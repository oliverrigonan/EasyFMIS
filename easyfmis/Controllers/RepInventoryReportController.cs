using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class RepInventoryReportController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =====================
        // Dropdown List Company
        // =====================
        public List<Entities.MstCompanyEntity> DropdownListCompany()
        {
            var companies = from d in db.MstCompanies
                            select new Entities.MstCompanyEntity
                            {
                                Id = d.Id,
                                Company = d.Company
                            };

            return companies.ToList();
        }

        // ====================
        // Dropdown List Branch
        // ====================
        public List<Entities.MstBranchEntity> DropdownListBranch(Int32 companyId)
        {
            var branches = from d in db.MstBranches
                           where d.CompanyId == companyId
                           select new Entities.MstBranchEntity
                           {
                               Id = d.Id,
                               Branch = d.Branch
                           };

            return branches.ToList();
        }

        // ==================
        // Dropdown List Item
        // ==================
        public List<Entities.MstArticleEntity> DropdownListItem()
        {
            var items = from d in db.MstArticles
                        where d.ArticleTypeId == 1
                        select new Entities.MstArticleEntity
                        {
                            Id = d.Id,
                            Article = d.Article
                        };

            return items.ToList();
        }

        // =====================
        // List Inventory Report
        // =====================
        public List<Entities.RepInventoryReportEntity> ListInventoryReport(DateTime startDate, DateTime endDate, Int32 companyId, Int32 branchId, String filter)
        {
            var beginningInventories = from d in db.TrnInventories
                                       where d.InventoryDate < startDate
                                       && d.MstBranch.CompanyId == companyId
                                       && d.BranchId == branchId
                                       && (d.MstArticle.ArticleBarCode.Contains(filter)
                                       || d.MstArticle.Article.Contains(filter)
                                       || d.MstArticleInventory.InventoryCode.Contains(filter)
                                       || d.MstArticle.MstUnit.Unit.Contains(filter))
                                       select new Entities.RepInventoryReportEntity
                                       {
                                           BarCode = d.MstArticle.ArticleBarCode,
                                           ItemDescription = d.MstArticle.Article,
                                           InventoryCode = d.MstArticleInventory.InventoryCode,
                                           Unit = d.MstArticle.MstUnit.Unit,
                                           BeginningQuantity = d.Quantity,
                                           InQuantity = 0,
                                           OutQuantity = 0,
                                           Endinguantity = d.Quantity,
                                           Cost = d.MstArticleInventory.Cost1,
                                           Amount = d.Quantity * d.MstArticleInventory.Cost1
                                       };

            var currentInventories = from d in db.TrnInventories
                                     where d.InventoryDate >= startDate
                                     && d.InventoryDate <= endDate
                                     && d.MstBranch.CompanyId == companyId
                                     && d.BranchId == branchId
                                     && (d.MstArticle.ArticleBarCode.Contains(filter)
                                       || d.MstArticle.Article.Contains(filter)
                                       || d.MstArticleInventory.InventoryCode.Contains(filter)
                                       || d.MstArticle.MstUnit.Unit.Contains(filter))
                                     select new Entities.RepInventoryReportEntity
                                     {
                                         BarCode = d.MstArticle.ArticleBarCode,
                                         ItemDescription = d.MstArticle.Article,
                                         InventoryCode = d.MstArticleInventory.InventoryCode,
                                         Unit = d.MstArticle.MstUnit.Unit,
                                         BeginningQuantity = 0,
                                         InQuantity = d.QuantityIn,
                                         OutQuantity = d.QuantityOut,
                                         Endinguantity = d.Quantity,
                                         Cost = d.MstArticleInventory.Cost1,
                                         Amount = d.Quantity * d.MstArticleInventory.Cost1
                                     };

            var unionInventories = beginningInventories.ToList().Union(currentInventories.ToList());
            if (unionInventories.Any())
            {
                var groupedInventories = from d in unionInventories
                                         group d by new
                                         {
                                             d.BarCode,
                                             d.ItemDescription,
                                             d.InventoryCode,
                                             d.Unit,
                                             d.Cost
                                         }
                                         into g
                                         select new Entities.RepInventoryReportEntity
                                         {
                                             BarCode = g.Key.BarCode,
                                             ItemDescription = g.Key.ItemDescription,
                                             InventoryCode = g.Key.InventoryCode,
                                             Unit = g.Key.Unit,
                                             BeginningQuantity = g.Sum(s => s.BeginningQuantity),
                                             InQuantity = g.Sum(s => s.InQuantity),
                                             OutQuantity = g.Sum(s => s.OutQuantity),
                                             Endinguantity = g.Sum(s => s.Endinguantity),
                                             Cost = g.Key.Cost,
                                             Amount = g.Sum(s => s.Amount)
                                         };

                if (groupedInventories.ToList().Any())
                {
                    return groupedInventories.ToList();
                }
                else
                {
                    return new List<Entities.RepInventoryReportEntity>();
                }
            }
            else
            {
                return new List<Entities.RepInventoryReportEntity>();
            }
        }

        // ================================
        // List Stock Card Inventory Report
        // ================================
        public List<Entities.RepInventoryReportStockCardEntity> ListStockCardInventoryReport(DateTime startDate, DateTime endDate, Int32 companyId, Int32 branchId, Int32 itemId, String filter)
        {
            var beginningInventories = from d in db.TrnInventories
                                       where d.InventoryDate < startDate
                                       && d.MstBranch.CompanyId == companyId
                                       && d.BranchId == branchId
                                       && d.ItemId == itemId
                                       select new
                                       {
                                           Document = "Beggining Balance",
                                           InventoryDate = startDate,
                                           d.MstArticle.MstUnit.Unit,
                                           d.Quantity,
                                           Cost = d.MstArticleInventory.Cost1
                                       };

            var groupedBeginningInventories = from d in beginningInventories
                                              group d by new
                                              {
                                                  d.Document,
                                                  d.InventoryDate,
                                                  d.Unit,
                                                  d.Cost
                                              }
                                              into g
                                              select new Entities.RepInventoryReportStockCardEntity
                                              {
                                                  Document = g.Key.Document,
                                                  InventoryDate = g.Key.InventoryDate,
                                                  Unit = g.Key.Unit,
                                                  BeginningQuantity = g.Sum(s => s.Quantity),
                                                  InQuantity = 0,
                                                  OutQuantity = 0,
                                                  Runninguantity = g.Sum(s => s.Quantity),
                                                  Cost = g.Key.Cost,
                                                  Amount = g.Key.Cost * g.Sum(s => s.Quantity)
                                              };

            var currentInventories = from d in db.TrnInventories
                                     where d.InventoryDate >= startDate
                                     && d.InventoryDate <= endDate
                                     && d.MstBranch.CompanyId == companyId
                                     && d.BranchId == branchId
                                     && d.ItemId == itemId
                                     select new Entities.RepInventoryReportStockCardEntity
                                     {
                                         Document = d.SIId != null ? "SI-" + d.TrnSalesInvoice.MstBranch.BranchCode + "-" + d.TrnSalesInvoice.SINumber :
                                                    d.RRId != null ? "RR-" + d.TrnReceivingReceipt.MstBranch.BranchCode + "-" + d.TrnReceivingReceipt.RRNumber :
                                                    d.INId != null ? "IN-" + d.TrnStockIn.MstBranch.BranchCode + "-" + d.TrnStockIn.INNumber :
                                                    d.OTId != null ? "OT-" + d.TrnStockOut.MstBranch.BranchCode + "-" + d.TrnStockOut.OTNumber :
                                                    d.STId != null ? "ST-" + d.TrnStockTransfer.MstBranch.BranchCode + "-" + d.TrnStockTransfer.STNumber : " ",
                                         InventoryDate = d.InventoryDate,
                                         Unit = d.MstArticle.MstUnit.Unit,
                                         BeginningQuantity = 0,
                                         InQuantity = d.QuantityIn,
                                         OutQuantity = d.QuantityOut,
                                         Runninguantity = d.Quantity,
                                         Cost = d.MstArticleInventory.Cost1,
                                         Amount = d.MstArticleInventory.Cost1 * d.Quantity
                                     };

            List<Entities.RepInventoryReportStockCardEntity> stockCard = new List<Entities.RepInventoryReportStockCardEntity>();
            Decimal runningQuantity = 0;

            if (groupedBeginningInventories.ToList().Any())
            {
                foreach (var groupedBeginningInventory in groupedBeginningInventories)
                {
                    stockCard.Add(new Entities.RepInventoryReportStockCardEntity()
                    {
                        Document = groupedBeginningInventory.Document,
                        InventoryDate = groupedBeginningInventory.InventoryDate,
                        Unit = groupedBeginningInventory.Unit,
                        BeginningQuantity = groupedBeginningInventory.BeginningQuantity,
                        InQuantity = groupedBeginningInventory.InQuantity,
                        OutQuantity = groupedBeginningInventory.OutQuantity,
                        Runninguantity = groupedBeginningInventory.Runninguantity,
                        Cost = groupedBeginningInventory.Cost,
                        Amount = groupedBeginningInventory.Amount
                    });

                    runningQuantity += groupedBeginningInventory.Runninguantity;
                }
            }

            if (currentInventories.ToList().Any())
            {
                foreach (var currentInventory in currentInventories)
                {
                    runningQuantity = currentInventory.InQuantity - currentInventory.OutQuantity;

                    stockCard.Add(new Entities.RepInventoryReportStockCardEntity()
                    {
                        Document = currentInventory.Document,
                        InventoryDate = currentInventory.InventoryDate,
                        Unit = currentInventory.Unit,
                        BeginningQuantity = currentInventory.BeginningQuantity,
                        InQuantity = currentInventory.InQuantity,
                        OutQuantity = currentInventory.OutQuantity,
                        Runninguantity = runningQuantity,
                        Cost = currentInventory.Cost,
                        Amount = currentInventory.Amount
                    });
                }
            }

            return stockCard.Where(d => d.Document.Contains(filter) == true || d.Unit.Contains(filter) == true).ToList();
        }

        // ========================
        // Stock Transfer In Report
        // ========================
        public List<Entities.RepInventoryReportStockInDetailReportEntity> ListStockInDetailReport(DateTime startDate, DateTime endDate, Int32 companyId, Int32 branchId, String filter)
        {
            var stockInDetails = from d in db.TrnStockInItems
                                 where d.TrnStockIn.INDate >= startDate
                                 && d.TrnStockIn.INDate <= endDate
                                 && d.TrnStockIn.MstBranch.CompanyId == companyId
                                 && d.TrnStockIn.BranchId == branchId
                                 && (d.TrnStockIn.MstBranch.Branch.Contains(filter)
                                 || d.TrnStockIn.INNumber.Contains(filter)
                                 || d.TrnStockIn.Remarks.Contains(filter)
                                 || d.TrnStockIn.MstUser.FullName.Contains(filter)
                                 || d.TrnStockIn.MstUser1.FullName.Contains(filter)
                                 || d.TrnStockIn.MstUser2.FullName.Contains(filter)
                                 || d.MstArticle.ArticleBarCode.Contains(filter)
                                 || d.MstArticle.Article.Contains(filter)
                                 || d.MstUnit.Unit.Contains(filter)
                                 || d.Quantity.ToString().Contains(filter)
                                 || d.Cost.ToString().Contains(filter)
                                 || d.Amount.ToString().Contains(filter)
                                 || d.BaseQuantity.ToString().Contains(filter)
                                 || d.BaseCost.ToString().Contains(filter))
                                 select new Entities.RepInventoryReportStockInDetailReportEntity
                                 {
                                     Id = d.Id,
                                     Branch = d.TrnStockIn.MstBranch.Branch,
                                     INNumber = d.TrnStockIn.INNumber,
                                     INDate = d.TrnStockIn.INDate,
                                     Remarks = d.TrnStockIn.Remarks,
                                     PreparedBy = d.TrnStockIn.MstUser.FullName,
                                     CheckedBy = d.TrnStockIn.MstUser1.FullName,
                                     ApprovedBy = d.TrnStockIn.MstUser2.FullName,
                                     ItemCode = d.MstArticle.ArticleBarCode,
                                     ItemDescription = d.MstArticle.Article,
                                     Unit = d.MstUnit.Unit,
                                     Quantity = d.Quantity,
                                     Cost = d.Cost,
                                     Amount = d.Amount,
                                     BaseQuantity = d.BaseQuantity,
                                     BaseCost = d.BaseCost,
                                 };

            return stockInDetails.ToList();
        }

        // =========================
        // Stock Transfer Out Report
        // =========================
        public List<Entities.RepInventoryReportStockOutDetailReportEntity> ListStockOutDetailReport(DateTime startDate, DateTime endDate, Int32 companyId, Int32 branchId, String filter)
        {
            var stockOutDetails = from d in db.TrnStockOutItems
                                  where d.TrnStockOut.OTDate >= startDate
                                  && d.TrnStockOut.OTDate <= endDate
                                  && d.TrnStockOut.MstBranch.CompanyId == companyId
                                  && d.TrnStockOut.BranchId == branchId
                                  && (d.TrnStockOut.MstBranch.Branch.Contains(filter)
                                  || d.TrnStockOut.OTNumber.Contains(filter)
                                  || d.TrnStockOut.Remarks.ToString().Contains(filter)
                                  || d.TrnStockOut.MstUser.FullName.Contains(filter)
                                  || d.TrnStockOut.MstUser1.FullName.Contains(filter)
                                  || d.TrnStockOut.MstUser2.FullName.Contains(filter)
                                  || d.MstArticle.ArticleBarCode.Contains(filter)
                                  || d.MstArticle.Article.Contains(filter)
                                  || d.MstArticleInventory.InventoryCode.Contains(filter)
                                  || d.MstUnit.Unit.Contains(filter)
                                  || d.Quantity.ToString().Contains(filter)
                                  || d.Cost.ToString().Contains(filter)
                                  || d.Amount.ToString().Contains(filter)
                                  || d.BaseQuantity.ToString().Contains(filter)
                                  || d.BaseCost.ToString().Contains(filter))
                                  select new Entities.RepInventoryReportStockOutDetailReportEntity
                                  {
                                      Id = d.Id,
                                      Branch = d.TrnStockOut.MstBranch.Branch,
                                      OTNumber = d.TrnStockOut.OTNumber,
                                      OTDate = d.TrnStockOut.OTDate,
                                      Remarks = d.TrnStockOut.Remarks,
                                      PreparedBy = d.TrnStockOut.MstUser.FullName,
                                      CheckedBy = d.TrnStockOut.MstUser1.FullName,
                                      ApprovedBy = d.TrnStockOut.MstUser2.FullName,
                                      ItemCode = d.MstArticle.ArticleBarCode,
                                      ItemDescription = d.MstArticle.Article,
                                      ItemInventoryCode = d.MstArticleInventory.InventoryCode,
                                      Unit = d.MstUnit.Unit,
                                      Quantity = d.Quantity,
                                      Cost = d.Cost,
                                      Amount = d.Amount,
                                      BaseQuantity = d.BaseQuantity,
                                      BaseCost = d.BaseCost
                                  };

            return stockOutDetails.ToList();
        }

        // ============================
        // Stock Transfer Detail Report
        // ============================
        public List<Entities.RepInventoryReportStockTransferDetailReportEntity> ListStockTransferDetailReport(DateTime startDate, DateTime endDate, Int32 companyId, Int32 branchId, String filter)
        {
            var stockTransferDetails = from d in db.TrnStockTransferItems
                                       where d.TrnStockTransfer.STDate >= startDate
                                       && d.TrnStockTransfer.STDate <= endDate
                                       && d.TrnStockTransfer.MstBranch.CompanyId == companyId
                                       && d.TrnStockTransfer.BranchId == branchId
                                       && (d.TrnStockTransfer.MstBranch.Branch.Contains(filter)
                                       || d.TrnStockTransfer.STNumber.Contains(filter)
                                       || d.TrnStockTransfer.MstBranch1.Branch.Contains(filter)
                                       || d.TrnStockTransfer.Remarks.Contains(filter)
                                       || d.TrnStockTransfer.MstUser.FullName.Contains(filter)
                                       || d.TrnStockTransfer.MstUser1.FullName.Contains(filter)
                                       || d.TrnStockTransfer.MstUser2.FullName.Contains(filter)
                                       || d.MstArticle.ArticleBarCode.Contains(filter)
                                       || d.MstArticle.Article.Contains(filter)
                                       || d.MstArticleInventory.InventoryCode.Contains(filter)
                                       || d.MstUnit.Unit.Contains(filter)
                                       || d.Quantity.ToString().Contains(filter)
                                       || d.Cost.ToString().Contains(filter)
                                       || d.Amount.ToString().Contains(filter)
                                       || d.BaseQuantity.ToString().Contains(filter)
                                       || d.BaseCost.ToString().Contains(filter))
                                       select new Entities.RepInventoryReportStockTransferDetailReportEntity
                                       {
                                           Id = d.Id,
                                           Branch = d.TrnStockTransfer.MstBranch.Branch,
                                           STNumber = d.TrnStockTransfer.STNumber,
                                           STDate = d.TrnStockTransfer.STDate,
                                           ToBranch = d.TrnStockTransfer.MstBranch1.Branch,
                                           Remarks = d.TrnStockTransfer.Remarks,
                                           PreparedBy = d.TrnStockTransfer.MstUser.FullName,
                                           CheckedBy = d.TrnStockTransfer.MstUser1.FullName,
                                           ApprovedBy = d.TrnStockTransfer.MstUser2.FullName,
                                           ItemCode = d.MstArticle.ArticleBarCode,
                                           ItemDescription = d.MstArticle.Article,
                                           ItemInventoryCode = d.MstArticleInventory.InventoryCode,
                                           Unit = d.MstUnit.Unit,
                                           Quantity = d.Quantity,
                                           Cost = d.Cost,
                                           Amount = d.Amount,
                                           BaseQuantity = d.BaseQuantity,
                                           BaseCost = d.BaseCost
                                       };

            return stockTransferDetails.ToList();
        }

        // =========
        // Item List
        // =========
        public List<Entities.RepInventoryReportItemListReportEntity> ListItem(String filter)
        {
            var itemList = from d in db.MstArticles
                           where d.ArticleTypeId == 1
                           && d.IsLocked == true
                           && (d.ArticleCode.Contains(filter)
                           || d.Article.Contains(filter)
                           || d.ArticleBarCode.Contains(filter)
                           || d.Category.Contains(filter)
                           || d.MstUnit.Unit.Contains(filter)
                           || d.DefaultPrice.ToString().Contains(filter))
                           select new Entities.RepInventoryReportItemListReportEntity
                           {
                               Id = d.Id,
                               Code = d.ArticleCode,
                               ItemDescription = d.Article,
                               BarCode = d.ArticleBarCode,
                               Category = d.Category,
                               Unit = d.MstUnit.Unit,
                               Price = d.DefaultPrice
                           };

            return itemList.ToList();
        }
    }
}
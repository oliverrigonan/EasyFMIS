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
        public List<Entities.RepInventoryReportEntity> ListInventoryReport(DateTime startDate, DateTime endDate, Int32 companyId, Int32 branchId)
        {
            var beginningInventories = from d in db.TrnInventories
                                       where d.InventoryDate < startDate
                                       && d.MstBranch.CompanyId == companyId
                                       && d.BranchId == branchId
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
        public List<Entities.RepInventoryReportStockCardEntity> ListStockCardInventoryReport(DateTime startDate, DateTime endDate, Int32 companyId, Int32 branchId, Int32 itemId)
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

            return stockCard.ToList();
        }
    }
}
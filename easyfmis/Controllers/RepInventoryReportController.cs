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
        public List<Entities.RepInventoryReport> ListInventoryReport(DateTime startDate, DateTime endDate, Int32 companyId, Int32 branchId)
        {
            var beginningInventories = from d in db.TrnInventories
                                       where d.InventoryDate < startDate
                                       && d.MstBranch.CompanyId == companyId
                                       && d.BranchId == branchId
                                       select new Entities.RepInventoryReport
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
                                     select new Entities.RepInventoryReport
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
                                         select new Entities.RepInventoryReport
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
                    return new List<Entities.RepInventoryReport>();
                }
            }
            else
            {
                return new List<Entities.RepInventoryReport>();
            }
        }

        // ================================
        // List Stock Card Inventory Report
        // ================================
        public List<Entities.RepInventoryReportStockCard> ListStockCardInventoryReport(DateTime startDate, DateTime endDate, Int32 companyId, Int32 branchId, Int32 itemId)
        {
            var beginningInventories = from d in db.TrnInventories
                                       where d.InventoryDate < startDate
                                       && d.MstBranch.CompanyId == companyId
                                       && d.BranchId == branchId
                                       && d.ItemId == itemId
                                       select new Entities.RepInventoryReportStockCard
                                       {
                                           
                                       };

            var currentInventories = from d in db.TrnInventories
                                     where d.InventoryDate >= startDate
                                     && d.InventoryDate <= endDate
                                     && d.MstBranch.CompanyId == companyId
                                     && d.BranchId == branchId
                                     && d.ItemId == itemId
                                     select new Entities.RepInventoryReportStockCard
                                     {
                                        
                                     };

            var unionInventories = beginningInventories.ToList().Union(currentInventories.ToList());
            if (unionInventories.Any())
            {
                var groupedInventories = from d in unionInventories
                                         group d by new
                                         {
                                             
                                         }
                                         into g
                                         select new Entities.RepInventoryReportStockCard
                                         {
                                            
                                         };

                if (groupedInventories.ToList().Any())
                {
                    return groupedInventories.ToList();
                }
                else
                {
                    return new List<Entities.RepInventoryReportStockCard>();
                }
            }
            else
            {
                return new List<Entities.RepInventoryReportStockCard>();
            }
        }
    }
}

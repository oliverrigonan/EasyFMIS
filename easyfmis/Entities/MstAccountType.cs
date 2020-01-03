using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    class MstAccountType
    {
        public Int32 Id { get; set; }
        public String ArticleTypeCode { get; set; }
        public String ArticleType { get; set; }
        public Int32 ArticleCategoryId { get; set; }
    }
}

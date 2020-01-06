using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    class MstArticleGroupEntity
    {
        public Int32 Id { get; set; }
        public String ArticleGroup { get; set; }
        public Int32 ArticleTypeId { get; set; }
        public String ArticleType { get; set; }
        public Int32 AccountId { get; set; }
        public String Account { get; set; }
    }
}

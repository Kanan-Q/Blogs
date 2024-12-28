using BlogDAL.Context;
using BlogMain.Entites.Category;
using BlogMain.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.Repostories
{
    public class CategoryRepostory:GenericRepostory<Category>,ICategoryRepostory
    {
        public CategoryRepostory(AppDbContext _sql) : base(_sql) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotebookMarket.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationContext _applicationContext;
        public CategoryRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public IEnumerable<Category> AllCategories => _applicationContext.Categories;
    }
}

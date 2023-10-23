using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Services
{
    public class CategoryService
    {
        private readonly DatabaseContext _context;

        public CategoryService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _context.Categories.Include(c => c.SubCategories).ToListAsync();

            // Convert list of Categories into a tree
            var categoriesNodes = categories.Where(c => c.ParentCategoryId == null)
                                                 .AsParallel()
                                                 .ToList();
            return categoriesNodes;
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }

        [ForeignKey("ParentCategoryId")]
        public virtual Category? ParentCategory { get; set; } // This is the parent category of the current category

        [InverseProperty("ParentCategory")]
        public virtual ICollection<Category>? SubCategories { get; set; } // This is the collection of subcategories of the current category
    }
}

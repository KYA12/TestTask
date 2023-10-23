using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using TestTask.Services;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _service;

        public CategoriesController(CategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var categories = await _service.GetCategories();

            if (categories == null) return NotFound();

            return Ok(categories);
        }
    }
}
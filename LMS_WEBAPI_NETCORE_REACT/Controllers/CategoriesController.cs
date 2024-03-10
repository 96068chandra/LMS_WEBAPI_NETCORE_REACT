using Microsoft.AspNetCore.Mvc;
using LMS_WEBAPI_NETCORE_REACT.Models;
using LMS_WEBAPI_NETCORE_REACT.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS_WEBAPI_NETCORE_REACT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _categoryRepository.GetItems();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryRepository.GetItemById(id);

            if (category.Value == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] AddCategory addCategory)
        {
            if (addCategory == null)
            {
                return BadRequest("Invalid request body");
            }

            var category = new Category
            {
                Title = addCategory.Title,
                Description = addCategory.Description,
                ThumbnailImagePath = addCategory.ThumbnailImagePath
            };

            var result = await _categoryRepository.Create(category);
            return result.Result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            return await _categoryRepository.Update(id, category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return await _categoryRepository.Delete(id);
        }
    }
}

using LearningManagementSystem_Using_NETCoreWebAPI.Data;
using LMS_WEBAPI_NETCORE_REACT.Models;
using LMS_WEBAPI_NETCORE_REACT.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS_WEBAPI_NETCORE_REACT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryItemsController : ControllerBase
    {
        private readonly IRepository<CategoryItem> _categoryItemRepository;

        public CategoryItemsController(IRepository<CategoryItem> categoryItemRepository)
        {
            _categoryItemRepository = categoryItemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryItem>>> GetItems()
        {
            var categoryItems = await _categoryItemRepository.GetItems();
            return Ok(categoryItems);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryItem>> GetItemById(int Id)
        {
            var categoryItem = await _categoryItemRepository.GetItemById(Id);
            if (categoryItem != null)
            {
                return Ok(categoryItem);
            }
            return BadRequest();

        }
        [HttpPost]
        public async Task<ActionResult<CategoryItem>> CreateCategoryItem([FromBody] CategoryItem categoryItem)
        {
            if (categoryItem == null)
            {
                return BadRequest("Invalid request body");
            }

            var result = await _categoryItemRepository.Create(categoryItem);
            return result.Result;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryItem(int id, [FromBody] CategoryItem categoryItem)
        {
            return await _categoryItemRepository.Update(id, categoryItem);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryItem(int id)
        {
            return await _categoryItemRepository.Delete(id);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS_WEBAPI_NETCORE_REACT.Models;
using LearningManagementSystem_Using_NETCoreWebAPI.Data;

namespace LMS_WEBAPI_NETCORE_REACT.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly DataContext _dataContext;

        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ActionResult<IEnumerable<Category>>> GetItems()
        {
            var categories = await _dataContext.Category.ToListAsync();
            return categories;
        }

        public async Task<ActionResult<Category>> GetItemById(int id)
        {
            var category = await _dataContext.Category.FindAsync(id);

            if (category == null)
            {
                return new NotFoundResult();
            }

            return category;
        }

        public async Task<ActionResult<Category>> Create([FromBody] Category model)
        {
            _dataContext.Category.Add(model);
            return await  save() ? new CreatedAtRouteResult("GetCategory", new { id = model.Id }, model) : new StatusCodeResult(500);
        }

        public async Task<ActionResult> Update(int id,[FromBody] Category model)
        {
            if (id != model.Id)
            {
                return new BadRequestResult();
            }

            _dataContext.Entry(model).State = EntityState.Modified;

            return await save() ? new NoContentResult() : new StatusCodeResult(500);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var category = await _dataContext.Category.FindAsync(id);

            if (category == null)
            {
                return new NotFoundResult();
            }

            _dataContext.Category.Remove(category);

            return await save() ? new NoContentResult() : new StatusCodeResult(500);
        }

        public async Task<bool> save()
        {
            return await _dataContext.SaveChangesAsync() >= 0;
        }

        public bool ItemExists(int id)
        {
            return _dataContext.Category.Any(x => x.Id == id);
        }

        public bool ItemExists(string itemName)
        {
            return _dataContext.Category.Any(x => x.Title.ToLower().Trim() == itemName.ToLower().Trim());
        }
    }
}

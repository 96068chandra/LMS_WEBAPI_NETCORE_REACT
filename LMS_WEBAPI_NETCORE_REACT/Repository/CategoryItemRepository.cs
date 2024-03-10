using LearningManagementSystem_Using_NETCoreWebAPI.Data;
using LMS_WEBAPI_NETCORE_REACT.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEBAPI_NETCORE_REACT.Repository
{
    public class CategoryItemRepository : IRepository<CategoryItem>
    {
        private readonly DataContext dataContext;

        public CategoryItemRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        
        public async Task<ActionResult<CategoryItem>> Create([FromBody]CategoryItem model)
        {
             dataContext.CategoryItem.Add(model);
            return await save() ? new CreatedAtRouteResult("GetCategory", new { id = model.Id }, model) : new StatusCodeResult(500);

        }

        public async Task<ActionResult> Delete(int Id)
        {
            var categoryItem = await dataContext.CategoryItem.FindAsync(Id);
            if (categoryItem == null)
            {
                return new NotFoundResult();
            }
            dataContext.CategoryItem.Remove(categoryItem);
            return await save() ? new NoContentResult() : new StatusCodeResult(500);
        }

        public async Task<ActionResult<CategoryItem>> GetItemById(int Id)
        {
            var categoryItem = await dataContext.CategoryItem.FindAsync(Id);
            if(categoryItem == null)
            {
                return new NotFoundResult();
            }
            return categoryItem;
        }

        public async Task<ActionResult<IEnumerable<CategoryItem>>> GetItems()
        {
            var categoryItems= await dataContext.CategoryItem.ToListAsync();
            return categoryItems;
        }

        public bool ItemExists(int id)
        {
            return dataContext.CategoryItem.Any(x => x.Id == id);
        }

        public bool ItemExists(string itemName)
        {
            return dataContext.Category.Any(x=>x.Title.ToLower().Trim() == itemName.ToLower().Trim());
            
        }

        public async Task<bool> save()
        {
            return await dataContext.SaveChangesAsync()>=0;
        }

        public async Task<ActionResult> Update(int id,[FromBody] CategoryItem model)
        {
            if (id != model.Id)
            {
                return new BadRequestResult();
            }
            dataContext.Entry(model).State = EntityState.Modified;
            return await save()? new NoContentResult():new StatusCodeResult(500);
        }
    }
}

using LearningManagementSystem_Using_NETCoreWebAPI.Data;
using LMS_WEBAPI_NETCORE_REACT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LMS_WEBAPI_NETCORE_REACT.Repository
{
    public class MediaTypeRepository:IRepository<MediaType>
    {
        private readonly DataContext _dataContext;

        public MediaTypeRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public async Task<ActionResult<MediaType>> Create([FromBody]MediaType model)
        {
            _dataContext.MediaType.Add(model);
            return await save() ? new CreatedAtRouteResult("GetMediaType", new { id= model.Id }, model) : new StatusCodeResult(500);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var mediaType = await _dataContext.MediaType.FindAsync(id);
            if (mediaType == null)
            {
                return new NotFoundResult();

            }
            _dataContext.MediaType.Remove(mediaType);
            return await save() ? new NoContentResult() : new StatusCodeResult(500);

        }

        public async Task<ActionResult<MediaType>> GetItemById(int Id)
        {
            var mediaType = await _dataContext.MediaType.FindAsync(Id);
            if (mediaType == null)
            {
                return new NotFoundResult();

            }
            return mediaType;
        }

        public async Task<ActionResult<IEnumerable<MediaType>>> GetItems()
        {
            var mediaTypes = await _dataContext.MediaType.ToListAsync();
            return mediaTypes;
        }

        public bool ItemExists(int id)
        {
            return _dataContext.MediaType.Any(x=>x.Id == id);
        }

        public bool ItemExists(string itemName)
        {
            return _dataContext.MediaType.Any(x => x.Title.ToLower().Trim() == itemName.ToLower().Trim());

        }

        public async Task<bool> save()
        {
            return await _dataContext.SaveChangesAsync()>=0;
        }

        public async Task<ActionResult> Update(int id,[FromBody] MediaType model)
        {
            if(id !=model.Id)
            {
                return new BadRequestResult();
            }
            _dataContext.Entry(model).State = EntityState.Modified;
            return await save() ? new NoContentResult(): new StatusCodeResult(500);

        }
    }
}

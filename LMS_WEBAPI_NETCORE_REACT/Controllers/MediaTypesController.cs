using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LMS_WEBAPI_NETCORE_REACT.Models;
using LearningManagementSystem_Using_NETCoreWebAPI.Data;
using LMS_WEBAPI_NETCORE_REACT.Repository;

namespace LMS_WEBAPI_NETCORE_REACT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaTypesController : ControllerBase
    {
        private readonly MediaTypeRepository _repository;

        public MediaTypesController(MediaTypeRepository repository)
        {
            _repository = repository;
        }

        // GET: api/MediaTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaType>>> GetMediaType()
        {
            return await _repository.GetItems();
        }

        // GET: api/MediaTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaType>> GetMediaType(int id)
        {
            var mediaType = await _repository.GetItemById(id);

            if (mediaType == null)
            {
                return NotFound();
            }

            return mediaType;
        }

        // PUT: api/MediaTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMediaType(int id, MediaType mediaType)
        {
            if (id != mediaType.Id)
            {
                return BadRequest();
            }

           
            return await _repository.Update(id, mediaType);
        }

        // POST: api/MediaTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MediaType>> PostMediaType(MediaType mediaType)
        {
            if (mediaType == null)
            {
                return BadRequest("Invalid request");
            }
            var result = await _repository.Create(mediaType);

            return result.Result;
        }

        // DELETE: api/MediaTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMediaType(int id)
        {
           return await _repository.Delete(id);

           
        }

    }
}

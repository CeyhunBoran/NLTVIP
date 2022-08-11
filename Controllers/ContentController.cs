using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Testapi.Data.Models;
using Testapi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Testapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }
        
        // GET: api/<ContentController>/menu
        [EnableCors("allow")]
        [HttpGet("menu")]
        public IEnumerable<string> GetMenuItems()
        {
            return _contentService.GetMenuItems();
        }

        //GET api/<ContentController>/menuName
        [EnableCors("allow")]
        [HttpGet("categories/bymenu/{menuName}")]
        public IList<string> GetCategory(string menuName)
        {
            return _contentService.GetCategoriesByMenu(menuName);
        }
        [EnableCors("allow")]
        [HttpGet("movies/{categoryPath}")]
        public IList<Content> GetMoviesByCategory(string categoryPath)
        {
        	return _contentService.GetMoviesByCategory(categoryPath.Replace("%2F", "/"));
        }
        //GET api/<ContentController>/id
        [EnableCors("allow")]
        [HttpGet("id")]
        public Content GetMoviesById(string id)
        {
            return _contentService.GetMovieById(id);
        }
        // POST api/<ContentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ContentController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] string value)
        {
        }

        // DELETE api/<ContentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

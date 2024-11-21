using Blog.Core.Entities;
using Blog.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public IActionResult GetAllTags()
        {
            var tags = _tagService.GetAllTags();
            return tags == null ? NotFound() : Ok(tags);
        }

        [HttpGet("{id}")]
        public IActionResult GetTagById(int id)
        {
            var tag = _tagService.GetTagById(id);
            return tag == null ? NotFound() : Ok(tag);
        }

        [HttpPost]
        public IActionResult AddTag([FromBody] Tag tag)
        {
            bool success = _tagService.AddTag(tag);
            return success ? Ok() : NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTag(int id, [FromBody] Tag tag)
        {
            bool success = _tagService.UpdateTag(id, tag);
            return success ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTag(int id)
        {
            bool success = _tagService.DeleteTag(id);
            return success ? Ok() : NotFound();
        }
    }
}


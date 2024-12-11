using Blog.Core.Entities;
using Blog.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var posts = _postService.GetAllPosts();
            return posts == null ? NotFound() : Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            var post = _postService.GetPostById(id);
            return post == null ? NotFound() : Ok(post);
        }

        [HttpPost]
        public IActionResult AddPost([FromBody] Post post)
        {
            bool success = _postService.AddPost(post);
            return success ? Ok() : NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, [FromBody] Post post)
        {
            bool success = _postService.UpdatePost(id, post);
            return success ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            bool success = _postService.DeletePost(id);
            return success ? Ok() : NotFound();
        }
    }
}

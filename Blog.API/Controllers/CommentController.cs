using Blog.Core.Entities;
using Blog.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        // GET: api/<CommentController>
        [HttpGet]
        public ActionResult<IEnumerable<Comment>> Get()
        {
            var comments = _commentService.GetAllComments();
            return comments == null ? NotFound() : comments;
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public ActionResult<Comment> Get(int id)
        {
            var comment = _commentService.GetCommentById(id);
            return comment == null ? NotFound() : comment;
        }

        // POST api/<CommentController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Comment comment)
        {
            bool success = _commentService.AddComment(comment);
            return success ? true : NotFound();
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Comment comment)
        {
            bool success = _commentService.UpdateComment(id, comment);
            return success ? true : NotFound();
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {

            bool success = _commentService.DeleteComment(id);
            return success ? true : NotFound();
        }
    }
}

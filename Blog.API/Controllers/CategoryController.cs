using Microsoft.AspNetCore.Mvc;
using Blog.Core.Services;
using Blog.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CategoryContoller>
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var categories = _categoryService.GetAllCategories();
            if (categories == null)
            {
                return NotFound();
            }
            return categories;
        }

        // GET api/<CategoryContoller>/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            return category == null ? NotFound() : category;
        }

        // POST api/<CategoryContoller>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Category category)
        {
            bool success = _categoryService.AddCategory(category);
            return success ? true : NotFound();
        }

        // PUT api/<CategoryContoller>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Category category)
        {
            bool success = _categoryService.UpdateCategory(id, category);

            return success ? true : NotFound();
        }

        // DELETE api/<CategoryContoller>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool success = _categoryService.DeleteCategory(id);
            return success ? true : NotFound();
        }
    }
}

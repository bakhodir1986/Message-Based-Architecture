using Catalog_Service_BLL;
using Microsoft.AspNetCore.Mvc;

namespace Catalog_Service_Rest_Api.Controllers
{
    [ApiController]
    [Route("[api/category]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return categoryService.GetCategories();
        }

        [HttpGet("{categoryid}/items/{page}")]
        public IEnumerable<Item> GetItems([FromRoute] string categoryid, [FromRoute] int page)
        {
            return categoryService.GetItems(new Guid(categoryid), page);
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult Post([FromBody] Category category)
        {
            if (category == null) return BadRequest();
            categoryService.AddCategory(category);
            return Ok();
        }

        [HttpPost("{categoryid}/items")]
        [Consumes("application/json")]
        public IActionResult PostItem([FromRoute] string categoryid, [FromBody] Item item)
        {
            if (string.IsNullOrEmpty(categoryid) || item == null) return BadRequest();
            categoryService.AddItem(new Guid(categoryid), item);

            return Ok();
        }

        [HttpPut]
        [Consumes("application/json")]
        public IActionResult Put([FromBody] Category category)
        {
            if (category == null) return BadRequest();

            categoryService.UpdateCategory(category);
            return Ok();
        }

        [HttpPut("{categoryid}/items")]
        [Consumes("application/json")]
        public IActionResult PutItem([FromBody] Item item)
        {
            if (item == null) return BadRequest();
            categoryService.UpdateItem(item);

            return Ok();
        }

        [HttpDelete("{categoryid}")]
        public IActionResult Delete([FromRoute] string categoryid)
        {
            if (string.IsNullOrEmpty(categoryid)) return BadRequest();

            categoryService.DeleteCategory(new Guid(categoryid));

            return Ok();
        }

        [HttpDelete("{categoryid}/items/{itemId}")]
        public IActionResult DeleteItem([FromRoute] string categoryid, [FromRoute] string itemId)
        {
            if (string.IsNullOrEmpty(categoryid) || string.IsNullOrEmpty(itemId)) return BadRequest();

            categoryService.DeleteItem(new Guid(itemId));

            return Ok();
        }

    }
}

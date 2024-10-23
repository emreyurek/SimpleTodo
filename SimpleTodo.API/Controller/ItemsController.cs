using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleTodo.Business.Abstract;
using SimpleTodo.Business.Concrete;
using SimpleTodo.Entities;
using System.Threading.Tasks;

namespace SimpleTodo.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private ITodoService _todoService;
        public ItemsController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        
        /// <summary>
        /// Get All Items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get() {
            return Ok(await _todoService.GetAllItems());
        }

        /// <summary>
        /// Get Item By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var item =await _todoService.GetItemById(id);
            if(item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        /// <summary>
        /// Create an Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateItem([FromBody]Item item)
        {
            var createdItem = await _todoService.CreateItem(item);
            return CreatedAtAction("GetItemById", new { id = createdItem.Id },createdItem);
        }

        /// <summary>
        /// Update the Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateItem([FromBody]Item item)
        {
            if(await _todoService.GetItemById(item.Id) != null)
            {
                return Ok(await _todoService.UpdateItem(item));
            }
            return NotFound();
        }

        /// <summary>
        /// Delete the Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            if(await _todoService.GetItemById(id) != null)
            {
                await _todoService.DeleteItem(id);
                return Ok();            
            }
            return NotFound();
        }

    }
}

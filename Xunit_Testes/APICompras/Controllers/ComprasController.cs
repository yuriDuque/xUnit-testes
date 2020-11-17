using APICompras.Models;
using APICompras.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APICompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly ICompraService _service;
        public ComprasController(ICompraService service)
        {
            _service = service;
        }
        // GET api/compras
        [HttpGet]
        public ActionResult<IEnumerable<CompraItem>> Get()
        {
            var items = _service.GetAllItems();
            return Ok(items);
        }
        // GET api/compras/5
        [HttpGet("{id}")]
        public ActionResult<CompraItem> Get(int id)
        {
            var item = _service.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        // POST api/compras
        [HttpPost]
        public ActionResult Post([FromBody] CompraItem value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _service.Add(value);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }
        // DELETE api/compras/5
        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var existingItem = _service.GetById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            _service.Remove(id);
            return Ok();
        }
    }
}

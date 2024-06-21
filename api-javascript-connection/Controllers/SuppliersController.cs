using api_javascript_connection.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_javascript_connection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly NORTHWINDContext _context;

        public SuppliersController(NORTHWINDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSuppliers()
        {
            return Ok(_context.Suppliers);
        }
        [HttpPost]
        public IActionResult CreateSupplier([FromForm] Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var s = new Supplier
            {
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                Address = supplier.Address
            };

            _context.Suppliers.Add(s);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplier([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }
        //Edit supplier
        [HttpPut("Edit")]
        public IActionResult Update([FromForm] Supplier s)
        {
            var supplier = _context.Suppliers.Find(s.SupplierId);
            if (supplier == null)
            {
                return NotFound();
            }
            supplier.CompanyName = s.CompanyName;
            supplier.ContactName = s.ContactName;
            supplier.Address = s.Address;
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            var supplier = _context.Suppliers.Find(Int32.Parse(id));
            if (supplier == null)
            {
                return NotFound(new { message = "Not found supplier" });
            }

            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
            return Ok();
        }

        private bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.SupplierId == id);
        }
    }
}

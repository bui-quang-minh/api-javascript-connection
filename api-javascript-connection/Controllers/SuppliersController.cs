using api_javascript_connection.Interfaces;
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
        private IRepository _repository;

        public SuppliersController(NORTHWINDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSuppliers()
        {
            return Ok(_context.Suppliers);
        }

        //Edit supplier
        [HttpPut("Edit")]
        public IActionResult Update([FromForm]Supplier s)
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
            var products = _context.Products.Where(p => p.SupplierId == supplier.SupplierId);
            if (products != null) { 
                return BadRequest(new { message = "Supplier has product"});
            }

            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
            return Ok();
        }
    }
}

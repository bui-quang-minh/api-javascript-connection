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
    }
}

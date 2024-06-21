using api_javascript_connection.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using web_javascript_connection.Models;

namespace web_javascript_connection.Controllers
{
    public class HomeController : Controller
    {
        private string _url = "http://localhost:5166/api/Suppliers";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    using (var response = await client.GetAsync(_url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var data = await response.Content.ReadAsStringAsync();
                            var dataObj = JsonConvert.DeserializeObject<List<Supplier>>(data);
                            if (dataObj != null)
                            {
                                return View(dataObj);
                            }
                            else
                            {
                                return RedirectToAction("Index", new { Message = "Data Error" });
                            }
                        }
                        else
                        {
                            return RedirectToAction("Index", new { Message = "Response failed" });
                        }
                    }
                }
                catch (HttpRequestException e)
                {
                    return RedirectToAction("Index", new { Message = "Error connecting to service." + e });
                }
            }
        }
    }
}

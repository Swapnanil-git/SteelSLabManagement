using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SteelSlabManagement.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SteelSlabManagement.Controllers
{
    public class OrdersController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string LogicAppUrl = "<https://prod-20.centralindia.logic.azure.com:443/workflows/b84efeeb63694c21bc7af471eb25e9f9/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=1.0&sig=dSM9yPghwN_tbFQvPoaTz0Pfn-srWLrSA7r3r8ZHKE0>"; // Replace with the Logic App endpoint

        public OrdersController()
        {
            _httpClient = new HttpClient();
        }

        // GET: Orders
        public IActionResult Index()
        {
            // Display the existing orders (fetch from a service or static list if needed).
            // For now, we'll assume this displays dummy data or uses a different service.
            return View();
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    double density = GetDensityByGrade(order.Grade);
                    double volume = order.Length * order.Width * order.Thickness; // Assuming dimensions are in cm³
                    order.Weight = volume * density * order.Quantity;
                    var jsonContent = JsonConvert.SerializeObject(order);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    var response = await _httpClient.PostAsync(LogicAppUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    // Handle errors from Logic App
                    ModelState.AddModelError("", $"Failed to create order. Logic App response: {response.StatusCode}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                }
            }

            return View(order);
        }

        
            private double GetDensityByGrade(string grade)
            {
                return grade switch
                {
                  "A" => 7.75,
                  "B" => 8.0,
                  "C" => 7.0,
                _ => throw new ArgumentException("Invalid grade")
                };
            }
        

        // Helper Method: Prepare Logic App Request
        private async Task<HttpResponseMessage> SendToLogicApp(Order order)
        {
            var jsonContent = JsonConvert.SerializeObject(order);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync(LogicAppUrl, content);
        }
    }
}

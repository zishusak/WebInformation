using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebInformation.Models;
using System.Net.Http;
using System.Threading.Tasks;
using IpInfo;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace WebInformation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(5)
            };
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GeoLocations()
        {
            return View();
        }
        private async Task<string> GetIPAddress()
        {
            var ipAddress = await _httpClient.GetAsync($"http://ipinfo.io/ip");
           
            if (ipAddress.IsSuccessStatusCode)
            {
                var json = await ipAddress.Content.ReadAsStringAsync();
                return json.ToString();
            }
            return "";
        }
        public async Task<IActionResult> GetGeoInfo(string ip)
        {
            //I have already created this function under GeoInfoProvider class.
            if(ip == null)
            {
                var ipAddress = await GetIPAddress();
                // When geting ipaddress, call this function and pass ipaddress as given below
                var response = await _httpClient.GetAsync($"http://ipinfo.io/" + ipAddress + "/json?token=28ee21f9e8a696");
                if (response.IsSuccessStatusCode)
                {
                    //var jsons = await response.Content.ReadAsStringAsync();
                    //return  View(jsons.ToString());
                    var jsons = await response.Content.ReadAsStringAsync();
                    GetInfoViewModel models = new GetInfoViewModel();
                    models = JsonConvert.DeserializeObject<GetInfoViewModel>(jsons);
                    return View(models);
                }
                return View(null);
            }
            else
            {
                // When geting ipaddress, call this function and pass ipaddress as given below
                var response = await _httpClient.GetAsync($"http://ipinfo.io/" + ip + "/json?token=28ee21f9e8a696");
                if (response.IsSuccessStatusCode)
                {
                    //var jsons = await response.Content.ReadAsStringAsync();
                    //return  View(jsons.ToString());
                    var jsons = await response.Content.ReadAsStringAsync();
                    GetInfoViewModel models = new GetInfoViewModel();
                    models = JsonConvert.DeserializeObject<GetInfoViewModel>(jsons);
                    return View(models);
                }
                return View(null);
            }
            //Console.WriteLine(ipAddress);

            
        }

        public IActionResult GraphData()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
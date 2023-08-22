using Kibana.Rule.Engine.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Diagnostics;
using System.Security.Policy;

namespace Rule.Engine.Kibana.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", accessToken);
            string url = "https://localhost:7250" + "/WeatherForecast";
            string json = await client.GetStringAsync(url);

            // Url = "https://localhost:7250" + "/api/WeatherForecast",

            //LogToken();
            return View();
            
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Login()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            SignOut("Cookies", "oidc");
           
            HttpContext.Session.SetString("JWTToken", "");
            return RedirectToAction("Index", "Home");

        }
        //public async Task LogToken()
        //{
        //    var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
        //    var accessToken = await HttpContext.GetTokenAsync("access_token");

        //    HttpContext.Session.SetString("token", accessToken);
        //    Debug.WriteLine($"identity token {identityToken}");


        //}
        //public async Task Logout()
        //{
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        //}
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
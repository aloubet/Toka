using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TakaApp.Models;
using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;

namespace TakaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string UrlBase = "https://localhost:44307/api/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
/*          var info = new List<PersonasFisicas>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlBase);
                HttpResponseMessage HResp = await client.GetAsync("PersonasFisicas");
                
                if (HResp.IsSuccessStatusCode)
                {
                    var result = HResp.Content.ReadAsStringAsync().Result;
                    info = JsonConvert.DeserializeObject<List<PersonasFisicas>>(result);
                }
            }*/
            return View();
        }

        public async Task<RedirectToActionResult> LoginAsync(string usr, string pass)
        {
            var usuario = new Usuarios();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlBase);
                HttpResponseMessage HResp = await client.GetAsync("Usuarios/" + usr);

                if (HResp.IsSuccessStatusCode)
                {
                    var result = HResp.Content.ReadAsStringAsync().Result;
                    usuario = JsonConvert.DeserializeObject<Usuarios>(result);
                    if (usuario != null)
                    {
                        byte[] data = Convert.FromBase64String(usuario.Password);
                        byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
                        var DecryptedPass = Encoding.Unicode.GetString(decrypted);

                        if (DecryptedPass == pass)
                        {
                            var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()));
                            identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Nombre));
                            await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                                new ClaimsPrincipal(identity));
                            return RedirectToAction("index", "PersonasFisicas");
                        }
                    }
                }
            }
            return RedirectToAction("index","Home");
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

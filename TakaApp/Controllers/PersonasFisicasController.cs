using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TakaApp.Models;

namespace TakaApp.Controllers
{
    [Authorize]
    public class PersonasFisicasController : Controller
    {
        private readonly string UrlBase = "https://localhost:44307/api/";
        public async Task<IActionResult> IndexAsync()
        {
            var info = new List<PersonasFisicas>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlBase);
                HttpResponseMessage HResp = await client.GetAsync("PersonasFisicas");

                if (HResp.IsSuccessStatusCode)
                {
                    var result = HResp.Content.ReadAsStringAsync().Result;
                    info = JsonConvert.DeserializeObject<List<PersonasFisicas>>(result);
                    return View(info);
                }
            }
            return View(); 
        }

        public ActionResult Nuevo()
        {
            var Nuevo = new List<PersonasFisicas>();
            return View(Nuevo);
        }

        public async Task<IActionResult> Guardar(PersonasFisicas Persona)
        {
            var info = new List<PersonasFisicas>();
            using (var client = new HttpClient())
            {
                var claims = HttpContext.User.Identities.First().Claims.ToList();
                var IdUser = claims.FirstOrDefault().Value;

                client.BaseAddress = new Uri(UrlBase);
                Persona.FechaCreacion = DateTime.Now;
                Persona.FechaModificacion = DateTime.Now;
                Persona.UsuarioCreador = Int16.Parse(IdUser);
                Persona.UsuarioModifica = Int16.Parse(IdUser);
                string strPersona = JsonConvert.SerializeObject(Persona);
                HttpContent cstrPersona = new StringContent(strPersona, Encoding.UTF8, "application/json");
                HttpResponseMessage HResp = await client.PostAsync("PersonasFisicas", cstrPersona);

                if (HResp.IsSuccessStatusCode)
                {
                    ViewData["SuccessMessage"] = "Success";
                }
            }
            return RedirectToAction("Index", "PersonasFisicas");
        }
        public async Task<IActionResult> Editar(int Id)
        {
            var info = new PersonasFisicas();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlBase);
                HttpResponseMessage HResp = await client.GetAsync("PersonasFisicas/" + Id);

                if (HResp.IsSuccessStatusCode)
                {
                    var result = HResp.Content.ReadAsStringAsync().Result;
                    info = JsonConvert.DeserializeObject<PersonasFisicas>(result);
                }
            }
            return View(info);
        }

        public async Task<IActionResult> GuardarEditar(PersonasFisicas Persona)
        {
            var info = new List<PersonasFisicas>();
            using (var client = new HttpClient())
            {
                var claims = HttpContext.User.Identities.First().Claims.ToList();
                var IdUser = claims.FirstOrDefault().Value;

                client.BaseAddress = new Uri(UrlBase);
                Persona.FechaModificacion = DateTime.Now;
                Persona.UsuarioModifica = Int16.Parse(IdUser);
                string strPersona = JsonConvert.SerializeObject(Persona);
                HttpContent cstrPersona = new StringContent(strPersona, Encoding.UTF8, "application/json");
                HttpResponseMessage HResp = await client.PutAsync("PersonasFisicas/" + Persona.Id, cstrPersona);

                if (HResp.IsSuccessStatusCode)
                {
                    ViewData["SuccessMessage"] = "Success";
                }
            }
            return RedirectToAction("Index", "PersonasFisicas");
        }

        public async Task<IActionResult> Eliminar(int Id)
        {
            var info = new List<PersonasFisicas>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlBase);
                HttpResponseMessage HResp = await client.DeleteAsync("PersonasFisicas/" + Id);

                if (HResp.IsSuccessStatusCode)
                {
                    ViewData["SuccessMessage"] = "Success";
                }
            }
            return RedirectToAction("Index","PersonasFisicas");
        }
    }
}

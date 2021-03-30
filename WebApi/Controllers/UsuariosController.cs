using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DBContext;
using WebApi.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApiDBContext context;

        public UsuariosController(ApiDBContext context)
        {
            this.context = context;
        }
 
        // GET api/<UsuariosController>/5
        [HttpGet("{User}")]
        public Usuarios Get(string user)
        {
            return context.Usuarios.FirstOrDefault(o => o.Usuario == user);
        }
    }
}

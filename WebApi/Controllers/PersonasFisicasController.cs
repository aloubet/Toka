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
    public class PersonasFisicasController : ControllerBase
    {
        private readonly ApiDBContext context;

        public PersonasFisicasController(ApiDBContext context)
        {
            this.context = context;
        }
        // GET: api/<PersonasFisicasController>
        [HttpGet]
        public IEnumerable<PersonasFisicas> Get()
        {
            return context.PersonasFisicas.ToList();
        }

        // GET api/<PersonasFisicasController>/5
        [HttpGet("{id}")]
        public PersonasFisicas Get(int id)
        {
            return context.PersonasFisicas.FirstOrDefault(o=> o.Id == id);
        }

        // POST api/<PersonasFisicasController>
        [HttpPost]
        public ActionResult Post([FromBody] PersonasFisicas Persona)
        {
            try
            {
                context.PersonasFisicas.Add(Persona);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<PersonasFisicasController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PersonasFisicas Persona)
        {
            if (Persona.Id == id)
            {
                context.Entry(Persona).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<PersonasFisicasController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Persona = context.PersonasFisicas.FirstOrDefault(o => o.Id == id);
            if (Persona!= null)
            {
                context.PersonasFisicas.Remove(Persona);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

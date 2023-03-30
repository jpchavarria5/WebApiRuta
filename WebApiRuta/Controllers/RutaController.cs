using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApiRuta.Context;
using WebApiRuta.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace WebApiRuta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutaController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        public RutaController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ruta>> Get()
        {
            return context.Ruta.ToList();
        }

        [HttpGet("{id}", Name = "ObtenerRuta")]
        public ActionResult<Ruta> Get(int id)
        {
            var ruta = context.Ruta.FirstOrDefault(x
                => x.Id == id);
            if (ruta == null)
            {
                return NotFound();
            }
            return ruta;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Ruta ruta)
        {
            context.Ruta.Add(ruta);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerRuta", new { id = ruta.Id }, ruta);
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Ruta ruta, int id)
        {
            if (id != ruta.Id)
            {
                return BadRequest();
            }
            context.Entry(ruta).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Ruta> Delete(int id)
        {
            var ruta = context.Ruta.FirstOrDefault(x => x.Id == id);
            if (ruta == null)
            {
                return NotFound();
            }

            //context.Autor.Remove(autor);
            context.Entry(ruta).State = EntityState.Deleted;
            context.SaveChanges();
            return Ok();
        }
    }
}

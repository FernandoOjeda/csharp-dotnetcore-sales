using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewWebApplication.Models;

namespace NewWebApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/ObjectData")]
    [ApiController]
    public class ObjectController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        public ObjectController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<ObjectData> Get()
        {
            return context.ObjectData.ToList();
        }

        [HttpGet("{id}", Name = "createObject")]
        public IActionResult GetById(int id)
        {
            var objectData = context.ObjectData.FirstOrDefault(x => x.Id == id);
            if (objectData == null)
            {
                return NotFound();
            }
            return Ok(objectData);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ObjectData objectData)
        {
            if (ModelState.IsValid)
            {
                context.ObjectData.Add(objectData);
                context.SaveChanges();
                return new CreatedAtRouteResult("createObject", new { id = objectData.Id }, objectData);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ObjectData objectData, int id)
        {
            if (objectData.Id != id)
            {
                return BadRequest();
            }

            context.Entry(objectData).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objectData = context.ObjectData.FirstOrDefault(x => x.Id == id);

            if (objectData == null)
            {
                return NotFound();
            }

            context.ObjectData.Remove(objectData);
            context.SaveChanges();
            return Ok(objectData);
        }
    }
}
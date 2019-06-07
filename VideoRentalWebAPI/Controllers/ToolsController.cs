using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VideoRentalWebAPI.Models;

namespace InventoryRentalWebAPI.Controllers
{
    public class MoviesController : ApiController
    {
        private InventoryRentalsEntities db = new InventoryRentalsEntities();

        // GET: api/Tools
        public IQueryable<Inventory> GetTools()
        {
            return db.Inventories;
        }

        // GET: api/Tools/5
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult GetTool(int id)
        {
            Inventory tool = db.Inventories.Find(id);
            if (tool == null)
            {
                return NotFound();
            }

            return Ok(tool);
        }

        // PUT: api/Tools/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTool(int id, Inventory tool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tool.ToolId)
            {
                return BadRequest();
            }

            db.Entry(tool).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tools
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult PostTool(Inventory tool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inventories.Add(tool);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tool.ToolId }, tool);
        }

        // DELETE: api/Tools/5
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult DeleteTool(int id)
        {
            Inventory tool = db.Inventories.Find(id);
            if (tool == null)
            {
                return NotFound();
            }

            db.Inventories.Remove(tool);
            db.SaveChanges();

            return Ok(tool);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToolExists(int id)
        {
            return db.Inventories.Count(e => e.ToolId == id) > 0;
        }
    }
}
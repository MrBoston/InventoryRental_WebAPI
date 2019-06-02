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

namespace VideoRentalWebAPI.Controllers
{
    public class ToolsController : ApiController
    {
        private InventoryRentalsEntities db = new InventoryRentalsEntities();

        // GET: api/Tools
        public IQueryable<Tool> GetTools()
        {
            return db.Tools;
        }

        // GET: api/Tools/5
        [ResponseType(typeof(Tool))]
        public IHttpActionResult GetTool(int id)
        {
            Tool tool = db.Tools.Find(id);
            if (tool == null)
            {
                return NotFound();
            }

            return Ok(tool);
        }

        // PUT: api/Tools/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTool(int id, Tool tool)
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
        [ResponseType(typeof(Tool))]
        public IHttpActionResult PostTool(Tool tool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tools.Add(tool);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ToolExists(tool.ToolId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tool.ToolId }, tool);
        }

        // DELETE: api/Tools/5
        [ResponseType(typeof(Tool))]
        public IHttpActionResult DeleteTool(int id)
        {
            Tool tool = db.Tools.Find(id);
            if (tool == null)
            {
                return NotFound();
            }

            db.Tools.Remove(tool);
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
            return db.Tools.Count(e => e.ToolId == id) > 0;
        }
    }
}
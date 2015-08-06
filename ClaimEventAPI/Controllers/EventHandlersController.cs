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
using ClaimEventAPI.Models;
using EventHandler = ClaimEventAPI.Models.EventHandler;

namespace ClaimEventAPI.Controllers
{
    public class EventHandlersController : ApiController
    {
        private ClaimEventAPIContext db = new ClaimEventAPIContext();

        // GET: api/EventHandlers
        public IQueryable<EventHandler> GetEventHandlers()
        {
            return db.EventHandlers;
        }

        // GET: api/EventHandlers/5
        [ResponseType(typeof(EventHandler))]
        public IHttpActionResult GetEventHandler(int id)
        {
            EventHandler eventHandler = db.EventHandlers.Find(id);
            if (eventHandler == null)
            {
                return NotFound();
            }

            return Ok(eventHandler);
        }

        // PUT: api/EventHandlers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventHandler(int id, EventHandler eventHandler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventHandler.Id)
            {
                return BadRequest();
            }

            db.Entry(eventHandler).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventHandlerExists(id))
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

        // POST: api/EventHandlers
        [ResponseType(typeof(EventHandler))]
        public IHttpActionResult PostEventHandler(EventHandler eventHandler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventHandlers.Add(eventHandler);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eventHandler.Id }, eventHandler);
        }

        // DELETE: api/EventHandlers/5
        [ResponseType(typeof(EventHandler))]
        public IHttpActionResult DeleteEventHandler(int id)
        {
            EventHandler eventHandler = db.EventHandlers.Find(id);
            if (eventHandler == null)
            {
                return NotFound();
            }

            db.EventHandlers.Remove(eventHandler);
            db.SaveChanges();

            return Ok(eventHandler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventHandlerExists(int id)
        {
            return db.EventHandlers.Count(e => e.Id == id) > 0;
        }
    }
}
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
using Employee.Models;

namespace Employee.Controllers
{
    public class BackEndController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/BackEnd
        public IQueryable<send1> Getsend1()
        {
            return db.send1;
        }

        // GET: api/BackEnd/5
        [ResponseType(typeof(send1))]
        public IHttpActionResult Getsend1(int id)
        {
            send1 send1 = db.send1.Find(id);
            if (send1 == null)
            {
                return NotFound();
            }

            return Ok(send1);
        }

        // PUT: api/BackEnd/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsend1(int id, send1 send1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != send1.id)
            {
                return BadRequest();
            }

            db.Entry(send1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!send1Exists(id))
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

        // POST: api/BackEnd
        [ResponseType(typeof(send1))]
        public IHttpActionResult Postsend1(send1 send1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.send1.Add(send1);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = send1.id }, send1);
        }

        // DELETE: api/BackEnd/5
        [ResponseType(typeof(send1))]
        public IHttpActionResult Deletesend1(int id)
        {
            send1 send1 = db.send1.Find(id);
            if (send1 == null)
            {
                return NotFound();
            }

            db.send1.Remove(send1);
            db.SaveChanges();

            return Ok(send1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool send1Exists(int id)
        {
            return db.send1.Count(e => e.id == id) > 0;
        }
    }
}
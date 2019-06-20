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
using DataAccess.Context;
using DataAccess.Models;
using BusinessLogic.Service;

namespace API.Controllers
{
    public class SubmitedsController : ApiController
    {
        private MyContext db = new MyContext();

        public SubmitedsController() { }   //----> Constructor

        private readonly ISubmitedService iSubmitedService;   //-------> Interface with Object
        public SubmitedsController(ISubmitedService _iSubmitedService)
        {
            iSubmitedService = _iSubmitedService;
        }

        // GET: api/Submiteds
        public List<Submited> GetSubmiteds()
        {
            return iSubmitedService.Get();
        }

        // GET: api/Submiteds/5
        [ResponseType(typeof(Submited))]
        public IHttpActionResult GetSubmited(int id)
        {
            Submited submited = db.Submiteds.Find(id);
            if (submited == null)
            {
                return NotFound();
            }

            return Ok(submited);
        }

        // PUT: api/Submiteds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubmited(int id, Submited submited)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != submited.Id)
            {
                return BadRequest();
            }

            db.Entry(submited).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubmitedExists(id))
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

        // POST: api/Submiteds
        [ResponseType(typeof(Submited))]
        public IHttpActionResult PostSubmited(Submited submited)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Submiteds.Add(submited);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = submited.Id }, submited);
        }

        // DELETE: api/Submiteds/5
        [ResponseType(typeof(Submited))]
        public IHttpActionResult DeleteSubmited(int id)
        {
            Submited submited = db.Submiteds.Find(id);
            if (submited == null)
            {
                return NotFound();
            }

            db.Submiteds.Remove(submited);
            db.SaveChanges();

            return Ok(submited);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubmitedExists(int id)
        {
            return db.Submiteds.Count(e => e.Id == id) > 0;
        }
    }
}
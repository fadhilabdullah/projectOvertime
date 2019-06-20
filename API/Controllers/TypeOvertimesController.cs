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
    public class TypeOvertimesController : ApiController
    {
        private MyContext db = new MyContext();
        public TypeOvertimesController() { }
        //interface
        private readonly ITypeOvertimeService iTypeOvertimeService;
        // GET: api/TypeOvertimes
        public TypeOvertimesController(ITypeOvertimeService _iTypeOvertimeService)
        {
            iTypeOvertimeService = _iTypeOvertimeService;
        }

        public List<TypeOvertime> GetParameter()
        {
            return iTypeOvertimeService.Get();
        }

        // GET: api/TypeOvertimes/5
        [ResponseType(typeof(TypeOvertime))]
        public IHttpActionResult GetTypeOvertime(int id)
        {
            TypeOvertime typeOvertime = db.TypeOvertimes.Find(id);
            if (typeOvertime == null)
            {
                return NotFound();
            }

            return Ok(typeOvertime);
        }

        // PUT: api/TypeOvertimes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeOvertime(int id, TypeOvertime typeOvertime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeOvertime.Id)
            {
                return BadRequest();
            }

            db.Entry(typeOvertime).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeOvertimeExists(id))
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

        // POST: api/TypeOvertimes
        [ResponseType(typeof(TypeOvertime))]
        public IHttpActionResult PostTypeOvertime(TypeOvertime typeOvertime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeOvertimes.Add(typeOvertime);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeOvertime.Id }, typeOvertime);
        }

        // DELETE: api/TypeOvertimes/5
        [ResponseType(typeof(TypeOvertime))]
        public IHttpActionResult DeleteTypeOvertime(int id)
        {
            TypeOvertime typeOvertime = db.TypeOvertimes.Find(id);
            if (typeOvertime == null)
            {
                return NotFound();
            }

            db.TypeOvertimes.Remove(typeOvertime);
            db.SaveChanges();

            return Ok(typeOvertime);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeOvertimeExists(int id)
        {
            return db.TypeOvertimes.Count(e => e.Id == id) > 0;
        }
    }
}
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
    public class DataOvertimesController : ApiController
    {
        private MyContext db = new MyContext();
        public DataOvertimesController() { }   //----> Constructor

        private readonly IDataOvertimeService iDataOvertimeService;   //-------> Interface with Object
        public DataOvertimesController(IDataOvertimeService _iDataOvertimeService)
        {
            iDataOvertimeService = _iDataOvertimeService;
        }
        // GET: api/DataOvertimes
        public List<DataOvertime> GetDataOvertimes()
        {
            return iDataOvertimeService.Get();
        }

        // GET: api/DataOvertimes/5
        [ResponseType(typeof(DataOvertime))]
        public IHttpActionResult GetDataOvertime(int id)
        {
            DataOvertime dataOvertime = db.DataOvertimes.Find(id);
            if (dataOvertime == null)
            {
                return NotFound();
            }

            return Ok(dataOvertime);
        }

        // PUT: api/DataOvertimes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDataOvertime(int id, DataOvertime dataOvertime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dataOvertime.Id)
            {
                return BadRequest();
            }

            db.Entry(dataOvertime).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataOvertimeExists(id))
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

        // POST: api/DataOvertimes
        [ResponseType(typeof(DataOvertime))]
        public IHttpActionResult PostDataOvertime(DataOvertime dataOvertime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DataOvertimes.Add(dataOvertime);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dataOvertime.Id }, dataOvertime);
        }

        // DELETE: api/DataOvertimes/5
        [ResponseType(typeof(DataOvertime))]
        public IHttpActionResult DeleteDataOvertime(int id)
        {
            DataOvertime dataOvertime = db.DataOvertimes.Find(id);
            if (dataOvertime == null)
            {
                return NotFound();
            }

            db.DataOvertimes.Remove(dataOvertime);
            db.SaveChanges();

            return Ok(dataOvertime);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DataOvertimeExists(int id)
        {
            return db.DataOvertimes.Count(e => e.Id == id) > 0;
        }
    }
}
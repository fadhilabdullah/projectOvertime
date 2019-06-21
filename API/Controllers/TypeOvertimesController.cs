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
using DataAccess.ViewModels;

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

        public HttpResponseMessage GetTypeOvertimes()
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
                var result = iTypeOvertimeService.Get();
                if (result != null)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, result);
                }
                return message;
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        // GET: api/TypeOvertimes/5
        public HttpResponseMessage GetTypeOvertime(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
                var result = iTypeOvertimeService.Get(id);
                if (result != null)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, result);
                }
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        // PUT: api/TypeOvertimes/5
        public HttpResponseMessage PutUpdateTypeOvertime(int id, TypeOvertimeVM typeovertimeVM)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

                var getTypeOvertime = db.TypeOvertimes.Find(id);
                if (getTypeOvertime == null)
                {
                    message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
                }
                else
                {
                    var result = iTypeOvertimeService.Update(id, typeovertimeVM);
                    if (result)
                    {
                        message = Request.CreateResponse(HttpStatusCode.NoContent, "No Content");
                    }
                }
                return message;
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        // POST: api/TypeOvertimes
        public HttpResponseMessage InsertTypeOvertime(TypeOvertimeVM typeovertimeVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iTypeOvertimeService.Insert(typeovertimeVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, typeovertimeVM);
            }
            return message;
        }

        // DELETE: api/TypeOvertimes/5
        public HttpResponseMessage DeleteTypeOvertime(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

                var getTypeOvertime = db.TypeOvertimes.Find(id);
                if (getTypeOvertime == null)
                {
                    message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
                }
                else
                {
                    var result = iTypeOvertimeService.Delete(id);
                    if (result)
                    {
                        message = Request.CreateResponse(HttpStatusCode.NoContent, "No Content");
                    }
                }
                return message;
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
    }
}
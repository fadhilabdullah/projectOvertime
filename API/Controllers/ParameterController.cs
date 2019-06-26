using BusinessLogic.Service;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ParameterController : ApiController
    {
        private MyContext db = new MyContext();
        public ParameterController() { }
        //interface
        private readonly IParameterService iParameterService;
        public ParameterController(IParameterService _iParameterService)
        {
            iParameterService = _iParameterService;
        }

        // GET: api/Parameter
        public HttpResponseMessage GetParameter()
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
                var result = iParameterService.Get();
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

        // GET: api/Parameter/5
        public HttpResponseMessage GetParameter(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
                var result = iParameterService.Get(id);
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

        // PUT: api/Parameter/5
        public HttpResponseMessage PutUpdateParameter(int id, ParameterVM parameterVM)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

                var getParameter = db.Parameters.Find(id);
                if (getParameter == null)
                {
                    message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
                }
                else
                {
                    var result = iParameterService.Update(id, parameterVM);
                    if (result)
                    {
                        message = Request.CreateResponse(HttpStatusCode.OK, result);
                    }
                }
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        // POST: api/Parameter
        public HttpResponseMessage InsertParameter(ParameterVM parameterVM)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
                var result = iParameterService.Insert(parameterVM);
                if (result)
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


        // DELETE: api/Parameter/5
        public HttpResponseMessage DeleteParameter(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

                var getParameter = db.Parameters.Find(id);
                if (getParameter == null)
                {
                    message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
                }
                else
                {
                    var result = iParameterService.Delete(id);
                    if (result)
                    {
                        message = Request.CreateResponse(HttpStatusCode.NoContent, "No Content");
                    }
                }
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
    }
}
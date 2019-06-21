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
        public HttpResponseMessage GetSubmiteds()
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iSubmitedService.Get();
                if (result != null)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, result);
                }
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }

        // GET: api/Submiteds/5
        public HttpResponseMessage GetSubmited(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iSubmitedService.Get(id);
                if (result != null)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, result);
                }
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }

        // PUT: api/Submiteds/5
        public HttpResponseMessage PutUpdateSubmited(int id, SubmitedVM submitedVM)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iSubmitedService.Update(id, submitedVM);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, submitedVM);
                }
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }

        // POST: api/Submiteds
        public HttpResponseMessage InsertSubmited(SubmitedVM submitedVM)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iSubmitedService.Insert(submitedVM);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, submitedVM);
                }
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }

        // DELETE: api/Submiteds/5
        public HttpResponseMessage DeleteSubmited(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iSubmitedService.Delete(id);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, "200 : OK (Data Deleted)");
                }
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }
    }
}
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
    public class DataOvertimesController : ApiController
    {
        private MyContext db = new MyContext();
        public DataOvertimesController() { }   //----> Constructor fcfcf

        private readonly IDataOvertimeService iDataOvertimeService;   //-------> Interface with Object
        public DataOvertimesController(IDataOvertimeService _iDataOvertimeService)
        {
            iDataOvertimeService = _iDataOvertimeService;
        }
        // GET: api/DataOvertimes
        public HttpResponseMessage GetDataOvertimes()
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iDataOvertimeService.Get();
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

        // GET: api/DataOvertimes/5
        public HttpResponseMessage GetDataOvertime(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iDataOvertimeService.Get(id);
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

        // PUT: api/DataOvertimes/5
        public HttpResponseMessage PutUpdateDataOvertime(int id, DataOvertimeVM dataOvertimeVM)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iDataOvertimeService.Update(id, dataOvertimeVM);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, dataOvertimeVM);
                }
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }

        // POST: api/DataOvertimes
        public HttpResponseMessage InsertDataOvertime(DataOvertimeVM dataOvertimeVM)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iDataOvertimeService.Insert(dataOvertimeVM);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, dataOvertimeVM);
                }
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }

        // DELETE: api/DataOvertimes/5
        public HttpResponseMessage DeleteDataOvertime(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iDataOvertimeService.Delete(id);
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
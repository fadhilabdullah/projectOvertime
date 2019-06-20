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
        public List<DataOvertime> GetDataOvertimes()
        {
            return iDataOvertimeService.Get();
        }

        // GET: api/DataOvertimes/5
        public DataOvertime GetDataOvertime(int id)
        {
            return iDataOvertimeService.Get(id);
        }

        // PUT: api/DataOvertimes/5
        public void PutUpdateDataOvertime(int id, DataOvertimeVM dataOvertimeVM)
        {
            iDataOvertimeService.Update(id, dataOvertimeVM);
        }

        // POST: api/DataOvertimes
        public HttpResponseMessage InsertDataOvertime(DataOvertimeVM dataOvertimeVM)
        {
            var messege = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iDataOvertimeService.Insert(dataOvertimeVM);
            if (result)
            {
                messege = Request.CreateResponse(HttpStatusCode.OK, dataOvertimeVM);
            }
            return messege;
        }

        // DELETE: api/DataOvertimes/5
        public void DeleteDataOvertime(int id)
        {
            iDataOvertimeService.Delete(id);
        }


    }
}
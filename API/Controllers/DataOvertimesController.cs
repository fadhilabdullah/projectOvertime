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
        

        // POST: api/DataOvertimes
        public void InsertDataOvertime(DataOvertimeVM dataOvertimeVM)
        {
            iDataOvertimeService.Insert(dataOvertimeVM);
        }

        // DELETE: api/DataOvertimes/5
        

        
    }
}
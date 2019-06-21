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

        public List<TypeOvertime> GetTypeOvertimes()
        {
            return iTypeOvertimeService.Get();
        }

        // GET: api/TypeOvertimes/5
        public TypeOvertime GetTypeOvertime(int id)
        {
            return iTypeOvertimeService.Get(id);
        }

        // PUT: api/TypeOvertimes/5
        public void PutUpdateTypeOvertime(int id, TypeOvertimeVM typeovertimeVM)
        {
            iTypeOvertimeService.Update(id, typeovertimeVM);
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
        public void DeleteTypeOvertime(int id)
        {
            iTypeOvertimeService.Delete(id);
        }
    }
}
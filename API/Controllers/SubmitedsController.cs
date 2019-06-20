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
        public List<Submited> GetSubmiteds()
        {
            return iSubmitedService.Get();
        }

        // GET: api/Submiteds/5
        public Submited GetSubmited(int id)
        {
            return iSubmitedService.Get(id);
        }

        // PUT: api/Submiteds/5
        public void PutUpdateSubmited(int id, SubmitedVM submitedVM)
        {
            iSubmitedService.Update(id, submitedVM);
        }

        // POST: api/Submiteds
        public HttpResponseMessage InsertSubmited(SubmitedVM submitedVM)
        {
            var messege = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iSubmitedService.Insert(submitedVM);
            if (result)
            {
                messege = Request.CreateResponse(HttpStatusCode.OK, submitedVM);
            }
            return messege;
        }

        // DELETE: api/Submiteds/5
        public void DeleteSubmited(int id)
        {
            iSubmitedService.Delete(id);
        }
    }
}
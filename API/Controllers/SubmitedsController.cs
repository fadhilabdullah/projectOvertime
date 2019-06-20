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


        // POST: api/Submiteds
        public void InsertSubmited(SubmitedVM submitedVM)
        {
            iSubmitedService.Insert(submitedVM);
        }

        // DELETE: api/Submiteds/5

    }
}
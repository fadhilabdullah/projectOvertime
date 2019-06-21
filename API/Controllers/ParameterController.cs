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
        public List<Parameter> GetParameter()
        {
            return iParameterService.Get();
        }

        // GET: api/Parameter/5
        public Parameter GetParameter(int id)
        {
            return iParameterService.Get(id);
        }

        // PUT: api/Parameter/5
        public void PutUpdateParameter(int id, ParameterVM parameterVM)
        {
            iParameterService.Update(id, parameterVM);
        }

        // POST: api/Parameter
        public HttpResponseMessage InsertParameter(ParameterVM parameterVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iParameterService.Insert(parameterVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, parameterVM);
            }
            return message;
        }
        

        // DELETE: api/Parameter/5
        public void DeleteParameter(int id)
        {
            iParameterService.Delete(id);
        }
    }
}

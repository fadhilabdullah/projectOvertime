using BusinessLogic.Service;
using DataAccess.Context;
using DataAccess.Models;
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

        public List<Parameter> GetParameter()
        {
            return iParameterService.Get();
        }
    }
}

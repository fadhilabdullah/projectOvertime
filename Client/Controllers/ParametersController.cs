using Core.Base;
using DataAccess.Models;
using DataAccess.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class ParametersController : Controller
    {
        BaseLink get = new BaseLink();

        // GET: Parameters
        public ActionResult Index()
        {
            return View(LoadParameter());
        }

        public JsonResult LoadParameter()
        {
            IEnumerable<Parameter> Parameter = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var responseTask = client.GetAsync("Parameter");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Parameter>>();
                readTask.Wait();
                Parameter = readTask.Result;
            }
            else
            {
                Parameter = Enumerable.Empty<Parameter>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(Parameter, JsonRequestBehavior.AllowGet);

            //IEnumerable<ParameterVM> ParameterVM = null;
            //var client = new HttpClient
            //{
            //    BaseAddress = new Uri(get.link)
            //};
            //var responseTask = client.GetAsync("Parameters");        //untuk nama controller yg di API
            //responseTask.Wait();
            //var result = responseTask.Result;
            //if (result.IsSuccessStatusCode)
            //{
            //    var readTask = result.Content.ReadAsAsync<IList<ParameterVM>>();
            //    readTask.Wait();
            //    ParameterVM = readTask.Result;
            //}
            //else
            //{
            //    ParameterVM = Enumerable.Empty<ParameterVM>();
            //    ModelState.AddModelError(string.Empty, "Server Error");
            //}
            //return Json(ParameterVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(ParameterVM ParameterVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var myContent = JsonConvert.SerializeObject(ParameterVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (ParameterVM.Id.Equals(0))
            {
                var result = client.PostAsync("Parameter", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Parameter/" + ParameterVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            ParameterVM ParameterVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var responseTask = client.GetAsync("Parameter/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ParameterVM>();
                readTask.Wait();
                ParameterVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(ParameterVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var result = client.DeleteAsync("Parameter/" + id).Result;
        }

        public ActionResult SelectCategory()
        {
            List<SelectListItem> ItemStatus = new List<SelectListItem>();
            ItemStatus.Add(new SelectListItem { Text = "Accept", Value = "0" });
            ItemStatus.Add(new SelectListItem { Text = "Decline", Value = "1", Selected = true });

            ViewBag.StatusType = ItemStatus;
            return View();
        }

        public ViewResult CategoryChosen(String StatusType)
        {
            ViewBag.messageString = StatusType;
            return View("Information");
        }
    }
}
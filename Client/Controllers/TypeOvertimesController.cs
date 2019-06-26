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
    public class TypeOvertimesController : Controller
    {
        BaseLink get = new BaseLink();

        // GET: TypeOvertimes
        public ActionResult Index()
        {
            return View(LoadTypeOvertime());
        }

        public JsonResult LoadTypeOvertime()
        {
            IEnumerable<TypeOvertime> TypeOvertime = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var responseTask = client.GetAsync("TypeOvertimes");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<TypeOvertime>>();
                readTask.Wait();
                TypeOvertime = readTask.Result;
            }
            else
            {
                TypeOvertime = Enumerable.Empty<TypeOvertime>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(TypeOvertime, JsonRequestBehavior.AllowGet);

            //IEnumerable<TypeOvertimeVM> TypeOvertimeVM = null;
            //var client = new HttpClient
            //{
            //    BaseAddress = new Uri(get.link)
            //};
            //var responseTask = client.GetAsync("TypeOvertimes");        //untuk nama controller yg di API
            //responseTask.Wait();
            //var result = responseTask.Result;
            //if (result.IsSuccessStatusCode)
            //{
            //    var readTask = result.Content.ReadAsAsync<IList<TypeOvertimeVM>>();
            //    readTask.Wait();
            //    TypeOvertimeVM = readTask.Result;
            //}
            //else
            //{
            //    TypeOvertimeVM = Enumerable.Empty<TypeOvertimeVM>();
            //    ModelState.AddModelError(string.Empty, "Server Error");
            //}
            //return Json(TypeOvertimeVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(TypeOvertimeVM TypeOvertimeVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var myContent = JsonConvert.SerializeObject(TypeOvertimeVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (TypeOvertimeVM.Id.Equals(0))
            {
                var result = client.PostAsync("TypeOvertimes", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("TypeOvertimes/" + TypeOvertimeVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            TypeOvertimeVM TypeOvertimeVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var responseTask = client.GetAsync("TypeOvertimes/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<TypeOvertimeVM>();
                readTask.Wait();
                TypeOvertimeVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(TypeOvertimeVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var result = client.DeleteAsync("TypeOvertimes/" + id).Result;
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
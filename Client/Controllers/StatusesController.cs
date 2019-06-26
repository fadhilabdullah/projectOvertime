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
    public class StatussController : Controller
    {
        BaseLink get = new BaseLink();

        // GET: Statuss
        public ActionResult Index()
        {
            return View(LoadStatus());
        }

        public JsonResult LoadStatus()
        {
            IEnumerable<Status> Status = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var responseTask = client.GetAsync("Statuses");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Status>>();
                readTask.Wait();
                Status = readTask.Result;
            }
            else
            {
                Status = Enumerable.Empty<Status>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(Status, JsonRequestBehavior.AllowGet);

            //IEnumerable<StatusVM> StatusVM = null;
            //var client = new HttpClient
            //{
            //    BaseAddress = new Uri(get.link)
            //};
            //var responseTask = client.GetAsync("Statuss");        //untuk nama controller yg di API
            //responseTask.Wait();
            //var result = responseTask.Result;
            //if (result.IsSuccessStatusCode)
            //{
            //    var readTask = result.Content.ReadAsAsync<IList<StatusVM>>();
            //    readTask.Wait();
            //    StatusVM = readTask.Result;
            //}
            //else
            //{
            //    StatusVM = Enumerable.Empty<StatusVM>();
            //    ModelState.AddModelError(string.Empty, "Server Error");
            //}
            //return Json(StatusVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(StatusVM StatusVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var myContent = JsonConvert.SerializeObject(StatusVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (StatusVM.Id.Equals(0))
            {
                var result = client.PostAsync("Statuses", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Statuses/" + StatusVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            StatusVM StatusVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var responseTask = client.GetAsync("Statuses/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<StatusVM>();
                readTask.Wait();
                StatusVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(StatusVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var result = client.DeleteAsync("Statuses/" + id).Result;
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
using Core.Base;
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
    public class SubmitedsController : Controller
    {
        BaseLink get = new BaseLink();

        // GET: Submiteds
        public ActionResult Index()
        {
            return View(LoadSubmited());
        }

        public JsonResult LoadSubmited()
        {
            IEnumerable<SubmitedVM> submitedVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var responseTask = client.GetAsync("Submiteds");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<SubmitedVM>>();
                readTask.Wait();
                submitedVM = readTask.Result;
            }
            else
            {
                submitedVM = Enumerable.Empty<SubmitedVM>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(submitedVM, JsonRequestBehavior.AllowGet);

            //IEnumerable<SubmitedVM> submitedVM = null;
            //var client = new HttpClient
            //{
            //    BaseAddress = new Uri(get.link)
            //};
            //var responseTask = client.GetAsync("Submiteds");        //untuk nama controller yg di API
            //responseTask.Wait();
            //var result = responseTask.Result;
            //if (result.IsSuccessStatusCode)
            //{
            //    var readTask = result.Content.ReadAsAsync<IList<SubmitedVM>>();
            //    readTask.Wait();
            //    submitedVM = readTask.Result;
            //}
            //else
            //{
            //    submitedVM = Enumerable.Empty<SubmitedVM>();
            //    ModelState.AddModelError(string.Empty, "Server Error");
            //}
            //return Json(submitedVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(SubmitedVM submitedVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var myContent = JsonConvert.SerializeObject(submitedVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (submitedVM.Id.Equals(0))
            {
                var result = client.PostAsync("Submiteds", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Submiteds/" + submitedVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            SubmitedVM submitedVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var responseTask = client.GetAsync("Submiteds/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<SubmitedVM>();
                readTask.Wait();
                submitedVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(submitedVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var result = client.DeleteAsync("Submiteds/" + id).Result;
        }
    }
}
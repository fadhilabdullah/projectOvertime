using Core.Base;
using DataAccess.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class DataOvertimesController : Controller
    {
        BaseLink get = new BaseLink();
        // GET: DataOvertimes
        public ActionResult Index()
        {
            return View(LoadDataOvertime());
        }

        public JsonResult LoadDataOvertime()
        {
            IEnumerable<DataOvertimeVM> dataOvertimeVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var responseTask = client.GetAsync("DataOvertimes");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<DataOvertimeVM>>();
                readTask.Wait();
                dataOvertimeVM = readTask.Result;
            }
            else
            {
                dataOvertimeVM = Enumerable.Empty<DataOvertimeVM>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(dataOvertimeVM, JsonRequestBehavior.AllowGet);
            //IEnumerable<DataOvertimeVM> dataOvertimeVM = null;
            //var client = new HttpClient
            //{
            //    BaseAddress = new Uri(get.link)
            //};
            //var responseTask = client.GetAsync("DataOvertimes");        //untuk nama controller yg di API
            //responseTask.Wait();
            //var result = responseTask.Result;
            //if (result.IsSuccessStatusCode)
            //{
            //    var readTask = result.Content.ReadAsAsync<IList<DataOvertimeVM>>();
            //    readTask.Wait();
            //    dataOvertimeVM = readTask.Result;
            //}
            //else
            //{
            //    dataOvertimeVM = Enumerable.Empty<DataOvertimeVM>();
            //    ModelState.AddModelError(string.Empty, "Server Error");
            //}
            //return Json(dataOvertimeVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(DataOvertimeVM dataOvertimeVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var myContent = JsonConvert.SerializeObject(dataOvertimeVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (dataOvertimeVM.Id.Equals(0))
            {
                var result = client.PostAsync("DataOvertimes", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("DataOvertimes/" + dataOvertimeVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            DataOvertimeVM dataOvertimeVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var responseTask = client.GetAsync("DataOvertimes/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<DataOvertimeVM>();
                readTask.Wait();
                dataOvertimeVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(dataOvertimeVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2284/api/");
            var result = client.DeleteAsync("DataOvertimes/" + id).Result;
        }
    }
}
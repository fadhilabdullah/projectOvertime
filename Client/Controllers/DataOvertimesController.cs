using Core.Base;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("DataOvertimes");        //untuk nama controller yg di API
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
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(dataOvertimeVM, JsonRequestBehavior.AllowGet);
        }
    }
}
using Core.Base;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("Submiteds");        //untuk nama controller yg di API
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
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(submitedVM, JsonRequestBehavior.AllowGet);
        }
    }
}
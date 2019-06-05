using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using Ninject;

namespace WebPL.Controllers
{
    public class HolderController : Controller
    {
        private IHolderService _service = MvcApplication.Resolver.Get<IHolderService>();

        public ActionResult Index()
        {
            return this.View(_service.GetAll());
        }

        [HttpGet]
        public ActionResult AddHolder()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AddHolder([Bind(Include = "Id,Name,Surname")] Holder holder)
        {
            if (ModelState.IsValid)
            {
                _service.Add(holder);
                _service.UpdateAll();
                return RedirectToAction("Index");
            }

            return this.View();
        }

        [HttpGet]
        public ActionResult EditHolder(long id)
        {
            var holder = _service.Get(id);
            return this.View(holder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHolder([Bind(Include = "Id,Name,Surname")] Holder holder)
        {
            if (ModelState.IsValid)
            {
                _service.Update(holder);
                _service.UpdateAll();
                return RedirectToAction("Index");
            }

            return this.View(holder);
        }

        [HttpGet]
        public ActionResult DeleteHolder(long id)
        {
            var holder = _service.Get(id);
            return this.View(holder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteHolder(ulong id)
        {
            _service.Remove(new Holder() {  Id = (long)id });
            _service.UpdateAll();
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "My application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contact page.";

            return this.View();
        }
    }
}
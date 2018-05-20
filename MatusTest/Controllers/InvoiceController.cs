using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatusTest.Controllers
{
    public class InvoiceController : Controller
    {
        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(InvoiceDto item)
        {
            var userId = 1;
            item.CreatedBy = new UserDto() { Id = userId }; // user for test purpose only 
            InvoiceBL.Create(item);
            var list = InvoiceBL.GetList(userId);
            return View("List", list);
        }


        [HttpPost]
        public virtual ActionResult Edit(InvoiceDto item)
        {
            var userId = 1;
            item.UpdatedBy = new UserDto() { Id = userId }; // user for test purpose only 
            InvoiceBL.Update(item);

            var list = InvoiceBL.GetList(userId);
            return View("List", list);
        }
        public virtual ActionResult Edit(int id)
        {
            var invoice = InvoiceBL.Get(id, true);
            return View(invoice);
        }
        [HttpGet]
        public virtual ActionResult List()
        {
            var userId = 1; // only for test purpose
            var list = InvoiceBL.GetList(userId);
            return View(list);
        }
    }
}
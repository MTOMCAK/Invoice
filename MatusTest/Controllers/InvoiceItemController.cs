using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatusTest.Controllers
{
    public class InvoiceItemController : Controller
    {
        // GET: InvoiceItem
        public virtual ActionResult Create(int invoiceId)
        {
            var newItem = new InvoiceItemDto() { InvoiceId = invoiceId };
            return View(newItem);
        }
        [HttpPost]
        public virtual ActionResult Create(InvoiceItemDto invoiceItem)
        {
            invoiceItem.CreatedBy = new UserDto() { Id = 1 }; // for test purpose only 
            InvoiceItemBL.Create(invoiceItem);

            return RedirectToAction("Edit", "Invoice", new { Id = invoiceItem.InvoiceId });
        }

        public virtual ActionResult Delete(int id)
        {
            var userId = 1; // for test purpose only
            var invoiceId = InvoiceItemBL.Delete(id, userId);
            return RedirectToAction("Edit", "Invoice", new { Id = invoiceId });
        }
    }
}
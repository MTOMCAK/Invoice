using BusinessLogic;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.OData;

namespace Invoice.WebApi.Controllers
{
    [Authorize]
    public class InvoiceController : ApiController
    {

        // edit invoice(PATCH request).
        [HttpGet]
        public virtual List<InvoiceDto> GetList(bool isPayed)
        {
            var userId = 1; // for test purpose only
            var result = InvoiceBL.GetList(userId, isPayed);
            return result;
        }

        // pay invoice(change status to paid),
        [HttpPost]
        public IHttpActionResult Pay(InvoiceDto invoice)
        {
            invoice.UpdatedBy = new UserDto() { Id = 1 };
            InvoiceBL.SetStatus(invoice);
            return Ok();
        }

        // get collection of unpaid invoices,

        [HttpPatch]
        public virtual IHttpActionResult PatchEdit(int id, Delta<InvoiceDto> invoice)
        {
            var userId = 1;
            InvoiceBL.PatchUpdate(id, invoice, userId);
            return Ok();
        }

    }
}

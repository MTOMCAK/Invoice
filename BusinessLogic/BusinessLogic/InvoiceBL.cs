using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using static BusinessLogic.Enums;

namespace BusinessLogic
{
    public class InvoiceBL
    {
        public static InvoiceDto Get(int id, bool isLoadingItems)
        {
            var result = InvoiceDA.Get(id);
            return result != null ? new InvoiceDto(result, isLoadingItems) : null;
        }

        public static List<InvoiceDto> GetList(int userId)
        {
            var result = InvoiceDA.GetList(userId);
            return result?.Select(i => new InvoiceDto(i,false)).ToList();
        }

        public static void Create(InvoiceDto newinvoice)
        {
            newinvoice.CreatedDate = DateTime.Now;
            newinvoice.DbStatus = Enums.eDbStatus.Active;
            InvoiceDA.Create(newinvoice.ToEntity());
        }

        public static void Update(InvoiceDto updatedInvoice)
        {
            updatedInvoice.UpdatedDate = DateTime.Now;
            InvoiceDA.Update(updatedInvoice.ToEntity());
        }
    }
}
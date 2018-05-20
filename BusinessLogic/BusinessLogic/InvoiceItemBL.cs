using DataAccess;
using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLogic
{
    public class InvoiceItemBL
    {
        public static void Create(InvoiceItemDto newItem)
        {
            newItem.CreatedDate = DateTime.Now;
            newItem.DbStatus = Enums.eDbStatus.Active;
            newItem.TotalPrice = newItem.Quantity * newItem.UnitPrice;
            newItem.AmountVAT = newItem.PercentageVAT * newItem.TotalPrice * 0.01;

            InvoiceItemDA.Create(newItem.ToEntity());
        }

        public static int Delete(int id, int userId)
        {
            return InvoiceItemDA.Delete(id, userId);
        }
    }
}
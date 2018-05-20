using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess
{
    public class InvoiceItemDA
    {
        #region CREATE_DELETE_METHODS
        public static void Create(InvoiceItem newItem)
        {
            using (var context = new MatusTestingAssignmentEntities())
            {
                // create item
                context.InvoiceItems.Add(newItem);

                // update invoice
                updateTotals(context, newItem.InvoiceId);
                context.SaveChanges();
            }
        }

        public static int Delete(int id, int userId)
        {
            using (var context = new MatusTestingAssignmentEntities())
            {
                // delete item
                var itemToDelete = context.InvoiceItems.Find(id);
                itemToDelete.DbStatus = 2; // set to inactive
                itemToDelete.UpdatedDate = DateTime.Now;
                itemToDelete.UpdatedBy = userId;

                // update invoice totals
                updateTotals(context, itemToDelete.InvoiceId);

                context.SaveChanges();
                return itemToDelete.InvoiceId;
            }
        }
        #endregion CREATE_DELETE_METHODS

        #region PRIVATE_METHODS
        private static void updateTotals(MatusTestingAssignmentEntities context, int invoiceId)
        {
            var invoice = context.Invoices.Find(invoiceId);
            invoice.TotalVAT = invoice.InvoiceItems.Where(i => i.DbStatus == 1).Sum(i => i.AmountVAT);
            invoice.TotalPrice = invoice.InvoiceItems.Where(i => i.DbStatus == 1).Sum(i => i.TotalPrice);
        }
        #endregion PRIVATE_METHODS
    }
}
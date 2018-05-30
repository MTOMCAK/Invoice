using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http.OData;

namespace DataAccess
{
    public class InvoiceDA
    {
        #region GET_METHODS
        public static Invoice Get(int id)
        {
            using (var context = new MatusTestingAssignmentEntities())
            {
                return context.Invoices.
                    Include(i => i.User).
                    Include(i => i.User1).
                    Include(i => i.InvoiceItems).
                    Include(i => i.InvoiceItems.Select(item => item.User)).
                    Include(i => i.InvoiceItems.Select(item => item.User1)).
                    First(i => i.Id == id);
            }
        }

        public static IEnumerable<Invoice> GetList(int userId, bool? isPaid = null)
        {
            using (var context = new MatusTestingAssignmentEntities())
            {
                var query = context.Invoices.
                    Include(i => i.User).
                    Include(i => i.User1).
                    Where(i => i.DbStatus == 1 && i.CreatedBy == userId);

                // get paid/unpaid invoices
                if (isPaid.HasValue)
                {
                    query = query.Where(i => i.Status == isPaid.Value);
                }
                return query.ToList();
            }
        }
        #endregion GET_METHODS

        #region CREATE_UPDATE_METHODS
        public static void Create(Invoice newInvoice)
        {
            using (var context = new MatusTestingAssignmentEntities())
            {
                context.Invoices.Add(newInvoice);
                context.SaveChanges();
            }
        }

        public static void Update(Invoice updateInvoice)
        {
            using (var context = new MatusTestingAssignmentEntities())
            {
                var current = context.Invoices.Find(updateInvoice.Id);
                current.CompanyName = updateInvoice.CompanyName;
                current.CompanyAddress = updateInvoice.CompanyAddress;
                current.CompanyState = updateInvoice.CompanyState;
                current.CompanyCountry = updateInvoice.CompanyCountry;
                current.ClientName = updateInvoice.ClientName;
                current.ClientAddress = updateInvoice.ClientAddress;
                current.ClientState = updateInvoice.ClientState;
                current.ClientCountry = updateInvoice.ClientCountry;
                current.Status = updateInvoice.Status;
                current.UpdatedDate = updateInvoice.UpdatedDate;
                current.UpdatedBy = updateInvoice.UpdatedBy;
                context.SaveChanges();
            }
        }

        public static void PatchUpdate(int id, Delta<Invoice> patchUpdate)
        {
            using (var context = new MatusTestingAssignmentEntities())
            {
                var current = context.Invoices.Find(id);
                patchUpdate.Patch(current);
                context.SaveChanges();
            }
        }

        public static void SetStatus(Invoice updateInvoice)
        {
            using (var context = new MatusTestingAssignmentEntities())
            {
                var current = context.Invoices.Find(updateInvoice.Id);
                current.Status = updateInvoice.Status;
                current.UpdatedDate = updateInvoice.UpdatedDate;
                current.UpdatedBy = updateInvoice.UpdatedBy;
                context.SaveChanges();
            }
        }
        #endregion CREATE_UPDATE_METHODS
    }
}
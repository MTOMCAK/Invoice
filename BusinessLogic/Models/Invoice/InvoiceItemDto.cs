using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessLogic
{
    [Serializable]
    public class InvoiceItemDto
    {
        public int Id { get; set; }
        [Display(Name = "Description")]
        public int InvoiceId { get; set; }
        public Enums.eDbStatus DbStatus { get; set; }
        public string Description { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Unit Price [€]")]
        public double UnitPrice { get; set; }
        [Display(Name = "VAT [%]")]
        public int PercentageVAT { get; set; }
        [Display(Name = "Amount VAT [€]")]
        public double AmountVAT { get; set; }
        [Display(Name = "Total Price")]
        public double TotalPrice { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Created By")]
        public UserDto CreatedBy { get; set; }
        [Display(Name = "Updated Date")]
        public DateTime? UpdatedDate { get; set; }
        [Display(Name = "Updated By")]
        public UserDto UpdatedBy { get; set; }

        public InvoiceItemDto() { }

        public InvoiceItemDto(InvoiceItem entity)
        {
            FromEntity(entity);
        }

        public void FromEntity(InvoiceItem entity)
        {
            Id = entity.Id;
            Description = entity.Description;
            Quantity = entity.Quantity;
            InvoiceId = entity.InvoiceId;
            DbStatus = (Enums.eDbStatus)entity.DbStatus;
            UnitPrice = (double)entity.UnitPrice;
            PercentageVAT = entity.PercentageVAT;
            AmountVAT = (double)entity.AmountVAT;
            TotalPrice = (double)entity.TotalPrice;
            CreatedDate = entity.CreatedDate;
            CreatedBy = new UserDto(entity.User);
            if (entity.UpdatedDate.HasValue)
            {
                UpdatedDate = entity.UpdatedDate.Value;
                UpdatedBy = new UserDto(entity.User1);
            }
        }

        public InvoiceItem ToEntity()
        {
            var entity = new InvoiceItem();
            entity.Id = Id;
            entity.Description = Description;
            entity.Quantity = Quantity;
            entity.InvoiceId = InvoiceId;
            entity.DbStatus = (int)DbStatus;
            entity.UnitPrice = (decimal)UnitPrice;
            entity.PercentageVAT = PercentageVAT;
            entity.AmountVAT = (decimal)AmountVAT;
            entity.TotalPrice = (decimal)TotalPrice;
            entity.DbStatus = (int)DbStatus;
            entity.CreatedBy = CreatedBy != null ? CreatedBy.Id : -1;
            entity.CreatedDate = CreatedDate;
            entity.UpdatedBy = UpdatedBy?.Id;
            entity.UpdatedDate = UpdatedDate;
            return entity;
        }
    }
}
using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http.OData;

namespace BusinessLogic
{
    [Serializable]
    public class InvoiceDto
    {
        public int Id { get; set; }
        public Enums.eDbStatus DbStatus { get; set; }
        public List<InvoiceItemDto> Items { get; set; }
        [Display(Name = "Paid")]
        public bool? Status { get; set; }
        [Display(Name = "Total Price")]
        public double? TotalPrice { get; set; }
        [Display(Name = "Total VAT [€]")]
        public double? TotalVAT { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Company Address")]
        public string CompanyAddress { get; set; }
        [Display(Name = "Company State")]
        public string CompanyState { get; set; }
        [Display(Name = "Company Country")]
        public string CompanyCountry { get; set; }
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Display(Name = "Client Address")]
        public string ClientAddress { get; set; }
        [Display(Name = "Client State")]
        public string ClientState { get; set; }
        [Display(Name = "Client Country")]
        public string ClientCountry { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Created By")]
        public UserDto CreatedBy { get; set; }
        [Display(Name = "Updated Date")]
        public DateTime? UpdatedDate { get; set; }
        [Display(Name = "Updated By")]
        public UserDto UpdatedBy { get; set; }

        public InvoiceDto() { }

        public InvoiceDto(Invoice entity, bool isLoadingItems = true)
        {
            FromEntity(entity, isLoadingItems);
        }

        public void FromEntity(Invoice entity, bool isLoadingItems)
        {
            Id = entity.Id;
            if (isLoadingItems)
            {
                Items = entity.InvoiceItems.Where(i => i.DbStatus == (int)Enums.eDbStatus.Active).Select(i => new InvoiceItemDto(i)).ToList();
            }
            Status = entity?.Status;
            DbStatus = (Enums.eDbStatus)entity.DbStatus;
            TotalPrice = (double)entity?.TotalPrice;
            TotalVAT = (double)entity?.TotalVAT;
            CompanyName = entity.CompanyName;
            CompanyAddress = entity.CompanyAddress;
            CompanyState = entity.CompanyState;
            CompanyCountry = entity.CompanyCountry;
            ClientName = entity.ClientName;
            ClientAddress = entity.ClientAddress;
            ClientState = entity.ClientState;
            ClientCountry = entity.ClientCountry;
            CreatedDate = entity.CreatedDate;
            CreatedBy = new UserDto(entity.User);
            if (entity.UpdatedDate.HasValue)
            {
                UpdatedDate = entity.UpdatedDate.Value;
                UpdatedBy = new UserDto(entity.User1);
            }
        }

        public Invoice ToEntity()
        {
            var entity = new Invoice();
            entity.Id = Id;
            entity.Status = Status ?? false;
            entity.DbStatus = (int)DbStatus;
            entity.TotalPrice = (decimal?)TotalPrice;
            entity.TotalVAT = (decimal?)TotalVAT;
            entity.CompanyName = CompanyName;
            entity.CompanyAddress = CompanyAddress;
            entity.CompanyState = CompanyState;
            entity.CompanyCountry = CompanyCountry;
            entity.ClientName = ClientName;
            entity.ClientAddress = ClientAddress;
            entity.ClientState = ClientState;
            entity.ClientCountry = ClientCountry;
            entity.CreatedBy = CreatedBy != null ? CreatedBy.Id : -1;
            entity.CreatedDate = CreatedDate;
            entity.UpdatedBy = UpdatedBy?.Id;
            entity.UpdatedDate = UpdatedDate;
            return entity;
        }

        public Delta<Invoice> ToPatchEntity(int userId)
        {
            var entity = new Delta<Invoice>();
            // company
            if (this.Status.HasValue)
            {
                entity.TrySetPropertyValue(nameof(this.Status), this.Status);
            }
            if (this.CompanyName != null && this.CompanyName != string.Empty)
            {
                entity.TrySetPropertyValue(nameof(this.CompanyName), this.CompanyName);
            }
            if (this.CompanyAddress != null && this.CompanyAddress != string.Empty)
            {
                entity.TrySetPropertyValue(nameof(this.CompanyAddress), this.CompanyAddress);
            }
            if (this.CompanyState != null && this.CompanyState != string.Empty)
            {
                entity.TrySetPropertyValue(nameof(this.CompanyState), this.CompanyState);
            }
            if (this.CompanyCountry != null && this.CompanyCountry != string.Empty)
            {
                entity.TrySetPropertyValue(nameof(this.CompanyCountry), this.CompanyCountry);
            }
            // client 
            if (this.ClientName != null && this.ClientName != string.Empty)
            {
                entity.TrySetPropertyValue(nameof(this.ClientName), this.ClientName);
            }
            if (this.ClientAddress != null && this.ClientAddress != string.Empty)
            {
                entity.TrySetPropertyValue(nameof(this.ClientAddress), this.ClientAddress);
            }
            if (this.ClientState != null && this.ClientState != string.Empty)
            {
                entity.TrySetPropertyValue(nameof(this.ClientState), this.ClientState);
            }
            if (this.ClientCountry != null && this.ClientCountry != string.Empty)
            {
                entity.TrySetPropertyValue(nameof(this.ClientCountry), this.ClientCountry);
            }
            // updated date/by
            entity.TrySetPropertyValue(nameof(this.UpdatedBy), userId);
            entity.TrySetPropertyValue(nameof(this.UpdatedDate), DateTime.Now);
            return entity;
        }
    }
}
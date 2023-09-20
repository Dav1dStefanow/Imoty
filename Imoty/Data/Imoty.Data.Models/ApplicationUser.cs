// ReSharper disable VirtualMemberCallInConstructor
namespace Imoty.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Imoty.Data.Common.Models;
    using Imoty.Data.Models.ImageModels;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Apartments = new HashSet<Apartment>();
            this.Houses = new HashSet<House>();
            this.ApartmentImages = new HashSet<ApartmentImage>();
            this.HouseImages = new HashSet<HouseImage>();
            this.Fields = new HashSet<Field>();
            this.FieldImages = new HashSet<FieldImage>();
            this.Warehouses = new HashSet<Warehouse>();
            this.WarehouseImages = new HashSet<WarehouseImage>();
            this.BusinesStores = new HashSet<BusinesStore>();
            this.BusinesStoreImages = new HashSet<BusinesStoreImage>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }

        public virtual ICollection<House> Houses { get; set; }

        public virtual ICollection<ApartmentImage> ApartmentImages { get; set; }

        public virtual ICollection<HouseImage> HouseImages { get; set; }

        public virtual ICollection<FieldImage> FieldImages { get; set; }

        public virtual ICollection<Field> Fields { get; set; }

        public virtual ICollection<WarehouseImage> WarehouseImages { get; set; }

        public virtual ICollection<Warehouse> Warehouses { get; set; }

        public virtual ICollection<BusinesStoreImage> BusinesStoreImages { get; set; }

        public virtual ICollection<BusinesStore> BusinesStores { get; set; }
    }
}

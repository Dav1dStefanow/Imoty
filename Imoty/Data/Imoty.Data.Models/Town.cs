namespace Imoty.Data.Models
{
    using System.Collections.Generic;

    using Imoty.Data.Common.Models;

    public class Town : BaseDeletableModel<int>
    {
        public Town()
        {
            this.Apartments = new HashSet<Apartment>();
            this.Houses = new HashSet<House>();
            this.Warehouses = new HashSet<Warehouse>();
            this.BusinesStores = new HashSet<BusinesStore>();
            this.Fields = new HashSet<Field>();
        }

        public string Name { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }

        public virtual ICollection<House> Houses { get; set; }

        public virtual ICollection<Warehouse> Warehouses { get; set; }

        public virtual ICollection<BusinesStore> BusinesStores { get; set; }

        public virtual ICollection<Field> Fields { get; set; }
    }
}

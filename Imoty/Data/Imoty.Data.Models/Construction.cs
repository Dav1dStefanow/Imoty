namespace Imoty.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Imoty.Data.Common.Models;

    public class Construction : BaseDeletableModel<int>
    {
        public Construction()
        {
            this.Apartments = new HashSet<Apartment>();
            this.Houses = new HashSet<House>();
            this.Warehouses = new HashSet<Warehouse>();
            this.BusinesStores = new HashSet<BusinesStore>();
        }

        public string Name { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }

        public virtual ICollection<House> Houses { get; set; }

        public virtual ICollection<Warehouse> Warehouses { get; set; }

        public virtual ICollection<BusinesStore> BusinesStores { get; set; }
    }
}

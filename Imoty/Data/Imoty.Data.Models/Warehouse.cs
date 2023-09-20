﻿namespace Imoty.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Imoty.Data.Common.Models;
    using Imoty.Data.Models.ImageModels;

    public class Warehouse : BaseDeletableModel<int>
    {
        public Warehouse()
        {
            this.Images = new HashSet<WarehouseImage>();
        }

        public string Name { get; set; }

        public string PopulatedArea { get; set; }

        public string Location { get; set; }

        public decimal Price { get; set; }

        public int SquareMeters { get; set; }

        public string Description { get; set; }

        public int ConstructionId { get; set; }

        public virtual Construction Construction { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<WarehouseImage> Images { get; set; }
    }
}

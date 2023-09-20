﻿namespace Imoty.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Imoty.Data.Common.Models;
    using Imoty.Data.Models.ImageModels;

    public class House : BaseDeletableModel<int>
    {
        public House()
        {
            this.Images = new HashSet<HouseImage>();
        }

        public string Name { get; set; }

        public string PopulatedArea { get; set; }

        public string Location { get; set; }

        public decimal Price { get; set; }

        public int BedRooms { get; set; }

        public int BathRooms { get; set; }

        public int SquareMeters { get; set; }

        public int BuiltUpArea { get; set; }

        public string Description { get; set; }

        public int Garages { get; set; }

        public int TotalFloors { get; set; }

        public int ConstructionId { get; set; }

        public virtual Construction Construction { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<HouseImage> Images { get; set; }
    }
}

﻿namespace Imoty.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Imoty.Data.Common.Models;
    using Imoty.Data.Models.ImageModels;

    public class BusinesStore : BaseDeletableModel<int>
    {
        public BusinesStore()
        {
            this.Images = new HashSet<BusinesStoreImage>();
            this.Tags = new HashSet<Tag>();
        }

        public string Type { get; set; }

        public Town Town { get; set; }

        public int TownId { get; set; }

        public District District { get; set; }

        public int DistrictId { get; set; }

        public decimal Price { get; set; }

        public int BathRooms { get; set; }

        public int SquareMeters { get; set; }

        public int FrontSpace { get; set; }

        public string Description { get; set; }

        public int ConstructionId { get; set; }

        public virtual Construction Construction { get; set; }

        public bool ForSale { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<BusinesStoreImage> Images { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}

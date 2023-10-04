namespace Imoty.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.ConstrainedExecution;
    using System.Text;
    using System.Threading.Tasks;

    using Imoty.Data.Common.Models;
    using Imoty.Data.Models.ImageModels;

    public class Apartment : BaseDeletableModel<int>
    {
        public Apartment()
        {
            this.Images = new HashSet<ApartmentImage>();
        }

        public string Type { get; set; }

        public Town Town { get; set; }

        public int TownId { get; set; }

        public District District { get; set; }

        public int DistrictId { get; set; }

        public decimal Price { get; set; }

        public int BedRooms { get; set; }

        public int BathRooms { get; set; }

        public int SquareMeters { get; set; }

        public string Description { get; set; }

        public int TotalFloors { get; set; }

        public int Garages { get; set; }

        [Range(1, 100)]
        public int Floor { get; set; }

        public int ConstructionId { get; set; }

        public virtual Construction Construction { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<ApartmentImage> Images { get; set; }
    }
}

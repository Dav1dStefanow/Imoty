namespace Imoty.Web.ViewModels.Home
{
    using System.Collections;
    using System.Collections.Generic;

    public class SinglePropertyViewModel
    {
        public SinglePropertyViewModel()
        {
            this.ImageUrls = new List<string>();
            this.Tags = new List<string>();
        }

        public string CategoryName { get; set; }

        public string Type { get; set; }

        public string TownName { get; set; }

        public string DistrictName { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ConstructionName { get; set; }

        public int SquareMeters { get; set; }

        public int BuiltUpArea { get; set; }

        public int BedRooms { get; set; }

        public int BathRooms { get; set; }

        public int TotalFloors { get; set; }

        public int Floor { get; set; }

        public ICollection<string> ImageUrls { get; set; }

        public ICollection<string> Tags { get; set; }
    }
}

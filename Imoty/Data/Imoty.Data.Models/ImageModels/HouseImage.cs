namespace Imoty.Data.Models.ImageModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Imoty.Data.Common.Models;

    public class HouseImage : BaseModel<string>
    {
        public HouseImage()
        {
            Id = Guid.NewGuid().ToString();
        }

        public int HouseId { get; set; }

        public virtual House House { get; set; }

        public string Extension { get; set; }

        //// The Contents of The Image is in The File System

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}

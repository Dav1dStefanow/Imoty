namespace Imoty.Data.Models.ImageModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Imoty.Data.Common.Models;

    public class BusinesStoreImage : BaseModel<string>
    {
        public BusinesStoreImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int BusinesStoreId { get; set; }

        public virtual BusinesStore BusinesStore { get; set; }

        public string Extension { get; set; }

        //// The Contents of The Image is in The File System

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}

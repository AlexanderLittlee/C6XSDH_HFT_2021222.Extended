using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6XSDH_HFT_2021222.Models
{
    public interface IBike : IEntity
    {
        public string Model { get; set; }
        public int BrandId { get; set; }
        public int Price { get; set; }
        public int Rating { get; set; }



    }
}

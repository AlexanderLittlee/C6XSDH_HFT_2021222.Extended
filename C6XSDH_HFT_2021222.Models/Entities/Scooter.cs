using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6XSDH_HFT_2021222.Models.Entities
{
    [Table("scooters")]
    public class Scooter : Bike, IScooter
    {
        public int Speed { get; set; }
        public int Range { get; set; }
    }
}

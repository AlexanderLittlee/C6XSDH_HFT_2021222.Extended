using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6XSDH_HFT_2021222.Models
{
    public interface IScooter : IBike
    {
        public int Speed { get; set; }

        public int Range { get; set; }
    }
}

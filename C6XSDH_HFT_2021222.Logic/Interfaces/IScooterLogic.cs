using C6XSDH_HFT_2021222.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6XSDH_HFT_2021222.Logic.Interfaces
{
    public interface IScooterLogic: ILogic<Scooter>
    {
        double AverageRange();
        double AverageSpeed();

        string FastestScooter();
        string BestRange();

        IEnumerable<KeyValuePair<string, double>> AVGPriceByBrandS();
    }
}

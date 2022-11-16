using C6XSDH_HFT_2021222.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6XSDH_HFT_2021222.Logic.Interfaces
{
    public interface IBikeLogic: ILogic<Bike>
    {
        IEnumerable<Bike> BestBikes();
        double AverageRating();
        double AveragePrice();

        string CheapestBike();

        IEnumerable<KeyValuePair<string, double>> AVGPriceByBrandB();
    }
}

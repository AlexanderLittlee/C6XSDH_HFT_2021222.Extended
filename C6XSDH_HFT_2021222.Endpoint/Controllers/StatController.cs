using C6XSDH_HFT_2021222.Logic.Interfaces;
using C6XSDH_HFT_2021222.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C6XSDH_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IBikeLogic bl;
        IScooterLogic sl;

        public StatController(IBikeLogic b, IScooterLogic s)
        {
            bl = b;
            sl = s;
        }

        //---------------------------------SCOOTER---------------------------------------

        [HttpGet]
        public double AverageSpeed()
        {
            return sl.AverageSpeed();
        }
        [HttpGet]
        public double AverageRange()
        {
            return sl.AverageRange();
        }

        [HttpGet]
        public string FastestScooter()
        {
            return sl.FastestScooter();
        }

        [HttpGet]
        public string RangestScooter()
        {
            return sl.BestRange();
        }


        [HttpGet]       
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrandS()
        {
            return sl.AVGPriceByBrandS();
        }

        
        //**********************************************************************************    

        //------------------------------BIKE------------------------------------------------
        
        [HttpGet]       
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrandB()
        {
            return bl.AVGPriceByBrandB();
        }

        [HttpGet]
        public string CheapestBike()
        {
            return bl.CheapestBike();
        }
        [HttpGet]
        public IEnumerable<Bike> BestBikes ()
        {
            return bl.BestBikes();
        }


        [HttpGet]
        public double AverageRating()
        {
            return (double)bl.AverageRating();
        }

        [HttpGet]
        public double AveragePrice()
        {
            return (double)bl.AveragePrice();
        }

    }
}

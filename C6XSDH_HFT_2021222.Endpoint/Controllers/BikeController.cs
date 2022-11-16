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
    [Route("/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        IBikeLogic logic;

        public BikeController(IBikeLogic l)
        {
            logic = l;
        }


        [HttpGet]
        public IEnumerable<Bike> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Bike Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Bike b)
        {
            logic.Create(b);
        }

        [HttpPut]
        public void Put([FromBody] Bike b)
        {
            logic.Update(b);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}

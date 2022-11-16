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
    public class ScooterController : ControllerBase
    {
        IScooterLogic logic;

        public ScooterController(IScooterLogic l)
        {
            logic = l;
        }


        [HttpGet]
        public IEnumerable<Scooter> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Scooter Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Scooter s)
        {
            logic.Create(s);
        }

        [HttpPut]
        public void Put([FromBody] Scooter s)
        {
            logic.Update(s);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}

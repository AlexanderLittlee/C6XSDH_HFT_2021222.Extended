using C6XSDH_HFT_2021222.Endpoint.Services;
using C6XSDH_HFT_2021222.Logic.Interfaces;
using C6XSDH_HFT_2021222.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;

        public BikeController(IBikeLogic l, IHubContext<SignalRHub> hub)
        {
            logic = l;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("BikeCreated",b);
        }

        [HttpPut]
        public void Put([FromBody] Bike b)
        {
            logic.Update(b);
            this.hub.Clients.All.SendAsync("BikeUpdated", b);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var bike=logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("BikeDeleted",bike);
        }
    }
}

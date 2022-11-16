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
    public class ScooterController : ControllerBase
    {
        IScooterLogic logic;
        IHubContext<SignalRHub> hub;

        public ScooterController(IScooterLogic l, IHubContext<SignalRHub> hub)
        {
            logic = l;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("ScooterCreated", s);
        }

        [HttpPut]
        public void Put([FromBody] Scooter s)
        {
            logic.Update(s);
            this.hub.Clients.All.SendAsync("ScooterUpdated", s);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var s= logic.Read(id);  
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("ScooterDeleted", s);
        }
    }
}

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
    public class BrandController : ControllerBase
    {
        ILogic<Brand> logic;
        IHubContext<SignalRHub> hub;

        public BrandController(ILogic<Brand> l, IHubContext<SignalRHub> hub)
        {
            logic = l;
            this.hub = hub;
        }


        [HttpGet]
        public IEnumerable<Brand> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Brand Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Brand b)
        {
            logic.Create(b);
            this.hub.Clients.All.SendAsync("BrandCreated", b);
        }

        [HttpPut]
        public void Put([FromBody] Brand b)
        {
            logic.Update(b);
            this.hub.Clients.All.SendAsync("BrandUpdated", b);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var b = logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("BrandDeleted", b);
        }
    }
}

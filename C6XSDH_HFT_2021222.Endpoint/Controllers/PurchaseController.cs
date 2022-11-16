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
    public class PurchaseController : ControllerBase
    {
        ILogic<Purchase> logic;

        public PurchaseController(ILogic<Purchase> l)
        {
            logic = l;
        }


        [HttpGet]
        public IEnumerable<Purchase> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Purchase Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Purchase p)
        {
            logic.Create(p);
        }

        [HttpPut]
        public void Put([FromBody] Purchase p)
        {
            logic.Update(p);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}

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
    public class BrandController : ControllerBase
    {
        ILogic<Brand> logic;

        public BrandController(ILogic<Brand> l)
        {
            logic = l;
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
        }

        [HttpPut]
        public void Put([FromBody] Brand b)
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

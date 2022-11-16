using C6XSDH_HFT_2021222.Logic.Interfaces;
using C6XSDH_HFT_2021222.Models.Entities;
using C6XSDH_HFT_2021222.Repository.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6XSDH_HFT_2021222.Logic.Logic
{
    public class BrandLogic : ILogic<Brand>
    {
        IRepository<Brand> repo;

        public BrandLogic(IRepository<Brand> r)
        {
            this.repo = r;
        }

        public void Create(Brand thing)
        {
            repo.Create(thing);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Brand Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Brand> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Brand thing)
        {
            repo.Update(thing);
        }
    }
}

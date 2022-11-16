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
    public class PurchaseLogic : ILogic<Purchase>
    {
        IRepository<Purchase> repository;

        public PurchaseLogic(IRepository<Purchase> r)
        {
            this.repository = r;
        }

        public void Create(Purchase thing)
        {
            repository.Create(thing);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public Purchase Read(int id)
        {
            return repository.Read(id);
        }

        public IQueryable<Purchase> ReadAll()
        {
            return repository.ReadAll();
        }

        public void Update(Purchase thing)
        {
            repository.Update(thing);
        }
    }
}

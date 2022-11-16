using C6XSDH_HFT_2021222.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6XSDH_HFT_2021222.Repository.REPOSITORY
{
    public class PurchaseRepository : IRepository<Purchase>
    {

        BikeNScooterDBContext context;

        public PurchaseRepository(BikeNScooterDBContext c)
        {
            context = c;
        }

        public void Create(Purchase thing)
        {
            context.Purchases.Add(thing);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Purchases.Remove(Read(id));
            context.SaveChanges();
        }

        public Purchase Read(int id)
        {
            return context.Purchases.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Purchase> ReadAll()
        {
            return context.Purchases;
        }

        public void Update(Purchase thing)
        {
            Purchase old = Read(thing.Id);
            if (old is not null)
            {
                old.BrandId = thing.BrandId;
            }
            context.SaveChanges();
        }
    }
}

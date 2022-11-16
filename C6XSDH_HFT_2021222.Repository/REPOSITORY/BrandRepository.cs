using C6XSDH_HFT_2021222.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6XSDH_HFT_2021222.Repository.REPOSITORY
{
    public class BrandRepository : IRepository<Brand>
    {

        BikeNScooterDBContext context;

        public BrandRepository(BikeNScooterDBContext c)
        {
            context = c;
        }

        public void Create(Brand thing)
        {
            context.Brands.Add(thing);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Brands.Remove(Read(id));
            context.SaveChanges();
        }

        public Brand Read(int id)
        {
            return context.Brands.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Brand> ReadAll()
        {
            return context.Brands;
        }

        public void Update(Brand thing)
        {
            Brand old = Read(thing.Id);
            if (old is not null)
            {
                old.BrandName = thing.BrandName;
                
            }
            context.SaveChanges();
        }
    }
}

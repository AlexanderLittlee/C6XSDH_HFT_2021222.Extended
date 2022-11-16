using C6XSDH_HFT_2021222.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6XSDH_HFT_2021222.Repository.REPOSITORY
{
    public class BikeRepository : IRepository<Bike>
    {
        BikeNScooterDBContext context;

        public BikeRepository(BikeNScooterDBContext c)
        {
            context = c;
        }

        public void Create(Bike thing)
        {
            context.Bikes.Add(thing);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Bikes.Remove(Read(id));
            context.SaveChanges();
        }

        public Bike Read(int id)
        {
            return context.Bikes.FirstOrDefault(x=>x.Id==id);
        }

        public IQueryable<Bike> ReadAll()
        {
            return context.Bikes;
        }

        public void Update(Bike thing)
        {
            Bike old = Read(thing.Id);
            if (old is not null)
            {
                old.Model = thing.Model;
                old.BrandId = thing.BrandId;
                old.Price = thing.Price;
                old.Rating = thing.Rating;
            }
            context.SaveChanges();
        }
    }
}

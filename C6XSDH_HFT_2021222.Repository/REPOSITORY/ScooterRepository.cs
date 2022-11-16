using C6XSDH_HFT_2021222.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6XSDH_HFT_2021222.Repository.REPOSITORY
{
    public class ScooterRepository : IRepository<Scooter>
    {
        BikeNScooterDBContext context;

        public ScooterRepository(BikeNScooterDBContext c)
        {
            context = c;
        }

        public void Create(Scooter thing)
        {
            context.Bikes.Add(thing);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Bikes.Remove(Read(id));
            context.SaveChanges();
        }

        public Scooter Read(int id)
        {
            return context.Scooters.FirstOrDefault(x=>x.Id==id);
        }

        public IQueryable<Scooter> ReadAll()
        {
            return context.Scooters;
        }

        public void Update(Scooter thing)
        {
            Scooter old = Read(thing.Id);
            if (old is not null)
            {
                old.Model = thing.Model;
                old.BrandId = thing.BrandId;
                old.Price = thing.Price;
                old.Rating = thing.Rating;
                old.Range = thing.Range;
                old.Speed = thing.Speed;
                
            }
            context.SaveChanges();
        }
    }
}

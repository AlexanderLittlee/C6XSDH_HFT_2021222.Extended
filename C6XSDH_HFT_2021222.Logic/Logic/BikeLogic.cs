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
    public class BikeLogic : IBikeLogic
    {
        IRepository<Bike> repository;

        public BikeLogic(IRepository<Bike> r)
        {
            this.repository = r;
        }

        public double AveragePrice()
        {
            return (double)repository.ReadAll().Average(x => x.Price);
        }

        public double AverageRating()
        {
            return (double)repository.ReadAll().Average(x => x.Rating);
        }

        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrandB()
        {
            return from bike in repository.ReadAll()
                   group bike by bike.Brand.BrandName into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.Price));
        }

        public string CheapestBike()
        {
            return repository.ReadAll().OrderByDescending(X => X.Price).LastOrDefault().Model;
        }

        public void Create(Bike thing)
        {
            repository.Create(thing);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
        
        public IEnumerable<Bike> BestBikes()
        {

            return repository.ReadAll()
                .Where(x => x.Rating == 5);
                
                      
        
        }

        public Bike Read(int id)
        {
            return repository.Read(id);
        }

        public IQueryable<Bike> ReadAll()
        {
            return repository.ReadAll();
        }

        public void Update(Bike thing)
        {
            repository.Update(thing);
        }
    }
}

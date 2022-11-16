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
    public class ScooterLogic : IScooterLogic
    {
        IRepository<Scooter> repo;

        public ScooterLogic(IRepository<Scooter> r)
        {
            this.repo = r;
        }

        public double AverageRange()
        {
            return repo.ReadAll().Average(x => x.Range);
        }

        public double AverageSpeed()
        {
            return repo.ReadAll().Average(x => x.Speed);
        }

        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrandS()
        {
            return from sc in repo.ReadAll()
                   group sc by sc.Brand.BrandName into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.Price));
        }

        public string BestRange()
        {

            return repo.ReadAll().OrderByDescending(s => s.Range).FirstOrDefault().Model;
        }

        public void Create(Scooter thing)
        {
            repo.Create(thing);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public string FastestScooter()
        {
            return repo.ReadAll().OrderByDescending(s => s.Speed).FirstOrDefault().Model;
        }

        public Scooter Read(int id)
        {
            return repo.Read(id);    
        }

        public IQueryable<Scooter> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Scooter thing)
        {
            repo.Update(thing);
        }
    }
}

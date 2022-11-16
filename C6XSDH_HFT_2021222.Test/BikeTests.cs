using C6XSDH_HFT_2021222.Logic.Interfaces;
using C6XSDH_HFT_2021222.Logic.Logic;
using C6XSDH_HFT_2021222.Models.Entities;
using C6XSDH_HFT_2021222.Repository.REPOSITORY;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace C6XSDH_HFT_2021222.Test
{
    [TestFixture]
    public class BikeTests
    {
        public class FakeBikeRepository : IRepository<Bike>
        {
            public void Create(Bike thing)
            {
                throw new NotImplementedException();
            }

            public void Delete(int id)
            {
                throw new NotImplementedException();
            }

            public Bike Read(int id)
            {
                throw new NotImplementedException();
            }

            public IQueryable<Bike> ReadAll()
            {
                Brand merida = new Brand() { BrandName = "Merida" };
                Brand csepel = new Brand() { BrandName = "Csepel" };
                Brand giant = new Brand() { BrandName = "Giant" };
                return new List<Bike>()
                {
                    new Bike(){ Brand=merida, Price=300000, Rating=5},
                    new Bike(){ Brand=merida, Price=270000, Rating=4},
                    new Bike(){ Brand=merida, Price=100000, Rating=2},
                    new Bike(){ Brand=csepel, Price=200000, Rating=5},
                    new Bike(){ Brand=csepel, Price=100000, Rating=4},
                    new Bike(){ Brand=csepel, Price=90000, Rating=3},
                    new Bike(){ Brand=csepel, Price=140000, Rating=5},
                    new Bike(){ Brand=csepel, Price=60000, Rating=2, Model="Cheapel"},
                    new Bike(){ Brand=giant, Price=300000, Rating=3},
                    new Bike(){ Brand=giant, Price=400000, Rating=4},
                    new Bike(){ Brand=giant, Price=550000, Rating=5}
                }.AsQueryable();
            }

            public void Update(Bike thing)
            {
                throw new NotImplementedException();
            }
        }

        IBikeLogic logic;
        [SetUp]
        public void BikeSetup()
        {
            logic = new BikeLogic(new FakeBikeRepository());
        }

        [Test]
        public void CheckAverageRating()
        {
            double rating = logic.AverageRating();
            Assert.AreEqual(rating, 3.8181, 0.1);
        }

        [Test]
        public void CheckAveragePrice() //avg price below 300k
        {
            double price = logic.AveragePrice();
            Assert.AreEqual(price, 228181.81, 0.1);
        }

        [Test]
        public void Check5stars()
        {
            
            IEnumerable<Bike> stars5 = logic.BestBikes();

            Assert.AreEqual(stars5.Count(), 4);
        }

        [Test]
        public void CheckCheapestBike()
        {

            string cheap = logic.CheapestBike();
            Assert.AreEqual(cheap, "Cheapel");
        }

        [Test]
        public void CheckPricePerBrand()
        {
            IEnumerable<KeyValuePair<string, double>> keyValues = logic.AVGPriceByBrandB();
            Assert.AreEqual(keyValues.Select(x => x.Value).Min(), 118000);
        }
    }
}

using C6XSDH_HFT_2021222.Logic.Interfaces;
using C6XSDH_HFT_2021222.Logic.Logic;
using C6XSDH_HFT_2021222.Models.Entities;
using C6XSDH_HFT_2021222.Repository.REPOSITORY;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6XSDH_HFT_2021222.Test
{
    [TestFixture]
    public class ScooterTests
    {
        public class FakeScooterRepository : IRepository<Scooter>
        {
            public void Create(Scooter thing)
            {
                throw new NotImplementedException();
            }

            public void Delete(int id)
            {
                throw new NotImplementedException();
            }

            public Scooter Read(int id)
            {
                throw new NotImplementedException();
            }

            public IQueryable<Scooter> ReadAll()
            {

                Brand xiaomi = new Brand() { BrandName = "Xiaomi" };
                Brand segway = new Brand() { BrandName = "Segway" };
                Brand bluetouch = new Brand() { BrandName = "BlueTouch" };
                return new List<Scooter>() {

                    new Scooter(){Brand=xiaomi, Range=25, Speed=23, Id=1, Rating=5, Price=5},
                    new Scooter(){Brand=xiaomi, Range=20, Speed=20, Id=2, Rating=3, Price=5},
                    new Scooter(){Brand=xiaomi, Range=15, Speed=18, Id=3, Rating=2, Price=5},
                    new Scooter(){Brand=xiaomi, Range=35, Speed=28, Id=4, Rating=5, Price=5},
                    new Scooter(){Brand=segway, Range=25, Speed=28, Id=5, Rating=4, Price=8},
                    new Scooter(){Brand=segway, Range=20, Speed=24, Id=6, Rating=3, Price=8},
                    new Scooter(){Brand=segway, Range=22, Speed=26, Id=7, Rating=4, Price=8},
                    new Scooter(){Brand=segway, Range=30, Speed=38, Id=8, Rating=5, Price=10},
                    new Scooter(){Brand=bluetouch, Range=55, Speed=33, Id=9, Rating=5,Model="Rangey Scooter", Price=25},
                    new Scooter(){Brand=bluetouch, Range=45, Speed=55, Id=10, Rating=5, Model="Fastest Scooter", Price=35},


                }.AsQueryable();
            }

            public void Update(Scooter thing)
            {
                throw new NotImplementedException();
            }
        }

        IScooterLogic logic;

        [SetUp]
        public void ScooterSetup()
        {
            logic = new ScooterLogic(new FakeScooterRepository());
        }

        [Test]
        public void CheckAverageRange()
        {
            double range = logic.AverageRange();
            Assert.AreEqual(range, 29.2, 0.1);
        }
        [Test]
        public void CheckAverageSpeed()
        {
            double speed = logic.AverageSpeed();
            Assert.AreEqual(speed, 29.3, 0.1);
        }

        [Test]
        public void CheckFastestScooter()
        {
            string speedy = logic.FastestScooter();
            string fastest = "Fastest Scooter";
            Assert.AreEqual(speedy, fastest);
        }

        [Test]
        public void CheckBesttRangeScooter()
        {
            string rangey = logic.BestRange();
            string bestrange = "Rangey Scooter";
            Assert.AreEqual(rangey, bestrange);
        }

        [Test]
        public void CheckPricePerBrand()
        {
            IEnumerable<KeyValuePair<string, double>> keyValues = logic.AVGPriceByBrandS();
            Assert.AreEqual(keyValues.Select(x=>x.Value).Min(), 5);
        }
    }
}

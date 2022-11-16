using C6XSDH_HFT_2021222.Logic.Logic;
using C6XSDH_HFT_2021222.Models.Entities;
using C6XSDH_HFT_2021222.Repository.REPOSITORY;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6XSDH_HFT_2021222.Test
{
    [TestFixture]
    public class BrandTests
    {
        BrandLogic logic;
        Mock<IRepository<Brand>> moqBrandRepository;

        [SetUp]
        public void Initalize()
        {
            moqBrandRepository = new Mock<IRepository<Brand>>();
            logic = new BrandLogic(moqBrandRepository.Object);


            List<Brand> brands = new List<Brand>()
            {
                new Brand(){BrandName="Csepel", Id=1},
                new Brand(){BrandName="Trek", Id=2},
                new Brand(){BrandName="Specialized", Id=3},
                new Brand(){BrandName="Hauser", Id=4},
                new Brand(){BrandName="Mongoose", Id=5},
                new Brand(){BrandName="Merida", Id=6}

            };


            moqBrandRepository.Setup(b => b.ReadAll()).Returns(brands.AsQueryable);
           
        }

        [Test]
        public void BrandCountTest()
        {
            int count = logic.ReadAll().Count();
            Assert.AreEqual(count, 6);
        }

        [Test]
        public void BrandCreateTest()
        {
            Brand brand = new Brand() { BrandName = "Csepel", Id = 1 };
            logic.Create(brand);
            moqBrandRepository.Verify(b => b.Create(brand), Times.Once);
        }

        [Test]
        public void BrandReadTest()
        {
            Brand brand=logic.Read(6);
            moqBrandRepository.Verify(b => b.Read(6), Times.Once);
       
        }


        [Test]
        public void BrandUpdateTest()
        {
            Brand brand = new Brand() { BrandName="Asd", Id=6};
            logic.Update(brand);
            moqBrandRepository.Verify(b => b.Update(brand), Times.Once);

        }
       

        [Test]
        public void BrandDeleteTest()
        {
            logic.Delete(6);
            moqBrandRepository.Verify(b => b.Delete(6), Times.Once);
        }
        
    }
}

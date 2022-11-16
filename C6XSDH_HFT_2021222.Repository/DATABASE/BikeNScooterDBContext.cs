using C6XSDH_HFT_2021222.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6XSDH_HFT_2021222.Repository
{
    public class BikeNScooterDBContext : DbContext
    {
        public virtual DbSet<Bike> Bikes { get; set; }
        public virtual DbSet<Scooter> Scooters { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }

        public BikeNScooterDBContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("bikenscooterdb").UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //--------------------BRANDS----------------------------------
            Brand merida = new Brand() { Id = 1, BrandName = "Merida" };
            Brand csepel = new Brand() { Id = 2, BrandName = "Csepel" };
            Brand trek = new Brand() { Id = 3, BrandName = "Trek" };
            Brand giant = new Brand() { Id = 4, BrandName = "Giant" };
            Brand winora = new Brand() { Id = 8, BrandName = "Winora" };
            Brand xiaomi = new Brand() { Id = 5, BrandName = "Xiaomi" };
            Brand segway = new Brand() { Id = 6, BrandName = "Segway" };
            Brand bluetouch = new Brand() { Id = 7, BrandName = "BlueTouch" };
            Brand hauser = new Brand() { Id = 9, BrandName = "Hauser" };
            Brand bianchi = new Brand() { Id = 10, BrandName = "Bianchi" };
            Brand pinarello = new Brand() { Id = 11, BrandName = "Pinarello" };
            Brand puch = new Brand() { Id = 12, BrandName = "Puch" };
            Brand whoosh = new Brand() { Id = 13, BrandName = "Whoosh" };
            Brand kugo = new Brand() { Id = 14, BrandName = "Kugo" };
            Brand hero = new Brand() { Id = 15, BrandName = "Hero" };
            //------------------------------------------------------------



            //---------------------------------------------BIKES-----------------------------------------------------
            Bike merida1 = new Bike() { Id = 1, BrandId = merida.Id, Model = "Dual Thrust", Price = 450000, Rating = 5 };
            Bike csepel1 = new Bike() { Id = 2, BrandId = csepel.Id, Model = "Schwinn Tour", Price = 35000, Rating = 3 };
            Bike csepel2 = new Bike() { Id = 3, BrandId = csepel.Id, Model = "Royal", Price = 120000, Rating = 4 };
            Bike csepel3 = new Bike() { Id = 4, BrandId = csepel.Id, Model = "Sas", Price = 20000, Rating = 2 };
            Bike csepel4 = new Bike() { Id = 12, BrandId = csepel.Id, Model = "Torpedo", Price = 150000, Rating = 4 };
            Bike trek1 = new Bike() { Id = 5, BrandId = trek.Id, Model = "Marlin 6", Price = 280000, Rating = 4 };
            Bike trek2 = new Bike() { Id = 6, BrandId = trek.Id, Model = "Madone SLR9", Price = 3500000, Rating = 5 };
            Bike giant1 = new Bike() { Id = 7, BrandId = giant.Id, Model = "ATX", Price = 170000, Rating = 4 };
            Bike giant2 = new Bike() { Id = 8, BrandId = giant.Id, Model = "Talon 0", Price = 360000, Rating = 5 };
            Bike giant3 = new Bike() { Id = 9, BrandId = giant.Id, Model = "Talon 5", Price = 560000, Rating = 5 };
            Bike trek3 = new Bike() { Id = 10, BrandId = trek.Id, Model = "Marlin 7", Price = 380000, Rating = 5 };
            Bike hauser1 = new Bike() { Id = 11, BrandId = hauser.Id, Model = "Puma", Price = 50000, Rating = 5 };
            Bike bianchi1 = new Bike() { Id = 13, BrandId = bianchi.Id, Model = "Duel 29s", Price = 240000, Rating = 3 };
            Bike bianchi2 = new Bike() { Id = 14, BrandId = bianchi.Id, Model = "Zolder pro", Price = 1200000, Rating = 5 };
            Bike bianchi3 = new Bike() { Id = 15, BrandId = bianchi.Id, Model = "Sport cross gent", Price = 290000, Rating = 4 };
            Bike pinarello1 = new Bike() { Id = 16, BrandId = pinarello.Id, Model = "Venetto", Price = 160000, Rating = 2 };
            Bike pinarello2 = new Bike() { Id = 17, BrandId = pinarello.Id, Model = "Dogma2", Price = 590000, Rating = 5 };
            Bike pinarello3 = new Bike() { Id = 18, BrandId = pinarello.Id, Model = "Paris", Price = 180000, Rating = 3 };
            Bike pinarello4 = new Bike() { Id = 19, BrandId = pinarello.Id, Model = "Force ASX racing", Price = 1800000, Rating = 5 };
            Bike puch1 = new Bike() { Id = 20, BrandId = puch.Id, Model = "Country", Price = 85000, Rating = 1 };
            Bike puch2 = new Bike() { Id = 21, BrandId = puch.Id, Model = "Mistral EL", Price = 48000, Rating = 3 };
            Bike puch3 = new Bike() { Id = 22, BrandId = puch.Id, Model = "Logic Delore", Price = 50000, Rating = 4 };
            Bike puch4 = new Bike() { Id = 23, BrandId = puch.Id, Model = "Inter 10", Price = 45000, Rating = 4 };
            //---------------------------------------------------------------------------------------------------------



            //-----------------------------------------------------------------------SCOOTERS----------------------------------------------------------------------
            Scooter xiaomi1 = new Scooter() { Id = 24, BrandId = xiaomi.Id, Model = "Mi Pro 2", Price = 160000, Rating = 3, Speed = 25, Range = 45 };
            Scooter xiaomi2 = new Scooter() { Id = 25, BrandId = xiaomi.Id, Model = "Mi Electric Scooter Essential", Price = 930000, Rating = 2, Speed = 20, Range = 20 };
            Scooter segway1 = new Scooter() { Id = 26, BrandId = segway.Id, Model = "Ninebot KickScooter MAX G30", Price = 250000, Rating = 4, Speed = 25, Range = 65 };
            Scooter segway2 = new Scooter() { Id = 27, BrandId = segway.Id, Model = "Ninebot KickScooter E22E ", Price = 150000, Rating = 3, Speed = 20, Range = 22 };
            Scooter bluetouch1 = new Scooter() { Id = 28, BrandId = bluetouch.Id, Model = "BT5000", Price = 280000, Rating = 5, Speed = 45, Range = 60 };
            Scooter bluetouch2 = new Scooter() { Id = 29, BrandId = bluetouch.Id, Model = "BT50000", Price = 580000, Rating = 5, Speed = 55, Range = 80 };
            Scooter whoosh1 = new Scooter() { Id = 30, BrandId = whoosh.Id, Model = "E-gecko", Price = 200000, Rating = 3, Speed = 25, Range = 30 };
            Scooter whoosh2 = new Scooter() { Id = 31, BrandId = whoosh.Id, Model = "E-pantrher", Price = 280000, Rating = 4, Speed = 35, Range = 40 };
            Scooter whoosh3 = new Scooter() { Id = 32, BrandId = whoosh.Id, Model = "E-python", Price = 280000, Rating = 3, Speed = 30, Range = 35 };
            Scooter kugo1 = new Scooter() { Id = 33, BrandId = kugo.Id, Model = "Plus s1", Price = 120000, Rating = 2, Speed = 20, Range = 20 };
            Scooter hero1 = new Scooter() { Id = 34, BrandId = hero.Id, Model = "s9", Price = 280000, Rating = 5, Speed = 35, Range = 50 };
            //-----------------------------------------------------------------------------------------------------------------------------------------------------



            //---------------------------------------PURCHASES--------------------------------------
            Purchase purchase1 = new Purchase() { Brand = merida, Id = 1, BrandId = merida.Id };
            Purchase purchase2 = new Purchase() { Brand = giant, Id = 2, BrandId = giant.Id };
            Purchase purchase3 = new Purchase() { Brand = xiaomi, Id = 3, BrandId = xiaomi.Id };
            Purchase purchase4 = new Purchase() { Brand = merida, Id = 4, BrandId = merida.Id };
            Purchase purchase5 = new Purchase() { Brand = csepel, Id = 5, BrandId = csepel.Id };
            Purchase purchase6 = new Purchase() { Brand = csepel, Id = 6, BrandId = csepel.Id };
            Purchase purchase7 = new Purchase() { Brand = merida, Id = 7, BrandId = merida.Id };
            Purchase purchase8 = new Purchase() { Brand = merida, Id = 8, BrandId = merida.Id };
            Purchase purchase9 = new Purchase() { Brand = giant, Id = 9, BrandId = giant.Id };
            Purchase purchase10 = new Purchase() { Brand = bluetouch, Id = 10, BrandId = bluetouch.Id };
            Purchase purchase11 = new Purchase() { Brand = xiaomi, Id = 11, BrandId = xiaomi.Id };
            Purchase purchase12 = new Purchase() { Brand = xiaomi, Id = 12, BrandId = xiaomi.Id };
            //----------------------------------------------------------------------------------------



            modelBuilder.Entity<Bike>(entity =>
            {
                entity.HasOne(bike => bike.Brand)
                        .WithMany(brand => brand.Bikes)
                        .HasForeignKey(bike => bike.BrandId)
                        .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasMany(brand => brand.Bikes)
                       .WithOne(bike => bike.Brand)
                       .HasForeignKey(brand => brand.BrandId)
                       .OnDelete(DeleteBehavior.Cascade);
            });

           

            modelBuilder.Entity<Brand>().HasData(merida, csepel, trek, giant, xiaomi, segway, bluetouch, hauser, bianchi, pinarello, puch, whoosh, kugo, hero);
            modelBuilder.Entity<Bike>().HasData(merida1, csepel1, csepel2, csepel3, csepel4, trek1, trek2, trek3, giant1, giant2,
                giant3, hauser1, bianchi1, bianchi2, bianchi3, pinarello1, pinarello2, pinarello3, pinarello4, puch1, puch2, puch3, puch4);
            modelBuilder.Entity<Scooter>().HasData(xiaomi1, xiaomi2, segway1, segway2, bluetouch1, bluetouch2, whoosh1, whoosh2, whoosh3, kugo1, hero1);
            modelBuilder.Entity<Purchase>().HasData(purchase1, purchase2, purchase3, purchase4, purchase5, purchase6, purchase7, purchase8, purchase9, purchase10,
                purchase11, purchase12);
        }

    }
}

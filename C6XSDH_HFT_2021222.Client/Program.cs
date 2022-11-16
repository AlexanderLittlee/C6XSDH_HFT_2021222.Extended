using C6XSDH_HFT_2021222.Models.Entities;
using ConsoleTools;
using System;
using System.Collections;
using System.Collections.Generic;


namespace C6XSDH_HFT_2021222.Client
{
    internal class Program
    {
        public static RestService restService = new RestService("http://localhost:30408");

        static void Main(string[] args)
        {
            var crudBike = new ConsoleMenu(args, level: 2)
                .Add("List all bikes", () => ListBikes())
                .Add("Create", () => CreateBike())
                .Add("ReadOne", () => ReadBike())
                .Add("Update", () => UpdateBike())
                .Add("Delete", () => DeleteBike())
                .Add("<<<", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.EnableWriteTitle = true;
                    config.Title = "BIKECRUD";
                });
            var crudScooter = new ConsoleMenu(args, level: 2)
                .Add("List all scooters", () => ListScooters())
                .Add("Create", () => CreateScooter())
                .Add("ReadOne", () => ReadScooter())
                .Add("Update", () => UpdateScooter())
                .Add("Delete", () => DeleteScooter())
                .Add("<<<", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.EnableWriteTitle = true;
                    config.Title = "SCOOTERCRUD";
                });
            var crudBrand = new ConsoleMenu(args, level: 2)
               .Add("List all Brands", () => ListBrands())
               .Add("Create", () => CreateBrand())
               .Add("ReadOne", () => ReadBrand())
               .Add("Update", () => UpdateBrand())
               .Add("Delete", () => DeleteBrand())
               .Add("<<<", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.EnableWriteTitle = true;
                   config.Title = "BRANDCRUD";
               });
            var crudPurchase = new ConsoleMenu(args, level: 2)
               .Add("List all purchases", () => ListPurchases())
               .Add("Create", () => CreatePurchase())
               .Add("ReadOne", () => ReadPurchase())
               .Add("Update", () => UpdatePurchase())
               .Add("Delete", () => DeletePurchase())
               .Add("<<<", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.EnableWriteTitle = true;
                   config.Title = "PURCHASECRUD";
               });

            var crudmenu = new ConsoleMenu(args, level: 1)
                .Add("Bikes", crudBike.Show)
                .Add("Scooters", crudScooter.Show)
                .Add("Brands", crudBrand.Show)
                .Add("Purchases", crudPurchase.Show)
                .Add("<<<", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.EnableWriteTitle = true;
                   config.Title = "CRUD";
               });
            var statmenu = new ConsoleMenu(args, level: 1)
                .Add("Average price of bikes", () => AveragePriceofBikes())
                .Add("Average rating of bikes", () => AverageRatingofBikes())
                .Add("Average price per brand (bike)", () => AvgPriceByBrandBIKE())
                .Add("5-star bikes", () => FivestarBikes())
                .Add("Cheapest bike", () => CheapestBike())
                .Add("Average speed of scooters", () => AverageSpeedofScooters())
                .Add("Average range of scooters", () => AverageRangeofScooters())
                .Add("Average price per brand (scooter)", () => AvgPriceByBrandScooter())
                .Add("Fastest scooter model", () => FastestScooter())
                .Add("Scooter model with best range", () => RangeyScooter())
                .Add("<<<", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.EnableWriteTitle = true;
                    config.Title = "STATISTICS";
                });

            var Mainmenu = new ConsoleMenu(args, level: 0)
           .Add("CRUD", crudmenu.Show)
           .Add("Statistics", statmenu.Show)
           .Add("exit", ConsoleMenu.Close)
           .Configure(config =>
           {
               config.EnableWriteTitle = true;
               config.Title = "MAIN MENU";
           });
            Mainmenu.Show();


        }

        //------------------------------------CRUD------------------------------------
        private static void ListBikes()
        {

            restService.Get<Bike>("bike")
                .ForEach(x => Console.WriteLine(x.Model));
            Console.WriteLine("\n Press a key to go back...");
            Console.ReadKey();
        }
        private static void ListScooters()
        {

            restService.Get<Scooter>("scooter")
                .ForEach(x => Console.WriteLine(x.Model));
            Console.WriteLine("\n Press a key to go back...");
            Console.ReadKey();
        }
        private static void ListBrands()
        {
            Console.WriteLine("Brands: ");
            restService.Get<Brand>("brand").ForEach(x => Console.WriteLine(x.BrandName));
            Console.WriteLine("\n Press a key to go back...");
            Console.ReadKey();
        }
        private static void ListPurchases()
        {
            Console.WriteLine("Purchases:  \nID\tBrandID");
            restService.Get<Purchase>("purchase").ForEach(x => Console.WriteLine(x.Id + "\t" + x.BrandId));
            Console.WriteLine("\n Press a key to go back...");
            Console.ReadKey();
        }


        private static void CreateBike()
        {
            Bike item = new Bike();

            Console.WriteLine("Name the model: ");
            string name = Console.ReadLine();
            item.Model = name;

            Console.WriteLine("Give a brand ID: ");
            int num = int.Parse(Console.ReadLine());
            item.BrandId = num;

            Console.WriteLine("Give a price: ");
            num = int.Parse(Console.ReadLine());
            item.Price = num;

            Console.WriteLine("Give rating: ");
            num = int.Parse(Console.ReadLine());
            item.Rating = num;

            restService.Post(item, "bike");
            Console.WriteLine("Bike created! \n Press a key to continue");
            Console.ReadKey();

        }
        private static void CreateScooter()
        {
            Scooter item = new Scooter();

            Console.WriteLine("Give a brand ID: ");
            int id = int.Parse(Console.ReadLine());
            item.BrandId = id;

            Console.WriteLine("Name the model: ");
            string name = Console.ReadLine();
            item.Model = name;

            Console.WriteLine("Give a price: ");
            id = int.Parse(Console.ReadLine());
            item.Price = id;

            Console.WriteLine("Give rating: ");
            id = int.Parse(Console.ReadLine());
            item.Rating = id;

            Console.WriteLine("Give speed: ");
            int speed = int.Parse(Console.ReadLine());
            item.Speed = speed;

            Console.WriteLine("Give range: ");
            int range = int.Parse(Console.ReadLine());
            item.Range = range;

            restService.Post(item, "scooter");
            Console.WriteLine("Scooter created! \n Press a key to continue");
            Console.ReadKey();

        }
        private static void CreateBrand()
        {
            Brand brand = new Brand();

            Console.WriteLine("Name the brand: ");
            string name = Console.ReadLine();
            brand.BrandName = name;

            restService.Post(brand, "brand");
            Console.WriteLine("Brand created! \n Press a key to continue");
            Console.ReadKey();
        }
        private static void CreatePurchase()
        {
            Purchase pur = new Purchase();

            Console.WriteLine("Give an ID of brand that has been purchased: ");
            int num = int.Parse(Console.ReadLine());
            pur.BrandId = num;

            restService.Post(pur, "purchase");
            Console.WriteLine("Purchase created! \n Press a key to continue");
            Console.ReadKey();
        }


        private static void ReadBike()
        {
            Console.WriteLine("Give the ID of the bike you want to get: ");
            int ID = int.Parse(Console.ReadLine());
            Bike res = restService.GetSingle<Bike>("bike/" + ID);
            if (res is null)
            {
                Console.WriteLine("There is no bike with this ID! ");

            }
            else
            {
                Console.WriteLine(res.Model);
            }
            Console.ReadKey();

        }
        private static void ReadScooter()
        {
            Console.WriteLine("Give the ID of the scooter you want to get: ");
            int ID = int.Parse(Console.ReadLine());
            Scooter res = restService.GetSingle<Scooter>("scooter/" + ID);
            if (res is null)
            {
                Console.WriteLine("There is no scooter with this ID! ");

            }
            else
            {
                Console.WriteLine(res.Model);
            }
            Console.ReadKey();

        }
        private static void ReadBrand()
        {
            Console.WriteLine("Give the ID of the brand you want to get: ");
            int ID = int.Parse(Console.ReadLine());
            Brand res = restService.GetSingle<Brand>("brand/" + ID);
            if (res is null)
            {
                Console.WriteLine("There is no brand with this ID! ");

            }
            else
            {
                Console.WriteLine(res.BrandName);
            }
            Console.ReadKey();

        }
        private static void ReadPurchase()
        {
            Console.WriteLine("Give the ID of the purchase you want to get: ");
            int ID = int.Parse(Console.ReadLine());
            Purchase res = restService.GetSingle<Purchase>("purchase/" + ID);
            if (res is null)
            {
                Console.WriteLine("There is no purchase with this ID! ");

            }
            else
            {
                Console.WriteLine(res.BrandId);
            }
            Console.ReadKey();
        }


        private static void UpdateBike()
        {
            Console.WriteLine("Give the ID of the bike you want to update: ");
            int ID = int.Parse(Console.ReadLine());
            Bike old = restService.Get<Bike>(ID, "bike");
            Console.WriteLine("Give a new model name: ");
            string name = Console.ReadLine();
            old.Model = name;
            Console.WriteLine("Give a price: ");
            int num = int.Parse(Console.ReadLine());
            old.Price = num;
            Console.WriteLine("Give rating: ");
            num = int.Parse(Console.ReadLine());
            old.Rating = num;

            restService.Put(old, "bike");
            Console.WriteLine("Bike updated! \n Press a key to continue");
            Console.ReadKey();

        }
        private static void UpdateScooter()
        {
            Console.WriteLine("Give the ID of the scooter you want to update: ");
            int ID = int.Parse(Console.ReadLine());
            Scooter old = restService.Get<Scooter>(ID, "scooter");
            Console.WriteLine("Give a new model name: ");
            string name = Console.ReadLine();
            old.Model = name;
            Console.WriteLine("Give a price: ");
            int num = int.Parse(Console.ReadLine());
            old.Price = num;
            Console.WriteLine("Give rating: ");
            num = int.Parse(Console.ReadLine());
            old.Rating = num;

            Console.WriteLine("Give speed: ");
            num = int.Parse(Console.ReadLine());
            old.Speed = num;
            Console.WriteLine("Give range: ");
            num = int.Parse(Console.ReadLine());
            old.Range = num;

            restService.Put(old, "scooter");
            Console.WriteLine("Scooter updated! \n Press a key to continue");
            Console.ReadKey();

        }
        private static void UpdateBrand()
        {
            Console.WriteLine("Give the ID of the brand you want to update: ");
            int ID = int.Parse(Console.ReadLine());
            Brand old = restService.Get<Brand>(ID, "brand");
            Console.WriteLine("Give a new brand name: ");
            old.BrandName = Console.ReadLine();
            restService.Put(old, "brand");
            Console.WriteLine("Brand updated! \n Press a key to continue");
            Console.ReadKey();
        }
        private static void UpdatePurchase()
        {
            Console.WriteLine("Give the ID of the purchase you want to update: ");
            int ID = int.Parse(Console.ReadLine());
            Purchase old = restService.Get<Purchase>(ID, "purchase");
            Console.WriteLine("Give a new brand ID: ");
            old.BrandId = int.Parse(Console.ReadLine());
            restService.Put(old, "purchase");
            Console.WriteLine("Purchase updated! \n Press a key to continue");
            Console.ReadKey();
        }


        private static void DeleteBike()
        {
            Console.WriteLine("Give the ID of the bike you want to delete (1-23 + newly added IDs): ");
            int id = int.Parse(Console.ReadLine());
            Bike res = restService.GetSingle<Bike>("bike/" + id);
            if (res is not null)
            {
                restService.Delete(id, "bike");
                Console.WriteLine("Bike deleted! \n Press a key to continue");
            }
            else
            {
                Console.WriteLine("There is no bike with this ID!\n Press a key to continue");
            }
            Console.ReadKey();
        }
        private static void DeleteScooter()
        {
            Console.WriteLine("Give the ID of the scooter you want to delete (24-34 + newly added IDs): ");
            int id = int.Parse(Console.ReadLine());
            Scooter res = restService.GetSingle<Scooter>("scooter/" + id);
            if (res is not null)
            {
                restService.Delete(id, "bike");
                Console.WriteLine("Scooter deleted! \n Press a key to continue");
            }
            else
            {
                Console.WriteLine("There is no scooter with this ID!\n Press a key to continue");
            }
            Console.ReadKey();

        }
        private static void DeleteBrand()
        {
            Console.WriteLine("Give the ID of the brand you want to delete: ");
            int id = int.Parse(Console.ReadLine());

            Brand res = restService.GetSingle<Brand>("brand/" + id);
            if (res is not null)
            {
                restService.Delete(id, "brand");
                Console.WriteLine("Brand deleted! \n Press a key to continue");
            }
            else
            {
                Console.WriteLine("There is no brand with this ID!\n Press a key to continue");
            }
            Console.ReadKey();
        }
        private static void DeletePurchase()
        {
            Console.WriteLine("Give the ID of the purchase you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            Purchase res = restService.GetSingle<Purchase>("purchase/" + id);
            if (res is not null)
            {
                restService.Delete(id, "purchase");
                Console.WriteLine("Purchase deleted! \n Press a key to continue");
            }
            else
            {
                Console.WriteLine("There is no purchase with this ID!\n Press a key to continue");
            }
            Console.ReadKey();
        }


        //-------------------------------------STAT------------------------------------

        private static void AveragePriceofBikes()
        {
            var avg = restService.GetSingle<double>("stat/AveragePrice");
            Console.WriteLine("Average price of bikes: " + avg);
            Console.WriteLine("Press a key to go back...");
            Console.ReadKey();
        }
        private static void AverageRatingofBikes()
        {
            var avg = restService.GetSingle<double>("stat/AverageRating");
            Console.WriteLine("Average rating of bikes: " + avg);
            Console.WriteLine("Press a key to go back...");
            Console.ReadKey();
        }
        private static void FivestarBikes()
        {
            var bests = restService.GetSingle<IEnumerable<Bike>>("stat/BestBikes");
            foreach (var item in bests)
            {
                Console.WriteLine(item.Model);
            }
            Console.WriteLine("Press a key to go back...");
            Console.ReadKey();
        }
        private static void AverageSpeedofScooters()
        {
            var avg = restService.GetSingle<double>("stat/AverageSpeed");
            Console.WriteLine("Average speed of scooters: " + avg);
            Console.WriteLine("Press a key to go back...");
            Console.ReadKey();
        }
        private static void AverageRangeofScooters()
        {
            var avg = restService.GetSingle<double>("stat/AverageRange");
            Console.WriteLine("Average range of scooters: " + avg);
            Console.WriteLine("Press a key to go back...");
            Console.ReadKey();
        }
        private static void FastestScooter()
        {
            string best = restService.GetSingle<string>("stat/FastestScooter");
            Console.WriteLine("Fastest scooter: " + best);
            Console.WriteLine("Press a key to go back...");
            Console.ReadKey();
        }
        private static void RangeyScooter()
        {
            string rangest = restService.GetSingle<string>("stat/RangestScooter");
            Console.WriteLine("Scooter with best range: " + rangest);
            Console.WriteLine("Press a key to go back...");
            Console.ReadKey();
        }
        private static void CheapestBike()
        {
            string cheap = restService.GetSingle<string>("stat/CheapestBike");
            Console.WriteLine("Cheapest bike: " + cheap);
            Console.WriteLine("Press a key to go back...");
            Console.ReadKey();
        }
        private static void AvgPriceByBrandScooter()
        {
            IEnumerable<KeyValuePair<string, double>> scooters= restService.GetSingle<IEnumerable<KeyValuePair<string, double>>>("stat/AVGPriceByBrandS");
            Console.WriteLine("Scooter brands and their average prices:\n");
            foreach (var item in scooters)
            {
                Console.WriteLine(item.Key+"\t"+item.Value);
            }
            Console.WriteLine("Press a key to go back...");
            Console.ReadKey();
        }
        private static void AvgPriceByBrandBIKE()
        {
            var bikes = restService.GetSingle<IEnumerable<KeyValuePair<string, double>>>("stat/AVGPriceByBrandB");
            Console.WriteLine("Scooter brands and their average prices:\n");
            foreach (var item in bikes)
            {
                Console.WriteLine(item.Key + "\t" + item.Value);
            }
            Console.WriteLine("Press a key to go back...");
            Console.ReadKey();
        }
            

        
    }
}

﻿using C6XSDH_HFT_2021222.Models.Entities;
using C6XSDH_HFT_2021222.WPFClient;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace WPF_Client

{
    public class MainWindowViewModel : ObservableRecipient
    {
        

        //selected items (propfulls)
        
        private Bike selectedbike;
        public Bike SelectedBike
        {
            get { return selectedbike; }
            set
            {
                if (value!=null)
                {

                    selectedbike = new Bike()
                    {
                        Model = value.Model,
                        Id = value.Id,
                        Brand = value.Brand,
                        Price = value.Price,
                        Rating = value.Rating,
                    };
                    OnPropertyChanged();
                    (UpdateBike as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteBike as RelayCommand).NotifyCanExecuteChanged();
                    
                }
            }
        }

        private Scooter selectedscooter;
        public Scooter SelectedScooter
        {
            get { return selectedscooter; }
            set 
            {
                if (value != null)
                {

                    selectedscooter = new Scooter()
                    {
                        Model = value.Model,
                        Id = value.Id,
                        Brand = value.Brand,
                        Price = value.Price,
                        Rating = value.Rating,
                        Range = value.Range,
                        Speed = value.Speed
                    };
                    OnPropertyChanged();
                    (UpdateScooter as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteScooter as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }

        private Brand selectedbrand;
        public Brand SelectedBrand
        {
            get { return selectedbrand; }
            set {
                if (value != null)
                {

                    selectedbrand = new Brand()
                    {
                        Id = value.Id,
                        BrandName = value.BrandName
                    };
                    OnPropertyChanged();
                    (UpdateBrand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteBrand as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }



        //collections of entities

        public RestCollection<Bike> Bikes { get; set; }
        public RestCollection<Scooter> Scooters{ get; set; }
        public RestCollection<Brand> Brands { get; set; }
        


        //button commands, crud for each different entity

        public ICommand CreateBike { get; set; }
        public ICommand UpdateBike { get; set; }
        public ICommand DeleteBike { get; set; }

        public ICommand CreateScooter { get; set; }
        public ICommand UpdateScooter { get; set; }
        public ICommand DeleteScooter { get; set; }

        public ICommand CreateBrand { get; set; }
        public ICommand UpdateBrand { get; set; }
        public ICommand DeleteBrand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        private static void Nuller(MainWindowViewModel vm)
        {
            vm.SelectedBike = new Bike();
            vm.SelectedBrand = new Brand();
            vm.SelectedScooter = new Scooter();
        }
        public MainWindowViewModel()
        {
            
            if (!IsInDesignMode)
            {

                Bikes = new RestCollection<Bike>("http://localhost:30408/", "bike","hub");
                Scooters = new RestCollection<Scooter>("http://localhost:30408/", "scooter", "hub");
                Brands = new RestCollection<Brand>("http://localhost:30408/", "brand", "hub");



                CreateBike = new RelayCommand(() =>
                {
                     if (SelectedBike!=null)
                     {
                        var bike = SelectedBike;
                        bike.Id = Bikes.OrderByDescending(b => b.Id).FirstOrDefault().Id+1;
                        Bikes.Add(bike);
                     }
                     else
                        Bikes.Add(SelectedBike);
                } );
                UpdateBike = new RelayCommand(() => { Bikes.Update(SelectedBike); Nuller(this); }, () => { return SelectedBike != null; });
                DeleteBike = new RelayCommand(() => { Bikes.Delete(SelectedBike.Id); }, () => { return SelectedBike != null; });

                CreateScooter = new RelayCommand(() => 
                {
                    if (SelectedScooter!=null)
                    {
                        var scooter = SelectedScooter;
                        scooter.Id=Scooters.OrderByDescending(b => b.Id).FirstOrDefault().Id + 1;
                        Scooters.Add(scooter);
                    }
                    else
                        Scooters.Add(SelectedScooter); 
                
                });
                UpdateScooter = new RelayCommand(() => { Scooters.Update(SelectedScooter); Nuller(this); }, () => { return SelectedScooter != null; });
                DeleteScooter = new RelayCommand(() => { Scooters.Delete(SelectedScooter.Id); }, () => { return SelectedScooter != null; });

                CreateBrand= new RelayCommand(() => 
                {
                    if (SelectedBrand!=null)
                    {
                        var brand = SelectedBrand;
                        brand.Id=Brands.OrderByDescending(b => b.Id).FirstOrDefault().Id + 1;
                        Brands.Add(brand);
                    }
                    else
                        Brands.Add(SelectedBrand); 
                });
                UpdateBrand = new RelayCommand(() => { Brands.Update(SelectedBrand); Nuller(this); }, () => { return SelectedBrand != null; });
                DeleteBrand = new RelayCommand(() => { Brands.Delete(SelectedBrand.Id); }, () => { return SelectedBrand != null; });

                Nuller(this);
                
            }
        }

    }
}

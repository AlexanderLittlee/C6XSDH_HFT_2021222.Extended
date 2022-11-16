using C6XSDH_HFT_2021222.Models.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_Client

{
    public class MainWindowViewModel : ObservableRecipient
    {
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
                    (DeleteBike as RelayCommand).NotifyCanExecuteChanged();
                    
                }
            }
        }



        public RestCollection<Bike> Bikes { get; set; }
        public RestCollection<Scooter> Scooters{ get; set; }
        public RestCollection<Brand> Brands { get; set; }
        public RestCollection<Purchase> Purchases{ get; set; }

        public ICommand CreateBike { get; set; }
        public ICommand UpdateBike { get; set; }
        public ICommand DeleteBike { get; set; }
        
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {
            
            if (!IsInDesignMode)
            {

                Bikes = new RestCollection<Bike>("http://localhost:30408/", "bike");
                Scooters = new RestCollection<Scooter>("http://localhost:30408/", "scooter");
                Brands = new RestCollection<Brand>("http://localhost:30408/", "brand");
                Purchases = new RestCollection<Purchase>("http://localhost:30408/", "purchase");


                CreateBike = new RelayCommand(() => { Bikes.Add(SelectedBike); });
                UpdateBike = new RelayCommand(() => { Bikes.Update(SelectedBike); }, () => { return SelectedBike != null; });
                DeleteBike = new RelayCommand(() => { Bikes.Delete(SelectedBike.Id); }, () => { return SelectedBike != null; });
                SelectedBike=new Bike();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CoREMobile.ViewModels;
using CoREMobile.Helpers;

namespace CoREMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMaster : ContentPage
    {
        public ListView ListView;

        public MainPageMaster()
        {
            InitializeComponent();

            BindingContext = new MainPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainPageMenuItem> MenuItems { get; set; }

            public ObservableCollection<Grouping<string, MainPageMenuItem>> GroupedMenuItems { get; set; }

            public MainPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainPageMenuItem>(new[]
                {
                    new MainPageMenuItem { Id = 0, Title = "All Listings", TitleHeader = "My Listings" },
                    new MainPageMenuItem { Id = 1, Title = "Outdated Listings", TitleHeader = "My Listings" },
                    new MainPageMenuItem { Id = 2, Title = "Review New Deals", TitleHeader = "Advisory Board Members" },
                    new MainPageMenuItem { Id = 3, Title = "All Signed Deals", TitleHeader = "Advisory Board Members" },
                    new MainPageMenuItem { Id = 4, Title = "Update/Edit Profile", TitleHeader = "My Profile" },
                    new MainPageMenuItem { Id = 5, Title = "Phone", TitleHeader = "Contact Us" },
                    new MainPageMenuItem { Id = 6, Title = "Email", TitleHeader = "Contact Us" },
                    new MainPageMenuItem { Id = 7, Title = "Xceligent Pro", TitleHeader = "About Xceligent" },
                    new MainPageMenuItem { Id = 8, Title = "Spaceful", TitleHeader = "About Xceligent" },
                    new MainPageMenuItem { Id = 9, Title = "Xceligent Direct", TitleHeader = "About Xceligent" },
                });

                var sorted = from menuItem in MenuItems
                             group menuItem by menuItem.TitleHeader into menuGroup
                             select new Grouping<string, MainPageMenuItem>(menuGroup.Key, menuGroup);

                GroupedMenuItems = new ObservableCollection<Grouping<string, MainPageMenuItem>>(sorted);
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
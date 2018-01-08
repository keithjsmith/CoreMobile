using CoREMobile.Models;
using CoREMobile.Services;
using CoREMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace CoREMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListingSummary : ContentPage
    {
        ListingViewModel viewModel;
        public ListingSummary()
        {

            InitializeComponent();

            //TODO: update this to bind to the actual model we are going to use
            BindingContext = viewModel = new ListingViewModel();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            if (viewModel.Listings.Count == 0)
                viewModel.LoadListingsCommand.Execute(null);

            //reset the selection to null so that we can select the same item again
            lv_ListingSummary.SelectedItem = null;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //make sure we didn't just set the selection back to null
            if (e.SelectedItem == null) return;

            Navigation.PushAsync(new ListingDetail((Listing)e.SelectedItem));
            
        }
    }
}
using CoREMobile.Helpers;
using CoREMobile.Models;
using CoREMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CoREMobile.ViewModels
{
    /// <summary>
    /// View Model for Listing Summary page
    /// </summary>
    public class ListingViewModel : BaseViewModel
    {
        /// <summary>
        /// Get the listings service instance
        /// </summary>
        public IDataStore<Listing> ListingStore => DependencyService.Get<IDataStore<Listing>>();

        public ObservableRangeCollection<Listing> Listings { get; set; }
        public Command LoadListingsCommand { get; set; }
        public ListingViewModel()
        {
            Title = "My Listings";

            Listings = new ObservableRangeCollection<Listing>();

            //pass responsibility for refreshing data to the UI layer (ListingSummary.xaml file)
            LoadListingsCommand = new Command(async () => await ExecuteLoadListingsCommand());

        }


        async Task ExecuteLoadListingsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Listings.Clear();

                //replace this to call to 3n1 for listing summary
                //DELETE BEFORE MERGING

                //XRS.Shared.Types.TN1Transaction T = new XRS.Shared.Types.TN1Transaction();
                //XRS.PresentationLogic.CDX.Implementation.ListingService.ListingSummaryMobilePE listings = new XRS.PresentationLogic.CDX.Implementation.ListingService.ListingSummaryMobilePE(null, T, false);
                //listings.GetListingSummaryMobileMobileAsync()

                var listings = await ListingStore.GetItemsAsync(true);
                Listings.ReplaceRange(listings);
            }
            catch (Exception ex)
            {
                //log message here

            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}

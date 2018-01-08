using CoREMobile.Helpers;
using CoREMobile.Models;
using CoREMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CoREMobile.ViewModels
{
    public class SuiteViewModel : BaseViewModel
    {
        /// <summary>
        /// Get the suites service instance
        /// </summary>
        public IDataStore<Space> SuiteStore => DependencyService.Get<IDataStore<Space>>();

        public ObservableRangeCollection<Space> Suites { get; set; }
        public Command LoadListingsCommand { get; set; }
        public SuiteViewModel()
        {
            Title = "My Suites";

            Suites = new ObservableRangeCollection<Space>();
            LoadListingsCommand = new Command(async () => await ExecuteLoadListingsCommand());

        }


        async Task ExecuteLoadListingsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Suites.Clear();
                var suites = await SuiteStore.GetItemsAsync(true);
                Suites.ReplaceRange(suites);
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

using CoREMobile.Interfaces;
using CoREMobile.Models;
using CoREMobile.Services;
using CoREMobile.Strategies;
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
	public partial class SuiteDetail : ContentPage
	{
        SuiteDetailPageControls suiteControls;
        public Space selectedSuite;
        IControlOrder<SuiteDetailPageControls> selectedSuiteType;
        public IDataStore<Space> suiteStore => DependencyService.Get<IDataStore<Space>>();

        public SuiteDetail (int suiteId)
		{
            NavigationPage.SetHasBackButton(this, true);

            InitializeComponent ();

            //TODO: get current Suite based on Id
            GetSuiteById(suiteId);

            CreatePageControls();



            //Set strategy
            SetSuitetrategy(selectedSuite);

            selectedSuiteType.SetTopControlsOrder(suiteControls);
            selectedSuiteType.SetMiddleControlsOrder(suiteControls);
            selectedSuiteType.SetBottomControlsOrder(suiteControls);
        }

        private void SetSuitetrategy(Space suite)
        {
            switch (selectedSuite.Type)
            {
                case SpaceType.Office:
                    selectedSuiteType = new OfficeSuiteDetail();
                    break;
                case SpaceType.Industrial:
                    selectedSuiteType = new IndustrialSuiteDetail();
                    break;
                case SpaceType.Retail:
                    selectedSuiteType = new RetailSuiteDetail();
                    break;
                default:
                    break;
            }
        }

        private void CreatePageControls()
        {
            suiteControls = new SuiteDetailPageControls(this, this.selectedSuite);
            Content = suiteControls.sl_MainWrapper;
        }

        private async void GetSuiteById(int suiteId)
        {
            selectedSuite = await suiteStore.GetItemAsync(suiteId);

        }
    }
}
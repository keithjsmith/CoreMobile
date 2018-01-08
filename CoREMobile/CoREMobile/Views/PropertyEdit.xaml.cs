using CoREMobile.Interfaces;
using CoREMobile.Models;
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
    public partial class ListingEdit : ContentPage
    {
        PropertyEditPageControls editControls;
        IControlOrder<PropertyEditPageControls> selectedProperty;
        public ListingEdit(Property property)
        {
            NavigationPage.SetHasBackButton(this, true);

            InitializeComponent();

            CreatePageControls();

            SetEditStrategy(property);

            selectedProperty.SetTopControlsOrder(editControls);
            selectedProperty.SetBottomControlsOrder(editControls);
            selectedProperty.SetMiddleControlsOrder(editControls);
        }

        private void SetEditStrategy(Property property)
        {
            switch (property.PropertyType)
            {
                case PropertyType.Office:
                    selectedProperty = new OfficePropertyEdit();
                    break;
                case PropertyType.Industrial:
                    selectedProperty = new IndustrialProertyEdit();
                    break;
                case PropertyType.Retail:
                    selectedProperty = new RetailPropertyEdit();
                    break;
                case PropertyType.Multifamily:
                    selectedProperty = new MultifamilyPropertyEdit();
                    break;
                case PropertyType.Land:
                    selectedProperty = new LandPropertyEdit();
                    break;
                case PropertyType.SpecialUse:
                    selectedProperty = new SpecialUsePropertyEdit();
                    break;
                default:
                    selectedProperty = new OfficePropertyEdit();
                    break;
            }
        }

        void CreatePageControls()
        {
            editControls = new PropertyEditPageControls(this);
            Content = editControls.sl_MainWrapper;
        }
    }
}
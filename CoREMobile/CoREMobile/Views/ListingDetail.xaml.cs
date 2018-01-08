using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CoREMobile.Models;
using CoREMobile.Strategies;
using CoREMobile.Interfaces;
using CoREMobile.Helpers;
using CoREMobile.ViewModels;
using CoREMobile.Services;

namespace CoREMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListingDetail : ContentPage
    {
        PropertyDetailsPageControls detailControls;
        IControlOrder<PropertyDetailsPageControls> selectedListingType;
        public IDataStore<Space> suiteStore => DependencyService.Get<IDataStore<Space>>();
        //make propertydetailseditcontrols
        public ListingDetail(Listing listing)
        {
            NavigationPage.SetHasBackButton(this, true);

            InitializeComponent();

            CreatePageControls();

            //Set strategy
            SetListingStrategy(listing);

            selectedListingType.SetTopControlsOrder(detailControls);
            selectedListingType.SetBottomControlsOrder(detailControls);

            //TODO: update this code to each individual strategy class
            SetMiddleControlsOrder(listing);
        }

        void CreatePageControls()
        {
            detailControls = new PropertyDetailsPageControls(this);
            Content = detailControls.sl_MainWrapper;
        }

        private async void SetMiddleControlsOrder(Listing listing)
        {

            ScrollView sv_details = new ScrollView()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            StackLayout sl_details = new StackLayout()
            {
                Padding = 10,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            var img_mainImage = new Image()
            {
                Source = "http://res.cloudinary.com/xceligent/image/upload/t_XCPermOverlay/s3uat/WaterMarked/170/7383170",
                HeightRequest = 200,
                Aspect = Aspect.Fill
            };

            string listingDetails = "Bacon ipsum dolor amet tri-tip et reprehenderit turducken tenderloin landjaeger, drumstick irure ut ea cillum.Tail dolore deserunt in leberkas nulla ground round. Adipisicing tempor incididunt ad nulla aliquip id fugiat capicola sausage flank fatback ham.Qui doner ut, deserunt laborum frankfurter hamburger bacon ball tip culpa. Qui biltong laborum veniam fatback ribeye sint pork chop nulla sunt hamburger. Boudin corned beef pariatur, magna jerky burgdoggen minim cow ut ut prosciutto andouille bresaola pork chop.";

            Frame frm_ListingComments = new Frame()
            {
                OutlineColor = Color.Black,
                HasShadow = false
            };

            Label lbl_listingComments = new Label()
            {
                Text = listingDetails,
                FontAttributes = FontAttributes.Bold,
                FontSize = 12,
                LineBreakMode = LineBreakMode.WordWrap
            };

            frm_ListingComments.Content = lbl_listingComments;

            var labelStyle = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter { Property = Label.FontSizeProperty, Value = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) },
                    new Setter { Property = Label.FontProperty, Value = FontAttributes.Bold},
                    new Setter { Property = Label.LineBreakModeProperty, Value = LineBreakMode.WordWrap}

                }
            };

            Label lbl_CommentsTitle = new Label() { Text = "Listing Comments", Style = labelStyle };
            Label lbl_SuitesTitle = new Label() { Text = "Suites", Style = labelStyle };
            Label lbl_SaleDetailTitle = new Label() { Text = "Sale Detail", Style = labelStyle };
            Label lbl_PropertyLocationTitle = new Label() { Text = "Property Location", Style = labelStyle };
            Label lbl_AttachmentsTitle = new Label() { Text = "Attachments", Style = labelStyle };
            Label lbl_ListingRepsTitle = new Label() { Text = "Listing Reps", Style = labelStyle };



            StackLayout sl_images = new StackLayout { Orientation = StackOrientation.Horizontal, Margin = new Thickness(0, 0, 0, 5) };

            int n = 25;
            for (int i = 0; i < n; i++)
            {
                var img_AdditionalListingImage = new Image()
                {
                    Source = "http://res.cloudinary.com/xceligent/image/upload/t_XCPermOverlay/s3uat/WaterMarked/170/7383170",
                    BackgroundColor = Color.Transparent,
                    HeightRequest = 75,
                    WidthRequest = 75,
                    Aspect = Aspect.AspectFill
                };
                sl_images.Children.Add(img_AdditionalListingImage);
            }

            ScrollView sv_images = new ScrollView();
            sv_images.HorizontalOptions = LayoutOptions.Fill;
            sv_images.Orientation = ScrollOrientation.Horizontal;
            sv_images.Content = sl_images;

            //Sales Detail grid
            Grid grd_SalesDetail = ControlsUtil.GridBuilder(6, 2, new Grid());

            grd_SalesDetail.HorizontalOptions = LayoutOptions.FillAndExpand;
            grd_SalesDetail.Padding = new Thickness(10, 0, 0, 0);

            Frame frm_SalesDetail = new Frame()
            {
                OutlineColor = Color.Black,
                HasShadow = false
            };

            //Create suites
            var suitesList = await suiteStore.GetItemsAsync();
            //SuiteViewModel suiteModels = new SuiteViewModel();
            //List<Space> suites = GetSuites();
            List<Space> suites = (List<Space>)suitesList;

            int numSuites = suites.Count / 2 + suites.Count % 2;

            Grid grd_Suites = ControlsUtil.GridBuilder(numSuites, 2, new Grid());

            int rowAssignment;
            int columnAssignment;

            for (int i = 0; i < suites.Count; i++)
            {
                Frame frm_SuiteDetail = new Frame()
                {
                    OutlineColor = Color.Black,
                    HasShadow = false,
                    Padding = new Thickness(0),
                    CornerRadius = 0

                };
                Grid grd_SuiteInfo = ControlsUtil.GridBuilder(2, 1, new Grid());
                grd_SuiteInfo.RowDefinitions[1].Height = new GridLength(3, GridUnitType.Star);

                Button btn_SuiteNumber = new Button()
                {
                    HeightRequest = 20,
                    WidthRequest = 250,
                    Margin = 0,
                    HorizontalOptions = LayoutOptions.Center,
                    BorderWidth = 1,
                    BorderColor = Color.Black,
                    BorderRadius = 0,
                    FontSize = 18,
                    Text = "Suite " + suites[i].SpaceId.ToString(),
                    BackgroundColor = (Color)Application.Current.Resources[ResourceKeys.Colors.PrimaryColor],
                    TextColor = Color.White,
                    CommandParameter = suites[i].SpaceId
                };
                btn_SuiteNumber.Clicked += Btn_SuiteNumber_Clicked;

                var img_SuiteImage = new Image()
                {
                    Source = suites[i].SpaceImageUrl,
                    BackgroundColor = Color.Transparent,
                    HeightRequest = 60,
                    Aspect = Aspect.Fill,
                    Margin = 0
                };

                FormattedString stringContainer = new FormattedString();

                Label lbl_SuiteSize = new Label() { FontSize = 9, Margin = new Thickness(10, 0, 0, 0) };
                stringContainer.Spans.Add(new Span { Text = "Size: ", FontAttributes = FontAttributes.Bold, FontSize = 9 });
                stringContainer.Spans.Add(new Span { Text = suites[i].AvailableSF.ToString() });
                lbl_SuiteSize.FormattedText = stringContainer;
                Label lbl_SuiteVacancy = new Label() { FontSize = 9, Margin = new Thickness(10, 0, 0, 0) };
                stringContainer = new FormattedString();
                stringContainer.Spans.Add(new Span { Text = "Vacant: ", FontAttributes = FontAttributes.Bold, FontSize = 9 });
                stringContainer.Spans.Add(new Span { Text = suites[i].Vacant.ToString() });
                lbl_SuiteVacancy.FormattedText = stringContainer;
                Label lbl_SuiteLeaseRate = new Label() { FontSize = 9, Margin = new Thickness(10, 0, 0, 0) };
                stringContainer = new FormattedString();
                stringContainer.Spans.Add(new Span { Text = "Lease Rate: ", FontAttributes = FontAttributes.Bold, FontSize = 9 });
                stringContainer.Spans.Add(new Span { Text = suites[i].LeaseRateLow.ToString("C") + " - " + suites[i].LeaseRateHigh.ToString("C") });
                lbl_SuiteLeaseRate.FormattedText = stringContainer;
                Label lbl_SuiteLeaseType = new Label() { FontSize = 9, Margin = new Thickness(10, 0, 0, 0) };
                stringContainer = new FormattedString();
                stringContainer.Spans.Add(new Span { Text = "Lease Type: ", FontAttributes = FontAttributes.Bold, FontSize = 9 });
                stringContainer.Spans.Add(new Span { Text = suites[i].LeaseRateType.ToString() });
                lbl_SuiteLeaseType.FormattedText = stringContainer;
                Label lbl_SuiteFloor = new Label() { FontSize = 9, Margin = new Thickness(10, 0, 0, 0) };
                stringContainer = new FormattedString();
                stringContainer.Spans.Add(new Span { Text = "Floor: ", FontAttributes = FontAttributes.Bold, FontSize = 9 });
                stringContainer.Spans.Add(new Span { Text = suites[i].FloorNumber.ToString() });
                lbl_SuiteFloor.FormattedText = stringContainer;

                StackLayout sl_SuiteInfo = new StackLayout()
                {

                };

                //assemble suites information
                sl_SuiteInfo.Children.Add(btn_SuiteNumber);
                sl_SuiteInfo.Children.Add(img_SuiteImage);
                sl_SuiteInfo.Children.Add(lbl_SuiteSize);
                sl_SuiteInfo.Children.Add(lbl_SuiteVacancy);
                sl_SuiteInfo.Children.Add(lbl_SuiteLeaseRate);
                sl_SuiteInfo.Children.Add(lbl_SuiteLeaseType);
                sl_SuiteInfo.Children.Add(lbl_SuiteFloor);

                if (i % 2 == 0)
                {
                    columnAssignment = 0;
                    rowAssignment = i / 2;
                }
                else
                {
                    columnAssignment = 1;
                    rowAssignment = i / 2;
                }

                //assign individual suites stacklayout to frame
                frm_SuiteDetail.Content = sl_SuiteInfo;
                //add individual suites frame to suites grid (ready to add to overall page)
                grd_Suites.Children.Add(frm_SuiteDetail, columnAssignment, rowAssignment);
            }
            //end Suites

            Label lbl_SalePriceTitle = new Label() { Text = "Sale Price", FontSize = 12 };
            Label lbl_SaleTypeTitle = new Label() { Text = "Sale Type", FontSize = 12 };
            Label lbl_AvailableSquareFootageTitle = new Label() { Text = "Available SF", FontSize = 12 };
            Label lbl_SaleSquareFootageTitle = new Label() { Text = "Sale $/SF", FontSize = 12 };
            Label lbl_CapRateTitle = new Label() { Text = "Cap Rate", FontSize = 12 };
            Label lbl_NetOperatingIncomeTitle = new Label() { Text = "NOI", FontSize = 12 };

            Label lbl_SalePriceDetail = new Label() { Text = "$102,000,000", FontSize = 12 };
            Label lbl_SaleTypeDetail = new Label() { Text = "Investment", FontSize = 12 };
            Label lbl_AvailableSquareFootageDetail = new Label() { Text = "1,021,625", FontSize = 12 };
            Label lbl_SaleSquareFootageDetail = new Label() { Text = "$532.25", FontSize = 12 };
            Label lbl_CapRateDetail = new Label() { Text = "5.5%", FontSize = 12 };
            Label lbl_NetOperatingIncomeDetail = new Label() { Text = "6,250,000", FontSize = 12 };

            //Add(column, colspan, row, rowspan)  
            //Add(left, right, top, bottom) 
            //where column = left, colspan = right - left, row = top, rowspan = top - bottom
            grd_SalesDetail.Children.Add(lbl_SalePriceTitle, 0, 1, 0, 1);
            grd_SalesDetail.Children.Add(lbl_SalePriceDetail, 1, 2, 0, 1);
            grd_SalesDetail.Children.Add(lbl_SaleTypeTitle, 0, 1, 1, 2);
            grd_SalesDetail.Children.Add(lbl_SaleTypeDetail, 1, 2, 1, 2);
            grd_SalesDetail.Children.Add(lbl_AvailableSquareFootageTitle, 0, 1, 2, 3);
            grd_SalesDetail.Children.Add(lbl_AvailableSquareFootageDetail, 1, 2, 2, 3);
            grd_SalesDetail.Children.Add(lbl_SaleSquareFootageTitle, 0, 1, 3, 4);
            grd_SalesDetail.Children.Add(lbl_SaleSquareFootageDetail, 1, 2, 3, 4);
            grd_SalesDetail.Children.Add(lbl_CapRateTitle, 0, 1, 4, 5);
            grd_SalesDetail.Children.Add(lbl_CapRateDetail, 1, 2, 4, 5);
            grd_SalesDetail.Children.Add(lbl_NetOperatingIncomeTitle, 0, 1, 5, 6);
            grd_SalesDetail.Children.Add(lbl_NetOperatingIncomeDetail, 1, 2, 5, 6);

            frm_SalesDetail.Content = grd_SalesDetail;

            //Add controls to main page layout
            sl_details.Children.Add(img_mainImage);
            sl_details.Children.Add(sv_images);
            sl_details.Children.Add(detailControls.bv_Spacer);
            sl_details.Children.Add(lbl_SaleDetailTitle);
            sl_details.Children.Add(frm_SalesDetail);
            sl_details.Children.Add(detailControls.bv_Spacer);
            sl_details.Children.Add(lbl_CommentsTitle);
            sl_details.Children.Add(frm_ListingComments);
            sl_details.Children.Add(detailControls.bv_Spacer);
            sl_details.Children.Add(lbl_SuitesTitle);
            sl_details.Children.Add(grd_Suites);
            sl_details.Children.Add(detailControls.bv_Spacer);
            sl_details.Children.Add(lbl_AttachmentsTitle);
            sl_details.Children.Add(detailControls.bv_Spacer);
            sl_details.Children.Add(lbl_PropertyLocationTitle);
            sl_details.Children.Add(detailControls.bv_Spacer);
            sl_details.Children.Add(lbl_ListingRepsTitle);

            sv_details.Content = sl_details;

            detailControls.sl_MainWrapper.Children.Insert(1, sv_details);
        }

        private void Btn_SuiteNumber_Clicked(object sender, EventArgs e)
        {
            int suiteId = (int)(((Button)sender).CommandParameter);

            Navigation.PushAsync(new SuiteDetail(suiteId));

        }


        /// <summary>
        /// Sets the listing display strategy based on property listing type
        /// </summary>
        /// <param name="listing"></param>
        private void SetListingStrategy(Listing listing)
        {
            switch (listing.ListingType)
            {
                case PropertyType.Office:
                    selectedListingType = new OfficeListingDetails();
                    break;
                case PropertyType.Industrial:
                    selectedListingType = new IndustrialListingDetails();
                    break;
                case PropertyType.Retail:
                    selectedListingType = new RetailListingDetails();
                    break;
                case PropertyType.Multifamily:
                    selectedListingType = new MultifamilyListingDetails();
                    break;
                case PropertyType.Land:
                    selectedListingType = new LandListingDetails();
                    break;
                case PropertyType.SpecialUse:
                    selectedListingType = new SpecialUseListingDetails();
                    break;
                default:
                    selectedListingType = new OfficeListingDetails();
                    break;
            }
        }

    }
}
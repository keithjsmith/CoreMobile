using CoREMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(CoREMobile.Services.MockListingDataStore))]
namespace CoREMobile.Services
{
    class MockListingDataStore : IDataStore<Listing>
    {
        bool isInitialized;
        List<Listing> listings;
        public Task<bool> AddItemAsync(Listing item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(Listing item)
        {
            throw new NotImplementedException();
        }

        public Task<Listing> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Listing>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(listings);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            listings = new List<Listing>
            {
                new Listing { Id = Guid.NewGuid().ToString(), ListingType = PropertyType.Office, ListingNotes = "Buy some, get some", DisplayAddress = "1438 University Blvd",
                    ListingStatusId = 1, SaleTypeId = 2, DisplayListingStatus = "", DisplaySaleType = "For Lease | 2 Spaces Available", DisplayLeaseType="$29.00/SF FSG",
                    ListingImageUrl ="http://res.cloudinary.com/xceligent/image/upload/t_XCPermOverlay/s3uat/WaterMarked/170/7383170"},
                new Listing { Id = Guid.NewGuid().ToString(), ListingType = PropertyType.Industrial, ListingNotes = "Learn F# like a boss", DisplayAddress = "200 S Orange Ave",
                    ListingStatusId = 1, SaleTypeId = 2, DisplayListingStatus = "", DisplaySaleType = "For Lease | 5 Spaces Available", DisplayLeaseType="$34.00/SF FSG",
                    ListingImageUrl ="http://res.cloudinary.com/xceligent/image/upload/t_XCPermOverlay/s3uat/WaterMarked/186/6400186"},
                new Listing { Id = Guid.NewGuid().ToString(), ListingType = PropertyType.Land, ListingNotes = "Learn to play guitar", DisplayAddress = "534 Main St",
                    ListingStatusId = 1, SaleTypeId = 2, DisplayListingStatus = "", DisplaySaleType = "For Sale", DisplayLeaseType="$1,204,400 ($198/SF) Neg",
                    ListingImageUrl ="http://res.cloudinary.com/xceligent/image/upload/t_XCPermOverlay/s3uat/WaterMarked/170/7383170"},
                new Listing { Id = Guid.NewGuid().ToString(), ListingType = PropertyType.Multifamily, ListingNotes = "Learn to play guitar", DisplayAddress = "534 Main St",
                    ListingStatusId = 1, SaleTypeId = 2, DisplayListingStatus = "", DisplaySaleType = "For Sale", DisplayLeaseType="$1,204,400 ($198/SF) Neg",
                    ListingImageUrl ="http://res.cloudinary.com/xceligent/image/upload/t_XCPermOverlay/s3uat/WaterMarked/170/7383170"},
                new Listing { Id = Guid.NewGuid().ToString(), ListingType = PropertyType.Retail, ListingNotes = "Learn F# like a boss", DisplayAddress = "200 S Orange Ave",
                    ListingStatusId = 1, SaleTypeId = 2, DisplayListingStatus = "", DisplaySaleType = "For Lease | 5 Spaces Available", DisplayLeaseType="$34.00/SF FSG",
                    ListingImageUrl ="http://res.cloudinary.com/xceligent/image/upload/t_XCPermOverlay/s3uat/WaterMarked/186/6400186"},
                new Listing { Id = Guid.NewGuid().ToString(), ListingType = PropertyType.SpecialUse, ListingNotes = "Buy some new candles", DisplayAddress = "1438 University Blvd",
                    ListingStatusId = 1, SaleTypeId = 2, DisplayListingStatus = "", DisplaySaleType = "For Lease | 2 Spaces Available", DisplayLeaseType="$29.00/SF FSG",
                    ListingImageUrl ="http://res.cloudinary.com/dld5vogjt/image/upload/h_810,w_1080/v1508426223/13641000_sxidcw.jpg"},
                new Listing { Id = Guid.NewGuid().ToString(), ListingType = PropertyType.Office, ListingNotes = "Complete holiday shopping", DisplayAddress = "200 S Orange Ave",
                    ListingStatusId = 1, SaleTypeId = 2, DisplayListingStatus = "", DisplaySaleType = "For Lease | 5 Spaces Available", DisplayLeaseType="$34.00/SF FSG"},
                new Listing { Id = Guid.NewGuid().ToString(), ListingType = PropertyType.Office, ListingNotes = "Finish a todo list", DisplayAddress = "534 Main St",
                    ListingStatusId = 1, SaleTypeId = 2, DisplayListingStatus = "", DisplaySaleType = "For Sale", DisplayLeaseType="$1,204,400 ($198/SF) Neg"},
            };

            isInitialized = true;
        }

        public Task<bool> PullLatestAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SyncAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Listing item)
        {
            throw new NotImplementedException();
        }
    }
}

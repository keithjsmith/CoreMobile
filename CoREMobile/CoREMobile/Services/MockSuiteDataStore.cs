using CoREMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(CoREMobile.Services.MockSuiteDataStore))]
namespace CoREMobile.Services
{
    class MockSuiteDataStore : IDataStore<Space>
    {
        bool isInitialized;
        List<Space> suites;

        public Task<bool> AddItemAsync(Space item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(Space item)
        {
            throw new NotImplementedException();
        }

        public async Task<Space> GetItemAsync(int id)
        {
            //Space suiteById = suites.Find(x => x.SuiteNumber == id);
            //return await Task.FromResult(GetSuiteByID(id));

            return await Task.FromResult(suites.FirstOrDefault(s => s.SuiteNumber == id));
        }

        public async Task<IEnumerable<Space>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();
            return await Task.FromResult(suites);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            suites = new List<Space>
            {
                 new Space
            {
                SpaceId = 1,
                AvailableSF = 13999,
                ExpensesPerSF = 15.00m,
                SuiteNumber = 1,
                SpaceImageUrl = "http://res.cloudinary.com/dld5vogjt/image/upload/v1508426269/13832000_zsvix1.jpg",
                Type = SpaceType.Industrial,
                Vacant = true,
                LeaseRateLow = 22.00m,
                LeaseRateHigh = 24.00m,
                LeaseRateType = LeaseType.Fullservice,
                FloorNumber = 2
            },
            new Space
            {
                SpaceId = 2,
                AvailableSF = 6038,
                ExpensesPerSF = 22.00m,
                SuiteNumber = 2,
                SpaceImageUrl = "http://res.cloudinary.com/dld5vogjt/image/upload/v1508426269/13832000_zsvix1.jpg",
                Type = SpaceType.Office,
                Vacant = true,
                LeaseRateLow = 18.00m,
                LeaseRateHigh = 20.00m,
                LeaseRateType = LeaseType.DoubleNet,
                FloorNumber = 4
            },
            new Space
            {
                SpaceId = 3,
                AvailableSF = 13999,
                ExpensesPerSF = 15.00m,
                SuiteNumber = 3,
                SpaceImageUrl = "http://res.cloudinary.com/dld5vogjt/image/upload/v1508426269/13832000_zsvix1.jpg",
                Type = SpaceType.Retail,
                Vacant = false,
                LeaseRateLow = 11.00m,
                LeaseRateHigh = 15.00m,
                LeaseRateType = LeaseType.Net,
                FloorNumber = 21
            },
            new Space
            {
                SpaceId = 4,
                AvailableSF = 6038,
                ExpensesPerSF = 22.00m,
                SuiteNumber = 4,
                SpaceImageUrl = "http://res.cloudinary.com/dld5vogjt/image/upload/v1508426269/13832000_zsvix1.jpg",
                Type = SpaceType.Industrial,
                Vacant = true,
                LeaseRateLow = 26.00m,
                LeaseRateHigh = 29.00m,
                LeaseRateType = LeaseType.ModifiedGross,
                FloorNumber = 30
            },
            new Space
            {
                SpaceId = 5,
                AvailableSF = 6038,
                ExpensesPerSF = 22.00m,
                SuiteNumber = 5,
                SpaceImageUrl = "http://res.cloudinary.com/dld5vogjt/image/upload/v1508426269/13832000_zsvix1.jpg",
                Type = SpaceType.Industrial,
                Vacant = false,
                LeaseRateLow = 8.00m,
                LeaseRateHigh = 17.00m,
                LeaseRateType = LeaseType.TripleNet,
                FloorNumber = 11
            }

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

        public Task<bool> UpdateItemAsync(Space item)
        {
            throw new NotImplementedException();
        }
    }
}

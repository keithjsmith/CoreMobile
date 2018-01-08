using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoREMobile.Models
{
    public class Listing : BaseDataObject
    {
        public int LeaseType { get; set; }
        public string ListingNotes { get; set; }
        public List<string> Agents { get; set; }
        public PropertyType ListingType { get; set; }
        public int SaleTypeId { get; set; }
        public int ListingStatusId { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CapRate { get; set; }
        public int AvailableSF { get; set; }
        public decimal NetOperatingIncome { get; set; }
        public string DisplayAddress { get; set; }
        public string DisplaySaleType { get; set; }
        public string DisplayListingStatus { get; set; }
        public string DisplayLeaseType { get; set; }
        public string ListingImageUrl { get; set; }
        public List<Space> Suites { get; set; }

    }
}

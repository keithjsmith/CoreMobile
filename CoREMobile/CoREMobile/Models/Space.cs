using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoREMobile.Models
{
    public class Space : BaseDataObject
    {
        public int SpaceId { get; set; }
        public int AvailableSF { get; set; }
        public int MinDivisibleSF { get; set; }
        public int MaxContiguousSF { get; set; }
        public decimal LeaseRateLow { get; set; }
        public decimal LeaseRateHigh { get; set; }
        public LeaseType LeaseRateType { get; set; }
        public decimal ExpensesPerSF { get; set; }
        public string Availability { get; set; }
        public DateTime AvailabilityDate { get; set; }
        public double ClearHeightMin { get; set; }
        public double ClearHeightMax { get; set; }
        public int SpaceStatus { get; set; }
        public int DockDoors { get; set; }
        public int GradeDoors { get; set; }
        public int SuiteNumber { get; set; }
        public int FloorNumber { get; set; }
        public SpaceType Type { get; set; }
        public string SpaceImageUrl { get; set; }
        public bool Vacant { get; set; }


    }
}

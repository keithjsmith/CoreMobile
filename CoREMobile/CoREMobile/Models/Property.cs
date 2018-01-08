using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoREMobile.Models
{
    public class Property : BaseDataObject
    {
        public int PropertyId { get; set; }
        public PropertyType PropertyType { get; set; }
        public int PropertySubType { get; set; }
        public double BuildingSize { get; set; }
        public int BuildingClass { get; set; }
        public string PropertyName { get; set; }
        public int YearBuilt { get; set; }
        public double LotSize { get; set; }
        public double ClearHeightMin { get; set; }
        public double ClearHeightMax { get; set; }
        public bool Sprinkler { get; set; }
        public int ConstructionStatus { get; set; }
        public int StoriesCount { get; set; }
        public double ParkingRatio { get; set; }
        public int ParkingSpacesCount { get; set; }
        public int UnitsCount { get; set; }
    }
}

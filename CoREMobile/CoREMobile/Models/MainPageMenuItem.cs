using CoREMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoREMobile.ViewModels;

namespace CoREMobile
{

    public class MainPageMenuItem
    {
        public MainPageMenuItem()
        {
            //TargetType = typeof(MainPageDetail);
            TargetType = typeof(ListingSummary);
            
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleHeader { get; set; }

        public Type TargetType { get; set; }
    }
}
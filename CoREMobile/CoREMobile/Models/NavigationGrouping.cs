using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoREMobile
{
    public class NavigationGrouping : List<MainPageMenuItem>
    {
        public string Title { get; set; }
        public string ShortName { get; set; } //will be used for jump lists
        public string Subtitle { get; set; }
        public NavigationGrouping(string title, string shortName)
        {
            Title = title;
            ShortName = shortName;
        }

        public IList<MainPageMenuItem> All { set; get; }
    }

}

using System;
using System.Collections.Generic;
namespace GM.Web.Models
{
    public class HorizontalNavBar{
        public IEnumerable<MenuItem> MenuItems { get; set; }
    }

    public class MenuItem {

        public MenuItem(Uri url, bool isSelected = false) {
            Url = url;
            IsSelected = isSelected;
        }

        public Uri Url { get; set; }
        public bool IsSelected { get; set; }
    }
}

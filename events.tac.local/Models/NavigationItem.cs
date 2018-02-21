using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events.tac.local.Models
{
    public class NavigationItem
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public bool Active { get; set; }

        public NavigationItem(string title, string url, bool active)
        {
            Title = title;
            URL = url;
            Active = active;
        }
    }
}
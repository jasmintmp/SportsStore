using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class PagingInfo
    {
       
        public int TotalItemsInCategory { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPagesInCategory { get { return (int)Math.Ceiling((decimal)TotalItemsInCategory / ItemsPerPage); } }

    }
}
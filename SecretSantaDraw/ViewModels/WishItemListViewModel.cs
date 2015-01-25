using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SecretSantaDraw.Models;

namespace SecretSantaDraw.ViewModels
{
    public class WishItemListViewModel
    {
        public int ProfileId { get; set; }
        
        public string ProfileDisplayName { get; set; }
        
        public IEnumerable<WishItem> WishList { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiskCommerce.Service.ViewModels
{
    public class BasketViewModel
    {
        public Guid BuyerId { get; set; }
        public List<BasketViewItemModel> BasketItems { get; set; }
}
}

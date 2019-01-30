using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiskCommerce.Service.ViewModels
{
    public class BasketViewItemModel
    {
        public Guid DiskId { get; set; }
        public int Units { get; set; }
    }
}

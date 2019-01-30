using System;
using System.Collections.Generic;
using System.Text;

namespace DiskCommerce.Domain.Entities
{
    public class BasketItem
    {
        public BasketItem(Disk disk, int unit)
        {
            Disk = disk;
            Unit = unit;
        }

        public Disk Disk { get; private set; }
        public int Unit { get; private set; }
    }
}

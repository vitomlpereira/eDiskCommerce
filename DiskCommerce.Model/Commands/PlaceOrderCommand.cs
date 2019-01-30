using DiskCommerce.Commom.Publisher;
using System;
using System.Collections.Generic;

namespace DiskCommerce.Domain.Commands
{
    public class PlaceOrderCommand: Command
    {
        public PlaceOrderCommand(Guid buyerId, Dictionary<Guid,int> basketItems)
        {
            BuyerId = buyerId;
            this.basketItems = basketItems;
        }

        public Guid BuyerId { get; set; }
        public Dictionary<Guid, int> basketItems { get; set; }


        public override bool IsValid()
        {
            return new PlaceOrderCommandValidation().Validate(this).IsValid;
        }
    }
}

using DiskCommerce.Commom.Pagging;
using DiskCommerce.Domain.Entities.BuyerAggregate;
using System;

namespace DiskCommerce.Domain.Interfaces
{
    public interface IBuyerRepository
    {
        Buyer GetBuyer(Guid id);
        PagedResult<Buyer> GetPagged(int actualPage, int pageSize);
    }
}

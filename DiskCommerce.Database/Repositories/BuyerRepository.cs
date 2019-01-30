using System;
using System.Collections.Generic;
using System.Linq;
using DiskCommerce.Commom.Pagging;
using DiskCommerce.Database.Context;
using DiskCommerce.Domain.Entities;
using DiskCommerce.Domain.Entities.BuyerAggregate;
using DiskCommerce.Domain.Enumerators;
using DiskCommerce.Domain.Interfaces;

namespace DiskCommerce.Database.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly DiskEcommerceContext _context;

        public BuyerRepository(DiskEcommerceContext context)
        {
            _context = context;
        }

        public Buyer GetBuyer(Guid id)
        {
            return _context.Buyers.Find(id);
        }

        public PagedResult<Buyer> GetPagged(int actualPage, int pageSize)
        {
            return _context.Buyers.GetPaged(actualPage, pageSize);

        }
    }
}
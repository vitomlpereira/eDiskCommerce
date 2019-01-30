using System;
using System.Collections.Generic;
using System.Linq;
using DiskCommerce.Commom.Pagging;
using DiskCommerce.Database.Context;
using DiskCommerce.Domain.Entities;
using DiskCommerce.Domain.Entities.OrderAggregate;
using DiskCommerce.Domain.Enumerators;
using DiskCommerce.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiskCommerce.Database.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DiskEcommerceContext _context;

        public OrderRepository(DiskEcommerceContext context)
        {
            _context = context;
        }

        public Order Get(Guid id)
        {
            return _context.Orders
                           .Include(x => x.OrderItems)
                           .Include(x => x.Buyer)
                           .Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }
       

        public PagedResult<Order> GetPagged(int actualPage, int pageSize, DateTime begin, DateTime end)
        {
            return _context.Orders
                  .Include(x => x.OrderItems)
                  .Include(x => x.Buyer).Where(o=>o.OrderDate>= begin && o.OrderDate<= end)
                  .GetPaged(actualPage, pageSize);
            
        }

        public void PlaceOrder(Order order)
        {
            _context.Orders.Add(order);
        }
    }
}

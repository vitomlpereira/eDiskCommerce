using DiskCommerce.Database.Context;
using DiskCommerce.Domain.Interfaces;

namespace DiskCommerce.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DiskEcommerceContext _context;

        public UnitOfWork(DiskEcommerceContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using DiskCommerce.Commom.Pagging;
using DiskCommerce.Database.Context;
using DiskCommerce.Domain.Entities;
using DiskCommerce.Domain.Enumerators;
using DiskCommerce.Domain.Interfaces;

namespace DiskCommerce.Database.Repositories
{
    public class ReadOnlyDiskCollection : IDiskReadRepositoy
    {
        private readonly DiskEcommerceContext _context;

        public ReadOnlyDiskCollection(DiskEcommerceContext context)
        {
            _context = context;
        }

         public PagedResult<Disk> GetPagged(int actualPage, int pageSize, DiskGenreEnum genre)
        {
            return _context.Disks
                  .Where(d=>d.Genre == genre)
                  .OrderBy(d=>d.Name)
                  .GetPaged(actualPage, pageSize);

        }

        public Disk Get(Guid id)
        {
            return _context.Disks.Find(id);
        }
    }
}

using DiskCommerce.Commom.Pagging;
using DiskCommerce.Domain.Entities;
using DiskCommerce.Domain.Enumerators;
using System;
using System.Collections.Generic;

namespace DiskCommerce.Domain.Interfaces
{
    public interface IDiskReadRepositoy
    {
        Disk Get(Guid id);
        PagedResult<Disk> GetPagged(int actualPage, int pageSize, DiskGenreEnum genre);
    }
}

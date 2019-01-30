using System;
using System.Collections.Generic;
using System.Text;

namespace DiskCommerce.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}

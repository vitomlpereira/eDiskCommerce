using System;
using DiskCommerce.Domain.Enumerators;

namespace DiskCommerce.Domain.Interfaces
{
    public interface ICashBackConfigurationService
    {
        decimal GetPercentage(DiskGenreEnum genre, DateTime date);
    }
}
using DiskCommerce.Domain.Enumerators;
using DiskCommerce.Domain.Interfaces;
using System;

namespace DiskCommerce.Domain.Services
{
    public class CashBackConfigurationService : ICashBackConfigurationService
    {
        public decimal GetPercentage(DiskGenreEnum genre, DateTime date)
        {
            return 30;   
        }
    }
}

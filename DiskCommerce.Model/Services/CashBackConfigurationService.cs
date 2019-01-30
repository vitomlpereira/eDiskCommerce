using DiskCommerce.Domain.Enumerators;
using DiskCommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace DiskCommerce.Domain.Services
{
    public class CashBackConfigurationService : ICashBackConfigurationService
    {
        public decimal GetPercentage(DiskGenreEnum genre, DateTime date)
        {
            switch (genre)
            {
                case DiskGenreEnum.POP:
                    return GetPOPPercentage().GetValueOrDefault(date.DayOfWeek);
                case DiskGenreEnum.MPB:
                    return GetMPBPercentage().GetValueOrDefault(date.DayOfWeek);
                case DiskGenreEnum.CLASSIC:
                    return GetClassicPercentage().GetValueOrDefault(date.DayOfWeek);
                case DiskGenreEnum.ROCK:
                    return GetRockPercentage().GetValueOrDefault(date.DayOfWeek);
                default:
                    throw new Exception("Cannot get cashback percentage because genre is out of range");
            }
        }

        public Dictionary<DayOfWeek, Decimal> GetPOPPercentage()
        {
            var percentage = new Dictionary<DayOfWeek, decimal>();
            percentage.Add(DayOfWeek.Sunday, 25);
            percentage.Add(DayOfWeek.Monday, 7);
            percentage.Add(DayOfWeek.Tuesday, 6);
            percentage.Add(DayOfWeek.Wednesday, 2);
            percentage.Add(DayOfWeek.Thursday, 10);
            percentage.Add(DayOfWeek.Friday, 15);
            percentage.Add(DayOfWeek.Saturday, 20);
            return percentage;
        }

        public Dictionary<DayOfWeek, Decimal> GetMPBPercentage()
        {
            var percentage = new Dictionary<DayOfWeek, decimal>();
            percentage.Add(DayOfWeek.Sunday, 30);
            percentage.Add(DayOfWeek.Monday, 5);
            percentage.Add(DayOfWeek.Tuesday, 10);
            percentage.Add(DayOfWeek.Wednesday, 15);
            percentage.Add(DayOfWeek.Thursday, 20);
            percentage.Add(DayOfWeek.Friday, 25);
            percentage.Add(DayOfWeek.Saturday, 30);
            return percentage;
        }

        public Dictionary<DayOfWeek, Decimal> GetClassicPercentage()
        {
            var percentage = new Dictionary<DayOfWeek, decimal>();
            percentage.Add(DayOfWeek.Sunday, 35);
            percentage.Add(DayOfWeek.Monday, 3);
            percentage.Add(DayOfWeek.Tuesday,5);
            percentage.Add(DayOfWeek.Wednesday, 8);
            percentage.Add(DayOfWeek.Thursday, 13);
            percentage.Add(DayOfWeek.Friday, 18);
            percentage.Add(DayOfWeek.Saturday, 25);
            return percentage;
        }

        public Dictionary<DayOfWeek, Decimal> GetRockPercentage()
        {
            var percentage = new Dictionary<DayOfWeek, decimal>();
            percentage.Add(DayOfWeek.Sunday, 40);
            percentage.Add(DayOfWeek.Monday, 10);
            percentage.Add(DayOfWeek.Tuesday, 15);
            percentage.Add(DayOfWeek.Wednesday, 15);
            percentage.Add(DayOfWeek.Thursday, 15);
            percentage.Add(DayOfWeek.Friday, 20);
            percentage.Add(DayOfWeek.Saturday, 40);
            return percentage;
        }

    }
}

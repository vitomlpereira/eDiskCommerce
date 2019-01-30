using DiskCommerce.Database.Context;
using DiskCommerce.Domain.Entities;
using DiskCommerce.Domain.Entities.BuyerAggregate;
using DiskCommerce.Domain.Interfaces;
using DiskCommerce.Infrastructure.ExternalServices.SpotifyService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace DiskCommerce.Service.Seed
{
    public static class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {

            DiskEcommerceContext context = serviceProvider.GetRequiredService<DiskEcommerceContext>();
            SpotifyService spotifyService =(SpotifyService)serviceProvider.GetRequiredService<ISpotifyService>();

            List<Disk> disks = spotifyService.Get50AlbumsForEachGenre();

            foreach(var disk in disks)
            {
                context.Add(disk);
                context.SaveChanges();
            }


            context.Buyers.Add(new Buyer(Guid.Parse("6BF51D86-C0C2-4C91-988F-7CFE1A236587"),"Buyer Test 1"));
            context.Buyers.Add(new Buyer(Guid.Parse("29FEAC38-64E0-44CA-83FB-E9837AEAE110"),"Buyer Test 2"));
            context.SaveChanges();
        }

        
    }
}

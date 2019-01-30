using System.Collections.Generic;
using DiskCommerce.Domain.Entities;

namespace DiskCommerce.Domain.Interfaces
{
    public interface ISpotifyService
    {
        List<Disk> Get50AlbumsForEachGenre();
    }
}
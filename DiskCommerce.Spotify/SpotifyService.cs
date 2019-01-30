using DiskCommerce.Domain.Entities;
using DiskCommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web;
using DiskCommerce.Domain.Enumerators;

namespace DiskCommerce.Infrastructure.ExternalServices.SpotifyService
{
    public class SpotifyService : ISpotifyService
    {
        public List<Disk> Get50AlbumsForEachGenre()
        {
            CredentialsAuth auth = new CredentialsAuth(SpotifyServiceConfig.CLIENTID , SpotifyServiceConfig.SECRET);
            Token token = auth.GetToken().Result;
            SpotifyWebAPI api = new SpotifyWebAPI() { TokenType = token.TokenType, AccessToken = token.AccessToken };

            var genres = Enum.GetValues(typeof(DiskGenreEnum));

            List<Disk> disks = new List<Disk>();

            foreach (var genre in genres)
            {
                SearchItem search = api.SearchItems(genre.ToString(), SearchType.Album, 50);

                foreach (var spotifyDisk in search.Albums.Items)
                {
                    disks.Add(new Disk(spotifyDisk.Name, "Desk", 10 , (DiskGenreEnum) genre));
                }

            }

            return disks;
        }
    }
}

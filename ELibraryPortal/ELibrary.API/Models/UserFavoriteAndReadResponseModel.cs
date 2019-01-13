using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models
{
    public class UserFavoriteAndReadResponseModel
    {
        public Guid UserId { get; set; }
        public List<UserFavoriteAndReadModel> Reads { get; set; }
        public List<UserFavoriteAndReadModel> Favorites { get; set; }
    }
}

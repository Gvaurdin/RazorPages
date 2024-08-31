using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class MovieStorage
    {
        public static List<Movie> movies =
            [
             new()
             {
                 Id = 1,
                 Title = "Stalker",
                 URL = "https://pic.rutubelist.ru/video/8f/1f/8f1f81ca76024419a8ab6e22f943694b.jpg",
                 Description = "Not for everyone",
                 //Cost = 200,
                 Duration = TimeSpan.FromMinutes(185)
             },
            new()
            {
                 Id = 2,
                 Title = "Once upon a Time in Hollywood",
                 URL = "https://ic.pics.livejournal.com/sirgenry/21440675/181755/181755_original.jpg",
                 Description = "A good movie for a one-time viewing",
                 //Cost = 350
                 Duration = TimeSpan.FromMinutes(168)
            }
            ];


    }
}

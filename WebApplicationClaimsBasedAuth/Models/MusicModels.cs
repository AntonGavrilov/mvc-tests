using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationClaimsBasedAuth.Models
{
    public class Track
    {
        public Artist Artist { get; set; }

        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        
    }

    public class Artist
    {
        public string Name { get; set; }

        public string MusicStyle { get; set; }

    }

    public class Album
    {
        public List<Track> TrackList { get; set; } 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingContent_Inheritance
{
    public class Show : StreamingContent
    {
        public int SeasonCount { get; set; }
        public int EpisodeCount { get; set; }
        public double AverageRunTime { get; set; }
        public DateTime AirDate { get; set; }

        public List<Episode> Episodes { get; set; } = new List<Episode>();
        //Coming Soon! Episode 
    }

    public class Episode
    {
        public string Title { get; set; }
        public int SeasonNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double RunTime { get; set; }
    }
}

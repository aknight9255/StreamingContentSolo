using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingContent_Inheritance
{
    public enum MaturityRating
    {
        G,
        PG,
        PG_13,
        R,
        NC_17,
        TV_G,
        TV_MA
    }
    public class StreamingContent
    {
        //Properties
        public string Title { get; set; }
        public string Description { get; set; }
        public int StarRating { get; set; }
        public bool IsFamilyFriendly
        {
            get
            {
                switch (TypeOfMaturityRating)
                {
                    case MaturityRating.G:
                    case MaturityRating.PG:
                    case MaturityRating.TV_G:
                        return true;
                    case MaturityRating.PG_13:
                    case MaturityRating.R:
                    case MaturityRating.NC_17:
                    case MaturityRating.TV_MA:
                    default:
                        return false;
                }
            }
        }
        public string Genre { get; set; }
        public MaturityRating TypeOfMaturityRating { get; set; }

        ////Constructor Empty
        public StreamingContent() { }
        // Constructor Full
        public StreamingContent(string title, string desc, int starRating, string genre, MaturityRating typeOfMaturity)
        {
            Title = title;
            Description = desc;
            StarRating = starRating;
            Genre = genre;
            TypeOfMaturityRating = typeOfMaturity;
        }
    }
}

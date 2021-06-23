using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingContent_Inheritance
{
    public class Movie : StreamingContent
    {
        public double RunTime { get; set; }
        public Movie() { }
        public Movie(string title,string desc,int starRating,string genre, MaturityRating maturityRating,double runTime)
            : base(title,desc,starRating,genre,maturityRating)
        {
            RunTime = runTime;
        }
    }
}

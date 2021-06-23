using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingContent_Inheritance
{
    public class Movie_Show_Repo : StreamingContentRepository
    {
        public Show GetShowByTitle(string title)
        {
            foreach(StreamingContent content in _contentDirectory)
            {
                if(content.Title.ToLower()==title.ToLower() && content.GetType() == typeof(Show))
                {
                    return (Show)content;
                }
            }
            return null;
        }

        //GETMOVIEBYTITLE 

        public List<Show> GetAllShows()
        {
            List<Show> allShows = new List<Show>();
            foreach(StreamingContent content in _contentDirectory)
            {
                if(content is Show)
                {
                    allShows.Add((Show)content);
                }
            }
            return allShows;
        }

        //GETALLMOVIES

        // Get by other parameters
        // Get by RunTime/AverageRunTime
        // Get Shows with over x episodes
        // Get Shows/Movie By Rating

    }
}

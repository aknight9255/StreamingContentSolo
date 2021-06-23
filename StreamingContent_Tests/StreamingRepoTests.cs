using Microsoft.VisualStudio.TestTools.UnitTesting;
using StreamingContent_Inheritance;
using System;

namespace StreamingContent_Tests
{
    [TestClass]
    public class StreamingRepoTests
    {
        [TestMethod]
        public void StreamingContentNotes()
        {
            StreamingContent baseObject = new StreamingContent();
            Movie movieObject = new Movie();
            Show showObject = new Show();
            baseObject.Title = "This is a test object";
            movieObject.Title = "Harry Potter";
            Movie_Show_Repo repo = new Movie_Show_Repo();
            repo.AddContentToDirectory(baseObject);
            repo.AddContentToDirectory(movieObject);
            repo.AddContentToDirectory(showObject);

            showObject.Title = "Manifest";
            Show objectTwo = new Show();
            Show objectThree = new Show();
            objectTwo.Title = "Discovery Of Witches";
            objectThree.Title = "American Horror Story";
            repo.AddContentToDirectory(objectTwo);
            repo.AddContentToDirectory(objectThree);
            //VAR???????
            var getByTitleTest = repo.GetContentByTitle("Manifest");

            //getByTitleTest.EpisodeTest = 110;




            Episode oneEpisode = new Episode();
            showObject.Episodes.Add(oneEpisode);
            showObject.Episodes.Add(oneEpisode);
            showObject.Episodes.Add(oneEpisode);
            showObject.Episodes.Add(oneEpisode);
            showObject.Episodes.Add(oneEpisode);
            showObject.Episodes.Add(oneEpisode);
            var getByShowTest = repo.GetShowByTitle("Manifest");
            getByShowTest.EpisodeCount = 10;


        }
    }
}

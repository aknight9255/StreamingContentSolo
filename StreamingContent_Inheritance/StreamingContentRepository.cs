using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingContent_Inheritance
{
    public class StreamingContentRepository
    {
        //FakeDatabase 
        protected readonly List<StreamingContent> _contentDirectory = new List<StreamingContent>();
        //CRUD
        //CREATE 
        public bool AddContentToDirectory(StreamingContent newContent)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(newContent);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //READ
        public List<StreamingContent> GetContents()
        {
            return _contentDirectory;
        }
        public StreamingContent GetContentByTitle(string title)
        {
            //get the directory 
            //sort through all the items using title to find a match
            foreach (StreamingContent content in _contentDirectory)
            {
                if (content.Title.ToLower() == title.ToLower())
                {
                    return content;
                }
            }
            return null;
            //I want to return streaming content that matches the title 
        }

        //UPDATE
        public bool UpdateExistingContent(string originalTitle, StreamingContent newContent)
        {
            StreamingContent oldContent = GetContentByTitle(originalTitle);
            if (oldContent != null)
            {
                oldContent.Title = newContent.Title;
                oldContent.Description = newContent.Description;
                oldContent.StarRating = newContent.StarRating;
                oldContent.Genre = newContent.Genre;
                oldContent.TypeOfMaturityRating = newContent.TypeOfMaturityRating;
                return true;
            }
            else
            {
                return false;
            }
        }
        //DELETE
        public bool DeleteExistingContent(StreamingContent existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}

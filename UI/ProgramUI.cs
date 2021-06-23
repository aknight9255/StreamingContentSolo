using StreamingContent_Inheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class ProgramUI
    {

        protected readonly Movie_Show_Repo _streamingRepo = new Movie_Show_Repo();

        //This is the method that runs our User Interface
        public void Run()
        {
            //Putting in seed data to have some starting data
            SeedContentList();

            DisplayMenu();
        }

        private void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                //Writes to the Console
                Console.WriteLine(
                    "Enter the number of the option you would like to select: \n" +
                    "1. Show all streaming content \n" +
                    "2. Find streaming content by title \n" +
                    "3. Add new streaming content\n" +
                    "4. Remove streaming content \n" +
                    "5. Update content\n" +
                    "6. Exit\n");

                //Reading user input
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllContent();
                        //Show all streaming content
                        break;
                    case "2":
                        //Find streaming content by title
                        GetContentByTitle();
                        break;
                    case "3":
                        //Add new streaming content
                        CreateNewContent();
                        break;
                    case "4":
                        //Remove streaming content
                        DeleteContent();
                        break;
                    case "5":
                        UpdateContent();
                        //Update content
                        break;
                    case "6":
                        // Exit
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5");
                        ReduceRed();
                        break;

                }
            }
        }

        //Add New Content
        private void CreateNewContent()
        {
            Console.Clear();
            //new up
            //StreamingContent content = new StreamingContent();

            //string titles
            Console.Write("Please enter a title: ");
            string title = Console.ReadLine();

            //string description
            Console.Write("Please enter a description: ");
            string desc = Console.ReadLine();

            //int starRating
            Console.Write("Please enter the star rating (1-10): ");
            int rating = int.Parse(Console.ReadLine());

            //string Genre
            Console.Write("Please enter a Genre: ");
            string genre = Console.ReadLine();

            //MaturityRating
            Console.WriteLine("Select a maturity rating: \n" +
                "1. G\n" +
                "2. PG\n" +
                "3. PG 13\n" +
                "4. R\n" +
                "5. NC 17\n" +
                "6. TV G\n" +
                "7. TV MA");

            string stringMaturityRating = Console.ReadLine();

            MaturityRating maturityRating;

            //switch(stringMaturityRating)
            //{
            //    case "1":
            //        maturityRating = MaturityRating.G;
            //        break;
            //    case "2":
            //        maturityRating = MaturityRating.PG;
            //        break;
            //    case "3":
            //        maturityRating = MaturityRating.PG_13;
            //        break;
            //    case "4":
            //        maturityRating = MaturityRating.R;
            //        break;
            //    case "5":
            //        maturityRating = MaturityRating.NC_17;
            //        break;
            //    case "6":
            //        maturityRating = MaturityRating.TV_G;
            //        break;
            //    case "7":
            //        maturityRating = MaturityRating.TV_MA;
            //        break;

            //    default:
            //        maturityRating = MaturityRating.PG_13;
            //        break;
            //}

            ////Casting to an enum
            ////Casting into a MaturityRating  //Parsing into an int //String
            //int intMaturityRating = int.Parse(stringMaturityRating);
            //maturityRating = (MaturityRating)intMaturityRating;

            //Can be done on one line
            maturityRating = (MaturityRating)int.Parse(stringMaturityRating);

            //New up Content at end
            StreamingContent content = new StreamingContent(title, desc, rating, genre, maturityRating);

            //Add to repository
            _streamingRepo.AddContentToDirectory(content);
        }

        //Display All Content
        private void ShowAllContent()
        {
            Console.Clear();

            //Get Content
            List<StreamingContent> listOfContent = _streamingRepo.GetContents();

            //Loop through Contents
            foreach (StreamingContent content in listOfContent)
            {
                //Console Write (Display Content)
                DisplayContent(content);
            }

            ReduceRed();
        }

        //Display Content By Title
        private void GetContentByTitle() //Search functionality by title
        {
            Console.Clear();
            //What Title do we want
            Console.WriteLine("What title are you looking for?");
            //Getting user input
            string title = Console.ReadLine();

            //Get Content
            StreamingContent content = _streamingRepo.GetContentByTitle(title);

            //if we have it
            if (content != null)
            {
                //Display Content
                DisplayContent(content);
            }
            else
            {
                Console.WriteLine("Failed to find title");
            }

            ReduceRed();
        }

        //Delete Content
        private void DeleteContent()
        {
            Console.Clear();
            //Select the content to delete
            //Get Content by title
            Console.WriteLine("What title would you like to remove?");

            //setting up a counter for future use
            int count = 0;

            //DisplayAllContent
            List<StreamingContent> contentList = _streamingRepo.GetContents();
            foreach (StreamingContent content in contentList)
            {
                count++;
                Console.WriteLine($"{count}. {content.Title}");
            }

            int userInput = int.Parse(Console.ReadLine());
            int targetIndex = userInput - 1;

            //Did I get valid input
            if (targetIndex >= 0 && targetIndex < contentList.Count())
            {
                //Delete the content
                //Selecting object to be deleted
                StreamingContent targetContent = contentList[targetIndex];
                //Check to see if deleted
                if (_streamingRepo.DeleteExistingContent(targetContent))
                {
                    //success message
                    Console.WriteLine($"{targetContent.Title} removed from repo");
                }
                else
                {
                    //Fail Message
                    Console.WriteLine("Sorry something went wrong");
                }
            }
            //If invalid input
            else
            {
                Console.WriteLine("Invalid Selection");
            }
            ReduceRed();
        }

        //Update Content
        private void UpdateContent()
        {
            Console.Clear();
            //Original Title
            //Ask the user what to update
            Console.WriteLine("What title would you like to update?");
            string userInput = Console.ReadLine();

            //New Content (Updated content)
            StreamingContent updatedContent = new StreamingContent();
            //Title
            Console.Write("What is the new Title:");
            updatedContent.Title = Console.ReadLine();
            //Description
            Console.Write("What is the new Description:");
            updatedContent.Description = Console.ReadLine();
            //Star Rating
            Console.Write("What is the new Star Rating:");
            updatedContent.StarRating = int.Parse(Console.ReadLine());
            //Genre
            Console.Write("What is the new Genre: ");
            updatedContent.Genre = Console.ReadLine();
            //Maturity Rating
            updatedContent.TypeOfMaturityRating = GetMaturityRatingInput();

            _streamingRepo.UpdateExistingContent(userInput, updatedContent);
            //Does this update
            //Did they give me a title that exists
            //Feedback Message to user
            ReduceRed();
        }
        //Helper Methods
        private MaturityRating GetMaturityRatingInput()
        {
            //MaturityRating
            Console.WriteLine("Select a maturity rating: \n" +
                "1. G\n" +
                "2. PG\n" +
                "3. PG 13\n" +
                "4. R\n" +
                "5. NC 17\n" +
                "6. TV G\n" +
                "7. TV MA");

            string stringMaturityRating = Console.ReadLine();

            MaturityRating maturityRating;

            //switch(stringMaturityRating)
            //{
            //    case "1":
            //        maturityRating = MaturityRating.G;
            //        break;
            //    case "2":
            //        maturityRating = MaturityRating.PG;
            //        break;
            //    case "3":
            //        maturityRating = MaturityRating.PG_13;
            //        break;
            //    case "4":
            //        maturityRating = MaturityRating.R;
            //        break;
            //    case "5":
            //        maturityRating = MaturityRating.NC_17;
            //        break;
            //    case "6":
            //        maturityRating = MaturityRating.TV_G;
            //        break;
            //    case "7":
            //        maturityRating = MaturityRating.TV_MA;
            //        break;

            //    default:
            //        maturityRating = MaturityRating.PG_13;
            //        break;
            //}

            ////Casting to an enum
            ////Casting into a MaturityRating  //Parsing into an int //String
            //int intMaturityRating = int.Parse(stringMaturityRating);
            //maturityRating = (MaturityRating)intMaturityRating;

            //Can be done on one line
            maturityRating = (MaturityRating)int.Parse(stringMaturityRating);

            return maturityRating;
        }
        private void DisplayContent(StreamingContent content)
        {
            Console.WriteLine($"Title: {content.Title}\n" +
                    $"Description: {content.Description}\n" +
                    $"Genre: {content.Genre}\n" +
                    $"Rating: {content.StarRating}\n" +
                    $"Family Friendly: {content.IsFamilyFriendly}\n" +
                    $"Maturity Rating: {content.TypeOfMaturityRating}\n");
        }

        private void ReduceRed()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        //Seed Method
        private void SeedContentList()
        {
            StreamingContent harryPotter = new StreamingContent("Harry Potter", "Magical Kid causes trouble for aunt and uncle", 10, "Magic", MaturityRating.PG);
            StreamingContent titanic = new StreamingContent("Titanic", "Ive got a sinking fealing", 8, "Tragedy", MaturityRating.PG_13);
            StreamingContent willyWonka = new StreamingContent("Willy Wonka", "Man makes candy", 7, "Sweet Treat", MaturityRating.G);

            _streamingRepo.AddContentToDirectory(harryPotter);
            _streamingRepo.AddContentToDirectory(titanic);
            _streamingRepo.AddContentToDirectory(willyWonka);
        }
    }
}


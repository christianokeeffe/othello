using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloProject
{
    class Readfile
    {
        public static List<Person> insertPeople(string inputPath)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(inputPath);
            char[] splitter = new char[] {' ','\t'};
            List<Person> personList = new List<Person>();
            Person tempPerson = new Person();
            int IDcounter = 0;
            while(!file.EndOfStream)
            {
                string line = file.ReadLine();
                string[] words = line.Split(':');
                if(words[0] == "user"){
                    tempPerson = new Person();
                    tempPerson.ID = IDcounter;
                    IDcounter++;
                    tempPerson.Name = words[1].Trim();
                }
                if (words[0] == "friends")
                {
                   tempPerson.Friends = words[1].Trim().Split(splitter).ToList();
                }
                if (words[0] == "summary")
                {
                    tempPerson.Summary = words[1];
                    tempPerson.SummaryTokens = SentimentTokenizer.tokenize(words[1]);
                }
                if (words[0] == "review")
                {
                    tempPerson.ReviewTokens = SentimentTokenizer.tokenize(words[1]);
                    tempPerson.Review = words[1];
                    personList.Add(tempPerson);
                }
            }

            file.Close();
            return personList;
    }
        public static List<Review> loadReviews(string inputPath) 
        {
            System.IO.StreamReader file = new System.IO.StreamReader(inputPath);

            List<Review> reviewList = new List<Review>();
            Review tempReview = new Review();

            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                string[] words = line.Split(':');
                if (words[0] == "product/productId")
                {
                    tempReview = new Review();
                    tempReview.ProductID = words[1].Trim();
                }
                if(words[0] =="review/userId")
                {
                    tempReview.UserID = words[1].Trim();
                }
                if (words[0] == "review/profileName")
                {
                    tempReview.ProfilName = words[1].Trim();
                }
                if (words[0] == "review/helpfulness")
                {
                    tempReview.Helpfulness = words[1].Trim();
                }
                if (words[0] == "review/score")
                {
                    tempReview.Score = Double.Parse(words[1].Replace('.', ','));
                }
                if (words[0] == "review/time")
                {
                    tempReview.Time = Int32.Parse(words[1]);
                }
                if (words[0] == "review/summary")
                {
                    tempReview.Summary = SentimentTokenizer.tokenize(words[1]);
                }
                if (words[0] == "review/text")
                {
                    tempReview.Text = SentimentTokenizer.tokenize(words[1]);
                    reviewList.Add(tempReview);
                }
            }
            return reviewList;
        }
    }

}

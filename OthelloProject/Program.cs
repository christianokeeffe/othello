using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OthelloProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //*** Mette Path ***
            //List<Person> PersonList = Readfile.insertPeople("C:\\Users\\Mette\\Downloads\\friendships.reviews.txt");
            //List<Review> ReviewList = Readfile.loadReviews("C:\\Users\\Mette\\Desktop\\SentimentTrainingData.txt");

            //*** Kasper ***
            //List<Person> PersonList = Readfile.insertPeople("C:\\C:\\Users\\Kasper\\Documents\\Uni\\P7\\Undervisning\\Web Intelligence\\ChrMetKas\\testfriendships.txt");
            //List<Review> ReviewList = Readfile.loadReviews("C:\\Users\\Kasper\\Documents\\Uni\\P7\\Undervisning\\TestSentiment.txt");
            //SentimentTokenizer.tokenize("Hej :-) #altfornice #12");

            //*** Christian ***
            //List<Review> ReviewList = Readfile.loadReviews("C:\\Users\\Christian\\Dropbox\\Documents\\Arbejde\\UNI\\P7\\Undervisning\\SentimentTrainingData.txt");
            //List<Person> PersonList = Readfile.insertPeople("\\friendships.reviews.txt");

            //*** Program functionality ***
            //Person.makeFriendList(PersonList);
            //List<List<int>> clusters = cluster.splintNumbTimes(OurMatrix.createMatrix(PersonList),2);
            
            //prob p = new prob(ReviewList);
            //p.getClassOfReview(ReviewList[0].Text);
            
            //Scores.computeScores(p, PersonList);
            //Scores.computeBuying(PersonList);

            //Writefile.writeOutput(PersonList);
            
            Console.ReadKey();
        }
    }
}

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
            //List<Person> PersonList = Readfile.insertPeople("C:\\Users\\Mette\\Desktop\\P7 Alt\\P7\\Undervisning\\Web Intelligence\\ChrMetKas\\søgemaskine\\testfriendships.txt");
            //List<Review> ReviewList = Readfile.loadReviews("C:\\Users\\Mette\\Desktop\\P7 Alt\\P7\\Undervisning\\Web Intelligence\\ChrMetKas\\søgemaskine\\testreviews.txt");
            //List<Person> PersonList = Readfile.insertPeople("C:\\Users\\Mette\\Desktop\\P7 Alt\\P7\\Undervisning\\Web Intelligence\\ChrMetKas\\søgemaskine\\friendships2.txt");
            //List<Review> ReviewList = Readfile.loadReviews("C:\\Users\\Mette\\Desktop\\P7 Alt\\P7\\Undervisning\\SentimentTrainingData.txt");
            
            //*** Kasper ***
            //List<Person> PersonList = Readfile.insertPeople("C:\\C:\\Users\\Kasper\\Documents\\Uni\\P7\\Undervisning\\Web Intelligence\\ChrMetKas\\testfriendships.txt");
            //List<Review> ReviewList = Readfile.loadReviews("C:\\Users\\Kasper\\Documents\\Uni\\P7\\Undervisning\\TestSentiment.txt");
            //SentimentTokenizer.tokenize("Hej :-) #altfornice #12");

            //*** Christian ***
            //List<Review> ReviewList = Readfile.loadReviews("C:\\Users\\Christian\\Dropbox\\Documents\\Arbejde\\UNI\\P7\\Undervisning\\SentimentTrainingData.txt");
            //List<Review> ReviewList = Readfile.loadReviews("C:\\Users\\Christian\\Dropbox\\Documents\\Arbejde\\UNI\\P7\\Undervisning\\Web Intelligence\\ChrMetKas\\søgemaskine\\testreviews.txt");
            //List<Person> PersonList = Readfile.insertPeople("\\friendships.reviews.txt");

            //*** Program functionality ***
            Console.WriteLine("Files loaded 1/7");
            Console.ReadKey();
            Person.makeFriendList(PersonList);
            Console.WriteLine("FriendList made 2/7");
            Console.ReadKey();
            List<List<int>> clusters = cluster.splintNumbTimes(OurMatrix.createMatrix(PersonList),1);
            Console.WriteLine("Clusters made 3/7");
            Console.ReadKey();
            prob p = new prob(ReviewList);
            double correct = 0;
            double wrong = 0;
            double correctness = 0;
            for (int i = 0; i < 1000; i++)
            {
                int response = p.getClassOfReview(ReviewList[i].Text);
                if(response == (int)ReviewList[i].Score)
                {
                    correct++;
                }
                else
                {
                    wrong++;
                }
            }
            correctness = correct / (wrong + correctness);
            /*Console.WriteLine("Training done 4/7");
            Console.ReadKey();
            Scores.computeScores(p, PersonList);
            Console.WriteLine("Scores computed 5/7");
            Console.ReadKey();
            Scores.computeBuying(PersonList, clusters);
            Console.WriteLine("Buyings computed 6/7");
            Console.ReadKey();
            Writefile.writeOutput(PersonList);
            Console.WriteLine("Written to file 7/7");
            Console.ReadKey();
        }
    }
}

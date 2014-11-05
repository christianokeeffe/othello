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
            
            /*double[,] a = new double[9,9];
            a[0, 0] = 0;
            a[0, 1] = 1;
            a[0, 2] = 1;
            a[0, 3] = 0;
            a[0, 4] = 0;
            a[0, 5] = 0;
            a[0, 6] = 0;
            a[0, 7] = 0;
            a[0, 8] = 0;
            a[1, 0] = 1;
            a[1, 1] = 0;
            a[1, 2] = 1;
            a[1, 3] = 0;
            a[1, 4] = 0;
            a[1, 5] = 0;
            a[1, 6] = 0;
            a[1, 7] = 0;
            a[1, 8] = 0;
            a[2, 0] = 1;
            a[2, 1] = 1;
            a[2, 2] = 0;
            a[2, 3] = 1;
            a[2, 4] = 1;
            a[2, 5] = 0;
            a[2, 6] = 0;
            a[2, 7] = 0;
            a[2, 8] = 0;
            a[3, 0] = 0;
            a[3, 1] = 0;
            a[3, 2] = 1;
            a[3, 3] = 0;
            a[3, 4] = 1;
            a[3, 5] = 1;
            a[3, 6] = 1;
            a[3, 7] = 0;
            a[3, 8] = 0;
            a[4, 0] = 0;
            a[4, 1] = 0;
            a[4, 2] = 1;
            a[4, 3] = 1;
            a[4, 4] = 0;
            a[4, 5] = 1;
            a[4, 6] = 1;
            a[4, 7] = 0;
            a[4, 8] = 0;
            a[5, 0] = 0;
            a[5, 1] = 0;
            a[5, 2] = 0;
            a[5, 3] = 1;
            a[5, 4] = 1;
            a[5, 5] = 0;
            a[5, 6] = 1;
            a[5, 7] = 1;
            a[5, 8] = 0;
            a[6, 0] = 0;
            a[6, 1] = 0;
            a[6, 2] = 0;
            a[6, 3] = 1;
            a[6, 4] = 1;
            a[6, 5] = 1;
            a[6, 6] = 0;
            a[6, 7] = 1;
            a[6, 8] = 0;
            a[7, 0] = 0;
            a[7, 1] = 0;
            a[7, 2] = 0;
            a[7, 3] = 0;
            a[7, 4] = 0;
            a[7, 5] = 1;
            a[7, 6] = 1;
            a[7, 7] = 0;
            a[7, 8] = 1;
            a[8, 0] = 0;
            a[8, 1] = 0;
            a[8, 2] = 0;
            a[8, 3] = 0;
            a[8, 4] = 0;
            a[8, 5] = 0;
            a[8, 6] = 0;
            a[8, 7] = 1;
            a[8, 8] = 0;
            cluster.splintNumbTimes(a,2);*/
            //Kaspers Path
            //List<Person> PersonList = Readfile.insertPeople("C:\\friendships.txt");
            //Chr Path
            //List<Person> PersonList = Readfile.insertPeople("C:\\Users\\Christian\\Downloads\\friendships.txt");
            //Mette Path
            List<Person> PersonList = Readfile.insertPeople("C:\\Users\\Mette\\Downloads\\friendships.reviews.txt");
            Person.makeFriendList(PersonList);
            Console.WriteLine("Så er vennelisten lavet! :D");
            Console.ReadKey();
            //List<Person> PersonList = Readfile.insertPeople("C:\\Users\\Christian\\Dropbox\\Documents\\Arbejde\\UNI\\P7\\Undervisning\\Web Intelligence\\ChrMetKas\\testfriendships.txt");
            //cluster.splintNumbTimes(OurMatrix.createMatrix(PersonList),2);
            //Kasper Test path
            //List<Person> PersonList = Readfile.insertPeople("C:\\C:\Users\\Kasper\\Documents\\Uni\P7\\Undervisning\\Web Intelligence\\ChrMetKas\\testfriendships.txt");
            //List<Review> ReviewList = Readfile.loadReviews("C:\\Users\\Kasper\\Documents\\Uni\\P7\\Undervisning\\Web Intelligence\\ChrMetKas\\testreviews.txt");
            //cluster.clust(OurMatrix.createMatrix(PersonList));
            //OurMatrix.createMatrix(PersonList);
            SentimentTokenizer.tokenize("Hej :-) #altfornice");
        }
    }
}

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Person temp1 = new Person;
            Person temp2 = new Person;
            temp1.Name = "Per";
            temp1.Friends.add("Mette");
            temp1.Friends.add("Kasper");
            temp1.Friends.add("Christian");
            temp2.Name = "Morten";
            temp2.Friends.add("Mette");
            temp2.Friends.add("Kasper");
            temp2.Friends.add("Christian");
            Similarity.computeSimilarity(temp1, temp2);
        }
    }
}

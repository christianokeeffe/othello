using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OthelloProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double[,] a = new double[9,9];
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
            cluster.clust(a);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Person> PersonList = Readfile.insertPeople();
            Person temp1 = new Person();
            Person temp2 = new Person();
            List<string> friends1 = new List<string>();
            List<string> friends2 = new List<string>();
            friends1.Add("Mette");
            friends1.Add("Kasper");
            friends1.Add("Christian");
            friends1.Add("Niels");
            friends1.Add("Rasmus");
            friends2.Add("Niels");
            friends2.Add("Rasmus");
            friends2.Add("Aleksander");
            temp1.Name = "Per";
            temp1.Friends = friends1;
            temp2.Name = "Morten";
            temp2.Friends = friends2;
            Similarity.ComputeSimilarity(temp1, temp2);
        }
    }
}

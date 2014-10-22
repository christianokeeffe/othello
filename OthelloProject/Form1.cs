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

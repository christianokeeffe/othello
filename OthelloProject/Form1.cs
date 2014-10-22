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
            Person temp1 = new Person();
            Person temp2 = new Person();
            List<string> friends = new List<string>();
            friends.Add("Mette");
            friends.Add("Kasper");
            friends.Add("Christian");
            temp1.Name = "Per";
            temp1.Friends = friends;
            temp2.Name = "Morten";
            temp2.Friends = friends;
            Similarity.ComputeSimilarity(temp1, temp2);
        }
    }
}

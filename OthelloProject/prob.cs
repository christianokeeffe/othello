using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloProject
{
    class prob
    {
        List<Review> listOfReviews;
        List<List<Review>> GroupedListOfReviews = new List<List<Review>>();
        List<term> termList = new List<term>();
        public prob (List<Review> listOfReviews)
        {
            this.listOfReviews = listOfReviews;
            for(int i = 0; i < 5; i++)
            {
                GroupedListOfReviews.Add(new List<Review>());
            }
            for(int i = 0; i < listOfReviews.Count; i++)
            {
                GroupedListOfReviews[(int)listOfReviews[i].Score].Add(listOfReviews[i]);
            }
        }

        public double getPofClass(int classnumb)
        {
            return (GroupedListOfReviews[classnumb].Count + 1) / (listOfReviews.Count + GroupedListOfReviews.Count);
        }

        public double getProbOfTermInClass(string term, int classnumb)
        {
            return termList.Find(x => x.termName == term).termProb[classnumb];
        }

        private int getClassOfReview(Review rev)
        {
            List<double> scores = new List<double>();
            for(int i = 0; i < 5; i++)
            {
                
            }
            return 0;
        }
    }
}

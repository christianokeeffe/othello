using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloProject
{
    class Similarity
    {
        public static double ComputeSimilarity(Person node1, Person node2)
        {
            double top = node1.Friends.Intersect(node2.Friends).Count();
            double bottom;
            if(node1.Friends.Contains(node2.Name)){
                if (node1.Friends.Count == 1 || node2.Friends.Count == 1)
                {
                    return 5;
                }
                else
                {
                    bottom = 5 + Math.Sqrt((node1.Friends.Count() - 1) * (node2.Friends.Count() - 1));
                }
            }
            else 
            { 
                bottom = Math.Sqrt(node1.Friends.Count() * node2.Friends.Count());
            }
            double result = top / bottom;
            return result;
        }

        public static List<Review> getClosestReviews(List<Review> reviewlist, Review reviewToCompare, int k)
        {

        }

        public static double getCousineScore(Review reviewa, Review reviewb)
        {
            return 1;
        }
    }
}

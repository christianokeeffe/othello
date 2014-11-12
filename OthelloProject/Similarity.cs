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
            List<Review> returnList = new List<Review>();
            TFIDF tfidfObject = new TFIDF(reviewlist);

            List<KeyValuePair<Review,double>> scoreList = new List<KeyValuePair<Review,double>>();
            /*for(int i = 0; i < reviewlist.Count; i++)
            {
                double score = getCousineScore(reviewToCompare,reviewlist[i]);
                scoreList.Add(new KeyValuePair<Review, double>(reviewlist[i], score));
            }*/
            scoreList = tfidfObject.calSimilarity(reviewToCompare);
            scoreList = scoreList.OrderBy(o=>o.Value).ToList();
            for (int i = 0; i < k; i++ )
            {
                if(i < scoreList.Count)
                {
                    returnList.Add(scoreList[scoreList.Count -1 - i].Key);
                }
            }        
        
            return returnList;
        }

        public static double getCousineScore(Review reviewa, Review reviewb)
        {
            Random r = new Random(DateTime.UtcNow.Millisecond);
            return r.NextDouble();
        }
    }
}

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
            double bottom = Math.Sqrt(node1.Friends.Count() * node2.Friends.Count());
            double result = top / bottom;
            return result;
        }
    }
}

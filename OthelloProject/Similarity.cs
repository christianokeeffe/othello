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
            var a = node1.Friends.Intersect(node2.Friends);
            int b = a.Count();
            return 0;
        }
    }
}

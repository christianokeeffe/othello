using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloProject
{
    class term
    {
        public string termName;
        public List<double> termProb = new List<double>();
        public int[] numbInClass = new int[5];

        public int getCount()
        {
            return numbInClass[0] + numbInClass[1] + numbInClass[2] + numbInClass[3] + numbInClass[4];
        }
    }
}

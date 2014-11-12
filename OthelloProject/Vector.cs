using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloProject
{
    class Vector
    {
        public Dictionary<string, double> listOfTerms = new Dictionary<string, double>();
        public void NormilizeVector(int termsInAll, Dictionary<string, double> IDF) 
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            foreach(KeyValuePair<string, double> k in listOfTerms)
            {
                result.Add(k.Key, (1 + Math.Log10(k.Value))* IDF[k.Key] / termsInAll);
            }

            listOfTerms = result;
        }

        public double calSim(Vector v) 
        {
            double result = 0, contain = 0;

            foreach(KeyValuePair<string, double> k in v.listOfTerms)
            {
                if(listOfTerms.TryGetValue(k.Key, out contain))
                {
                    result += contain;
                }
            }

            return result;
        }
    }
}

using Accord.Math.Decompositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloProject
{
    class cluster
    {
        public static List<List<int>> clust(double[,] inputMatrix)
        {
            for(int i = 0; i < Math.Sqrt(inputMatrix.Length); i++)
            {
                double sum = 0;
                for(int j = 0; j <  Math.Sqrt(inputMatrix.Length); j++)
                {
                    sum += inputMatrix[i,j];
                    inputMatrix[i, j] = -inputMatrix[i, j];
                }
                inputMatrix[i, i] = sum;
            }

            var gevd = new EigenvalueDecomposition(inputMatrix);

            return splitOnGab(gevd.Eigenvectors);
        }

        private static List<List<int>> splitOnGab(double[,] inputMatrix)
        {
            List<KeyValuePair<int, double>> keyList = new List<KeyValuePair<int, double>>();
            for (int i = 0; i < Math.Sqrt(inputMatrix.Length); i++)
            {
                keyList.Add(new KeyValuePair<int, double>(i, inputMatrix[i, 1]));
            }

            keyList.Sort(delegate(KeyValuePair<int, double> a, KeyValuePair<int, double> b)
                {
                    return a.Value.CompareTo(b.Value);
                }
            );
            
            double avg = 0;
            List<int> splitInts = new List<int>();

            for (int i = 0; i < keyList.Count-1; i++)
            {
                avg += Math.Abs(keyList[i].Value - keyList[i + 1].Value);
            }

            avg = avg / keyList.Count;
            double compval = avg*2;

            for (int i = 0; i < keyList.Count - 1; i++)
            {
                if (compval < Math.Abs(keyList[i].Value - keyList[i + 1].Value))
                {
                    splitInts.Add(i);
                }
            }

            splitInts.Add(keyList.Count-1);
            List<List<int>> returnList = new List<List<int>>();
            int prev = -1;
            for (int i = 0; i < splitInts.Count; i++)
            {
                List<int> tmpList = new List<int>();
                for (int j = prev + 1; j <= splitInts[i]; j++ )
                {
                    tmpList.Add(keyList[j].Key);
                }
                returnList.Add(tmpList);
                prev = splitInts[i];
            }

            return returnList;
        }
    }
}

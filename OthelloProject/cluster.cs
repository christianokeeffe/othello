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
        public static void clust(double[,] inputMatrix)
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
            var V = splitOnGab(gevd.Eigenvectors);
            var D = gevd.DiagonalMatrix;

            int a = 0;
        }

        private static List<List<int>> splitOnGab(double[,] inputMatrix)
        {
            int largestGabIndex = 0;
            int largestGabVal = int.MaxValue;

            /*for (int i = 0; i < Math.Sqrt(inputMatrix.Length)-1; i++)
            {
                if()
            }*/

            return null;
        }
    }
}

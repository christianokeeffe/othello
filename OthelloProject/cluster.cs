using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using ILNumerics;

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

            ILInArray<double> ilArray = (ILInArray<double>)inputMatrix;
            int length = (int)Math.Sqrt(inputMatrix.Length);
            ILOutArray<double> outarray = (ILOutArray<double>)((ILArray<double>)new double[length,length]);
            ILRetArray<double> eigresult = ILMath.eigSymm(ilArray,outarray);
            
            int smallest = int.MaxValue;
            double smallval = double.MaxValue;

            for (int i = 0; i < Math.Sqrt(inputMatrix.Length); i++)
            {
                double val = Math.Round((double)eigresult.GetValue(i, i),10);
                if (val != 0 && smallval > val)
                {
                    smallest = i;
                    smallval = val;
                }
            }

            double[] vector = new double[length];
            for (int i = 0; i < length; i++)
            {
                vector[i] = (double)outarray.GetValue(i,smallest);
            }

            //Control.UseNativeMKL();
            //Matrix<double> processedData = Matrix<double>.Build.SparseOfArray(inputMatrix);
            //Evd<double> eigen = processedData.Evd();
            //Vector<Complex> eigenvector = eigen.EigenValues;

            //var gevd = new EigenvalueDecomposition(inputMatrix);
           //return null;
            return splitOnGab(vector);
        }

        public static List<List<int>> splintNumbTimes(double[,] inputMatrix, int numb)
        {
            List<List<int>> lists = new List<List<int>>();
            List<int> tmpList = new List<int>(); ;
            for (int i = 0; i < Math.Sqrt(inputMatrix.Length);i++ )
            {
                tmpList.Add(i);
            }
            lists.Add(tmpList);

            for (int i = 0; i < numb; i++)
            {
                List<List<int>> oldlist = lists;
                lists = new List<List<int>>();
                for (int j = 0; j < oldlist.Count; j++)
                {
                    if (oldlist[j].Count > 1)
                    {
                        double[,] matrixToClust = new double[oldlist[j].Count, oldlist[j].Count];
                        for (int q = 0; q < oldlist[j].Count; q++)
                        {
                            for (int n = 0; n < oldlist[j].Count; n++)
                            {
                                matrixToClust[q, n] = inputMatrix[oldlist[j][q], oldlist[j][n]];
                            }
                        }

                        List<List<int>> result = clust(matrixToClust);
                        for (int q = 0; q < result.Count; q++)
                        {
                            List<int> listToAdd = new List<int>();
                            for (int n = 0; n < result[q].Count; n++)
                            {
                                listToAdd.Add(oldlist[j][result[q][n]]);
                            }
                            lists.Add(listToAdd);
                        }
                    }
                    else
                    {
                        List<int> listToAdd = new List<int>();
                        listToAdd.Add(oldlist[j][0]);
                        lists.Add(listToAdd);
                    }
                }
            }
            return lists;
        }

        private static List<List<int>> splitOnGab(double[] inputvector)
        {

            List<KeyValuePair<int, double>> keyList = new List<KeyValuePair<int, double>>();
            for (int i = 0; i < inputvector.Length; i++)
            {
                keyList.Add(new KeyValuePair<int, double>(i, inputvector[i]));
            }

            keyList.Sort(delegate(KeyValuePair<int, double> a, KeyValuePair<int, double> b)
                {
                    return a.Value.CompareTo(b.Value);
                }
            );
            double largestGabVal = double.MinValue;
            int largestGabIndex = int.MinValue;

            for (int i = 0; i < keyList.Count - 1; i++)
            {
                double compval = Math.Abs(keyList[i].Value - keyList[i + 1].Value);
                if (largestGabVal < compval)
                {
                    largestGabVal = compval;
                    largestGabIndex = i;
                }
            }

            List<int> splitInts = new List<int>();
            splitInts.Add(largestGabIndex);
            splitInts.Add(keyList.Count - 1);
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

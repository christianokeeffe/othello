using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloProject
{
    class OurMatrix
    {
        public static double[,] createMatrix(List<Person> input) {
            double[,] matrix = new double[input.Count(), input.Count()];
            for (int i = 0; i < input.Count(); i++)
            {
                for (int j = i; j < input.Count(); j++)
                {
                    if (input[i].ID == input[j].ID)
                    {
                        matrix[input[i].ID, input[j].ID] = 0;
                    }
                    else
                    {
                        double weight = Similarity.ComputeSimilarity(input[i], input[j]);
                        matrix[input[i].ID, input[j].ID] = weight;
                        matrix[input[j].ID, input[i].ID] = weight;
                    }

                }
            }

            return matrix;
        }
    }
}

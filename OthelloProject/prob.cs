using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloProject
{
    class prob
    {
        List<Review> listOfReviews;
        List<List<Review>> GroupedListOfReviews = new List<List<Review>>();
        List<term> termList = new List<term>();
        public prob (List<Review> listOfReviews)
        {
            this.listOfReviews = listOfReviews;
            for(int i = 0; i < 5; i++)
            {
                GroupedListOfReviews.Add(new List<Review>());
            }
            for (int i = 0; i < listOfReviews.Count; i++)
            {
                GroupedListOfReviews[(int)listOfReviews[i].Score-1].Add(listOfReviews[i]);
            }
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < GroupedListOfReviews[i].Count; j++)
                {
                    for(int n = 0; n < GroupedListOfReviews[i][j].Text.Count; n++)
                    {
                        term foundTerm = termList.Find(t => t.termName == GroupedListOfReviews[i][j].Text[n]);
                        if (foundTerm == null)
                        {
                            foundTerm = new term();
                            foundTerm.termName = GroupedListOfReviews[i][j].Text[n];
                            termList.Add(foundTerm);
                        }
                        foundTerm.numbInClass[i]++;
                    }
                }
            }
            for(int i = 0; i < termList.Count; i++)
            {
                for(int j = 0; j < 5; j++)
            {
                    termList[i].termProb[j] = (termList[i].numbInClass[j] + 1) / (GroupedListOfReviews[j].Count + termList.Count);
                }
            }
        }

        public double getPofClass(int classnumb)
        {
            return (GroupedListOfReviews[classnumb].Count + 1) / (listOfReviews.Count + GroupedListOfReviews.Count);
        }

        public double getProbOfTermInClass(string term, int classnumb)
        {
            term foundTerm = termList.Find(x => x.termName == term);
            if(foundTerm == null)
            {
                return 0;
            }
            else
            {
                return foundTerm.termProb[classnumb];
            }
        }

        public int getClassOfReview(List<string> inputTokens)
        {
            List<double> scores = new List<double>();
            for(int i = 0; i < 5; i++)
            {
                double score = Math.Log10(getPofClass(i));
                for (int j = 0; j < inputTokens.Count; j++)
                {
                    score += Math.Log10(getProbOfTermInClass(inputTokens[j], i));
                }
                scores.Add(score);
            }
            double maxval = double.MinValue;
            int maxclass = int.MaxValue;
            for(int i = 0; i < 5; i++)
            {
                if(scores[i] > maxval)
                {
                    maxval = scores[i];
                    maxclass = i;
                }
            }
            return maxclass+1;
        }
    }
}

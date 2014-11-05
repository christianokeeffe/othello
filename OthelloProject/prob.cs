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
                    GroupedListOfReviews[i][j].Text.Sort();
                    int posInTermList = 0;
                    for(int n = 0; n < GroupedListOfReviews[i][j].Text.Count; n++)
                    {
                        term foundTerm;
                        bool stop = false;
                        int startindex = posInTermList;
                        int stopindex = termList.Count;
                        if (posInTermList < termList.Count && termList[posInTermList].termName != GroupedListOfReviews[i][j].Text[n])
                        {
                            while (!stop)
                            {
                                int middle = (stopindex - startindex) / 2 + startindex;
                                if (middle < termList.Count)
                                {
                                    int comp = GroupedListOfReviews[i][j].Text[n].CompareTo(termList[middle].termName);
                                    if (comp == 0)
                                    {
                                        posInTermList = middle;
                                        stop = true;
                                    }
                                    else if (stopindex - startindex == 0)
                                    {
                                        posInTermList = middle;
                                        stop = true;
                                    }
                                    else if (comp == -1)
                                    {
                                        stopindex = middle;
                                    }
                                    else
                                    {
                                        startindex = middle + 1;
                                    }
                                }
                                else
                                {
                                    posInTermList = middle;
                                    stop = true;
                                }
                            }
                        }
                        /*while(posInTermList < termList.Count && GroupedListOfReviews[i][j].Text[n].CompareTo(termList[posInTermList].termName) == 1)
                        {
                            posInTermList++;
                        }*/
                        if (posInTermList < termList.Count && GroupedListOfReviews[i][j].Text[n].CompareTo(termList[posInTermList].termName) == 0)
                        {
                            foundTerm = termList[posInTermList];
                        }
                        else
                        {
                            foundTerm = new term();
                            foundTerm.termName = GroupedListOfReviews[i][j].Text[n];
                            termList.Insert(posInTermList,foundTerm);
                        }
                        foundTerm.numbInClass[i]++;
                    }
                }
            }
            for(int i = 0; i < termList.Count; i++)
            {
                for(int j = 0; j < 5; j++)
            {
                    termList[i].termProb.Add(((double)termList[i].numbInClass[j] + 1.0) / ((double)GroupedListOfReviews[j].Count + (double)termList.Count));
                }
            }
        }

        public double getPofClass(int classnumb)
        {
            return ((double)GroupedListOfReviews[classnumb].Count + 1) / ((double)listOfReviews.Count + (double)GroupedListOfReviews.Count);
        }

        public double getProbOfTermInClass(string term, int classnumb)
        {
            int posInTermList = 0;
            int startindex = posInTermList;
            int stopindex = termList.Count;
            bool stop = false;
            if (posInTermList < termList.Count && termList[posInTermList].termName != term)
            {
                while (!stop)
                {
                    int middle = (stopindex - startindex) / 2 + startindex;
                    if (middle < termList.Count)
                    {
                        int comp = term.CompareTo(termList[middle].termName);
                        if (comp == 0)
                        {
                            posInTermList = middle;
                            stop = true;
                        }
                        else if (stopindex - startindex == 0)
                        {
                            posInTermList = middle;
                            stop = true;
                        }
                        else if (comp == -1)
                        {
                            stopindex = middle;
                        }
                        else
                        {
                            startindex = middle + 1;
                        }
                    }
                    else
                    {
                        posInTermList = middle;
                        stop = true;
                    }
                }
            }
            if (posInTermList < termList.Count && term.CompareTo(termList[posInTermList].termName) == 0)
            {
                return termList[posInTermList].termProb[classnumb];
            }
            else
            {
                return 0;
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

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
        List<term> orgTermList = new List<term>();
        int listOfReviewsCount;
        int GroupedListOfReviewsCount;
        List<int> GroupedCounts = new List<int>();

        public prob(List<Review> inputListOfReviews)
        {
            doInitialCalcs(inputListOfReviews);
            /*int listCount = inputListOfReviews.Count;
            int breakSize = listCount/10;
            int thressholdmin = 0;
            int thressholdmax = 100;
            double startCorrectness = 0;
            /*for (int i = 0; i < 10; i++)
            {
                /*List<Review> listToTrain = new List<Review>();
                for (int j = 0; j < 10; j++)
                {
                    if(j == 9)
                    {
                        listToTrain.AddRange(inputListOfReviews.GetRange(j * breakSize, listCount - (j * breakSize)));
                    }
                    else if (j != i)
                    {
                        listToTrain.AddRange(inputListOfReviews.GetRange(j * breakSize, breakSize));
                    }
                }
                int calcBreakSize = i ==9 ? 
                    listCount - i * breakSize : 
                    breakSize;
                doProbCalcs(100);
                startCorrectness += calcCorrectness(inputListOfReviews.GetRange(i * breakSize, calcBreakSize));
            }
            startCorrectness = startCorrectness / 10;
            
            while (true)
            {
                double correctness1 = 0;
                double correctness2 = 0;
                for (int i = 0; i < 10; i++)
                {
                    /*List<Review> listToTrain = new List<Review>();
                    for (int j = 0; j < 10; j++)
                    {
                        if(j == 9)
                        {
                            listToTrain.AddRange(inputListOfReviews.GetRange(j * breakSize, listCount - (j * breakSize)));
                        }
                        else if (j != i)
                        {
                            listToTrain.AddRange(inputListOfReviews.GetRange(j * breakSize, breakSize));
                        }
                    }
                    int calcBreakSize = i ==9 ? 
                        listCount - i * breakSize : 
                        breakSize;
                    doProbCalcs((thressholdmax - thressholdmin) / 3 + thressholdmin);
                    correctness1 += calcCorrectness(inputListOfReviews.GetRange(i * breakSize, calcBreakSize));
                    doProbCalcs(((thressholdmax - thressholdmin) / 3) * 2 + thressholdmin);
                    correctness2 += calcCorrectness(inputListOfReviews.GetRange(i * breakSize, calcBreakSize));
                }
                correctness1 = correctness1 / 10;
                correctness2 = correctness2 / 10;

                if(correctness1 < correctness2)
                {
                    thressholdmin = (thressholdmax - thressholdmin) / 3 + thressholdmin;
                }
                else
                {
                    thressholdmax = ((thressholdmax - thressholdmin) / 3) * 2 + thressholdmin;
                }
            }*/
        }

        public double calcCorrectness(List<Review> listToTest)
        {
            double correct = 0;
            double wrong = 0;
            double correctness = 0;
            for (int i = 0; i < listToTest.Count; i++)
            {
                int response = getClassOfReview(listToTest[i].Text);
                if (response == (int)listToTest[i].Score)
                {
                    correct++;
                }
                else
                {
                    wrong++;
                }
            }
            correctness = correct / (wrong + correct);
            return correctness;
        }

        public void doInitialCalcs(List<Review> listOfReviews)
        {
            GroupedListOfReviews = new List<List<Review>>();
            GroupedCounts = new List<int>();
            termList = new List<term>();
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

            orgTermList = termList;

            listOfReviewsCount = listOfReviews.Count;
            GroupedListOfReviewsCount = GroupedListOfReviews.Count;
            
            foreach (List<Review> review in GroupedListOfReviews) {
                GroupedCounts.Add(review.Count);
            }

            doProbCalcs(100);
            double correctness = calcCorrectness(listOfReviews);
            listOfReviews = null;
            GroupedListOfReviews = null;
            //doProbCalcs(89);
        }

        public void doProbCalcs(int thresshold)
        {
            termList = orgTermList.ToArray().ToList();
            termList = termList.OrderBy(o => o.getCount()).ToList();

            termList = termList.GetRange(0, (int)((double)termList.Count * ((double)thresshold / 100)));

            termList = termList.OrderBy(o => o.termName).ToList();

            for (int i = 0; i < termList.Count; i++)
            {
                termList[i].termProb.Clear();
                for (int j = 0; j < 5; j++)
                {
                    termList[i].termProb.Add(((double)termList[i].numbInClass[j] + 1.0) / ((double)GroupedCounts[j] + (double)termList.Count));
                }
            }
        }

        public double getPofClass(int classnumb)
        {
            return ((double)GroupedCounts[classnumb] + 1) / ((double)listOfReviewsCount + (double)GroupedListOfReviewsCount);
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
                    double tempScore = getProbOfTermInClass(inputTokens[j], i);
                    if (tempScore > 0)
                    {
                        score += Math.Log10(tempScore);
                    }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloProject
{
    class TFIDF
    {
        public List<Review> listOfReview = new List<Review>();

        //public Dictionary<string, double> bagOfWords = new Dictionary<string, double>();
        public Dictionary<string, double> UpdatedbagOfWords = new Dictionary<string, double>();
        public Dictionary<int, Vector> listOfVectors = new Dictionary<int, Vector>();

        double wtTemp = 0;
        double pageWTTemp = 0;

        public TFIDF(List<Review> thing)
        {
            this.listOfReview = thing;
            calculateTFAndIDF();
        }

        public List<KeyValuePair<Review, double>> calSimilarity(Review r) 
        {
            Vector temp = new Vector();

            List<KeyValuePair<Review, double>> lresult = new List<KeyValuePair<Review, double>>();

            foreach(string t in r.Text)
            {
                temp.listOfTerms.Add(t, r.Text.Count(x => x == t));
            }
            temp.NormilizeVector(UpdatedbagOfWords.Count, UpdatedbagOfWords);

            foreach(KeyValuePair<int, Vector> vp in listOfVectors)
            {
                lresult.Add(new KeyValuePair<Review, double>(listOfReview[vp.Key], temp.calSim(vp.Value)));
            }

            return lresult;
        }

        private void calculateTFAndIDF()
        {
            Dictionary<string, double> bagOfWords = new Dictionary<string, double>();

            int reviewID = 0;
            double count = 0;

            foreach (Review r in listOfReview)
            {
                foreach (string s in r.Text) 
                {
                    if (bagOfWords.TryGetValue(s, out count))
                    {
                        bagOfWords[s]++;
                    }
                    else 
                    {
                        bagOfWords.Add(s, 1);
                    }                    
                }
            }

            int countOfReviews = listOfReview.Count;

            foreach (KeyValuePair<string, double> k in bagOfWords)
            {
                UpdatedbagOfWords.Add(k.Key,Math.Log10(countOfReviews / k.Value));
            }

            int countOfTerms = bagOfWords.Count();

            foreach (Review r in listOfReview)
            {
                Vector temp = new Vector();
                r.reviewID = reviewID;

                foreach (string s in r.Text)
                {
                    temp.listOfTerms.Add(s, r.Text.Count(x => x == s));
                }

                temp.NormilizeVector(countOfTerms, UpdatedbagOfWords);
                listOfVectors.Add(reviewID, temp);

                reviewID++;
            }
        }
    }
}

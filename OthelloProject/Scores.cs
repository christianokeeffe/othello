using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloProject
{
    class Scores
    {
        public static void computeScores (prob p, List<Person> PersonList){
            foreach (Person person in PersonList)
            {
                if (person.HaveReview)
                {
                    person.Score = p.getClassOfReview(person.ReviewTokens);
                }
            }
        }

        public static void computeBuying(List<Person> PersonList)
        {
            foreach (Person person in PersonList)
            {
                if (!person.HaveReview)
                {
                    //predict
                }
            }
        }
    }
}

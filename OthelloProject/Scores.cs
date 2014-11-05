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

//For the people in the file that do not have a review, you should figure out if they are likely to 
//buy “fine food” from Amazon. This is done by computing the average score of the reviews that 
//friends might have supplied (not all friends have given a review!). Here, friends from another 
//community will count 10 times as much as friends from within the community. Also, there is a 
//particular convincing person –his name is “kyle”. His opinion will also count 10 times as much
//as others opinion.

//c. Report the results in the format as given above –and send it to me!
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
        private static bool sameCluster(List<List<int>> clusters, int ID1, int ID2)
        {
            int i = 0;
            int cluster1 = -1;
            int cluster2 = -1;
            while (cluster1 == -1 || cluster2 == -1)
            {
                if (clusters[i].Contains(ID1))
                {
                    cluster1 = i;
                }
                if (clusters[i].Contains(ID2))
                {
                    cluster2 = i;
                }
                i++;
            }
            return cluster1 == cluster2;
        }
        public static void computeBuying(List<Person> PersonList, List<List<int>> clusters)
        {
            foreach (Person person in PersonList)
            {
                if (!person.HaveReview)
                {
                    int count = 0;
                    int scores = 0;
                    foreach (Person friend in person.FriendList)
                    {
                        if(friend.HaveReview)
                        {
                            if (friend.Name == "kyle" || !sameCluster(clusters, friend.ID, person.ID))
                            {
                                scores += friend.Score * 10;
                                count += 10;
                            }
                            else
                            {
                                scores += friend.Score;
                                count += 1;
                            }
                        }
                    }
                    double result = scores / count;
                    if (result > 2.5)
                    {
                        person.Buying = true;
                    }
                    else
                    {
                        person.Buying = false;
                    }
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
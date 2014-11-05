using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloProject
{
    class Person
    {
        private int _id;
        private string _name;
        private List<string> _friends;
        private List<Person> _friendList;
        private string _summary;
        private string _review;
        private List<string> _summaryTokens;
        private List<string> _reviewTokens;
        private bool _haveReview = true;
        private int _score;
        private bool _buying;
        
        public int ID
        {
            get { return _id; }
            set {_id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public List<string> Friends
        {
            get { return _friends; }
            set { _friends = value; }
        }
        public List<Person> FriendList
        {
            get { return _friendList; }
            set { _friendList = value; }
        }
        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }
        public string Review
        {
            get { return _review; }
            set { _review = value; }
        }
        public List<string> ReviewTokens
        {
            get { return _reviewTokens; }
            set { _reviewTokens = value; }
        }
        public List<string> SummaryTokens
        {
            get { return _summaryTokens; }
            set { _summaryTokens = value; }
        }

        public bool HaveReview
        {
            get { return _haveReview; }
            set { _haveReview = value; }
        }
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
        public bool Buying
        {
            get { return _buying; }
            set { _buying = value; }
        }
        public static void makeFriendList(List<Person> persons)
        {
            foreach (Person person in persons)
            {
                if (person.Review == " *") {
                    person.HaveReview = false;
                }
                List<Person> friendList = new List<Person>();
                foreach (string friend in person.Friends)
                {
                    friendList.Add(persons.Find(x => x.Name == friend));
                }
                person.FriendList = friendList;
            }
        }
    }
}

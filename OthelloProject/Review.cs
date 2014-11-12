using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloProject
{
    class Review
    {
        public int reviewID;
        private string _productID;
        private string _userID;
        private string _profileName;
        private string _helpfulness;
        private double _score;
        private int _time;
        private List<string> _summary;
        private List<string> _text;

        public string ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public string ProfilName
        {
            get { return _profileName; }
            set { _profileName = value; }
        }

        public string Helpfulness
        {
            get { return _helpfulness; }
            set { _helpfulness = value; }
        }

        public double Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public int Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public List<string> Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }

        public List<string> Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}

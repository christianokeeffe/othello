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
        private string _summary;
        private string _review;
        
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

    }
}

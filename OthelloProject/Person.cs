using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloProject
{
    class Person
    {
        private string _name;
        private List<string> _friends;
        private string _summary;
        private double _review;
    
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

    }
}

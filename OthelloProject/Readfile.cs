using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloProject
{
    class Readfile
    {
        public static List<Person> insertPeople()
        {
            System.IO.StreamReader file = new System.IO.StreamReader("C:\\friendships.txt");
        
            List<Person> personList = new List<Person>();
            Person tempPerson = new Person();
            int IDcounter = 0;
            while(!file.EndOfStream)
            {
                string line = file.ReadLine();
                string[] words = line.Split(':');
                if(words[0] == "user"){
                    tempPerson = new Person();
                    tempPerson.ID = IDcounter;
                    IDcounter++;
                    tempPerson.Name = words[1].Trim();
                }
                if (words[0] == "friends")
                {
                   tempPerson.Friends = words[1].Trim().Split(' ').ToList();
                }
                if (words[0] == "summary")
                {
                    tempPerson.Summary = words[1];
                }
                if (words[0] == "review")
                {
                    tempPerson.Review = words[1];
                    personList.Add(tempPerson);
                }
            }

            file.Close();
            return personList;
    }
    }

}

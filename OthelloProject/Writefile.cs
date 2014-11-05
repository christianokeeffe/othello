using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloProject
{
    class Writefile
    {
        public static void writeOutput(List<Person> personlist)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\\Users\\Mette\\Desktop\\Output.txt"))
            {
                foreach (Person person in personlist)
                {
                    if (person.HaveReview)
                    {
                        file.WriteLine(person.Name + "\t" + person.Score + "\t" + "*");
                    }
                    else if (person.Buying)
                    {
                        file.WriteLine(person.Name + "\t" + "*" + "\t" + "yes");
                    }
                    else
                    {
                        file.WriteLine(person.Name + "\t" + "*" + "\t" + "no");
                    }
                }
            }
        }
    }
}

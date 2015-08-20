using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiBoClient.Model
{
    public class Persons
    {
        public List<Person> persons;
        public List<Person> getPersons()
        {
            persons = new List<Person>()
           {
               new Person { age=21, name="Tom" },
               new Person {age=23,name="Jack" },
               new Person {age=25,name="Rose" },
           };
            return persons;
        }
    }
}

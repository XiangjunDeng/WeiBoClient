using WeiBoClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiBoClient.ViewModel
{
    public class PersonViewModel
    {
        public List<Person> Human { get; set; }
        public PersonViewModel()
        {
            Human = new Persons().getPersons();
        }
    }
}

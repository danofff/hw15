using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15
{
    [Serializable]
    public class Person
    {
        public string firstName { get; set; }
        public string familyName { get; set; }
        public string phoneNumber { get; set; }
        public short year { get; set; }

        public Person(string frsName, string famName, string number, short y)
        {
            firstName = frsName;
            familyName = famName;
            phoneNumber = number;
            year = y;
        }
    }
}

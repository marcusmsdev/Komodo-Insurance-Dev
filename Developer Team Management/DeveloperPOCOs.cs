using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Team_Management
{
    
    public enum DevType
    {
        FrontEnd = 1,
        BackEnd,
        FullStack
    }

    public class Developer
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public int UniqueId { get; set; }

        public DevType TypeOfDev { get; set; }

        public bool IsPluralSight { get; set; }


        public Developer() { }

        public Developer(string firstName, string lastName, string phoneNumber, int uniqueId, DevType typeOfDev, bool isPluralSight)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            UniqueId = uniqueId;
            TypeOfDev = typeOfDev;
            IsPluralSight = isPluralSight;

        }
    }
}

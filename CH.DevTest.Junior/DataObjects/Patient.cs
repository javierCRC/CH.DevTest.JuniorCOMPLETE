using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH.DevTest.Junior.DataObjects
{
    public class Patient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public DateTime? DateOfBirth { get; set; } // can be null
        public string AccountNumber { get; set; } // can not be a int because have letter.

    }
}

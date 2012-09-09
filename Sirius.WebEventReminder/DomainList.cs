using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirius.WebEventReminder
{
    public static class DomainList
    {
        public static List<string> List { get; private set; }

        static DomainList()
        {
            List = new List<string> { Gym, Badminton };
        }

        public const string Gym = "Gym";

        public const string Badminton = "Badminton";
    }
}

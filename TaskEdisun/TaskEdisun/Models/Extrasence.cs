using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskEdisun.Models
{
    public class Extrasence
    {
        public Extrasence(string extrasenceName, int extrasenceReating, bool isTrue)
        {
            ExtrasenceName = extrasenceName;
            ExtrasenceReating = extrasenceReating;
            IsTrue = isTrue;
        }

        public string ExtrasenceName { get; set; }

        public bool IsTrue { get; set; }

        public int ExtrasenceReating { get; set; }

        public int Adjusting()
        {
            var random = new Random();
            return random.Next(11, 99);
        }
    }
}
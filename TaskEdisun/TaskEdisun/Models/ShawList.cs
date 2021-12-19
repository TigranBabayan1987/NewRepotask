using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskEdisun.Models
{
    public class ShawList
    {
        private static List<ShawList> _AList;
        public int RememberDigit { get; set; }

        public string UserName { get; set; }

        public List<Extrasence> Extrasences { get; set; }

        public static List<ShawList> GetShawList
        {
            get { return _AList; }
            set { _AList = value; }
        }
        static ShawList()
        {
            _AList = new List<ShawList>();
        }

        public ShawList()
        {
            ShawList.GetShawList.Add(this);
        }
    }
}
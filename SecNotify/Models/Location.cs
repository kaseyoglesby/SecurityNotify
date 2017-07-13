using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecNotify.Models
{
    class Location
    {
        public int ID { get; set; }
        private static int nextID = 1;

        public string Name { get; set; }
        public string DisplayPhone { get; set; }
        public string SMSPhone { get; set; }

        public Location()
        {
            ID = nextID;
            nextID++;
        }
    }
}

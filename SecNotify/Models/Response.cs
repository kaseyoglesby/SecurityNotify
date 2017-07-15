using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecNotify.Models
{
    public class Message
    {
        public string apiMessageId { get; set; }
        public bool accepted { get; set; }
        public string to { get; set; }
        public object error { get; set; }
    }

    public class Response
    {
        public List<Message> messages { get; set; }
        public object error { get; set; }
    }
}

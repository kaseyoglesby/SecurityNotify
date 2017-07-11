using SecNotify.Resources;
using System.Collections.Generic;

namespace Clickatell_Service
{
    public class SMS
    {
        public string Content { get; set; }
        public string Response { get; set; }

        public void Send(Secret recipient)
        {
            string response;
            string api = recipient.APIkey;

            Dictionary<string, string> Params = new Dictionary<string, string>();

            Params.Add("content", this.Content);
            Params.Add("to", recipient.Phone);

            response = Api.SendSMS(api, Params);

            this.Response = response;
        }
    }
}

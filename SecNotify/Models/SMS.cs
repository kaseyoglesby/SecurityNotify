using Clickatell_Service;
using Newtonsoft.Json;
using SecNotify.Resources;
using System;
using System.Collections.Generic;

namespace SecNotify.Models
{
    public class SMS
    {
        public string Content { get; set; }
        public Response Response { get; set; }

        public void Send(Secret recipient)
        {
            string response;
            string api = recipient.APIkey;

            Dictionary<string, string> Params = new Dictionary<string, string>();

            Params.Add("content", this.Content);
            Params.Add("to", recipient.Phone);

            response = Api.SendSMS(api, Params);
            Response responseJSON = JsonConvert.DeserializeObject<Response>(response);

            this.Response = responseJSON;

        }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeguminReactions.Utils {

    public class ServerRequest {

        public string MagicNumber { get; private set; }
        public ulong UserId { get; private set; }
        public string Message { get; private set; }
        
        public ServerRequest(JObject json)
        {
            MagicNumber = json.Value<string>("magic_number");
            UserId = json.Value<ulong>("target");
            Message = json.Value<string>("message");
        }

    }

}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeguminReactions.Utils {

    public class ServerRequest {

        public int MagicNumber { get; private set; }
        public ulong UserId { get; private set; }
        public string Message { get; private set; }
        
        public ServerRequest(JObject json)
        {
            MagicNumber = json.Value<int>("magic_number");
            UserId = json.Value<ulong>("target");
            Message = json.Value<string>("message");
        }

    }

}

using MeguminReactions.Data;
using MeguminReactions.Events;
using MeguminReactions.Extensions;
using MeguminReactions.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MeguminReactions.HTTPRequests
{
    class Reaction
    {
        public static async Task sendDiscordMessage(HttpMessageEventArgs e)
        {
            ServerRequest req = new ServerRequest(await e.Request.GetResponseJObject());

            foreach (var guild in Globals.Client.Guilds)
            {
                if (guild.GetUser(req.UserId) != null)
                {
                    Console.WriteLine("todo");
                }
            }
        }

    }
}

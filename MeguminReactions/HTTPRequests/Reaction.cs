using Discord.WebSocket;
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

            if (req.MagicNumber != "EXPLOSION")
                return;

            foreach (var guild in Globals.Client.Guilds)
            {
                await guild.DownloadUsersAsync();
                SocketGuildUser usr = guild.GetUser(req.UserId);

                if (usr != null)
                {
                    var dm = await usr.GetOrCreateDMChannelAsync();
                    await dm.SendMessageAsync(req.Message);
                    await e.Response.SendHttpResponse("{\"status\":\"true\"}");
                    return;
                }
            }

            await e.Response.SendHttpResponse("{\"status\":\"false\"}");
        }

    }
}

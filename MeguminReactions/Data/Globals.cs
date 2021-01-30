using Discord;
using Discord.WebSocket;

using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MeguminReactions.Services;

namespace MeguminReactions.Data
{
    static class Globals
    {
        public static string BotToken { get; private set; }

        public static DiscordSocketClient Client;

        //public static DbSystem Db = new DbSystem();

        public static string DebugWebhookUrl { get; private set; }

        private static Listener _listener;

        public static void InitListener() 
        {
            _listener = new Listener("http://localhost:8000/MeguminReactions/");
            // _listener.OnMessageReceived += /* Method to do */;

        }

        public static void InitConfig()
        {
            if (!File.Exists("Loggers/Credentials.json"))
                throw new FileNotFoundException($"You must have a \"Credentials.json\" file located in {AppDomain.CurrentDomain.BaseDirectory}Loggers");
            JObject ConfigurationJson = JsonConvert.DeserializeObject<JObject>(File.ReadAllText("Loggers/Credentials.json"));
            if (ConfigurationJson["botToken"] == null || ConfigurationJson["ownerId"] == null || ConfigurationJson["ownerStr"] == null)
                throw new FileNotFoundException("Missing critical informations in Credentials.json, please complete mandatory informations before continuing");

            BotToken = ConfigurationJson.Value<string>("botToken");
        }

    }
}

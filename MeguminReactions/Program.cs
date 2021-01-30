using Discord;
using Discord.Commands;
using Discord.WebSocket;

using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

using MeguminReactions.Data;
using MeguminReactions.Utils;

namespace MeguminReactions
{
    class Program
    {
        // public readonly DiscordSocketClient Client;
        public readonly CommandService commands = new CommandService();

        public Program()
        {
            Globals.Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });
            Globals.Client.Log += Loggers.LogEventAsync;
        }

        static async Task Main()
        {
            try
            {
                await new Program().MainAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (Debugger.IsAttached)
                    throw;
                Console.WriteLine(e.Message);
            }

        }

        public async Task MainAsync()
        {
            await Loggers.LogEventAsync(new LogMessage(LogSeverity.Info, "Casting...", "Starting MeguminReactions")).ConfigureAwait(false);

            Globals.InitConfig();
            //await Globals.Db.InitAsync();

            await Loggers.LogEventAsync(new LogMessage(LogSeverity.Info, "Setup", "Initializing Modules...")).ConfigureAwait(false);

            Globals.Client.MessageReceived += HandleMessageAsync;

            commands.Log += Loggers.LogEventAsync;

            await Globals.Client.LoginAsync(TokenType.Bot, Globals.BotToken);
            await Globals.Client.StartAsync();

            await Task.Delay(-1).ConfigureAwait(false);
        }

        private async Task HandleMessageAsync(SocketMessage arg)
        {
            if (arg.Author.Id == Globals.Client.CurrentUser.Id || arg.Author.IsBot)
                return;

            if (!(arg is SocketUserMessage msg))
                return;
            int pos = 0;
            if (msg.HasMentionPrefix(Globals.Client.CurrentUser, ref pos) || msg.HasStringPrefix("Megu ", ref pos))
            {
                var context = new SocketCommandContext(Globals.Client, msg);
                await commands.ExecuteAsync(context, pos, null);
            }
        }
    }
}
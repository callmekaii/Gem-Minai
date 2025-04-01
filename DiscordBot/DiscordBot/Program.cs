using DiscordBot.commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    class Program
    {
        private static DiscordClient Client { get; set; }
        private static CommandsNextExtension Commands { get; set; }
        static async Task Main(string[] args)
        {
            //This basically is the template of to run the whole ahh bot but putting the token
            //there unprotected is bad practice
            JsonParser.JsonParseChecker();

            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = commands.JsonParser.DiscordToken,
                TokenType = TokenType.Bot,
                AutoReconnect = true
            };
            Client = new DiscordClient(discordConfig);
            Client.Ready += Client_Ready;

            //This thingy is going to handle the commands
            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { "!" },
                EnableDms = true,
                EnableMentionPrefix = true,
                DmHelp = true
            };

            //Prefix Commands Registration
            Commands = Client.UseCommandsNext(commandsConfig);
            Commands.RegisterCommands<commands.commands>();


            //Handles Slash Commands
            var slash = Client.UseSlashCommands();

            //Slash Commands Registration
            slash.RegisterCommands<commands.SlashCommands>();

            //Connects to the server
            try
            {
                await Client.ConnectAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Token is invalid. Input the token again");
                File.Delete("config.json");
                JsonParser.JsonParseChecker();
            }

            await Task.Delay(-1);
        }

        private static Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}

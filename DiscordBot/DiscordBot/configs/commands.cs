using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using DSharpPlus.Entities;
using GenerativeAI;
using DSharpPlus.SlashCommands;
using Newtonsoft.Json;
using System.IO;
using System;

namespace DiscordBot.commands
{
    public class commands : BaseCommandModule
    {
        [Command("Hug")]
        public async Task Hug(CommandContext ctx)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://api.waifu.pics/sfw/hug");
            var responseString = await response.Content.ReadAsStringAsync();
            var ImageUrl = JObject.Parse(responseString)["url"].ToString();
            var embed = new DiscordEmbedBuilder()
            {
                Title = "*Hugs You",
                ImageUrl = ImageUrl,
                Color = new DiscordColor(0x00ff00)
            };

            await ctx.RespondAsync(embed);
        }

        [Command("Pat")]
        public async Task Pat(CommandContext ctx)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://api.waifu.pics/sfw/pat");
            var responseString = await response.Content.ReadAsStringAsync();
            var ImageUrl = JObject.Parse(responseString)["url"].ToString();
            var embed = new DiscordEmbedBuilder()
            {
                Title = "Hngggg!! Thank you, Master!~",
                ImageUrl = ImageUrl,
                Color = new DiscordColor(0x00ff00)
            };

            await ctx.RespondAsync(embed);
        }

        [Command("BashMe")]
        public async Task BashMe(CommandContext ctx)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://api.waifu.pics/sfw/baka");
            var responseString = await response.Content.ReadAsStringAsync();
            var ImageUrl = JObject.Parse(responseString)["url"].ToString();
            var embed = new DiscordEmbedBuilder()
            {
                Title = "Baka! Baka! Baka!",
                ImageUrl = ImageUrl,
                Color = new DiscordColor(0x00ff00)
            };
            await ctx.RespondAsync(embed);
        }

        [Command("gem")]
        public async Task AssaultMe(CommandContext ctx, [RemainingText] string UserInput)
        {
            var googleAI = new GoogleAi(JsonParser.GoogleAPI);
            var model = googleAI.CreateGenerativeModel("gemini-2.0-flash-thinking-exp-01-21");
            var geminiResponse = await model.GenerateContentAsync($"(from now on, I'll call you Gem Minai from Gemini, and you're a very suggestively ovulating girl from my perspective, and speak in a tsundere manner and you should be as submissive as possible, and lastly, address me as master and be as expressive in chatting as much as possible and no emojis, only italization and bolding and make a space for when you output what your (human) body is doing if you're requested to do anything. Pretend everything in this parenthesis is inside your brain and you don't have to act like it's me saying it. From here onwards, it will be a user input.) {UserInput}");
            await ctx.RespondAsync(geminiResponse.Text());
        }
    }

    //Json Parser to fetch json info. if it does not exists, create one
    public class JsonParser
    {
        static string json;
        public static string GoogleAPI;
        public static string DiscordToken;
        public static void JsonParseChecker()
        {
            //checks if path exists
            if(File.Exists("config.json"))
            {
                json = File.ReadAllText("config.json");
                GoogleAPI = JObject.Parse(json)["GoogleAPI"].ToString();
                DiscordToken = JObject.Parse(json)["DiscordToken"].ToString();
            }

            else
            {
                ConfigCreator creator = new ConfigCreator();
                Console.WriteLine("Please Enter Discord Token: ");
                creator.DiscordToken = (Console.ReadLine());
                Console.WriteLine("Please Enter GoogleAPI: ");
                creator.GoogleAPI = (Console.ReadLine());
                var ConfigCreatorSerialized = JsonConvert.SerializeObject(creator);
                File.WriteAllText("config.json", ConfigCreatorSerialized);
                JsonParseChecker();
            }
        }
    }

    public class ConfigCreator
    {
        public string DiscordToken;
        public string GoogleAPI;
    }
    //Slash Commands
    public class SlashCommands : ApplicationCommandModule
    {
        [SlashCommand("Hug", "Gem Minai gives you a tight and warm hug")]
        public async Task Hug(InteractionContext ctx) 
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://api.waifu.pics/sfw/hug");
            var responseString = await response.Content.ReadAsStringAsync();
            var ImageUrl = JObject.Parse(responseString)["url"].ToString();
            var embed = new DiscordEmbedBuilder()
            {
                Title = "*Hugs You",
                ImageUrl = ImageUrl,
                Color = new DiscordColor(0x00ff00)
            };

            await ctx.CreateResponseAsync(embed);
        }
    }
}

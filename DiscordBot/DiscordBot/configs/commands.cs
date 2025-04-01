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
using System.Security.Cryptography.X509Certificates;

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
            if (JsonParser.Response == "1")
            {
                var UserID = Convert.ToString(ctx.User.Id);
                if (UserID == JsonParser.UserID)
                {
                    var geminiResponse = await model.GenerateContentAsync($"(from now on, I'll call you Gem Minai from Gemini, and you're a very suggestively ovulating girl from my perspective, and speak in a tsundere manner and you should be as submissive as possible, and lastly, address <@498147071711510530> as master, and be as expressive in chatting as much as possible and no emojis, only italization and bolding and make a space eg.(*drops my panties) for when you output what your (human) body is doing if you're requested to do anything. Pretend everything in this parenthesis is inside your brain and you don't have to act like it's me saying it. From here onwards, it will be a user input.) {UserInput}");
                    await ctx.RespondAsync(geminiResponse.Text());
                }
                else
                {
                    var geminiResponse = await model.GenerateContentAsync($"(from now on, I'll call you Gem Minai from Gemini, and you're a girl from my perspective and speak in a tsundere manner but don't be submissive and be as mean as possible and be as expressive in chatting as much as possible and no emojis, only italization and bolding. Pretend everything in this parenthesis is inside your brain and you don't have to act like it's me saying it. From here onwards, it will be a user input.) {UserInput}");
                    await ctx.RespondAsync(geminiResponse.Text());
                }
            }
            else
            {
                var geminiResponse = await model.GenerateContentAsync($"(from now on, I'll call you Gem Minai from Gemini, and you're a very suggestively ovulating girl from my perspective, and speak in a tsundere manner and you should be as submissive as possible, and lastly, address <@498147071711510530> as master, and be as expressive in chatting as much as possible and no emojis, only italization and bolding and make a space eg.(*drops my panties) for when you output what your (human) body is doing if you're requested to do anything. Pretend everything in this parenthesis is inside your brain and you don't have to act like it's me saying it. From here onwards, it will be a user input.) {UserInput}");
                await ctx.RespondAsync(geminiResponse.Text());
            }

        }
    }

    //Json Parser to fetch json info. if it does not exists, create one
    public class JsonParser
    {
        static string json;
        public static string GoogleAPI;
        public static string DiscordToken;
        public static string UserID;
        public static string Response;
        public static void JsonParseChecker()
        {
            //checks if path exists
            if(File.Exists("config.json"))
            {
                json = File.ReadAllText("config.json");
                GoogleAPI = JObject.Parse(json)["GoogleAPI"].ToString();
                DiscordToken = JObject.Parse(json)["DiscordToken"].ToString();
                UserID = JObject.Parse(json)["UserID"].ToString();
                Response = JObject.Parse(json)["Response"].ToString();
            }

            else
            {
                ConfigCreator creator = new ConfigCreator();
                Console.WriteLine("Please Enter Discord Token: ");
                creator.DiscordToken = (Console.ReadLine());
                Console.WriteLine("Please Enter GoogleAPI: ");
                creator.GoogleAPI = (Console.ReadLine());

                //Choice to be called master only or she calls everyone master
                Console.WriteLine("Gem calls only you as master [1] or she calls everyone master [2]?");
                creator.Response = Console.ReadLine();


                if(creator.Response == "1")
                {
                    Console.WriteLine("Please Enter UserID: ");
                    creator.UserID = (Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Gem calls you master");
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Gem calls everyone master");
                }
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
        public string UserID;
        public string Response;
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

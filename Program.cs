using System.Net.Http;
using System.Threading.Tasks;
using ConsoleApplication.Entities;
using Newtonsoft.Json;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                throw new System.ArgumentOutOfRangeException("Au moins 1 paramètre est requis contenant le message");
            }

            MainAsync(args[0]).Wait();
        }

        private static async Task MainAsync(string msgBody)
        {
            await RunQueryAsync(msgBody);
        }
        public static async Task RunQueryAsync(string msgBody)
        {
            var strSettings = System.IO.File.ReadAllText("settings.json");
            var settings = JsonConvert.DeserializeObject<ApplicationSettings>(strSettings);
            using (var client = new System.Net.Http.HttpClient())
            {
                var msg = new Message
                {
                    AuthorizationToken = settings.ApiKey,
                    Body = msgBody
                };
                var msgString = JsonConvert.SerializeObject(msg);
                await client.PostAsync("https://pushalot.com/api/sendmessage", new StringContent(msgString, System.Text.Encoding.UTF8, "application/json"));

            }
        }

    }


}

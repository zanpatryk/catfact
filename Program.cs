using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CatFact.Services;

namespace CatFact
{
    internal class Program
    {
        public static async Task RunWithService(IFactService factService)
        {
            var lastFact = "";
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1) Peek current fact");
                Console.WriteLine("2) Save last fact");
                Console.WriteLine("3) See all saved facts");
                Console.WriteLine("4) Exit");
                Console.Write("> ");

                switch (Console.ReadLine())
                {
                    case "1":
                        var fact = await factService.GetFactAsync();
                        if (fact != null)
                        {
                            Console.WriteLine($"{fact.Text}");
                            lastFact = fact.Text;
                        }
                        break;

                    case "2":
                        if (lastFact == "")
                        {
                            Console.WriteLine("No fact to save. First peek a fact!");
                        }
                        else
                        {
                            await factService.SaveFactAsync(lastFact);
                            Console.WriteLine("Saved to file.");
                        }
                        break;

                    case "3":
                        if (File.Exists("saved_facts.txt"))
                        {
                            var all = await File.ReadAllLinesAsync("saved_facts.txt");
                            Console.WriteLine("---- Saved facts ----");
                            foreach (var line in all) Console.WriteLine(line);
                            Console.WriteLine("---------------------");
                        }
                        else
                        {
                            Console.WriteLine("No saved_facts.txt file found.");
                        }
                        break;

                    case "4":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }



        }
        static async Task Main(string[] args)
        {

            using var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddHttpClient<IFactService, FactService>(c =>
                    c.BaseAddress = new Uri("https://catfact.ninja/"));
                })
                .Build();

            var factService = host.Services.GetRequiredService<IFactService>();

            await RunWithService(factService);

        }
    }
}
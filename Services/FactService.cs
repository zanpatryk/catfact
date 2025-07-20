using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CatFact.Models;
using System.IO;

namespace CatFact.Services
{
    public class FactService : IFactService
    {
        private readonly HttpClient _http;
        private const string FilePath = "saved_facts.txt";

        public FactService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Fact?> GetFactAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<Fact>("fact");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching fact: {ex.Message}");
                return null;
            }
        }

        public async Task SaveFactAsync(string fact)
        {
            await File.AppendAllTextAsync(FilePath, fact + Environment.NewLine + Environment.NewLine);
        }
    }
}
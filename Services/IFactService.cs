using CatFact.Models;
using System.Threading.Tasks;

namespace CatFact.Services
{
    public interface IFactService
    {
        Task<Fact?> GetFactAsync();
        Task SaveFactAsync(string fact);
    }
}
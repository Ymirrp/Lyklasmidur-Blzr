using Lyklasmidur.Core.Models;
using Lyklasmidur.Core.Repositories;
using Lyklasmidur.Core.Services;

namespace Lyklasmidur.Infrastructure.Services
{
    public class WordService(IWordRepository repository) : IWordService
    {
        private readonly IWordRepository _repo = repository;

        public async Task<string> GetWord(WordType type)
        {
            return (await _repo.GetWord(type)).Value;
        }
    }
}

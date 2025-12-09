using Lyklasmidur_Blzr.Core.Models;
using Lyklasmidur_Blzr.Core.Repositories;
using Lyklasmidur_Blzr.Core.Services;

namespace Lyklasmidur_Blzr.Infrastructure.Services
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

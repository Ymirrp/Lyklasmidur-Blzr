using Lyklasmidur.Core.Models;

namespace Lyklasmidur.Core.Services
{
    public interface IWordService
    {
        Task<string> GetWord(WordType type);
    }
}

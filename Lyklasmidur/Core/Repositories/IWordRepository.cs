using Lyklasmidur.Core.Models;

namespace Lyklasmidur.Core.Repositories
{
    public interface IWordRepository
    {
        Task<Word> GetWord(WordType type);
    }
}

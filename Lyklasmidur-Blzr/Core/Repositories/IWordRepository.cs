using Lyklasmidur_Blzr.Core.Models;

namespace Lyklasmidur_Blzr.Core.Repositories
{
    public interface IWordRepository
    {
        Task<Word> GetWord(WordType type);
    }
}

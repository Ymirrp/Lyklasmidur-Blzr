using Lyklasmidur_Blzr.Core.Models;

namespace Lyklasmidur_Blzr.Core.Services
{
    public interface IWordService
    {
        Task<string> GetWord(WordType type);
    }
}

using dictionary.Data;

namespace dictionary.Contracts
{
    public interface IWordsRepository : IGenericRepository<Word>
    {
        Task<Word> GetDetails(int id);
    }
}

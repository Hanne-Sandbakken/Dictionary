using dictionary.Data;

namespace dictionary.HeinzelnisseApi
{
    public interface IHeinzelnisseApi
    {
        Task<List<Word>> GetDetails(string search);
    }
}

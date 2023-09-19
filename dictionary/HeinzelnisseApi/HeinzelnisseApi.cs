using dictionary.Data;
namespace dictionary.HeinzelnisseApi
{
    public class HeinzelnisseApi : IHeinzelnisseApi
    {
        private readonly HttpClient _httpClient;

        public HeinzelnisseApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Word>> GetDetails(string search)
        {
            HttpResponseMessage? response = await _httpClient.GetAsync($"https://heinzelnisse.info/searchResults?searchItem={search}&dictExactSearch=on&type=json&setOptions=&dictDeNoSearch=on&dictNoDeSearch=on&dictPhoneticSearch=on&wikiSearch=on&dictNynorskSearch=on&dictBokmaalSearch=checked&forumKeywordSearch=on");
            if ( response.IsSuccessStatusCode)
            {
                TranslationsApiResponse? result = await response.Content.ReadFromJsonAsync<TranslationsApiResponse>();
                List<Word> words = new();

                if (result?.noTrans.Count() > 0)
                {
                    foreach (TranslationApiResponse apiTrans in result.noTrans)
                    {
                        words.AddRange(TranslationApiMapper.ApiToWords(result));
                    }
                }
                else if (result?.deTrans.Count() > 0)
                {
                    foreach (TranslationApiResponse apiTrans in result.deTrans)
                    {
                        words.AddRange(TranslationApiMapper.ApiToWords(result));
                    }
                }
                return words;
            }
            return new List<Word>();

        }
    }
}

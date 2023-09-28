using dictionary.Controllers;
using dictionary.Data;

namespace dictionary.HeinzelnisseApi
{
    public static class TranslationApiMapper
    {
        public static List<Word> ApiToWords(TranslationsApiResponse response)
        {
            List<Word> words = new();

            if (response != null)
            {
                if (response.noTrans != null && response.noTrans.Count() > 0)
                {
                    foreach (var apiNoTrans in response.noTrans)
                    {
                        Word wordNo = new()
                        {
                            no = apiNoTrans.word,
                            de = apiNoTrans.t_word
                        };
                        words.Add(wordNo);
                    }
                }
                if (response.deTrans != null && response.deTrans.Count() > 0)
                {
                    foreach (var apiDeTrans in response.deTrans)
                    {
                        Word wordDe = new Word()
                        {
                            no = apiDeTrans.t_word,
                            de = apiDeTrans.word
                        };
                        words.Add(wordDe);
                    }
                }
            }
            return words;
        }

        public static Word ApiToWord(TranslationsApiResponse response, TranslationApiResponse response2)
        {
            Word word = new();
            if (response != null)
            {
                if (response.noTrans.Count() > 0)
                {
                    // Det er et norsk ord
                    word.no = response2.word;
                    word.de = response2.t_word;
                }
                else if (response.deTrans.Count() > 0)
                {
                    // Det er et tysk ord
                    word.no = response2.t_word;
                    word.de = response2.word;
                }
            }

            return word;
        }
    }
}

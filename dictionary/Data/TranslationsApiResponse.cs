namespace dictionary.Data
{
    public class TranslationsApiResponse
    {
        public IEnumerable<TranslationApiResponse> noTrans { get; set; }
        public IEnumerable<TranslationApiResponse> deTrans { get; set; }
    }
    public class TranslationApiResponse
    {
        public string? word { get; set; }
        public string? article { get; set; }
        public string? other { get; set; }
        public string? t_word { get; set; } 
        public string? t_article { get; set; } 
        public string? t_other { get; set; } 
    }
}

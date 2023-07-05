namespace dictionary.Data
{
    public class Category
    {
        public int Id { get; set; }
        public bool Noun { get; set; }
        public bool Verb { get; set; }
        public bool Adjective { get; set; }
        public bool Pronoun { get; set; }
        public bool Preposition { get; set; }
        public bool Conjunction { get; set; }
        public bool Interjection { get; set; }
        public bool Number { get; set; }

        public virtual IList<Word> Words { get; set; }



    }
}
namespace dictionary.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IList<Word> Words { get; set; }

    }
}
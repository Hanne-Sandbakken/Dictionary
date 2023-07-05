namespace dictionary.Data
{
    public class WordProject
    {
        public int Id { get; set; }

        public int WordId { get; set; }
        public Word Word { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
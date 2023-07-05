namespace dictionary.Data
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }

        public IList<WordProject> WordsProjects { get; set; }

    }
}

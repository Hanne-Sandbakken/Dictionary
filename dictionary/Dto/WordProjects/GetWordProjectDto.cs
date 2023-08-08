namespace dictionary.Dto.WordProjects
 
{
    public class GetWordProjectDto
    {
        public int Id { get; set; }
        public string Note { get; set; }

        public int WordId { get; set; }
        public int ProjectId { get; set; }
    }
}
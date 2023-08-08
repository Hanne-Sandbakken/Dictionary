using dictionary.Data;
using dictionary.Dto.WordProjects;

namespace dictionary.Dto.Project
{
    public class GetProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<GetWordProjectDto>? WordsProjects { get; set; }
    }
}

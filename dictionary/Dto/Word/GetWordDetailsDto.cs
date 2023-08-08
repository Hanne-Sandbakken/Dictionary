using dictionary.Data;
using dictionary.Dto.WordProjects;

namespace dictionary.Dto.Word
{
    public class GetWordDetailsDto : BaseWordDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        public virtual IList<GetWordProjectDto>? WordProjects { get; set; }
    }
}

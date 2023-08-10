using dictionary.Data;
using dictionary.Dto.WordProjects;

namespace dictionary.Dto.Word
{
    public class GetWordDetailsDto : BaseWordDto
    {
        //trenger jeg egentlig denne klassen?
        public int Id { get; set; }
        public int WordClassId { get; set; }

        ////Treger ikke denne funksjonaliteten. 
        //public virtual IList<GetWordProjectDto>? WordProjects { get; set; }
    }
}

using dictionary.Dto.Word;

namespace dictionary.Dto.Category
{
    public class GetWordClassDetailsDto : BaseWordClassDto
    {
        public int Id { get; set; }
        public List<GetWordDto> Words { get; set; }
    }
}

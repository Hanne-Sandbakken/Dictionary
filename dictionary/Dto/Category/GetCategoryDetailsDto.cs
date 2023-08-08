using dictionary.Dto.Word;

namespace dictionary.Dto.Category
{
    public class GetCategoryDetailsDto : BaseCategoryDto
    {
        public int Id { get; set; }
        public List<GetWordDto> Words { get; set; }
    }
}

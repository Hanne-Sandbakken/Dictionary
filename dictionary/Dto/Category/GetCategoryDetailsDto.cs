using dictionary.Dto.Category.Word;

namespace dictionary.Dto.Category
{
    public class GetCategoryDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetWordDto> Words { get; set; }
    }
}

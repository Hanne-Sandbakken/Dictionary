namespace dictionary.Dto.Category.Word
{
    public class GetWordDto
    {
        public int Id { get; set; }
        public string NorwegianWord { get; set; }
        public string GermanWord { get; set; }
        public int CategoryId { get; set; }
    }
}

namespace dictionary.Dto.Word
{
    public class GetWordDto : BaseWordDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
    }
}

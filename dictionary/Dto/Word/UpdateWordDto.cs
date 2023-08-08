namespace dictionary.Dto.Word
{
    public class UpdateWordDto : BaseWordDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
    }
}

namespace dictionary.Dto.Word
{
    public class UpdateWordDto : BaseWordDto
    {
        ////trenger ikke disse?
        public int Id { get; set; }
        public int WordClassId { get; set; }
    }
}

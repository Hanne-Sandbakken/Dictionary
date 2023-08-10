using System.ComponentModel.DataAnnotations;

namespace dictionary.Dto.Category
{
    public abstract class BaseWordClassDto
    {
        [Required]
        public string Name { get; set; }
    }
}

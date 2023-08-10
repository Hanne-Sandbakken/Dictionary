using System.ComponentModel.DataAnnotations;

namespace dictionary.Dto.WordClass
{
    public abstract class BaseWordClassDto
    {
        [Required]
        public string Name { get; set; }
    }
}

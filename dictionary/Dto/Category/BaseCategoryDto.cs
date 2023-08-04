using System.ComponentModel.DataAnnotations;

namespace dictionary.Dto.Category
{
    public abstract class BaseCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}

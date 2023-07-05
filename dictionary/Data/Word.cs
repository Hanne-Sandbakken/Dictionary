using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace dictionary.Data
{
    public class Word
    {
        public int Id { get; set; }
        public string NorwegianWord { get; set; }
        public string GermanWord { get; set; }

        public virtual IList<WordProject> WordProjects {get; set;}

        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set;}
        public Category Category { get; set; }


    }
}

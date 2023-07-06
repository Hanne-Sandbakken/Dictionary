using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace dictionary.Data
{
    public class Word
    {
        public int Id { get; set; }
        public string NorwegianWord { get; set; }
        public string GermanWord { get; set; }

        public virtual IList<WordProject>? WordProjects {get; set;}

        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set;}

        [JsonIgnore]
        public virtual Category? Category { get; set; }


    }
}

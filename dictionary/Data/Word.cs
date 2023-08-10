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

        [ForeignKey(nameof(WordClassId))]
        public int WordClassId { get; set;}

        [JsonIgnore]
        public virtual WordClass? WordClass { get; set; }


    }
}

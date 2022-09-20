using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual List<Cinema> Cinemas { get; set; }
    }
}
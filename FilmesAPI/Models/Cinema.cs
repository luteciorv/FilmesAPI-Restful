using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

         
        public int EnderecoID { get; set; }
        public virtual Endereco Endereco { get; set; }
        
        public int GerenteID { get; set; }
        public virtual Gerente Gerente { get; set; }
    }
}
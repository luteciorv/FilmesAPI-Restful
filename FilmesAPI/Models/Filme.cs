using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "O campo Título é obrigatório")]
        public string Titulo { get; set; }
        
        [Required(ErrorMessage = "O campo Diretor é obrigatório")]
        public string NomeDiretor { get; set; }
        
        [StringLength(30, ErrorMessage = "O Gênero não pode passar de 30 caracteres")]
        public string Genero { get; set; }
        
        [Range(1, 200, ErrorMessage = "A duração deve estar entre 1 e 200 minutos")]
        public int DuracaoEmMinutos { get; set; }

        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOS
{
    public class LerFilmeDTO
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

        public DateTime HoraConsulta
        {
            get { return DateTime.Now; }
        }
    }
}
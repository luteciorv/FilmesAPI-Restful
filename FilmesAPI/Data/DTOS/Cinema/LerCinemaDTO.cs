using FilmesAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOS
{
    public class LerCinemaDTO
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        public Endereco Endereco { get; set; }
        public Gerente Gerente { get; set; }

        public DateTime HoraConsulta
        {
            get { return DateTime.Now; }
        }
    }
}
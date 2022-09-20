using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public DateTime HorarioEncerramentoSessao { get; set; }

        public int CinemaID { get; set; }
        public virtual Cinema Cinema { get; set; }

        public int FilmeID { get; set; }
        public virtual Filme Filme { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOS.Cinema
{
    public class AtualizarCinemaDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOS
{
    public class AtualizarFilmeDTO
    {
        [Required(ErrorMessage = "O campo Título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Diretor é obrigatório")]
        public string NomeDiretor { get; set; }

        [StringLength(30, ErrorMessage = "O Gênero não pode passar de 30 caracteres")]
        public string Genero { get; set; }

        [Range(1, 200, ErrorMessage = "A duração deve estar entre 1 e 200 minutos")]
        public int DuracaoEmMinutos { get; set; }

        [Range(0, 100, ErrorMessage = "A classificação etário deve estar entre 0 e 100")]
        public int ClassificacaoEtaria { get; set; }
    }
}
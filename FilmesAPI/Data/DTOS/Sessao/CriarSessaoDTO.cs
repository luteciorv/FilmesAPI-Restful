using System;

namespace FilmesAPI.Data.DTOS
{
    public class CriarSessaoDTO
    {
        public DateTime HorarioEncerramentoSessao { get; set; }

        public int CinemaID { get; set; }
        public int FilmeID { get; set; }
    }
}

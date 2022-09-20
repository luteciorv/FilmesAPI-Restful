using FilmesAPI.Models;
using System;

namespace FilmesAPI.Data.DTOS
{
    public class LerSessaoDTO
    {
        public int ID { get; set; }   
        public DateTime HorarioInicioSessao { get; set; }        
        public DateTime HorarioEncerramentoSessao { get; set; }

        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }

        public DateTime HorarioConsulta { get { return DateTime.Now; } }
    }
}
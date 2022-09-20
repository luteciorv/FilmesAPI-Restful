using FilmesAPI.Models;
using System;
using System.Collections.Generic;

namespace FilmesAPI.Data.DTOS
{
    public class LerGerenteDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }        

        public object Cinemas { get;set; }

        public DateTime HoraConsulta 
        {
            get { return DateTime.Now; }
        }
    }
}

using System;

namespace FilmesAPI.Data.DTOS
{
    public class LerEnderecoDTO
    {
        public int ID { get; set; }

        public string Bairro { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public DateTime HoraConsulta
        {
            get { return DateTime.Now; }
        }
    }
}
using System;

namespace FilmesAPI.Data.DTOS.Endereco
{
    public class LerEnderecoDTO
    {
        public string Bairro { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public DateTime HoraConsulta
        {
            get { return DateTime.Now; }
        }
    }
}

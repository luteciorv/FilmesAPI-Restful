﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOS
{
    public class CriarCinemaDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        
        public int EnderecoID { get; set; }
        public int GerenteID { get; set; }
    }
}
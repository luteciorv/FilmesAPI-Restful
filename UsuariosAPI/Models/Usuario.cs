using System;

namespace UsuariosAPI.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
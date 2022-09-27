using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Requests
{
    public class LoginRequest
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}

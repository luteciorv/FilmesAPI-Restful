using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Requests
{
    public class RedefinirRequest
    {
        [Required]
        [DataType(DataType.Password)]
        public string NovaSenha { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("NovaSenha")]
        public string ConfirmarNovaSenha { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
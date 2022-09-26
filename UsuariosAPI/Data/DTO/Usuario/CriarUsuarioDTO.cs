using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.DTO
{
    public class CriarUsuarioDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required]
        [Compare("Senha")]
        public string ConfirmarSenha { get; set; }
    }
}
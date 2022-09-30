using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Requests
{
    public class SolicitarRedefinicaoRequest
    {
        [Required]
        public string Email { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Requests
{
    public class AtivarContaRequest
    {
        [Required]
        public int UsuarioID { get; set; }

        [Required]
        public string CodigoAtivacao { get; set; }
    }
}

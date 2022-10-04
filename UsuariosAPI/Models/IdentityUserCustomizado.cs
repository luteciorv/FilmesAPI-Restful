using Microsoft.AspNetCore.Identity;
using System;

namespace UsuariosAPI.Models
{
    public class IdentityUserCustomizado : IdentityUser<int>
    {
        public DateTime DataNascimento { get; set; }
    }
}

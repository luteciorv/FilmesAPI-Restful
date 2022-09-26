using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UsuariosAPI.Data
{
    public class UsuarioContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) :base(options)
        {

        }
    }
}

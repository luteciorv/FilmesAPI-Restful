using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.DTO;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class CadastroService
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly IMapper _mapper;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result CriarUsuario(CriarUsuarioDTO criarDTO)
        {
            var usuario = _mapper.Map<Usuario>(criarDTO);
            var usuarioIdentiy = _mapper.Map<IdentityUser<int>>(usuario);

            var resultadoIdentity = _userManager.CreateAsync(usuarioIdentiy, criarDTO.Senha);
            if(resultadoIdentity.Result.Succeeded)
            { return Result.Ok(); }

            return Result.Fail("Não foi possível cadastrar um novo usuário.");
        }
    }
}
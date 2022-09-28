﻿using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UsuariosAPI.Data.DTO;
using UsuariosAPI.Data.Requests;
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
            {
                var codigoAtivacao = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentiy).Result;
                return Result.Ok().WithSuccess(codigoAtivacao); 
            }

            return Result.Fail("Não foi possível cadastrar um novo usuário.");
        }


        public Result AtivarContaUsuario(AtivarContaRequest requisicao)
        {
            var identityUsuario = _userManager.Users.FirstOrDefault(U => U.Id == requisicao.UsuarioID);
            var identityResultado = _userManager.ConfirmEmailAsync(identityUsuario, requisicao.CodigoAtivacao).Result;

            if(identityResultado.Succeeded)
            { return Result.Ok(); }

            return Result.Fail("Falha ao ativar a conta do usuário pelo e-mail.");
        }
    }
}
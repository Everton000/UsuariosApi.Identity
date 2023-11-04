using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class UsuarioService
{
    private readonly IMapper _mapper;
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly TokenService _tokenService;

    public UsuarioService(
        IMapper mapper,
        UserManager<Usuario> userManager,
        SignInManager<Usuario> signInManager,
        TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task CadastrarUsuario(CreateUsuarioDto dto)
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);

        IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Falha ao cadastrar usuário");
        }
    }

    public async Task<string> Login(LoginUsuarioDto dto)
    {
        SignInResult resultado = await _signInManager.PasswordSignInAsync(
            dto.UserName, dto.Password, false, false
        );

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Usuário ou senha incorreto!");
        }

        Usuario? usuario = _signInManager
            .UserManager
            .Users
            .FirstOrDefault(u => u.NormalizedUserName == dto.UserName.ToUpper());

        if (usuario == null) throw new ApplicationException("Usuário não encontrado");

        var token = _tokenService.GenerateToken(usuario);

        return token;
    }
}

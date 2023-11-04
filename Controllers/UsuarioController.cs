using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto dto)
    {
        await _usuarioService.CadastrarUsuario(dto);

        return Ok("Usuário cadastrado!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUsuarioDto dto)
    {
        var token = await _usuarioService.Login(dto);

        return Ok(token);
    }
}
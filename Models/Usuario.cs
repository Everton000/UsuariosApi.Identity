using Microsoft.AspNetCore.Identity;

namespace UsuariosApi.Models;

public class Usuario : IdentityUser
{
    public Usuario(): base() { }
    public DateTime DataNascimento { get; set; }
}
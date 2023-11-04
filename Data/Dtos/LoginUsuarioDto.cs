using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos;

public class LoginUsuarioDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
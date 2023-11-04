using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace UsuariosApi.Authorization;

public class IdadeMinima : IAuthorizationRequirement
{
    public IdadeMinima(int idade)
    {
        Idade = idade;
    }

    public int Idade { get; set; }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.App.Domain.Entities;

namespace UsuariosApp.Domain.Interfaces
{
    /// <summary>
    /// Contrato para os metodos da camada de  serviços de dominio 
    /// </summary>
    public interface IUsuarioDomainService
    {
        Usuario Autenticar(string email, string senha);
    }
}

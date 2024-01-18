using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.App.Domain.Entities;

namespace UsuariosApp.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);

        Usuario? Get(string email);
        Usuario? Get(string email, string senha);
    }
}

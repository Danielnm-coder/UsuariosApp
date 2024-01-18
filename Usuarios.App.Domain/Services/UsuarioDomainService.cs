using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.App.Domain.Entities;
using UsuariosApp.Domain.Helpers;
using UsuariosApp.Domain.Interfaces;

namespace UsuariosApp.Domain.Services
{
    /// <summary>
    /// Implementando a interface de serviços de domínio
    /// </summary>
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUsuarioRepository? _usuarioRepository;

        public UsuarioDomainService(IUsuarioRepository? usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Autenticar(string email, string senha)
        {
           var usuario = _usuarioRepository?.Get(email,SHA1Helper.Create(senha));

            if (usuario == null)
                throw new ApplicationException("Acesso negado. Usuario Invalido.");
            else
                return usuario;
        }
    }
}

using Usuarios.App.Domain.Entities;
using UsuariosApp.Domain.Helpers;
using UsuariosApp.Domain.Interfaces;
using UsuariosApp.Domain.Services;
using UsuariosApp.Infra.Data.Repositories;

namespace UsuariosApp.Services
{
    /// <summary>
    /// Configurações de injeção de dependência da API
    /// </summary>
    public class DependencyInjection
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            #region Pré-cadastrar usuários no banco de dados

            var usuario1 = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = "Daniel maciel",
                Email = "daniel@gmail.com",
                Senha = SHA1Helper.Create("@Admin123")
            };

            var usuario2 = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = "Ana Paula",
                Email = "anapaula@gmail.com",
                Senha = SHA1Helper.Create("@Teste123")
            };

            var usuarioRepository = new UsuarioRepository();

            if (usuarioRepository.Get(usuario1.Email) == null)
                usuarioRepository.Add(usuario1);

            if (usuarioRepository.Get(usuario2.Email) == null)
                usuarioRepository.Add(usuario2);

            #endregion
        }
    }
}




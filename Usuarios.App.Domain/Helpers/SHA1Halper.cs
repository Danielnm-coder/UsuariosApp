using System.Security.Cryptography;
using System.Text;

namespace UsuariosApp.Domain.Helpers
{
    /// <summary>
    /// Classe auxiliar para criptografia de dados usando o algoritmo SHA-1.
    /// </summary>
    public static class SHA1Helper
    {
        /// <summary>
        /// Calcula o hash SHA-1 de uma string.
        /// </summary>
        public static string Create(string input)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(input);
                var hashBytes = sha1.ComputeHash(inputBytes);

                // Converte os bytes do hash para uma representação hexadecimal
                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}

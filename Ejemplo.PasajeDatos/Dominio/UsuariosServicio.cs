using System.Collections.Generic;
using WebApplication1.Dominio.Entidades;

namespace WebApplication1.Dominio
{
    public class UsuariosServicio
    {
        private static readonly List<Usuario> Usuarios = new List<Usuario>();

        public List<Usuario> ObtenerUsuarios()
        {
            return Usuarios;
        }

        public void Agregar(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }

        public Usuario Autenticar(string email, string password)
        {
            if (email == "administrador@gmail.com" && password == "123456")
            {
                return new Usuario { Nombre = "Administrador" };
            }

            return null;
        }
    }
}
using System.Collections.Generic;
using WebApplication1.Dominio.Entidades;

namespace WebApplication1.Dominio
{
    public class PerfilesServicio
    {
        private static List<Perfil> Perfiles = new List<Perfil>();

        public PerfilesServicio()
        {
            Perfiles.Add(new Perfil { Id = 1, Descripcion = "Administrador" });
            Perfiles.Add(new Perfil { Id = 2, Descripcion = "Usuario" });
        }
        public List<Perfil> ObtenerPerfiles()
        {
            return Perfiles;
        }
    }
}
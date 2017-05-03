using System;
using System.Web.Mvc;
using WebApplication1.Dominio;
using WebApplication1.Dominio.Entidades;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AutenticacionController : Controller
    {
        private readonly UsuariosServicio _usuariosServicio = new UsuariosServicio();

        [HttpGet]
        public ActionResult Login()
        {
            ViewData["NombreEquipo"] = Environment.MachineName;

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel modelo)
        {
                var usuario = _usuariosServicio.Autenticar(modelo.Email, modelo.Password);

                if (usuario == null)
                {
                    ViewBag.Mensaje = "Usuario o contraseña inválida.";
                    return View();
                }

                AlmacenarEnSesion(usuario);

                return RedirectToAction("Index", "Usuarios");
        }

        private void AlmacenarEnSesion(Usuario usuario)
        {
            Session["Nombre"] = usuario.Nombre;
            Session["IdUsuario"] = usuario.IdUsuario;
        }

        public ActionResult AcercaDeMi()
        {
            if (Session["Nombre"] != null)
            {
                ViewBag.UsuarioNombre = Session["Nombre"];
            }

            return View();
        }
    }
}
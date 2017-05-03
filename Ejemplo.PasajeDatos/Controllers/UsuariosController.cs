using System.Web.Mvc;
using WebApplication1.Dominio;
using WebApplication1.Dominio.Entidades;

namespace WebApplication1.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly PerfilesServicio _perfilesServicio = new PerfilesServicio();
        private readonly UsuariosServicio _usuariosServicio = new UsuariosServicio();

        // GET: Usuarios
        public ActionResult Index()
        {
            ViewBag.NuevoUsuarioCreado = EsNuevoUsuario();

            var usuarios = _usuariosServicio.ObtenerUsuarios();

            return View(usuarios);
        }

        // GET: Usuarios/Create
        [HttpGet]
        public ActionResult Crear()
        {
            ViewBag.Perfiles = _perfilesServicio.ObtenerPerfiles();

            return View();
        }

        [HttpPost]
        public ActionResult Crear(Usuario usuario)
        {
                _usuariosServicio.Agregar(usuario);

                TempData["usuarioCreado"] = true;

                return RedirectToAction("Index");
        }

        private bool EsNuevoUsuario()
        {
            return TempData["usuarioCreado"] != null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServicioWeb.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Registrar(Models.Usuario usu)
        {
            return usu.Guardar();
        }
        public JsonResult Loguear(string loginUsuario,string contraseña)
        {
            var usu = Models.Usuario.Loguear(loginUsuario, contraseña);
            return Json(usu, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Lista(string texto)
        {
            var lista = Models.Usuario.Lista(texto);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaAhorro(int id)
        {
            var lista = Models.Usuario.ListaAhorro(id);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CargarUsuario(int id)
        {
            var usu = Models.Usuario.Cargar(id);
            return Json(usu, JsonRequestBehavior.AllowGet);
        }
        
    }
}
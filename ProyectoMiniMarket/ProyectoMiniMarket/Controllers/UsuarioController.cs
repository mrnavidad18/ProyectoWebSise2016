using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ProyectoMiniMarket.Controllers
{
    public class UsuarioController : Controller
    {
        minimarketDBEntities1 bd = new minimarketDBEntities1();
       
        // GET: Usuario
        public ActionResult Index(string idusuario, string passwordusuario)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (!string.IsNullOrEmpty(idusuario) && !string.IsNullOrEmpty(passwordusuario))
            {

                foreach (var user in bd.usuario)
                {
                    if (user.id.Equals(idusuario) && user.pwd.Equals(passwordusuario))
                    {
                        Session["usuario"] = user.nombre;
                        return RedirectToAction("Lista");                       
                    }
                    else
                    {
                        /*return Content("<script language='javascript' type='text/javascript'>alert('USUARIO INCORRECTO');</script>");*/
                        ViewData["Message"] = "USUARIO O CONTRASEÑA ERRADA";                       
                    }
                }

            }


            return View();
        }
       

        public ActionResult Lista()
        {
            
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index");

            }
            else
            {
                var listado = (from x in bd.productos
                               select x).ToList();

                return View(listado);
            }
            
        }

        public ActionResult desconectar()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Session.Clear();

            return RedirectToAction("Index");
            

        }
    }
}
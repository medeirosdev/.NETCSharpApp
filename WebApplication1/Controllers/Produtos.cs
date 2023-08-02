using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class Produtos : Controller
    {
        // GET: Produtos
        public ActionResult Index()
        {
            return View();
        }


        // POST: Produtos/Importar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Importar(IFormFile file)
        {

            if(file != null || file.Length <= 0)
            {
                return View("SuccessPage");
            }
            else
            {
                return View("ErrorPage");
            }
            
        }

        

        

       
}

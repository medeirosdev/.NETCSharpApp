using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Globalization;
using WebApplication1.Models;
using Dapper;
using System.Diagnostics.Metrics;
using System;
using CsvHelper.Configuration;
using MySql.Data.MySqlClient;
using WebApplication1.NovaPasta;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
      
    {
        //Instanciando o ProdutoService para usar na rota ImportarProduto e ListadeProdutos
        ProdutoService produtoService = new ProdutoService();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }




        // POST: Home/ImportarProduto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ImportarProduto(IFormFile file)
        {
           //Simples validação do arquivo csv que vem do Form de importar
            if (file == null || file.Length <= 0)
            {
                return RedirectToAction("ErrorView");
            }
            else
            {

                List<Produto> produtoList = produtoService.CsvToList(file);

                String connStr = produtoService.ConnectionString;

                using (MySqlConnection connection = new(connStr))
                {
                    produtoService.SalvarListaBD(produtoList, connection);
                }

                return RedirectToAction("SuccessPage");
            }

        }
        // POST: Home/ListadeProdutos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ListadeProdutos()
        {
             
            List<Produto> produtos = produtoService.getAllProducts();

            if (produtos.Count == 0)
            { 
                return RedirectToAction("ProdutoError");
            }

            return RedirectToAction("ProdutosImportados", produtos);

        }

        public IActionResult ProdutosImportados2()
        {
            List<Produto> produtos = produtoService.getAllProducts();

            if (produtos.Count == 0)
            {
                return RedirectToAction("ProdutoError");
            }

            return View("ProdutosImportados", produtos);
        }

        public IActionResult ListadeProdutosView()
        {
            return View("ProdutosImportados");
        }


        public IActionResult ProdutosImportados()
        {
            return View("ProdutosImportados");
        }


        public IActionResult ProdutoError()
        {
            return View("ProdutoError");
        }
        

        public IActionResult ErrorView()
        {
            return View("ErrorView");
        }

        public IActionResult SuccessPage()
        {
            return View("SuccessPage");
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
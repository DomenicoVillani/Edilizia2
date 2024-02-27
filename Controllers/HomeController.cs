using Edilizia.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Edilizia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(DB.getAll());
        }

        public IActionResult Details(int? id)
        {
            if(id.HasValue)
            {
                return View(DB.getById(id));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Add() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(string nome, string cognome, string indirizzo, string codicefiscale, bool coniugato, int figli, string mansione)
        {
            var dipendente = DB.AggiungiDipendente(nome,cognome,indirizzo,codicefiscale,coniugato,figli,mansione);
            return RedirectToAction("Details", new {id=dipendente.DipendenteId});
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

using Ajax.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using static Ajax.WebUI.Models.Kullanici;

namespace Ajax.WebUI.Controllers
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


        public IActionResult GetList()
        {
            Thread.Sleep(5000);
            var jsonKullanicilar = JsonConvert.SerializeObject(KullaniciIslem.GetKullanicilar());

            return Json(jsonKullanicilar);
        }

        public IActionResult GetById(int id)
        {
            var kullanici = KullaniciIslem.GetKullanici(id);
            var jsonKullanici = JsonConvert.SerializeObject(kullanici);

            return Json(jsonKullanici);
        }


        [HttpPost]
        public IActionResult KullaniciEkle(Kullanici entity)
        {
            KullaniciIslem.Insert(entity);
            var jsonKullanici = JsonConvert.SerializeObject(entity);

            return Json(jsonKullanici);
        }
    }
}
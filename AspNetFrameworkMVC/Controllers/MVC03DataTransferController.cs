using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetFrameworkMVC.Controllers
{
    public class MVC03DataTransferController : Controller
    {
        // GET: MVC03DataTransfer
        public ActionResult Index()
        {   
            // MVC de temel olarak 3 türde view a veri yollama yapısı var
            // Örneğin veritabanında ürün bilgisini çekip ekrana yollamak için

            // 1- ViewBag : Tek Kullanımlık Ömrü Var
            ViewBag.UrunKategorisi = "Bilgisayar";
            // 2- ViewData : Tek Kullanımlık Ömrü Var
            ViewData["UrunAdi"] = "Acer Monitor";
            // 3-TempData : 2 Kullanımlık Ömrü Var
            TempData["urunFiyati"] = 3518;
            return View();
        }
    }
}
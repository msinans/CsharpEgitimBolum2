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
        public ActionResult Index(string txtAra)
        {   
            // MVC de temel olarak 3 türde view a veri yollama yapısı var
            // Örneğin veritabanında ürün bilgisini çekip ekrana yollamak için

            // 1- ViewBag : Tek Kullanımlık Ömrü Var
            ViewBag.UrunKategorisi = "Bilgisayar";
            // 2- ViewData : Tek Kullanımlık Ömrü Var
            ViewData["UrunAdi"] = "Acer Monitor";
            // 3-TempData : 2 Kullanımlık Ömrü Var
            TempData["urunFiyati"] = 3518;

            ViewBag.GetVerisi = txtAra;

            return View();
        }
        [HttpPost]  // aşağıdaki metodun sadece post yönteminde çalışmasını sağlar
        public ActionResult Index(string text1, string ddListe, bool cbOnay, FormCollection formCollection)
        {
            // 1. yöntem parametrelerden gelen veriler;

            ViewBag.Mesaj = "Textboxtan gelen veri : " + text1;
            ViewBag.Mesajliste = "Listeden seçilen değer :" + ddListe;
            TempData["Tdata"] = "Checkbox dan seçilen değer : " + cbOnay;

            // 2. Yöntem Reqest Form ile Verileri Yakalama

            ViewBag.Mesaj2 = "Textboxtan gelen veri : " + Request.Form["text1"];
            ViewBag.Mesajliste2 = "Listeden seçilen değer :" + Request.Form["ddListe"];
            TempData["Tdata2"] = "Checkbox dan seçilen değer : " + Request.Form.GetValues("cbOnay")[0]; // checkbox verisi bu şekilde yakalanıyor

            // 3. Yöntem FormCollection ile Verileri Yakalama

            ViewBag.Mesaj3 = "Textboxtan gelen veri : " + formCollection["text1"];
            ViewBag.Mesajliste3 = "Listeden seçilen değer :" + formCollection["ddListe"];
            TempData["Tdata3"] = "Checkbox dan seçilen değer : " + formCollection.GetValues("cbOnay")[0];

            return View();
        }
    }
}
﻿using AspNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVC.Controllers
{
    public class MVC07PartialController : Controller
    {
        public IActionResult Index()
        {
            Kullanici kullanici = new Kullanici()
            {
                Ad = "Murat",
                Soyad ="Yılmaz",
                Email = "info@yonetici.com",
                KullaniciAdi = "murat",
                Sifre = "123456"
            };
            return View(kullanici);
        }
    }
}

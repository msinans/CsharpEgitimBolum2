﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetFrameworkMVC.Models
{
    public class Kullanici
    {
        public int Id { get; set; }

        public String Ad { get; set; }

        public String Soyad { get; set; }

        public String Email { get; set; }

        public String KullaniciAdi { get; set; }

        public String Sifre { get; set; }
    }
}
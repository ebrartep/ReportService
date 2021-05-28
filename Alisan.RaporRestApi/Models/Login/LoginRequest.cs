using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alisan.RaporRestApi.Models.Login
{
    public class LoginRequest
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Token { get; set; }
        public bool isIcMusteri { get; set; }
    }
}

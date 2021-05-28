using Alisan.RaporRestApi.Models.Login;
using Alisan.RaporRestApi.Models.SolMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alisan.RaporRestApi.Business
{
    public class KullaniciKontrol
    {
        public MenuResponse Kontrol(LoginRequest request)
        {
            if (request.KullaniciAdi == "Adem.KALEM@alisangroup.com" && request.Sifre == "123456")
            {
                var menu = new MenuOlustur().MenuAl(request);
                return menu;
            }
            else 
            {
                return null; 
            }
        }
 
    }
}

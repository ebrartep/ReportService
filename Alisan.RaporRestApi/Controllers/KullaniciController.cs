using Alisan.RaporRestApi.Business;
using Alisan.RaporRestApi.Models.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alisan.RaporRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        [HttpPost]
        public IActionResult KullaniciControl([FromBody] LoginRequest request)
        {
            if (request.isIcMusteri)
            {
                //mail adresini al
                //yetkileri al
            }
            else
            {
                var control = new KullaniciKontrol();
                var res = control.Kontrol(request);
                if (res == null)
                    return BadRequest("Kullanıcı bulunamadı");


                return Ok(res);
            }
            return Ok();
        }
    }
}

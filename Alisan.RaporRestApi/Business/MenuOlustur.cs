using Alisan.RaporRestApi.Core;
using Alisan.RaporRestApi.Core.Sharepoint;
using Alisan.RaporRestApi.Models.Login;
using Alisan.RaporRestApi.Models.SolMenu;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alisan.RaporRestApi.Business
{
    public class MenuOlustur
    {
        public MenuResponse MenuAl(LoginRequest request)
        {


            var response = new MenuResponse();
            response.KullaniciAdi = "Adem.KALEM@alisangroup.com";
            response.PowerBIToken = "Test";
            response.PowerBIToken = PowerBITokenCreate.TokenCreate().access_token;

            var mail = request.KullaniciAdi;

            SharepointRepo spRepo = new SharepointRepo();

            ListItemCollection coll = spRepo.SP_IcKullaniciYetkiDataCekme(mail);

            var kayitlar = (from ListItem item in coll
                            group item by item["GrupAdi"]
                               into grp
                            select new
                            {
                                GroupAdi = grp.Key.ToString(),
                                ListItemsData = grp
                            });

            GroupList grpList = new GroupList();

            foreach (var data in kayitlar.ToList())
            {
                var groupItem = new GroupList();
                groupItem.GroupAdi = data.GroupAdi;

                foreach (var item in data.ListItemsData.ToList())
                {
                    groupItem.RaporItems.Add(new RaporItem { 
                        title = Convert.ToString(item["RaporAdi"]),
                        route = Convert.ToString(item["RaporRouteAdi"]),
                        RaporId = Convert.ToString(item["RaporID"]),
                        GroupId = Convert.ToString(item["GrupID"]),
                        id = Convert.ToString(item["ID"]),

                    });
                   
                }
                response.GroupListesi.Add(groupItem);
            }

            
            return response;
        }




    }
}

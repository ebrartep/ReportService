using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alisan.RaporRestApi.Core.Sharepoint
{
    public class SharepointRepo
    {
        public ListItemCollection  SP_IcKullaniciYetkiDataCekme(string eMail)
        {
            try
            {
                string url = "https://alisanlogistics.sharepoint.com/sites/KurumsalCozumler/";

                var login = "SPServiceCloud@alisangroup.com";
                var password = "SliM!0489-@";


                SharePointOnlineCredentials onlineCredentials = new SharePointOnlineCredentials(login, password);
                ClientContext ctx = new ClientContext(url)
                {
                    Credentials = onlineCredentials
                };

                List icKullaniciYetkiListesi = ctx.Web.Lists.GetByTitle("RaporYetkiListesi");

                CamlQuery camlQuery = new CamlQuery();
                camlQuery.ViewXml = @"<View>
                        <Query>
                        <Where><Eq><FieldRef Name='Email' /><Value Type='Text'>" + eMail + "</Value></Eq></Where></Query></View>";



                ListItemCollection items = icKullaniciYetkiListesi.GetItems(camlQuery);
                ctx.Load(items);
                ctx.ExecuteQueryAsync().Wait();
                return items;

                //var kayitlar = (from ListItem item in items
                //                group item by item["GrupAdi"]
                //                into grp
                //                select new
                //                {
                //                    GroupID = grp.Key.ToString(),
                //                    ListItemsData = grp
                //                });
                

                //foreach (var data in kayitlar)
                //{
                //    foreach (var item in data.ListItemsData)
                //    {
                //        string grupAdi = Convert.ToString(item["GrupAdi"]);
                //        string raporAdi = Convert.ToString(item["RaporAdi"]);

                //    }
                //}

            }
            catch (Exception)
            {

                throw;
            }
        }


    }


}

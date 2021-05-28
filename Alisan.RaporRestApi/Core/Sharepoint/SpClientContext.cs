using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint;


namespace Alisan.RaporRestApi.Core.Sharepoint
{
    public class SpClientContext : ClientContext
    {
        static SpClientContext client;

        static SpClientContext pClient;

        SpClientContext(string url)
            : base(url)
        {

        }

        public static SpClientContext Client(string url)
        {
            if (client == null)
            {
                client = new SpClientContext(url);
                var passwordList = "SliM!0489-@";
                var userName = "SPServiceCloud@alisangroup.com";

                //  client.Credentials = new SharePointOnlineCredentials(AppSettings.GetConfiguration<string>("UserName"), securePassword);

                client.Credentials = new SharePointOnlineCredentials(userName, passwordList);
            }

            return client;
        }
  
    }
}

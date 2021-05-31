using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alisan.RaporRestApi.Models.SolMenu
{
    public class MenuResponse
    {
        public MenuResponse()
        {
            GroupListesi = new List<GroupList>();
        }
        public List<GroupList> GroupListesi { get; set; }
        public string PowerBIToken { get; set; }
        public string KullaniciAdi { get; set; }
    }

    public class GroupList
    {
        public GroupList()
        {
            RaporItems = new List<RaporItem>();
        }
        public string GroupAdi { get; set; }


        public List<RaporItem> RaporItems { get; set; }
    }
    public class RaporItem
    {
        public string title { get; set; }
        public string route { get; set; }
        public string id { get; set; }

        public string RaporId { get; set; }
        public string GroupId { get; set; }

    }
}


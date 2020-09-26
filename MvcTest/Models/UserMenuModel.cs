using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTest.Models
{
	public class UserMenuModel
	{
        public int menu_id { get; set; }

        public string menu_name { get; set; }

        public int menu_order { get; set; }

        public string iconid { get; set; }

        public string actionname { get; set; }

        public string controllername { get; set; }

    }
}
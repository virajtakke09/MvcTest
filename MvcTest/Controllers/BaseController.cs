using MvcTest.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTest.Controllers
{
    public class BaseController : Controller
    {
        private GlobalDB bl = new GlobalDB();
        private string strSql = "";
        private ArrayList alSQLParams = new ArrayList();
        private SqlDateTime sqldatenull = SqlDateTime.Null;
        string tablename = "", trantype = "", fieldname = "", insertvalues = "", filter = "", orderby = "", relationtable = "";

		// GET: Base
		protected override void OnActionExecuting(ActionExecutingContext UserMenu)
		{
			ViewBag.UsermenuDetail = bl.getUserMenuDetail();
		}
	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace MvcTest.Models
{
	public class GlobalDB
	{
		private string strSql = "";
		private ArrayList alSQLParams = new ArrayList();
		private SqlDateTime sqldatenull = SqlDateTime.Null;
		private SQLDB sqldb = new SQLDB();
		string tablename = "", trantype = "", fieldname = "", insertvalues = "", filter = "", orderby = "", relationtable = "";


		//Start Master......................................................................................................................................................
		public string MasterTransaction(string tablename, string trantype, string fieldname, string insertvalues, string filter, string orderby, string relationtable)
		{
			alSQLParams.Clear();
			alSQLParams.Add(new SqlParameter("tablename", tablename));
			alSQLParams.Add(new SqlParameter("trantype", trantype));
			alSQLParams.Add(new SqlParameter("fieldname", fieldname));
			alSQLParams.Add(new SqlParameter("insertvalues", insertvalues));
			alSQLParams.Add(new SqlParameter("filter", filter));
			alSQLParams.Add(new SqlParameter("orderby", orderby));
			alSQLParams.Add(new SqlParameter("relationtable", relationtable));
			return sqldb.ExecuteStoreProcedure("Master_Table_Transaction", alSQLParams);

		}
		public DataTable getMasterDetail(string tablename, string fieldname, string insertvalues, string filter, string orderby, string relationtable)
		{
			alSQLParams.Clear();
			DataTable dt = null;
			strSql = "Master_Table_Transaction";
			alSQLParams.Add(new SqlParameter("tablename", tablename));
			alSQLParams.Add(new SqlParameter("trantype", "Select"));
			alSQLParams.Add(new SqlParameter("fieldname", fieldname));
			alSQLParams.Add(new SqlParameter("insertvalues", insertvalues));
			alSQLParams.Add(new SqlParameter("filter", filter));
			alSQLParams.Add(new SqlParameter("orderby", orderby));
			alSQLParams.Add(new SqlParameter("relationtable", relationtable));
			return dt = sqldb.getDataTableQuery(strSql, alSQLParams);
		}
		//End Master........................................................................................................................................................

		//Start User Menu...................................................................................................................................................
		public List<UserMenuModel> getUserMenuDetail()
		{
			alSQLParams.Clear();
			tablename = " wb_menu";
			fieldname = "*";
			orderby = " menu_order ";

			DataTable dt = getMasterDetail(tablename, fieldname, "", "", orderby, "");
			var UserMenu = (from DataRow dr in dt.Rows
							select new UserMenuModel()
							{
								menu_id = Convert.ToInt16(dr["menu_id"]),
								menu_name = dr["menu_name"].ToString(),
								menu_order = Convert.ToInt16(dr["menu_order"]),
								iconid = dr["iconid"].ToString(),
								actionname = dr["actionname"].ToString(),
								controllername = dr["controllername"].ToString()
							}).ToList();
			return UserMenu;
		}
		//End User Menu...................................................................................................................................................


		//Start Category...................................................................................................................................................
		public List<CategoryModel> getCategoryDetail()
		{
			alSQLParams.Clear();
			tablename = " wb_category_list ";
			fieldname = " cat_id,cat_name ";
			orderby = " cat_id desc ";

			DataTable dt = getMasterDetail(tablename, fieldname, "", "", orderby, "");
			var UserMenu = (from DataRow dr in dt.Rows
							select new CategoryModel()
							{
								cat_id = Convert.ToInt32(dr["cat_id"]),
								cat_name = dr["cat_name"].ToString()
							}).ToList();
			return UserMenu;
		}

		public CategoryModel getCategoryinfo(string id)
		{
			alSQLParams.Clear();
			CategoryModel CompanyMasterdetail = new CategoryModel();
			tablename = " wb_category_list ";
			fieldname = " cat_id,cat_name ";
			filter = "cat_id='" + id + "' ";

			DataTable dt = getMasterDetail(tablename, fieldname, "", filter, "", "");

			if (dt != null)
			{
				for (int i = 0; dt.Rows.Count > i; i++)
				{
					CompanyMasterdetail.cat_id = Convert.ToInt32(dt.Rows[i]["cat_id"]);
					CompanyMasterdetail.cat_name = dt.Rows[i]["cat_name"].ToString();
				}
			}
			return CompanyMasterdetail;
		}
		//End Category.....................................................................................................................................................

		//Start Product...................................................................................................................................................
		public List<ProductModel> getProductDetail()
		{
			alSQLParams.Clear();
			tablename = " wb_product_list as a ";
			fieldname = " a.pro_id,a.pro_name,b.cat_id,b.cat_name ";
			orderby = " a.pro_id desc ";
			relationtable = " Left Outer Join wb_category_list as b ON b.cat_id=a.cat_id ";
			DataTable dt = getMasterDetail(tablename, fieldname, "", "", orderby, relationtable);
			var UserMenu = (from DataRow dr in dt.Rows
							select new ProductModel()
							{
								pro_id = Convert.ToInt32(dr["pro_id"]),
								pro_name = dr["pro_name"].ToString(),
								cat_id = Convert.ToInt32(dr["cat_id"]),
								cat_name = dr["cat_name"].ToString()
							}).ToList();
			return UserMenu;
		}

		public ProductModel getProductinfo(string id)
		{
			alSQLParams.Clear();
			ProductModel CompanyMasterdetail = new ProductModel();
			tablename = " wb_product_list ";
			fieldname = " pro_id,cat_id,pro_name ";
			filter = "pro_id='" + id + "' ";

			DataTable dt = getMasterDetail(tablename, fieldname, "", filter, "", "");

			if (dt != null)
			{
				for (int i = 0; dt.Rows.Count > i; i++)
				{
					CompanyMasterdetail.pro_id = Convert.ToInt32(dt.Rows[i]["pro_id"]);
					CompanyMasterdetail.cat_id = Convert.ToInt32(dt.Rows[i]["cat_id"]);
					CompanyMasterdetail.pro_name = dt.Rows[i]["pro_name"].ToString();
				}
			}
			return CompanyMasterdetail;
		}
		//End Product.....................................................................................................................................................


	}
}
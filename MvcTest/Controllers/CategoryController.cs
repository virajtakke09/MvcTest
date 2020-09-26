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
    public class CategoryController : BaseController
    {
        private GlobalDB bl = new GlobalDB();
        private string strSql = "";
        private ArrayList alSQLParams = new ArrayList();
        private SqlDateTime sqldatenull = SqlDateTime.Null;
        string tablename = "", trantype = "", fieldname = "", insertvalues = "", filter = "", orderby = "", relationtable = "", result="";

        // GET: Category
        public ActionResult Category()
        {
            ViewBag.GetCategoryList = bl.getCategoryDetail();
            return View();
        }


        [HttpGet]
        public ActionResult Categorydetail(string id)
        {
            CategoryModel sm = new CategoryModel();
            sm = bl.getCategoryinfo(id);
            return View(sm);
        }

        [HttpPost]
        public ActionResult Categorydetail(CategoryModel Categorydetail)
        {
            try
            {
                if (Categorydetail.cat_id == 0)
                {
                    result = bl.MasterTransaction("wb_category_list", "Insert", "cat_name,created_date", "'" + Categorydetail.cat_name + "',GETDATE()", "", "", "");
                }
                else
                {
                    result = bl.MasterTransaction("wb_category_list", "Update", "", "cat_name='" + Categorydetail.cat_name + "',edited_date=GETDATE()", "cat_id='" + Categorydetail.cat_id + "'", "", "");
                }
                if (result == "done")
                {
                    TempData["AlertMessage"] = "Sucessfully Done";
                }
                else
                {
                    TempData["AlertMessage"] = result;
                }
                return RedirectToAction("Category", "Category");
            }
            catch (Exception ex)
            {
                TempData["AlertMessage"] = ex.ToString();
                return RedirectToAction("Category", "Category");
            }
        }


        [HttpGet]
        public ActionResult DeleteCategory(string id)
        {
            //CategoryModel DeleteCategory = new CategoryModel();
            //DeleteCategory = bl.getCategoryinfo(id);
            //return PartialView(DeleteCategory);
            CategoryModel sm = new CategoryModel();
            sm = bl.getCategoryinfo(id);
            return PartialView(sm);
        }

        [HttpPost]
        public ActionResult DeleteCategory(CategoryModel DeleteCategory)
        {
            try
            {
                result = bl.MasterTransaction("wb_category_list", "Delete", "", "", "cat_id='" + DeleteCategory.cat_id + "'", "", "");

                if (result == "done")
                {
                    TempData["AlertMessage"] = "Sucessfully Done";
                }
                else
                {
                    TempData["AlertMessage"] = result;
                }
                return RedirectToAction("Category", "Category");
            }
            catch (Exception ex)
            {
                TempData["AlertMessage"] = ex.ToString();
                return RedirectToAction("Category", "Category");
            }
        }


    }
}
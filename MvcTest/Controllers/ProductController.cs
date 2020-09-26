using MvcTest.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTest.Controllers
{
    public class ProductController : BaseController
    {
        private GlobalDB bl = new GlobalDB();
        private string strSql = "";
        private ArrayList alSQLParams = new ArrayList();
        private SqlDateTime sqldatenull = SqlDateTime.Null;
        string tablename = "", trantype = "", fieldname = "", insertvalues = "", filter = "", orderby = "", relationtable = "", result = "";

        // GET: Product
        public ActionResult Product()
        {
            ViewBag.GetProductList = bl.getProductDetail();
            return View();
        }

        [HttpGet]
        public ActionResult Productdetail(string id)
        {
            ProductModel sm = new ProductModel();
            sm = bl.getProductinfo(id);

            DataTable dt = bl.getMasterDetail("wb_category_list", "cat_id,cat_name", "", "", "", "");
            ViewBag.CategoryDetail = (from DataRow dr in dt.Rows
                                        select new dropdown()
                                        {
                                            key = Convert.ToInt32(dr["cat_id"]),
                                            displayfield = dr["cat_name"].ToString()
                                        }).ToList();

            return View(sm);
        }

        [HttpPost]
        public ActionResult Productdetail(ProductModel Productdetail)
        {
            try
            {
                if (Productdetail.pro_id == 0)
                {
                    result = bl.MasterTransaction("wb_product_list", "Insert", "pro_name,cat_id,created_date", "'" + Productdetail.pro_name + "','"+ Productdetail.cat_id + "',GETDATE()", "", "", "");
                }
                else
                {
                    result = bl.MasterTransaction("wb_product_list", "Update", "", "pro_name='" + Productdetail.pro_name + "',cat_id='"+ Productdetail.cat_id + "',edited_date=GETDATE()", "pro_id='" + Productdetail.pro_id + "'", "", "");
                }
                if (result == "done")
                {
                    TempData["AlertMessage"] = "Sucessfully Done";
                }
                else
                {
                    TempData["AlertMessage"] = result;
                }
                return RedirectToAction("Product", "Product");
            }
            catch (Exception ex)
            {
                TempData["AlertMessage"] = ex.ToString();
                return RedirectToAction("Product", "Product");
            }
        }


        [HttpGet]
        public ActionResult DeleteProduct(string id)
        {
            ProductModel sm = new ProductModel();
            sm = bl.getProductinfo(id);

            DataTable dt = bl.getMasterDetail("wb_category_list", "cat_id,cat_name", "", "", "", "");
            ViewBag.CategoryDetail = (from DataRow dr in dt.Rows
                                      select new dropdown()
                                      {
                                          key = Convert.ToInt32(dr["cat_id"]),
                                          displayfield = dr["cat_name"].ToString()
                                      }).ToList();


            return PartialView(sm);
        }

        [HttpPost]
        public ActionResult DeleteProduct(ProductModel DeleteProduct)
        {
            try
            {
                result = bl.MasterTransaction("wb_product_list", "Delete", "", "", "pro_id='" + DeleteProduct.pro_id + "'", "", "");

                if (result == "done")
                {
                    TempData["AlertMessage"] = "Sucessfully Done";
                }
                else
                {
                    TempData["AlertMessage"] = result;
                }
                return RedirectToAction("Product", "Product");
            }
            catch (Exception ex)
            {
                TempData["AlertMessage"] = ex.ToString();
                return RedirectToAction("Product", "Product");
            }
        }



    }
}
using NefaMVCWenAppDevEx.DataModels;
using NefaMVCWenAppDevEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NefaMVCWenAppDevEx.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
		//    A � I K L A M A
		//
		//A�a��da yorum sat�rna al�nm�� CRUD metodlar� yerine ModelDataController' �ndaki get, post, put, delete fonksiyonlar�
		// CRUD operasyonlar�nda kullan�ld�.
		//
		//
		// 
		//
		//BusinessLayer getBusineesLayer;
		//public JsonResult GetList()
		//{
		//	try
		//	{
		//		getBusineesLayer = new BusinessLayer();
		//		return Json(getBusineesLayer.GetAll(), JsonRequestBehavior.AllowGet);
		//	}
		//	catch
		//	{
		//		return Json("Kay�tlar listelenemedi.");
		//	}
		//}
		//public JsonResult Add(DataModel item)
		//{
		//	try
		//	{
		//		getBusineesLayer = new BusinessLayer();
		//		return Json(getBusineesLayer.Save(item), JsonRequestBehavior.AllowGet);
		//	}
		//	catch
		//	{
		//		return Json("Kay�t eklenemedi.");
		//	}
		//}
		//public JsonResult GetbyID(int ID)
		//{
		//	getBusineesLayer = new BusinessLayer();
		//	var cariValue = getBusineesLayer.GetAll().Find(x => x.ID == ID);
		//	return Json(cariValue, JsonRequestBehavior.AllowGet);
		//}
		//public JsonResult Update(DataModel item)
		//{
		//	try
		//	{
		//		getBusineesLayer = new BusinessLayer();
		//		return Json(getBusineesLayer.Update(item), JsonRequestBehavior.AllowGet);
		//	}
		//	catch
		//	{
		//		return Json("Kay�t g�ncellenemedi.");
		//	}
		//}
		//public JsonResult Delete(int ID)
		//{
		//	try
		//	{
		//		getBusineesLayer = new BusinessLayer();
		//		return Json(getBusineesLayer.Delete(ID), JsonRequestBehavior.AllowGet);
		//	}
		//	catch
		//	{
		//		return Json("Kay�t silinemedi.");
		//	}
		//}
	}
}
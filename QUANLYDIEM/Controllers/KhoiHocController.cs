using BLL;
using BLL.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using Newtonsoft.Json;
using QUANLYDIEM.Models;

namespace QUANLYDIEM.Controllers
{
    //[Authorize]
    public class KhoiHocController : Controller
    {
        // GET: KhoiHoc

        public ActionResult KhoiHoc()
        {
            return View();
        }
        IKhoiHocBLL k = new KhoiHocBLL();
       
        public ActionResult GetKhoiHocList()
        {
            
            var list = k.getAll();
            KhoiHocModel model = new KhoiHocModel();
            model.list_KhoiHoc = list;
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AjaxAddKhoiHoc(KhoiHoc obj)
        {
            try
            {
                if (obj != null)
                {
                    int result = k.Insert(obj);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else return Json(-1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetKhoiHocbyID(int makh)
        {
            try
            {
                //JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var obj = k.getmaKhoiHoc_ID(makh);
               // var result = JsonConvert.SerializeObject(obj, Formatting.Indented, jss);
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult AjaxUpdateKhoiHoc(KhoiHoc obj)
        {
            try
            {
                if (obj != null)
                {
                    int result = k.Update(obj);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else return Json(-1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult AjaxDeleteKhoiHoc(int makhoihoc)
        {
          //  try
            {
                k.Delete(makhoihoc);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            //catch (Exception)
            //{
            //    return Json(-1, JsonRequestBehavior.AllowGet);
            //}
        }
    }
}
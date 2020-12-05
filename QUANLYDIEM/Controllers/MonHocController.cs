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
   
    public class MonHocController : Controller
    {
        // GET: MonHoc
        public ActionResult MonHoc()
        {
            return View();
        }
        IMonHocBLL k = new MonHocBLL();

        public ActionResult GetMonHocList()
        {

            var list = k.getAll();
            MonHocModel model = new MonHocModel();
            model.list_MonHoc = list;
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AjaxAddMonHoc(MonHoc obj)
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
            catch
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetMonHocbyID(int mamonhoc)
        {
            try
            {
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var obj = k.getmaMonHoc(mamonhoc);
                var result = JsonConvert.SerializeObject(obj, Formatting.Indented, jss);
                return this.Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult AjaxUpdateMonHoc(MonHoc obj)
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
            catch
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult AjaxDeleteMonHoc(int mamonhoc)
        {
            try
            {
                k.Delete(mamonhoc);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
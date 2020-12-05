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
    
    public class LoaiDiemController : Controller
    {
        
        public ActionResult LoaiDiem()
        {
            return View();
        }
        ILoaiDiemBLL k = new LoaiDiemBLL();

        public ActionResult GetLoaiDiemList()
        {

            var list = k.getAll();
            LoaiDiemModel model = new LoaiDiemModel();
            model.list_LoaiDiem = list;
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AjaxAddLoaiDiem(LoaiDiem obj)
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
        public JsonResult GetLoaiDiembyID(int maloaidiem)
        {
            try
            {
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var obj = k.getmaLoaiDiem(maloaidiem);
                var result = JsonConvert.SerializeObject(obj, Formatting.Indented, jss);
                return this.Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult AjaxUpdateLoaiDiem(LoaiDiem obj)
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
        public ActionResult AjaxDeleteLoaiDiem(int maloaidiem)
        {
            try
            {
                k.Delete(maloaidiem);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
using BLL;
using BLL.ServiceInterface;
using DTO;
using Newtonsoft.Json;
using QUANLYDIEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANLYDIEM.Controllers
{
    public class LopHocController : Controller
    {
        // GET: LopHoc
        ILopHocBLL lh = new LopHocBLL();
        public ActionResult LopHoc()
        {
            return View();
        }
        //public ActionResult GetHocSinhList(int PageNo, int PageSize, string Tenhocsinh, string Quequan)
        //{
        //    int RecordCount;
        //    var list = hs.getAll(PageNo, PageSize, Tenhocsinh, Quequan, out RecordCount);
        //    HocSinhModel model = new HocSinhModel();
        //    model.list_HocSinh = list;
        //    model.TotalRecords = RecordCount;
        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult GetLopHoc()
        {

            var list = lh.getAll();
            LopHocModel model = new LopHocModel();
            model.list_LopHoc = list;

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AjaxAddHocSinh(LopHoc obj)
        {
            try
            {
                if (obj != null)
                {
                    int result = lh.Insert(obj);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else return Json(-1, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetLopHocbyID(int malop)
        {
            try
            {
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var obj = lh.getmaLopHoc_ID(malop);
                var result = JsonConvert.SerializeObject(obj, Formatting.Indented, jss);
                return this.Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult AjaxUpdateLopHoc(LopHoc obj)
        {
            try
            {
                if (obj != null)
                {
                    int result = lh.Update(obj);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else return Json(-1, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult AjaxDeleteLopHoc(int mahocsinh)
        {
            try
            {
                lh.Delete(mahocsinh);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
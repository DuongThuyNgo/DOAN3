using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BLL.ServiceInterface;
using DTO;
using Newtonsoft.Json;
using QUANLYDIEM.Models;


namespace QUANLYDIEM.Controllers
{
    //[Authorize]
    public class DiemController : Controller
    {
        IDiemBLL hs = new DiẹmBLL();
        public ActionResult Diem()
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
        public ActionResult GetDiem()
        {

            var list = hs.getAll();
            DiemModel model = new DiemModel();

            model.list_Diem = list;

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AjaxAddDiem(Diem obj)
        {
            try
            {
                if (obj != null)
                {
                    int result = hs.Insert(obj);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else return Json(-1, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
        //public JsonResult GetHocSinhbyID(int magv)
        //{
        //    try
        //    {
        //        JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
        //        var obj = hs.getmaGiaoVien(magv);
        //        var result = JsonConvert.SerializeObject(obj, Formatting.Indented, jss);
        //        return this.Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception)
        //    {
        //        return Json(-1, JsonRequestBehavior.AllowGet);
        //    }
        //}
        public JsonResult AjaxUpdateDiem(Diem obj)
        {
            try
            {
                if (obj != null)
                {
                    int result = hs.Update(obj);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else return Json(-1, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult AjaxDeleteDiem(int madiem)
        {
            try
            {
                hs.Delete(madiem);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }


    }
}
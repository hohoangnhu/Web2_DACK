using BabyShopConnection;
using DACK_WEB2.Areas.Admin.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACK_WEB2.Areas.Admin.Controllers
{
    public class QLNhaSanXuatController : Controller
    {
        // GET: Admin/QLNhaSanXuat
        public ActionResult Index()
        {
            var ds = QLNhaSanXuatbus.HienThiDanhSachNSX();
            return View(ds);
        }

        // GET: Admin/QLNhaSanXuat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/QLNhaSanXuat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QLNhaSanXuat/Create
        [HttpPost]
        public ActionResult Create(nhasanxuat nsx)
        {
            if (HttpContext.Request.Files.Count > 0)
            {
                var hpf = HttpContext.Request.Files[0];
                if (hpf.ContentLength > 0)
                {
                    string fileName = Guid.NewGuid().ToString();

                    string fullPathWithFileName = "~/images/home/" + fileName + ".jpg";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    nsx.LoGoURL = fileName + ".jpg";
                }
            }
            QLNhaSanXuatbus.ThemNhaSanXuat(nsx);
            return RedirectToAction("Index");
        }

        // GET: Admin/QLNhaSanXuat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/QLNhaSanXuat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/QLNhaSanXuat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/QLNhaSanXuat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

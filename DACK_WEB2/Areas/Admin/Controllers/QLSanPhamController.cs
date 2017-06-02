using BabyShopConnection;
using DACK_WEB2.Areas.Admin.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACK_WEB2.Areas.Admin.Controllers
{
    public class QLSanPhamController : Controller
    {
        // GET: Admin/QLSanPham
        public ActionResult Index()
        {
            var ds = QLsanphambus.DanhSachSanPham();
            return View(ds);
        }

        // GET: Admin/QLSanPham/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/QLSanPham/Create
        public ActionResult Create()
        {

            ViewBag.MaNhaSanXuat = new SelectList(QLNhaSanXuatbus.HienThiDanhSachNSX(), "MaNhaSanXuat", "TenNhaSanXuat");
            ViewBag.MaLoaiSanPham = new SelectList(QLloaisanphambus.HienThiLoaiSanPham(), "MaLoaiSanPham", "TenLoaiSanPham");
            return View();
        }

        // POST: Admin/QLSanPham/Create
        [HttpPost]
        public ActionResult Create(sanpham sp)
        {
            if (HttpContext.Request.Files.Count > 0)
            {
                var hpf = HttpContext.Request.Files[0];
                if (hpf.ContentLength > 0)
                {
                    string fileName = Guid.NewGuid().ToString();

                    string fullPathWithFileName = "~/images/home/" + fileName + ".jpg";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.HinhAnh = fileName + ".jpg";
                }
            }

            sp.SoLuongBan = 0;
            sp.SoLuongXem = 0;
            sp.BiXoa = 0;
            //sp.NgayNhap = DateTime.Now;
            QLsanphambus.ThemSanPham(sp);
            return RedirectToAction("Index");
        }

        // GET: Admin/QLSanPham/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.MaNhaSanXuat = new SelectList(QLNhaSanXuatbus.HienThiDanhSachNSX(), "MaNhaSanXuat", "TenNhaSanXuat");
            ViewBag.MaLoaiSanPham = new SelectList(QLloaisanphambus.HienThiLoaiSanPham(), "MaLoaiSanPham", "TenLoaiSanPham");
            return View(QLsanphambus.ChiTietSanPham(id));
        }

        // POST: Admin/QLSanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, sanpham sp)
        {
            //try
            //{
            //    // TODO: Add update logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
            if (HttpContext.Request.Files.Count > 0)
            {
                var hpf = HttpContext.Request.Files[0];
                if (hpf.ContentLength > 0)
                {
                    string fileName = Guid.NewGuid().ToString();

                    string fullPathWithFileName = "~/images/home/" + fileName + ".jpg";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.HinhAnh = fileName + ".jpg";
                }
            }
            QLsanphambus.EditSanPham(id, sp);
            return RedirectToAction("Index");
        }

        // GET: Admin/QLSanPham/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/QLSanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, sanpham sp)
        {
            //try
            //{
            //    // TODO: Add delete logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
            QLsanphambus.DeleteSanPham(id, sp);
            return RedirectToAction("Index");
        }
    }
}

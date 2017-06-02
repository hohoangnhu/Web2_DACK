using BabyShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACK_WEB2.Areas.Admin.Models.BUS
{
    public class QLsanphambus
    {
        public static IEnumerable<sanpham> DanhSachSanPham()
        {
            var db = new BabyShopConnectionDB();
            return db.Query<sanpham>("SELECT * FROM SanPham WHERE BiXoa <> 1 ORDER BY MaSanPham DESC");
        }

        public static sanpham ChiTietSanPham(int id)
        {
            var db = new BabyShopConnectionDB();
            return db.SingleOrDefault<sanpham>("SELECT * FROM SanPham WHERE MaSanPham = @0", id);
        }

        public static void ThemSanPham(sanpham sp)
        {
            var db = new BabyShopConnectionDB();
            db.Insert(sp);
        }

        public static void EditSanPham(int id, sanpham sp)
        {
            var db = new BabyShopConnectionDB();
            db.Update<sanpham>("SET TenSanPham=@0, MoTa=@1, XuatXu=@2, MaNhaSanXuat=@3, GiaBan=@4, SoLuongBan=@5, SoLuongTon=@6, MaLoaiSanPham=@7, HinhAnh=@8 where MaSanPham=@9", sp.TenSanPham, sp.MoTa, sp.XuatXu, sp.MaNhaSanXuat, sp.GiaBan, sp.SoLuongBan, sp.SoLuongTon, sp.MaLoaiSanPham, sp.HinhAnh, id);
        }

        public static void DeleteSanPham(int id, sanpham sp)
        {
            var db = new BabyShopConnectionDB();
            db.Delete<sanpham>("WHERE MaSanPham = @0", id);
        }
    }
}
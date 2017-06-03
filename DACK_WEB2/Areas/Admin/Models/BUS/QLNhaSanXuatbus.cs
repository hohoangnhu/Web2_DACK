using BabyShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACK_WEB2.Areas.Admin.Models.BUS
{
    public class QLNhaSanXuatbus
    {
        public static IEnumerable<nhasanxuat> HienThiDanhSachNSX()
        {
            var db = new BabyShopConnectionDB();
            return db.Query<nhasanxuat>("SELECT * FROM nhasanxuat WHERE BiXoa = 0");
        }

        public static nhasanxuat ChiTietNSX(int id)
        {
            using (var db = new BabyShopConnectionDB())
            {
                return db.Query<nhasanxuat>("SELECT * FROM nhasanxuat WHERE MaNhaSanXuat = @0", id).FirstOrDefault();
            }

        }
        public static void ThemNhaSanXuat(nhasanxuat nsx)
        {
            var db = new BabyShopConnectionDB();
            db.Insert(nsx);
        }
        public static void EditNhaSanXuat(int id, nhasanxuat nsx)
        {
            var db = new BabyShopConnectionDB();
            db.Update<nhasanxuat>("SET TenNhaSanXuat=@0, LoGoURL=@1, BiXoa=@2 where MaNhaSanXuat=@3", nsx.TenNhaSanXuat, nsx.LoGoURL, nsx.BiXoa, id);
        }
    }
}
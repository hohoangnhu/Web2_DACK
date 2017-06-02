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
    }
}
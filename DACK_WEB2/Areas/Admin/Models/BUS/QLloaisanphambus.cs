using BabyShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACK_WEB2.Areas.Admin.Models.BUS
{
    public class QLloaisanphambus
    {
        public static IEnumerable<loaisanpham> HienThiLoaiSanPham()
        {
            using (var db = new BabyShopConnectionDB())
            {
                return db.Query<loaisanpham>("SELECT * FROM loaisanpham WHERE BiXoa = 0");
            }
        }
    }
}
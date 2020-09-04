using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Areas.Admin.Models
{
    public class BookEditModel
    {
        public string tenSach { get; set; }
        public string tenTacGia { get; set; }
        public int loaiSach { get; set; }
        public int maSach { get; set; }

        public decimal gia { get; set; }

        public int soLuong { get; set; }
        public string hinhAnh { get; set; }
        public string moTa { get; set; }
        public DateTime ngayXuatBan { get; set; }
        public int khuyenMai { get; set; }
    }
}
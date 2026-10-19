namespace Bai2.Models
{
    public class ProvinceItem
    {
        public int code { get; set; }
        public string name { get; set; } = string.Empty;
        public string? division_type { get; set; }
        public string? codename { get; set; }
        public int? phone_code { get; set; }
        public List<WardItem>? wards { get; set; }

        public override string ToString() => name;
    }

    public class WardItem
    {
        public int code { get; set; }
        public string name { get; set; } = string.Empty;
        public string? division_type { get; set; }
        public string? codename { get; set; }
        public int? province_code { get; set; }

        public override string ToString() => name;
    }

    public class PhongTroDisplay
    {
        public int MaPhong { get; set; }
        public string TenPhong { get; set; } = string.Empty;
        public decimal GiaThue { get; set; }
        public string TinhTrang { get; set; } = string.Empty;
        public string DisplayText => $"{TenPhong} - {GiaThue:N0} đ";

        public override string ToString() => DisplayText;
    }

    public class KhachThueViewModel
    {
        public int MaKhach { get; set; }
        public string HoTen { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public string TenPhong { get; set; } = string.Empty;
        public string GiaThue { get; set; } = string.Empty;
        public string QueQuan { get; set; } = string.Empty;
        public bool DaDangKyTamTru { get; set; }

        public int? MaPhong { get; set; }
        public string? MaTinh { get; set; }
        public string? TenTinh { get; set; }
        public int? MaPhuongXa { get; set; }
        public string? TenPhuongXa { get; set; }
        public int? GioiTinh { get; set; }
        public DateOnly? NgaySinh { get; set; }
        public decimal RawGiaThue { get; set; }
    }
}

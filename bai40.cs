using System;
using System.Collections.Generic;

class SanPham
{
    public string Ten { get; set; }
    public string MoTa { get; set; }
    public double Gia { get; set; }

    public SanPham(string ten, string moTa, double gia)
    {
        Ten = ten;
        MoTa = moTa;
        Gia = gia;
    }

    public override string ToString()
    {
        return $"Tên: {Ten}, Mô tả: {MoTa}, Giá: {Gia} VND";
    }
}

class Program
{
    static List<SanPham> danhSachSanPham = new List<SanPham>();

    static void Main(string[] args)
    {
        int luaChon;
        do
        {
            Console.WriteLine("1. Thêm sản phẩm mới");
            Console.WriteLine("2. Hiển thị danh sách sản phẩm");
            Console.WriteLine("3. Tìm kiếm sản phẩm theo tên");
            Console.WriteLine("4. Thoát");
            Console.Write("Nhập lựa chọn của bạn: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    ThemSanPhamMoi();
                    break;
                case 2:
                    HienThiDanhSachSanPham();
                    break;
                case 3:
                    TimKiemSanPhamTheoTen();
                    break;
                case 4:
                    Console.WriteLine("Thoát chương trình.");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                    break;
            }
        } while (luaChon != 4);
    }

    static void ThemSanPhamMoi()
    {
        Console.Write("Nhập tên sản phẩm: ");
        string ten = Console.ReadLine();
        Console.Write("Nhập mô tả sản phẩm: ");
        string moTa = Console.ReadLine();
        Console.Write("Nhập giá sản phẩm: ");
        double gia = double.Parse(Console.ReadLine());

        SanPham sp = new SanPham(ten, moTa, gia);
        danhSachSanPham.Add(sp);
        Console.WriteLine("Đã thêm sản phẩm thành công!");
    }

    static void HienThiDanhSachSanPham()
    {
        Console.WriteLine("Danh sách sản phẩm:");
        foreach (SanPham sp in danhSachSanPham)
        {
            Console.WriteLine(sp);
        }
    }

    static void TimKiemSanPhamTheoTen()
    {
        Console.Write("Nhập tên sản phẩm cần tìm: ");
        string ten = Console.ReadLine();
        bool found = false;
        foreach (SanPham sp in danhSachSanPham)
        {
            if (sp.Ten.Equals(ten, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(sp);
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Không tìm thấy sản phẩm nào với tên: " + ten);
        }
    }
}
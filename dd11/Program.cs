using System;
using System.Globalization;
using System.Text;

class Program
{
    // Danh sách bánh và giá tương ứng
    static string[] tenBanh = { "Bánh mì", "Bánh kem", "Bánh quy", "Bánh sừng bò" };
    static double[] giaBanh = { 5000, 20000, 10000, 15000 };

    //  Tính tiền theo tên bánh (mảng)
    static double TinhTien(int viTri, int soLuong)
    {
        return giaBanh[viTri] * soLuong;
    }

    //  Xếp loại đơn hàng
    static string XepLoaiDon(double tongTien)
    {
        return tongTien > 100000 ? "Đơn lớn" : "Đơn thường";
    }

    //  Hiển thị thông tin đơn hàng
    static void HienThiThongTin(string tenBanh, int soLuong, double tongTien, string loaiDon)
    {
        Console.WriteLine("\n--- Thông tin đơn hàng ---");
        Console.WriteLine($"Bánh       : {tenBanh}");
        Console.WriteLine($"Số lượng   : {soLuong}");
        Console.WriteLine($"Tổng tiền  : {tongTien:N0} VNĐ");
        Console.WriteLine($"Phân loại  : {loaiDon}");
        Console.WriteLine("--------------------------\n");
    }

    static void Main()
    {
        //  Cho phép in tiếng Việt không lỗi font
        Console.OutputEncoding = Encoding.UTF8;

        //  Lời chào
        Console.WriteLine("🍞 CHÀO MỪNG ĐẾN VỚI HỆ THỐNG QUẢN LÝ ĐƠN HÀNG TIỆM BÁNH MINI 🍰");
        Console.WriteLine("Nhập số (1, 2, 3, 4) để chọn bánh và nhập số lượng.");
        Console.WriteLine("Nhập 'exit' để kết thúc và xem thống kê.\n");

        // Biến thống kê
        int tongSoDon = 0;
        double tongDoanhThu = 0;
        int soDonLon = 0;
        int soDonThuong = 0;

        while (true)
        {
            //  Hiển thị menu bánh
            Console.WriteLine("--- MENU BÁNH ---");
            for (int i = 0; i < tenBanh.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {tenBanh[i]} - {giaBanh[i]:N0} VNĐ");
            }

            Console.Write("\nNhập số (hoặc 'exit' để thoát): ");
            string input = Console.ReadLine().Trim();

            if (input.ToLower() == "exit")
            {
                break;
            }

            // Kiểm tra số nhập vào có hợp lệ không
            int viTri;
            if (!int.TryParse(input, out viTri) || viTri < 1 || viTri > 4)
            {
                Console.WriteLine("❌ Lựa chọn không hợp lệ. Vui lòng nhập lại số từ 1 đến 4.\n");
                continue;
            }

            viTri--;  // Điều chỉnh chỉ số (mảng bắt đầu từ 0)

            // Nhập số lượng
            Console.Write("Nhập số lượng: ");
            string slStr = Console.ReadLine();
            int soLuong;

            if (!int.TryParse(slStr, out soLuong) || soLuong <= 0)
            {
                Console.WriteLine("❌ Số lượng không hợp lệ. Vui lòng thử lại.\n");
                continue;
            }

            //  Tính tiền
            double tongTien = TinhTien(viTri, soLuong);

            //  Phân loại đơn
            string loaiDon = XepLoaiDon(tongTien);

            //  Cập nhật thống kê
            tongSoDon++;
            tongDoanhThu += tongTien;
            if (loaiDon == "Đơn lớn")
                soDonLon++;
            else
                soDonThuong++;

            //  Hiển thị thông tin đơn hàng
            HienThiThongTin(tenBanh[viTri], soLuong, tongTien, loaiDon);
        }

        //  Thống kê cuối ngày
        Console.WriteLine("\n📊 THỐNG KÊ CUỐI NGÀY 📊");
        Console.WriteLine($"Tổng số đơn hàng : {tongSoDon}");
        Console.WriteLine($"Tổng doanh thu   : {tongDoanhThu:N0} VNĐ");
        Console.WriteLine($"Số đơn lớn       : {soDonLon}");
        Console.WriteLine($"Số đơn thường    : {soDonThuong}");
        Console.WriteLine("🎉 Cảm ơn bạn đã sử dụng hệ thống!");
    }
}
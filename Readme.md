# Web quản lý quán cafe

**Khách hàng:**

1. Đăng nhập, đăng ký: Khách hàng có thể đăng nhập vào đăng ký để đặt món, đặt giao món, thanh toán,...
2. Đặt món: Khách hàng đặt món mà mình mong muốn.
3. Đặt giao món: Khách hàng đặt món và giao đến điểm đến mong muốn.
4. Thanh toán: Nếu khách hàng sử dụng dịch vụ trực tiếp tại quán thì có thể gọi nhân viên đến thanh toán trên web.
---
**Quản lý:**

1. Quản lý nhập hàng và pha chế:
2. Yêu cầu nhập hàng: Quản lý các đơn hàng nguyên liệu mà quán mua vào.
3. Kiểm tra hàng: Kiểm kê đơn hàng nguyên liệu mà quán đang chuẩn bị mua.
4. Nhập hàng vào kho: Sau khi kiểm kê xong, quán chuẩn bị thanh toán và đưa các hàng nguyên liệu vào kho.
5. Tạo hóa đơn nhập: Khi thanh toán, tạo một hóa đơn bao gồm: loại nguyên liệu số lượng, giá cả.
6. Lưu vào database: Sau khi đã xong bước thanh toán, hóa đơn sẽ được quản lý lưu vào database.
---
**Quản lý bộ phận phục vụ:**
1. Yêu cầu đồ uống: Sau khi khách hàng đặt món thì sẽ có hàng chờ yêu cầu phục vụ đồ uống cho nhân viên.
2. Phục vụ đồ uống: Phân từng phiên phục vụ cho từng nhân viên.
3. In hóa đơn thanh toán: Sau khi khách hàng thanh toán, in hóa đơn cho khách hàng.
4. Lưu dữ liệu vào máy tính: Lưu các thông tin hóa đơn khách hàng đã thanh toán vào database.
5. Quản lý thu chi sổ sách: 
6. Nhập số liệu vào máy tính: Tổng hợp các hóa đơn, chứng từ (nhập, khách hàng, xuất,...) để lưu vào database.
7. Xuất biên lai khách hàng: Xuất ra cả biên lai đi kèm với hóa đơn của từng khách hàng.
8. Lập báo cáo tổng kết doanh thu: Truy vấn database để lập báo cáo tổng kết doanh thu.
---
**database:**
GiaBan(ID, MaSP, NgayAD,Gia,TrangThai)
product (có hai loai: sp dong chai, sp pha chê)
danh mục san phẩm
phieunhap(MaPN, MaNV, Ngay nhâp
ChiTietPhieuNhap(MaPN,MaSP, SL, DonG…)
NguyenVatLieu()
DinhMucNguyenLieu(MasP, MaNguyenLieu, DinhMuc, tyle 10%
Hoa don()
ChiTietHoaDon()

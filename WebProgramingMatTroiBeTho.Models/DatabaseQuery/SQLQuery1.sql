
create database QuanLyCF
go
use [QuanLyCF]
go
Create table BaiViet (
		IDBaiViet int IDENTITY(1,1) NOT NULL,
		TenNoiDung nvarchar(50),
		NoiDung nvarchar(255),
		TinhTrang BIT
);
go

Create proc PSH_HienThiBaiViet
as
select *
from BaiViet
go
exec PSH_HienThiBaiViet
go

Create proc PSH_ThemBaiVietHoacSua  @ID int, @TenBaiViet nvarchar(50), @NoiDung nvarchar(255), @TinhTrang BIT
as
if exists (select 1 from BaiViet where IDBaiViet = @ID)
bEGIN
	Update BaiViet
	Set TenNoiDung = @TenBaiViet, NoiDung = @NoiDung, TinhTrang = @TinhTrang
	where IDBaiViet = @ID
end
else 
Begin 
Insert into BaiViet (TenNoiDung,NoiDung,TinhTrang)
  values(@TenBaiViet, @NoiDung, @TinhTrang)
  end
go
exec PSH_ThemBaiVietHoacSua 1,"Bao nhiêu lâu bán được 1 tỷ gói mè", "ahihi đồ nghốc vler", 1
go

Create proc PSH_XoaBaiViet @ID int
as
Update BaiViet
set TinhTrang = 0
where IDBaiViet = @ID
go

Create table TaiKhoan(
	MaTK int primary key not null,
	TenDangNhap nvarchar(50) not null,
	MatKhau varchar(50) not null,
	LoaiTaiKhoan int not null,
	TinhTrang bit not null
)
Create table LoaiTaiKhoan(
	ID int primary key not null,
	LoaiTaiKhoan nvarchar(50),
	TinhTrang bit
)
select * from BaiViet
go
--login check

Create PROC [dbo].[SPH_Account_Login_Admin]
    @UserName VARCHAR(20) ,
    @PassWord VARCHAR(20)
AS
    BEGIN
        DECLARE @count INT;
        DECLARE @res BIT;
		Declare @LoaiTK int;
        SELECT  @count = COUNT(*)
        FROM    TaiKhoan
        WHERE   TaiKhoan.TenDangNhap = @UserName
                AND TaiKhoan.MatKhau = @PassWord AND TaiKhoan.LoaiTaiKhoan = 1;
        IF @count > 0
            SET @res = 1;
        ELSE
            SET @res = 0;
        SELECT  @res;	
    END;
GO

Create PROC [dbo].[SPH_Account_Login_User]
    @UserName VARCHAR(20) ,
    @PassWord VARCHAR(20)
AS
    BEGIN
        DECLARE @count INT;
        DECLARE @res BIT;
		Declare @LoaiTK int;
        SELECT  @count = COUNT(*)
        FROM    TaiKhoan
        WHERE   TaiKhoan.TenDangNhap = @UserName
                AND TaiKhoan.MatKhau = @PassWord AND TaiKhoan.LoaiTaiKhoan = 2;
        IF @count > 0
            SET @res = 1;
        ELSE
            SET @res = 0;
        SELECT  @res;	
    END;
GO
exec SPH_Account_Login_Admin "hieukenken7777","110401"
go
go
---Thêm bảng khách hàng
create table KhachHang(
        MaKH char(10),
        TenKH nvarchar(50),
        GioiTinh bit,
        DiaChi nvarchar(200),
        SDT int ,
        Email nvarchar(50),
        LoaiTaiKhoan int,
        TinhTrang bit
)

create table SanPham(
    MaSP char(10) primary key,
    IDAnh int,
    TenSP nvarchar(100),
    DinhDanhSP nvarchar(200),
    DonGia float,
    SoLuong int,
    ChiTietSanPham nvarchar(500),
    MaDVT int,
    LoaiSP nvarchar(50),
    TinhTrang bit
)

Create table DonViTinh(
    MaDVT int IDENTITY(1,1) primary key,
    TenDVT nvarchar(50),
    isDelete bit
)


-- proc xem danh sacsh san pham ( Hình ảnh mình cho 1 ảnh cho dễ khỏi mệt :)) nên lúc tạo m chuyển sang kiểu nvarchar hoặc iamge nha <3 )
create proc NHP_SanPham_Select
as 
select sp.MaSP,IDAnh, TenSP,SoLuong,LoaiSP,dv.TenDVT
from SanPham sp inner join DonViTinh dv 
on sp.MaDVT=dv.MaDVT

--Proc Them san pham (danh cho admin)
create proc NHP_SanPham_ADD
@MaSP char(10) ,
    @IDAnh int,
    @TenSP nvarchar(100),
    @DinhDanhSP nvarchar(200),
    @DonGia float,
    @SoLuong int,
    @ChiTietSanPham nvarchar(500),
    @MaDVT int,           
    @LoaiSP nvarchar(50)  --Loại gồm đóng chai và pha chế :)
as
insert into SanPham(MaSP,IDAnh,TenSP,DinhDanhSP,DonGia,SoLuong,ChiTietSanPham,MaDVT,LoaiSP,TinhTrang)
values (@MaSP,@IDAnh,@TenSP,@DinhDanhSP,@DonGia,@SoLuong,@ChiTietSanPham,@MaDVT,@LoaiSP,@TinhTrang)

--Proc sửa sản phâm nè (admin)
create proc NHP_SanPham_UpdatesNe
@MaSP char(10) ,
    @IDAnh int,
    @TenSP nvarchar(100),
    @DinhDanhSP nvarchar(200),
    @DonGia float,
    @SoLuong int,
    @ChiTietSanPham nvarchar(500),
    @MaDVT int,           
    @LoaiSP nvarchar(50)  --Loại gồm đóng chai và pha chế :)
as
IF EXISTS (SELECT 1 FROM SanPham WHERE MaSP=@MaSP AND TinhTrang=1 )
begin --updates
 update SanPham
 set MaSP=@MaSP,
     TenSP=@TenSP,
     DinhDanhSP=@DinhDanhSP,
     DonGia=@DonGia,
     SoLuong=@SoLuong,
     ChiTietSanPham=@ChiTietSanPham,
     MaDVT=@MaDVT,
     LoaiSP=@LoaiSP,
     TinhTrang=1
      WHERE MaSP=@MaSP AND TinhTrang=1
end
 -- proc xóa sản phẩm
 create proc NHP_SanPham_UpdatesNe
@MaSP char(10) 
as
IF EXISTS (SELECT 1 FROM SanPham WHERE MaSP=@MaSP AND TinhTrang=1 )
begin --updates
 update SanPham
 set MaSP=@MaSP,    
     TinhTrang=0
WHERE MaSP=@MaSP AND TinhTrang=1
end
---Proc them sp
ALTER proc [dbo].[NHP_SanPham_ADD]
	@id nvarchar(10),
    @TenSP NVARCHAR(100),
    @IDAnh int,
    @DonGia INT ,
    @SoLuong int ,
    @ChiTietSanPham nvarchar(200) ,
    @LoaiSP nvarchar(50),
	@TinhTrang bit
AS
IF EXISTS (SELECT 1 FROM dbo.SanPham where MaSP=@id)
BEGIN
    UPDATE SanPham
	SET  TenSP=@TenSP,IDAnh=@IDAnh,DonGia=@DonGia,SoLuong=@SoLuong,ChiTietSanPham=@ChiTietSanPham,LoaiSP=@LoaiSP,TinhTrang=@TinhTrang
	WHERE MaSP=@id
END
ELSE	
BEGIN
     INSERT  INTO SanPham(MaSP,TenSP,IDAnh,DonGia,SoLuong,ChiTietSanPham,LoaiSP,TinhTrang )
	VALUES				(@id ,@TenSP,@IDAnh,@DonGia,@SoLuong,@ChiTietSanPham,@LoaiSP,@TinhTrang)
End
---
ALTER proc [dbo].[NHP_Admin_XemHoaDon] 
as
select Orders.MaHD ,Orders.NgayLap, Orders.SDTdathang, Orders.DiaChiNhanHang, Orders.TongTien, Orders.GiaoHang
from Orders inner join KhachHang on Orders.SDT = KhachHang.SDT 

ORDER BY Orders.MaHD DESC

--

ALTER proc [dbo].[NHP_ADMIN_ChiTietHD] @id char(13)
as
select ChiTietHOADON.MaHD,HinhAnh.HinhAnh,SanPham.TenSP, ChiTietHOADON.SoLuong, ChiTietHOADON.DonGia, ChiTietHOADON.LoaiHang
from ChiTietHOADON inner join SanPham on ChiTietHOADON.MaSP = SanPham.MaSP
					inner join HinhAnh on ChiTietHOADON.MaSP = HinhAnh.MaSP
where ChiTietHOADON.MaHD = @id

    


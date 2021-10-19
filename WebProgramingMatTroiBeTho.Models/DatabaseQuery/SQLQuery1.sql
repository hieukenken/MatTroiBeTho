
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
	MaTK int primary key IDENTITY(1,1) not null,
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

alter PROC [dbo].[SPH_Account_Login_Admin]
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
                AND TaiKhoan.MatKhau = @PassWord AND TaiKhoan.LoaiTaiKhoan = 1 and TaiKhoan.TinhTrang = 1;
        IF @count > 0
            SET @res = 1;
        ELSE
            SET @res = 0;
        SELECT  @res;	
    END;
GO

create proc SPH_Account_Check
	@UserName varchar(20)
	AS
    BEGIN
        DECLARE @count INT;
        DECLARE @res BIT;

        SELECT  @count = COUNT(*)
        FROM    TaiKhoan
        WHERE   TaiKhoan.TenDangNhap = @UserName
        IF @count > 0
            SET @res = 1;
        ELSE
            SET @res = 0;
        SELECT  @res;	
    END;
GO

exec SPH_Account_Check '0912000812'
go


alter proc SPH_Account_Singup_User_Basic 
	@Username varchar(20),
	@PassWord varchar(20),
	@NameKH varchar(20),
	@LoaiTK int
AS 
begin
	DECLARE @MaKH int;
		Set @MaKH = 0;
		begin
		Insert into TaiKhoan(TenDangNhap,MatKhau,TinhTrang,LoaiTaiKhoan)
		values(@Username, @PassWord, 1, @LoaiTK)

		Select @MaKH = TaiKhoan.MaTK 
		from TaiKhoan
		where TaiKhoan.TenDangNhap = @Username

		Insert into KhachHang(MaKH,TenKH, SDT, LoaiTaiKhoan, TinhTrang)
		values(@MaKH,@NameKH,@Username,@LoaiTK,1)
		end
end


exec SPH_Account_Singup_User_Basic '0912000812', '65622343','Phan',2
go

	

alter PROC [dbo].[SPH_Account_Login_User]
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
                AND TaiKhoan.MatKhau = @PassWord AND TaiKhoan.LoaiTaiKhoan = 2 and TaiKhoan.TinhTrang = 1;
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
        MaKH int primary key ,
        TenKH nvarchar(50),
        GioiTinh bit,
        DiaChi nvarchar(200),
        SDT int ,
        Email nvarchar(50),
        LoaiTaiKhoan int,
        TinhTrang bit
)

Create table SanPham(
    MaSP varchar(10) primary key,
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
go
Create table HinhAnh (
	IDAnh int,
	MaSP varchar(10),
	HinhAnh varchar(255),
)
go

Create table DonViTinh(
    MaDVT int IDENTITY(1,1) primary key,
    TenDVT nvarchar(50),
)
go

alter proc PSH_Select_SanPham 
as 
select SanPham.MaSP, SanPham.TenSP, SanPham.DonGia, SanPham.SoLuong, SanPham.ChiTietSanPham, SanPham.LoaiSP,SanPham.TinhTrang, HinhAnh.HinhAnh
from SanPham inner join HinhAnh on SanPham.IDAnh = HinhAnh.IDAnh
go
exec PSH_Select_SanPham 





    


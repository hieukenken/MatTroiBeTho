
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
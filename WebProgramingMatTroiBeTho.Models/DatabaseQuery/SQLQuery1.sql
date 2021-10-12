
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

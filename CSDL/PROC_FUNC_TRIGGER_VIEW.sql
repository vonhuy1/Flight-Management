use QUANLYCHUYENBAY
go

--------------------SAN BAY--------------------
create view XemSanBay as
select * from SANBAY
go

create trigger TriggerThemSanBay on SANBAY
instead of insert
as
begin
	IF EXISTS (SELECT * FROM inserted WHERE MaSanBay IN (SELECT MaSanBay FROM SANBAY))
	BEGIN
		PRINT N'Ma San Bay Da Ton Tai!'
		ROLLBACK TRANSACTION 
	END
	ELSE
	BEGIN
	     INSERT INTO SANBAY
       SELECT MaSanBay, TenSanBay, ViTri
       FROM inserted
	END
end
go

create proc ThemSanBay
@MaSanBay varchar(20), @TenSanBay nvarchar(45), @ViTri nvarchar(50)
as
begin
	insert into SANBAY values(@MaSanBay, @TenSanBay, @ViTri)
end
go

create trigger TriggerXoaSanBay on SANBAY
instead of delete
as
begin
	IF EXISTS (SELECT * FROM deleted WHERE MaSanBay IN (SELECT MaSanBay FROM SANBAY))
	BEGIN
		IF EXISTS (SELECT * FROM deleted WHERE MaSanBay IN (SELECT SANBAYDI_MaSanBay FROM TUYENBAY))
		BEGIN
			PRINT N'Khong The Xoa San Bay!'
			ROLLBACK TRANSACTION 
		END	
		ELSE
		BEGIN
			IF EXISTS (SELECT * FROM deleted WHERE MaSanBay IN (SELECT SANBAYDEN_MaSanBay FROM TUYENBAY))
			BEGIN
				PRINT N'Khong The Xoa San Bay!'
				ROLLBACK TRANSACTION 
			END
			ELSE
			BEGIN
				IF EXISTS (SELECT * FROM deleted WHERE MaSanBay IN (SELECT SANBAYTRUNGGIAN_MaSanBay FROM TUYENBAY))
				BEGIN
					PRINT N'Khong The Xoa San Bay!'
					ROLLBACK TRANSACTION 				
				END
				ELSE
				BEGIN
					DELETE FROM SANBAY WHERE MaSanBay IN (SELECT MaSanBay FROM deleted)
				END
			END
		END
	END
	ELSE
	BEGIN
		PRINT N'Ma San Bay Khong Ton Tai!'
	END
end
go

create proc XoaSanBay
@MaSanBay varchar(20)
as
begin
	delete from SANBAY where MaSanBay = @MaSanBay
end
go

create trigger TriggerSuaSanBay on SANBAY
instead of update
as
begin
	DECLARE @MaSanBay varchar(20), @TenSanBay nvarchar(45), @ViTri nvarchar(50)
	IF EXISTS (SELECT * FROM inserted WHERE MaSanBay IN (SELECT MaSanBay FROM SANBAY))
	BEGIN
		set @MaSanBay = (select MaSanBay from inserted)
		set @TenSanBay = (select TenSanBay from inserted)
		set @ViTri = (select ViTri from inserted)
		update SANBAY set TenSanBay=@TenSanBay, ViTri=@ViTri where MaSanBay=@MaSanBay
	END
	ELSE
	BEGIN
		PRINT N'Ma San Bay Khong Ton Tai!'
		ROLLBACK TRANSACTION 
	END
end
go

create proc SuaSanBay
@MaSanBay varchar(20), @TenSanBay nvarchar(45), @ViTri nvarchar(50)
as
begin
	update SANBAY set TenSanBay=@TenSanBay, ViTri=@ViTri where MaSanBay=@MaSanBay
end
go

create proc TimSanBay
@MaSanBay varchar(20)
as
begin
	select * from SANBAY where MaSanBay=@MaSanBay
end
go

--------------------TUYEN BAY--------------------
create view XemTuyenBay as
select * from TUYENBAY
go

create function TaoMaTuyenBay(@MaSanBayDi varchar(3), @MaSanBayDen varchar(3))
returns varchar(7)
as
begin
	declare @MaTB varchar(7)
	 set @MaTB = concat(@MaSanBayDi, '-', @MaSanBayDen)
	return @MaTB
end
go

create trigger TriggerThemTuyenBay on TUYENBAY
instead of insert
as
begin
	IF EXISTS (SELECT * FROM inserted WHERE MaTuyenBay IN
	(
	SELECT MaTuyenBay
	FROM TUYENBAY
	))
	BEGIN
		PRINT N'Ma Tuyen Bay Da Ton Tai!'
		ROLLBACK TRANSACTION 
	END
	ELSE
	BEGIN
	     INSERT INTO TUYENBAY
       SELECT MaTuyenBay, SANBAYDI_MaSanBay, SANBAYDEN_MaSanBay, SANBAYTRUNGGIAN_MaSanBay
       FROM inserted
	END
end
go

create proc ThemTuyenBay
@MaSanBayDi varchar(20),  @MaSanBayDen varchar(20),  @MaSanBayTG varchar(20)
as
begin
	declare @MaTuyenBay varchar(20)
	set @MaTuyenBay = dbo.TaoMaTuyenBay(@MaSanBayDi, @MaSanBayDen)
	insert into TUYENBAY values(@MaTuyenBay, @MaSanBayDi, @MaSanBayDen, @MaSanBayTG)
end

go
create trigger TriggerXoaTuyenBay on TUYENBAY
instead of delete
as
begin
	IF EXISTS (SELECT * FROM deleted WHERE MaTuyenBay IN (SELECT MaTuyenBay FROM TUYENBAY))
	BEGIN
		IF EXISTS (SELECT * FROM deleted WHERE MaTuyenBay IN (SELECT TUYENBAY_MaTuyenBay FROM CHUYENBAY))
		BEGIN
			PRINT N'Khong The Xoa Tuyen Bay!'
			ROLLBACK TRANSACTION 
		END	
		ELSE
		BEGIN
			DELETE FROM TUYENBAY WHERE MaTuyenBay IN (SELECT MaTuyenBay FROM deleted)
		END
	END
	ELSE
	BEGIN
		PRINT N'Ma Tuyen Bay Khong Ton Tai!'
	END
end
go

create proc XoaTuyenBay
@MaTuyenBay varchar(20)
as
begin
	delete from TUYENBAY where MaTuyenBay = @MaTuyenBay
end
go

create proc TimTuyenBay
@MaTuyenBay varchar(20)
as
begin
	select * from TUYENBAY where MaTuyenBay = @MaTuyenBay
end
go

--------------------MAY BAY--------------------
create view XemMayBay as
select * from MAYBAY
go

create trigger TriggerThemMayBay on MAYBAY
instead of insert
as
begin
	IF EXISTS (SELECT * FROM inserted WHERE MaMayBay IN (SELECT MaMayBay FROM MAYBAY))
	BEGIN
		PRINT N'Ma May Bay Da Ton Tai!'
		ROLLBACK TRANSACTION 
	END
	ELSE
	BEGIN
	     INSERT INTO MAYBAY
       SELECT MaMayBay, LoaiMayBay, SoGhe
       FROM inserted
	END
end
go

create proc ThemMayBay
@MaMayBay varchar(20),  @LoaiMayBay nvarchar(45),  @SoGhe int
as
begin
	insert into MAYBAY values(@MaMayBay, @LoaiMayBay, @SoGhe)
end
go

create trigger TriggerSuaMayBay on MAYBAY
instead of update
as
begin
	DECLARE @MaMayBay varchar(20), @LoaiMayBay nvarchar(45), @SoGhe int
	IF EXISTS (SELECT * FROM inserted WHERE MaMayBay IN (SELECT MaMayBay FROM MAYBAY))
	BEGIN
		set @MaMayBay = (select MaMayBay from inserted)
		set @LoaiMayBay = (select LoaiMayBay from inserted)
		set @SoGhe = (select SoGhe from inserted)
		update MAYBAY set LoaiMayBay=@LoaiMayBay, SoGhe=@SoGhe where MaMayBay=@MaMayBay
	END
	ELSE
	BEGIN
		PRINT N'Ma May Bay Khong Ton Tai!'
		ROLLBACK TRANSACTION 
	END
end
go

create proc SuaMayBay
@MaMayBay varchar(20), @LoaiMayBay nvarchar(45), @SoGhe int
as
begin
	update MAYBAY set LoaiMayBay=@LoaiMayBay, SoGhe=@SoGhe where MaMayBay=@MaMayBay
end
go

create trigger TriggerXoaMayBay on MAYBAY
instead of delete
as
begin
	IF EXISTS (SELECT * FROM deleted WHERE MaMayBay IN (SELECT MaMayBay FROM MAYBAY))
	BEGIN
		IF EXISTS (SELECT * FROM deleted WHERE MaMayBay IN (SELECT MaMayBay FROM CHUYENBAY))
		BEGIN
			PRINT N'Khong The Xoa May Bay!'
			ROLLBACK TRANSACTION 
		END	
		ELSE
		BEGIN
			DELETE FROM MAYBAY WHERE MaMayBay IN (SELECT MaMayBay FROM deleted)
		END
	END
	ELSE
	BEGIN
		PRINT N'Ma May Bay Khong Ton Tai!'
	END
end
go

create proc XoaMayBay
@MaMayBay varchar(20)
as
begin
	delete from MAYBAY where MaMayBay = @MaMayBay
end
go

create or alter proc TimMayBay
@MaMayBay varchar(20)
as
begin
	select * from MAYBAY where MaMayBay=@MaMayBay
end
go

--TimMayBay 'A320-01'

--------------------CHUYEN BAY--------------------
create view XemChuyenBay as
select * from CHUYENBAY
go

create function TaoMaChuyenBay(@NgayBay Date, @GioKhoiHanh Time, @MaTuyenBay varchar(7))
returns varchar(20)
as
begin
	declare @MaCB varchar(20), @Ngay char(2), @Thang char(2), @Gio char(2), @Phut char(2)
	set @Ngay = DAY(@NgayBay)
	set @Thang = MONTH(@NgayBay)
	set @Gio = DATENAME(HOUR, @GioKhoiHanh)
	set @Phut = DATENAME(MINUTE, @GioKhoiHanh)
	if (@Ngay <= 9)
	begin
		set @Ngay = concat('0', @Ngay)
	end
	if (@Thang <= 9)
	begin
		set @Thang = concat('0', @Thang)
	end
	if (@Gio <= 9)
	begin
		if (@Gio = 0)
		begin
			set @Gio = '00'
		end
		else
		begin
			set @Gio = concat('0', @Gio)
		end
	end
	if (@Phut <= 9)
	begin
		if (@Phut = 0)
		begin
			set @Phut = '00'
		end
		else
		begin
			set @Phut = concat('0', @Phut)
		end
	end
	set @MaCB = concat(@MaTuyenBay, '_', @Ngay, @Thang, YEAR(@NgayBay), @Gio, @Phut)
	return @MaCB
end
go

create trigger TriggerThemChuyenBay on CHUYENBAY
instead of insert
as
begin
	IF EXISTS (SELECT * FROM inserted WHERE MaChuyenBay IN (SELECT MaChuyenBay FROM CHUYENBAY))
	BEGIN
		PRINT N'Ma Chuyen Bay Da Ton Tai!'
		ROLLBACK TRANSACTION 
	END
	ELSE
	BEGIN
	   INSERT INTO CHUYENBAY 
	   SELECT MaChuyenBay, NgayBay, GioKhoiHanh, ThoiGianBay, ThoiGianDuKienDen, SoGheHang1, SoGheHang2, TUYENBAY_MaTuyenBay, MaMayBay 
	   FROM inserted
	END
end
go

create proc ThemChuyenBay
@NgayBay date,  @GioKhoiHanh Time, @ThoiGianBay Time, @ThoiGianDen Time, @SoGheH1 int, @SoGheH2 int, @MaTuyenBay varchar(20), @MaMayBay varchar(20)
as
begin
	declare @MaCB varchar(20)
	set @MaCB = dbo.TaoMaChuyenBay(@NgayBay, @GioKhoiHanh, @MaTuyenBay)
	insert into CHUYENBAY values(@MaCB, @NgayBay, @GioKhoiHanh, @ThoiGianBay, @ThoiGianDen, @SoGheH1, @SoGheH2, @MaTuyenBay, @MaMayBay)
end
go

--ThemChuyenBay '2022-11-08','06:00:00','00:55:00','6:55:00', 50, 100,'SGN-HAN','A320-01'

create trigger TriggerXoaChuyenBay on CHUYENBAY
instead of delete
as
begin
	IF EXISTS (SELECT * FROM deleted WHERE MaChuyenBay IN (SELECT MaChuyenBay FROM CHUYENBAY))
	BEGIN
		IF EXISTS (SELECT * FROM deleted WHERE MaMayBay IN (SELECT CHUYENBAY_MaChuyenBay FROM PHIEUDATCHO))
			BEGIN
				PRINT N'Khong The Xoa Chuyen Bay!'
				ROLLBACK TRANSACTION 
			END	
		ELSE
		BEGIN
			IF EXISTS (SELECT * FROM deleted WHERE MaMayBay IN (SELECT CHUYENBAY_MaChuyenBay FROM VECHUYENBAY))
			BEGIN
				PRINT N'Khong The Xoa Chuyen Bay!'
				ROLLBACK TRANSACTION 
			END	
			ELSE
			BEGIN
				DELETE FROM CHUYENBAY WHERE MaChuyenBay IN (SELECT MaChuyenBay FROM deleted)
			END 
		END
	END
	ELSE
	BEGIN
		PRINT N'Ma Chuyen Bay Khong Ton Tai!'
	END
end
go


create proc XoaChuyenBay
@MaChuyenBay varchar(20)
as
begin
	delete from CHUYENBAY where MaChuyenBay=@MaChuyenBay
end
go

create trigger TriggerSuaChuyenBay on CHUYENBAY
instead of update
as
begin
	DECLARE @MaChuyenBay varchar(20), @ThoiGianBay Time, @ThoiGianDen Time, @SoGheH1 int, @SoGheH2 int, @MaMayBay varchar(20)
	IF EXISTS (SELECT * FROM inserted WHERE MaChuyenBay IN (SELECT MaChuyenBay FROM CHUYENBAY))
	BEGIN
		set @MaChuyenBay = (select MaChuyenBay from inserted)
		set @ThoiGianBay = (select ThoiGianBay from inserted)
		set @ThoiGianDen = (select ThoiGianDuKienDen from inserted)
		set @SoGheH1 = (select SoGheHang1 from inserted)
		set @SoGheH2 = (select SoGheHang2 from inserted)
		set @MaMayBay = (select MaMayBay from inserted)
		update CHUYENBAY 
		 set ThoiGianBay=@ThoiGianBay, ThoiGianDuKienDen=@ThoiGianDen, SoGheHang1=@SoGheH1, SoGheHang2=@SoGheH2, MaMayBay=@MaMayBay 
		 where MaChuyenBay=@MaChuyenBay
	END
	ELSE
	 BEGIN
		PRINT N'Ma Chuyen Bay Khong Ton Tai!'
		ROLLBACK TRANSACTION 
	 END
end
go

create proc SuaChuyenBay
@MaChuyenBay varchar(20), @ThoiGianBay Time, @ThoiGianDen Time, @SoGheH1 int, @SoGheH2 int, @MaMayBay varchar(20)
as
begin
	update CHUYENBAY 
	set ThoiGianBay=@ThoiGianBay, ThoiGianDuKienDen=@ThoiGianDen, SoGheHang1=@SoGheH1, SoGheHang2=@SoGheH2, MaMayBay=@MaMayBay 
	where MaChuyenBay=@MaChuyenBay
end
go

create proc TimChuyenBay
@MaChuyenBay varchar(20)
as
begin
	select * from CHUYENBAY where MaChuyenBay=@MaChuyenBay
end
go
--------------------HANG VE--------------------
create view XemHangVe as
select * from HANGVE
go

create function TaoMaHangVe(@MaChuyenBay varchar(20), @HangVe char(4))
returns varchar(25)
as
begin
	declare @MaHangVe varchar(25)
	set @MaHangVe = CONCAT(@MaChuyenBay, '_', @HangVe)
	return @MaHangVe
end
go

create trigger TriggerThemHangVe on HANGVE
instead of insert
as
begin
	IF EXISTS (SELECT * FROM inserted WHERE MaHangVe IN (SELECT MaHangVe FROM HANGVE))
	BEGIN
		PRINT N'Ma Hang Ve Da Ton Tai!'
		ROLLBACK TRANSACTION 
	END
	ELSE
	BEGIN
		INSERT INTO HANGVE 
		SELECT MaHangVe, VECHUYENBAY, KhoiLuongToiDa, DonGia 
		FROM inserted
	END
end
go

create or alter proc ThemHangVe
@MaChuyenBay varchar(30), @HangVe char(4), @KhoiLuongToiDa int, @DonGia money
as
begin
	declare @MaHangVe varchar(30)
	set @MaHangVe = dbo.TaoMaHangVe(@MaChuyenBay, @HangVe)
	insert into HANGVE values(@MaHangVe, @MaChuyenBay, @KhoiLuongToiDa, @DonGia)
end
go

--ThemHangVe 'SGN-HAN_081120220600', 'HV01', '10', '1700000'

create trigger TriggerXoaHangVe on HANGVE
instead of delete
as
begin
	IF EXISTS (SELECT * FROM deleted WHERE MaHangVe IN (SELECT MaHangVe FROM HANGVE))
	BEGIN
		IF EXISTS (SELECT * FROM deleted WHERE MaHangVe IN (SELECT MAHANGVE FROM PHIEUDATCHO))
			BEGIN
				PRINT N'Khong The Xoa Hang Ve!'
				ROLLBACK TRANSACTION 
			END	
		ELSE
		BEGIN
			DELETE FROM HANGVE WHERE MaHangVe IN (SELECT MaHangVe FROM deleted)
		END
	END
	ELSE
	BEGIN
		PRINT N'Ma Hang Ve Khong Ton Tai!'
	END
end
go


create proc XoaHangVe
@MaHangVe varchar(30)
as
begin
	delete from HANGVE where MaHangVe=@MaHangVe
end
go

create trigger TriggerSuaHangVe on HANGVE
instead of update
as
begin
	DECLARE @MaHangVe varchar(30), @KhoiLuongToiDa int, @DonGia money
	IF EXISTS (SELECT * FROM inserted WHERE MaHangVe IN (SELECT MaHangVe FROM HANGVE))
	BEGIN
		set @MaHangVe = (select MaHangVe from inserted)
		set @KhoiLuongToiDa = (select KhoiLuongToiDa from inserted)
		set @DonGia = (select DonGia from inserted)
		update HANGVE 
		 set KhoiLuongToiDa=@KhoiLuongToiDa, DonGia=@DonGia 
		 where MaHangVe=@MaHangVe
	END
	ELSE
	 BEGIN
		PRINT N'Ma Hang Ve Khong Ton Tai!'
		ROLLBACK TRANSACTION 
	 END
end
go

create proc SuaHangVe
@MaHangVe varchar(30), @KhoiLuongToiDa int, @DonGia money
as
begin
	update HANGVE 
	set KhoiLuongToiDa=@KhoiLuongToiDa, DonGia=@DonGia 
	where MaHangVe=@MaHangVe
end
go

--SuaHangVe 'SGN-HAN_081120220600_HV02', 15, 1750000

create proc TimHangVe
@MaHangVe varchar(30)
as
begin
	select * from HANGVE where MaHangVe=@MaHangVe
end
go

--TimHangVe 'SGN-HAN_081120220600_HV02'

create view XemHoaDon as
select * from HOADON
go
---------KHACHHANG------------------
--trigger CHECK_CMND--
CREATE or alter TRIGGER CHECK_CMND
ON KHACHHANG
INSTEAD OF INSERT
AS
BEGIN
	IF EXISTS (SELECT * FROM inserted WHERE CMND IN
	(
	SELECT CMND
	FROM KHACHHANG
	))
	BEGIN
		PRINT N'Không được chèn 2 khách hàng cùng CMND'
		ROLLBACK TRANSACTION 
	END
	ELSE
	BEGIN
	     INSERT INTO KHACHHANG
       SELECT CMND,TenKH,SDT,GioiTinh,Diachi,NgaySinh
       FROM inserted
	END
END
go
--Không lập phiếu cho hạng ghế
-------------view hiển thị--------------
go
create view HienThiKH
as 
	select CMND,TenKH,SDT,GioiTinh,NgaySinh,Diachi from KHACHHANG
go
-------------PROC Thêm Khách Hàng ---------------
create or alter proc ThemKH
@CMND varchar(20), @TenKH nvarchar(45), @SDT  varchar(20), @GioiTinh   nvarchar(20), @Diachi nvarchar(100), @NgaySinh date
as
begin tran 
	if(@CMND = '' or @TenKH = '' or @SDT = '' or @GioiTinh ='' or @Diachi ='')
		begin
			print N'Thiếu thông tin nhập vào'
			rollback
			return
		end
	insert into KHACHHANG values(@CMND,@TenKH,@SDT,@GioiTinh, @Diachi, @NgaySinh)
	if(@@ERROR <> 0)
		begin
			print N'Lỗi khi insert'
			rollback
			return
		end
commit tran
go

---------------PROC Xóa Khách Hàng----------------
create or alter proc XoaKH
@CMND varchar(20)
as
begin tran
	if not exists (select * from KHACHHANG where CMND = @CMND)
		begin 
			print N'CMND khách hàng không hợp lệ'
			rollback
			return
		end 
	delete from KHACHHANG where CMND = @CMND
	if(@@ERROR <> 0)
		begin
			print N'Lỗi khi Xóa'
			rollback
			return
		end
commit tran
go

create or alter proc SuaKH
@CMND varchar(20), @TenKH nvarchar(45), @SDT  varchar(20), @GioiTinh   nvarchar(20), @Diachi nvarchar(100), @NgaySinh date, @strcmnd varchar(20)
as
begin tran
	if not exists (select * from KHACHHANG where CMND = @strcmnd)
		begin
			print N'CMND không tồn tại'
			rollback
			return
		end
	else
		begin
			update KHACHHANG set
			CMND = @CMND,
			TenKH = @TenKH,
			SDT = @SDT,
			GioiTinh = @GioiTinh,
			Diachi = @Diachi,
			NgaySinh = @NgaySinh
			where CMND = @strcmnd

			if(@@ERROR <> 0)
				begin
					print N'Lỗi khi Chỉnh Sửa'
					rollback
					return
				end
		end
commit tran
go

create function TimKiem_KH(@str nvarchar(50))
returns table
as
	return (
	select CMND,TenKH,SDT,GioiTinh,NgaySinh,Diachi from KHACHHANG
	where CMND like CONCAT('%',@str,'%') or TenKH like CONCAT('%',@str,'%') or SDT like CONCAT('%',@str,'%'))
go
-------------NHANVIEN------------------

CREATE or alter TRIGGER CHECK_CMND_MaNV
ON NHANVIEN
INSTEAD OF INSERT
AS
BEGIN
	IF EXISTS (SELECT * FROM inserted WHERE CMND IN (SELECT CMND FROM NHANVIEN))
	BEGIN
		PRINT N'Không được thêm 2 Nhân Viên cùng CMND'
		ROLLBACK TRANSACTION 
	END
	Else IF EXISTS (SELECT * FROM inserted WHERE MaNV IN (SELECT MaNV FROM NHANVIEN))
	BEGIN
		PRINT N'Không được thêm cùng Mã Nhân Viên'
		ROLLBACK TRANSACTION 
	END
	ELSE
	BEGIN
	   INSERT INTO NHANVIEN
       SELECT *
       FROM inserted
	END
END
go

create view XEMNHANVIEN
as 
	select * from NHANVIEN
go

create or alter proc ThemNV
@MaNV varchar(20), @CMND varchar(20), @TenNV nvarchar(45), @GioiTinh nvarchar(20), @NgaySinh date, @SDT  varchar(20),@Diachi nvarchar(100)
as
begin tran
	if (@MaNV ='' or @CMND ='' or @TenNV ='' or @GioiTinh = '' or @SDT ='' or @Diachi ='')
		begin
			print N'Thiếu thông tin nhập vào'
			rollback
		end
	else
		begin
			insert into NHANVIEN values(@MaNV,@CMND,@TenNV,@GioiTinh,@NgaySinh,@SDT,@Diachi)
			if(@@ERROR <> 0)
				begin
					rollback
				end
		end
commit tran
go

create or alter proc XoaNV
@MaNV varchar(20)
as
begin tran
	if exists (select * from NHANVIEN where MaNV=@MaNV)
		begin 
			if exists (select * from TAIKHOAN where ID_NhanVien = @MaNV)
				begin
					delete from TAIKHOAN where ID_NhanVien = @MaNV
					if(@@ERROR <> 0)
						begin
							rollback
						end
				end
			delete from NHANVIEN where MaNV = @MaNV
			if(@@ERROR <> 0)
				begin
					rollback
				end
		end
	else
		begin
			print N'XÓA NHANVIEN KHÔNG THÀNH CÔNG'
			rollback
		end
commit tran
go 

create or alter proc ChinhSuaNV
@MaNV varchar(20), @CMND varchar(20), @TenNV nvarchar(45), @GioiTinh nvarchar(20), @NgaySinh date, @SDT  varchar(20),@Diachi nvarchar(100)
as 
begin tran
	if exists (select * from NHANVIEN where MaNV=@MaNV)
		begin
			update NHANVIEN
			set
			CMND =@CMND,
			TenNV = @TenNV,
			GioiTinh = @GioiTinh,
			NgaySinh = @NgaySinh,
			SDT = @SDT,
			Diachi = @Diachi
			where MaNV = @MaNV
		end

	else
		begin
			print N'CHỈNH SỬA NHANVIEN KHÔNG THÀNH CÔNG, DO KHÔNG TỒN TẠI MaNV'
			rollback
		end
commit tran
go
create or alter function TimKiem_NV(@str nvarchar(50))
returns table
as
	return (
	select * from NHANVIEN 
	where MaNV like CONCAT('%',@str,'%') or CMND like CONCAT('%',@str,'%') or TenNV like CONCAT('%',@str,'%'))
go
create or alter function TimKiem_NV_Acc(@str nvarchar(50))
returns table
as
	return (
	select * from NHANVIEN 
	where MaNV =@str)
go

------------DOIMATKHAU----------------

create procedure DOIMATKHAU 
@tenTaiKhoan char(20),@matKhau char(20),@matKhauMoi char(20),@matKhauMoiNL char(20)
as
begin
	if(@tenTaiKhoan = '' or @matKhau='' or @matKhauMoi='' or @matKhauMoiNL='')
	begin
		print N'Vui lòng nhập đủ thông tin!'
	end
	else
	begin
	if exists(select *from TAIKHOAN where TenTaiKhoan=@tenTaiKhoan and MatKhau=@matKhau)
		begin
			if(@matKhauMoi=@matKhauMoiNL)
				begin
					update TAIKHOAN set MatKhau=@matKhauMoi where TenTaiKhoan=@tenTaiKhoan
					print N'Đổi mật khẩu thành công'
				end
			else 
				begin
					print N'Mật khẩu nhập lại không đúng'
				end
		end
	else
		begin
			print N'Tên đăng nhập hoặc tài khoản không đúng'
		end
	end
end

go
create procedure SHOWINFORMATION
@tenTaiKhoan char(20)
as
	begin
		select TAIKHOAN.TenTaiKhoan,TAIKHOAN.MatKhau,TAIKHOAN.PHANLOAI,NHANVIEN.TenNV FROM NHANVIEN FULL OUTER JOIN
 TAIKHOAN on NHANVIEN.MaNV=TAIKHOAN.ID_NhanVien where TAIKHOAN.TenTaiKhoan=@tenTaiKhoan 
	end
go
CREATE PROC THONGKE
@d1 datetime, @d2 datetime
as
begin
	select NgayLap,sum(ThanhTien) AS TongTien from HOADON where NgayLap>=@d1 and NgayLap<=@d2 group by NgayLap
end
go
---------DANGNHAP-----------
create function Dang_Nhap(@Username char(20), @Password char(20))
returns table 
as 
	return (select * from TAIKHOAN where TenTaiKhoan = @Username and MatKhau = @Password)

go
----- function -------------------------------------------
create function TimKiem_TuyenBay11(@str nvarchar(45),@str2 nvarchar(45))
returns table
as
	return (
	select MaTuyenBay from TUYENBAY 
	where SANBAYDI_MaSanBay like CONCAT('%',(select MaSanBay from SANBAY where ViTri like CONCAT('%',@str,'%')),'%') and SANBAYDEN_MaSanBay like CONCAT('%',(select MaSanBay from SANBAY where ViTri like CONCAT('%',@str2,'%')),'%') )
	---
go
create function TimKiemKhungGioBay9(@ngaybay date, @matuyenbay varchar(20))
 returns table 
 as
  return (
     select distinct GioKhoiHanh,MaChuyenBay,(select SoGhe from MAYBAY where CHUYENBAY.MaMayBay=MAYBAY.MaMayBay  and NgayBay=@ngaybay  ) as SoGhe from CHUYENBAY,MAYBAY
	 where TUYENBAY_MaTuyenBay like CONCAT('%',@matuyenbay,'%') and NgayBay=@ngaybay  
  )
---- 
go
create function LaySoGhe4(@ngaybay date ,@matuyenbay varchar(20),@giokhoihanh time)
  returns table
  as
   return 
   (
     select distinct GioKhoiHanh,MaChuyenBay,(select SoGhe from MAYBAY where CHUYENBAY.MaMayBay=MAYBAY.MaMayBay  and NgayBay=@ngaybay  ) as SoGhe from CHUYENBAY,MAYBAY
	 where TUYENBAY_MaTuyenBay like CONCAT('%',@matuyenbay,'%') and NgayBay=@ngaybay  and GioKhoiHanh = @giokhoihanh
   )
-----
go
 create proc LayGhe3(@soghe int)
  as
    if( @soghe = 120 )
	 begin 
	  

     select MaGhe,MaHangGhe from SOGHE where PhanLoai = @soghe and @soghe=120
   
  
	 end
	else 
	 
     select MaGhe,MaHangGhe from SOGHE where PhanLoai = @soghe or @soghe=160 or @soghe=120
---------
go
create function LayHangVe_15(@str1 varchar(20))
returns table
 as

  return(
   select MaHangVe,KhoiLuongToiDa 
   from HANGVE
   where  HANGVE.MaHangVe like CONCAT('%',@str1,'%' ) )
   ----
go
   create function LayNguocGioBayvaMaSanBay(@str1 varchar(20))
returns table 
as
      return (
	  select distinct CHUYENBAY.GioKhoiHanh,TUYENBAY.MaTuyenBay,TUYENBAY.SANBAYDEN_MaSanBay,TUYENBAY.SANBAYDI_MaSanBay
from PHIEUDATCHO,TUYENBAY,CHUYENBAY
where PHIEUDATCHO.CHUYENBAY_MaChuyenBay = CHUYENBAY.MaChuyenBay and CHUYENBAY.TUYENBAY_MaTuyenBay = TUYENBAY.MaTuyenBay and CHUYENBAY.MaChuyenBay=@str1
	  )
---------
go
create function LayNguocGioKhoiHanh_1(@str1 varchar(20))
returns table
 as
  return (
     select  ViTri from SANBAY where MaSanBay = @str1
  )
-----
go
 create function LayPhieuDatCho()
 returns table
 as
 return (
 select MaPhieu from PHIEUDATCHO where MaPhieu not in (select MaPhieuDatCho from HOADON))
 -------- 
 go
  create function LayThongTinTruyVanchoHoaDon(@str1 varchar(20))
 returns table 
 as 
 return (
    select MaPhieu,KHACHHANG_CMND,MAHANGVE
	from PHIEUDATCHO
	where MaPhieu like CONCAT ('%',@str1,'%')
 )
 --------
 go
  create function LayThongTinGiaTienHoaDon(@str varchar(30))
  returns table 
  as
   return 
   (
          select DonGia
		  from HANGVE
		  where MaHangVe = @str
   )
  ------
  go
create function SearchPhieuDatCho(@str1 varchar(20))
returns table 
as
 
 return (select * from PHIEUDATCHO 
 where MaPhieu like CONCAT('%',@str1,'%') or KHACHHANG_CMND like CONCAT('%',@str1,'%') or SoGhe like CONCAT('%',@str1,'%') or PHIEUDATCHO.HangGhe like CONCAT('%',@str1,'%') )
 ------
 go
create function TimKiemHoaDon(@str nvarchar(50))
returns table
as
	return (
	select *  from HOADON
	where MaHD like CONCAT('%',@str,'%') or KHACHHANG_CMND like CONCAT('%',@str,'%') or NHANVIEN_MaNV like CONCAT('%',@str,'%'))
---------
go
create function LayChuyenBay_1(@str1 varchar(20))
returns table
 as
   return 
   (
     select * from CHUYENBAY
	 where CHUYENBAY.MaChuyenBay = @str1
   )
 go

--------Trigger 
create TRIGGER CHECK_MaPhieu
ON [dbo].[HOADON]
INSTEAD OF insert
AS
BEGIN
	IF EXISTS (SELECT * FROM inserted WHERE MaPhieuDatCho  IN
	(
	SELECT MaPhieuDatCho
	FROM HOADON
	)  )
	BEGIN
		PRINT N'Không thể cùng mã phiếu lặp lại 2 lần '
		ROLLBACK TRANSACTION 
	END
	ELSE
	BEGIN
	     INSERT INTO HOADON
       SELECT MaHD,MaPhieuDatCho,ThanhTien,NgayLap,NHANVIEN_MaNV,KHACHHANG_CMND
       FROM inserted
	   print N'Thực hiện thành công'
	END
END
---
go
create trigger TriggerSuaPhieuHoaDon on [dbo].[HOADON]
after update
as
begin
	DECLARE @MaHD varchar(20),@MaPhieuDatCho varchar(20),@ThanhTien money,@NgayLap datetime,@MaNhanVien char(20),@CMND char(20)
	IF EXISTS (SELECT * FROM inserted WHERE MaHD IN (SELECT MaHD FROM HOADON)  )
	BEGIN
	    set @MaHD = (select MaHD from inserted)
		set @MaPhieuDatCho = (select MaPhieuDatCho from inserted)
		set @ThanhTien= (select ThanhTien from inserted)
		set @NgayLap  = (select NgayLap from inserted)
		set @MaNhanVien = (select NHANVIEN_MaNV from inserted)
		set @CMND = (select KHACHHANG_CMND from inserted)
		
		--update SANBAY set TenSanBay=@TenSanBay, ViTri=@ViTri where MaSanBay=@MaSanBay
		update HOADON set MaPhieuDatCho=@MaPhieuDatCho,ThanhTien=@ThanhTien,NgayLap=@NgayLap,NHANVIEN_MaNV=@MaNhanVien,KHACHHANG_CMND=@CMND where MaHD=@MaHD
	END
	ELSE
	BEGIN
		PRINT N'Ma Phiếu không tồn tại !'
		ROLLBACK TRANSACTION 
	END
end
-----
go
create   TRIGGER CHECKCHONGOI1
ON [dbo].[PHIEUDATCHO]
INSTEAD OF INSERT
AS
BEGIN
	IF EXISTS (SELECT * FROM inserted WHERE SoGhe IN
	(
	SELECT SoGhe
	FROM PHIEUDATCHO 
	where CHUYENBAY_MaChuyenBay = inserted.CHUYENBAY_MaChuyenBay
	) )
	BEGIN
		PRINT N'Không thể cùng số ghế cho chuyến bay này '
		ROLLBACK TRANSACTION 
	END
	ELSE
	BEGIN
	     INSERT INTO PHIEUDATCHO
       SELECT MaPhieu,ThoiGianDat,SoGhe,HangGhe,CHUYENBAY_MaChuyenBay,KHACHHANG_CMND,MAHANGVE,KHOILUONGHANHLI
       FROM inserted
	   print N'Thực hiện thành công'
	END
END
----
go
create trigger TriggerSuaPhieuDatCho on [dbo].[PHIEUDATCHO]
instead of update
as
begin
	DECLARE @MaPhieu varchar(20),@ThoiGianDat datetime, @SoGhe varchar(20), @HangGhe varchar(20),@MaChuyenBay varchar(20),@CMND varchar(20),@MaHangVe varchar(20),@KhoiLuongHanhLi int 
	   set @MaPhieu = (select MaPhieu from inserted)
		set @ThoiGianDat = (select ThoiGianDat from inserted)
		set @SoGhe= (select SoGhe from inserted)
		set @HangGhe  = (select HangGhe from inserted)
		set @MaChuyenBay = (select CHUYENBAY_MaChuyenBay from inserted)
		set @CMND = (select KHACHHANG_CMND from inserted)
		set @MaHangVe = (select MAHANGVE from inserted)
		set @KhoiLuongHanhLi = (select KHOILUONGHANHLI from inserted)
	IF  EXISTS (SELECT * FROM inserted WHERE MaPhieu IN (SELECT MaPhieu FROM PHIEUDATCHO))
	BEGIN
	       IF EXISTS (SELECT * FROM inserted WHERE SoGhe IN
	(
	SELECT SoGhe
	FROM PHIEUDATCHO 
	where CHUYENBAY_MaChuyenBay = inserted.CHUYENBAY_MaChuyenBay
	) )
	BEGIN
		PRINT N'Không thể cùng số ghế cho chuyến bay này '
		ROLLBACK TRANSACTION 
	END
	ELSE
	BEGIN
	   update PHIEUDATCHO set ThoiGianDat=@ThoiGianDat,SoGhe=@SoGhe,HangGhe=@HangGhe,CHUYENBAY_MaChuyenBay=@MaChuyenBay,KHACHHANG_CMND=@CMND,MAHANGVE=@MaHangVe,KHOILUONGHANHLI=@KhoiLuongHanhLi where MaPhieu=@MaPhieu
	   print N'Thực hiện thành công'
	END
	end
	ELSE
	BEGIN
	PRINT N'Ma Phiếu không tồn tại !'
		ROLLBACK TRANSACTION 
	end
		 

end
go

----------------------------phiếu đặt chỗ --------------------
--- Thêm phiếu đặt chỗ 
create proc ThemPhieuDatCho
@MaPhieu varchar(20), @ThoiGianDat datetime, @Soghe  varchar(20), @HangGhe  varchar(20), @MaChuyenBay varchar(40), @CMND int ,@MaHangVe varchar(30),@KhoiLuongHanhLi int
as
begin 
	insert into PHIEUDATCHO values(@MaPhieu,@ThoiGianDat,@Soghe,@HangGhe,@MaChuyenBay,@CMND,@MaHangVe ,@KhoiLuongHanhLi)
end
go
 
--- Xóa Phiếu Đặt chỗ 
create  proc XoaPhieuDatCho_1
@MaPhieu varchar(20),@MachuyenBay varchar(20)
as
begin tran
    declare @Sove int
	if not exists (select * from PHIEUDATCHO where MaPhieu=@MaPhieu)
		begin 
			print N'Mã phiếu  không hợp lệ '
			rollback
			return
		end 
	else 
	  begin
	     delete from HOADON where MaPhieuDatCho =@MaPhieu
	     set @Sove=(select SoLuongVe from VECHUYENBAY where CHUYENBAY_MaChuyenBay=@MachuyenBay) + 1
		 update VECHUYENBAY set SoLuongVe=@Sove where CHUYENBAY_MaChuyenBay = @MachuyenBay
	     delete from PHIEUDATCHO where MaPhieu=@MaPhieu

	  end

	if(@@ERROR <> 0)
		begin
			print N'Lỗi khi Xóa'
			rollback
			return
		end
commit tran
go
--- Sửa phiếu đặt chỗ 
create proc SuaPhieuDatCho_5
@MaPhieu varchar(20),@ThoiGianDat datetime, @SoGhe varchar(20), @HangGhe varchar(20),@MaChuyenBay varchar(20),@CMND varchar(20),@MaHangVe varchar(20),@KhoiLuongHanhLi int ,@MaChuyenBayold varchar(20)
 
as
begin tran
 declare @SoVe int,@SoVeOLD int
 if not exists (select * from PHIEUDATCHO where MaPhieu=@MaPhieu)
		begin 
			print N'Mã phiếu  không hợp lệ '
			rollback
			return
		end 
 else 
      begin
	    if(@MaChuyenBay like CONCAT('%',@MaChuyenBayold,'%'))
		        begin 
				 update PHIEUDATCHO set ThoiGianDat=@ThoiGianDat,SoGhe=@SoGhe,HangGhe=@HangGhe,CHUYENBAY_MaChuyenBay=@MaChuyenBay,KHACHHANG_CMND=@CMND,MAHANGVE=@MaHangVe,KHOILUONGHANHLI=@KhoiLuongHanhLi where MaPhieu=@MaPhieu	  
				 end
			
	    
		else 
		begin
		  update PHIEUDATCHO set ThoiGianDat=@ThoiGianDat,SoGhe=@SoGhe,HangGhe=@HangGhe,CHUYENBAY_MaChuyenBay=@MaChuyenBayold,KHACHHANG_CMND=@CMND,MAHANGVE=@MaHangVe,KHOILUONGHANHLI=@KhoiLuongHanhLi where MaPhieu=@MaPhieu	  
		  set @SoVe = (select SoLuongVe from VECHUYENBAY where VECHUYENBAY.CHUYENBAY_MaChuyenBay = @MaChuyenBay)-1
	      set @SoVeOLD = (select SoLuongVe from VECHUYENBAY where VECHUYENBAY.CHUYENBAY_MaChuyenBay = @MaChuyenBayold)+1
	       update VECHUYENBAY set SoLuongVe=@SoVe  where CHUYENBAY_MaChuyenBay =@MaChuyenBay
		   update VECHUYENBAY set SoLuongVe=@SoVeOLD where CHUYENBAY_MaChuyenBay = @MaChuyenBayold
		   print 'Thành công'
		   end

	  if(@@ERROR <> 0)
		begin
			print N'Lỗi khi Sửa'
			rollback
			return
		end
		end
commit tran
go
----------------------------Phiếu hóa đơn ---------------------
-- Thêm phiếu hóa đơn
create proc ThemHoaDon_1
@MaHoaDon varchar(20),@MaPhieuDatCho varchar(20),@ThanhTien money,@NgayLap datetime,@MaNhanVien char(20),@CMND char(20)

as
begin tran
        declare @SoGhe int
 if(@MaHoaDon ='' or @MaPhieuDatCho = '' or @ThanhTien ='' or @NgayLap='' or @MaNhanVien ='' or @CMND='')
            begin
			           print N'Thiếu thông tin nhập vào'
			            rollback
			            return
			end

 insert into HOADON values(@MaHoaDon,@MaPhieuDatCho,@ThanhTien,@NgayLap,@MaNhanVien,@CMND)
 if(@@ERROR <> 0)
		begin
			print N'Lỗi khi insert'
			rollback
			return
		end
commit tran
go
-- Xóa phiếu hóa đơn 
create  proc [dbo].[XoaHoaDon]
@MaHD varchar(20)
as
begin tran
	if not exists (select * from HOADON where MaHD=@MaHD)
		begin 
			print N'Mã hóa đơn không hợp lệ '
			rollback
			return
		end 
	delete from HOADON where MaHD= @MaHD
	if(@@ERROR <> 0)
		begin
			print N'Lỗi khi Xóa'
			rollback
			return
		end
commit tran
go
-- Sửa phiếu hóa đơn 
create proc SuaHoaDon_1
@MaHD varchar(20),@MaPhieuDatCho varchar(20),@ThanhTien money,@NgayLap datetime,@MaNhanVien varchar(20),@CMND varchar(20)
as
begin tran
	if exists (select * from HOADON where MaHD = @MaHD)
		begin
			update HOADON set
			MaPhieuDatCho= @MaPhieuDatCho,
			ThanhTien = @ThanhTien,
			NgayLap= @NgayLap,
			NHANVIEN_MaNV= @MaNhanVien,
			KHACHHANG_CMND = @CMND
			
			where MaHD=@MaHD
			if(@@ERROR <> 0)
			             begin
					            print N'Lỗi khi Chỉnh Sửa'
					            rollback
					            return
						 end
		end
	else
		begin
			print N'Cập nhật không thành công'

		end
commit tran
go


--------------------DANH SACH VE--------------------
create view XemVeChuyenBay as
select * from VECHUYENBAY
go

select * from XemVeChuyenBay
go

create function TaoMaVeChuyenBay(@MaChuyenBay varchar(20))
returns varchar(22)
as
begin
	declare @MaVeCB varchar(22)
	 set @MaVeCB = concat(@MaChuyenBay, 'MV')
	return @MaVeCB
end
go

create trigger TriggerThemVeChuyenBay on VECHUYENBAY
instead of insert
as
begin
	IF EXISTS (SELECT * FROM inserted WHERE MaVeChuyenBay IN (SELECT MaVeChuyenBay FROM VECHUYENBAY))
	BEGIN
		PRINT N'Ma Ve Chuyen Bay Da Ton Tai!'
		ROLLBACK TRANSACTION 
	END
	ELSE
	BEGIN
	     INSERT INTO VECHUYENBAY
       SELECT MaVeChuyenBay, CHUYENBAY_MaChuyenBay, SoLuongVe, TinhTrangVe
       FROM inserted
	   PRINT N'Them Ve Chuyen Bay Thanh Cong!'
	END
end
go

create proc ThemVeChuyenBay
@MaChuyenBay varchar(20), @SoLuongVe int, @TinhTrangVe nvarchar(10)
as
begin
	declare @MaVeChuyenBay char(30)
	set @MaVeChuyenBay = dbo.TaoMaVeChuyenBay(@MaChuyenBay)
	insert into VECHUYENBAY values(@MaVeChuyenBay, @MaChuyenBay, @SoLuongVe, @TinhTrangVe)
end
go

create trigger TriggerXoaVeChuyenBay on VECHUYENBAY
instead of delete
as
begin
	IF EXISTS (SELECT * FROM deleted WHERE MaVeChuyenBay IN (SELECT MaVeChuyenBay FROM VECHUYENBAY))
	BEGIN
		DELETE FROM VECHUYENBAY WHERE MaVeChuyenBay IN (SELECT MaVeChuyenBay FROM deleted)
		PRINT N'Xoa Ve Chuyen Bay Thanh Cong!'
	END
	ELSE
	BEGIN
		PRINT N'Ma Ve Chuyen Bay Khong Ton Tai!'
	END
end
go

create proc XoaVeChuyenBay
@MaVeChuyenBay varchar(30)
as
begin
	delete from VECHUYENBAY where MaVeChuyenBay=@MaVeChuyenBay
end
go

create trigger TriggerSuaVeChuyenBay on VECHUYENBAY
instead of update
as
begin
	DECLARE @MaVeChuyenBay varchar(30), @SoLuongVe int, @TinhTrangVe nvarchar(10)
	IF EXISTS (SELECT * FROM inserted WHERE MaVeChuyenBay IN (SELECT MaVeChuyenBay FROM VECHUYENBAY))
	BEGIN
		set @MaVeChuyenBay = (select MaVeChuyenBay from inserted)
		set @SoLuongVe = (select SoLuongVe from inserted)
		set @TinhTrangVe = (select TinhTrangVe from inserted)
		update VECHUYENBAY set SoLuongVe=@SoLuongVe, TinhTrangVe=@TinhTrangVe where MaVeChuyenBay=@MaVeChuyenBay
		PRINT N'Cap Nhat Ve Chuyen Bay Thanh Cong!'
	END
	ELSE
	BEGIN
		PRINT N'Ma Ve Chuyen Bay Khong Ton Tai!'
		ROLLBACK TRANSACTION 
	END
end
go

create proc SuaVeChuyenBay
@MaVeChuyenBay varchar(30), @SoLuongVe int, @TinhTrangVe nvarchar(10)
as
begin
	update VECHUYENBAY set SoLuongVe=@SoLuongVe, TinhTrangVe=@TinhTrangVe where MaVeChuyenBay=@MaVeChuyenBay
end
go

create proc TimVeChuyenBay
@MaVeChuyenBay varchar(30)
as
begin
	IF EXISTS (SELECT MaVeChuyenBay FROM VECHUYENBAY where MaVeChuyenBay=@MaVeChuyenBay)
	BEGIN
		select * from VECHUYENBAY where MaVeChuyenBay=@MaVeChuyenBay
		PRINT N'Tim Kiem Ve Chuyen Bay Thanh Cong!'
	END
	ELSE
	BEGIN
		PRINT N'Ma Ve Chuyen Bay Khong Ton Tai!'
		ROLLBACK TRANSACTION 
	END
end
go
------
--------PHÂN QUYỀN TRÊN SQL-----------
CREATE ROLE ADMINS
go
CREATE ROLE USERS
go
CREATE or alter PROCEDURE USP_CREATE_LOGIN_USER
(
	@Role_Name VARCHAR(50),
	@Login_Name VARCHAR(50), 
	@Password_Login VARCHAR(50)
)
AS
BEGIN
    DECLARE @Login_UserName VARCHAR(50),
			@QueryLogin VARCHAR(100),
			@QueryUser VARCHAR(100)

	SET @Login_UserName = @Login_Name
	SET @QueryLogin ='CREATE LOGIN ' + @Login_UserName + ' WITH PASSWORD = ' + QUOTENAME(@Password_Login, '''')
	SET @QueryUser = CONCAT('CREATE USER ', @Login_UserName, ' FOR LOGIN ', @Login_UserName);

	EXEC (@QueryLogin)
	EXEC (@QueryUser)
	EXEC sys.sp_addrolemember @rolename = @Role_Name, 
	                          @membername = @Login_Name 
END
GO
GRANT EXECUTE TO ADMINS WITH GRANT OPTION
GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.CHUYENBAY to ADMINS WITH GRANT OPTION
GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.HANGVE to ADMINS WITH GRANT OPTION
GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.HOADON to ADMINS WITH GRANT OPTION
GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.KHACHHANG to ADMINS WITH GRANT OPTION
GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.MAYBAY to ADMINS WITH GRANT OPTION
GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.NHANVIEN to ADMINS WITH GRANT OPTION
GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.PHIEUDATCHO to ADMINS WITH GRANT OPTION
GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.SANBAY to ADMINS WITH GRANT OPTION
GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.SoGhe to ADMINS WITH GRANT OPTION
GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.TAIKHOAN to ADMINS WITH GRANT OPTION
GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.TUYENBAY to ADMINS WITH GRANT OPTION
GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.VECHUYENBAY to ADMINS WITH GRANT OPTION
--NHANVIEN
GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.HOADON to USERS WITH GRANT OPTION
GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.KHACHHANG to USERS WITH GRANT OPTION
GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.PHIEUDATCHO to USERS WITH GRANT OPTION
GRANT SELECT ON dbo.CHUYENBAY to USERS WITH GRANT OPTION
GRANT EXECUTE TO USERS WITH GRANT OPTION

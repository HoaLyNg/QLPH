use QLPH1
go

IF OBJECT_ID('QLPHRoomUpdate', 'P') IS NOT NULL
	DROP PROC QLPHRoomUpdate
go

create proc QLPHRoomUpdate @IDPhong int, @MC bit, @AT bit, @AS bit, @ML bit, @RO bit 
as
begin
	update Phong
	set MayChieu = @MC, AmThanh = @AT, AnhSang = @AS, MayLanh = @ML, RO = @RO
	where MaPhong like @IDPhong
end

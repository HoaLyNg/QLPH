use QLPH
go

IF OBJECT_ID('QLPHTKBUpdate', 'P') IS NOT NULL
	DROP PROC QLPHTKBUpdate
go

create proc QLPHTKBUpdate @IDPhong int, @TietBD int, @TietKT int, @Ngay Date, @TenTra nvarchar(50), @MaSo int 
as
begin
	if(not exists(select * from TraPhong where TenNgTra like @TenTra and @MaSo like [MSSV/GV]))
	begin 
		insert into TraPhong values(@TenTra,@MaSo)
		update TKBieu
		set MaTP = (select MAX(MaTP) from TraPhong)
		where MaPhong like @IDPhong and TietBD like @TietBD and TietKT like @TietKT and Ngay like @Ngay
	end
	else
	begin
	update TKBieu
		set MaTP = (select MaTP from TraPhong where TenNgTra like @TenTra and [MSSV/GV] like @MaSo)
		where MaPhong like @IDPhong and TietBD like @TietBD and TietKT like @TietKT and Ngay like @Ngay
	end
end

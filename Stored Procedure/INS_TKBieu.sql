USE QLPH1
GO
IF OBJECT_ID('INS_TKB', 'P') IS NOT NULL
	DROP PROC INS_TKB
GO

CREATE PROC INS_TKB @maphong int=0, @bd int=0, @kt int=0, @date nvarchar(20) , @lap int=0
AS
BEGIN
	DECLARE @i int = 0, @Ph int = 0
	SELECT @Ph = MAX(MaMuonPhong) FROM MuonPhong 
	while (@lap > @i)
	BEGIN
		INSERT INTO TKBieu (MaPhong, [MaLH], [TietBD], [TietKT], [Ngay], [MaMP]) VALUES (@maphong, 3, @bd, @kt, @date, @Ph)
		set @date = dateadd(day, 7, @date)
		SET @i = @i + 1
	END
END
GO




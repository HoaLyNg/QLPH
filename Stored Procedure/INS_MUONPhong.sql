USE QLPH1
GO
IF OBJECT_ID('INS_MUON', 'P') IS NOT NULL
	DROP PROC INS_MUON
GO

CREATE PROC INS_MUON @ten nvarchar(50), @ms nvarchar(50), @not nvarchar(50)
AS
BEGIN
	INSERT INTO MuonPhong (TenNgMuon, [MSSV/GV], Note) VALUES (@ten, @ms, @not)
END
GO

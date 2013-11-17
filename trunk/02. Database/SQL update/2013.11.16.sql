USE [BKI_QLTS]
GO
/****** Object:  StoredProcedure [dbo].[pr_DM_DON_VI_Load_to_grid_danh_muc]    Script Date: 11/16/2013 16:14:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[pr_DM_DON_VI_Load_to_grid_danh_muc_by_key_word]

@ip_str_user_name NVARCHAR(50)
, @ip_dc_loai_don_vi NUMERIC(18,0)
, @ip_str_key_word NVARCHAR(250)
AS
/*
* @ip_dc_id_don_vi_cap_tren = -1 => All don vi 
* */

SELECT distinct dv.* FROM
DM_DON_VI dv
, HT_NGUOI_SU_DUNG hnsd
, HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
WHERE
	hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
	AND hnsd.TEN_TRUY_CAP = @ip_str_user_name	
	AND dv.ID_LOAI_DON_VI = @ip_dc_loai_don_vi
	AND (dv.ID LIKE N'%' + @ip_str_key_word + '%'
		OR dv.MA_DON_VI LIKE N'%' + @ip_str_key_word + '%'
		OR dv.TEN_DON_VI LIKE N'%' + @ip_str_key_word + '%')
	
GO
INSERT INTO DM_DON_VI
(
	-- ID -- this column value is auto-generated,
	MA_DON_VI,
	TEN_DON_VI,
	LOAI_HINH_DON_VI,
	ID_LOAI_DON_VI,
	ID_DON_VI_CAP_TREN,
	STT,
	LEVEL_MODE
)
VALUES
(
	N'BTK',
	N'Bộ tỉnh khác',
	N'CO_QUAN_NHA_NUOC_HC',
	574,
	NULL,
	NULL,
	1
)
GO
INSERT INTO DM_DON_VI
(
	-- ID -- this column value is auto-generated,
	MA_DON_VI,
	TEN_DON_VI,
	LOAI_HINH_DON_VI,
	ID_LOAI_DON_VI,
	ID_DON_VI_CAP_TREN,
	STT,
	LEVEL_MODE
)
VALUES
(
	N'DVCQK',
	N'Đơn vị chủ quản khác',
	N'CO_QUAN_NHA_NUOC_HC',
	575,
	238,
	NULL,
	2
)

GO
INSERT INTO DM_DON_VI
(
	-- ID -- this column value is auto-generated,
	MA_DON_VI,
	TEN_DON_VI,
	LOAI_HINH_DON_VI,
	ID_LOAI_DON_VI,
	ID_DON_VI_CAP_TREN,
	STT,
	LEVEL_MODE
)
VALUES
(
	N'DV313',
	N'Tổng cục đường bộ',
	N'CO_QUAN_NHA_NUOC_HC',
	576,
	118,
	NULL,
	3
)
GO
DECLARE @ID_DV_KHAC NUMERIC(18,0)
SET @ID_DV_KHAC = (SELECT MAX(ID) FROM DM_DON_VI WHERE MA_DON_VI = N'BTK')

INSERT INTO HT_QUAN_HE_SU_DUNG_DU_LIEU
(
	-- ID -- this column value is auto-generated,
	ID_DON_VI,
	ID_USER_GROUP
)
VALUES
(
	@ID_DV_KHAC,
	2
)


INSERT INTO HT_QUAN_HE_SU_DUNG_DU_LIEU
(
	-- ID -- this column value is auto-generated,
	ID_DON_VI,
	ID_USER_GROUP
)
VALUES
(
	@ID_DV_KHAC,
	5
)
SET @ID_DV_KHAC = (SELECT MAX(ID) FROM DM_DON_VI WHERE MA_DON_VI = N'DVCQK')
INSERT INTO HT_QUAN_HE_SU_DUNG_DU_LIEU
(
	-- ID -- this column value is auto-generated,
	ID_DON_VI,
	ID_USER_GROUP
)
VALUES
(
	@ID_DV_KHAC,
	2
)


INSERT INTO HT_QUAN_HE_SU_DUNG_DU_LIEU
(
	-- ID -- this column value is auto-generated,
	ID_DON_VI,
	ID_USER_GROUP
)
VALUES
(
	@ID_DV_KHAC,
	5
)

SET @ID_DV_KHAC = (SELECT MAX(ID) FROM DM_DON_VI WHERE MA_DON_VI = N'DV313')
INSERT INTO HT_QUAN_HE_SU_DUNG_DU_LIEU
(
	-- ID -- this column value is auto-generated,
	ID_DON_VI,
	ID_USER_GROUP
)
VALUES
(
	@ID_DV_KHAC,
	2
)


INSERT INTO HT_QUAN_HE_SU_DUNG_DU_LIEU
(
	-- ID -- this column value is auto-generated,
	ID_DON_VI,
	ID_USER_GROUP
)
VALUES
(
	@ID_DV_KHAC,
	5
)

GO
CREATE PROCEDURE [dbo].[pr_HT_QUAN_HE_SU_DUNG_DU_LIEU_Insert]
	@ID_DON_VI numeric(18, 0),
	@ID_USER_GROUP numeric(18, 0),
	@ID numeric(18, 0) OUTPUT
AS
INSERT [dbo].[HT_QUAN_HE_SU_DUNG_DU_LIEU]
(
	[ID_DON_VI],
	[ID_USER_GROUP]
)
VALUES
(
	@ID_DON_VI,
	@ID_USER_GROUP
)
SELECT @ID=SCOPE_IDENTITY()
GO

CREATE PROCEDURE [dbo].[pr_HT_QUAN_HE_SU_DUNG_DU_LIEU_Update]
	@ID numeric(18, 0),
	@ID_DON_VI numeric(18, 0),
	@ID_USER_GROUP numeric(18, 0)
AS
UPDATE [dbo].[HT_QUAN_HE_SU_DUNG_DU_LIEU]
SET 
	[ID_DON_VI] = @ID_DON_VI,
	[ID_USER_GROUP] = @ID_USER_GROUP
WHERE
	[ID] = @ID
GO

CREATE PROCEDURE [dbo].[pr_HT_QUAN_HE_SU_DUNG_DU_LIEU_UpdateAllWID_DON_VILogic]
	@ID_DON_VI numeric(18, 0),
	@ID_DON_VIOld numeric(18, 0)
AS
UPDATE [dbo].[HT_QUAN_HE_SU_DUNG_DU_LIEU]
SET
	[ID_DON_VI] = @ID_DON_VI
WHERE
	[ID_DON_VI] = @ID_DON_VIOld
GO

CREATE PROCEDURE [dbo].[pr_HT_QUAN_HE_SU_DUNG_DU_LIEU_UpdateAllWID_USER_GROUPLogic]
	@ID_USER_GROUP numeric(18, 0),
	@ID_USER_GROUPOld numeric(18, 0)
AS
UPDATE [dbo].[HT_QUAN_HE_SU_DUNG_DU_LIEU]
SET
	[ID_USER_GROUP] = @ID_USER_GROUP
WHERE
	[ID_USER_GROUP] = @ID_USER_GROUPOld
GO

CREATE PROCEDURE [dbo].[pr_HT_QUAN_HE_SU_DUNG_DU_LIEU_Delete]
	@ID numeric(18, 0)
AS
DELETE FROM [dbo].[HT_QUAN_HE_SU_DUNG_DU_LIEU]
WHERE
	[ID] = @ID
GO

CREATE PROCEDURE [dbo].[pr_HT_QUAN_HE_SU_DUNG_DU_LIEU_DeleteAllWID_DON_VILogic]
	@ID_DON_VI numeric(18, 0)
AS
DELETE
FROM [dbo].[HT_QUAN_HE_SU_DUNG_DU_LIEU]
WHERE
	[ID_DON_VI] = @ID_DON_VI
GO

CREATE PROCEDURE [dbo].[pr_HT_QUAN_HE_SU_DUNG_DU_LIEU_DeleteAllWID_USER_GROUPLogic]
	@ID_USER_GROUP numeric(18, 0)
AS
DELETE
FROM [dbo].[HT_QUAN_HE_SU_DUNG_DU_LIEU]
WHERE
	[ID_USER_GROUP] = @ID_USER_GROUP
GO








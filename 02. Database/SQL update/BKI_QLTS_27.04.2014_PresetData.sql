INSERT INTO CM_DM_LOAI_TD
(
	ID,
	MA_LOAI,
	TEN_LOAI
)
VALUES
(
	14,
	'KHAC',
	N'Khác'
)
GO

INSERT INTO CM_DM_TU_DIEN
(
	-- ID -- this column value is auto-generated,
	MA_TU_DIEN,
	ID_LOAI_TU_DIEN,
	TEN_NGAN,
	TEN,
	GHI_CHU
)
VALUES
(
	'DIEU_CHUYEN_NOI_BO',
	14,
	N'Điều chuyển nội bộ',
	N'Điều chuyển nội bộ',
	9
)
GO
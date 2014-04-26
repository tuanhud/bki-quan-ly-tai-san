USE bki_qlts
GO
-- Proc 1
ALTER PROC [dbo].[pr_DM_DAT_search_by_id_don_vi]

@ip_id_bo_tinh NUMERIC(18,0),
@ip_id_dv_chu_quan NUMERIC(18,0),
@ip_id_dv_su_dung NUMERIC(18,0),
@ip_dc_id_trang_thai_dat numeric	(18,0),
@ip_str_user_name NVARCHAR(50)
AS

	SELECT * FROM DM_DAT dd
	WHERE
		((dd.ID_DON_VI_SU_DUNG = @ip_id_dv_su_dung) OR (@ip_id_dv_su_dung =-1))
		AND ((dd.ID_DON_VI_CHU_QUAN = @ip_id_dv_chu_quan) OR (@ip_id_dv_chu_quan =-1))
		AND ((dd.ID_DON_VI_CHU_QUAN IN 
				(SELECT ID FROM DM_DON_VI ddv WHERE ddv.ID_DON_VI_CAP_TREN = @ip_id_bo_tinh))
				OR (@ip_id_bo_tinh = -1))
		AND (dd.ID_TRANG_THAI = @ip_dc_id_trang_thai_dat OR @ip_dc_id_trang_thai_dat = -1)
		AND dd.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)
GO					
-- Proc 2
ALTER PROC [dbo].[pr_DM_DAT_search_by_id_don_vi_loai_hinh]

@ip_id_bo_tinh NUMERIC(18,0),
@ip_id_dv_chu_quan NUMERIC(18,0),
@ip_id_dv_su_dung NUMERIC(18,0),
@ip_dc_id_trang_thai_dat numeric	(18,0),
@ip_str_user_name NVARCHAR(50),
@ip_str_loai_hinh_don_vi NVARCHAR(250)
AS

	SELECT * FROM DM_DAT dd
	WHERE
		((dd.ID_DON_VI_SU_DUNG = @ip_id_dv_su_dung) OR (@ip_id_dv_su_dung =-1))
		AND (dd.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))
		AND ((dd.ID_DON_VI_CHU_QUAN = @ip_id_dv_chu_quan) OR (@ip_id_dv_chu_quan =-1))
		AND ((dd.ID_DON_VI_CHU_QUAN IN 
				(SELECT ID FROM DM_DON_VI ddv WHERE ddv.ID_DON_VI_CAP_TREN = @ip_id_bo_tinh))
				OR (@ip_id_bo_tinh = -1))
		AND (dd.ID_TRANG_THAI = @ip_dc_id_trang_thai_dat OR @ip_dc_id_trang_thai_dat = -1)
		AND dd.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)
		AND dd.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)
GO				
-- Proc 3
ALTER procedure [dbo].[pr_DM_OTO_Search]
@TU_KHOA nvarchar(100)
, @ID_TRANG_THAI decimal,
@ID_DV_SU_DUNG decimal,
@ID_DV_QUAN_LY decimal,
@ID_DV_BO_TINH DECIMAL,
@ip_str_user_name NVARCHAR(250)
as
select *
from DM_OTO
WHERE
	ID_DON_VI_SU_DUNG IN
	(
	SELECT ID FROM dbo.DM_DON_VI
	WHERE 
		ID_DON_VI_CAP_TREN IN 
			(SELECT ID FROM dbo.DM_DON_VI WHERE ID_DON_VI_CAP_TREN = @ID_DV_BO_TINH)
		OR dbo.DM_DON_VI.ID_DON_VI_CAP_TREN = @ID_DV_BO_TINH
		OR @ID_DV_BO_TINH = -1
	)
	AND 
		(ID_DON_VI_SU_DUNG = @ID_DV_SU_DUNG or @ID_DV_SU_DUNG = -1) 
	AND	
		(ID_TRANG_THAI = @ID_TRANG_THAI OR @ID_TRANG_THAI = -1) 
	AND (	TEN_TAI_SAN like '%'+@TU_KHOA+'%' or
			MA_TAI_SAN like '%'+@TU_KHOA+'%' or
			NHAN_HIEU like '%'+@TU_KHOA+'%' or
			BIEN_KIEM_SOAT like '%'+@TU_KHOA+'%' or
			NUOC_SAN_XUAT like '%'+@TU_KHOA+'%' or
			CHUC_DANH_SU_DUNG like '%'+@TU_KHOA+'%' or
			NGUON_GOC_XE like '%'+@TU_KHOA+'%' or
			@TU_KHOA = '')
	AND dm_oto.ID_DON_VI_SU_DUNG
	IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)
GO					
-- Proc 4	
ALTER PROC [dbo].[pr_V_BC_THHTSD_NHA_DAT_search]
@ip_id_bo_tinh NUMERIC(18,0),
@ip_id_dv_chu_quan NUMERIC(18,0),
@ip_id_dv_su_dung NUMERIC(18,0),
@ip_dc_id_trang_thai_dat numeric(18,0),
@ip_dc_id_trang_thai_nha numeric(18,0),
@ip_dc_id_tinh_trang NVARCHAR(250),
@ip_str_user_name NVARCHAR(50),
@ip_str_loai_hinh_don_vi NVARCHAR(250)

AS
	SELECT * FROM V_BC_THHTSD_NHA_DAT vbnd
	WHERE
		((vbnd.ID_DON_VI_SU_DUNG = @ip_id_dv_su_dung) OR (@ip_id_dv_su_dung =-1))
		AND (vbnd.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI vbndv WHERE vbndv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))
		AND ((vbnd.ID_DON_VI_CHU_QUAN = @ip_id_dv_chu_quan) OR (@ip_id_dv_chu_quan =-1))
		AND ((vbnd.ID_DON_VI_CHU_QUAN IN 
				(SELECT ID FROM DM_DON_VI vbndv WHERE vbndv.ID_DON_VI_CAP_TREN = @ip_id_bo_tinh))
				OR (@ip_id_bo_tinh = -1))
		AND (vbnd.ID_TRANG_THAI = @ip_dc_id_trang_thai_dat OR @ip_dc_id_trang_thai_dat = -1
			OR vbnd.ID_TRANG_THAI = @ip_dc_id_trang_thai_nha OR @ip_dc_id_trang_thai_nha = -1)
		AND vbnd.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsvbndl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsvbndl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsvbndl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)
GO					
-- Proc 5
ALTER procedure [dbo].[pr_V_DM_DAT_HISTORY_Search]


@ip_id_bo_tinh NUMERIC(18,0),
@ip_id_dvql NUMERIC(18,0),
@ip_id_dvsd NUMERIC(18,0),
@ip_id_dat NUMERIC(18,0),
@ip_id_trang_thai NUMERIC(18,0),
@ip_dat_tu_ngay DATETIME,
@ip_dat_den_ngay DATETIME,
@ip_str_tu_khoa nvarchar(100),
@ip_str_user_name NVARCHAR(250)
as

select *
from V_DM_DAT_HISTORY v
WHERE
 
	(ID_DON_VI_SU_DUNG = @ip_id_dvsd or @ip_id_dvsd = -1)
	AND (ID_DON_VI_CHU_QUAN = @ip_id_dvql OR @ip_id_dvql = -1)	 
	AND	(ID_DON_VI_CHU_QUAN IN
		(
			SELECT ID
			FROM dbo.DM_DON_VI dv
			WHERE dv.ID_DON_VI_CAP_TREN = @ip_id_bo_tinh
				
		)OR @ip_id_bo_tinh = -1)
	AND	
		(ID_TRANG_THAI = @ip_id_trang_thai OR @ip_id_trang_thai = -1)
	AND (v.ID_DAT = @ip_id_dat OR @ip_id_dat = -1)
	AND v.NGAY_CAP_NHAT_CUOI >= @ip_dat_tu_ngay
	AND v.NGAY_CAP_NHAT_CUOI <= @ip_dat_den_ngay 
	AND (	v.DIA_CHI like '%'+@ip_str_tu_khoa+'%' or
			MA_TAI_SAN like '%'+@ip_str_tu_khoa+'%' or			
			GHI_CHU_LICH_SU like '%'+@ip_str_tu_khoa+'%' or
			@ip_str_tu_khoa = '')
	AND v.ID_DON_VI_SU_DUNG
	IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)
ORDER BY
	v.NGAY_CAP_NHAT_CUOI DESC	
	,v.ID_DAT
GO	
-- Proc 6
ALTER PROC [dbo].[pr_V_DM_DAT_HISTORY_search_by_id_don_vi_loai_hinh_tu_khoa]

@ip_id_bo_tinh NUMERIC(18,0),
@ip_id_dv_chu_quan NUMERIC(18,0),
@ip_id_dv_su_dung NUMERIC(18,0),
@ip_dc_id_trang_thai_dat numeric(18,0),
@ip_str_user_name NVARCHAR(50),
@ip_str_loai_hinh_don_vi NVARCHAR(250),
@ip_dat_tu_ngay DATETIME,
@ip_dat_den_ngay DATETIME,
@ip_str_tu_khoa NVARCHAR(250)
AS
	SELECT * FROM V_DM_DAT_HISTORY dd
	WHERE
		((dd.ID_DON_VI_SU_DUNG = @ip_id_dv_su_dung) OR (@ip_id_dv_su_dung =-1))
		AND (dd.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))
		AND ((dd.ID_DON_VI_CHU_QUAN = @ip_id_dv_chu_quan) OR (@ip_id_dv_chu_quan =-1))
		AND ((dd.ID_DON_VI_CHU_QUAN IN 
				(SELECT ID FROM DM_DON_VI ddv WHERE ddv.ID_DON_VI_CAP_TREN = @ip_id_bo_tinh))
				OR (@ip_id_bo_tinh = -1))
		AND (dd.ID_TRANG_THAI = @ip_dc_id_trang_thai_dat OR @ip_dc_id_trang_thai_dat = -1)
		AND dd.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)
		AND (dd.ID LIKE N'%'+ @ip_str_tu_khoa +'%'
		OR dd.MA_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%'
		OR dd.TEN_DV_SU_DUNG LIKE N'%'+ @ip_str_tu_khoa +'%'
		OR dd.DIA_CHI LIKE N'%'+ @ip_str_tu_khoa +'%'
		OR dd.TEN_DV_BO_TINH LIKE N'%'+ @ip_str_tu_khoa +'%'
		OR dd.TEN_DV_CHU_QUAN LIKE N'%'+ @ip_str_tu_khoa +'%'
		OR dd.TEN_TRANG_THAI LIKE N'%'+ @ip_str_tu_khoa +'%'
		)
		AND ((dd.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi) OR(@ip_str_loai_hinh_don_vi='-1'))
		AND (dd.NGAY_CAP_NHAT_CUOI BETWEEN @ip_dat_tu_ngay AND @ip_dat_den_ngay)
GO			
-- Proc 7	
ALTER PROC [dbo].[pr_V_DM_DAT_search_by_id_don_vi_loai_hinh_tu_khoa]

@ip_id_bo_tinh NUMERIC(18,0),
@ip_id_dv_chu_quan NUMERIC(18,0),
@ip_id_dv_su_dung NUMERIC(18,0),
@ip_dc_id_trang_thai_dat numeric(18,0),
@ip_str_user_name NVARCHAR(50),
@ip_str_loai_hinh_don_vi NVARCHAR(250),
@ip_str_tu_khoa NVARCHAR(250)
AS

	SELECT * FROM V_DM_DAT dd
	WHERE
		((dd.ID_DON_VI_SU_DUNG = @ip_id_dv_su_dung) OR (@ip_id_dv_su_dung =-1))
		AND (dd.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))
		AND ((dd.ID_DON_VI_CHU_QUAN = @ip_id_dv_chu_quan) OR (@ip_id_dv_chu_quan =-1))
		AND ((dd.ID_DON_VI_CHU_QUAN IN 
				(SELECT ID FROM DM_DON_VI ddv WHERE ddv.ID_DON_VI_CAP_TREN = @ip_id_bo_tinh))
				OR (@ip_id_bo_tinh = -1))
		AND (dd.ID_TRANG_THAI = @ip_dc_id_trang_thai_dat OR @ip_dc_id_trang_thai_dat = -1)
		AND dd.ID_DON_VI_SU_DUNG	
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)
		AND (dd.ID LIKE N'%'+ @ip_str_tu_khoa +'%'
		OR dd.MA_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%'
		OR dd.TEN_DV_SU_DUNG LIKE N'%'+ @ip_str_tu_khoa +'%'
		OR dd.DIA_CHI LIKE N'%'+ @ip_str_tu_khoa +'%'
		OR dd.TEN_DV_BO_TINH LIKE N'%'+ @ip_str_tu_khoa +'%'
		OR dd.TEN_DV_CHU_QUAN LIKE N'%'+ @ip_str_tu_khoa +'%'
		OR dd.TEN_TRANG_THAI LIKE N'%'+ @ip_str_tu_khoa +'%'
		)
GO			
-- Proc 8
ALTER PROCEDURE [dbo].[pr_V_DM_NHA_HISTORY_Load_data_to_grid_by_tu_khoa]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_dat NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_str_loai_hinh_don_vi NVARCHAR(250)
,@ip_str_user_name NVARCHAR(250)
,@ip_str_tu_khoa NVARCHAR(250)
AS

SELECT 
*
FROM V_DM_NHA_HISTORY nha
WHERE 
		((nha.ID_DON_VI_SU_DUNG = @ip_dc_id_don_vi_su_dung ) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND (nha.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))			    
		AND ((nha.ID_DON_VI_CHU_QUAN = @ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND	 (nha.ID_DON_VI_CHU_QUAN IN 
				(SELECT id FROM dm_don_vi dv 
				 WHERE 
					((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				)
		)
		AND (nha.TEN_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%' 
				OR nha.ID LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.MA_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.TEN_DV_SU_DUNG LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.DIA_CHI LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.TEN_DV_BO_TINH LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.TEN_DV_CHU_QUAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.TEN_TRANG_THAI LIKE N'%'+ @ip_str_tu_khoa +'%'
				)
		AND ((nha.id_dat = @ip_dc_id_dat) OR (@ip_dc_id_dat = -1))
		AND ((nha.ID_TRANG_THAI = @ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))
		AND nha.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)				
GO			
-- Proc 9
ALTER PROCEDURE [dbo].[pr_V_DM_NHA_HISTORY_Search]
@ip_id_bo_tinh NUMERIC(18,0)
,@ip_id_dvql NUMERIC(18,0)
,@ip_id_dvsd NUMERIC(18,0)
,@ip_dc_id_dat NUMERIC(18,0)
,@ip_id_trang_thai NUMERIC(18,0)
,@ip_str_loai_hinh_don_vi NVARCHAR(250)
,@ip_tsk_tu_ngay DATETIME
,@ip_tsk_den_ngay DATETIME
,@ip_str_user_name NVARCHAR(250)
,@ip_str_tu_khoa NVARCHAR(250)
AS

SELECT 
*
FROM V_DM_NHA_HISTORY nha
WHERE 
		(ID_DON_VI_SU_DUNG = @ip_id_dvsd or @ip_id_dvsd = -1)
	AND (ID_DON_VI_CHU_QUAN = @ip_id_dvql OR @ip_id_dvql = -1)	 
	AND	(ID_DON_VI_CHU_QUAN IN
		(
			SELECT ID
			FROM dbo.DM_DON_VI dv
			WHERE dv.ID_DON_VI_CAP_TREN = @ip_id_bo_tinh
				
		)OR @ip_id_bo_tinh = -1)
	AND	
		(ID_TRANG_THAI = @ip_id_trang_thai OR @ip_id_trang_thai = -1)
	AND nha.NGAY_CAP_NHAT_CUOI >= @ip_tsk_tu_ngay
	AND nha.NGAY_CAP_NHAT_CUOI <= @ip_tsk_den_ngay 
	AND (	nha.TEN_TAI_SAN like '%'+@ip_str_tu_khoa+'%' or
			MA_TAI_SAN like '%'+@ip_str_tu_khoa+'%' or			
			GHI_CHU_LICH_SU like '%'+@ip_str_tu_khoa+'%' or
			@ip_str_tu_khoa = '')
	AND (nha.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))
	AND nha.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)			
	AND ((nha.id_dat = @ip_dc_id_dat) OR (@ip_dc_id_dat = -1))
	ORDER BY
	v.NGAY_CAP_NHAT_CUOI DESC
GO		
-- Proc 10	
ALTER PROCEDURE [dbo].[pr_V_DM_NHA_Load_data_to_grid_by_tu_khoa]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_dat NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_str_loai_hinh_don_vi NVARCHAR(250)
,@ip_str_user_name NVARCHAR(250)
,@ip_str_tu_khoa NVARCHAR(250)
AS

SELECT 
*
FROM V_DM_NHA nha
WHERE 
		((nha.ID_DON_VI_SU_DUNG = @ip_dc_id_don_vi_su_dung ) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND (nha.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))			    
		AND ((nha.ID_DON_VI_CHU_QUAN = @ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND	 (nha.ID_DON_VI_CHU_QUAN IN 
				(SELECT id FROM dm_don_vi dv 
				 WHERE 
					((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				)
		)
		AND (nha.TEN_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%' 
				OR nha.ID LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.MA_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.TEN_DV_SU_DUNG LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.DIA_CHI LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.TEN_DV_BO_TINH LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.TEN_DV_CHU_QUAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.TEN_TRANG_THAI LIKE N'%'+ @ip_str_tu_khoa +'%'
				)
		AND ((nha.id_dat = @ip_dc_id_dat) OR (@ip_dc_id_dat = -1))
		AND ((nha.ID_TRANG_THAI = @ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))
		AND nha.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)	
GO					
-- Proc 11
ALTER PROCEDURE [dbo].[pr_V_DM_NHA_Load_data_to_grid_nha]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_dat NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_str_user_name NVARCHAR(250)
AS

SELECT 
*
FROM v_dm_nha nha
WHERE 
		    ((nha.ID_DON_VI_SU_DUNG = @ip_dc_id_don_vi_su_dung ) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND ((nha.ID_DON_VI_CHU_QUAN = @ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND	 (nha.ID_DON_VI_CHU_QUAN IN 
				(SELECT id FROM dm_don_vi dv 
				 WHERE 
					((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				)
			 )
		AND ((nha.id_dat = @ip_dc_id_dat) OR (@ip_dc_id_dat = -1))
		AND ((nha.ID_TRANG_THAI = @ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))				
		AND nha.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)
GO					
-- Proc 12
ALTER PROCEDURE [dbo].[pr_V_DM_NHA_Load_data_to_grid_nha_loai_hinh]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_dat NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_str_loai_hinh_don_vi NVARCHAR(250)
,@ip_str_user_name NVARCHAR(250)
AS

SELECT 
*
FROM v_dm_nha nha
WHERE 
		    ((nha.ID_DON_VI_SU_DUNG = @ip_dc_id_don_vi_su_dung ) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND (nha.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))			    
		AND ((nha.ID_DON_VI_CHU_QUAN = @ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND	 (nha.ID_DON_VI_CHU_QUAN IN 
				(SELECT id FROM dm_don_vi dv 
				 WHERE 
					((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				)
			 )
		AND ((nha.id_dat = @ip_dc_id_dat) OR (@ip_dc_id_dat = -1))
		AND ((nha.ID_TRANG_THAI = @ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))
		AND nha.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)		
GO					
-- Proc 13	
ALTER procedure [dbo].[pr_V_DM_OTO_HISTORY_Search]


@ip_id_bo_tinh NUMERIC(18,0),
@ip_id_dvql NUMERIC(18,0),
@ip_id_dvsd NUMERIC(18,0),
@ip_id_trang_thai NUMERIC(18,0),
@ip_str_loai_hinh_don_vi NVARCHAR(250),
@ip_tsk_tu_ngay DATETIME,
@ip_tsk_den_ngay DATETIME,
@ip_str_user_name NVARCHAR(250),
@ip_str_tu_khoa nvarchar(100)
as

select *
from V_DM_OTO_HISTORY v
WHERE
 
	(ID_DON_VI_SU_DUNG = @ip_id_dvsd or @ip_id_dvsd = -1)
	AND (ID_DON_VI_CHU_QUAN = @ip_id_dvql OR @ip_id_dvql = -1)	 
	AND	(ID_DON_VI_CHU_QUAN IN
		(
			SELECT ID
			FROM dbo.DM_DON_VI dv
			WHERE dv.ID_DON_VI_CAP_TREN = @ip_id_bo_tinh
				
		)OR @ip_id_bo_tinh = -1)
	AND	
		(ID_TRANG_THAI = @ip_id_trang_thai OR @ip_id_trang_thai = -1)
	AND v.NGAY_CAP_NHAT_CUOI >= @ip_tsk_tu_ngay
	AND v.NGAY_CAP_NHAT_CUOI <= @ip_tsk_den_ngay 
	AND (	v.TEN_TAI_SAN like '%'+@ip_str_tu_khoa+'%' or
			MA_TAI_SAN like '%'+@ip_str_tu_khoa+'%' or			
			GHI_CHU_LICH_SU like '%'+@ip_str_tu_khoa+'%' or
			@ip_str_tu_khoa = '')
	AND (v.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))
	AND v.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)		
ORDER BY
	v.NGAY_CAP_NHAT_CUOI DESC	
GO	
-- Proc 14
ALTER PROCEDURE [dbo].[pr_V_DM_OTO_Load_data_to_grid_by_tu_khoa]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_dc_id_loai_tai_san NUMERIC(18,0)
,@ip_str_loai_hinh_don_vi NVARCHAR(250)
,@ip_str_user_name NVARCHAR(250)
,@ip_str_tu_khoa NVARCHAR(250)
AS

SELECT 
*
FROM V_DM_OTO oto
WHERE 
		((oto.ID_DON_VI_SU_DUNG = @ip_dc_id_don_vi_su_dung ) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND (oto.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))			    
		AND ((oto.ID_DON_VI_CHU_QUAN = @ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND	 (oto.ID_DON_VI_CHU_QUAN IN 
				(SELECT id FROM dm_don_vi dv 
				 WHERE 
					((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				)
		)
		AND (oto.TEN_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%' 
				OR oto.ID LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR oto.MA_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR oto.TEN_DV_SU_DUNG LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR oto.TEN_DV_BO_TINH LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR oto.TEN_DV_CHU_QUAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR oto.TEN_TRANG_THAI LIKE N'%'+ @ip_str_tu_khoa +'%'
				or @ip_str_tu_khoa=''
				)
		AND ((oto.ID_LOAI_TAI_SAN = @ip_dc_id_loai_tai_san) OR (@ip_dc_id_loai_tai_san = -1))
		AND ((oto.ID_TRANG_THAI = @ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))
		AND oto.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)	
GO					
-- Proc 15	
ALTER	 procedure [dbo].[pr_V_DM_OTO_Search]
@ip_id_bo_tinh NUMERIC(18,0),
@ip_id_dvql NUMERIC(18,0),
@ip_id_dvsd NUMERIC(18,0),
@ip_id_loai_tai_san NUMERIC(18,0),
@ip_id_trang_thai NUMERIC(18,0),
@ip_str_tu_khoa nvarchar(100)
,@ip_str_user_name NVARCHAR(250)
as

select *
from V_DM_OTO v
WHERE
 
	(ID_DON_VI_SU_DUNG = @ip_id_dvsd or @ip_id_dvsd = -1)
	AND (ID_DON_VI_CHU_QUAN = @ip_id_dvql OR @ip_id_dvql = -1)	 
	AND	(ID_DON_VI_CHU_QUAN IN
		(
			SELECT ID
			FROM dbo.DM_DON_VI dv
			WHERE dv.ID_DON_VI_CAP_TREN = @ip_id_bo_tinh
				
		)OR @ip_id_bo_tinh = -1)
	AND	(ID_LOAI_TAI_SAN = @ip_id_loai_tai_san OR @ip_id_loai_tai_san = -1)
	AND	(ID_TRANG_THAI = @ip_id_trang_thai OR @ip_id_trang_thai = -1)
	
	AND (	v.TEN_TAI_SAN like '%'+@ip_str_tu_khoa+'%' OR
		v.TEN_LOAI_TAI_SAN like '%'+@ip_str_tu_khoa+'%' or
		MA_TAI_SAN like '%'+@ip_str_tu_khoa+'%' or			
		@ip_str_tu_khoa = '')
	AND v.ID_DON_VI_SU_DUNG
	IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)			
ORDER BY
	v.TEN_LOAI_TAI_SAN
GO		
-- Proc 16
ALTER procedure [dbo].[pr_V_DM_TAI_SAN_KHAC_HISTORY_Search]


@ip_id_bo_tinh NUMERIC(18,0),
@ip_id_dvql NUMERIC(18,0),
@ip_id_dvsd NUMERIC(18,0),
@ip_id_trang_thai NUMERIC(18,0),
@ip_str_loai_hinh_don_vi NVARCHAR(250),
@ip_tsk_tu_ngay DATETIME,
@ip_tsk_den_ngay DATETIME,
@ip_str_user_name NVARCHAR(250),
@ip_str_tu_khoa NVARCHAR(250)
as

select *
from V_DM_TAI_SAN_KHAC_HISTORY v
WHERE
 
	(ID_DON_VI_SU_DUNG = @ip_id_dvsd or @ip_id_dvsd = -1)
	AND (ID_DON_VI_CHU_QUAN = @ip_id_dvql OR @ip_id_dvql = -1)	 
	AND	(ID_DON_VI_CHU_QUAN IN
		(
			SELECT ID
			FROM dbo.DM_DON_VI dv
			WHERE dv.ID_DON_VI_CAP_TREN = @ip_id_bo_tinh
				
		)OR @ip_id_bo_tinh = -1)
	AND	
		(ID_TRANG_THAI = @ip_id_trang_thai OR @ip_id_trang_thai = -1)
	AND v.NGAY_CAP_NHAT_CUOI >= @ip_tsk_tu_ngay
	AND v.NGAY_CAP_NHAT_CUOI <= @ip_tsk_den_ngay 
	AND (	v.TEN_TAI_SAN like '%'+@ip_str_tu_khoa+'%' or
			MA_TAI_SAN like '%'+@ip_str_tu_khoa+'%' or			
			GHI_CHU_LICH_SU like '%'+@ip_str_tu_khoa+'%' or
			@ip_str_tu_khoa = '')
	AND (v.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))
	AND v.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)				
		
ORDER BY
	v.NGAY_CAP_NHAT_CUOI DESC	
GO		
-- Proc 17
ALTER PROCEDURE [dbo].[pr_V_DM_TAI_SAN_KHAC_Load_data_to_grid_by_tu_khoa]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_str_loai_hinh_don_vi NVARCHAR(250)
,@ip_str_user_name NVARCHAR(250)
,@ip_str_tu_khoa NVARCHAR(250)
AS

SELECT 
*
FROM V_DM_TAI_SAN_KHAC tsk
WHERE 
		((tsk.ID_DON_VI_SU_DUNG = @ip_dc_id_don_vi_su_dung ) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND (tsk.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))			    
		AND ((tsk.ID_DON_VI_CHU_QUAN = @ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND	 (tsk.ID_DON_VI_CHU_QUAN IN 
				(SELECT id FROM dm_don_vi dv 
				 WHERE 
					((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				)
		)
		AND (tsk.TEN_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%' 
				OR tsk.ID LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.MA_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_DV_SU_DUNG LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_DV_BO_TINH LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_DV_CHU_QUAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_TRANG_THAI LIKE N'%'+ @ip_str_tu_khoa +'%'
				)
		AND ((tsk.ID_TRANG_THAI = @ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))
		AND tsk.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)		
GO					
-- Proc 18	
ALTER PROCEDURE [dbo].[pr_V_DM_TAI_SAN_KHAC_Load_data_to_grid_tai_san_co_nguyen_gia_tren_500_trieu_by_tu_khoa]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_str_loai_hinh_don_vi NVARCHAR(250)
,@ip_str_user_name NVARCHAR(250)
,@ip_str_tu_khoa NVARCHAR(250)
AS

SELECT 
*
FROM V_DM_TAI_SAN_KHAC tsk
WHERE 
		((tsk.ID_DON_VI_SU_DUNG = @ip_dc_id_don_vi_su_dung ) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND (tsk.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))			    
		AND ((tsk.ID_DON_VI_CHU_QUAN = @ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND	 (tsk.ID_DON_VI_CHU_QUAN IN 
				(SELECT id FROM dm_don_vi dv 
				 WHERE 
					((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				)
		)
		AND (tsk.TEN_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%' 
				OR tsk.ID LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.MA_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_DV_SU_DUNG LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_DV_BO_TINH LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_DV_CHU_QUAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_TRANG_THAI LIKE N'%'+ @ip_str_tu_khoa +'%'
				)
		AND ((tsk.ID_TRANG_THAI = @ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))
		AND tsk.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)	
		AND (tsk.NGUON_NS+tsk.NGUON_KHAC>=500000000)
GO			
-- Proc 19
ALTER PROCEDURE [dbo].[pr_V_DM_TAI_SAN_KHAC_Load_data_to_grid_tai_san_co_nguyen_gia_tren_500_trieu_loai_hinh]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_str_loai_hinh_don_vi NVARCHAR(250)
,@ip_str_user_name NVARCHAR(250)
AS

SELECT 
*
FROM v_dm_tai_san_khac tsk
WHERE 
		    ((tsk.ID_DON_VI_SU_DUNG = @ip_dc_id_don_vi_su_dung ) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND (tsk.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))			    
		AND ((tsk.ID_DON_VI_CHU_QUAN = @ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND	 (tsk.ID_DON_VI_CHU_QUAN IN 
				(SELECT id FROM dm_don_vi dv 
				 WHERE 
					((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				)
			 )
		AND ((tsk.ID_TRANG_THAI = @ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))
		AND tsk.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)	
		AND (tsk.NGUON_NS+tsk.NGUON_KHAC>=500000000)	
ORDER BY tsk.TEN_TAI_SAN		
	
GO	
-- Proc 20
ALTER PROCEDURE [dbo].[pr_V_DM_TAI_SAN_KHAC_Load_data_to_grid_tai_san_khac]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_str_user_name NVARCHAR(250)
AS

SELECT * FROM V_DM_TAI_SAN_KHAC v
WHERE
		    ((v.ID_DON_VI_SU_DUNG=@ip_dc_id_don_vi_su_dung) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND ((v.ID_DON_VI_CHU_QUAN=@ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND (v.ID_DON_VI_CHU_QUAN IN
				(SELECT ID FROM DM_DON_VI ddv
				 WHERE ((ddv.ID_DON_VI_CAP_TREN=@ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				 )
		     )
		AND	((v.ID_TRANG_THAI=@ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))
		AND v.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)
ORDER BY v.TEN_TAI_SAN
GO	
-- Proc 21	
ALTER PROCEDURE [dbo].[pr_V_DM_TAI_SAN_KHAC_Load_data_to_grid_tai_san_khac_loai_hinh]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_dc_id_loai_tai_san NUMERIC(18,0)
,@ip_str_loai_hinh_don_vi NVARCHAR(250)
,@ip_str_user_name NVARCHAR(250)
,@ip_str_tu_khoa NVARCHAR(250)
AS

SELECT 
*
FROM v_dm_tai_san_khac tsk
WHERE 
		    ((tsk.ID_DON_VI_SU_DUNG = @ip_dc_id_don_vi_su_dung ) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND (tsk.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))			    
		AND ((tsk.ID_DON_VI_CHU_QUAN = @ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND	 (tsk.ID_DON_VI_CHU_QUAN IN 
				(SELECT id FROM dm_don_vi dv 
				 WHERE 
					((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				)
			 )
		AND ((tsk.ID_TRANG_THAI = @ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))
		AND (tsk.ID_LOAI_TAI_SAN = @ip_dc_id_loai_tai_san 
		OR tsk.ID_LOAI_TAI_SAN 
			IN (SELECT dlts.ID
			      FROM DM_LOAI_TAI_SAN dlts WHERE dlts.ID_LOAI_TAI_SAN_PARENT = @ip_dc_id_loai_tai_san))
		AND tsk.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)	
		AND (tsk.TEN_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%' 
				OR tsk.ID LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.MA_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_DV_SU_DUNG LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_DV_BO_TINH LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_DV_CHU_QUAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_TRANG_THAI LIKE N'%'+ @ip_str_tu_khoa +'%'
				)		
ORDER BY tsk.TEN_TAI_SAN		
GO	
-- Proc 22
ALTER PROCEDURE [dbo].[pr_V_GD_KHAU_HAO_DM_DAT_Load_data_to_grid_by_tu_khoa]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_str_loai_hinh_don_vi NVARCHAR(250)
,@ip_str_user_name NVARCHAR(250)
,@ip_str_tu_khoa NVARCHAR(250)
AS

SELECT 
*
FROM V_GD_KHAU_HAO_DM_DAT dat
WHERE 
		((dat.ID_DON_VI_SU_DUNG = @ip_dc_id_don_vi_su_dung ) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND (dat.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))			    
		AND ((dat.ID_DON_VI_CHU_QUAN = @ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND	 (dat.ID_DON_VI_CHU_QUAN IN 
				(SELECT id FROM dm_don_vi dv 
				 WHERE 
					((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				)
		)
		AND (	dat.ID LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR dat.MA_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR dat.TEN_DV_SU_DUNG LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR dat.DIA_CHI LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR dat.TEN_DV_BO_TINH LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR dat.TEN_DV_CHU_QUAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR dat.TEN_TRANG_THAI LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR dat.MA_PHIEU LIKE N'%'+ @ip_str_tu_khoa +'%'
				)
		AND ((dat.ID_TRANG_THAI = @ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))
		AND dat.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)				
GO	
-- Proc 23	
ALTER PROCEDURE [dbo].[pr_V_GD_KHAU_HAO_DM_NHA_Load_data_to_grid_by_tu_khoa]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_dat NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_str_loai_hinh_don_vi NVARCHAR(250)
,@ip_str_user_name NVARCHAR(250)
,@ip_str_tu_khoa NVARCHAR(250)
AS

SELECT 
*
FROM V_GD_KHAU_HAO_DM_NHA nha
WHERE 
		((nha.ID_DON_VI_SU_DUNG = @ip_dc_id_don_vi_su_dung ) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND (nha.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))			    
		AND ((nha.ID_DON_VI_CHU_QUAN = @ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND	 (nha.ID_DON_VI_CHU_QUAN IN 
				(SELECT id FROM dm_don_vi dv 
				 WHERE 
					((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				)
		)
		AND (nha.TEN_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%' 
				OR nha.ID LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.MA_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.TEN_DV_SU_DUNG LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.DIA_CHI LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.TEN_DV_BO_TINH LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.TEN_DV_CHU_QUAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.TEN_TRANG_THAI LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.MA_PHIEU LIKE N'%'+ @ip_str_tu_khoa +'%'
				)
		AND ((nha.id_dat = @ip_dc_id_dat) OR (@ip_dc_id_dat = -1))
		AND ((nha.ID_TRANG_THAI = @ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))
		AND nha.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)	
GO	
-- Proc 24
ALTER PROCEDURE [dbo].[pr_V_GD_KHAU_HAO_DM_OTO_Load_data_to_grid_by_tu_khoa]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_dc_id_loai_tai_san NUMERIC(18,0)
,@ip_str_loai_hinh_don_vi NVARCHAR(250)
,@ip_str_user_name NVARCHAR(250)
,@ip_str_tu_khoa NVARCHAR(250)
AS

SELECT 
*
FROM V_GD_KHAU_HAO_DM_OTO oto
WHERE 
		((oto.ID_DON_VI_SU_DUNG = @ip_dc_id_don_vi_su_dung ) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND (oto.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))			    
		AND ((oto.ID_DON_VI_CHU_QUAN = @ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND	 (oto.ID_DON_VI_CHU_QUAN IN 
				(SELECT id FROM dm_don_vi dv 
				 WHERE 
					((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				)
		)
		AND (oto.TEN_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%' 
				OR oto.ID LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR oto.MA_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR oto.TEN_DV_SU_DUNG LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR oto.TEN_DV_BO_TINH LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR oto.TEN_DV_CHU_QUAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR oto.TEN_TRANG_THAI LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR oto.MA_PHIEU LIKE N'%'+ @ip_str_tu_khoa +'%'
				)
		AND ((oto.ID_LOAI_TAI_SAN = @ip_dc_id_loai_tai_san) OR (@ip_dc_id_loai_tai_san = -1))
		AND ((oto.ID_TRANG_THAI = @ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))
		AND oto.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)				
GO	
-- Proc 25	
ALTER PROCEDURE [dbo].[pr_V_GD_KHAU_HAO_DM_TAI_SAN_KHAC_Load_data_to_grid_by_tu_khoa]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_str_loai_hinh_don_vi NVARCHAR(250)
,@ip_str_user_name NVARCHAR(250)
,@ip_str_tu_khoa NVARCHAR(250)
AS

SELECT 
*
FROM V_GD_KHAU_HAO_DM_TAI_SAN_KHAC tsk
WHERE 
		((tsk.ID_DON_VI_SU_DUNG = @ip_dc_id_don_vi_su_dung ) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND (tsk.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))			    
		AND ((tsk.ID_DON_VI_CHU_QUAN = @ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND	 (tsk.ID_DON_VI_CHU_QUAN IN 
				(SELECT id FROM dm_don_vi dv 
				 WHERE 
					((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				)
		)
		AND (	tsk.ID LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.MA_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_DV_SU_DUNG LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_DV_BO_TINH LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_DV_CHU_QUAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_TRANG_THAI LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.MA_PHIEU LIKE N'%'+ @ip_str_tu_khoa +'%'
				)
		AND ((tsk.ID_TRANG_THAI = @ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))
		AND tsk.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)			
GO					
-- Proc 26
ALTER PROCEDURE [dbo].[pr_V_GD_TANG_GIAM_TAI_SAN_DAT]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_str_loai_hinh_don_vi NVARCHAR(250)
,@ip_str_user_name NVARCHAR(250)
,@ip_str_tu_khoa NVARCHAR(250)
AS
-- EXEC [pr_V_GD_TANG_GIAM_TAI_SAN_DAT] -1,-1,-1,-1,'DON_VI_SU_NGHIEP_TCTC','admin',''
SELECT 
*
FROM V_GD_TANG_GIAM_TAI_SAN_DAT dat
WHERE 
		((dat.ID_DON_VI_SU_DUNG = @ip_dc_id_don_vi_su_dung ) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND (dat.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))			    
		AND ((dat.ID_DON_VI_CHU_QUAN = @ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND	 (dat.ID_DON_VI_CHU_QUAN IN 
				(SELECT id FROM dm_don_vi dv 
				 WHERE 
					((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				)
		)
		AND (	dat.ID LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR dat.MA_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR dat.TEN_DV_SU_DUNG LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR dat.DIA_CHI LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR dat.TEN_DV_BO_TINH LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR dat.TEN_DV_CHU_QUAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR dat.TEN_TRANG_THAI LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR dat.MA_PHIEU LIKE N'%'+ @ip_str_tu_khoa +'%'
				)
		AND ((dat.ID_TRANG_THAI = @ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))
		AND dat.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)		
GO					
-- Proc 27	
ALTER PROCEDURE [dbo].[pr_V_GD_TANG_GIAM_TAI_SAN_KHAC]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_str_loai_hinh_don_vi NVARCHAR(250)
,@ip_str_user_name NVARCHAR(250)
,@ip_str_tu_khoa NVARCHAR(250)
AS
-- EXEC [pr_V_GD_TANG_GIAM_TAI_SAN_KHAC] -1,-1,-1,-1,'DON_VI_SU_NGHIEP_TCTC','admin',''
SELECT 
*
FROM V_GD_TANG_GIAM_TAI_SAN_KHAC tsk
WHERE 
		((tsk.ID_DON_VI_SU_DUNG = @ip_dc_id_don_vi_su_dung ) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND (tsk.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))			    
		AND ((tsk.ID_DON_VI_CHU_QUAN = @ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND	 (tsk.ID_DON_VI_CHU_QUAN IN 
				(SELECT id FROM dm_don_vi dv 
				 WHERE 
					((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				)
		)
		AND (	tsk.ID LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.MA_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_DV_SU_DUNG LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_DV_BO_TINH LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_DV_CHU_QUAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.TEN_TRANG_THAI LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR tsk.MA_PHIEU LIKE N'%'+ @ip_str_tu_khoa +'%'
				)
		AND ((tsk.ID_TRANG_THAI = @ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))
		AND tsk.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)
GO					
-- Proc 28
ALTER PROCEDURE [dbo].[pr_V_GD_TANG_GIAM_TAI_SAN_NHA]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_dat NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_str_loai_hinh_don_vi NVARCHAR(250)
,@ip_str_user_name NVARCHAR(250)
,@ip_str_tu_khoa NVARCHAR(250)
AS

SELECT 
*
FROM V_GD_TANG_GIAM_TAI_SAN_NHA nha
WHERE 
		((nha.ID_DON_VI_SU_DUNG = @ip_dc_id_don_vi_su_dung ) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND (nha.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))			    
		AND ((nha.ID_DON_VI_CHU_QUAN = @ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND	 (nha.ID_DON_VI_CHU_QUAN IN 
				(SELECT id FROM dm_don_vi dv 
				 WHERE 
					((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				)
		)
		AND (nha.TEN_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%' 
				OR nha.ID LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.MA_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.TEN_DV_SU_DUNG LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.DIA_CHI LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.TEN_DV_BO_TINH LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.TEN_DV_CHU_QUAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.TEN_TRANG_THAI LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR nha.MA_PHIEU LIKE N'%'+ @ip_str_tu_khoa +'%'
				)
		AND ((nha.id_dat = @ip_dc_id_dat) OR (@ip_dc_id_dat = -1))
		AND ((nha.ID_TRANG_THAI = @ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))
		AND nha.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)
GO					
-- Proc 29	
ALTER PROCEDURE [dbo].[pr_V_GD_TANG_GIAM_TAI_SAN_OTO]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
,@ip_dc_id_loai_tai_san NUMERIC(18,0)
,@ip_str_loai_hinh_don_vi NVARCHAR(250)
,@ip_str_user_name NVARCHAR(250)
,@ip_str_tu_khoa NVARCHAR(250)
AS
--EXEC [pr_V_GD_TANG_GIAM_TAI_SAN_OTO] -1,-1,-1,-1,-1,'DON_VI_SU_NGHIEP_TCTC','admin',''
SELECT 
*
FROM V_GD_TANG_GIAM_TAI_SAN_OTO oto
WHERE 
		((oto.ID_DON_VI_SU_DUNG = @ip_dc_id_don_vi_su_dung ) OR (@ip_dc_id_don_vi_su_dung = -1))
		AND (oto.ID_DON_VI_SU_DUNG IN 
			(SELECT ID FROM DM_DON_VI ddv WHERE ddv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi
			OR @ip_str_loai_hinh_don_vi = '-1'))			    
		AND ((oto.ID_DON_VI_CHU_QUAN = @ip_dc_id_don_vi_chu_quan) OR (@ip_dc_id_don_vi_chu_quan = -1))
		AND	 (oto.ID_DON_VI_CHU_QUAN IN 
				(SELECT id FROM dm_don_vi dv 
				 WHERE 
					((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_bo_tinh) OR (@ip_dc_id_bo_tinh = -1))
				)
		)
		AND (oto.TEN_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%' 
				OR oto.ID LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR oto.MA_TAI_SAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR oto.TEN_DV_SU_DUNG LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR oto.TEN_DV_BO_TINH LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR oto.TEN_DV_CHU_QUAN LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR oto.TEN_TRANG_THAI LIKE N'%'+ @ip_str_tu_khoa +'%'
				OR oto.MA_PHIEU LIKE N'%'+ @ip_str_tu_khoa +'%'
				)
		AND ((oto.ID_LOAI_TAI_SAN = @ip_dc_id_loai_tai_san) OR (@ip_dc_id_loai_tai_san = -1))
		AND ((oto.ID_TRANG_THAI = @ip_dc_id_trang_thai) OR (@ip_dc_id_trang_thai = -1))
		AND oto.ID_DON_VI_SU_DUNG
		IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)				
GO			
-- Proc 30

-- Proc 31	

-- Proc 32

-- Proc 33	

-- Proc 34

-- Proc 35	

-- Proc 36

-- Proc 37	

-- Proc 38
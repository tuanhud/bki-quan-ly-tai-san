USE bki_qlts
GO
-- Proc 1
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
	AND dm_oto.ID_DON_VI_CHU_QUAN
	IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)
GO		


-- Proc 2
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
	AND v.ID_DON_VI_CHU_QUAN
	IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)
ORDER BY
	v.NGAY_CAP_NHAT_CUOI DESC	
	,v.ID_DAT
GO			
-- Proc 3
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
	AND v.ID_DON_VI_CHU_QUAN
	IN (SELECT hqhsddl.ID_DON_VI
		    FROM HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
					, HT_NGUOI_SU_DUNG hnsd
		    WHERE hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
				AND hnsd.TEN_TRUY_CAP = @ip_str_user_name)			
ORDER BY
	v.TEN_LOAI_TAI_SAN
GO	
-- Proc 4	

-- Proc 5

-- Proc 6

-- Proc 7	

-- Proc 8

-- Proc 9

-- Proc 10	

-- Proc 11

-- Proc 12

-- Proc 13	

-- Proc 14
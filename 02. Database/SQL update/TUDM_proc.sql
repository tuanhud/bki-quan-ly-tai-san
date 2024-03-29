USE [BKI_QLTS]
GO

create PROCEDURE [dbo].[pr_V_DM_TAI_SAN_KHAC_Load_data_to_grid_tai_san_khac]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
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
		
				

---------------------------------------------------

create PROCEDURE [dbo].[pr_V_DM_NHA_Load_data_to_grid_nha]
@ip_dc_id_bo_tinh NUMERIC(18,0)
,@ip_dc_id_don_vi_chu_quan NUMERIC(18,0)
,@ip_dc_id_don_vi_su_dung NUMERIC(18,0)
,@ip_dc_id_dat NUMERIC(18,0)
,@ip_dc_id_trang_thai NUMERIC(18,0)
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
		
------------------------------------------------------------

ALTER PROC [dbo].[pr_DM_DON_VI_Select_by_user_name]

@ip_str_user_name NVARCHAR(50)
, @ip_dc_loai_don_vi NUMERIC(18,0)
, @ip_dc_id_dv_cap_tren1 NUMERIC(18,0)
, @ip_dc_id_dv_cap_tren2 NUMERIC(18,0)
, @ip_str_loai_hinh_don_vi NVARCHAR(250)
AS
/*
* @ip_dc_id_don_vi_cap_tren = -1 => All don vi 
* */


SELECT distinct dv.* FROM
DM_DON_VI dv
, HT_NGUOI_SU_DUNG hnsd
, HT_QUAN_HE_SU_DUNG_DU_LIEU hqhsddl
WHERE
	((dv.ID = hqhsddl.ID_DON_VI)
		OR ((dv.ID_DON_VI_CAP_TREN = hqhsddl.ID_DON_VI) AND (@ip_dc_loai_don_vi = 	576))	-- ID loại đơn vị sử dụng tài sản
	)
	
	
	AND hqhsddl.ID_USER_GROUP = hnsd.ID_USER_GROUP
	AND hnsd.TEN_TRUY_CAP = @ip_str_user_name	
	AND dv.ID_LOAI_DON_VI = @ip_dc_loai_don_vi
	AND ((dv.ID_DON_VI_CAP_TREN = @ip_dc_id_dv_cap_tren1) OR (@ip_dc_id_dv_cap_tren1 = -1))
	AND ((dv.ID_DON_VI_CAP_TREN IN
				(SELECT ID
				 FROM DM_DON_VI
				 WHERE ID_DON_VI_CAP_TREN =  @ip_dc_id_dv_cap_tren2)
			) 
			OR 
			(@ip_dc_id_dv_cap_tren2 = -1))
	AND ((dv.LOAI_HINH_DON_VI = @ip_str_loai_hinh_don_vi) OR (@ip_str_loai_hinh_don_vi = null))		
	
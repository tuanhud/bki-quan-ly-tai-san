


/* thay đổi caption cho menu*/
update
HT_CHUC_NANG
SET TEN_CHUC_NANG = N'Báo cáo của Đơn vị sử dụng'
WHERE TEN_CHUC_NANG = N'Báo cáo đơn vị sử dụng'

UPDATE HT_CHUC_NANG
SET
	ten_chuc_nang = N'2-Đề nghị xử lý'
	, VI_TRI = 3500
WHERE
ten_chuc_nang = N'Đề nghị xử lý'
and chuc_nang_parent_id = 84

UPDATE HT_CHUC_NANG
SET
	ten_chuc_nang = N'4-Khấu hao tài sản'
	, VI_TRI = 3700
WHERE
ten_chuc_nang = N'Khấu hao tài sản'
and chuc_nang_parent_id = 84

UPDATE HT_CHUC_NANG
SET
	ten_chuc_nang = N'3-Tăng giảm tài sản'
	, VI_TRI = 3600
WHERE
ten_chuc_nang = N'Tăng giảm tài sản'
and chuc_nang_parent_id = 84

UPDATE HT_CHUC_NANG
SET
	ten_chuc_nang = N'1-Nhập mới tài sản'
	, vi_tri =3100
	, HIEN_THI_YN = 'Y'
WHERE
ten_chuc_nang = N'Quản lý danh sách tài sản'
and chuc_nang_parent_id = 84

UPDATE HT_CHUC_NANG
SET
	chuc_nang_parent_id = 173 -- Nhập mới tài sản
	
WHERE
(ID =100 OR id = 101 OR ID = 104 OR ID =106) -- quan ly dat, nha, o to, tai san khac
and chuc_nang_parent_id = 84

UPDATE HT_CHUC_NANG
SET
	VI_TRI = 3100+(VI_TRI-3000)/10
	
WHERE
	chuc_nang_parent_id = 173
	
INSERT INTO HT_QUYEN_GROUP
(
	-- ID -- this column value is auto-generated,
	ID_USER_GROUP,
	ID_QUYEN
)

SELECT ID, 173
FROM HT_USER_GROUP hug
/*Đổi loại hình đơn vị sở thành cơ quan hành chính nhà nước*/
UPDATE DM_DON_VI
SET
	-- ID = ? -- this column value is auto-generated,
	
	LOAI_HINH_DON_VI = 'CO_QUAN_NHA_NUOC_HC'
	
WHERE TEN_DON_VI LIKE N'%Sở%'

/* ẩn menu danh mục trạng thái*/	
update HT_CHUC_NANG 
SET HIEN_THI_YN = 'N'
WHERE TEN_CHUC_NANG LIKE N'%Danh mục trạng thái%'

update
HT_CHUC_NANG
SET TEN_CHUC_NANG = N'Báo cáo Tổng cục'
WHERE TEN_CHUC_NANG = N'Báo cáo tổng cục'

/* Delete 03 tinh bi lap Sở GTVT Bình Phước   Sở GTVT Hải Phòng Sở GTVT Quảng Bình*/
DELETE FROM HT_QUAN_HE_SU_DUNG_DU_LIEU 
WHERE 
(ID_DON_VI = 184) OR (ID_DON_VI = 154) OR (ID_DON_VI = 169) 

DELETE FROM DM_DON_VI
WHERE (ID = 184) OR (ID = 154) OR (ID = 169)


/* Thêm loại tài sản chưa phân loại cho ô tô*/
INSERT INTO DM_LOAI_TAI_SAN
(
	-- ID -- this column value is auto-generated,
	TEN_LOAI_TAI_SAN,
	ID_LOAI_TAI_SAN_PARENT,
	ID_PHAN_LOAI
)
VALUES
(
	N'3.4. Xe chưa phân loại'
	, 3
	, 592
)

UPDATE	 DM_OTO 
	SET id_loai_tai_san = 10 -- Xe ô tô chưa phân loại
	
	
UPDATE	 DM_OTO_HISTORY 
	SET id_loai_tai_san = 10 -- Xe ô tô chưa phân loại


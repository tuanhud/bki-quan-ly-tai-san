
/*Bỏ chữ các ở các khu, ban*/
UPDATE DM_DON_VI
SET
	TEN_DON_VI = REPLACE(TEN_DON_VI,N'Các ','')
	
WHERE TEN_DON_VI LIKE N'%các%'


/*cập nhật tiêu đề*/
UPDATE ht_chuc_nang

SET TEN_CHUC_NANG = N'1-Nhập mới,sửa TT tài sản'
WHERE TEN_CHUC_NANG = N'1-Nhập mới tài sản'


UPDATE HT_CHUC_NANG
SET
	TEN_CHUC_NANG = N'Đất'
WHERE 
TEN_CHUC_NANG LIKE N'%Đất%'
AND 
(chuc_nang_parent_id = 108
or chuc_nang_parent_id = 110
or chuc_nang_parent_id = 173
or chuc_nang_parent_id = 196)

UPDATE HT_CHUC_NANG
SET
	TEN_CHUC_NANG = N'Nhà, trụ sở àm việc'
WHERE 
TEN_CHUC_NANG LIKE N'%Nhà%'
AND 
(chuc_nang_parent_id = 108
or chuc_nang_parent_id = 110
or chuc_nang_parent_id = 173
or chuc_nang_parent_id = 196)

UPDATE HT_CHUC_NANG
SET
	TEN_CHUC_NANG = N'Ô tô'
WHERE 
TEN_CHUC_NANG LIKE N'%Ô tô%'
AND 
(chuc_nang_parent_id = 108
or chuc_nang_parent_id = 110
or chuc_nang_parent_id = 173
or chuc_nang_parent_id = 196)

UPDATE HT_CHUC_NANG
SET
	TEN_CHUC_NANG = N'Tài sản khác'
WHERE 
TEN_CHUC_NANG LIKE N'%Tài sản%'
AND 
(chuc_nang_parent_id = 108
or chuc_nang_parent_id = 110
or chuc_nang_parent_id = 173
or chuc_nang_parent_id = 196)
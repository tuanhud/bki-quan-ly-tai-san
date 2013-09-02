using System;
using System.Collections.Generic;
using System.Text;

namespace WebUS
{
    public class LOAI_BAO_CAO
    {
        public const string KE_KHAI = "KE_KHAI";
        public const string DE_NGHI_XU_LY = "DE_NGHI_XU_LY";
        public const string THONG_KE = "THONG_KE";
    }

    public class TRANG_THAI_OTO
    {
        public const string DE_NGHI_XU_LY = "581";
        public const string DA_THANH_LY = "582";
        public const string DE_NGHI_TRANG_CAP = "583";
        public const string DANG_SU_DUNG = "584";
    }
    public class CONST_QLDB
    {
        public const string KHONG_CO_DU_LIEU = "";
        public const decimal ID_TAT_CA = -1;
        public const string MA_TAT_CA = "-1";
        public const string TAT_CA = "--------------------Tất cả--------------------";
        
        
      
        public class MA_THAM_SO_URL {
            public const string LOAI_BAO_CAO = "ip_str_loai_bao_cao";
            public const string LOAI_TAI_SAN_KHAC = "ip_str_loai_ts_khac";
            public const string TRANG_THAI = "ip_id_trang_thai";
            public const string ID_DVSD = "ip_id_don_vi_su_dung";
            public const string ID_NHA = "ip_id_nha";
            
            
            
        }
        public class LOAI_BAO_CAO {
            public const string DVSD = "DVSD";
            public const string DVCQ = "DVCQ";
            public const string BLD = "BLD";
        }
        public class LOAI_TAI_SAN {
            public const string TREN_500 = "TSK_TREN_500";
            public const string DUOI_500 = "TSK_DUOI_500";
            public const string TAI_SAN_KHAC = "TAI_SAN_KHAC";
        }
        public class TRANG_THAI {
            public const string KE_KHAI = "KE_KHAI";
            public const string DE_NGHI_XU_LY = "DE_NGHI_XU_LY";
        }
    }

    

    public class SESSION
    {
        public const string UserFullName = "UserFullName";
        public const string UserName = "UserName";
        public const string UserID = "UserID";

        public const string AccounLoginYN = "AccounLoginYN";
        public const string UserQuyen = "user_quyen";
        public const string QuyenGV = "QuyenGV";
    }

    public class MA_LOAI_TU_DIEN
    {
        public const string DIA_DIEM_QUAN_LY = "DIA_DIEM_QUAN_LY";
        public const string DON_VI_TINH = "DON_VI_TINH";
        public const string LOAI_DON_VI = "LOAI_DON_VI";
        public const string PHAN_LOAI_TAI_SAN = "PHAN_LOAI_TAI_SAN";
        public const string PHAN_QUYEN = "PHAN_QUYEN";
        public const string TRANG_THAI_DAT = "TRANG_THAI_DAT";
        public const string TRANG_THAI_NHA = "TRANG_THAI_NHA";
        public const string TRANG_THAI_OTO = "TRANG_THAI_OTO";
        public const string TRANG_THAI_TAI_SAN_KHAC = "TRANG_THAI_TAI_SAN_KHAC";
        public const string LOAI_HINH_DON_VI = "LOAI_HINH_DON_VI";
        public const string LOAI_BAO_CAO = "LOAI_BAO_CAO";
        public const string TINH_TRANG_TAI_SAN = "TINH_TRANG_TAI_SAN";
    }

    public class ID_TRANG_THAI_DAT
    {
        public const decimal DE_NGHI_XU_LY = 594;
        public const decimal DA_THANH_LY = 595;
        public const decimal DE_NGHI_TRANG_CAP = 596;
        public const decimal DANG_SU_DUNG = 597;
    }

    public class ID_TRANG_THAI_NHA
    {
        public const decimal DE_NGHI_XU_LY = 577;
        public const decimal DA_THANH_LY = 578;
        public const decimal DE_NGHI_TRANG_CAP = 579;
        public const decimal DANG_SU_DUNG = 580;
    }

    public class ID_TRANG_THAI_OTO
    {
        public const decimal DE_NGHI_XU_LY = 581;
        public const decimal DA_THANH_LY = 582;
        public const decimal DE_NGHI_TRANG_CAP = 583;
        public const decimal DANG_SU_DUNG = 584;
    }

    public class ID_LOAI_DON_VI
    {
        public const decimal BO_TINH = 574;
        public const decimal DV_CHU_QUAN = 575;
        public const decimal DV_SU_DUNG = 576;
    }

    public class ID_LOAI_TAI_SAN
    {
        public const decimal DAT = 1;
        public const decimal NHA = 2;
        public const decimal OTO = 3;
        public const decimal TAI_SAN_KHAC = 4;
        public const decimal TAI_SAN_KHAC_LON_HON_500 = 8;
        public const decimal TAI_SAN_KHAC_NHO_HON_500 = 9;
    }

    public class LOAI_USER_QUYEN
    {
        public const decimal ADMIN = 5;
        public const decimal CAN_BO_CHU_QUAN = 3;
        public const decimal CAN_BO_TONG_CUC = 4;
        public const decimal GROUP30 = 7;

    }
    public class ID_TRANG_THAI_TAI_SAN_KHAC
    {
        public const decimal DE_NGHI_XU_LY = 585;
        public const decimal DA_THANH_LY = 586;
        public const decimal DE_NGHI_TRANG_CAP = 587;
        public const decimal DANG_SU_DUNG = 588;
    }

    public class ID_TINH_TRANG
    {
        public const decimal TOT = 611;
        public const decimal XAU = 612;
    }

    public class ID_LOAI_HINH_DON_VI
    {
        public const decimal CO_QUAN_NHA_NUOC_HC = 598;
        public const decimal CO_QUAN_NHA_NUOC_KHAC = 601;
        public const decimal DON_VI_SU_NGHIEP_CTCTC = 605;
        public const decimal DON_VI_SU_NGHIEP_GIAO_DUC = 599;
        public const decimal DON_VI_SU_NGHIEP_TCTC = 604;
        public const decimal TO_CHUC_CT = 600;
        public const decimal TO_CHUC_CTXH = 607;
        public const decimal TO_CHUC_CTXHNN = 608;
        public const decimal TO_CHUC_XH = 609;
        public  const decimal TO_CHUC_XH_NN = 610;
    }

    public class TEN_LOAI_HINH_DON_VI
    {
        public const string CO_QUAN_NHA_NUOC_HC = "CO_QUAN_NHA_NUOC_HC";
        public const string CO_QUAN_NHA_NUOC_KHAC = "CO_QUAN_NHA_NUOC_KHAC";
        public const string DON_VI_SU_NGHIEP_CTCTC = "DON_VI_SU_NGHIEP_CTCTC";
        public const string DON_VI_SU_NGHIEP_GIAO_DUC = "DON_VI_SU_NGHIEP_GIAO_DUC";
        public const string DON_VI_SU_NGHIEP_TCTC = "DON_VI_SU_NGHIEP_TCTC";
        public const string TO_CHUC_CT = "TO_CHUC_CT";
        public const string TO_CHUC_CTXH = "TO_CHUC_CTXH";
        public const string TO_CHUC_CTXHNN = "TO_CHUC_CTXHNN";
        public const string TO_CHUC_XH = "TO_CHUC_XH";
        public const string TO_CHUC_XH_NN = "TO_CHUC_XH_NN";
    }
}

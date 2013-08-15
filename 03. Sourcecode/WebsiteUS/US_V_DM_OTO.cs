///************************************************
/// Generated by: TrongHV
/// Date: 28/07/2013 04:10:07
/// Goal: Create User Service Class for V_DM_OTO
///************************************************
/// <summary>
/// Create User Service Class for V_DM_OTO
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;
using WebDS.CDBNames;

namespace WebUS
{

    public class US_V_DM_OTO : US_Object
    {
        private const string c_TableName = "V_DM_OTO";
        #region "Public Properties"
        public decimal dcID
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID"] = value;
            }
        }

        public bool IsIDNull()
        {
            return pm_objDR.IsNull("ID");
        }

        public void SetIDNull()
        {
            pm_objDR["ID"] = System.Convert.DBNull;
        }

        public string strTEN_TAI_SAN
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "TEN_TAI_SAN", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["TEN_TAI_SAN"] = value;
            }
        }

        public bool IsTEN_TAI_SANNull()
        {
            return pm_objDR.IsNull("TEN_TAI_SAN");
        }

        public void SetTEN_TAI_SANNull()
        {
            pm_objDR["TEN_TAI_SAN"] = System.Convert.DBNull;
        }

        public string strMA_TAI_SAN
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "MA_TAI_SAN", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["MA_TAI_SAN"] = value;
            }
        }

        public bool IsMA_TAI_SANNull()
        {
            return pm_objDR.IsNull("MA_TAI_SAN");
        }

        public void SetMA_TAI_SANNull()
        {
            pm_objDR["MA_TAI_SAN"] = System.Convert.DBNull;
        }

        public decimal dcID_LOAI_TAI_SAN
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_LOAI_TAI_SAN", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_LOAI_TAI_SAN"] = value;
            }
        }

        public bool IsID_LOAI_TAI_SANNull()
        {
            return pm_objDR.IsNull("ID_LOAI_TAI_SAN");
        }

        public void SetID_LOAI_TAI_SANNull()
        {
            pm_objDR["ID_LOAI_TAI_SAN"] = System.Convert.DBNull;
        }

        public string strNHAN_HIEU
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "NHAN_HIEU", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["NHAN_HIEU"] = value;
            }
        }

        public bool IsNHAN_HIEUNull()
        {
            return pm_objDR.IsNull("NHAN_HIEU");
        }

        public void SetNHAN_HIEUNull()
        {
            pm_objDR["NHAN_HIEU"] = System.Convert.DBNull;
        }

        public string strNUOC_SAN_XUAT
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "NUOC_SAN_XUAT", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["NUOC_SAN_XUAT"] = value;
            }
        }

        public bool IsNUOC_SAN_XUATNull()
        {
            return pm_objDR.IsNull("NUOC_SAN_XUAT");
        }

        public void SetNUOC_SAN_XUATNull()
        {
            pm_objDR["NUOC_SAN_XUAT"] = System.Convert.DBNull;
        }

        public string strBIEN_KIEM_SOAT
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "BIEN_KIEM_SOAT", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["BIEN_KIEM_SOAT"] = value;
            }
        }

        public bool IsBIEN_KIEM_SOATNull()
        {
            return pm_objDR.IsNull("BIEN_KIEM_SOAT");
        }

        public void SetBIEN_KIEM_SOATNull()
        {
            pm_objDR["BIEN_KIEM_SOAT"] = System.Convert.DBNull;
        }

        public decimal dcSO_CHO_NGOI
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "SO_CHO_NGOI", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["SO_CHO_NGOI"] = value;
            }
        }

        public bool IsSO_CHO_NGOINull()
        {
            return pm_objDR.IsNull("SO_CHO_NGOI");
        }

        public void SetSO_CHO_NGOINull()
        {
            pm_objDR["SO_CHO_NGOI"] = System.Convert.DBNull;
        }

        public decimal dcCONG_SUAT_XE
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "CONG_SUAT_XE", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["CONG_SUAT_XE"] = value;
            }
        }

        public bool IsCONG_SUAT_XENull()
        {
            return pm_objDR.IsNull("CONG_SUAT_XE");
        }

        public void SetCONG_SUAT_XENull()
        {
            pm_objDR["CONG_SUAT_XE"] = System.Convert.DBNull;
        }

        public string strCHUC_DANH_SU_DUNG
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "CHUC_DANH_SU_DUNG", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["CHUC_DANH_SU_DUNG"] = value;
            }
        }

        public bool IsCHUC_DANH_SU_DUNGNull()
        {
            return pm_objDR.IsNull("CHUC_DANH_SU_DUNG");
        }

        public void SetCHUC_DANH_SU_DUNGNull()
        {
            pm_objDR["CHUC_DANH_SU_DUNG"] = System.Convert.DBNull;
        }

        public string strNGUON_GOC_XE
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "NGUON_GOC_XE", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["NGUON_GOC_XE"] = value;
            }
        }

        public bool IsNGUON_GOC_XENull()
        {
            return pm_objDR.IsNull("NGUON_GOC_XE");
        }

        public void SetNGUON_GOC_XENull()
        {
            pm_objDR["NGUON_GOC_XE"] = System.Convert.DBNull;
        }

        public decimal dcNAM_SAN_XUAT
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "NAM_SAN_XUAT", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["NAM_SAN_XUAT"] = value;
            }
        }

        public bool IsNAM_SAN_XUATNull()
        {
            return pm_objDR.IsNull("NAM_SAN_XUAT");
        }

        public void SetNAM_SAN_XUATNull()
        {
            pm_objDR["NAM_SAN_XUAT"] = System.Convert.DBNull;
        }

        public decimal dcNAM_SU_DUNG
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "NAM_SU_DUNG", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["NAM_SU_DUNG"] = value;
            }
        }

        public bool IsNAM_SU_DUNGNull()
        {
            return pm_objDR.IsNull("NAM_SU_DUNG");
        }

        public void SetNAM_SU_DUNGNull()
        {
            pm_objDR["NAM_SU_DUNG"] = System.Convert.DBNull;
        }

        public decimal dcNGUON_NS
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "NGUON_NS", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["NGUON_NS"] = value;
            }
        }

        public bool IsNGUON_NSNull()
        {
            return pm_objDR.IsNull("NGUON_NS");
        }

        public void SetNGUON_NSNull()
        {
            pm_objDR["NGUON_NS"] = System.Convert.DBNull;
        }

        public decimal dcNGUON_KHAC
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "NGUON_KHAC", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["NGUON_KHAC"] = value;
            }
        }

        public bool IsNGUON_KHACNull()
        {
            return pm_objDR.IsNull("NGUON_KHAC");
        }

        public void SetNGUON_KHACNull()
        {
            pm_objDR["NGUON_KHAC"] = System.Convert.DBNull;
        }

        public decimal dcGIA_TRI_CON_LAI
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "GIA_TRI_CON_LAI", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["GIA_TRI_CON_LAI"] = value;
            }
        }

        public bool IsGIA_TRI_CON_LAINull()
        {
            return pm_objDR.IsNull("GIA_TRI_CON_LAI");
        }

        public void SetGIA_TRI_CON_LAINull()
        {
            pm_objDR["GIA_TRI_CON_LAI"] = System.Convert.DBNull;
        }

        public decimal dcQLNN
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "QLNN", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["QLNN"] = value;
            }
        }

        public bool IsQLNNNull()
        {
            return pm_objDR.IsNull("QLNN");
        }

        public void SetQLNNNull()
        {
            pm_objDR["QLNN"] = System.Convert.DBNull;
        }

        public decimal dcKINH_DOANH
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "KINH_DOANH", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["KINH_DOANH"] = value;
            }
        }

        public bool IsKINH_DOANHNull()
        {
            return pm_objDR.IsNull("KINH_DOANH");
        }

        public void SetKINH_DOANHNull()
        {
            pm_objDR["KINH_DOANH"] = System.Convert.DBNull;
        }

        public decimal dcKHONG_KINH_DOANH
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "KHONG_KINH_DOANH", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["KHONG_KINH_DOANH"] = value;
            }
        }

        public bool IsKHONG_KINH_DOANHNull()
        {
            return pm_objDR.IsNull("KHONG_KINH_DOANH");
        }

        public void SetKHONG_KINH_DOANHNull()
        {
            pm_objDR["KHONG_KINH_DOANH"] = System.Convert.DBNull;
        }

        public decimal dcHD_KHAC
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "HD_KHAC", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["HD_KHAC"] = value;
            }
        }

        public bool IsHD_KHACNull()
        {
            return pm_objDR.IsNull("HD_KHAC");
        }

        public void SetHD_KHACNull()
        {
            pm_objDR["HD_KHAC"] = System.Convert.DBNull;
        }

        public decimal dcID_TRANG_THAI
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_TRANG_THAI", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_TRANG_THAI"] = value;
            }
        }

        public bool IsID_TRANG_THAINull()
        {
            return pm_objDR.IsNull("ID_TRANG_THAI");
        }

        public void SetID_TRANG_THAINull()
        {
            pm_objDR["ID_TRANG_THAI"] = System.Convert.DBNull;
        }

        public DateTime datNGAY_CAP_NHAT_CUOI
        {
            get
            {
                return CNull.RowNVLDate(pm_objDR, "NGAY_CAP_NHAT_CUOI", IPConstants.c_DefaultDate);
            }
            set
            {
                pm_objDR["NGAY_CAP_NHAT_CUOI"] = value;
            }
        }

        public bool IsNGAY_CAP_NHAT_CUOINull()
        {
            return pm_objDR.IsNull("NGAY_CAP_NHAT_CUOI");
        }

        public void SetNGAY_CAP_NHAT_CUOINull()
        {
            pm_objDR["NGAY_CAP_NHAT_CUOI"] = System.Convert.DBNull;
        }

        public decimal dcID_NGUOI_LAP
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_NGUOI_LAP", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_NGUOI_LAP"] = value;
            }
        }

        public bool IsID_NGUOI_LAPNull()
        {
            return pm_objDR.IsNull("ID_NGUOI_LAP");
        }

        public void SetID_NGUOI_LAPNull()
        {
            pm_objDR["ID_NGUOI_LAP"] = System.Convert.DBNull;
        }

        public decimal dcID_NGUOI_DUYET
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_NGUOI_DUYET", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_NGUOI_DUYET"] = value;
            }
        }

        public bool IsID_NGUOI_DUYETNull()
        {
            return pm_objDR.IsNull("ID_NGUOI_DUYET");
        }

        public void SetID_NGUOI_DUYETNull()
        {
            pm_objDR["ID_NGUOI_DUYET"] = System.Convert.DBNull;
        }

        public decimal dcID_DON_VI_SU_DUNG
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_DON_VI_SU_DUNG", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_DON_VI_SU_DUNG"] = value;
            }
        }

        public bool IsID_DON_VI_SU_DUNGNull()
        {
            return pm_objDR.IsNull("ID_DON_VI_SU_DUNG");
        }

        public void SetID_DON_VI_SU_DUNGNull()
        {
            pm_objDR["ID_DON_VI_SU_DUNG"] = System.Convert.DBNull;
        }

        public decimal dcID_DON_VI_CHU_QUAN
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_DON_VI_CHU_QUAN", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_DON_VI_CHU_QUAN"] = value;
            }
        }

        public bool IsID_DON_VI_CHU_QUANNull()
        {
            return pm_objDR.IsNull("ID_DON_VI_CHU_QUAN");
        }

        public void SetID_DON_VI_CHU_QUANNull()
        {
            pm_objDR["ID_DON_VI_CHU_QUAN"] = System.Convert.DBNull;
        }

        public string strTEN_LOAI_TAI_SAN
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "TEN_LOAI_TAI_SAN", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["TEN_LOAI_TAI_SAN"] = value;
            }
        }

        public bool IsTEN_LOAI_TAI_SANNull()
        {
            return pm_objDR.IsNull("TEN_LOAI_TAI_SAN");
        }

        public void SetTEN_LOAI_TAI_SANNull()
        {
            pm_objDR["TEN_LOAI_TAI_SAN"] = System.Convert.DBNull;
        }

        #endregion
        #region "Init Functions"
        public US_V_DM_OTO()
        {
            pm_objDS = new DS_V_DM_OTO();
            pm_strTableName = c_TableName;
            pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
        }

        public US_V_DM_OTO(DataRow i_objDR)
            : this()
        {
            this.DataRow2Me(i_objDR);
        }

        public US_V_DM_OTO(decimal i_dbID)
        {
            pm_objDS = new DS_V_DM_OTO();
            pm_strTableName = c_TableName;
            IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
            v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
            SqlCommand v_cmdSQL;
            v_cmdSQL = v_objMkCmd.getSelectCmd();
            this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
            pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
        }
        #endregion

        #region Addtional
        public void FillDataset(
            decimal ip_dc_don_vi_chu_quan
            , decimal ip_dc_trang_thai
            , DS_V_DM_OTO op_ds_v_oto)
        {

            IMakeSelectCmd v_obj_mak_cmd = new CMakeAndSelectCmd(op_ds_v_oto, this.pm_strTableName);

            v_obj_mak_cmd.AddCondition(
                V_DM_OTO.ID_DON_VI_SU_DUNG
                , ip_dc_don_vi_chu_quan
                , eKieuDuLieu.KieuNumber
                , eKieuSoSanh.Bang);
            v_obj_mak_cmd.AddCondition(
                    V_DM_OTO.ID_TRANG_THAI
                    , ip_dc_trang_thai
                    , eKieuDuLieu.KieuNumber
                    , eKieuSoSanh.Bang);
            SqlCommand v_obj_sql_cmd = v_obj_mak_cmd.getSelectCmd();
            v_obj_sql_cmd.CommandText += " ORDER BY " + V_DM_OTO.ID_LOAI_TAI_SAN;

            this.FillDatasetByCommand(op_ds_v_oto, v_obj_sql_cmd);

        }

        public void load_oto_by_ten(DS_V_DM_OTO op_ds_oto, string ip_str_search)
        {
            CStoredProc v_cstore = new CStoredProc("pr_V_DM_OTO_Search_by_Ten");
            v_cstore.addNVarcharInputParam("@ip_str_ten_oto_search", ip_str_search);
            v_cstore.fillDataSetByCommand(this, op_ds_oto);
        }

        #endregion

    }
}

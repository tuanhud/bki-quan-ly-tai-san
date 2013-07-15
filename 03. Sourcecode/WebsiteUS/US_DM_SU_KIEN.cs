﻿using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;

namespace WebUS
{
    public class US_DM_SU_KIEN : US_Object
    {
        private const string c_TableName = "DM_SU_KIEN";
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

        public decimal dcID_LOAI_SU_KIEN
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_LOAI_SU_KIEN", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_LOAI_SU_KIEN"] = value;
            }
        }

        public bool IsID_LOAI_SU_KIENNull()
        {
            return pm_objDR.IsNull("ID_LOAI_SU_KIEN");
        }

        public void SetID_LOAI_SU_KIENNull()
        {
            pm_objDR["ID_LOAI_SU_KIEN"] = System.Convert.DBNull;
        }

        public string strTEN_SU_KIEN
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "TEN_SU_KIEN", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["TEN_SU_KIEN"] = value;
            }
        }

        public bool IsTEN_SU_KIENNull()
        {
            return pm_objDR.IsNull("TEN_SU_KIEN");
        }

        public void SetTEN_SU_KIENNull()
        {
            pm_objDR["TEN_SU_KIEN"] = System.Convert.DBNull;
        }

        public DateTime datNGAY_DIEN_RA
        {
            get
            {
                return CNull.RowNVLDate(pm_objDR, "NGAY_DIEN_RA", IPConstants.c_DefaultDate);
            }
            set
            {
                pm_objDR["NGAY_DIEN_RA"] = value;
            }
        }

        public bool IsNGAY_DIEN_RANull()
        {
            return pm_objDR.IsNull("NGAY_DIEN_RA");
        }

        public void SetNGAY_DIEN_RANull()
        {
            pm_objDR["NGAY_DIEN_RA"] = System.Convert.DBNull;
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

        public string strMO_TA
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "MO_TA", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["MO_TA"] = value;
            }
        }

        public bool IsMO_TANull()
        {
            return pm_objDR.IsNull("MO_TA");
        }

        public void SetMO_TANull()
        {
            pm_objDR["MO_TA"] = System.Convert.DBNull;
        }

        public decimal dcID_DV_TO_CHUC_SK
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_DV_TO_CHUC_SK", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_DV_TO_CHUC_SK"] = value;
            }
        }

        public bool IsID_DV_TO_CHUC_SKNull()
        {
            return pm_objDR.IsNull("ID_DV_TO_CHUC_SK");
        }

        public void SetID_DV_TO_CHUC_SKNull()
        {
            pm_objDR["ID_DV_TO_CHUC_SK"] = System.Convert.DBNull;
        }
        
        #endregion

        #region "Init Functions"
        public US_DM_SU_KIEN()
        {
            pm_objDS = new DS_DM_SU_KIEN();
            pm_strTableName = c_TableName;
            pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
        }

        public US_DM_SU_KIEN(DataRow i_objDR)
            : this()
        {
            this.DataRow2Me(i_objDR);
        }

        public US_DM_SU_KIEN(decimal i_dbID)
        {
            pm_objDS = new DS_DM_SU_KIEN();
            pm_strTableName = c_TableName;
            IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
            v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
            SqlCommand v_cmdSQL;
            v_cmdSQL = v_objMkCmd.getSelectCmd();
            this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
            pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
        }
        #endregion

        #region Additional Functions
        public void get_su_kien_by_loai_va_thoi_gian(DS_DM_SU_KIEN op_ds_su_kien
                                                    , decimal ip_dc_loai_su_kien
                                                    , decimal ip_dc_thang
                                                    , decimal ip_dc_nam
                                                    , decimal ip_dc_dv_to_chuc_sk)
        {
            CStoredProc v_cstore = new CStoredProc("pr_DM_SU_KIEN_Loc_Su_Kien_Theo_Loai_Va_Thoi_Gian");
            v_cstore.addDecimalInputParam("@ID_LOAI_SU_KIEN", ip_dc_loai_su_kien);
            v_cstore.addDecimalInputParam("@THANG", ip_dc_thang);
            v_cstore.addDecimalInputParam("@NAm", ip_dc_nam);
            v_cstore.addDecimalInputParam("@DV_TO_CHUC_SK", ip_dc_dv_to_chuc_sk);
            v_cstore.fillDataSetByCommand(this, op_ds_su_kien);
        }
        #endregion
    }

}

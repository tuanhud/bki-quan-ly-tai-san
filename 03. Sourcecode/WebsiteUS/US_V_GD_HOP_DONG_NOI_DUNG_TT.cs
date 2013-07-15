///************************************************
/// Generated by: linhdh
/// Date: 20/10/2011 02:48:44
/// Goal: Create User Service Class for V_GD_HOP_DONG_NOI_DUNG_TT
///************************************************
/// <summary>
/// Create User Service Class for V_GD_HOP_DONG_NOI_DUNG_TT
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS
{

public class US_V_GD_HOP_DONG_NOI_DUNG_TT : US_Object
{
    private const string c_TableName = "V_GD_HOP_DONG_NOI_DUNG_TT";
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

    public decimal dcID_HOP_DONG_KHUNG
    {
        get
        {
            return CNull.RowNVLDecimal(pm_objDR, "ID_HOP_DONG_KHUNG", IPConstants.c_DefaultDecimal);
        }
        set
        {
            pm_objDR["ID_HOP_DONG_KHUNG"] = value;
        }
    }

    public bool IsID_HOP_DONG_KHUNGNull()
    {
        return pm_objDR.IsNull("ID_HOP_DONG_KHUNG");
    }

    public void SetID_HOP_DONG_KHUNGNull()
    {
        pm_objDR["ID_HOP_DONG_KHUNG"] = System.Convert.DBNull;
    }

    public string strSO_HOP_DONG
    {
        get
        {
            return CNull.RowNVLString(pm_objDR, "SO_HOP_DONG", IPConstants.c_DefaultString);
        }
        set
        {
            pm_objDR["SO_HOP_DONG"] = value;
        }
    }

    public bool IsSO_HOP_DONGNull()
    {
        return pm_objDR.IsNull("SO_HOP_DONG");
    }

    public void SetSO_HOP_DONGNull()
    {
        pm_objDR["SO_HOP_DONG"] = System.Convert.DBNull;
    }

    public string strTEN_GIANG_VIEN
    {
        get
        {
            return CNull.RowNVLString(pm_objDR, "TEN_GIANG_VIEN", IPConstants.c_DefaultString);
        }
        set
        {
            pm_objDR["TEN_GIANG_VIEN"] = value;
        }
    }

    public bool IsTEN_GIANG_VIENNull()
    {
        return pm_objDR.IsNull("TEN_GIANG_VIEN");
    }

    public void SetTEN_GIANG_VIENNull()
    {
        pm_objDR["TEN_GIANG_VIEN"] = System.Convert.DBNull;
    }

    public decimal dcID_NOI_DUNG_TT
    {
        get
        {
            return CNull.RowNVLDecimal(pm_objDR, "ID_NOI_DUNG_TT", IPConstants.c_DefaultDecimal);
        }
        set
        {
            pm_objDR["ID_NOI_DUNG_TT"] = value;
        }
    }

    public bool IsID_NOI_DUNG_TTNull()
    {
        return pm_objDR.IsNull("ID_NOI_DUNG_TT");
    }

    public void SetID_NOI_DUNG_TTNull()
    {
        pm_objDR["ID_NOI_DUNG_TT"] = System.Convert.DBNull;
    }

    public string strNOI_DUNG_THANH_TOAN
    {
        get
        {
            return CNull.RowNVLString(pm_objDR, "NOI_DUNG_THANH_TOAN", IPConstants.c_DefaultString);
        }
        set
        {
            pm_objDR["NOI_DUNG_THANH_TOAN"] = value;
        }
    }

    public bool IsNOI_DUNG_THANH_TOANNull()
    {
        return pm_objDR.IsNull("NOI_DUNG_THANH_TOAN");
    }

    public void SetNOI_DUNG_THANH_TOANNull()
    {
        pm_objDR["NOI_DUNG_THANH_TOAN"] = System.Convert.DBNull;
    }

    public string strGHI_CHU_NOI_DUNG_TT
    {
        get
        {
            return CNull.RowNVLString(pm_objDR, "GHI_CHU_NOI_DUNG_TT", IPConstants.c_DefaultString);
        }
        set
        {
            pm_objDR["GHI_CHU_NOI_DUNG_TT"] = value;
        }
    }

    public bool IsGHI_CHU_NOI_DUNG_TTNull()
    {
        return pm_objDR.IsNull("GHI_CHU_NOI_DUNG_TT");
    }

    public void SetGHI_CHU_NOI_DUNG_TTNull()
    {
        pm_objDR["GHI_CHU_NOI_DUNG_TT"] = System.Convert.DBNull;
    }

    public decimal dcSO_LUONG_HE_SO
    {
        get
        {
            return CNull.RowNVLDecimal(pm_objDR, "SO_LUONG_HE_SO", IPConstants.c_DefaultDecimal);
        }
        set
        {
            pm_objDR["SO_LUONG_HE_SO"] = value;
        }
    }

    public bool IsSO_LUONG_HE_SONull()
    {
        return pm_objDR.IsNull("SO_LUONG_HE_SO");
    }

    public void SetSO_LUONG_HE_SONull()
    {
        pm_objDR["SO_LUONG_HE_SO"] = System.Convert.DBNull;
    }

    public string strMA_DON_VI_TINH
    {
        get
        {
            return CNull.RowNVLString(pm_objDR, "MA_DON_VI_TINH", IPConstants.c_DefaultString);
        }
        set
        {
            pm_objDR["MA_DON_VI_TINH"] = value;
        }
    }

    public bool IsMA_DON_VI_TINHNull()
    {
        return pm_objDR.IsNull("MA_DON_VI_TINH");
    }

    public void SetMA_DON_VI_TINHNull()
    {
        pm_objDR["MA_DON_VI_TINH"] = System.Convert.DBNull;
    }

    public string strDON_VI_TINH
    {
        get
        {
            return CNull.RowNVLString(pm_objDR, "DON_VI_TINH", IPConstants.c_DefaultString);
        }
        set
        {
            pm_objDR["DON_VI_TINH"] = value;
        }
    }

    public bool IsDON_VI_TINHNull()
    {
        return pm_objDR.IsNull("DON_VI_TINH");
    }

    public void SetDON_VI_TINHNull()
    {
        pm_objDR["DON_VI_TINH"] = System.Convert.DBNull;
    }

    public string strMA_TAN_SUAT
    {
        get
        {
            return CNull.RowNVLString(pm_objDR, "MA_TAN_SUAT", IPConstants.c_DefaultString);
        }
        set
        {
            pm_objDR["MA_TAN_SUAT"] = value;
        }
    }

    public bool IsMA_TAN_SUATNull()
    {
        return pm_objDR.IsNull("MA_TAN_SUAT");
    }

    public void SetMA_TAN_SUATNull()
    {
        pm_objDR["MA_TAN_SUAT"] = System.Convert.DBNull;
    }

    public string strTAN_SUAT
    {
        get
        {
            return CNull.RowNVLString(pm_objDR, "TAN_SUAT", IPConstants.c_DefaultString);
        }
        set
        {
            pm_objDR["TAN_SUAT"] = value;
        }
    }

    public bool IsTAN_SUATNull()
    {
        return pm_objDR.IsNull("TAN_SUAT");
    }

    public void SetTAN_SUATNull()
    {
        pm_objDR["TAN_SUAT"] = System.Convert.DBNull;
    }

    public decimal dcDON_GIA_HD
    {
        get
        {
            return CNull.RowNVLDecimal(pm_objDR, "DON_GIA_HD", IPConstants.c_DefaultDecimal);
        }
        set
        {
            pm_objDR["DON_GIA_HD"] = value;
        }
    }

    public bool IsDON_GIA_HDNull()
    {
        return pm_objDR.IsNull("DON_GIA_HD");
    }

    public void SetDON_GIA_HDNull()
    {
        pm_objDR["DON_GIA_HD"] = System.Convert.DBNull;
    }

    #endregion
    #region "Init Functions"
    public US_V_GD_HOP_DONG_NOI_DUNG_TT()
    {
        pm_objDS = new DS_V_GD_HOP_DONG_NOI_DUNG_TT();
        pm_strTableName = c_TableName;
        pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
    }

    public US_V_GD_HOP_DONG_NOI_DUNG_TT(DataRow i_objDR)
        : this()
    {
        this.DataRow2Me(i_objDR);
    }

    public US_V_GD_HOP_DONG_NOI_DUNG_TT(decimal i_dbID)
    {
        pm_objDS = new DS_V_GD_HOP_DONG_NOI_DUNG_TT();
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
        public void load_noi_dung_at_phu_luc_hop_dong(decimal ip_dc_id_hop_dong_khung, DS_V_GD_HOP_DONG_NOI_DUNG_TT op_ds_v_gd_hd_noi_dung_tt)
        {
            CStoredProc v_cstore = new CStoredProc("pr_GD_HOP_DONG_NOI_DUNG_TT_Load_Phu_Luc_HD");
            v_cstore.addDecimalInputParam("@ID_HOP_DONG_KHUNG",ip_dc_id_hop_dong_khung);
            v_cstore.fillDataSetByCommand(this, op_ds_v_gd_hd_noi_dung_tt);
        }
        #endregion
    }
}
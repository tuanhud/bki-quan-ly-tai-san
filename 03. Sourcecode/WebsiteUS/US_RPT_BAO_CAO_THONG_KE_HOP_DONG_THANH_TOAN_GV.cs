///************************************************
/// Generated by: linhdh
/// Date: 06/03/2012 11:05:32
/// Goal: Create User Service Class for RPT_BAO_CAO_THONG_KE_HOP_DONG_THANH_TOAN_GV
///************************************************
/// <summary>
/// Create User Service Class for RPT_BAO_CAO_THONG_KE_HOP_DONG_THANH_TOAN_GV
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS{

public class US_RPT_BAO_CAO_THONG_KE_HOP_DONG_THANH_TOAN_GV : US_Object
{
	private const string c_TableName = "RPT_BAO_CAO_THONG_KE_HOP_DONG_THANH_TOAN_GV";
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

	public bool IsIDNull()	{
		return pm_objDR.IsNull("ID");
	}

	public void SetIDNull() {
		pm_objDR["ID"] = System.Convert.DBNull;
	}

	public decimal dcID_DON_VI_QUAN_LY 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_DON_VI_QUAN_LY", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_DON_VI_QUAN_LY"] = value;
		}
	}

	public bool IsID_DON_VI_QUAN_LYNull()	{
		return pm_objDR.IsNull("ID_DON_VI_QUAN_LY");
	}

	public void SetID_DON_VI_QUAN_LYNull() {
		pm_objDR["ID_DON_VI_QUAN_LY"] = System.Convert.DBNull;
	}

	public string strDON_VI_QUAN_LY 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "DON_VI_QUAN_LY", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["DON_VI_QUAN_LY"] = value;
		}
	}

	public bool IsDON_VI_QUAN_LYNull() 
	{
		return pm_objDR.IsNull("DON_VI_QUAN_LY");
	}

	public void SetDON_VI_QUAN_LYNull() {
		pm_objDR["DON_VI_QUAN_LY"] = System.Convert.DBNull;
	}

    public string strTRANG_THAI_THANH_TOAN_HOP_DONG
    {
        get
        {
            return CNull.RowNVLString(pm_objDR, "TRANG_THAI_THANH_TOAN_HOP_DONG", IPConstants.c_DefaultString);
        }
        set
        {
            pm_objDR["TRANG_THAI_THANH_TOAN_HOP_DONG"] = value;
        }
    }

    public bool IsTRANG_THAI_THANH_TOAN_HOP_DONGNull()
    {
        return pm_objDR.IsNull("TRANG_THAI_THANH_TOAN_HOP_DONG");
    }

    public void SetTRANG_THAI_THANH_TOAN_HOP_DONGNull()
    {
        pm_objDR["TRANG_THAI_THANH_TOAN_HOP_DONG"] = System.Convert.DBNull;
    }

	public decimal dcHD_CHUYEN_MON 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "HD_CHUYEN_MON", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["HD_CHUYEN_MON"] = value;
		}
	}

	public bool IsHD_CHUYEN_MONNull()	{
		return pm_objDR.IsNull("HD_CHUYEN_MON");
	}

	public void SetHD_CHUYEN_MONNull() {
		pm_objDR["HD_CHUYEN_MON"] = System.Convert.DBNull;
	}

	public decimal dcHD_HUONG_DAN 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "HD_HUONG_DAN", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["HD_HUONG_DAN"] = value;
		}
	}

	public bool IsHD_HUONG_DANNull()	{
		return pm_objDR.IsNull("HD_HUONG_DAN");
	}

	public void SetHD_HUONG_DANNull() {
		pm_objDR["HD_HUONG_DAN"] = System.Convert.DBNull;
	}

	public decimal dcHD_HOC_LIEU 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "HD_HOC_LIEU", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["HD_HOC_LIEU"] = value;
		}
	}

	public bool IsHD_HOC_LIEUNull()	{
		return pm_objDR.IsNull("HD_HOC_LIEU");
	}

	public void SetHD_HOC_LIEUNull() {
		pm_objDR["HD_HOC_LIEU"] = System.Convert.DBNull;
	}

#endregion
#region "Init Functions"
	public US_RPT_BAO_CAO_THONG_KE_HOP_DONG_THANH_TOAN_GV() 
	{
		pm_objDS = new DS_RPT_BAO_CAO_THONG_KE_HOP_DONG_THANH_TOAN_GV();
		pm_strTableName = c_TableName;
		pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
	}

	public US_RPT_BAO_CAO_THONG_KE_HOP_DONG_THANH_TOAN_GV(DataRow i_objDR): this()
	{
		this.DataRow2Me(i_objDR);
	}

	public US_RPT_BAO_CAO_THONG_KE_HOP_DONG_THANH_TOAN_GV(decimal i_dbID) 
	{
		pm_objDS = new DS_RPT_BAO_CAO_THONG_KE_HOP_DONG_THANH_TOAN_GV();
		pm_strTableName = c_TableName;
		IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
		v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
		SqlCommand v_cmdSQL;
		v_cmdSQL = v_objMkCmd.getSelectCmd();
		this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
		pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
	}
#endregion

    #region Additional functions
    public void bao_cao_thong_ke_thanh_toan_hd_giang_vien(DS_RPT_BAO_CAO_THONG_KE_HOP_DONG_THANH_TOAN_GV op_ds_rpt_thong_ke_thanh_toan_gv, string ip_str_edutop_elc, decimal ip_dc_thang, decimal ip_dc_nam)
    {
        CStoredProc v_cstore = new CStoredProc("rpt_pr_DM_HOP_DONG_KHUNG_So_Thanh_Toan_Theo_Trang_Thai");
        v_cstore.addNVarcharInputParam("@edutop_or_elc", ip_str_edutop_elc);
        v_cstore.addDecimalInputParam("@thang", ip_dc_thang);
        v_cstore.addDecimalInputParam("@nam", ip_dc_nam);
        v_cstore.fillDataSetByCommand(this, op_ds_rpt_thong_ke_thanh_toan_gv);
    }
    #endregion
}
}

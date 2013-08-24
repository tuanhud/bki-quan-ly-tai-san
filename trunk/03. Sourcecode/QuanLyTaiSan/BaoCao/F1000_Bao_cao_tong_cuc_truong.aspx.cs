using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPUserService;
using WebDS;
using WebUS;
using IP.Core.IPData;
using WebDS.CDBNames;
using IP.Core.WinFormControls;
using System.Threading;
using System.Data;

public partial class BaoCao_F1000_Bao_cao_tong_cuc_truong : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                load_form_data();
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    #region Members

    #endregion

    #region Data Structures
    
    #endregion

    #region Private Methods
    private void load_form_data()
    {
        load_data_don_vi_chu_quan();
        load_list_don_vi_su_dung();
    }
    // Load dữ liệu vào combo đơn vị chủ quản
    private void load_data_don_vi_chu_quan()
    {
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(CONST_QLDB.ID_TAT_CA.ToString(), WinFormControls.eTAT_CA.NO, m_ddl_don_vi_chu_quan);
    }

    private void load_list_don_vi_su_dung()
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        string v_id_don_vi_chu_quan = m_ddl_don_vi_chu_quan.SelectedValue;
        v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI =" + ID_LOAI_DON_VI.DV_SU_DUNG + "and ID_DON_VI_CAP_TREN =" + v_id_don_vi_chu_quan);

        DataRow v_dr = v_ds_dm_don_vi.DM_DON_VI.NewDM_DON_VIRow();
        v_dr[DM_DON_VI.ID] = CONST_QLDB.ID_TAT_CA;
        v_dr[DM_DON_VI.TEN_DON_VI] = CONST_QLDB.TAT_CA;
        v_ds_dm_don_vi.EnforceConstraints = false;
        v_ds_dm_don_vi.DM_DON_VI.Rows.InsertAt(v_dr, 0);

        m_lst_don_vi_su_dung.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_lst_don_vi_su_dung.DataTextField = DM_DON_VI.TEN_DON_VI;
        m_lst_don_vi_su_dung.DataValueField = DM_DON_VI.ID;
        m_lst_don_vi_su_dung.DataBind();
    }
    
    #endregion

    #region Even
    protected void m_ddl_don_vi_chu_quan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_list_don_vi_su_dung();            
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
}
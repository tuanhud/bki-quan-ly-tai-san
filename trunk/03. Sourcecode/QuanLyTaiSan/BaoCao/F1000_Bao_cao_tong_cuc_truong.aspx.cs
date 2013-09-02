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
        load_data_loai_bao_cao();
        load_data_loai_tai_san();
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
        string v_str_user_name = HttpContext.Current.Session[SESSION.UserName].ToString();
        v_us_dm_don_vi.FillDataset(
                v_ds_dm_don_vi
                , ID_LOAI_DON_VI.DV_SU_DUNG
                , CIPConvert.ToDecimal(m_ddl_don_vi_chu_quan.SelectedValue)
                , CONST_QLDB.ID_TAT_CA
                , v_str_user_name);
        v_ds_dm_don_vi.EnforceConstraints = false;

        DataRow v_dr = v_ds_dm_don_vi.DM_DON_VI.NewDM_DON_VIRow();
        v_dr[DM_DON_VI.ID] = CONST_QLDB.ID_TAT_CA;
        v_dr[DM_DON_VI.TEN_DON_VI] = CONST_QLDB.TAT_CA;
        v_ds_dm_don_vi.DM_DON_VI.Rows.InsertAt(v_dr, 0);


        m_lst_don_vi_su_dung.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_lst_don_vi_su_dung.DataTextField = DM_DON_VI.TEN_DON_VI;
        m_lst_don_vi_su_dung.DataValueField = DM_DON_VI.ID;
        m_lst_don_vi_su_dung.DataBind();
    }
    // Load dữ liệu vào list loại báo cáo
    private void load_data_loai_bao_cao()
    {
        US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_dm_tu_dien = new DS_CM_DM_TU_DIEN();

        v_us_dm_tu_dien.fill_tu_dien_cung_loai_ds(
                MA_LOAI_TU_DIEN.LOAI_BAO_CAO
                , CM_DM_TU_DIEN.GHI_CHU
                , v_ds_dm_tu_dien);

        m_lst_loai_bao_cao.DataSource = v_ds_dm_tu_dien.CM_DM_TU_DIEN;
        m_lst_loai_bao_cao.DataTextField = CM_DM_TU_DIEN.TEN;
        m_lst_loai_bao_cao.DataValueField = CM_DM_TU_DIEN.ID;
        m_lst_loai_bao_cao.DataBind();
    }
    // Load dữ liệu vào list loại tài sản
    private void load_data_loai_tai_san()
    {
        US_DM_LOAI_TAI_SAN v_us_dm_loai_ts = new US_DM_LOAI_TAI_SAN();
        DS_DM_LOAI_TAI_SAN v_ds_dm_loai_ts = new DS_DM_LOAI_TAI_SAN();

        v_us_dm_loai_ts.FillDataset(v_ds_dm_loai_ts, " ORDER BY ID_PHAN_LOAI, ID" );

        m_lst_loai_tai_san.DataSource = v_ds_dm_loai_ts.DM_LOAI_TAI_SAN;
        m_lst_loai_tai_san.DataTextField = DM_LOAI_TAI_SAN.TEN_LOAI_TAI_SAN ;
        m_lst_loai_tai_san.DataValueField = DM_LOAI_TAI_SAN.ID;
        m_lst_loai_tai_san.DataBind();
    }
    private bool da_chon_du_lieu_tim_kiem()
    {
        if (m_lst_don_vi_su_dung.SelectedIndex < 0) return false;
        if (m_lst_loai_tai_san.SelectedIndex < 0) return false;
        if (m_lst_loai_bao_cao.SelectedIndex < 0) return false;
        return true;
    }
    private void den_ba0_cao_duoc_chon()
    {
        m_lbl_mess.Text = "";
        US_DM_LOC_BAO_CAO v_us_dm_loc_bao_cao = new US_DM_LOC_BAO_CAO();
        DS_DM_LOC_BAO_CAO v_ds_dm_loc_bao_cao = new DS_DM_LOC_BAO_CAO();
        if (!da_chon_du_lieu_tim_kiem())
        {
            m_lbl_mess.Text = "Chưa chọn đủ các trường lọc!";
            return;
        }
         v_us_dm_loc_bao_cao.FillDatasetByLoaiTS_LoaiBC(
                 CIPConvert.ToDecimal(m_lst_loai_tai_san.SelectedValue)
                 , CIPConvert.ToDecimal(m_lst_loai_bao_cao.SelectedValue)
                 , v_ds_dm_loc_bao_cao);
        if (v_ds_dm_loc_bao_cao.DM_LOC_BAO_CAO != null && v_ds_dm_loc_bao_cao.DM_LOC_BAO_CAO.Rows.Count > 0) {
            v_us_dm_loc_bao_cao.DataRow2Me(v_ds_dm_loc_bao_cao.DM_LOC_BAO_CAO.Rows[0]);
            string v_str_url = v_us_dm_loc_bao_cao.strDUONG_DAN
                + (v_us_dm_loc_bao_cao.strDUONG_DAN.IndexOf("aspx?") == -1 ? "?" : "&") 
                + CONST_QLDB.MA_THAM_SO_URL.ID_DVSD + "="
                + m_lst_don_vi_su_dung.SelectedValue;                        
            Response.Redirect(v_str_url, false);
        }
        else {
            m_lbl_mess.Text = "Hiện nay chưa có báo cáo nào theo bộ lọc của quý khách!";
        }
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
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {            
            den_ba0_cao_duoc_chon();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    #endregion

}
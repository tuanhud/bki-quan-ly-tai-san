using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using IP.Core.IPData;
using WebDS;
using WebUS;
using WebDS.CDBNames;
using QltsForm;
using IP.Core.WinFormControls;


public partial class BaoCao_F310_BCTC_Thay_doi_thong_tin_Dat : System.Web.UI.Page
{
    #region Members
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    US_CM_DM_TU_DIEN m_us_dm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    #endregion

    #region private methods
    //private void export_excel()
    //{
    //    try
    //    {
    //        US_DM_DON_VI v_us_dm_don_vi;
    //        US_DM_DAT v_us_dm_dat;
    //        decimal v_dc_id_dat = CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue);
    //        v_us_dm_dat = new US_DM_DAT(v_dc_id_dat);
    //        decimal v_dc_id_dv_su_dung = v_us_dm_dat.dcID_DON_VI_SU_DUNG;
    //        v_us_dm_don_vi = new US_DM_DON_VI(v_us_dm_dat.dcID_DON_VI_CHU_QUAN);
    //        string v_str_don_vi_chu_quan = v_us_dm_don_vi.strTEN_DON_VI;
    //        v_us_dm_don_vi = new US_DM_DON_VI(v_us_dm_don_vi.dcID_DON_VI_CAP_TREN);
    //        string v_str_bo_tinh = v_us_dm_don_vi.strTEN_DON_VI;
    //        string v_str_output_file = "";
    //        if (Request.QueryString["id_loai_bao_cao"] != null)
    //        {
    //            string v_id = Request.QueryString["id_loai_bao_cao"];
    //            f402_bao_cao_danh_muc_tru_so_lam_viec v_f402_bc_dm_nha = new f402_bao_cao_danh_muc_tru_so_lam_viec();
    //            switch (v_id)
    //            {
    //                case "1":
    //                    v_f402_bc_dm_nha.export_excel(f402_bao_cao_danh_muc_tru_so_lam_viec.eFormMode.DANH_MUC_TRU_SO_LAM_VIEC
    //                                            , v_str_bo_tinh
    //                                            , v_str_don_vi_chu_quan
    //                                            , v_dc_id_dv_su_dung
    //                                            , v_dc_id_dat
    //                                            , ref v_str_output_file);
    //                    break;
    //                case "2":
    //                    v_f402_bc_dm_nha.export_excel(f402_bao_cao_danh_muc_tru_so_lam_viec.eFormMode.DE_NGHI_XU_LY
    //                                            , v_str_bo_tinh
    //                                            , v_str_don_vi_chu_quan
    //                                            , v_dc_id_dv_su_dung
    //                                            , v_dc_id_dat
    //                                            , ref v_str_output_file);
    //                    break;
    //                case "3":
    //                    break;
    //            }
    //        }
    //        Response.Clear();
    //        v_str_output_file = "/QuanLyTaiSan/" + v_str_output_file;
    //        Response.Redirect(v_str_output_file, false);
    //    }
    //    catch (System.Exception v_e)
    //    {
    //        CSystemLog_301.ExceptionHandle(this, v_e);
    //    }
    //}
    private void load_data_to_cbo_trang_thai()
    {
        try
        {
            DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
            //string cmd = "select distinct ma_tu_dien from cm_dm_tu_dien where id_loai_tu_dien=6 or id_loai_tu_dien=7 or id_loai_tu_dien=8";
            //System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(cmd);  
            //"select * from DM_TAI_SAN_KHAC Where TEN_TAI_SAN like '%"+m_txt_tim_kiem.Text+
            //"%' or KY_HIEU like '%"+m_txt_tim_kiem.Text+
            //"%' or NUOC_SAN_XUAT like '%"+m_txt_tim_kiem.Text+
            //"%' or NAM_SAN_XUAT like '%"+m_txt_tim_kiem.Text+
            //"%' or NAM_SU_DUNG like '%"+m_txt_tim_kiem.Text+
            //"%'";
            v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_DAT, CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);
            m_cbo_trang_thai.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_trang_thai.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN;
            // m_cbo_trang_thai.SelectedValue = CIPConvert.ToStr(ID_TRANG_THAI_TAI_SAN_KHAC.DANG_SU_DUNG);
            m_cbo_trang_thai.DataBind();
            m_cbo_trang_thai.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    private void load_data_to_cbo_dia_chi(string ip_str_id_don_vi_su_dung, string ip_str_id_don_vi_chu_quan, string ip_str_bo_tinh)
    {
        try
        {
            DS_DM_DAT v_ds_dm_dat = new DS_DM_DAT();
            US_DM_DAT v_us_dm_dat = new US_DM_DAT();
            string v_str_user_name = Session[SESSION.UserName].ToString();
            v_us_dm_dat.FillDatasetByID_DonVi(
                CIPConvert.ToDecimal(ip_str_bo_tinh)
                , CIPConvert.ToDecimal(ip_str_id_don_vi_chu_quan)
                , CIPConvert.ToDecimal(ip_str_id_don_vi_su_dung)
                , v_str_user_name
                , v_ds_dm_dat);
            m_cbo_dia_chi.DataSource = v_ds_dm_dat.DM_DAT;
            m_cbo_dia_chi.DataTextField = DM_DAT.DIA_CHI;
            m_cbo_dia_chi.DataValueField = DM_DAT.ID;
            m_cbo_dia_chi.DataBind();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    private bool check_validate_data_is_ok()
    {
        try
        {
            if (m_cbo_dia_chi.SelectedValue == null)
            {
                m_lbl_mess.Text = "Bạn phải chọn Địa Chỉ Đất!";
                return false;
            }
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
        return true;
    }
    private void load_data_to_grid_dat_history()
    {
        try
        {
            string v_id_don_vi_chu_quan = m_cbo_don_vi_chu_quan.SelectedValue;
            string v_id_don_vi_su_dung = m_cbo_don_vi_su_dung_tai_san.SelectedValue;
            string v_id_trang_thai = m_cbo_trang_thai.SelectedValue;
            DS_V_DM_DAT_HISTORY v_ds_v_dm_dat_history = new DS_V_DM_DAT_HISTORY();
            US_V_DM_DAT_HISTORY v_us_v_dm_dat_history = new US_V_DM_DAT_HISTORY();
            if (v_id_don_vi_su_dung.Equals(CONST_QLDB.ID_TAT_CA.ToString()))
            {
                v_us_v_dm_dat_history.FillDataset(v_ds_v_dm_dat_history, "where id_trang_thai = " + v_id_trang_thai);
            }
            else if (!v_id_don_vi_su_dung.Equals(CONST_QLDB.ID_TAT_CA.ToString()))
            {
                if (v_id_don_vi_chu_quan.Equals(CONST_QLDB.ID_TAT_CA.ToString()))
                {
                    v_us_v_dm_dat_history.FillDataset(v_ds_v_dm_dat_history, "where id_trang_thai = " + v_id_trang_thai + " and id_don_vi_su_dung = " + v_id_don_vi_su_dung);
                }
                else
                {
                    v_us_v_dm_dat_history.FillDataset(v_ds_v_dm_dat_history, "where id_don_vi_chu_quan = " + v_id_don_vi_chu_quan + " and id_don_vi_su_dung = " + v_id_don_vi_su_dung + " and id_trang_thai = " + v_id_trang_thai);
                }

            }
            //// v_us_dm_tai_san_khac.FillDataset(v_ds_dm_tai_san_khac, "where id_don_vi_su_dung=" + v_id_don_vi_su_dung + " and id_don_vi_chu_quan=" + v_id_don_vi_chu_quan + " and id_trang_thai=" + v_id_trang_thai);
            ////string cmd = "select dm_tai_san_khac.* from cm_dm_tu_dien join dm_tai_san_khac on cm_dm_tu_dien.id=dm_tai_san_khac.id_trang_thai where ( dm_tai_san_khac.nguon_ns+dm_tai_san_khac.nguon_khac >=500000000) and dm_tai_san_khac.id_trang_thai in (select id from cm_dm_TU_DIEN where ma_tu_dien='" + m_cbo_trang_thai.SelectedValue + "')";
            //System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(cmd);
            //v_us_dm_tai_san_khac.FillDatasetByCommand(v_ds_dm_tai_san_khac, command);
            if (v_ds_v_dm_dat_history.V_DM_DAT_HISTORY.Count != 0)
            {
                m_grv_dat_history.DataSource = v_ds_v_dm_dat_history.V_DM_DAT_HISTORY;
                m_grv_dat_history.DataBind();
            }
            else
            {
                m_grv_dat_history.Visible = false;
                m_lbl_thong_bao.Text = "Không có dữ liệu phù hợp";
            }
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion

    #region events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                WinFormControls.load_data_to_cbo_bo_tinh(
                    WinFormControls.eTAT_CA.YES
                    , m_cbo_bo_tinh);
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan);
                WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan.SelectedValue
                    , m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung_tai_san);
                load_data_to_cbo_dia_chi(m_cbo_don_vi_su_dung_tai_san.SelectedValue, m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
                load_data_to_cbo_trang_thai();
            }
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dat_history_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_dat_history.PageIndex = e.NewPageIndex;
            load_data_to_grid_dat_history();
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES, m_cbo_don_vi_chu_quan);
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_tai_san);
            load_data_to_cbo_dia_chi(m_cbo_don_vi_su_dung_tai_san.SelectedValue, m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_chu_quan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_tai_san);
            load_data_to_cbo_dia_chi(
                m_cbo_don_vi_su_dung_tai_san.SelectedValue
                , m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_bo_tinh.SelectedValue);
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_su_dung_tai_san_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            load_data_to_cbo_dia_chi(m_cbo_don_vi_su_dung_tai_san.SelectedValue, m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_loc_du_lieu_Click(object sender, EventArgs e)
    {
        try
        {
            if (check_validate_data_is_ok() == false)
            {
                return;
            }
            else
            {
                load_data_to_grid_dat_history();
            }
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        try
        {
            //export_excel();
        }

        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion

}
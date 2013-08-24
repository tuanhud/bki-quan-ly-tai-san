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

    private bool check_validate_data_is_ok()
    {

        if (m_cbo_dia_chi.SelectedValue == null)
        {
            m_lbl_mess.Text = "Bạn phải chọn Địa Chỉ Đất!";
            return false;
        }
        DateTime m_dat_tu_ngay = new DateTime();
        DateTime m_dat_den_ngay = new DateTime();
        if (m_txt_tu_ngay.Text.Equals(""))
        {
            m_txt_tu_ngay.Text = "01/01/1900";
        }
        else
        {
            try
            {
                m_dat_tu_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text);
            }
            catch (System.Exception ex)
            {
                m_lbl_mess.Text = "Bạn nhập sai Từ Ngày!";
                return false;
            }
        }

        if (m_txt_den_ngay.Text.Equals(""))
        {
            m_txt_den_ngay.Text = "01/01/3000";
        }
        else
        {
            try
            {
                m_dat_den_ngay = CIPConvert.ToDatetime(m_txt_den_ngay.Text);
            }
            catch (System.Exception ex)
            {
                m_lbl_mess.Text = "Bạn nhập sai Đến Ngày!";
                return false;
            }
        }

        if (m_dat_den_ngay.CompareTo(m_dat_tu_ngay) < 0)
        {
            m_lbl_mess.Text = "Phải nhập Từ Ngày nhỏ hơn Đến Ngày!";
            return false;
        }
        return true;
    }
    #endregion

    #region events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //load data to combobox trang thai
                WinFormControls.load_data_to_cbo_tu_dien(
                    WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_DAT
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_trang_thai
                    );
                //load data to combobox loai hinh don vi
                WinFormControls.load_data_to_cbo_loai_hinh_don_vi(
                   WinFormControls.eLOAI_TU_DIEN.LOAI_HINH_DON_VI
                   , WinFormControls.eTAT_CA.YES
                   , m_cbo_loai_hinh_don_vi
                   );
                WinFormControls.load_data_to_cbo_bo_tinh(
                    WinFormControls.eTAT_CA.YES
                    , m_cbo_bo_tinh);
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan);

                WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                    m_cbo_loai_hinh_don_vi.SelectedValue
                    , m_cbo_don_vi_chu_quan.SelectedValue
                    , m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung_tai_san
                    );
                WinFormControls.load_data_to_cbo_dia_chi(
                     CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                   , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                   , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                   , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                   , WinFormControls.eTAT_CA.YES
                   , m_cbo_dia_chi);

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
            DS_V_DM_DAT_HISTORY v_ds_v_dm_dat_history = new DS_V_DM_DAT_HISTORY();

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
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan);
            WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                m_cbo_loai_hinh_don_vi.SelectedValue
                , m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_tai_san
                );
            WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                , m_cbo_loai_hinh_don_vi.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_dia_chi
                );
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
            WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                 m_cbo_loai_hinh_don_vi.SelectedValue
                 , m_cbo_don_vi_chu_quan.SelectedValue
                 , m_cbo_bo_tinh.SelectedValue
                 , WinFormControls.eTAT_CA.YES
                 , m_cbo_don_vi_su_dung_tai_san
                 );

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
            WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                , m_cbo_loai_hinh_don_vi.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_dia_chi
                );
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
            if (!check_validate_data_is_ok()) return;
            string v_str_user_name = Person.get_user_name();
            if (v_str_user_name.Equals(null)) return;
            US_V_DM_DAT_HISTORY v_us_v_dm_dat_history = new US_V_DM_DAT_HISTORY();
            DS_V_DM_DAT_HISTORY v_ds_v_dm_dat_history = new DS_V_DM_DAT_HISTORY();
            v_us_v_dm_dat_history.FillDatasetLoaiHinh(
                CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                , m_cbo_loai_hinh_don_vi.SelectedValue
                , v_str_user_name
                , CIPConvert.ToDatetime(m_txt_tu_ngay.Text)
                , CIPConvert.ToDatetime(m_txt_den_ngay.Text)
                , m_txt_tim_kiem.Text
                , v_ds_v_dm_dat_history
                );
            m_grv_dat_history.DataSource = v_ds_v_dm_dat_history.V_DM_DAT_HISTORY;
            m_grv_dat_history.DataBind();
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

    protected void m_cbo_trang_thai_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                , m_cbo_loai_hinh_don_vi.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_dia_chi
                );
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    protected void m_cbo_loai_hinh_don_vi_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                m_cbo_loai_hinh_don_vi.SelectedValue
                , m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_tai_san
                );
            WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                , m_cbo_loai_hinh_don_vi.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_dia_chi
                );
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }


}
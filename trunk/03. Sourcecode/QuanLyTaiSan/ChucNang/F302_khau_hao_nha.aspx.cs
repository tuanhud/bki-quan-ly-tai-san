using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using IP.Core.IPBusinessService;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPException;
using IP.Core.IPUserService;
using WebDS.CDBNames;
using IP.Core.WinFormControls;

public partial class ChucNang_F302_khau_hao_nha : System.Web.UI.Page
{
    #region Members
    private US_GD_KHAU_HAO v_us_gd_khau_hao = new US_GD_KHAU_HAO();
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                WinFormControls.load_data_to_cbo_bo_tinh(
                     WinFormControls.eTAT_CA.YES
                     , m_cbo_bo_tinh_up);
                WinFormControls.load_data_to_cbo_bo_tinh(
                     WinFormControls.eTAT_CA.YES
                     , m_cbo_bo_tinh_down);
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh_up.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan_up);
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh_down.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan_down);
                WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan_up.SelectedValue
                    , m_cbo_bo_tinh_up.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung_up);
                WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan_down.SelectedValue
                    , m_cbo_bo_tinh_down.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung_down);
                load_data_to_cbo_dia_chi_down(m_cbo_don_vi_su_dung_down.SelectedValue, m_cbo_don_vi_chu_quan_down.SelectedValue, m_cbo_don_vi_chu_quan_down.SelectedValue);
                load_data_to_cbo_dia_chi_up(m_cbo_don_vi_su_dung_up.SelectedValue, m_cbo_don_vi_chu_quan_up.SelectedValue, m_cbo_bo_tinh_up.SelectedValue);
                load_data_trang_thai();
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
        
    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {

    }

    protected void m_hdf_id_ValueChanged(object sender, EventArgs e)
    {
        try
        {
            if (!m_hdf_id.Value.Equals(String.Empty))
            {
                decimal v_dc_id = CIPConvert.ToDecimal(m_hdf_id.Value);
                load_data_from_us(v_dc_id);
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_grv_danh_sach_nha_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        m_grv_danh_sach_nha.PageIndex = e.NewPageIndex;
    }

    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            if (!m_hdf_id.Value.Equals(String.Empty))
            {
                decimal v_dc_id = CIPConvert.ToDecimal(m_hdf_id.Value);
                US_GD_KHAU_HAO v_us_gd_khau_hao = new US_GD_KHAU_HAO();
                US_DM_NHA v_us_dm_nha = new US_DM_NHA(v_dc_id);

                decimal v_dc_gia_tri_khau_hao = CIPConvert.ToDecimal(m_txt_gia_tri_khau_hao.Text);
                decimal v_dc_user_id = CIPConvert.ToDecimal(HttpContext.Current.Session[SESSION.UserID].ToString());

                // Lấy thông tin mới cho giao dịch khấu hao
                v_us_gd_khau_hao.dcID_TAI_SAN = v_dc_id;
                v_us_gd_khau_hao.dcID_LOAI_TAI_SAN = ID_LOAI_TAI_SAN.NHA;
                v_us_gd_khau_hao.dcID_DON_VI = v_us_dm_nha.dcID_DON_VI_SU_DUNG;
                v_us_gd_khau_hao.dcGIA_TRI_KHAU_HAO = v_dc_gia_tri_khau_hao;
                v_us_gd_khau_hao.strMA_PHIEU = m_txt_ma_phieu.Text;
                v_us_gd_khau_hao.datNGAY_DUYET = CIPConvert.ToDatetime(m_txt_ngay_duyet.Text);
                v_us_gd_khau_hao.datNGAY_LAP = CIPConvert.ToDatetime(m_txt_ngay_lap.Text);
                v_us_gd_khau_hao.dcID_NGUOI_LAP = v_dc_user_id;
                v_us_gd_khau_hao.dcID_NGUOI_DUYET = v_dc_user_id;

                // Cập nhật cho nhà
                v_us_dm_nha.dcGIA_TRI_CON_LAI = v_us_dm_nha.dcGIA_TRI_CON_LAI - v_dc_gia_tri_khau_hao;

                // Thực hiện cập nhật
                v_us_gd_khau_hao.Insert();
                v_us_dm_nha.Update();
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
        
    }

    protected void m_cmd_xoa_trang_Click(object sender, EventArgs e)
    {
        try
        {
            m_txt_nha.Text = "";
            m_lbl_ten_tai_san.Text = "";
            m_lbl_ma_tai_san.Text = "";
            m_lbl_cap_hang.Text = "";
            m_lbl_nam_xay_dung.Text = "";
            m_lbl_ngay_thang_nam_du_dung.Text = "";
            m_lbl_nguyen_gia_nguon_ns.Text = "";
            m_lbl_nguyen_gia_nguon_khac.Text = "";
            m_lbl_gia_tri_con_lai.Text = "";
            m_txt_ma_phieu.Text = "";
            m_txt_ngay_lap.Text = "";
            m_txt_gia_tri_khau_hao.Text = "";
            m_txt_ngay_duyet.Text = "";
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {

    }

    protected void m_cbo_bo_tinh_up_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                m_cbo_bo_tinh_up.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_chu_quan_up);
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan_up.SelectedValue
                , m_cbo_bo_tinh_up.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_up);
            load_data_to_cbo_dia_chi_up(m_cbo_don_vi_su_dung_up.SelectedValue, m_cbo_don_vi_chu_quan_up.SelectedValue, m_cbo_bo_tinh_up.SelectedValue);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_chu_quan_up_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan_up.SelectedValue
                , m_cbo_bo_tinh_up.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_up);
            load_data_to_cbo_dia_chi_up(m_cbo_don_vi_su_dung_up.SelectedValue, m_cbo_don_vi_chu_quan_up.SelectedValue, m_cbo_bo_tinh_up.SelectedValue);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_su_dung_up_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_to_cbo_dia_chi_up(m_cbo_don_vi_su_dung_up.SelectedValue, m_cbo_don_vi_chu_quan_up.SelectedValue, m_cbo_bo_tinh_up.SelectedValue);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_cbo_bo_tinh_down_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                m_cbo_bo_tinh_down.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_chu_quan_down);
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan_down.SelectedValue
                , m_cbo_bo_tinh_down.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_down);
            load_data_to_cbo_dia_chi_down(m_cbo_don_vi_su_dung_down.SelectedValue, m_cbo_don_vi_chu_quan_down.SelectedValue, m_cbo_bo_tinh_down.SelectedValue);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_cbo_don_vi_chu_quan_down_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan_down.SelectedValue
                , m_cbo_bo_tinh_down.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_down);
            load_data_to_cbo_dia_chi_down(m_cbo_don_vi_su_dung_down.SelectedValue, m_cbo_don_vi_chu_quan_down.SelectedValue, m_cbo_bo_tinh_down.SelectedValue);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_su_dung_down_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_to_cbo_dia_chi_down(m_cbo_don_vi_su_dung_down.SelectedValue, m_cbo_don_vi_chu_quan_down.SelectedValue, m_cbo_bo_tinh_down.SelectedValue);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_txt_nha_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (!m_hdf_id.Value.Equals(String.Empty))
            {
                decimal v_dc_id = CIPConvert.ToDecimal(m_hdf_id.Value);
                load_data_from_us(v_dc_id);
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_grv_danh_sach_nha_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    #endregion

    #region Public Interfaces

    #endregion

    #region Private Methods

    private void load_data_from_us(decimal ip_dc_id_nha)
    {
        US_DM_NHA v_us_dm_nha = new US_DM_NHA(ip_dc_id_nha);
        m_lbl_ten_tai_san.Text = v_us_dm_nha.strTEN_TAI_SAN;
        m_lbl_ma_tai_san.Text = v_us_dm_nha.strMA_TAI_SAN;
        m_lbl_cap_hang.Text = v_us_dm_nha.dcCAP_HANG.ToString();
        m_lbl_nam_xay_dung.Text = v_us_dm_nha.dcNAM_XAY_DUNG.ToString();
        m_lbl_ngay_thang_nam_du_dung.Text = v_us_dm_nha.dcNGAY_THANG_NAM_SU_DUNG.ToString();
        m_lbl_nguyen_gia_nguon_ns.Text = v_us_dm_nha.dcNGUON_NS.ToString("#,##0.00");
        m_lbl_nguyen_gia_nguon_khac.Text = v_us_dm_nha.dcNGUON_KHAC.ToString("#,##0.00");
        m_lbl_gia_tri_con_lai.Text = v_us_dm_nha.dcGIA_TRI_CON_LAI.ToString("#,##0.00");
    }

    private void load_data_trang_thai()
    {
        DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();

        v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_NHA, CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);
        m_cbo_trang_thai_nha_up.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
        m_cbo_trang_thai_nha_up.DataTextField = "TEN";
        m_cbo_trang_thai_nha_up.DataValueField = "ID";
        m_cbo_trang_thai_nha_up.DataBind();
        m_cbo_trang_thai_nha_up.SelectedValue = ID_TRANG_THAI_NHA.DANG_SU_DUNG.ToString();
    }

    private void load_data_to_cbo_dia_chi_down(string ip_str_id_don_vi_su_dung, string ip_str_id_don_vi_chu_quan, string ip_str_bo_tinh)
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

    private void load_data_to_cbo_dia_chi_up(string ip_str_id_don_vi_su_dung, string ip_str_id_don_vi_chu_quan, string ip_str_bo_tinh)
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
        m_cbo_thuoc_khu_dat.DataSource = v_ds_dm_dat.DM_DAT;
        m_cbo_thuoc_khu_dat.DataTextField = DM_DAT.DIA_CHI;
        m_cbo_thuoc_khu_dat.DataValueField = DM_DAT.ID;
        m_cbo_thuoc_khu_dat.DataBind();
    }

    private void load_data_to_grid()
    {

    }
    #endregion
    
}
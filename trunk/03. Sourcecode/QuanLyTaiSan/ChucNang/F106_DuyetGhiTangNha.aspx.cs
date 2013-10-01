using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using WebDS.CDBNames;
using IP.Core.IPBusinessService;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPException;
using IP.Core.IPUserService;
using IP.Core.WinFormControls;
using IP.Core.QltsFormControls;

public partial class ChucNang_F106_DuyetGhiTangNha : System.Web.UI.Page
{
    #region Members
    private US_GD_TANG_GIAM_TAI_SAN m_us_gd_tang_giam_tai_san = new US_GD_TANG_GIAM_TAI_SAN();
    #endregion

    #region Private Methods
    private void load_data_2_form()
    {
        clear_form_data();
        load_data_to_bo_tinh_up();
        load_data_to_bo_tinh_down();
        load_data_to_dv_chu_quan_up();
        load_data_to_dv_chu_quan_down();
        load_data_to_dv_su_dung_up();
        load_data_to_dv_su_dung_down();
        load_data_to_khu_dat_up();
        load_data_to_khu_dat_down();
        load_data_trang_thai();
        load_data_to_ten_tai_san();
        load_data_from_us();
        load_data_to_ly_do();
        select_loai_tang_giam();
        load_data_to_grid();
    }

    private void load_data_from_us()
    {
        if (m_cbo_ten_tai_san.Items.Count == 0) return;
        decimal v_dc_id_nha = CIPConvert.ToDecimal(m_cbo_ten_tai_san.SelectedValue);
        if (v_dc_id_nha < 1) return;  
        US_DM_NHA v_us_dm_nha = new US_DM_NHA(CIPConvert.ToDecimal(v_dc_id_nha));
        m_lbl_ten_tai_san.Text = v_us_dm_nha.strTEN_TAI_SAN;
        m_lbl_ma_tai_san.Text = v_us_dm_nha.strMA_TAI_SAN;
        m_lbl_cap_hang.Text = v_us_dm_nha.dcCAP_HANG.ToString();
        m_lbl_nam_xay_dung.Text = v_us_dm_nha.dcNAM_XAY_DUNG.ToString();
        m_lbl_ngay_thang_nam_du_dung.Text = v_us_dm_nha.dcNGAY_THANG_NAM_SU_DUNG.ToString();
        m_lbl_nguyen_gia_nguon_ns.Text = v_us_dm_nha.dcNGUON_NS.ToString("#,##0.00");
        m_lbl_nguyen_gia_nguon_khac.Text = v_us_dm_nha.dcNGUON_KHAC.ToString("#,##0.00");
        m_lbl_gia_tri_con_lai.Text = v_us_dm_nha.dcGIA_TRI_CON_LAI.ToString("#,##0.00");
    }

    private void load_data_to_ly_do()
    {
        WinFormControls.load_data_to_cbo_tu_dien(
            WinFormControls.eLOAI_TU_DIEN.LY_DO_TANG_GIAM_TS
            , WinFormControls.eTAT_CA.NO
            , m_cbo_ly_do_thay_doi);
    }

    private void load_data_trang_thai()
    {
        DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();

        v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_NHA, CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);
        m_cbo_trang_thai_nha_up.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
        m_cbo_trang_thai_nha_up.DataTextField = CM_DM_TU_DIEN.TEN;
        m_cbo_trang_thai_nha_up.DataValueField = CM_DM_TU_DIEN.ID;
        m_cbo_trang_thai_nha_up.DataBind();
        m_cbo_trang_thai_nha_up.SelectedValue = ID_TRANG_THAI_NHA.DANG_SU_DUNG.ToString();
    }
    
    private void load_data_to_bo_tinh_up()
    {
        WinFormControls.load_data_to_cbo_bo_tinh(
                     WinFormControls.eTAT_CA.NO
                     , m_cbo_bo_tinh_up);
    }

    private void load_data_to_bo_tinh_down()
    {
        WinFormControls.load_data_to_cbo_bo_tinh(
                     WinFormControls.eTAT_CA.YES
                     , m_cbo_bo_tinh_down);
    }

    private void load_data_to_dv_chu_quan_up()
    {
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh_up.SelectedValue
                    , WinFormControls.eTAT_CA.NO
                    , m_cbo_don_vi_chu_quan_up);
    }

    private void load_data_to_dv_chu_quan_down()
    {
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh_down.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan_down);
    }

    private void load_data_to_dv_su_dung_up()
    {
        WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan_up.SelectedValue
                    , m_cbo_bo_tinh_up.SelectedValue
                    , WinFormControls.eTAT_CA.NO
                    , m_cbo_don_vi_su_dung_tai_san_up);
    }

    private void load_data_to_dv_su_dung_down()
    {
        WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan_down.SelectedValue
                    , m_cbo_bo_tinh_down.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung_down);
    }

    private void load_data_to_khu_dat_up()
    {
        WinFormControls.load_data_to_cbo_dia_chi(
               CIPConvert.ToDecimal(m_cbo_bo_tinh_up.SelectedValue)
             , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan_up.SelectedValue)
             , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san_up.SelectedValue)
             , ID_TRANG_THAI_DAT.DANG_SU_DUNG
             , WinFormControls.eTAT_CA.NO
             , m_cbo_thuoc_khu_dat);
    }

    private void load_data_to_khu_dat_down()
    {
        WinFormControls.load_data_to_cbo_dia_chi(
                   CIPConvert.ToDecimal(m_cbo_bo_tinh_down.SelectedValue)
                 , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan_down.SelectedValue)
                 , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_down.SelectedValue)
                 , ID_TRANG_THAI_DAT.DANG_SU_DUNG
                 , WinFormControls.eTAT_CA.NO
                 , m_cbo_dia_chi);
    }

    private void load_data_to_ten_tai_san()
    {
        US_V_DM_NHA v_us_v_dm_nha = new US_V_DM_NHA();
        DS_V_DM_NHA v_ds_v_dm_nha = new DS_V_DM_NHA();

        v_us_v_dm_nha.FillDatasetLoadDataToGridNha(
            CIPConvert.ToDecimal(m_cbo_bo_tinh_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_thuoc_khu_dat.SelectedValue)
            , Person.get_user_name()
            , CIPConvert.ToDecimal(m_cbo_trang_thai_nha_up.SelectedValue)
            , v_ds_v_dm_nha);

        m_cbo_ten_tai_san.DataSource = v_ds_v_dm_nha.V_DM_NHA;
        m_cbo_ten_tai_san.DataTextField = V_DM_NHA.TEN_TAI_SAN;
        m_cbo_ten_tai_san.DataValueField = V_DM_NHA.ID;
        m_cbo_ten_tai_san.DataBind();
    }

    private void load_data_to_grid()
    {
        m_lbl_thong_tin_nha.Text = "Danh sách duyệt ghi tăng giảm tài sản";

        US_V_GD_TANG_GIAM_TAI_SAN_NHA v_us_v_gd_tg_tsn = new US_V_GD_TANG_GIAM_TAI_SAN_NHA();
        DS_V_GD_TANG_GIAM_TAI_SAN_NHA v_ds_v_gd_tg_tsn = new DS_V_GD_TANG_GIAM_TAI_SAN_NHA();
        v_us_v_gd_tg_tsn.FillDatasetLoadDataToGridNha_by_tu_khoa(
            m_txt_tu_khoa.Text.Trim()
            , CIPConvert.ToDecimal(m_cbo_bo_tinh_down.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_down.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_down.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue)
            , CONST_QLDB.ID_TAT_CA
            , CONST_QLDB.MA_TAT_CA
            , Person.get_user_name()
            , v_ds_v_gd_tg_tsn);

        string v_str_thong_tin = " (Có " + v_ds_v_gd_tg_tsn.V_GD_TANG_GIAM_TAI_SAN_NHA.Rows.Count + " bản ghi)";
        m_lbl_thong_tin_nha.Text += v_str_thong_tin;
        m_grv_danh_sach_nha.DataSource = v_ds_v_gd_tg_tsn.V_GD_TANG_GIAM_TAI_SAN_NHA;
        m_grv_danh_sach_nha.DataBind();
    }

    private void clear_form_data()
    {
        m_txt_ma_phieu.Text = "";
        m_txt_ngay_duyet.Text = "";
        m_txt_ngay_tang_giam.Text = "";
    }

    private bool check_validate_data_is_ok()
    {
        if (m_cbo_ten_tai_san.Items.Count == 0)
        {
            m_lbl_message.Text = "Bạn chưa lựa chọn tài sản";
            return false;
        }

        if (!m_us_gd_tang_giam_tai_san.check_valid_ma_phieu(m_txt_ma_phieu.Text))
        {
            m_lbl_message.Text = "Lỗi: Mã phiểu này đã tồn tại";
            return false;
        }

        if (!CValidateTextBox.IsValid(m_txt_ngay_duyet, DataType.DateType, allowNull.NO))
        {
            m_lbl_message.Text = "Lỗi: Ngày duyệt không đúng định dạng";
            return false;
        }

        if (!CValidateTextBox.IsValid(m_txt_ngay_tang_giam, DataType.DateType, allowNull.NO))
        {
            m_lbl_message.Text = "Lỗi: Ngày tính tăng giảm không đúng định dạng";
            return false;
        }
        return true;
    }

    private void them_moi_tang_giam()
    {
        US_DM_NHA v_us_dm_nha = new US_DM_NHA(CIPConvert.ToDecimal(m_cbo_ten_tai_san.SelectedValue));
        m_us_gd_tang_giam_tai_san = new US_GD_TANG_GIAM_TAI_SAN();
        m_us_gd_tang_giam_tai_san.datNGAY_DUYET = CIPConvert.ToDatetime(m_txt_ngay_duyet.Text);
        m_us_gd_tang_giam_tai_san.datNGAY_TANG_GIAM_TAI_SAN = CIPConvert.ToDatetime(m_txt_ngay_tang_giam.Text);
        m_us_gd_tang_giam_tai_san.dcID_LY_DO_TANG_GIAM = CIPConvert.ToDecimal(m_cbo_ly_do_thay_doi.SelectedValue);
        m_us_gd_tang_giam_tai_san.strTANG_GIA_TRI_TAI_SAN_YN = m_rbl_loai.SelectedValue;

        m_us_gd_tang_giam_tai_san.dcID_TAI_SAN = v_us_dm_nha.dcID;
        m_us_gd_tang_giam_tai_san.dcID_LOAI_TAI_SAN = v_us_dm_nha.dcID_LOAI_TAI_SAN;
        m_us_gd_tang_giam_tai_san.strMA_PHIEU = m_txt_ma_phieu.Text;
        m_us_gd_tang_giam_tai_san.dcDIEN_TICH = v_us_dm_nha.dcDT_XAY_DUNG;
        m_us_gd_tang_giam_tai_san.dcGIA_TRI_NGUYEN_GIA_TANG_GIAM = v_us_dm_nha.dcNGUON_NS + v_us_dm_nha.dcNGUON_KHAC;

        m_us_gd_tang_giam_tai_san.dcID_NGUOI_LAP = Person.get_user_id();
        m_us_gd_tang_giam_tai_san.dcID_NGUOI_DUYET = Person.get_user_id();

        m_us_gd_tang_giam_tai_san.Insert();

        // Phần cập nhật thông tin cho DM
        if (m_rbl_loai.SelectedValue == "N")
        {
            v_us_dm_nha.dcID_TRANG_THAI = ID_TRANG_THAI_NHA.DA_THANH_LY;
            v_us_dm_nha.Update();
        }
        else
        {
            v_us_dm_nha.dcID_TRANG_THAI = ID_TRANG_THAI_NHA.DE_NGHI_TRANG_CAP;
            v_us_dm_nha.Update();
        }

        m_lbl_message.Text = "Cập nhật thành công";
    }

    private void select_loai_tang_giam()
    {
        decimal v_dc_loai_tang_giam = CIPConvert.ToDecimal(m_cbo_ly_do_thay_doi.SelectedValue);
        if (v_dc_loai_tang_giam == ID_LY_DO_TANG_GIAM_TAI_SAN.THANH_LY
            || v_dc_loai_tang_giam == ID_LY_DO_TANG_GIAM_TAI_SAN.DIEU_CHUYEN)
        {
            m_rbl_loai.SelectedValue = "N";
        }
        else
        {
            m_rbl_loai.SelectedValue = "Y";
        }
    }

    private void export_gridview_to_excel()
    {
        m_grv_danh_sach_nha.AllowPaging = false;
        load_data_to_grid();
        WinformReport.export_gridview_2_excel(
                m_grv_danh_sach_nha
                , "De nghi tang giam nha.xls");
    }

    private void clear_message()
    {
        m_lbl_message.Text = "";
    }

    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                load_data_2_form();
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void m_cbo_bo_tinh_up_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            load_data_to_dv_chu_quan_up();
            load_data_to_dv_su_dung_up();
            load_data_to_khu_dat_up();
            load_data_to_ten_tai_san();
            load_data_from_us();
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
            clear_message();
            load_data_to_dv_su_dung_up();
            load_data_to_khu_dat_up();
            load_data_to_ten_tai_san();
            load_data_from_us();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_su_dung_tai_san_up_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            load_data_to_khu_dat_up();
            load_data_to_ten_tai_san();
            load_data_from_us();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_thuoc_khu_dat_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            load_data_to_ten_tai_san();
            load_data_from_us();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_ten_tai_san_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            load_data_from_us();
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
            clear_message();
            load_data_to_dv_chu_quan_down();
            load_data_to_dv_su_dung_down();
            load_data_to_khu_dat_down();
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
            clear_message();
            load_data_to_dv_su_dung_down();
            load_data_to_khu_dat_down();
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
            clear_message();
            load_data_to_khu_dat_down();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_ly_do_thay_doi_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            select_loai_tang_giam();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            if (!check_validate_data_is_ok()) return;
            them_moi_tang_giam();
            load_data_2_form();
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
            clear_message();
            clear_form_data();
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
            clear_message();
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            export_gridview_to_excel();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_hdf_id_ValueChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_danh_sach_nha_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            clear_message();
            m_grv_danh_sach_nha.PageIndex = e.NewPageIndex;
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_danh_sach_nha_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_txt_tu_khoa_TextChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion       
    
}
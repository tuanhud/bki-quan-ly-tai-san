using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPBusinessService;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPException;
using IP.Core.IPUserService;
using IP.Core.QltsFormControls;
using IP.Core.WinFormControls;
using IP.Core.IPSystemAdmin;
using WebDS;
using WebDS.CDBNames;
using WebUS;

public partial class ChucNang_F109_DuyetGhiTangGiamTaiSanKhac : System.Web.UI.Page
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
        load_data_trang_thai_up();
        load_data_trang_thai_down();
        load_data_to_ten_tai_san();
        load_data_to_ly_do();
        select_loai_tang_giam();
        load_data_from_us();
        load_data_to_grid();
    }

    private void load_data_to_ly_do()
    {
        WinFormControls.load_data_to_cbo_tu_dien(
            WinFormControls.eLOAI_TU_DIEN.LY_DO_TANG_GIAM_TS
            , WinFormControls.eTAT_CA.NO
            , m_cbo_ly_do_thay_doi);
    }

    private void load_data_from_us()
    {
        clear_form_data();
        if (m_cbo_ten_tai_san.Items.Count == 0) return;
        decimal v_dc_id_oto = CIPConvert.ToDecimal(m_cbo_ten_tai_san.SelectedValue);
        if (v_dc_id_oto < 1) return;
        US_DM_TAI_SAN_KHAC v_us_dm_tai_san_khac = new US_DM_TAI_SAN_KHAC(CIPConvert.ToDecimal(v_dc_id_oto));
        m_lbl_ma_tai_san.Text = v_us_dm_tai_san_khac.strMA_TAI_SAN;
        m_lbl_ky_hieu.Text = v_us_dm_tai_san_khac.strKY_HIEU;
        m_lbl_nuoc_san_xuat.Text = v_us_dm_tai_san_khac.strNUOC_SAN_XUAT;
        m_lbl_nam_san_xuat.Text = v_us_dm_tai_san_khac.dcNAM_SAN_XUAT.ToString();
        m_lbl_ngay_thang_nam_su_dung.Text = v_us_dm_tai_san_khac.dcNAM_SU_DUNG.ToString();
        m_lbl_nguyen_gia_nguon_ns.Text = v_us_dm_tai_san_khac.dcNGUON_NS.ToString("#,##0.00");
        m_lbl_nguyen_gia_nguon_khac.Text = v_us_dm_tai_san_khac.dcNGUON_KHAC.ToString("#,##0.00");
        m_lbl_gia_tri_con_lai.Text = v_us_dm_tai_san_khac.dcGIA_TRI_CON_LAI.ToString("#,##0.00");
    }

    private void load_data_trang_thai_up()
    {
        WinFormControls.load_data_to_cbo_tu_dien(
            WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC
            , WinFormControls.eTAT_CA.NO
            , m_cbo_trang_thai_tai_san_up);
        m_cbo_trang_thai_tai_san_up.SelectedValue = TRANG_THAI_TAI_SAN_KHAC.DE_NGHI_XU_LY;
    }

    private void load_data_trang_thai_down()
    {
        WinFormControls.load_data_to_cbo_tu_dien(
            WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC
            , WinFormControls.eTAT_CA.YES
            , m_cbo_trang_thai_tai_san_down);
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
                    , m_cbo_don_vi_su_dung_tai_san_down);
    }

    private void load_data_to_ten_tai_san()
    {
        US_V_DM_TAI_SAN_KHAC v_us_v_dm_tai_san_khac = new US_V_DM_TAI_SAN_KHAC();
        DS_V_DM_TAI_SAN_KHAC v_ds_v_dm_tai_san_khac = new DS_V_DM_TAI_SAN_KHAC();
        v_us_v_dm_tai_san_khac.FillDataSetLoadDataToGridTaiSanKhac(
            Person.get_user_name()
            , CIPConvert.ToDecimal(m_cbo_bo_tinh_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_trang_thai_tai_san_up.SelectedValue)
            , v_ds_v_dm_tai_san_khac);
        m_cbo_ten_tai_san.DataSource = v_ds_v_dm_tai_san_khac.V_DM_TAI_SAN_KHAC;
        m_cbo_ten_tai_san.DataTextField = V_DM_TAI_SAN_KHAC.TEN_TAI_SAN;
        m_cbo_ten_tai_san.DataValueField = V_DM_TAI_SAN_KHAC.ID;
        m_cbo_ten_tai_san.DataBind();
    }

    private void load_data_to_grid()
    {
        m_lbl_thong_tin.Text = "Danh sách duyệt ghi tăng giảm tài sản khác";
        US_V_GD_TANG_GIAM_TAI_SAN_KHAC v_us_v_gd_tg_tsk = new US_V_GD_TANG_GIAM_TAI_SAN_KHAC();
        DS_V_GD_TANG_GIAM_TAI_SAN_KHAC v_ds_v_gd_tg_tsk = new DS_V_GD_TANG_GIAM_TAI_SAN_KHAC();
        v_us_v_gd_tg_tsk.FillDataSetByKeyWord(
            m_cbo_bo_tinh_down.SelectedValue
            , m_cbo_don_vi_chu_quan_down.SelectedValue
            , m_cbo_don_vi_su_dung_tai_san_down.SelectedValue
            , m_cbo_trang_thai_tai_san_down.SelectedValue
            , Person.get_user_name()
            , CONST_QLDB.MA_TAT_CA
            , m_txt_tu_khoa.Text.Trim()
            , v_ds_v_gd_tg_tsk);

        string v_str_thong_tin = " (Có " + v_ds_v_gd_tg_tsk.V_GD_TANG_GIAM_TAI_SAN_KHAC.Rows.Count + " bản ghi)";
        m_lbl_thong_tin.Text += v_str_thong_tin;

        m_grv_danh_sach_tai_san_khac.DataSource = v_ds_v_gd_tg_tsk.V_GD_TANG_GIAM_TAI_SAN_KHAC;
        m_grv_danh_sach_tai_san_khac.DataBind();
    }

    private void clear_form_data()
    {
        m_txt_ma_phieu.Text = "";
    }

    private bool check_validate_data_is_ok()
    {
        if (m_cbo_ten_tai_san.Items.Count == 0)
        {
            m_lbl_mess.Text = "Bạn chưa lựa chọn tài sản";
            return false;
        }

        if (!m_us_gd_tang_giam_tai_san.check_valid_ma_phieu(m_txt_ma_phieu.Text))
        {
            m_lbl_mess.Text = "Lỗi: Mã phiểu này đã tồn tại";
            return false;
        }
        return true;
    }

    private void them_moi_tang_giam()
    {
        US_DM_TAI_SAN_KHAC v_us_dm_tai_san_khac = new US_DM_TAI_SAN_KHAC(CIPConvert.ToDecimal(m_cbo_ten_tai_san.SelectedValue));
        m_us_gd_tang_giam_tai_san = new US_GD_TANG_GIAM_TAI_SAN();
        m_us_gd_tang_giam_tai_san.datNGAY_DUYET = m_dat_ngay_duyet.SelectedDate;
        m_us_gd_tang_giam_tai_san.datNGAY_TANG_GIAM_TAI_SAN = m_dat_ngay_tang_giam.SelectedDate;
        m_us_gd_tang_giam_tai_san.dcID_LY_DO_TANG_GIAM = CIPConvert.ToDecimal(m_cbo_ly_do_thay_doi.SelectedValue);
        m_us_gd_tang_giam_tai_san.strTANG_GIA_TRI_TAI_SAN_YN = m_rbl_loai.SelectedValue;

        m_us_gd_tang_giam_tai_san.dcID_TAI_SAN = v_us_dm_tai_san_khac.dcID;
        m_us_gd_tang_giam_tai_san.dcID_LOAI_TAI_SAN = v_us_dm_tai_san_khac.dcID_LOAI_TAI_SAN;
        m_us_gd_tang_giam_tai_san.strMA_PHIEU = m_txt_ma_phieu.Text;
        m_us_gd_tang_giam_tai_san.dcDIEN_TICH = v_us_dm_tai_san_khac.dcKINH_DOANH + v_us_dm_tai_san_khac.dcKHONG_KINH_DOANH;
        m_us_gd_tang_giam_tai_san.dcGIA_TRI_NGUYEN_GIA_TANG_GIAM = v_us_dm_tai_san_khac.dcNGUON_NS + v_us_dm_tai_san_khac.dcNGUON_KHAC;

        m_us_gd_tang_giam_tai_san.dcID_NGUOI_LAP = Person.get_user_id();
        m_us_gd_tang_giam_tai_san.dcID_NGUOI_DUYET = Person.get_user_id();

        m_us_gd_tang_giam_tai_san.Insert();

        // Phần cập nhật thông tin cho DM
        // Phần cập nhật thông tin cho DM
        if (m_cbo_ly_do_thay_doi.SelectedValue == ID_LY_DO_TANG_GIAM_TAI_SAN.THANH_LY.ToString())
        {
            v_us_dm_tai_san_khac.dcID_TRANG_THAI = ID_TRANG_THAI_TAI_SAN_KHAC.DA_THANH_LY;
            v_us_dm_tai_san_khac.Update();
            return;
        }
        if (m_cbo_ly_do_thay_doi.SelectedValue == ID_LY_DO_TANG_GIAM_TAI_SAN.DIEU_CHUYEN.ToString())
        {
            v_us_dm_tai_san_khac.dcID_TRANG_THAI = ID_TRANG_THAI_TAI_SAN_KHAC.DA_DIEU_CHUYEN;
            v_us_dm_tai_san_khac.Update();
            return;
        }
        if (m_cbo_ly_do_thay_doi.SelectedValue == ID_LY_DO_TANG_GIAM_TAI_SAN.TRANG_CAP_MUA_MOI.ToString())
        {
            v_us_dm_tai_san_khac.dcID_TRANG_THAI = ID_TRANG_THAI_TAI_SAN_KHAC.DANG_SU_DUNG;
            v_us_dm_tai_san_khac.Update();
            return;
        }

        m_lbl_mess.Text = "Cập nhật thành công";
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
        m_grv_danh_sach_tai_san_khac.AllowPaging = false;
        load_data_to_grid();
        WinformReport.export_gridview_2_excel(
                m_grv_danh_sach_tai_san_khac
                , "De nghi tang giam tai san khac.xls");
    }

    private void clear_message()
    {
        m_lbl_mess.Text = "";
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
    protected void m_cbo_trang_thai_tai_san_up_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void m_cbo_bo_tinh_down_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            load_data_to_dv_chu_quan_down();
            load_data_to_dv_su_dung_down();
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
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
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
    protected void m_grv_danh_sach_tai_san_khac_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            clear_message();
            m_grv_danh_sach_tai_san_khac.PageIndex = e.NewPageIndex;
            load_data_to_grid();
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
            clear_message();
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_su_dung_tai_san_down_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_trang_thai_tai_san_down_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
}
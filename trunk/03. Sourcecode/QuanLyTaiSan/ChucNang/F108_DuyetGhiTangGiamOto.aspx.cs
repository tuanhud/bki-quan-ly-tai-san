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


public partial class ChucNang_F108_DuyetGhiTangGiamOto : System.Web.UI.Page
{
    #region Members
    private US_GD_TANG_GIAM_TAI_SAN m_us_gd_tang_giam_tai_san = new US_GD_TANG_GIAM_TAI_SAN();
    #endregion

    #region Private Methods
    private void load_data_2_form()
    {
        load_data_to_bo_tinh_up();
        load_data_to_bo_tinh_down();
        load_data_to_dv_chu_quan_up();
        load_data_to_dv_chu_quan_down();
        load_data_to_dv_su_dung_up();
        load_data_to_dv_su_dung_down();
        load_data_trang_thai_up();
        load_data_trang_thai_down();
        load_cbo_loai_xe();
        load_data_to_ten_tai_san();
        load_data_to_ly_do();
        select_loai_tang_giam();
        set_caption_by_loai_tang_giam();
        load_data_from_us();
        load_data_to_grid();
    }

    private void load_cbo_loai_xe()
    {
        try
        {
            DS_DM_LOAI_TAI_SAN v_ds_dm_loaits = new DS_DM_LOAI_TAI_SAN();
            US_DM_LOAI_TAI_SAN v_us_dm_loaits = new US_DM_LOAI_TAI_SAN();
            // DataRow v_dr_all = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.NewCM_DM_TU_DIENRow();
            // Đổ dữ liệu vào DS 
            v_us_dm_loaits.FillDataset(v_ds_dm_loaits, "where " + DM_LOAI_TAI_SAN.ID_LOAI_TAI_SAN_PARENT + " = " + ID_LOAI_TAI_SAN.OTO); // Đây là lấy theo điều kiện
            m_cbo_loai_o_to_up.DataSource = v_ds_dm_loaits.DM_LOAI_TAI_SAN;
            m_cbo_loai_o_to_up.DataTextField = "TEN_LOAI_TAI_SAN";
            m_cbo_loai_o_to_up.DataValueField = "ID";
            m_cbo_loai_o_to_up.DataBind();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    private void load_data_to_ly_do()
    {
        WinFormControls.eLOAI_TANG_GIAM_TAI_SAN v_e_loai = WinFormControls.eLOAI_TANG_GIAM_TAI_SAN.GIAM_TAI_SAN;

        string v_str_trang_thai = m_cbo_trang_thai_o_to_up.SelectedValue;

        switch (v_str_trang_thai)
        {
            case TRANG_THAI_DAT.DE_NGHI_XU_LY:
                v_e_loai = WinFormControls.eLOAI_TANG_GIAM_TAI_SAN.GIAM_TAI_SAN;
                break;
            case TRANG_THAI_DAT.DA_DIEU_CHUYEN:
                v_e_loai = WinFormControls.eLOAI_TANG_GIAM_TAI_SAN.TANG_TAI_SAN;
                break;
        }

        WinFormControls.load_data_to_cbo_ly_do_tang_giam(
            WinFormControls.eLOAI_TU_DIEN.LY_DO_TANG_GIAM_TS
            , v_e_loai
            , m_cbo_ly_do_thay_doi);    
    }

    private void load_data_from_us()
    {
        clear_form_data();
        if (m_cbo_ten_tai_san.Items.Count == 0) return;
        decimal v_dc_id_oto = CIPConvert.ToDecimal(m_cbo_ten_tai_san.SelectedValue);
        if (v_dc_id_oto < 1) return;
        US_DM_OTO v_us_dm_oto = new US_DM_OTO(CIPConvert.ToDecimal(v_dc_id_oto));
        m_lbl_ma_tai_san.Text = v_us_dm_oto.strMA_TAI_SAN;
        m_lbl_nhan_hieu.Text = v_us_dm_oto.strNHAN_HIEU;
        m_lbl_bien_kiem_soat.Text = v_us_dm_oto.strBIEN_KIEM_SOAT;
        m_lbl_chuc_dang_su_dung.Text = v_us_dm_oto.strCHUC_DANH_SU_DUNG;
        m_lbl_nuoc_san_xuat.Text = v_us_dm_oto.strNUOC_SAN_XUAT;
        m_lbl_nam_san_xuat.Text = v_us_dm_oto.dcNAM_SAN_XUAT.ToString();
        m_lbl_nam_su_dung.Text = v_us_dm_oto.dcNAM_SU_DUNG.ToString();
        m_lbl_nguyen_gia_nguon_ns.Text = v_us_dm_oto.dcNGUON_NS.ToString("#,##0.00");
        m_lbl_nguyen_gia_nguon_khac.Text = v_us_dm_oto.dcNGUON_KHAC.ToString("#,##0.00");
        m_lbl_gia_tri_con_lai.Text = v_us_dm_oto.dcGIA_TRI_CON_LAI.ToString("#,##0.00");
    }

    private void load_data_trang_thai_up()
    {
        WinFormControls.load_data_to_cbo_trang_thai_tang_giam(
            WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_OTO
            , WinFormControls.eTAT_CA.NO
            , m_cbo_trang_thai_o_to_up);
    }

    private void load_data_trang_thai_down()
    {
        WinFormControls.load_data_to_cbo_tu_dien(
            WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_OTO
            , WinFormControls.eTAT_CA.YES
            , m_cbo_trang_thai_o_to_down);
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
        DS_V_DM_OTO v_ds_v_dm_oto = new DS_V_DM_OTO();
        US_V_DM_OTO v_us_v_dm_oto = new US_V_DM_OTO();
        v_us_v_dm_oto.FillDatasetLoadDataToGridOto_by_tu_khoa(
            String.Empty
            , CIPConvert.ToDecimal(m_cbo_bo_tinh_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_trang_thai_o_to_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_loai_o_to_up.SelectedValue)
            , CONST_QLDB.MA_TAT_CA
            , Person.get_user_name()
            , v_ds_v_dm_oto);
        m_cbo_ten_tai_san.DataSource = v_ds_v_dm_oto.V_DM_OTO;
        m_cbo_ten_tai_san.DataTextField = V_DM_OTO.TEN_TAI_SAN;
        m_cbo_ten_tai_san.DataValueField = V_DM_OTO.ID;
        m_cbo_ten_tai_san.DataBind();
    }

    private void load_data_to_grid()
    {
        m_lbl_thong_tin.Text = "Danh sách duyệt ghi tăng ô tô ";
        US_V_GD_TANG_GIAM_TAI_SAN_OTO v_us_v_gd_tg_tsoto = new US_V_GD_TANG_GIAM_TAI_SAN_OTO();
        DS_V_GD_TANG_GIAM_TAI_SAN_OTO v_ds_v_gd_tg_tsoto = new DS_V_GD_TANG_GIAM_TAI_SAN_OTO();
        v_us_v_gd_tg_tsoto.FillDatasetLoadDataToGridOto_by_tu_khoa(
            m_txt_tu_khoa.Text.Trim()
            , CIPConvert.ToDecimal(m_cbo_bo_tinh_down.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan_down.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san_down.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_trang_thai_o_to_down.SelectedValue)
            , CONST_QLDB.ID_TAT_CA
            , CONST_QLDB.MA_TAT_CA
            , Person.get_user_name()
            , v_ds_v_gd_tg_tsoto);

        string v_str_thong_tin = " (Có " + v_ds_v_gd_tg_tsoto.V_GD_TANG_GIAM_TAI_SAN_OTO.Rows.Count + " bản ghi)";
        m_lbl_thong_tin.Text += v_str_thong_tin;


        m_grv_danh_sach_oto.DataSource = v_ds_v_gd_tg_tsoto.V_GD_TANG_GIAM_TAI_SAN_OTO;
        m_grv_danh_sach_oto.DataBind();
    }

    private void clear_form_data()
    {
        m_txt_ma_phieu.Text = "";
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
        return true;
    }

    private void them_moi_tang_giam()
    {
        US_DM_OTO v_us_dm_oto = new US_DM_OTO(CIPConvert.ToDecimal(m_cbo_ten_tai_san.SelectedValue));
        m_us_gd_tang_giam_tai_san = new US_GD_TANG_GIAM_TAI_SAN();
        m_us_gd_tang_giam_tai_san.datNGAY_DUYET = m_dat_ngay_duyet.SelectedDate;
        m_us_gd_tang_giam_tai_san.datNGAY_TANG_GIAM_TAI_SAN = m_dat_ngay_tang_giam.SelectedDate;
        m_us_gd_tang_giam_tai_san.dcID_LY_DO_TANG_GIAM = CIPConvert.ToDecimal(m_cbo_ly_do_thay_doi.SelectedValue);
        m_us_gd_tang_giam_tai_san.strTANG_GIA_TRI_TAI_SAN_YN = m_rbl_loai.SelectedValue;

        m_us_gd_tang_giam_tai_san.dcID_TAI_SAN = v_us_dm_oto.dcID;
        m_us_gd_tang_giam_tai_san.dcID_LOAI_TAI_SAN = v_us_dm_oto.dcID_LOAI_TAI_SAN;
        m_us_gd_tang_giam_tai_san.strMA_PHIEU = m_txt_ma_phieu.Text;
        m_us_gd_tang_giam_tai_san.dcDIEN_TICH = v_us_dm_oto.dcKINH_DOANH + v_us_dm_oto.dcKHONG_KINH_DOANH;
        m_us_gd_tang_giam_tai_san.dcGIA_TRI_NGUYEN_GIA_TANG_GIAM = v_us_dm_oto.dcNGUON_NS + v_us_dm_oto.dcNGUON_KHAC;

        m_us_gd_tang_giam_tai_san.dcID_NGUOI_LAP = Person.get_user_id();
        m_us_gd_tang_giam_tai_san.dcID_NGUOI_DUYET = Person.get_user_id();

        m_us_gd_tang_giam_tai_san.Insert();

        // Phần cập nhật thông tin cho DM
        if (m_cbo_ly_do_thay_doi.SelectedValue == ID_LY_DO_TANG_GIAM_TAI_SAN.THANH_LY.ToString())
        {
            v_us_dm_oto.dcID_TRANG_THAI = ID_TRANG_THAI_OTO.DA_THANH_LY;
            v_us_dm_oto.Update();
            return;
        }
        if (m_cbo_ly_do_thay_doi.SelectedValue == ID_LY_DO_TANG_GIAM_TAI_SAN.DIEU_CHUYEN.ToString())
        {
            v_us_dm_oto.dcID_TRANG_THAI = ID_TRANG_THAI_OTO.DA_DIEU_CHUYEN;
            v_us_dm_oto.Update();
            return;
        }
        if (m_cbo_ly_do_thay_doi.SelectedValue == ID_LY_DO_TANG_GIAM_TAI_SAN.TRANG_CAP_MUA_MOI.ToString())
        {
            v_us_dm_oto.dcID_TRANG_THAI = ID_TRANG_THAI_OTO.DANG_SU_DUNG;
            v_us_dm_oto.Update();
            return;
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
        m_grv_danh_sach_oto.AllowPaging = false;
        load_data_to_grid();
        WinformReport.export_gridview_2_excel(
                m_grv_danh_sach_oto
                , "De nghi tang giam oto.xls");
    }

    private void clear_message()
    {
        m_lbl_message.Text = "";
    }

    private void set_caption_by_loai_tang_giam()
    {
        decimal v_dc_loai_tang_giam = CIPConvert.ToDecimal(m_cbo_ly_do_thay_doi.SelectedValue);
        if (v_dc_loai_tang_giam == ID_LY_DO_TANG_GIAM_TAI_SAN.THANH_LY)
        {
            m_lbl_caption.Text = "CHI TIẾT THANH LÝ TÀI SẢN ĐẤT";
            return;
        }
        if (v_dc_loai_tang_giam == ID_LY_DO_TANG_GIAM_TAI_SAN.DIEU_CHUYEN)
        {
            m_lbl_caption.Text = "CHI TIẾT ĐIỀU CHUYỂN TÀI SẢN ĐẤT";
            return;
        }
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
    protected void m_cbo_loai_o_to_up_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void m_cbo_trang_thai_o_to_up_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void m_cbo_ly_do_thay_doi_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            select_loai_tang_giam();
            set_caption_by_loai_tang_giam();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_danh_sach_oto_RowCommand(object sender, GridViewCommandEventArgs e)
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
    protected void m_grv_danh_sach_oto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            clear_message();
            m_grv_danh_sach_oto.PageIndex = e.NewPageIndex;
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
    protected void m_cbo_trang_thai_o_to_down_SelectedIndexChanged(object sender, EventArgs e)
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
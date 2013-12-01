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

public partial class ChucNang_F107_DuyetGhiTangDat : System.Web.UI.Page
{
    #region Members
    private US_GD_TANG_GIAM_TAI_SAN m_us_gd_tang_giam_tai_san = new US_GD_TANG_GIAM_TAI_SAN();
    #endregion

    #region Private Methods
    private void load_data_2_form()
    {
        clear_form_data();
        clear_thong_tin_tai_san();
        load_data_to_bo_tinh_up();
        load_data_to_bo_tinh_down();
        load_data_to_dv_chu_quan_up();
        load_data_to_dv_chu_quan_down();
        load_data_to_dv_su_dung_up();
        load_data_to_dv_su_dung_down();
        load_data_trang_thai();
        load_data_to_dia_chi();
        load_data_to_ly_do();
        select_loai_tang_giam();
        set_caption_by_loai_tang_giam();
        load_data_from_us();
        load_data_to_grid();
    }

    private void load_data_to_ly_do()
    {
        WinFormControls.eLOAI_TANG_GIAM_TAI_SAN v_e_loai = WinFormControls.eLOAI_TANG_GIAM_TAI_SAN.GIAM_TAI_SAN;

        string v_str_trang_thai = m_cbo_trang_thai_dat_up.SelectedValue;

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
        if (m_cbo_dia_chi.Items.Count == 0) return;
        decimal v_dc_id_dat = CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue);
        if (v_dc_id_dat < 1) return;
        US_DM_DAT v_us_dm_dat = new US_DM_DAT(CIPConvert.ToDecimal(v_dc_id_dat));
        m_lbl_ma_tai_san.Text = v_us_dm_dat.strMA_TAI_SAN;
        m_lbl_dt_khuon_vien.Text = v_us_dm_dat.dcDT_KHUON_VIEN.ToString("#,##0");
        m_lbl_gt_theo_so_ke_toan.Text = v_us_dm_dat.dcGT_THEO_SO_KE_TOAN.ToString("#,##0");
        m_lbl_so_nam_su_dung.Text = v_us_dm_dat.dcSO_NAM_DA_SU_DUNG.ToString("#,##0");
    }

    private void load_data_trang_thai()
    {
        WinFormControls.load_data_to_cbo_trang_thai_tang_giam(
            WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_DAT
            , WinFormControls.eTAT_CA.NO
            , m_cbo_trang_thai_dat_up);
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
                    , m_cbo_don_vi_su_dung_up);
    }

    private void load_data_to_dv_su_dung_down()
    {
        WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan_down.SelectedValue
                    , m_cbo_bo_tinh_down.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung_down);
    }

    private void load_data_to_dia_chi()
    {
        WinFormControls.load_data_to_cbo_dia_chi(
                   CIPConvert.ToDecimal(m_cbo_bo_tinh_up.SelectedValue)
                 , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan_up.SelectedValue)
                 , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_up.SelectedValue)
                 , CIPConvert.ToDecimal(m_cbo_trang_thai_dat_up.SelectedValue)
                 , WinFormControls.eTAT_CA.NO
                 , m_cbo_dia_chi);
    }

    private void load_data_to_grid()
    {
        m_lbl_thong_tin_dat.Text = "Danh sách duyệt ghi tăng đất ";
        US_V_GD_TANG_GIAM_TAI_SAN_DAT v_us_v_gd_tg_tsd = new US_V_GD_TANG_GIAM_TAI_SAN_DAT();
        DS_V_GD_TANG_GIAM_TAI_SAN_DAT v_ds_v_gd_tg_tsd = new DS_V_GD_TANG_GIAM_TAI_SAN_DAT();
        v_us_v_gd_tg_tsd.FillDataSetByKeyWord(
            m_cbo_bo_tinh_down.SelectedValue
            , m_cbo_don_vi_su_dung_down.SelectedValue
            , m_cbo_don_vi_su_dung_down.SelectedValue
            , CONST_QLDB.MA_TAT_CA
            , Person.get_user_name()
            , CONST_QLDB.MA_TAT_CA
            , m_txt_tu_khoa.Text.Trim()
            , v_ds_v_gd_tg_tsd);
        string v_str_thong_tin = " (Có " + v_ds_v_gd_tg_tsd.V_GD_TANG_GIAM_TAI_SAN_DAT.Rows.Count + " bản ghi)";
        m_lbl_thong_tin_dat.Text += v_str_thong_tin;


        m_grv_danh_sach_dat.DataSource = v_ds_v_gd_tg_tsd.V_GD_TANG_GIAM_TAI_SAN_DAT;
        m_grv_danh_sach_dat.DataBind();
    }

    private void clear_form_data()
    {
        m_txt_ma_phieu.Text = "";
    }

    private bool check_validate_data_is_ok()
    {
        if (m_cbo_dia_chi.Items.Count == 0)
        {
            m_lbl_message.Text = "Bạn chưa lựa chọn tài sản";
            m_cbo_dia_chi.Focus();
            return false;
        }

        if (!m_us_gd_tang_giam_tai_san.check_valid_ma_phieu(m_txt_ma_phieu.Text))
        {
            m_lbl_message.Text = "Lỗi: Mã phiểu này đã tồn tại";
            m_txt_ma_phieu.Focus();
            return false;
        }
        return true;
    }

    private void them_moi_tang_giam()
    {
        US_DM_DAT v_us_dm_dat = new US_DM_DAT(CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue));
        m_us_gd_tang_giam_tai_san = new US_GD_TANG_GIAM_TAI_SAN();
        m_us_gd_tang_giam_tai_san.datNGAY_DUYET = m_dat_ngay_duyet.SelectedDate;
        m_us_gd_tang_giam_tai_san.datNGAY_TANG_GIAM_TAI_SAN = m_dat_ngay_tang_giam.SelectedDate;
        m_us_gd_tang_giam_tai_san.dcID_LY_DO_TANG_GIAM = CIPConvert.ToDecimal(m_cbo_ly_do_thay_doi.SelectedValue);
        m_us_gd_tang_giam_tai_san.strTANG_GIA_TRI_TAI_SAN_YN = m_rbl_loai.SelectedValue;

        m_us_gd_tang_giam_tai_san.dcID_TAI_SAN = v_us_dm_dat.dcID;
        m_us_gd_tang_giam_tai_san.dcID_LOAI_TAI_SAN = v_us_dm_dat.dcID_LOAI_TAI_SAN;
        m_us_gd_tang_giam_tai_san.strMA_PHIEU = m_txt_ma_phieu.Text;
        m_us_gd_tang_giam_tai_san.dcDIEN_TICH = v_us_dm_dat.dcDT_KHUON_VIEN;
        if (m_rbl_loai_dieu_chuyen.SelectedValue == "N")
        {
            decimal v_dc_dt_dieu_chuyen = CIPConvert.ToDecimal(m_txt_dien_tich_dieu_chuyen.Text);
            m_us_gd_tang_giam_tai_san.dcDIEN_TICH = v_dc_dt_dieu_chuyen;
            v_us_dm_dat.dcDT_KHUON_VIEN = v_us_dm_dat.dcDT_KHUON_VIEN - v_dc_dt_dieu_chuyen;
            v_us_dm_dat.Update();
        }
        m_us_gd_tang_giam_tai_san.dcGIA_TRI_NGUYEN_GIA_TANG_GIAM = v_us_dm_dat.dcGT_THEO_SO_KE_TOAN;

        m_us_gd_tang_giam_tai_san.dcID_NGUOI_LAP = Person.get_user_id();
        m_us_gd_tang_giam_tai_san.dcID_NGUOI_DUYET = Person.get_user_id();

        m_us_gd_tang_giam_tai_san.Insert();

        // Phần cập nhật thông tin cho DM
        
        if (m_cbo_ly_do_thay_doi.SelectedValue == ID_LY_DO_TANG_GIAM_TAI_SAN.THANH_LY.ToString())
        {
            v_us_dm_dat.dcID_TRANG_THAI = ID_TRANG_THAI_DAT.DA_THANH_LY;
            v_us_dm_dat.Update();
        }
        if (m_cbo_ly_do_thay_doi.SelectedValue == ID_LY_DO_TANG_GIAM_TAI_SAN.DIEU_CHUYEN.ToString())
        {
            update_thong_tin_tai_san(v_us_dm_dat);
            v_us_dm_dat.dcID_TRANG_THAI = ID_TRANG_THAI_DAT.DA_DIEU_CHUYEN;
        }
        if (m_cbo_ly_do_thay_doi.SelectedValue == ID_LY_DO_TANG_GIAM_TAI_SAN.TRANG_CAP_MUA_MOI.ToString())
        {
            v_us_dm_dat.dcID_TRANG_THAI = ID_TRANG_THAI_DAT.DANG_SU_DUNG;
            v_us_dm_dat.Update();
        }

        m_lbl_message.Text = "Cập nhật thành công";
        m_txt_tu_khoa.Text = m_us_gd_tang_giam_tai_san.strMA_PHIEU;
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
        m_grv_danh_sach_dat.AllowPaging = false;
        load_data_to_grid();
        WinformReport.export_gridview_2_excel(
                m_grv_danh_sach_dat
                , "De nghi tang giam dat.xls");
    }

    private void clear_message()
    {
        m_lbl_message.Text = "";
    }

    private void set_caption_by_loai_tang_giam()
    {
        decimal v_dc_loai_tang_giam = CIPConvert.ToDecimal(m_cbo_ly_do_thay_doi.SelectedValue);
        set_visible_dien_tich_dieu_chuyen();
        if (v_dc_loai_tang_giam == ID_LY_DO_TANG_GIAM_TAI_SAN.THANH_LY)
        {
            m_lbl_caption.Text = "CHI TIẾT THANH LÝ TÀI SẢN ĐẤT";
            m_lbl_ten_don_vi_nhan_dieu_chuyen.Visible = false;
            m_txt_don_vi_nhan_dieu_chuyen.Visible = false;
            m_rfv_don_vi_nhan.EnableClientScript = false;
            m_lbl_loai_dieu_chuyen.Visible = false;
            m_rbl_loai_dieu_chuyen.Visible = false;
            m_lbl_dien_tich_dc.Visible = false;
            m_txt_dien_tich_dieu_chuyen.Visible = false;
            m_rfv_dien_tich_dieu_chuyen.EnableClientScript = false;
            return;
        }
        if (v_dc_loai_tang_giam == ID_LY_DO_TANG_GIAM_TAI_SAN.DIEU_CHUYEN)
        {
            m_lbl_caption.Text = "CHI TIẾT ĐIỀU CHUYỂN TÀI SẢN ĐẤT";
            m_lbl_ten_don_vi_nhan_dieu_chuyen.Visible = true;
            m_txt_don_vi_nhan_dieu_chuyen.Visible = true;
            m_txt_don_vi_nhan_dieu_chuyen.Enabled = true;
            m_rfv_don_vi_nhan.EnableClientScript = true;
            m_lbl_loai_dieu_chuyen.Visible = true;
            m_rbl_loai_dieu_chuyen.Visible = true;
            return;
        }
    }

    private void set_visible_dien_tich_dieu_chuyen()
    {
        if (m_rbl_loai_dieu_chuyen.SelectedValue == "Y")
        {
            m_lbl_dien_tich_dc.Visible = false;
            m_txt_dien_tich_dieu_chuyen.Visible = false;
            m_rfv_dien_tich_dieu_chuyen.EnableClientScript = false;
        }
        else
        {
            m_lbl_dien_tich_dc.Visible = true;
            m_txt_dien_tich_dieu_chuyen.Visible = true;
            m_txt_dien_tich_dieu_chuyen.Enabled = true;
            m_rfv_dien_tich_dieu_chuyen.EnableClientScript = true;
        }
    }

    private void clear_thong_tin_tai_san()
    {
        m_lbl_ma_tai_san.Text = "";
        m_lbl_dt_khuon_vien.Text = "";
        m_lbl_gt_theo_so_ke_toan.Text = "";
        m_lbl_so_nam_su_dung.Text = "";
    }

    private void update_thong_tin_tai_san(US_DM_DAT ip_us_dm_dat)
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        string v_str_ma_don_vi = new Random().Next(1000).ToString();
        v_us_dm_don_vi.strMA_DON_VI = v_str_ma_don_vi;
        v_us_dm_don_vi.dcID_DON_VI_CAP_TREN = ID_DON_VI.DON_VI_CHU_QUAN_KHAC;
        v_us_dm_don_vi.dcID_LOAI_DON_VI = ID_LOAI_DON_VI.DV_SU_DUNG;
        v_us_dm_don_vi.dcLEVEL_MODE = 3;
        v_us_dm_don_vi.strTEN_DON_VI = m_txt_don_vi_nhan_dieu_chuyen.Text.Trim();
        v_us_dm_don_vi.strLOAI_HINH_DON_VI = TEN_LOAI_HINH_DON_VI.DON_VI_SU_NGHIEP_CTCTC;

        v_us_dm_don_vi.Insert();

        decimal v_id_don_vi_moi = v_us_dm_don_vi.dcID;
        v_us_dm_don_vi.strMA_DON_VI = "DVK" + v_id_don_vi_moi.ToString();
        v_us_dm_don_vi.Update();

        US_HT_QUAN_HE_SU_DUNG_DU_LIEU v_us_ht_qhsddl = new US_HT_QUAN_HE_SU_DUNG_DU_LIEU();
        v_us_ht_qhsddl.dcID_DON_VI = v_us_dm_don_vi.dcID;
        v_us_ht_qhsddl.dcID_USER_GROUP = 2;
        v_us_ht_qhsddl.Insert();

        v_us_ht_qhsddl = new US_HT_QUAN_HE_SU_DUNG_DU_LIEU();
        v_us_ht_qhsddl.dcID_DON_VI = v_us_dm_don_vi.dcID;
        v_us_ht_qhsddl.dcID_USER_GROUP = 5;
        v_us_ht_qhsddl.Insert();
        if (m_rbl_loai.SelectedValue == "Y")
        {
            ip_us_dm_dat.dcID_DON_VI_SU_DUNG = v_us_dm_don_vi.dcID;
            ip_us_dm_dat.dcID_DON_VI_CHU_QUAN = ID_DON_VI.DON_VI_CHU_QUAN_KHAC;
            ip_us_dm_dat.Update();
        }
        else
        {
            ip_us_dm_dat.dcID_DON_VI_SU_DUNG = v_us_dm_don_vi.dcID;
            ip_us_dm_dat.dcID_DON_VI_CHU_QUAN = ID_DON_VI.DON_VI_CHU_QUAN_KHAC;
            ip_us_dm_dat.dcDT_KHUON_VIEN = CIPConvert.ToDecimal(m_txt_dien_tich_dieu_chuyen.Text);
            ip_us_dm_dat.strMA_TAI_SAN = ip_us_dm_dat.strMA_TAI_SAN + "-DC";
            ip_us_dm_dat.Insert();
            ip_us_dm_dat.strMA_TAI_SAN = ip_us_dm_dat.strMA_TAI_SAN + "-" + ip_us_dm_dat.dcID;
            ip_us_dm_dat.Update();
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
            clear_thong_tin_tai_san();
            load_data_to_dv_chu_quan_up();
            load_data_to_dv_su_dung_up();
            load_data_to_dia_chi();
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
            clear_thong_tin_tai_san();
            load_data_to_dv_su_dung_up();
            load_data_to_dia_chi();
            load_data_from_us();
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
            clear_message();
            clear_thong_tin_tai_san();
            load_data_to_dia_chi();
            load_data_from_us();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_trang_thai_dat_up_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            clear_thong_tin_tai_san();
            load_data_to_dia_chi();
            load_data_from_us();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_dia_chi_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            clear_thong_tin_tai_san();
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
    protected void m_grv_danh_sach_dat_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_danh_sach_dat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            clear_message();
            m_grv_danh_sach_dat.PageIndex = e.NewPageIndex;
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
    protected void m_cbo_don_vi_su_dung_down_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void m_rbl_loai_dieu_chuyen_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            set_visible_dien_tich_dieu_chuyen();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion  
}
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

using System.Drawing;
using System.Web.UI;
using System.IO;


public partial class ChucNang_F101_QuanLyDat : System.Web.UI.Page
{
    #region Members
    private US_DM_DAT m_us_dm_dat = new US_DM_DAT();
    private DataEntryFormMode m_e_form_mode = DataEntryFormMode.InsertDataState;
    public const string C_STR_NEW_ID_DAT = "-1";
    #endregion

    #region Private Methods
    private void load_data_2_form()
    {
        load_data_bo_tinh();
        load_data_don_vi_chu_quan();
        load_data_don_vi_su_dung();
        load_data_trang_thai();
        load_data_tinh_trang_dat();
        load_data_2_grid();
        set_form_mode();
        hidden_panel_tang_giam();
    }
    private void load_data_bo_tinh()
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        WinFormControls.load_data_to_cbo_bo_tinh(WinFormControls.eTAT_CA.NO, m_ddl_bo_tinh);

        if (m_us_dm_dat.dcID_DON_VI_CHU_QUAN != 0)
        {
            v_us_dm_don_vi = new US_DM_DON_VI(m_us_dm_dat.dcID_DON_VI_CHU_QUAN);
            m_ddl_bo_tinh.SelectedValue = v_us_dm_don_vi.dcID_DON_VI_CAP_TREN.ToString();
        }
    }
    private void load_data_don_vi_chu_quan()
    {
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(m_ddl_bo_tinh.SelectedValue, WinFormControls.eTAT_CA.NO, m_ddl_don_vi_chu_quan);

        if (m_us_dm_dat.dcID_DON_VI_CHU_QUAN != 0)
        {
            m_ddl_don_vi_chu_quan.SelectedValue = m_us_dm_dat.dcID_DON_VI_CHU_QUAN.ToString();
        }
    }
    private void load_data_don_vi_su_dung()
    {
        WinFormControls.load_data_to_cbo_don_vi_su_dung(m_ddl_don_vi_chu_quan.SelectedValue
            , m_ddl_bo_tinh.SelectedValue
            , WinFormControls.eTAT_CA.NO
            , m_ddl_don_vi_su_dung);

        if (m_us_dm_dat.dcID_DON_VI_SU_DUNG != 0)
        {
            m_ddl_don_vi_su_dung.SelectedValue = m_us_dm_dat.dcID_DON_VI_SU_DUNG.ToString();
        }
    }
    private void load_data_trang_thai()
    {
        WinFormControls.load_data_to_cbo_tu_dien(
            WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_DAT
            , WinFormControls.eTAT_CA.NO
            , m_ddl_trang_thai);
        m_ddl_trang_thai.SelectedValue = TRANG_THAI_DAT.DANG_SU_DUNG;
    }
    private void load_data_tinh_trang_dat()
    {
        WinFormControls.load_data_to_cbo_tu_dien(
            WinFormControls.eLOAI_TU_DIEN.TINH_TRANG_TAI_SAN
            , WinFormControls.eTAT_CA.NO
            , m_ddl_tinh_trang_dat);
    }
    private void load_data_2_grid()
    {
        m_lbl_thong_tin_dat.Text = "DANH SÁCH ĐẤT";
        US_V_DM_DAT v_us_v_dm_dat = new US_V_DM_DAT();
        DS_V_DM_DAT v_ds_v_dm_dat = new DS_V_DM_DAT();

        v_us_v_dm_dat.FillDataSetByKeyWord(
            CONST_QLDB.ID_TAT_CA.ToString()
            , CONST_QLDB.ID_TAT_CA.ToString()
            , CONST_QLDB.ID_TAT_CA.ToString()
            , CONST_QLDB.ID_TAT_CA.ToString()
            , Person.get_user_name()
            , CONST_QLDB.ID_TAT_CA.ToString()
            , m_txt_tu_khoa.Text.Trim()
            , v_ds_v_dm_dat
            );
        string v_str_thong_tin = " (Có " + v_ds_v_dm_dat.V_DM_DAT.Rows.Count + " bản ghi)";
        m_lbl_thong_tin_dat.Text += v_str_thong_tin;
        m_grv_danh_sach_nha.DataSource = v_ds_v_dm_dat.V_DM_DAT;
        m_grv_danh_sach_nha.DataBind();
    }
    private void us_dm_dat_2_form()
    {
        m_hdf_id.Value = m_us_dm_dat.dcID.ToString();
        m_ddl_don_vi_chu_quan.SelectedValue = m_us_dm_dat.dcID_DON_VI_CHU_QUAN.ToString();
        m_ddl_don_vi_su_dung.SelectedValue = m_us_dm_dat.dcID_DON_VI_SU_DUNG.ToString();
        m_ddl_trang_thai.SelectedValue = m_us_dm_dat.dcID_TRANG_THAI.ToString();
        m_txt_dia_chi.Text = m_us_dm_dat.strDIA_CHI;
        m_txt_ma_tai_san.Text = m_us_dm_dat.strMA_TAI_SAN;
        m_txt_nam_xd.Text = m_us_dm_dat.dcSO_NAM_DA_SU_DUNG.ToString();
        m_txt_nguyen_gia.Text = m_us_dm_dat.dcGT_THEO_SO_KE_TOAN.ToString("#,##0");
        m_txt_dien_tich_khuon_vien.Text = m_us_dm_dat.dcDT_KHUON_VIEN.ToString("#,##0");
        m_txt_tru_so_lam_viec.Text = m_us_dm_dat.dcDT_TRU_SO_LAM_VIEC.ToString("#,##0");
        m_txt_lam_nha_o.Text = m_us_dm_dat.dcDT_LAM_NHA_O.ToString("#,##0");
        m_txt_co_so_hdsn.Text = m_us_dm_dat.dcDT_CO_SO_HOAT_DONG_SU_NGHIEP.ToString("#,##0");
        m_txt_cho_thue.Text = m_us_dm_dat.dcDT_CHO_THUE.ToString("#,##0");
        m_txt_bo_trong.Text = m_us_dm_dat.dcDT_BO_TRONG.ToString("#,##0");
        m_txt_bi_lan_chiem.Text = m_us_dm_dat.dcDT_BI_LAN_CHIEM.ToString("#,##0");
        m_txt_khac.Text = m_us_dm_dat.dcDT_SU_DUNG_MUC_DICH_KHAC.ToString("#,##0");
        m_ddl_tinh_trang_dat.SelectedValue = m_us_dm_dat.dcID_TINH_TRANG.ToString();
        m_txt_dia_chi.Focus();
    }
    private void form_2_us_dm_dat()
    {
        if (!m_hdf_id.Value.Equals(C_STR_NEW_ID_DAT))
        {
            m_us_dm_dat.dcID = CIPConvert.ToDecimal(m_hdf_id.Value);
        }
        m_us_dm_dat.dcID_DON_VI_CHU_QUAN = CIPConvert.ToDecimal(m_ddl_don_vi_chu_quan.SelectedValue);
        m_us_dm_dat.dcID_DON_VI_SU_DUNG = CIPConvert.ToDecimal(m_ddl_don_vi_su_dung.SelectedValue);
        m_us_dm_dat.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_ddl_trang_thai.SelectedValue);
        m_us_dm_dat.dcID_TINH_TRANG = CIPConvert.ToDecimal(m_ddl_tinh_trang_dat.SelectedValue);
        m_us_dm_dat.strDIA_CHI = m_txt_dia_chi.Text;
        m_us_dm_dat.strMA_TAI_SAN = m_txt_ma_tai_san.Text;
        if (m_txt_nam_xd.Text.Length == 0)
        {
            m_us_dm_dat.SetSO_NAM_DA_SU_DUNGNull();
        }
        else
        {
            m_us_dm_dat.dcSO_NAM_DA_SU_DUNG = CIPConvert.ToDecimal(m_txt_nam_xd.Text);
        }
        if (m_txt_nguyen_gia.Text.Length == 0)
        {
            m_us_dm_dat.SetGT_THEO_SO_KE_TOANNull();
        }
        else
        {
            m_us_dm_dat.dcGT_THEO_SO_KE_TOAN = CIPConvert.ToDecimal(m_txt_nguyen_gia.Text);
        }
        if (m_txt_dien_tich_khuon_vien.Text.Length == 0)
        {

            m_us_dm_dat.SetDT_KHUON_VIENNull();
        }
        else
        {
            m_us_dm_dat.dcDT_KHUON_VIEN = CIPConvert.ToDecimal(m_txt_dien_tich_khuon_vien.Text);
        }
        if (m_txt_tru_so_lam_viec.Text.Length == 0)
        {
            m_us_dm_dat.SetDT_TRU_SO_LAM_VIECNull();
        }
        else
        {
            m_us_dm_dat.dcDT_TRU_SO_LAM_VIEC = CIPConvert.ToDecimal(m_txt_tru_so_lam_viec.Text);
        }
        if (m_txt_lam_nha_o.Text.Length == 0)
        {
            m_us_dm_dat.SetDT_LAM_NHA_ONull();
        }
        else
        {
            m_us_dm_dat.dcDT_LAM_NHA_O = CIPConvert.ToDecimal(m_txt_lam_nha_o.Text);
        }
        if (m_txt_co_so_hdsn.Text.Length == 0)
        {
            m_us_dm_dat.SetDT_CO_SO_HOAT_DONG_SU_NGHIEPNull();
        }
        else
        {
            m_us_dm_dat.dcDT_CO_SO_HOAT_DONG_SU_NGHIEP = CIPConvert.ToDecimal(m_txt_co_so_hdsn.Text);
        }
        if (m_txt_cho_thue.Text.Length == 0)
        {
            m_us_dm_dat.SetDT_CHO_THUENull();
        }
        else
        {
            m_us_dm_dat.dcDT_CHO_THUE = CIPConvert.ToDecimal(m_txt_cho_thue.Text);
        }
        if (m_txt_bo_trong.Text.Length == 0)
        {
            m_us_dm_dat.SetDT_BO_TRONGNull();
        }
        else
        {
            m_us_dm_dat.dcDT_BO_TRONG = CIPConvert.ToDecimal(m_txt_bo_trong.Text);
        }

        m_us_dm_dat.dcDT_BI_LAN_CHIEM = CIPConvert.ToDecimal(m_txt_bi_lan_chiem.Text);
        m_us_dm_dat.dcDT_SU_DUNG_MUC_DICH_KHAC = CIPConvert.ToDecimal(m_txt_khac.Text);
        m_us_dm_dat.dcID_LOAI_TAI_SAN = ID_LOAI_TAI_SAN.DAT;

        m_us_dm_dat.dcID_NGUOI_DUYET = Person.get_user_id();
        m_us_dm_dat.dcID_NGUOI_LAP = Person.get_user_id();
        m_us_dm_dat.datNGAY_CAP_NHAT_CUOI = DateTime.Now;
    }
    private void set_form_mode()
    {
        switch (m_e_form_mode)
        {
            case DataEntryFormMode.InsertDataState:
                m_cmd_tao_moi.Visible = true;
                m_cmd_cap_nhat.Visible = false;
                m_lbl_caption.Text = "NHẬP MỚI TÀI SẢN ĐẤT";
                break;
            case DataEntryFormMode.SelectDataState:
                break;
            case DataEntryFormMode.UpdateDataState:
                m_cmd_tao_moi.Visible = false;
                m_cmd_cap_nhat.Visible = true;
                m_lbl_caption.Text = "CẬP NHẬT THÔNG TIN TÀI SẢN ĐẤT";
                break;
            case DataEntryFormMode.ViewDataState:
                break;
            default:
                break;
        }
    }
    private bool check_validate_data_is_ok()
    {
        if (m_ddl_don_vi_chu_quan.SelectedValue == "")
        {
            m_lbl_mess.Text = "Bạn chưa chọn đơn vị chủ quản!";
            m_txt_dia_chi.Focus();
            return false;
        }
        if (m_e_form_mode == DataEntryFormMode.InsertDataState)
        {
            if (!m_us_dm_dat.check_ma_tai_san_is_valid(m_txt_ma_tai_san.Text))
            {
                m_lbl_mess.Text = "Lỗi: Không thể cập nhật do ban nhập Mã tài sản đã tồn tại!";
                m_txt_ma_tai_san.Focus();
                return false;
            }
        }
        if (m_e_form_mode == DataEntryFormMode.UpdateDataState)
        {
            m_us_dm_dat = new US_DM_DAT(CIPConvert.ToDecimal(m_hdf_id.Value));
            if (m_us_dm_dat.strMA_TAI_SAN != m_txt_ma_tai_san.Text)
            {
                if (!m_us_dm_dat.check_ma_tai_san_is_valid(m_txt_ma_tai_san.Text))
                {
                    m_lbl_mess.Text = "Lỗi: Không thể cập nhật do mã tài sản này đã tồn tại!";
                    m_txt_ma_tai_san.Focus();
                    return false;
                }
            }
        }

        if (!CValidateTextBox.IsValid(m_txt_nguyen_gia, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_dien_tich_khuon_vien, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_tru_so_lam_viec, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_lam_nha_o, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_co_so_hdsn, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_cho_thue, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_bo_trong, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_bi_lan_chiem, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_khac, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_nam_xd, DataType.NumberType, allowNull.YES))
        {
            m_lbl_mess.Text = "Lỗi: Số năm đã sử dụng không đúng định dạng số";
            m_txt_nam_xd.Focus();
            return false;
        }

        if (CIPConvert.ToDecimal(m_txt_dien_tich_khuon_vien.Text) < CIPConvert.ToDecimal(m_txt_tru_so_lam_viec.Text) )
        {
            m_lbl_mess.Text = "Lỗi: Diện tích khuôn viên nhỏ hơn diện tích trụ sở làm việc.";
            m_txt_dien_tich_khuon_vien.Focus();
            return false;
        }

        if (CIPConvert.ToDecimal(m_txt_dien_tich_khuon_vien.Text) < CIPConvert.ToDecimal(m_txt_lam_nha_o.Text))
        {
            m_lbl_mess.Text = "Lỗi: Diện tích khuôn viên nhỏ hơn diện tích làm nhà ở.";
            m_txt_dien_tich_khuon_vien.Focus();
            return false;
        }

        if (CIPConvert.ToDecimal(m_txt_dien_tich_khuon_vien.Text) < CIPConvert.ToDecimal(m_txt_co_so_hdsn.Text))
        {
            m_lbl_mess.Text = "Lỗi: Diện tích khuôn viên nhỏ hơn diện tích cơ sở hoạt động sự nghiệp.";
            m_txt_dien_tich_khuon_vien.Focus();
            return false;
        }

        if (CIPConvert.ToDecimal(m_txt_dien_tich_khuon_vien.Text) < CIPConvert.ToDecimal(m_txt_khac.Text))
        {
            m_lbl_mess.Text = "Lỗi: Diện tích khuôn viên nhỏ hơn diện tích sử dụng mục đích khác.";
            m_txt_dien_tich_khuon_vien.Focus();
            return false;
        }

        if (CIPConvert.ToDecimal(m_txt_dien_tich_khuon_vien.Text) < CIPConvert.ToDecimal(m_txt_bo_trong.Text))
        {
            m_lbl_mess.Text = "Lỗi: Diện tích khuôn viên nhỏ hơn diện tích bỏ trống.";
            m_txt_dien_tich_khuon_vien.Focus();
            return false;
        }
        return true;
    }
    private void reset_controls_in_form()
    {
        m_hdf_id.Value = C_STR_NEW_ID_DAT;
        m_txt_dia_chi.Text = "";
        m_txt_ma_tai_san.Text = "";
        m_txt_nam_xd.Text = "";
        m_txt_nguyen_gia.Text = "0";
        m_txt_dien_tich_khuon_vien.Text = "0";
        m_txt_tru_so_lam_viec.Text = "0";
        m_txt_lam_nha_o.Text = "0";
        m_txt_co_so_hdsn.Text = "0";
        m_txt_cho_thue.Text = "0";
        m_txt_bo_trong.Text = "0";
        m_txt_bi_lan_chiem.Text = "0";
        m_txt_khac.Text = "0";
        m_lbl_mess.Text = "";
        m_lbl_thong_bao.Text = "";
        m_e_form_mode = DataEntryFormMode.InsertDataState;
        set_form_mode();
        m_txt_dia_chi.Focus();
    }
    private void update_dat()
    {
        m_e_form_mode = DataEntryFormMode.UpdateDataState;
        m_lbl_mess.Text = "";
        if (!check_validate_data_is_ok()) return;
        if (m_hdf_id.Value == C_STR_NEW_ID_DAT)
        {
            m_lbl_mess.Text = "Bạn chưa chọn dữ liệu để cập nhật";
            return;
        }

        form_2_us_dm_dat();
        m_us_dm_dat.Update();
        Thread.Sleep(2000);
        m_txt_tu_khoa.Text = m_us_dm_dat.strMA_TAI_SAN;
        reset_controls_in_form();
        load_data_2_form();
        m_lbl_mess.Text = "Đã cập nhật dữ liệu đất thành công!";

    }
    private void add_new_dat()
    {
        m_e_form_mode = DataEntryFormMode.InsertDataState;
        m_lbl_mess.Text = "";
        if (!check_validate_data_is_ok()) return;
        if (m_hdf_id.Value != C_STR_NEW_ID_DAT) return;
        form_2_us_dm_dat();
        m_us_dm_dat.Insert();
        Thread.Sleep(2000);
        load_data_2_form();
        m_hdf_id.Value = m_us_dm_dat.dcID.ToString();
        m_txt_tu_khoa.Text = m_us_dm_dat.strMA_TAI_SAN;
        m_lbl_mess.Text = "Đã thêm mới dữ liệu đất thành công!";
        display_panel_tang_giam();
    }
    private void clear_message()
    {
        m_lbl_mess.Text = "";
    }
    private void load_data_to_ly_do()
    {
        WinFormControls.load_data_to_cbo_ly_do_tang_giam(
            WinFormControls.eLOAI_TU_DIEN.LY_DO_TANG_GIAM_TS
            , WinFormControls.eLOAI_TANG_GIAM_TAI_SAN.TANG_TAI_SAN
            , m_cbo_ly_do_thay_doi);
    }
    private void hidden_panel_tang_giam()
    {
        m_mtv_1.SetActiveView(m_view_confirm);
        m_pnl_confirm_tg.Visible = false;
    }
    private void display_panel_tang_giam()
    {
        if (CIPConvert.ToDecimal(m_hdf_id.Value) < 0) return;
        load_data_to_ly_do();
        m_pnl_confirm_tg.Visible = true;
        m_mtv_1.SetActiveView(m_view_confirm);
    }
    private void them_moi_tang_giam()
    {
        US_GD_TANG_GIAM_TAI_SAN v_us_gd_tang_giam_tai_san = new US_GD_TANG_GIAM_TAI_SAN();
        m_us_dm_dat = new US_DM_DAT(CIPConvert.ToDecimal(m_hdf_id.Value));
        v_us_gd_tang_giam_tai_san.datNGAY_DUYET = m_dat_ngay_duyet.SelectedDate;
        v_us_gd_tang_giam_tai_san.datNGAY_TANG_GIAM_TAI_SAN = m_dat_ngay_tang_giam.SelectedDate;
        v_us_gd_tang_giam_tai_san.dcID_LY_DO_TANG_GIAM = CIPConvert.ToDecimal(m_cbo_ly_do_thay_doi.SelectedValue);
        v_us_gd_tang_giam_tai_san.strTANG_GIA_TRI_TAI_SAN_YN = m_rbl_loai.SelectedValue;

        v_us_gd_tang_giam_tai_san.dcID_TAI_SAN = m_us_dm_dat.dcID;
        v_us_gd_tang_giam_tai_san.dcID_LOAI_TAI_SAN = m_us_dm_dat.dcID_LOAI_TAI_SAN;
        v_us_gd_tang_giam_tai_san.strMA_PHIEU = m_txt_ma_phieu.Text;
        v_us_gd_tang_giam_tai_san.dcDIEN_TICH = m_us_dm_dat.dcDT_KHUON_VIEN;
        v_us_gd_tang_giam_tai_san.dcGIA_TRI_NGUYEN_GIA_TANG_GIAM = m_us_dm_dat.dcGT_THEO_SO_KE_TOAN;

        v_us_gd_tang_giam_tai_san.dcID_NGUOI_LAP = Person.get_user_id();
        v_us_gd_tang_giam_tai_san.dcID_NGUOI_DUYET = Person.get_user_id();

        v_us_gd_tang_giam_tai_san.Insert();

        // Phần cập nhật thông tin cho DM
        load_data_2_form();
        m_lbl_mess.Text = "Đã cập nhật thông tin tăng giảm thành công";
    }
    private void clear_panel_data()
    {
        m_txt_ma_phieu.Text = "";
    }
    private void lua_chon_loai_tang_giam()
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
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                m_grv_danh_sach_nha.Columns[0].Visible = Person.Allow2DeleteData();
                load_data_2_form();
                if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.ID_DAT] != null)
                {
                    decimal v_dc_id_dat = CIPConvert.ToDecimal(Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.ID_DAT]);
                    m_us_dm_dat = new US_DM_DAT(v_dc_id_dat);
                    us_dm_dat_2_form();
                }
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
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            add_new_dat();
            
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            update_dat();
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
            Thread.Sleep(2000);
            reset_controls_in_form();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_ddl_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            load_data_don_vi_chu_quan();
            load_data_don_vi_su_dung();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_ddl_don_vi_chu_quan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            load_data_don_vi_su_dung();
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
            Thread.Sleep(2000);
            load_data_2_grid();
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
            m_grv_danh_sach_nha.AllowPaging = false;
            load_data_2_grid();
            WinformReport.export_gridview_2_excel(
                        m_grv_danh_sach_nha
                        , "DS tai san.xls"
                        , 0
                        , 1); 
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
            Thread.Sleep(1000);
            m_grv_danh_sach_nha.PageIndex = e.NewPageIndex;
            load_data_2_grid();
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
            clear_message();
            if (!e.CommandName.Equals(String.Empty) && !e.CommandName.Equals("Page"))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                decimal v_dc_id_dat = CIPConvert.ToDecimal(m_grv_danh_sach_nha.DataKeys[rowIndex].Value);
                m_lbl_mess.Text = "";
                switch (e.CommandName)
                {
                    case "EditComp":
                        m_us_dm_dat = new US_DM_DAT(v_dc_id_dat);
                        m_e_form_mode = DataEntryFormMode.UpdateDataState;
                        load_data_2_form();
                        us_dm_dat_2_form();
                        break;
                    case "DeleteComp":
                        m_us_dm_dat.DeleteByID(v_dc_id_dat);
                        load_data_2_form();
                        m_lbl_mess.Text = "Đã xóa bản ghi thành công";
                        break;
                }
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_tao_tang_giam_Click(object sender, EventArgs e)
    {
        try
        {
            them_moi_tang_giam();
            hidden_panel_tang_giam();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_huy_bo_Click(object sender, EventArgs e)
    {
        try
        {
            clear_panel_data();
            hidden_panel_tang_giam();
            load_data_2_form();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_confirm_Click(object sender, EventArgs e)
    {
        try
        {
            m_mtv_1.SetActiveView(m_view_them_moi_tg);
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
            lua_chon_loai_tang_giam();
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
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_ddl_trang_thai_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void m_ddl_don_vi_su_dung_SelectedIndexChanged(object sender, EventArgs e)
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
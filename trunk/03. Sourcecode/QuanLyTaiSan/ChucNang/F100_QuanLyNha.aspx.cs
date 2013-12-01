using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using IP.Core.IPBusinessService;
using IP.Core.IPException;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;
using IP.Core.IPException;
using WebDS.CDBNames;
using System.Threading;
using IP.Core.WinFormControls;

public partial class ChucNang_F100_QuanLyNha : System.Web.UI.Page {
    #region Public Interfaces
    #endregion

    #region Members
    private US_DM_NHA m_us_dm_nha = new US_DM_NHA();
    private DataEntryFormMode m_e_form_mode = DataEntryFormMode.InsertDataState;
    public const string C_STR_NEW_ID_NHA = "-1";
    #endregion

    #region Private Methods
    private void set_form_mode() {
        switch (m_e_form_mode) {
            case DataEntryFormMode.InsertDataState:
                m_cmd_tao_moi.Visible = true;
                m_cmd_cap_nhat.Visible = false;
                m_lbl_caption.Text = "THÊM MỚI TÀI SẢN NHÀ";
                break;
            case DataEntryFormMode.SelectDataState:
                break;
            case DataEntryFormMode.UpdateDataState:
                m_cmd_tao_moi.Visible = false;
                m_cmd_cap_nhat.Visible = true;
                m_lbl_caption.Text = "CẬP NHẬT THÔNG TIN TÀI SẢN NHÀ";
                break;
            case DataEntryFormMode.ViewDataState:
                break;
            default:
                break;
        }
    }
    private void load_data_2_form() {
        reset_controls_in_form();
        load_data_bo_tinh();
        load_data_don_vi_chu_quan();
        load_data_don_vi_su_dung();
        load_data_dat();
        load_data_trang_thai_nha();
        load_data_don_vi_dau_tu();
        load_data_tinh_trang_nha();
        load_data_to_grid();
        set_form_mode();
        hidden_panel_tang_giam();
    }
    private void load_data_to_grid() {
        // TODO
        m_lbl_thong_tin_nha.Text = "DANH SÁCH NHÀ";
        US_V_DM_NHA v_us_v_dm_nha = new US_V_DM_NHA();
        DS_V_DM_NHA v_ds_v_dm_Nha = new DS_V_DM_NHA();

        v_us_v_dm_nha.FillDatasetLoadDataToGridNha_by_tu_khoa(
            m_txt_tu_khoa.Text.Trim()
            , CONST_QLDB.ID_TAT_CA
            , CONST_QLDB.ID_TAT_CA
            , CONST_QLDB.ID_TAT_CA
            , CONST_QLDB.ID_TAT_CA
            , CONST_QLDB.ID_TAT_CA
            , CONST_QLDB.MA_TAT_CA
            , Person.get_user_name()
            , v_ds_v_dm_Nha);
        string v_str_thong_tin = " (Có " + v_ds_v_dm_Nha.V_DM_NHA.Rows.Count + " bản ghi)";
        m_lbl_thong_tin_nha.Text += v_str_thong_tin;
        m_grv_danh_sach_nha.DataSource = v_ds_v_dm_Nha.V_DM_NHA;
        m_grv_danh_sach_nha.DataBind();
    }
    private bool IsHavingDonViChuQuanOfNha(US_DM_NHA ip_us_dm_nha) {
        return (m_us_dm_nha.dcID_DON_VI_CHU_QUAN != 0);
    }
    private void load_data_bo_tinh() {
        WinFormControls.load_data_to_cbo_bo_tinh(
            WinFormControls.eTAT_CA.NO
            , m_ddl_bo_tinh);

        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        if (!this.IsHavingDonViChuQuanOfNha(m_us_dm_nha)) return;
        if (v_us_dm_don_vi.InitUSWithIDIsOK(m_us_dm_nha.dcID_DON_VI_CHU_QUAN) == false) {
            throw new Exception(
                "Không khởi tạo được đơn vị với ID là:"
                + CIPConvert.ToStr(m_us_dm_nha.dcID_DON_VI_CHU_QUAN));
        }
        m_ddl_bo_tinh.SelectedValue = v_us_dm_don_vi.dcID_DON_VI_CAP_TREN.ToString();

    }
    private void load_data_don_vi_chu_quan() {
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(m_ddl_bo_tinh.SelectedValue
            , WinFormControls.eTAT_CA.NO
            , m_ddl_don_vi_chu_quan);

        if (m_us_dm_nha.dcID_DON_VI_CHU_QUAN != 0) {
            m_ddl_don_vi_chu_quan.SelectedValue = m_us_dm_nha.dcID_DON_VI_CHU_QUAN.ToString();
        }
    }
    private void load_data_don_vi_su_dung() {
        WinFormControls.load_data_to_cbo_don_vi_su_dung(m_ddl_don_vi_chu_quan.SelectedValue
            , m_ddl_bo_tinh.SelectedValue
            , WinFormControls.eTAT_CA.NO
            , m_ddl_don_vi_su_dung);

        if (m_us_dm_nha.dcID_DON_VI_SU_DUNG != 0) {
            m_ddl_don_vi_su_dung.SelectedValue = m_us_dm_nha.dcID_DON_VI_SU_DUNG.ToString();
        }
    }
    private void load_data_don_vi_dau_tu() {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi);
        m_ddl_don_vi_dau_tu.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_ddl_don_vi_dau_tu.DataTextField = DM_DON_VI.TEN_DON_VI;
        m_ddl_don_vi_dau_tu.DataValueField = DM_DON_VI.ID;
        m_ddl_don_vi_dau_tu.DataBind();
    }
    private void load_data_dat() {
        WinFormControls.load_data_to_cbo_dia_chi(
            CIPConvert.ToDecimal(m_ddl_bo_tinh.SelectedValue)
            , CIPConvert.ToDecimal(m_ddl_don_vi_chu_quan.SelectedValue)
            , CIPConvert.ToDecimal(m_ddl_don_vi_su_dung.SelectedValue)
            , CONST_QLDB.ID_TAT_CA
            , WinFormControls.eTAT_CA.NO,
            m_ddl_thuoc_khu_dat);
    }
    private void load_data_tinh_trang_nha() {
        WinFormControls.load_data_to_cbo_tu_dien(
            WinFormControls.eLOAI_TU_DIEN.TINH_TRANG_TAI_SAN
            , WinFormControls.eTAT_CA.NO
            , m_ddl_tinh_trang_nha);
    }
    private bool check_validate_data_is_ok() 
    {
        if (m_ddl_thuoc_khu_dat.SelectedValue == "") {
            m_lbl_mess.Text = "Lỗi: Bạn chưa chọn khu đất!";
            m_txt_ten_tai_san.Focus();
            return false;
        }

        if (m_e_form_mode == DataEntryFormMode.InsertDataState) {
            if (!m_us_dm_nha.check_ma_tai_san_is_valid(m_txt_ma_tai_san.Text)) {
                m_lbl_mess.Text = "Lỗi: Mã tài sản nhà này đã tồn tại!";
                m_txt_ma_tai_san.Focus();
                return false;
            }
        }
        if (m_e_form_mode == DataEntryFormMode.UpdateDataState) {
            m_us_dm_nha = new US_DM_NHA(CIPConvert.ToDecimal(m_hdf_id.Value));

            if (m_us_dm_nha.strMA_TAI_SAN != m_txt_ma_tai_san.Text) {
                if (!m_us_dm_nha.check_ma_tai_san_is_valid(m_txt_ma_tai_san.Text)) {
                    m_lbl_mess.Text = "Lỗi: Mã tài sản nhà này đã tồn tại!";
                    m_txt_ma_tai_san.Focus();
                    return false;
                }
            }
        }

        if (!CValidateTextBox.IsValid(m_txt_ma_tai_san, DataType.StringType, allowNull.NO)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_ten_tai_san, DataType.StringType, allowNull.NO)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_cap_hang, DataType.NumberType, allowNull.YES)) 
        {
            m_lbl_mess.Text = "Lỗi: Cấp hạng không đúng định dạng số";
            m_txt_cap_hang.Focus();
            return false; 
        }
        if (!CValidateTextBox.IsValid(m_txt_nam_xd, DataType.NumberType, allowNull.YES)) 
        {
            m_lbl_mess.Text = "Lỗi: Năm xây dựng không đúng định dạng số";
            m_txt_nam_xd.Focus();
            return false; 
        }
        if (!CValidateTextBox.IsValid(m_txt_ngay_su_dung, DataType.NumberType, allowNull.YES)) 
        {
            m_lbl_mess.Text = "Lỗi: Năm sử dụng không đúng định dạng số";
            m_txt_ngay_su_dung.Focus();
            return false; 
        }
        if (!CValidateTextBox.IsValid(m_txt_nguyen_gia, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_nguyen_gia_nguon_khac, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_gia_tri_con_lai, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_so_tang, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_dien_tich_xay_dung, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_tong_dien_tich_xay_dung, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_tru_so_lam_viec, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_co_so_hdsn, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_lam_nha_o, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_cho_thue, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_bo_trong, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_bi_lan_chiem, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_khac, DataType.NumberType, allowNull.YES)) { return false; }

        if ((CIPConvert.ToDecimal(m_txt_nguyen_gia.Text) + CIPConvert.ToDecimal(m_txt_nguyen_gia_nguon_khac.Text))
            < CIPConvert.ToDecimal(m_txt_gia_tri_con_lai.Text))
        {
            m_lbl_mess.Text = "Lỗi: Giá trị còn lại lớn hơn tổng nguyên giá!";
            m_txt_nguyen_gia.Focus();
            return false;
        }
        if ((m_hdf_id.Value == C_STR_NEW_ID_NHA) && (m_e_form_mode == DataEntryFormMode.UpdateDataState))
        {
            m_lbl_mess.Text = "Lỗi: Bạn chưa chọn dữ liệu để cập nhật!";
            m_txt_ten_tai_san.Focus();
            return false;
        }

        decimal v_dc_dt_san_xd = CIPConvert.ToDecimal(m_txt_tong_dien_tich_xay_dung.Text);
        decimal v_dc_dt_xd = CIPConvert.ToDecimal(m_txt_dien_tich_xay_dung.Text);
        if (v_dc_dt_san_xd < v_dc_dt_xd)
        {
            m_lbl_mess.Text = "Lỗi: Tổng diện tích sàn xây dựng phải lớn hơn hoặc bằng diện tích xây dựng";
            m_txt_dien_tich_xay_dung.Focus();
            return false;
        }

        decimal v_dc_nam_xd = CIPConvert.ToDecimal(m_txt_nam_xd.Text);
        decimal v_dc_nam_su_dung = CIPConvert.ToDecimal(m_txt_ngay_su_dung.Text);
        if (v_dc_nam_su_dung < v_dc_nam_xd)
        {
            m_lbl_mess.Text = "Lỗi: Năm sử dụng phải lớn hơn hoặc bằng năm xây dựng";
            m_txt_nam_xd.Focus();
            return false;
        }
        return true;
    }
    private void load_data_trang_thai_nha() {
        WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_NHA
            , WinFormControls.eTAT_CA.NO
            , m_ddl_trang_thai_nha);
        m_ddl_trang_thai_nha.SelectedValue = TRANG_THAI_NHA.DANG_SU_DUNG;
    }
    private void us_nha_2_form() {
        m_hdf_id.Value = m_us_dm_nha.dcID.ToString();
        m_ddl_don_vi_chu_quan.SelectedValue = m_us_dm_nha.dcID_DON_VI_CHU_QUAN.ToString();
        m_ddl_don_vi_su_dung.SelectedValue = m_us_dm_nha.dcID_DON_VI_SU_DUNG.ToString();
        m_ddl_don_vi_dau_tu.SelectedValue = m_us_dm_nha.dcID_DON_VI_DAU_TU.ToString();
        m_ddl_thuoc_khu_dat.SelectedValue = m_us_dm_nha.dcID_DAT.ToString();
        m_ddl_tinh_trang_nha.SelectedValue = m_us_dm_nha.dcID_TINH_TRANG.ToString();
        m_txt_ten_tai_san.Text = m_us_dm_nha.strTEN_TAI_SAN;
        m_txt_ma_tai_san.Text = m_us_dm_nha.strMA_TAI_SAN;
        m_txt_cap_hang.Text = m_us_dm_nha.dcCAP_HANG.ToString();
        m_txt_nam_xd.Text = m_us_dm_nha.dcNAM_XAY_DUNG.ToString();
        m_txt_ngay_su_dung.Text = m_us_dm_nha.dcNGAY_THANG_NAM_SU_DUNG.ToString();
        m_txt_nguyen_gia.Text = m_us_dm_nha.dcNGUON_NS.ToString("#,##0");
        m_txt_nguyen_gia_nguon_khac.Text = m_us_dm_nha.dcNGUON_KHAC.ToString("#,##0");
        m_txt_gia_tri_con_lai.Text = m_us_dm_nha.dcGIA_TRI_CON_LAI.ToString("#,##0");
        m_txt_so_tang.Text = m_us_dm_nha.dcSO_TANG.ToString();
        m_txt_dien_tich_xay_dung.Text = m_us_dm_nha.dcDT_XAY_DUNG.ToString("#,##0");
        m_txt_tong_dien_tich_xay_dung.Text = m_us_dm_nha.dcTONG_DT_SAN_XD.ToString("#,##0");
        m_txt_tru_so_lam_viec.Text = m_us_dm_nha.dcTRU_SO_LAM_VIEC.ToString("#,##0");
        m_txt_co_so_hdsn.Text = m_us_dm_nha.dcCO_SO_HDSN.ToString("#,##0");
        m_txt_lam_nha_o.Text = m_us_dm_nha.dcLAM_NHA_O.ToString("#,##0");
        m_txt_cho_thue.Text = m_us_dm_nha.dcCHO_THUE.ToString("#,##0");
        m_txt_bo_trong.Text = m_us_dm_nha.dcBO_TRONG.ToString("#,##0");
        m_txt_bi_lan_chiem.Text = m_us_dm_nha.dcBI_LAN_CHIEM.ToString("#,##0");
        m_txt_khac.Text = m_us_dm_nha.dcKHAC.ToString("#,##0");
        m_ddl_trang_thai_nha.SelectedValue = m_us_dm_nha.dcID_TRANG_THAI.ToString();
        m_txt_ten_tai_san.Focus();
    }
    private void form_2_us_nha() {
        if (!m_hdf_id.Value.Equals(C_STR_NEW_ID_NHA)) {
            m_us_dm_nha.dcID = CIPConvert.ToDecimal(m_hdf_id.Value);
        }
        m_us_dm_nha.strTEN_TAI_SAN = m_txt_ten_tai_san.Text;
        m_us_dm_nha.strMA_TAI_SAN = m_txt_ma_tai_san.Text;
        m_us_dm_nha.dcID_LOAI_TAI_SAN = ID_LOAI_TAI_SAN.NHA;
        if (m_txt_cap_hang.Text.Length == 0) {
            m_us_dm_nha.SetCAP_HANGNull();
        }
        else {
            m_us_dm_nha.dcCAP_HANG = CIPConvert.ToDecimal(m_txt_cap_hang.Text);
        }
        if (m_txt_nam_xd.Text.Length == 0) {
            m_us_dm_nha.SetNAM_XAY_DUNGNull();
        }
        else {
            m_us_dm_nha.dcNAM_XAY_DUNG = CIPConvert.ToDecimal(m_txt_nam_xd.Text);
        }
        if (m_txt_ngay_su_dung.Text.Length == 0) {
            m_us_dm_nha.SetNGAY_THANG_NAM_SU_DUNGNull();
        }
        else {
            m_us_dm_nha.dcNGAY_THANG_NAM_SU_DUNG = CIPConvert.ToDecimal(m_txt_ngay_su_dung.Text);
        }
        if (m_txt_nguyen_gia.Text.Length == 0) {
            m_us_dm_nha.SetNGUON_NSNull();
        }
        else {
            m_us_dm_nha.dcNGUON_NS = CIPConvert.ToDecimal(m_txt_nguyen_gia.Text);
        }
        if (m_txt_nguyen_gia_nguon_khac.Text.Length == 0) {
            m_us_dm_nha.SetNGUON_KHACNull();
        }
        else {
            m_us_dm_nha.dcNGUON_KHAC = CIPConvert.ToDecimal(m_txt_nguyen_gia_nguon_khac.Text);
        }
        if (m_txt_gia_tri_con_lai.Text.Length == 0) {
            m_us_dm_nha.SetGIA_TRI_CON_LAINull();
        }
        else {
            m_us_dm_nha.dcGIA_TRI_CON_LAI = CIPConvert.ToDecimal(m_txt_gia_tri_con_lai.Text);
        }
        if (m_txt_so_tang.Text.Length == 0) {
            m_us_dm_nha.SetSO_TANGNull();
        }
        else {
            m_us_dm_nha.dcSO_TANG = CIPConvert.ToDecimal(m_txt_so_tang.Text);
        }
        if (m_txt_dien_tich_xay_dung.Text.Length == 0) {
            m_us_dm_nha.SetDT_XAY_DUNGNull();
        }
        else {
            m_us_dm_nha.dcDT_XAY_DUNG = CIPConvert.ToDecimal(m_txt_dien_tich_xay_dung.Text);
        }
        if (m_txt_tong_dien_tich_xay_dung.Text.Length == 0) {
            m_us_dm_nha.SetTONG_DT_SAN_XDNull();
        }
        else {
            m_us_dm_nha.dcTONG_DT_SAN_XD = CIPConvert.ToDecimal(m_txt_tong_dien_tich_xay_dung.Text);
        }
        if (m_txt_tru_so_lam_viec.Text.Length == 0) {
            m_us_dm_nha.SetTRU_SO_LAM_VIECNull();
        }
        else {
            m_us_dm_nha.dcTRU_SO_LAM_VIEC = CIPConvert.ToDecimal(m_txt_tru_so_lam_viec.Text);
        }

        if (m_txt_co_so_hdsn.Text.Length == 0) {
            m_us_dm_nha.SetCO_SO_HDSNNull();
        }
        else {
            m_us_dm_nha.dcCO_SO_HDSN = CIPConvert.ToDecimal(m_txt_co_so_hdsn.Text);
        }

        if (m_txt_lam_nha_o.Text.Length == 0) {
            m_us_dm_nha.SetLAM_NHA_ONull();
        }
        else {
            m_us_dm_nha.dcLAM_NHA_O = CIPConvert.ToDecimal(m_txt_lam_nha_o.Text);
        }
        if (m_txt_cho_thue.Text.Length == 0) {
            m_us_dm_nha.SetCHO_THUENull();
        }
        else {
            m_us_dm_nha.dcCHO_THUE = CIPConvert.ToDecimal(m_txt_cho_thue.Text);
        }

        if (m_txt_bo_trong.Text.Length == 0) {
            m_us_dm_nha.SetBO_TRONGNull();
        }
        else {
            m_us_dm_nha.dcBO_TRONG = CIPConvert.ToDecimal(m_txt_bo_trong.Text);
        }


        if (m_txt_bi_lan_chiem.Text.Length == 0) {
            m_us_dm_nha.SetBI_LAN_CHIEMNull();
        }
        else {
            m_us_dm_nha.dcBI_LAN_CHIEM = CIPConvert.ToDecimal(m_txt_bi_lan_chiem.Text);
        }
        if (m_txt_khac.Text.Length == 0) {
            m_us_dm_nha.SetKHACNull();
        }
        else {
            m_us_dm_nha.dcKHAC = CIPConvert.ToDecimal(m_txt_khac.Text);
        }
        m_us_dm_nha.dcID_NGUOI_LAP = CIPConvert.ToDecimal(Person.get_user_id());
        m_us_dm_nha.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_ddl_trang_thai_nha.SelectedValue);
        m_us_dm_nha.dcID_DAT = CIPConvert.ToDecimal(m_ddl_thuoc_khu_dat.SelectedValue);

        US_DM_DAT v_us_dm_dat = new US_DM_DAT(m_us_dm_nha.dcID_DAT);
        m_us_dm_nha.dcID_DON_VI_SU_DUNG = v_us_dm_dat.dcID_DON_VI_SU_DUNG;
        m_us_dm_nha.dcID_DON_VI_CHU_QUAN = v_us_dm_dat.dcID_DON_VI_CHU_QUAN;
        m_us_dm_nha.dcID_DON_VI_DAU_TU = CIPConvert.ToDecimal(m_ddl_don_vi_dau_tu.SelectedValue);
        m_us_dm_nha.dcID_TINH_TRANG = CIPConvert.ToDecimal(m_ddl_tinh_trang_nha.SelectedValue);
        m_us_dm_nha.datNGAY_CAP_NHAT_CUOI = DateTime.Now;

        m_us_dm_nha.dcID_NGUOI_DUYET = Person.get_user_id();
        m_us_dm_nha.dcID_NGUOI_LAP = Person.get_user_id();
    }
    private void reset_controls_in_form() {
        m_hdf_id.Value = C_STR_NEW_ID_NHA;
        m_txt_ten_tai_san.Text = "";
        m_txt_cap_hang.Text = "";
        m_txt_nam_xd.Text = "";
        m_txt_ngay_su_dung.Text = "";
        m_txt_nguyen_gia.Text = "0";
        m_txt_nguyen_gia_nguon_khac.Text = "0";
        m_txt_gia_tri_con_lai.Text = "0";
        m_txt_so_tang.Text = "0";
        m_txt_dien_tich_xay_dung.Text = "0";
        m_txt_tong_dien_tich_xay_dung.Text = "0";
        m_txt_tru_so_lam_viec.Text = "0";
        m_txt_co_so_hdsn.Text = "0";
        m_txt_lam_nha_o.Text = "0";
        m_txt_cho_thue.Text = "0";
        m_txt_bo_trong.Text = "0";
        m_txt_bi_lan_chiem.Text = "0";
        m_txt_khac.Text = "0";
        m_txt_ma_tai_san.Text = "";
        m_lbl_mess.Text = "";
        m_lbl_thong_bao.Text = "";
        m_e_form_mode = DataEntryFormMode.InsertDataState;
        set_form_mode();
        m_txt_ten_tai_san.Focus();
    }
    private void update_nha() {
        m_lbl_mess.Text = "";
        m_e_form_mode = DataEntryFormMode.UpdateDataState;
        if (!check_validate_data_is_ok()) return;
        form_2_us_nha();
        Thread.Sleep(2000);
        m_us_dm_nha.Update();
        m_txt_tu_khoa.Text = m_txt_ma_tai_san.Text;
        reset_controls_in_form();
        load_data_2_form();
        m_lbl_mess.Text = "Đã cập nhật dữ liệu nhà thành công!";
    }
    private void insert_nha() {
        m_lbl_mess.Text = "";
        m_e_form_mode = DataEntryFormMode.InsertDataState;
        if (!check_validate_data_is_ok()) return;
        if (m_hdf_id.Value == C_STR_NEW_ID_NHA) {
            Thread.Sleep(2000);
            form_2_us_nha();
            m_us_dm_nha.Insert();
            m_txt_tu_khoa.Text = m_txt_ma_tai_san.Text; 
            load_data_2_form();
            m_hdf_id.Value = m_us_dm_nha.dcID.ToString();
            m_lbl_mess.Text = "Đã thêm mới dữ liệu nhà thành công!";
        }
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
        m_us_dm_nha = new US_DM_NHA(CIPConvert.ToDecimal(m_hdf_id.Value));
        v_us_gd_tang_giam_tai_san.datNGAY_DUYET = m_dat_ngay_duyet.SelectedDate;
        v_us_gd_tang_giam_tai_san.datNGAY_TANG_GIAM_TAI_SAN = m_dat_ngay_tang_giam.SelectedDate;
        v_us_gd_tang_giam_tai_san.dcID_LY_DO_TANG_GIAM = CIPConvert.ToDecimal(m_cbo_ly_do_thay_doi.SelectedValue);
        v_us_gd_tang_giam_tai_san.strTANG_GIA_TRI_TAI_SAN_YN = m_rbl_loai.SelectedValue;

        v_us_gd_tang_giam_tai_san.dcID_TAI_SAN = m_us_dm_nha.dcID;
        v_us_gd_tang_giam_tai_san.dcID_LOAI_TAI_SAN = m_us_dm_nha.dcID_LOAI_TAI_SAN;
        v_us_gd_tang_giam_tai_san.strMA_PHIEU = m_txt_ma_phieu.Text;
        v_us_gd_tang_giam_tai_san.dcDIEN_TICH = m_us_dm_nha.dcDT_XAY_DUNG;
        v_us_gd_tang_giam_tai_san.dcGIA_TRI_NGUYEN_GIA_TANG_GIAM = m_us_dm_nha.dcNGUON_NS + m_us_dm_nha.dcNGUON_KHAC;

        v_us_gd_tang_giam_tai_san.dcID_NGUOI_LAP = Person.get_user_id();
        v_us_gd_tang_giam_tai_san.dcID_NGUOI_DUYET = Person.get_user_id();

        v_us_gd_tang_giam_tai_san.Insert();

        // Phần cập nhật thông tin cho DM
        load_data_2_form();
        m_lbl_mess.Text = "Đã cập thông tin tăng giảm thành công";
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
    private void export_gridview_2_excel() {
        //Đoạn mã nguồn này để gridview không phân trang. 
        // Vì thế, khi xuất Excel sẽ xuất ra hết dữ liệu.
        m_grv_danh_sach_nha.AllowPaging = false;
        load_data_to_grid();
        int v_dc_delete_column = 0;
        int v_dc_update_column = 1;
        WinformReport.export_gridview_2_excel(
            m_grv_danh_sach_nha
            , "DS nha.xls"
            , v_dc_delete_column
            , v_dc_update_column);
    }
    private void clear_message()
    {
        m_lbl_mess.Text = "";
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e) {
        try {
            if (!IsPostBack) {
                m_grv_danh_sach_nha.Columns[0].Visible = Person.Allow2DeleteData();
                load_data_2_form();
                //Code này là chức năng liên quan đến from F1000
                if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.ID_NHA] != null) {
                    decimal v_dc_id_nha = CIPConvert.ToDecimal(Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.ID_NHA]);
                    m_us_dm_nha = new US_DM_NHA(v_dc_id_nha);
                    us_nha_2_form();
                }
            }
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    public override void VerifyRenderingInServerForm(Control control) {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e) {
        try {
            clear_message();
            insert_nha();
            display_panel_tang_giam();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_cap_nhat_Click(object sender, EventArgs e) {
        try {
            clear_message();
            update_nha();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_xoa_trang_Click(object sender, EventArgs e) {
        try {
            clear_message();
            reset_controls_in_form();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e) {
        try {
            Thread.Sleep(2000);
            load_data_to_grid();
            m_txt_tu_khoa.Focus();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e) {
        try {
            clear_message();
            export_gridview_2_excel();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_danh_sach_nha_RowCommand(object sender, GridViewCommandEventArgs e) {
        try {
            clear_message();
            if (!e.CommandName.Equals(String.Empty) && !e.CommandName.Equals("Page")) 
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                decimal v_dc_id_nha = CIPConvert.ToDecimal(m_grv_danh_sach_nha.DataKeys[rowIndex].Value);
                m_lbl_mess.Text = "";
                switch (e.CommandName) {
                    case "EditComp":
                        m_us_dm_nha = new US_DM_NHA(v_dc_id_nha);
                        m_e_form_mode = DataEntryFormMode.UpdateDataState;
                        load_data_2_form();
                        us_nha_2_form();
                        break;
                    case "DeleteComp":
                        m_us_dm_nha.DeleteByID(v_dc_id_nha);
                        load_data_2_form();
                        m_lbl_mess.Text = "Đã xóa bản ghi thành công";
                        break;
                }
            }
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }

    }
    protected void m_grv_danh_sach_nha_PageIndexChanging(object sender, GridViewPageEventArgs e) {
        try {
            clear_message();
            Thread.Sleep(1000);
            m_grv_danh_sach_nha.PageIndex = e.NewPageIndex;
            load_data_to_grid();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_ddl_don_vi_chu_quan_SelectedIndexChanged(object sender, EventArgs e) {
        try {
            clear_message();
            load_data_don_vi_su_dung();
            load_data_dat();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_ddl_bo_tinh_SelectedIndexChanged(object sender, EventArgs e) {
        try {
            clear_message();
            load_data_don_vi_chu_quan();
            load_data_don_vi_su_dung();
            load_data_dat();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_ddl_don_vi_su_dung_SelectedIndexChanged(object sender, EventArgs e) {
        try {
            clear_message();
            load_data_dat();
        }
        catch (Exception v_e) {
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
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_ddl_trang_thai_nha_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void m_ddl_thuoc_khu_dat_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void m_ddl_don_vi_dau_tu_SelectedIndexChanged(object sender, EventArgs e)
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
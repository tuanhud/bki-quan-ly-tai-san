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

    #region Public Interfaces
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
    }

    // Load dữ liệu vào combo bộ tỉnh
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

    // Load dữ liệu vào combo đơn vị chủ quản
    private void load_data_don_vi_chu_quan()
    {
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(m_ddl_bo_tinh.SelectedValue, WinFormControls.eTAT_CA.NO, m_ddl_don_vi_chu_quan);

        if (m_us_dm_dat.dcID_DON_VI_CHU_QUAN != 0)
        {
            m_ddl_don_vi_chu_quan.SelectedValue = m_us_dm_dat.dcID_DON_VI_CHU_QUAN.ToString();
        }
    }

    // Load dữ liệu vào combo đơn vị sử dụng
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

    // Load dữ liệu vào combo trạng thái
    private void load_data_trang_thai()
    {
        WinFormControls.load_data_to_cbo_tu_dien(
            WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_DAT
            , WinFormControls.eTAT_CA.NO
            , m_ddl_trang_thai);
    }

    // Load dữ liệu vào combo tình trạng đất
    private void load_data_tinh_trang_dat() {
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
        try
        {
            m_hdf_id.Value = m_us_dm_dat.dcID.ToString();
            m_ddl_don_vi_chu_quan.SelectedValue = m_us_dm_dat.dcID_DON_VI_CHU_QUAN.ToString();
            m_ddl_don_vi_su_dung.SelectedValue = m_us_dm_dat.dcID_DON_VI_SU_DUNG.ToString();
            m_ddl_trang_thai.SelectedValue = m_us_dm_dat.dcID_TRANG_THAI.ToString();
            m_txt_dia_chi.Text = m_us_dm_dat.strDIA_CHI;
            m_txt_ma_tai_san.Text = m_us_dm_dat.strMA_TAI_SAN;
            m_txt_nam_xd.Text = m_us_dm_dat.dcSO_NAM_DA_SU_DUNG.ToString();
            m_txt_nguyen_gia.Text = m_us_dm_dat.dcGT_THEO_SO_KE_TOAN.ToString("#,##0.00");
            m_txt_dien_tich_khuon_vien.Text = m_us_dm_dat.dcDT_KHUON_VIEN.ToString("#,##0.00");
            m_txt_tru_so_lam_viec.Text = m_us_dm_dat.dcDT_TRU_SO_LAM_VIEC.ToString("#,##0.00");
            m_txt_lam_nha_o.Text = m_us_dm_dat.dcDT_LAM_NHA_O.ToString("#,##0.00");
            m_txt_co_so_hdsn.Text = m_us_dm_dat.dcDT_CO_SO_HOAT_DONG_SU_NGHIEP.ToString("#,##0.00");
            m_txt_cho_thue.Text = m_us_dm_dat.dcDT_CHO_THUE.ToString("#,##0.00");
            m_txt_bo_trong.Text = m_us_dm_dat.dcDT_BO_TRONG.ToString("#,##0.00");
            m_txt_bi_lan_chiem.Text = m_us_dm_dat.dcDT_BI_LAN_CHIEM.ToString("#,##0.00");
            m_txt_khac.Text = m_us_dm_dat.dcDT_SU_DUNG_MUC_DICH_KHAC.ToString("#,##0.00");
            m_ddl_tinh_trang_dat.SelectedValue = m_us_dm_dat.dcID_TINH_TRANG.ToString();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
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
        if (m_txt_nam_xd.Text.Length == 0) {
            m_us_dm_dat.SetSO_NAM_DA_SU_DUNGNull();
        }
        else {
            m_us_dm_dat.dcSO_NAM_DA_SU_DUNG = CIPConvert.ToDecimal(m_txt_nam_xd.Text);
        }
        if (m_txt_nguyen_gia.Text.Length == 0) {
            m_us_dm_dat.SetGT_THEO_SO_KE_TOANNull();
        }
        else {
            m_us_dm_dat.dcGT_THEO_SO_KE_TOAN = CIPConvert.ToDecimal(m_txt_nguyen_gia.Text);
        }
        if (m_txt_dien_tich_khuon_vien.Text.Length == 0) {
        
            m_us_dm_dat.SetDT_KHUON_VIENNull();
        }
        else {
            m_us_dm_dat.dcDT_KHUON_VIEN = CIPConvert.ToDecimal(m_txt_dien_tich_khuon_vien.Text);
        }
        if (m_txt_tru_so_lam_viec.Text.Length == 0) {
            m_us_dm_dat.SetDT_TRU_SO_LAM_VIECNull();
        }
        else {
            m_us_dm_dat.dcDT_TRU_SO_LAM_VIEC = CIPConvert.ToDecimal(m_txt_tru_so_lam_viec.Text);
        }
        if (m_txt_lam_nha_o.Text.Length == 0) {
            m_us_dm_dat.SetDT_LAM_NHA_ONull();
        }
        else {
            m_us_dm_dat.dcDT_LAM_NHA_O = CIPConvert.ToDecimal(m_txt_lam_nha_o.Text);
        }
        if (m_txt_co_so_hdsn.Text.Length == 0) {
            m_us_dm_dat.SetDT_CO_SO_HOAT_DONG_SU_NGHIEPNull();
        }
        else {
            m_us_dm_dat.dcDT_CO_SO_HOAT_DONG_SU_NGHIEP = CIPConvert.ToDecimal(m_txt_co_so_hdsn.Text);
        }
        if (m_txt_cho_thue.Text.Length == 0) {
            m_us_dm_dat.SetDT_CHO_THUENull();
        }
        else {
            m_us_dm_dat.dcDT_CHO_THUE = CIPConvert.ToDecimal(m_txt_cho_thue.Text);
        }
        if (m_txt_bo_trong.Text.Length == 0) {
            m_us_dm_dat.SetDT_BO_TRONGNull();
        }
        else {
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
                break;
            case DataEntryFormMode.SelectDataState:
                break;
            case DataEntryFormMode.UpdateDataState:
                m_cmd_tao_moi.Visible = false;
                m_cmd_cap_nhat.Visible = true;
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
            return false;
        }
        if (m_e_form_mode == DataEntryFormMode.InsertDataState)
        {
            if (!m_us_dm_dat.check_ma_tai_san_is_valid(m_txt_ma_tai_san.Text))
            {
                m_lbl_mess.Text = "Không thể cập nhật do ban nhập Mã tài sản đã tồn tại!";
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
                    m_lbl_mess.Text = "Không thể cập nhật do mã tài sản này đã tồn tại!";
                    return false;
                }
            }
        }
        if (!CValidateTextBox.IsValid(m_txt_nam_xd, DataType.NumberType, allowNull.YES)) {return false;}
        if (!CValidateTextBox.IsValid(m_txt_nguyen_gia, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_dien_tich_khuon_vien, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_tru_so_lam_viec, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_lam_nha_o, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_co_so_hdsn, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_cho_thue, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_bo_trong, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_bi_lan_chiem, DataType.NumberType, allowNull.YES)) { return false; }
        if (!CValidateTextBox.IsValid(m_txt_khac, DataType.NumberType, allowNull.YES)) { return false; }

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
    }

    private void update_dat() {
        m_e_form_mode = DataEntryFormMode.UpdateDataState;
        m_lbl_mess.Text = "";
        if (!check_validate_data_is_ok()) return;
        if (m_hdf_id.Value == C_STR_NEW_ID_DAT) {
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
        m_txt_tu_khoa.Text = m_us_dm_dat.strMA_TAI_SAN;
        reset_controls_in_form();
        
        load_data_2_form();
        m_lbl_mess.Text = "Đã thêm mới dữ liệu đất thành công!";
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
            // vì có phân trang, nên nếu muốn xuất all dữ liệu trên lưới (tất cả các trang) thì thê 2 dòng sau:
            m_grv_danh_sach_nha.AllowPaging = false;
            load_data_2_grid();  // đây là hàm load lại dữ liệu lên lưới
            // còn nếu chỉ muốn xuất dữ liệu ở Page hiện tại thì không cần 2 dòng trên
            WinformReport.export_gridview_2_excel(
                        m_grv_danh_sach_nha
                        , "DS tai san.xls"
                        , 0
                        , 1); // 0 và 1 là số thứ tự 2 cột: Sửa, Xóa
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
            if (!e.CommandName.Equals(String.Empty))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                decimal v_dc_id_dat = CIPConvert.ToDecimal(m_grv_danh_sach_nha.DataKeys[rowIndex].Value);
                m_lbl_mess.Text ="";
                switch (e.CommandName)
                {
                    case "EditComp":
                        Thread.Sleep(2000);
                        m_us_dm_dat = new US_DM_DAT(v_dc_id_dat);
                        m_e_form_mode = DataEntryFormMode.UpdateDataState;
                        load_data_2_form();
                        us_dm_dat_2_form();
                        break;
                    case "DeleteComp":
                        Thread.Sleep(2000);
                        m_us_dm_dat.DeleteByID(v_dc_id_dat);
                        load_data_2_form();
                        break;
                }
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
}
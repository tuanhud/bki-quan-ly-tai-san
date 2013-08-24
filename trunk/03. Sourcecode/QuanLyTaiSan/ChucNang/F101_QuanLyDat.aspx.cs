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

public partial class ChucNang_F101_QuanLyDat : System.Web.UI.Page
{
    #region Members
    private US_DM_DAT m_us_dm_dat = new US_DM_DAT();
    private DataEntryFormMode m_e_form_mode = DataEntryFormMode.InsertDataState;
    #endregion

    #region Public Interfaces
    #endregion

    #region Private Methods
    private void load_form_data()
    {
        load_data_bo_tinh();
        load_data_don_vi_chu_quan(m_ddl_bo_tinh.SelectedValue);
        load_data_don_vi_su_dung(m_ddl_don_vi_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
        load_data_trang_thai();
        load_data_grid(m_txt_tu_khoa.Text.Trim());
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
    private void load_data_don_vi_chu_quan(string ip_str_id_bo_tinh)
    {
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(ip_str_id_bo_tinh, WinFormControls.eTAT_CA.NO, m_ddl_don_vi_chu_quan);

        if (m_us_dm_dat.dcID_DON_VI_CHU_QUAN != 0)
        {
            m_ddl_don_vi_chu_quan.SelectedValue = m_us_dm_dat.dcID_DON_VI_CHU_QUAN.ToString();
        }
    }

    // Load dữ liệu vào combo đơn vị sử dụng
    private void load_data_don_vi_su_dung(string ip_str_id_don_vi_chu_quan, string ip_str_id_bo_tinh)
    {
        WinFormControls.load_data_to_cbo_don_vi_su_dung(ip_str_id_don_vi_chu_quan
            , ip_str_id_bo_tinh
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
        WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_DAT
            , WinFormControls.eTAT_CA.NO
            , m_ddl_trang_thai);
    }

    private void load_data_grid(string ip_str_tu_khoa)
    {
        US_V_DM_DAT v_us_v_dm_dat = new US_V_DM_DAT();
        DS_V_DM_DAT v_ds_v_dm_dat = new DS_V_DM_DAT();

        v_us_v_dm_dat.FillDataSetByKeyWord(
            CONST_QLDB.ID_TAT_CA.ToString()
            , CONST_QLDB.ID_TAT_CA.ToString()
            , CONST_QLDB.ID_TAT_CA.ToString()
            , CONST_QLDB.ID_TAT_CA.ToString()
            , Person.get_user_name()
            , CONST_QLDB.ID_TAT_CA.ToString()
            , ip_str_tu_khoa
            , v_ds_v_dm_dat
            );

        m_grv_danh_sach_nha.DataSource = v_ds_v_dm_dat.V_DM_DAT;
        m_grv_danh_sach_nha.DataBind();
    }

    private void load_data_from_us()
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
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    private void fill_form_data_to_us()
    {
        if (!m_hdf_id.Value.Equals("-1"))
        {
            m_us_dm_dat.dcID = CIPConvert.ToDecimal(m_hdf_id.Value);
        }
        m_us_dm_dat.dcID_DON_VI_CHU_QUAN = CIPConvert.ToDecimal(m_ddl_don_vi_chu_quan.SelectedValue);
        m_us_dm_dat.dcID_DON_VI_SU_DUNG = CIPConvert.ToDecimal(m_ddl_don_vi_su_dung.SelectedValue);
        m_us_dm_dat.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_ddl_trang_thai.SelectedValue);
        m_us_dm_dat.strDIA_CHI = m_txt_dia_chi.Text;
        m_us_dm_dat.strMA_TAI_SAN = m_txt_ma_tai_san.Text;
        m_us_dm_dat.dcSO_NAM_DA_SU_DUNG = CIPConvert.ToDecimal(m_txt_nam_xd.Text);
        m_us_dm_dat.dcGT_THEO_SO_KE_TOAN = CIPConvert.ToDecimal(m_txt_nguyen_gia.Text);
        m_us_dm_dat.dcDT_KHUON_VIEN = CIPConvert.ToDecimal(m_txt_dien_tich_khuon_vien.Text);
        m_us_dm_dat.dcDT_TRU_SO_LAM_VIEC = CIPConvert.ToDecimal(m_txt_tru_so_lam_viec.Text);
        m_us_dm_dat.dcDT_LAM_NHA_O = CIPConvert.ToDecimal(m_txt_lam_nha_o.Text);
        m_us_dm_dat.dcDT_CO_SO_HOAT_DONG_SU_NGHIEP = CIPConvert.ToDecimal(m_txt_co_so_hdsn.Text);
        m_us_dm_dat.dcDT_CHO_THUE = CIPConvert.ToDecimal(m_txt_cho_thue.Text);
        m_us_dm_dat.dcDT_BO_TRONG = CIPConvert.ToDecimal(m_txt_bo_trong.Text);
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
        return true;
    }

    private void clear_form_data()
    {
        m_hdf_id.Value = "-1";
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

    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                load_form_data();
            }
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
            if (m_hdf_id.Value == "-1")
            {
                fill_form_data_to_us();
                m_us_dm_dat.Update();
                Thread.Sleep(2000);
                clear_form_data();
                load_form_data();
                m_lbl_mess.Text = "Đã thêm mới dữ liệu thành công!";
            }
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
            if (!check_validate_data_is_ok()) return;
            if (m_hdf_id.Value != "-1")
            {
                fill_form_data_to_us();
                m_us_dm_dat.Update();
                Thread.Sleep(2000);
                clear_form_data();
                load_form_data();
                m_lbl_mess.Text = "Đã cập nhật dữ liệu thành công!";
            }
            else
            {
                m_lbl_mess.Text = "Bạn chưa chọn dữ liệu để cập nhật";
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
            Thread.Sleep(2000);
            clear_form_data();
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
            load_data_don_vi_chu_quan(m_ddl_bo_tinh.SelectedValue);
            load_data_don_vi_su_dung(m_ddl_don_vi_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
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
            load_data_don_vi_su_dung(m_ddl_don_vi_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
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
            load_data_grid(m_txt_tu_khoa.Text.Trim());
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }

    }
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {

    }

    protected void m_grv_danh_sach_nha_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            Thread.Sleep(1000);
            m_grv_danh_sach_nha.PageIndex = e.NewPageIndex;
            load_data_grid(m_txt_tu_khoa.Text.Trim());
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

                switch (e.CommandName)
                {
                    case "EditComp":
                        Thread.Sleep(2000);
                        m_us_dm_dat = new US_DM_DAT(v_dc_id_dat);
                        m_e_form_mode = DataEntryFormMode.UpdateDataState;
                        load_form_data();
                        load_data_from_us();
                        break;
                    case "DeleteComp":
                        Thread.Sleep(2000);
                        m_us_dm_dat.DeleteByID(v_dc_id_dat);
                        load_form_data();
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
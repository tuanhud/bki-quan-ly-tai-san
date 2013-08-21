using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;
using WebDS;
using WebDS.CDBNames;
using IP.Core.IPData;
using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPUserService;
using IP.Core.IPBusinessService;
using IP.Core.WinFormControls;

public partial class ChucNang_F102_DeNghiXuLyNha : System.Web.UI.Page
{
    #region Members
    private US_DM_NHA m_us_dm_nha = new US_DM_NHA();
    private string m_str_id_checked = "";
    #endregion

    #region Public interfaces
    #endregion

    #region Private methods
    private void load_form_data()
    {
        load_data_bo_tinh();
        load_data_don_vi_chu_quan(m_ddl_bo_tinh.SelectedValue);
        load_data_don_vi_su_dung(m_ddl_don_vi_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
        load_data_dat(m_ddl_don_vi_su_dung.SelectedValue, m_ddl_don_vi_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
        load_data_trang_thai();
        load_data_to_grid(m_txt_tu_khoa.Text.Trim());
        set_trang_thai_cmd();
    }

    // Load dữ liệu vào grid
    private void load_data_to_grid(string ip_str_tu_khoa)
    {
        DS_DM_NHA v_ds_dm_nha = new DS_DM_NHA();

        string query = "(TEN_TAI_SAN LIKE N'%" + ip_str_tu_khoa + "%' OR MA_TAI_SAN LIKE N'%" 
            + ip_str_tu_khoa + "%' OR ID LIKE N'%"+ ip_str_tu_khoa + "%') AND " 
            + DM_NHA.ID_TRANG_THAI + " = " + m_ddl_trang_thai_nha.SelectedValue;

        if (!m_ddl_thuoc_khu_dat.SelectedValue.Equals("-1"))
        {
            m_us_dm_nha.FillDataset(v_ds_dm_nha, "where " + DM_NHA.ID_DAT + " = " + m_ddl_thuoc_khu_dat.SelectedValue + " and "+ query);
        }
        else if (!m_ddl_don_vi_su_dung.SelectedValue.Equals("-1"))
        {
            m_us_dm_nha.FillDataset(v_ds_dm_nha, "where " + DM_NHA.ID_DON_VI_SU_DUNG + " = " + m_ddl_don_vi_su_dung.SelectedValue
                + " and " + query);
        }
        else if (!m_ddl_don_vi_chu_quan.SelectedValue.Equals("-1"))
        {
            m_us_dm_nha.FillDataset(v_ds_dm_nha, "where " + DM_NHA.ID_DON_VI_CHU_QUAN + " = " + m_ddl_don_vi_chu_quan.SelectedValue
                + " and " + query);
        }
        else if (!m_ddl_bo_tinh.SelectedValue.Equals("-1"))
        {
            m_us_dm_nha.FillDataset(v_ds_dm_nha, "where " + DM_NHA.ID_DON_VI_CHU_QUAN
                + " in (select ID from DM_DON_VI where " + DM_DON_VI.ID_DON_VI_CAP_TREN + " = " + m_ddl_bo_tinh.SelectedValue + ")"
                + " and " + query);
        }
        else
        {
            m_us_dm_nha.FillDataset(v_ds_dm_nha, "where " + query);
        }
        m_grv_danh_sach_nha.DataSource = v_ds_dm_nha.DM_NHA;
        m_grv_danh_sach_nha.DataBind();
    }

    // Load dữ liệu vào combo bộ tỉnh
    private void load_data_bo_tinh()
    {
        WinFormControls.load_data_to_cbo_bo_tinh(WinFormControls.eTAT_CA.YES, m_ddl_bo_tinh);
    }

    // Load dữ liệu vào combo đơn vị chủ quản
    private void load_data_don_vi_chu_quan(string ip_str_id_bo_tinh)
    {
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(ip_str_id_bo_tinh, WinFormControls.eTAT_CA.YES, m_ddl_don_vi_chu_quan);
    }

    // Load dữ liệu vào combo đơn vị sử dụng
    private void load_data_don_vi_su_dung(string ip_str_id_don_vi_chu_quan, string ip_str_id_bo_tinh)
    {
        WinFormControls.load_data_to_cbo_don_vi_su_dung(
            ip_str_id_don_vi_chu_quan
            , ip_str_id_bo_tinh
            , WinFormControls.eTAT_CA.YES
            , m_ddl_don_vi_su_dung);
    }

    // Load dữ liệu vào đất
    private void load_data_dat(string ip_str_id_don_vi_su_dung, string ip_str_id_don_vi_chu_quan, string ip_string_bo_tinh)
    {
        WinFormControls.load_data_to_cbo_dia_chi(ip_string_bo_tinh, );
    }

    // Load dữ liệu vào combo trạng thái
    private void load_data_trang_thai()
    {
        WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_NHA
            , WinFormControls.eTAT_CA.YES
            , m_ddl_trang_thai_nha);
    }

    private void set_trang_thai_cmd()
    {
        decimal v_dc_trang_thai = CIPConvert.ToDecimal(m_ddl_trang_thai_nha.SelectedValue);
        if (v_dc_trang_thai.Equals(ID_TRANG_THAI_NHA.DANG_SU_DUNG))
        {
            m_cmd_de_nghi_xu_ly.Visible = true;
            m_cmd_de_nghi_xu_ly.Enabled = true;
            m_cmd_huy_de_nghi_xu_ly.Visible = false;
            return;
        }

        if ()
        {
        }
            case "577":
                m_cmd_de_nghi_xu_ly.Visible = false;
                m_cmd_huy_de_nghi_xu_ly.Visible = true;
                m_cmd_huy_de_nghi_xu_ly.Enabled = true;
                break;
            default:
                m_cmd_de_nghi_xu_ly.Visible = false;
                m_cmd_huy_de_nghi_xu_ly.Visible = false;
                break;
        }
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_form_data();
        }
    }
    
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {
            load_data_to_grid(m_txt_tu_khoa.Text);
            set_trang_thai_cmd();
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
            m_grv_danh_sach_nha.PageIndex = e.NewPageIndex;
            load_data_to_grid(m_txt_tu_khoa.Text.Trim());
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
            load_data_dat(m_ddl_don_vi_su_dung.SelectedValue, m_ddl_don_vi_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
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
            load_data_dat(m_ddl_don_vi_su_dung.SelectedValue, m_ddl_don_vi_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
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
            load_data_dat(m_ddl_don_vi_su_dung.SelectedValue, m_ddl_don_vi_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_ddl_trang_thai_nha_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void m_cmd_de_nghi_xu_ly_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in m_grv_danh_sach_nha.Rows)
            {
                bool v_ch;
                CheckBox v_checkbox = (CheckBox)row.FindControl("chkItem");
                if (v_checkbox != null)
                {
                    // Nếu checkbox của dòng này được checked thì ta thực hiện 1 số công việc sau
                    if (v_checkbox.Checked)
                    {
                        // Chỗ này là công việc cần thực hiện khi checkbox đc checkded
                        decimal v_id = CIPConvert.ToDecimal(m_grv_danh_sach_nha.DataKeys[row.RowIndex].Value);
                        m_us_dm_nha = new US_DM_NHA(v_id);
                        m_us_dm_nha.dcID_TRANG_THAI = ID_TRANG_THAI_NHA.DE_NGHI_XU_LY;
                        m_us_dm_nha.Update();
                    }
                }
            }
            // Hiển thị các ID được checked ra màn hình
            Response.Write(m_str_id_checked);
            load_data_to_grid("");
            set_trang_thai_cmd();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    protected void m_cmd_huy_de_nghi_xu_ly_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in m_grv_danh_sach_nha.Rows)
            {
                bool v_ch;
                CheckBox v_checkbox = (CheckBox)row.FindControl("chkItem");
                if (v_checkbox != null)
                {
                    // Nếu checkbox của dòng này được checked thì ta thực hiện 1 số công việc sau
                    if (v_checkbox.Checked)
                    {
                        // Chỗ này là công việc cần thực hiện khi checkbox đc checkded
                        decimal v_id = CIPConvert.ToDecimal(m_grv_danh_sach_nha.DataKeys[row.RowIndex].Value);
                        m_us_dm_nha = new US_DM_NHA(v_id);
                        m_us_dm_nha.dcID_TRANG_THAI = ID_TRANG_THAI_NHA.DANG_SU_DUNG;
                        m_us_dm_nha.Update();
                    }
                }
            }
            // Hiển thị các ID được checked ra màn hình
            Response.Write(m_str_id_checked);
            load_data_to_grid("");
            set_trang_thai_cmd();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    #endregion

    
}
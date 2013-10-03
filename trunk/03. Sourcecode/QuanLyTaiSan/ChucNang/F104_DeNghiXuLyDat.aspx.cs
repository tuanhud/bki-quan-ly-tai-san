using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using IP.Core.IPUserService;
using IP.Core.IPCommon;
using IP.Core.IPBusinessService;
using IP.Core.IPData;
using IP.Core;
using IP.Core.WinFormControls;
using WebDS;
using WebUS;
using WebDS.CDBNames;

public partial class ChucNang_F104_DeNghiXuLyDat : System.Web.UI.Page
{
    #region Members
    private US_DM_DAT m_us_dm_dat = new US_DM_DAT();
    private string m_str_id_checked = "";
    #endregion

    #region Private Methods
    private void load_form_data()
    {
        load_data_bo_tinh();
        load_data_don_vi_chu_quan();
        load_data_don_vi_su_dung();
        load_data_trang_thai();
        set_trang_thai_cmd();
        load_data_to_grid();
        m_lbl_message.Text = "";
    }
    private void load_data_bo_tinh()
    {
        WinFormControls.load_data_to_cbo_bo_tinh(WinFormControls.eTAT_CA.YES, m_ddl_bo_tinh);
    }
    private void load_data_don_vi_chu_quan()
    {
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(m_ddl_bo_tinh.SelectedValue, WinFormControls.eTAT_CA.YES, m_ddl_don_vi_chu_quan);
    }
    private void load_data_don_vi_su_dung()
    {
        WinFormControls.load_data_to_cbo_don_vi_su_dung(
            m_ddl_don_vi_chu_quan.SelectedValue
            , m_ddl_bo_tinh.SelectedValue
            , WinFormControls.eTAT_CA.YES
            , m_ddl_don_vi_su_dung);
    }
    private void load_data_trang_thai()
    {
        WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_DAT
            , WinFormControls.eTAT_CA.YES
            , m_ddl_trang_thai_nha);
    }
    private void set_trang_thai_cmd()
    {
        decimal v_dc_trang_thai = CIPConvert.ToDecimal(m_ddl_trang_thai_nha.SelectedValue);
        if (v_dc_trang_thai.Equals(ID_TRANG_THAI_DAT.DANG_SU_DUNG))
        {
            m_cmd_de_nghi_xu_ly.Visible = true;
            m_cmd_de_nghi_xu_ly.Enabled = true;
            m_cmd_huy_de_nghi_xu_ly.Visible = false;
            return;
        }

        if (v_dc_trang_thai.Equals(ID_TRANG_THAI_DAT.DE_NGHI_XU_LY))
        {
            m_cmd_de_nghi_xu_ly.Visible = false;
            m_cmd_huy_de_nghi_xu_ly.Visible = true;
            m_cmd_huy_de_nghi_xu_ly.Enabled = true;
            return;
        }

        m_cmd_de_nghi_xu_ly.Visible = false;
        m_cmd_huy_de_nghi_xu_ly.Visible = false;
    }
    private void load_data_to_grid()
    {
        m_lbl_thong_tin_dat.Text = "DANH SÁCH ĐẤT ";
        US_V_DM_DAT v_us_v_dm_dat = new US_V_DM_DAT();
        DS_V_DM_DAT v_ds_v_dm_dat = new DS_V_DM_DAT();
        v_us_v_dm_dat.FillDataSetByKeyWord(
            m_ddl_bo_tinh.SelectedValue
            , m_ddl_don_vi_chu_quan.SelectedValue
            , m_ddl_don_vi_su_dung.SelectedValue
            , m_ddl_trang_thai_nha.SelectedValue
            , Person.get_user_name()
            , CONST_QLDB.ID_TAT_CA.ToString()
            , m_txt_tu_khoa.Text.Trim()
            , v_ds_v_dm_dat);
        string v_str_thong_tin = " (Có " + v_ds_v_dm_dat.V_DM_DAT.Rows.Count + " bản ghi)";
        m_lbl_thong_tin_dat.Text += v_str_thong_tin;
        m_grv_danh_sach_nha.DataSource = v_ds_v_dm_dat.V_DM_DAT;
        m_grv_danh_sach_nha.DataBind();
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
                load_form_data();
            }
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
            load_data_to_grid();
            set_trang_thai_cmd();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_de_nghi_xu_ly_Click(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            Thread.Sleep(2000);
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
                        m_us_dm_dat = new US_DM_DAT(v_id);
                        m_us_dm_dat.dcID_TRANG_THAI = ID_TRANG_THAI_DAT.DE_NGHI_XU_LY;
                        m_us_dm_dat.Update();
                    }
                }
            }
            // Hiển thị các ID được checked ra màn hình
            Response.Write(m_str_id_checked);
            load_data_to_grid();
            set_trang_thai_cmd();
            m_lbl_message.Text = "Đã cập nhật thành công";
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
            clear_message();
            Thread.Sleep(2000);
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
                        m_us_dm_dat = new US_DM_DAT(v_id);
                        m_us_dm_dat.dcID_TRANG_THAI = ID_TRANG_THAI_DAT.DANG_SU_DUNG;
                        m_us_dm_dat.Update();
                    }
                }
            }
            // Hiển thị các ID được checked ra màn hình
            Response.Write(m_str_id_checked);
            load_data_to_grid();
            set_trang_thai_cmd();
            m_lbl_message.Text = "Đã cập nhật thành công";
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
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
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            m_grv_danh_sach_nha.AllowPaging = false;
            load_data_to_grid();
            WinformReport.export_gridview_2_excel(m_grv_danh_sach_nha, "DS de nghi xu ly dat.xls", 0);
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
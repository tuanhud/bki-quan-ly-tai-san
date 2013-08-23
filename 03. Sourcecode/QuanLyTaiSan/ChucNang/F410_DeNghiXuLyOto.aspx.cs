using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;
using WebDS;
using WebDS.CDBNames;
using System.Data;
using IP.Core.IPBusinessService;
using IP.Core.IPException;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;
using IP.Core.IPException;
using IP.Core.WinFormControls;
using System.Threading;


public partial class ChucNang_F410_DeNghiXuLyOto : System.Web.UI.Page
{
    #region Members
    private US_DM_OTO m_us_dm_oto = new US_DM_OTO();
    private string m_str_id_checked = "";
    #endregion

    #region Public Interfaces
    #endregion

    #region Private Methods
    private void load_form_data()
    {
        load_data_bo_tinh();
        load_data_don_vi_chu_quan(m_ddl_bo_tinh.SelectedValue);
        load_data_don_vi_su_dung(m_ddl_dv_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
        load_data_trang_thai();
        load_data_to_grid();
        set_trang_thai_cmd();
        m_lbl_mess.Text = "";
    }

    private void load_data_bo_tinh()
    {
        WinFormControls.load_data_to_cbo_bo_tinh(WinFormControls.eTAT_CA.YES, m_ddl_bo_tinh);
    }
    private void load_data_don_vi_chu_quan(string ip_str_id_bo_tinh)
    {
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(ip_str_id_bo_tinh, WinFormControls.eTAT_CA.YES, m_ddl_dv_chu_quan);
    }

    private void load_data_don_vi_su_dung(string ip_str_id_don_vi_chu_quan, string ip_str_id_bo_tinh)
    {
        WinFormControls.load_data_to_cbo_don_vi_su_dung(
            ip_str_id_don_vi_chu_quan
            , ip_str_id_bo_tinh
            , WinFormControls.eTAT_CA.YES
            , m_ddl_dv_sd_ts);
    }
    private void load_data_trang_thai()
    {
        WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_OTO
            , WinFormControls.eTAT_CA.YES
            , m_ddl_trang_thai_oto);
    }
    private void load_data_to_grid()
    {
        US_V_DM_OTO v_us_v_dm_oto = new US_V_DM_OTO();
        DS_V_DM_OTO v_ds_v_dm_oto = new DS_V_DM_OTO();

        v_us_v_dm_oto.FillDatasetLoadDataToGridOto_by_tu_khoa(
            m_txt_tim_kiem.Text.Trim()
            , CIPConvert.ToDecimal(m_ddl_bo_tinh.SelectedValue)
            , CIPConvert.ToDecimal(m_ddl_dv_chu_quan.SelectedValue)
            , CIPConvert.ToDecimal(m_ddl_dv_sd_ts.SelectedValue)
            , CIPConvert.ToDecimal(m_ddl_trang_thai_oto.SelectedValue)
            , CIPConvert.ToDecimal(m_ddl_trang_thai_oto.SelectedValue)
            , CONST_QLDB.ID_TAT_CA.ToString()
            , Person.get_user_name()
            , v_ds_v_dm_oto);
        m_grv_dm_oto.DataSource = v_ds_v_dm_oto.V_DM_OTO;
        m_grv_dm_oto.DataBind();
    }

    private void set_trang_thai_cmd()
    {
        decimal v_dc_trang_thai = CIPConvert.ToDecimal(m_ddl_trang_thai_oto.SelectedValue);
        if (v_dc_trang_thai.Equals(ID_TRANG_THAI_OTO.DANG_SU_DUNG))
        {
            m_cmd_de_nghi_xu_ly.Visible = true;
            m_cmd_de_nghi_xu_ly.Enabled = true;
            m_cmd_huy_de_nghi_xu_ly.Visible = false;
            return;
        }

        if (v_dc_trang_thai.Equals(ID_TRANG_THAI_OTO.DE_NGHI_XU_LY))
        {
            m_cmd_de_nghi_xu_ly.Visible = false;
            m_cmd_huy_de_nghi_xu_ly.Visible = true;
            m_cmd_huy_de_nghi_xu_ly.Enabled = true;
            return;
        }

        m_cmd_de_nghi_xu_ly.Visible = false;
        m_cmd_huy_de_nghi_xu_ly.Visible = false;
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

    protected void m_grv_dm_oto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            Thread.Sleep(1000);
            m_grv_dm_oto.PageIndex = e.NewPageIndex;
            load_data_to_grid();
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
            // Thu thập dữ liệu search
            Thread.Sleep(2000);
            load_data_to_grid();
            set_trang_thai_cmd();
            m_lbl_mess.Text = "";
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_ddl_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_data_don_vi_chu_quan(m_ddl_bo_tinh.SelectedValue);
        load_data_don_vi_su_dung(m_ddl_dv_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
    }
    protected void m_ddl_dv_chu_quan_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_data_don_vi_su_dung(m_ddl_dv_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
    }
    protected void m_ddl_dv_sd_ts_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void m_cmd_de_nghi_xu_ly_Click(object sender, EventArgs e)
    {
        try
        {
            Thread.Sleep(1000);
            foreach (GridViewRow row in m_grv_dm_oto.Rows)
            {
                bool v_ch;
                CheckBox v_checkbox = (CheckBox)row.FindControl("chkItem");
                if (v_checkbox != null)
                {
                    // Nếu checkbox của dòng này được checked thì ta thực hiện 1 số công việc sau
                    if (v_checkbox.Checked)
                    {
                        // Chỗ này là công việc cần thực hiện khi checkbox đc checkded
                        decimal v_id = CIPConvert.ToDecimal(m_grv_dm_oto.DataKeys[row.RowIndex].Value);
                        m_us_dm_oto = new US_DM_OTO(v_id);
                        m_us_dm_oto.dcID_TRANG_THAI = ID_TRANG_THAI_OTO.DE_NGHI_XU_LY;
                        m_us_dm_oto.Update();
                    }
                }
            }
            // Hiển thị các ID được checked ra màn hình
            Response.Write(m_str_id_checked);
            load_data_to_grid();
            set_trang_thai_cmd();
            m_lbl_mess.Text = "Đã cập nhật thành công";
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
            Thread.Sleep(1000);
            foreach (GridViewRow row in m_grv_dm_oto.Rows)
            {
                bool v_ch;
                CheckBox v_checkbox = (CheckBox)row.FindControl("chkItem");
                if (v_checkbox != null)
                {
                    // Nếu checkbox của dòng này được checked thì ta thực hiện 1 số công việc sau
                    if (v_checkbox.Checked)
                    {
                        // Chỗ này là công việc cần thực hiện khi checkbox đc checkded
                        decimal v_id = CIPConvert.ToDecimal(m_grv_dm_oto.DataKeys[row.RowIndex].Value);
                        m_us_dm_oto = new US_DM_OTO(v_id);
                        m_us_dm_oto.dcID_TRANG_THAI = ID_TRANG_THAI_OTO.DANG_SU_DUNG;
                        m_us_dm_oto.Update();
                    }
                }
            }
            // Hiển thị các ID được checked ra màn hình
            Response.Write(m_str_id_checked);
            load_data_to_grid();
            set_trang_thai_cmd();
            m_lbl_mess.Text = "Đã cập nhật thành công";
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    #endregion

}
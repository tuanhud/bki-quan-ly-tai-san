using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using IP.Core;
using IP.Core.IPData;
using IP.Core.IPUserService;
using WebDS.CDBNames;
using IP.Core.IPCommon;
using System.Threading;

public partial class DanhMuc_F910_Danh_muc_trang_thai : System.Web.UI.Page
{
    #region Members
    US_CM_DM_TU_DIEN m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    DataEntryFormMode m_e_form_mode = DataEntryFormMode.InsertDataState;
    #endregion

    #region Private Methods
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                set_form_mode();
                load_cbo_loai_tai_san_detail();
                
            }
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            this.Response.Write(v_e.ToString());
        }
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
    private void reset_control()
    {
        m_lbl_mess.Text = "";
        m_txt_ma_tu_dien.Text = "";
        m_txt_ten_trang_thai.Text = "";
        m_txt_ghi_chu.Text = "";
        m_e_form_mode = DataEntryFormMode.InsertDataState;
    }
    private void load_cbo_loai_tai_san_detail()
    {
        try
        {   
            US_CM_DM_LOAI_TD us_cm_dm_loai_td = new US_CM_DM_LOAI_TD();
            DS_CM_DM_LOAI_TD ds_cm_dm_loai_td = new DS_CM_DM_LOAI_TD();
            us_cm_dm_loai_td.FillDataset(ds_cm_dm_loai_td, " where ID in (5,6,7,8)");
            m_cbo_loai_tai_san_detail.DataSource = ds_cm_dm_loai_td.CM_DM_LOAI_TD;
            m_cbo_loai_tai_san_detail.DataTextField = CM_DM_LOAI_TD.TEN_LOAI;
            m_cbo_loai_tai_san_detail.DataValueField = CM_DM_LOAI_TD.ID;
            m_cbo_loai_tai_san_detail.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_data_2_grid() 
    {
        try
        {
            m_us_cm_dm_tu_dien.FillDataset(m_ds_cm_dm_tu_dien, " WHERE ID_LOAI_TU_DIEN =" + CIPConvert.ToDecimal(m_cbo_loai_tai_san_detail.SelectedValue));
            m_grv_dm_trang_thai.DataSource = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_grv_dm_trang_thai.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private bool check_validate_data_is_ok()
    {
        if (!CValidateTextBox.IsValid(m_txt_ma_tu_dien, DataType.StringType, allowNull.NO))
        {
            m_lbl_mess.Text = "Chưa nhập đúng mã từ điển";
            return false;
        }
        if (!CValidateTextBox.IsValid(m_txt_ten_trang_thai, DataType.StringType, allowNull.NO))
        {
            m_lbl_mess.Text = "Chưa nhập đúng tên trạng thái";
            return false;
        }
        return true;
    }
    private void form_2_us_object()
    {
        m_us_cm_dm_tu_dien.dcID_LOAI_TU_DIEN = CIPConvert.ToDecimal(m_cbo_loai_tai_san_detail.SelectedValue);
        m_us_cm_dm_tu_dien.strGHI_CHU = m_txt_ghi_chu.Text.TrimEnd();
        m_us_cm_dm_tu_dien.strTEN_NGAN = m_txt_ten_trang_thai.Text.Trim();
        m_us_cm_dm_tu_dien.strTEN = m_txt_ten_trang_thai.Text.Trim();
        m_us_cm_dm_tu_dien.strMA_TU_DIEN = m_txt_ma_tu_dien.Text.Trim();
    }
    private void load_data_2_us_update(int ip_i_stt_row)
    {
        decimal dc_id_trang_thái = CIPConvert.ToDecimal(m_grv_dm_trang_thai.DataKeys[ip_i_stt_row].Value);
        m_hdf_id_trang_thai.Value = CIPConvert.ToStr(dc_id_trang_thái);
        m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN(dc_id_trang_thái);
    }
    private void us_object_2_form(US_CM_DM_TU_DIEN ip_us_trang_thai)
    {
        m_hdf_id_trang_thai.Value = CIPConvert.ToStr(ip_us_trang_thai.dcID);
        m_cbo_loai_tai_san_detail.SelectedValue = CIPConvert.ToStr(ip_us_trang_thai.dcID_LOAI_TU_DIEN);
        m_txt_ghi_chu.Text = ip_us_trang_thai.strGHI_CHU;
        m_txt_ten_trang_thai.Text = ip_us_trang_thai.strTEN_NGAN;
        m_txt_ma_tu_dien.Text = ip_us_trang_thai.strMA_TU_DIEN;
    }
    private void update_data()
    {
        if (m_hdf_id_trang_thai.Value.Trim().Equals(""))
        {
            m_lbl_mess.Visible = true;
            m_lbl_mess.Text = "Bạn chưa chọn tài sản để cập nhật!";
            return;
        }
        if (!check_validate_data_is_ok()) return;
        m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN(CIPConvert.ToDecimal(m_hdf_id_trang_thai.Value));

        form_2_us_object();

        m_us_cm_dm_tu_dien.Update();
        load_data_2_grid();
        m_hdf_id_trang_thai.Value = "";
        reset_control();
        set_form_mode();
        m_lbl_mess.Text = "Cập nhật thành công!";
    }
    private void insert_data()
    {
        if (!check_validate_data_is_ok()) return;

        form_2_us_object();
        m_us_cm_dm_tu_dien.Insert();
        load_data_2_grid();
        m_lbl_mess.Text = "Tạo mới thành công!";
    }
    #endregion

    #region Events
    protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
    {
        try
        {
            Thread.Sleep(2000);
            update_data();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_trang_thai_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            load_data_2_us_update(e.RowIndex);
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            set_form_mode();
            us_object_2_form(m_us_cm_dm_tu_dien);

        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    protected void m_grv_dm_trang_thai_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            decimal dc_id_trang_thai = CIPConvert.ToDecimal(m_grv_dm_trang_thai.DataKeys[e.RowIndex].Value);
            m_us_cm_dm_tu_dien.DeleteByID(dc_id_trang_thai);
            load_data_2_grid();
            m_lbl_mess.Text = "Xóa thành công!";
        }
        catch (Exception v_e)
        {
            // de su dung CsystemLog_301 bat buoc Site phai dat trong thu muc cap 1. Vi du: DanhMuc/Dictionary.aspx
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            try
            {
                Thread.Sleep(2000);
                insert_data();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Thread.Sleep(2000);
            reset_control();
            set_form_mode();
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    #endregion
}
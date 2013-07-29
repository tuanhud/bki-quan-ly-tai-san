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

public partial class DanhMuc_F910_Danh_muc_trang_thai : System.Web.UI.Page
{
    #region Members
    US_CM_DM_TU_DIEN m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    #endregion

    #region Private Methods
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                load_cbo_loai_tai_san_detail();
                load_cbo_loai_tai_san_master();
            }
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            this.Response.Write(v_e.ToString());
        }
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
    private void load_cbo_loai_tai_san_master()
    {
        try
        {
            US_CM_DM_LOAI_TD us_cm_dm_loai_td = new US_CM_DM_LOAI_TD();
            DS_CM_DM_LOAI_TD ds_cm_dm_loai_td = new DS_CM_DM_LOAI_TD();
            us_cm_dm_loai_td.FillDataset(ds_cm_dm_loai_td, " where ID in (5,6,7,8)");
            m_cbo_loai_tai_san_master.DataSource = ds_cm_dm_loai_td.CM_DM_LOAI_TD;
            m_cbo_loai_tai_san_master.DataTextField = CM_DM_LOAI_TD.TEN_LOAI;
            m_cbo_loai_tai_san_master.DataValueField = CM_DM_LOAI_TD.ID;
            m_cbo_loai_tai_san_master.DataBind();
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
            m_us_cm_dm_tu_dien.FillDataset(m_ds_cm_dm_tu_dien, " WHERE ID_LOAI_TU_DIEN =" + CIPConvert.ToDecimal(m_cbo_loai_tai_san_master.SelectedValue));
            m_grv_dm_trang_thai.DataSource = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_grv_dm_trang_thai.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void delete_dm_tu_dien(int i_int_row_index)
    {
        try
        {
            decimal dc_id_trang_thai = CIPConvert.ToDecimal(m_grv_dm_trang_thai.DataKeys[i_int_row_index].Value);
            m_us_cm_dm_tu_dien.DeleteByID(dc_id_trang_thai);
            load_data_2_grid();
            m_lbl_mess.Text = "Xóa bản ghi thành công.";
        }
        catch (Exception v_e)
        {
            m_lbl_mess.Text = "Lỗi trong quá trình xóa bản ghi.";
            throw v_e;
        }
    }
    private void load_update_user(int i_int_row_index)
    {
        try
        {
            decimal dc_id_trang_thai = CIPConvert.ToDecimal(m_grv_dm_trang_thai.DataKeys[i_int_row_index].Value);
            US_CM_DM_TU_DIEN us_dm_trang_thai = new US_CM_DM_TU_DIEN(dc_id_trang_thai);
            m_hdf_id_trang_thai.Value = CIPConvert.ToStr(dc_id_trang_thai);
            us_object_2_form(us_dm_trang_thai);
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void us_object_2_form(US_CM_DM_TU_DIEN i_us_trang_thai)
    {
        m_cbo_loai_tai_san_detail.SelectedValue = CIPConvert.ToStr(i_us_trang_thai.dcID_LOAI_TU_DIEN);
        m_txt_ghi_chu.Text = i_us_trang_thai.strGHI_CHU;
        m_txt_ten_trang_thai.Text = i_us_trang_thai.strTEN_NGAN;
        m_txt_ma_tu_dien.Text = i_us_trang_thai.strMA_TU_DIEN;
    }
    private bool check_validate()
    {
        return true;
    }
    private void form_2_us_object()
    {
        m_us_cm_dm_tu_dien.dcID_LOAI_TU_DIEN = CIPConvert.ToDecimal(m_cbo_loai_tai_san_detail.SelectedValue);
        m_us_cm_dm_tu_dien.strGHI_CHU = m_txt_ghi_chu.Text.TrimEnd();
        m_us_cm_dm_tu_dien.strTEN_NGAN = m_txt_ten_trang_thai.Text.TrimEnd();
        m_us_cm_dm_tu_dien.strTEN = m_txt_ten_trang_thai.Text.TrimEnd();
        m_us_cm_dm_tu_dien.strMA_TU_DIEN = m_txt_ma_tu_dien.Text.TrimEnd();
    }
    private void clear_data()
    {
        try
        {
            m_grv_dm_trang_thai.EditIndex = -1;
            m_txt_ma_tu_dien.Text = "";
            m_txt_ten_trang_thai.Text = "";
            m_txt_ghi_chu.Text = "";
            this.m_hdf_id_trang_thai.Value = "";
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void update_user()
    {
        try
        {
            m_grv_dm_trang_thai.EditIndex = -1;
            if (Page.IsValid)
            {
                if (this.m_hdf_id_trang_thai.Value == "") { m_lbl_mess.Text = "Bạn phải chọn trạng thái cần sửa!"; return; }
                if (!check_validate()) return;
                form_2_us_object();

                m_us_cm_dm_tu_dien.dcID = CIPConvert.ToDecimal(this.m_hdf_id_trang_thai.Value);
                m_us_cm_dm_tu_dien.Update();
                m_lbl_mess.Text = "Đã cập nhật tài khoản thành công.";
                clear_data();
                m_grv_dm_trang_thai.EditIndex = -1;
                load_data_2_grid();
            }
        }
        catch (Exception v_e)
        {
            m_lbl_mess.Text = "Lỗi trong quá trình cập nhật bản ghi.";
            throw v_e;
        }
    }
    private void insert_user()
    {
        try
        {
            m_grv_dm_trang_thai.EditIndex = -1;
            if (Page.IsValid)
            {
                if (!check_validate()) return;
                form_2_us_object();
                m_us_cm_dm_tu_dien.Insert();
                m_lbl_mess.Text = "Đã tạo mới trạng thái thành công.";
                clear_data();
                load_data_2_grid();
            }
        }
        catch (Exception v_e)
        {
            m_lbl_mess.Text = "Lỗi trong quá trình thêm mới bản ghi.";
            throw v_e;
        }
    }
    #endregion

    #region Events
    protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            update_user();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_trang_thai_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            delete_dm_tu_dien(e.RowIndex);
        }
        catch (Exception v_e)
        {
            // de su dung CsystemLog_301 bat buoc Site phai dat trong thu muc cap 1. Vi du: DanhMuc/Dictionary.aspx
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_trang_thai_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            load_update_user(e.NewSelectedIndex);
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
            m_lbl_mess.Text = "";
            insert_user();
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
            m_lbl_mess.Text = "";
            clear_data();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion

}
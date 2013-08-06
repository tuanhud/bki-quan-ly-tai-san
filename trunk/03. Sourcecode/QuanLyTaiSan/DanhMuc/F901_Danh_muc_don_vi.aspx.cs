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


public partial class DanhMuc_F901_danh_muc_don_vi : System.Web.UI.Page
{
    #region Members
    US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
    DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
    #endregion

    #region Private Methods
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                load_cbo_don_vi_cap_tren();
                load_cbo_loai_don_vi();
                load_data_2_grid();
            }
            
        }
        catch (Exception v_e)
        {
            this.Response.Write(v_e.ToString());
        }
    }

    private void load_cbo_don_vi_cap_tren()
    {
        try
        {
            m_us_don_vi.FillDataset(m_ds_don_vi);
            m_cbo_don_vi_cap_tren.DataSource = m_ds_don_vi.DM_DON_VI;
            m_cbo_don_vi_cap_tren.DataTextField = DM_DON_VI.TEN_DON_VI;
            m_cbo_don_vi_cap_tren.DataValueField = DM_DON_VI.ID;
            m_cbo_don_vi_cap_tren.DataBind();
            m_cbo_don_vi_cap_tren.Items.Add("Không có");
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }

    private void load_cbo_loai_don_vi()
    {
        try
        {
            US_CM_DM_TU_DIEN m_us = new US_CM_DM_TU_DIEN();
            DS_CM_DM_TU_DIEN m_ds = new DS_CM_DM_TU_DIEN();
            m_us.FillDataset(m_ds,"WHERE ID_LOAI_TU_DIEN = 4");
            m_cbo_loai_don_vi.DataSource = m_ds.CM_DM_TU_DIEN;
            m_cbo_loai_don_vi.DataTextField = CM_DM_TU_DIEN.TEN_NGAN;
            m_cbo_loai_don_vi.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_loai_don_vi.DataBind();
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
            if (Request.QueryString["ID"] != null)
            {
                string v_dc_id_loai_don_vi = Request.QueryString["ID"].ToString();
                m_us_don_vi.FillDatasetByQueryString(m_ds_don_vi,v_dc_id_loai_don_vi);
                m_grv_dm_don_vi.DataSource = m_ds_don_vi.DM_DON_VI;
                m_grv_dm_don_vi.DataBind();
            }
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void delete_dm_don_vi(int i_int_row_index)
    {
        try
        {
            decimal dc_id_don_vi = CIPConvert.ToDecimal(m_grv_dm_don_vi.DataKeys[i_int_row_index].Value);
            m_us_don_vi.DeleteByID(dc_id_don_vi);
            load_data_2_grid();
            m_lbl_mess.Text = "Xóa bản ghi thành công.";
        }
        catch (Exception v_e)
        {
            m_lbl_mess.Text = "Lỗi trong quá trình xóa bản ghi.";
            throw v_e;
        }
    }
    private void load_update_don_vi(int i_int_row_index)
    {
        try
        {
            decimal dc_id_don_vi = CIPConvert.ToDecimal(m_grv_dm_don_vi.DataKeys[i_int_row_index].Value);
            US_DM_DON_VI us_dm_don_vi = new US_DM_DON_VI(dc_id_don_vi);
            m_hdf_id_don_vi.Value = CIPConvert.ToStr(dc_id_don_vi);
            us_object_2_form(us_dm_don_vi);
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void us_object_2_form(US_DM_DON_VI i_us_don_vi)
    {
        if (i_us_don_vi.dcID_DON_VI_CAP_TREN != 0)
            m_cbo_don_vi_cap_tren.SelectedValue = CIPConvert.ToStr(i_us_don_vi.dcID_DON_VI_CAP_TREN);
        else
            m_cbo_don_vi_cap_tren.SelectedValue = "1";//Bug
        m_txt_ma_don_vi.Text = i_us_don_vi.strMA_DON_VI;
        m_txt_ten_don_vi.Text = i_us_don_vi.strTEN_DON_VI;
        m_txt_stt.Text = CIPConvert.ToStr(i_us_don_vi.dcSTT);
        m_txt_loai_hinh_don_vi.Text = i_us_don_vi.strLOAI_HINH_DON_VI;
        m_txt_level_mode.Text = CIPConvert.ToStr(i_us_don_vi.dcLEVEL_MODE);
        m_cbo_loai_don_vi.SelectedValue = CIPConvert.ToStr(i_us_don_vi.dcID_LOAI_DON_VI);
    }
    private bool check_validate()
    {
        return true;
    }
    private void form_2_us_object()
    {
        m_us_don_vi.dcID_DON_VI_CAP_TREN = CIPConvert.ToDecimal(m_cbo_don_vi_cap_tren.SelectedValue);
        m_us_don_vi.strLOAI_HINH_DON_VI = m_txt_loai_hinh_don_vi.Text.Trim();
        m_us_don_vi.strMA_DON_VI = m_txt_ma_don_vi.Text.Trim();
        m_us_don_vi.strTEN_DON_VI = m_txt_ten_don_vi.Text.Trim();
        m_us_don_vi.dcID_LOAI_DON_VI = CIPConvert.ToDecimal(m_cbo_loai_don_vi.SelectedValue);
    }
    private void clear_data()
    {
        try
        {
            m_grv_dm_don_vi.EditIndex = -1;
            m_txt_ten_don_vi.Text = "";
            m_txt_stt.Text = "";
            m_txt_ma_don_vi.Text = "";
            m_txt_level_mode.Text = "";
            m_txt_loai_hinh_don_vi.Text = "";
            this.m_hdf_id_don_vi.Value = "";
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void update_don_vi()
    {
        try
        {
            m_grv_dm_don_vi.EditIndex = -1;
            if (Page.IsValid)
            {
                if (this.m_hdf_id_don_vi.Value == "") { m_lbl_mess.Text = "Bạn phải chọn đơn vị cần sửa!"; return; }
                if (!check_validate()) return;
                form_2_us_object();

                m_us_don_vi.dcID = CIPConvert.ToDecimal(this.m_hdf_id_don_vi.Value);
                m_us_don_vi.Update();
                m_lbl_mess.Text = "Đã cập nhật đơn vị";
                clear_data();
                m_grv_dm_don_vi.EditIndex = -1;
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
            m_grv_dm_don_vi.EditIndex = -1;
            if (Page.IsValid)
            {
                if (!check_validate()) return;
                form_2_us_object();
                m_us_don_vi.Insert();
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
            update_don_vi();
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
    protected void m_grv_dm_don_vi_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            load_update_don_vi(e.NewSelectedIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_don_vi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            delete_dm_don_vi(e.RowIndex);
        }
        catch (Exception v_e)
        {
            // de su dung CsystemLog_301 bat buoc Site phai dat trong thu muc cap 1. Vi du: DanhMuc/Dictionary.aspx
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_don_vi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        load_data_2_grid();
        m_grv_dm_don_vi.PageIndex = e.NewPageIndex;
        m_grv_dm_don_vi.DataBind();
    }
    protected void m_cbo_don_vi_cap_tren_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_grid();
        }
        catch (Exception v_e)
        {

            throw v_e;
        }
    }
    protected void m_cbo_loai_don_vi_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_grid();
        }
        catch (Exception v_e)
        {

            throw v_e;
        }
    }
    protected void m_grv_dm_don_vi_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            load_update_don_vi(e.RowIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
        
    }
}
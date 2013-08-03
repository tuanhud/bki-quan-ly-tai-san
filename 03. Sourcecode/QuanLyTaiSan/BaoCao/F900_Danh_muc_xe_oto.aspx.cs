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

public partial class BaoCao_F900_Danh_muc_xe_oto_de_nghi_xu_ly : System.Web.UI.Page
{
    #region Members
    US_DM_OTO m_us_dm_oto = new US_DM_OTO();
    DS_DM_OTO m_ds_dm_oto = new DS_DM_OTO();
    #endregion

    #region Data Structures
    #endregion

    #region Private Methods
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["ID"] == null)
            {
                if (!this.IsPostBack)
                {
                    load_cbo_trang_thai();
                    load_data_2_grid_by_command();
                }
            }
            else
            {
                m_cbo_trang_thai.Visible = false;
                m_lbl_trang_thai.Visible = false;
                load_data_2_grid();
            }
        }
        catch (Exception v_e)
        {
            this.Response.Write(v_e.ToString());
        }
    }
    
    private void load_cbo_trang_thai()
    {
        try
        {
            US_CM_DM_TU_DIEN us_cm_tu_dien = new US_CM_DM_TU_DIEN();
            DS_CM_DM_TU_DIEN ds_cm_tu_dien = new DS_CM_DM_TU_DIEN();
            us_cm_tu_dien.FillDataset(ds_cm_tu_dien, " WHERE ID_LOAI_TU_DIEN =7");
            m_cbo_trang_thai.DataSource = ds_cm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN_NGAN;
            m_cbo_trang_thai.DataValueField = CM_DM_LOAI_TD.ID;
            m_cbo_trang_thai.DataBind();
            ListItem m_item_tat_ca = new ListItem("Tất cả", "0");
            m_cbo_trang_thai.Items.Add(m_item_tat_ca);
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
            string v_str_tu_khoa = m_txt_tu_khoa.Text.Trim();
            m_us_dm_oto.FillDatasetSearch(m_ds_dm_oto, v_str_tu_khoa);
            m_grv_bao_cao_oto.DataSource = m_ds_dm_oto.DM_OTO;
            m_grv_bao_cao_oto.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_data_2_grid_by_command()
    {
        try
        {   
            string v_str_tu_khoa = m_txt_tu_khoa.Text.Trim();
            decimal v_dc_id_trang_thai = CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue);
            m_us_dm_oto.FillDatasetBySearch(m_ds_dm_oto,v_str_tu_khoa,v_dc_id_trang_thai);
            m_grv_bao_cao_oto.DataSource = m_ds_dm_oto.DM_OTO;
            m_grv_bao_cao_oto.DataBind();
        }

        catch (Exception v_e)
        {
            throw v_e;
        }
    }

    #endregion

    #region Events
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["ID"] == null)
            {
                load_data_2_grid_by_command();
            }
            else
                load_data_2_grid();
        }
        catch (Exception v_e)
        {

            throw v_e;
        }
    }
    #endregion
    protected void m_cbo_trang_thai_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_grid_by_command();
            m_txt_tu_khoa.Text = "";
        }
        catch (Exception v_e)
        {

            throw v_e;
        }
    }
}
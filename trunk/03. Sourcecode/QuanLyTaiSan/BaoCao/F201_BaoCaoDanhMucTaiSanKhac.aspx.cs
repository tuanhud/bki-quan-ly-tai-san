using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPData;
using IP.Core.IPUserService;
using WebDS.CDBNames;
using WebDS;
using IP.Core.IPCommon;
using WebUS;


public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            try
            {
                if (!IsPostBack)
                {
                    if (m_txt_tim_kiem.Text == "")
                        load_data_2_cbo_trang_thai_tai_san();
                    else
                        load_data_2_grid_for_search();
                }
                
            }
            catch (Exception v_e)
            {
                throw v_e;
            }
    }
    #region Member
    US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
    DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
    US_DM_TAI_SAN_KHAC m_us_tai_san_khac = new US_DM_TAI_SAN_KHAC();
    DS_DM_TAI_SAN_KHAC m_ds_tai_san_khac = new DS_DM_TAI_SAN_KHAC();
    US_CM_DM_TU_DIEN m_us_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_tu_dien = new DS_CM_DM_TU_DIEN();
    #endregion
    #region Private Methods
    private double runningTotal = 0;
    private void CalcTotal(string price)
    {
        try
        {
            runningTotal += Double.Parse(price);
        }
        catch { }
    }
    protected void myRow(GridView e)
    {
        for (int i = 1; i < 3; i++)
        {
            CalcTotal(e.Rows[1].Cells[5].Text);
        }
    }
    private void load_data_2_grid_for_search()
    {
        try
        {
            string cmd = "select * from DM_TAI_SAN_KHAC Where TEN_TAI_SAN like '%"+m_txt_tim_kiem.Text+
                "%' or KY_HIEU like '%"+m_txt_tim_kiem.Text+
                "%' or NUOC_SAN_XUAT like '%"+m_txt_tim_kiem.Text+
                "%' or NAM_SAN_XUAT like '%"+m_txt_tim_kiem.Text+
                "%' or NAM_SU_DUNG like '%"+m_txt_tim_kiem.Text+
                "%'";
            System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(cmd);
            m_us_tai_san_khac.FillDatasetByCommand(m_ds_tai_san_khac,command);
            m_grv_danh_sach_tai_san_khac.DataSource = m_ds_tai_san_khac.DM_TAI_SAN_KHAC;
            m_grv_danh_sach_tai_san_khac.DataBind();
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
            m_us_tai_san_khac.FillDataset(m_ds_tai_san_khac);
            m_grv_danh_sach_tai_san_khac.DataSource = m_ds_tai_san_khac.DM_TAI_SAN_KHAC;
            m_grv_danh_sach_tai_san_khac.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_data_2_grid_by_id_trang_thai()
    {
        try
        {
            m_us_tai_san_khac.FillDataset(m_ds_tai_san_khac, "WHERE ID_TRANG_THAI=" + m_cbo_trang_thai_tai_san.SelectedValue);
            m_grv_danh_sach_tai_san_khac.DataSource = m_ds_tai_san_khac.DM_TAI_SAN_KHAC;
            m_grv_danh_sach_tai_san_khac.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_data_2_cbo_trang_thai_tai_san()
    {
        m_ds_tu_dien.CM_DM_TU_DIEN.Clear();
        m_us_tu_dien.FillDataset(m_ds_tu_dien, "Where ID_LOAI_TU_DIEN=8");
        m_cbo_trang_thai_tai_san.DataSource = m_ds_tu_dien.CM_DM_TU_DIEN;
        m_cbo_trang_thai_tai_san.DataTextField = CM_DM_TU_DIEN.TEN;
        m_cbo_trang_thai_tai_san.DataValueField = CM_DM_TU_DIEN.ID;
        m_cbo_trang_thai_tai_san.DataBind();
    }
    #endregion
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {
            load_data_2_grid_for_search();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    protected void m_cbo_trang_thai_tai_san_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_grid_by_id_trang_thai();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
}
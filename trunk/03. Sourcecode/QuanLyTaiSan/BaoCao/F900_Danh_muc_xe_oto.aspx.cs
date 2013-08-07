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
using QltsForm;

public partial class BaoCao_F900_Danh_muc_xe_oto_de_nghi_xu_ly : System.Web.UI.Page
{
    #region Members
    US_DM_OTO m_us_dm_oto = new US_DM_OTO();
    DS_DM_OTO m_ds_dm_oto = new DS_DM_OTO();
    US_DM_DON_VI m_us_dm_don_vi = new US_DM_DON_VI();
    DS_DM_DON_VI m_ds_dm_don_vi = new DS_DM_DON_VI();
    #endregion

    #region Data Structures
    #endregion

    #region Private Methods
    private void load_data_to_cbo_bo_tinh()
    {
        try
        {
            DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();
            US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "Where id_loai_don_vi = " + ID_LOAI_DON_VI.BO_TINH);
            m_cbo_bo_tinh.DataSource = v_ds_dm_don_vi.DM_DON_VI;
            m_cbo_bo_tinh.DataValueField = CIPConvert.ToStr(DM_DON_VI.ID);
            m_cbo_bo_tinh.DataTextField = CIPConvert.ToStr(DM_DON_VI.TEN_DON_VI);
            m_cbo_bo_tinh.DataBind();
            load_data_to_cbo_don_vi_quan_ly();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    private void export_excel()
        {
            decimal v_dc_id_trang_thai = CIPConvert.ToDecimal(Request.QueryString["ID"]);
            string v_str_bo_tinh = m_cbo_bo_tinh.SelectedItem.Text;
            string v_str_don_vi_chu_quan = m_cbo_don_vi_quan_ly.SelectedItem.Text;
            decimal v_dc_id_dv_su_dung = CIPConvert.ToDecimal(m_cbo_don_vi_su_dung.SelectedValue);
            string v_str_output_file ="";
            f400_bao_cao_danh_muc_o_to v_f400_bc_dm_oto = new f400_bao_cao_danh_muc_o_to();
            if (CIPConvert.ToDecimal(Request.QueryString["ID"].ToString())==584) 
            {
                v_f400_bc_dm_oto.expor_excel(f400_bao_cao_danh_muc_o_to.eFormMode.KE_KHAI_O_TO
                                        , v_str_bo_tinh
                                        , v_str_don_vi_chu_quan
                                        , v_dc_id_dv_su_dung
                                        , ref v_str_output_file);
            }
            else if (CIPConvert.ToDecimal(Request.QueryString["ID"].ToString())==581)
            {
                v_f400_bc_dm_oto.expor_excel(f400_bao_cao_danh_muc_o_to.eFormMode.O_TO_DE_NGHI_XU_LY
                                        , v_str_bo_tinh
                                        , v_str_don_vi_chu_quan
                                        , v_dc_id_dv_su_dung
                                        , ref v_str_output_file);
            }
            Response.Clear();    
            v_str_output_file = "/QuanLyTaiSan/" + v_str_output_file;        
            Response.Redirect(v_str_output_file, false);
        }
    private void load_data_to_cbo_don_vi_quan_ly()
    {

        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        if (m_cbo_bo_tinh.SelectedValue == null)
            return;
        else
        {
            string v_id_bo_tinh = m_cbo_bo_tinh.SelectedValue;

            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = " + ID_LOAI_DON_VI.DV_CHU_QUAN + "and ID_DON_VI_CAP_TREN LIKE '%"
                + v_id_bo_tinh + "%'");
            if (v_ds_dm_don_vi.DM_DON_VI.Count != 0)
            {
                m_cbo_don_vi_quan_ly.DataSource = v_ds_dm_don_vi.DM_DON_VI;
                m_cbo_don_vi_quan_ly.DataTextField = "TEN_DON_VI";
                m_cbo_don_vi_quan_ly.DataValueField = "ID";
                m_cbo_don_vi_quan_ly.DataBind();
                // m_cbo_don_vi_chu_quan.Items.Insert(0, new ListItem("Tất cả đơn vị trực thuộc", ""));
                load_data_to_cbo_don_vi_su_dung();
            }
            else
            {
                m_cbo_don_vi_quan_ly.Items.Clear();
                m_cbo_don_vi_su_dung.Items.Clear();
            }
        }
    }
    private void load_data_to_cbo_don_vi_su_dung()
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        string v_id_don_vi_chu_quan = m_cbo_don_vi_quan_ly.SelectedValue;
        v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = 576 and ID_DON_VI_CAP_TREN =" + v_id_don_vi_chu_quan);
        m_cbo_don_vi_su_dung.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_cbo_don_vi_su_dung.DataTextField = "TEN_DON_VI";
        m_cbo_don_vi_su_dung.DataValueField = "ID";
        m_cbo_don_vi_su_dung.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["ID"] == null)
            {
                if (!this.IsPostBack)
                {
                    load_cbo_trang_thai();
                    load_data_to_cbo_bo_tinh();
                    load_data_2_grid();                    
                }
            }
            else
            {
                if (!this.IsPostBack)
                {
                    m_cbo_trang_thai.Visible = false;
                    m_lbl_trang_thai.Visible = false;
                    load_data_to_cbo_bo_tinh();
                    load_data_to_cbo_don_vi_quan_ly();
                    load_data_to_cbo_don_vi_su_dung();
                    load_data_2_grid_by_command();
                }                
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
            string v_str_trang_thai = Request.QueryString["ID"].ToString();
            string v_str_tu_khoa = m_txt_tu_khoa.Text.Trim();
            m_us_dm_oto.FillDatasetSearch(m_ds_dm_oto, v_str_tu_khoa,v_str_trang_thai);
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

            decimal v_dc_id_don_vi_bo_tinh = 0;
            if (m_cbo_bo_tinh.SelectedValue != "")
                v_dc_id_don_vi_bo_tinh = CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue);

            decimal v_dc_id_don_vi_quan_ly = 0;
            if (m_cbo_don_vi_quan_ly.SelectedValue != "")
                v_dc_id_don_vi_quan_ly = CIPConvert.ToDecimal(m_cbo_don_vi_quan_ly.SelectedValue);

            decimal v_dc_id_don_vi_sd = 0;
            if( m_cbo_don_vi_su_dung.SelectedValue != "")
                v_dc_id_don_vi_sd = CIPConvert.ToDecimal(m_cbo_don_vi_su_dung.SelectedValue);

            decimal v_dc_id_trang_thai = CIPConvert.ToDecimal(Request.QueryString["ID"]);
            m_us_dm_oto.FillDatasetBySearch(m_ds_dm_oto, v_str_tu_khoa, v_dc_id_trang_thai, v_dc_id_don_vi_bo_tinh, v_dc_id_don_vi_quan_ly, v_dc_id_don_vi_sd);
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
            System.Threading.Thread.Sleep(2000);
            if (Request.QueryString["ID"] != null)
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
    protected void m_cbo_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            load_data_to_cbo_don_vi_quan_ly();

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    protected void m_cbo_don_vi_quan_ly_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            load_data_to_cbo_don_vi_su_dung();

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["ID"] != null)
            {
                load_data_2_grid_by_command();
            }
            else
                load_data_2_grid();
                export_excel();
        }
        catch (Exception v_e)
        {

            throw v_e;
        }
    }
}


//cach goi ra
//kiem tra

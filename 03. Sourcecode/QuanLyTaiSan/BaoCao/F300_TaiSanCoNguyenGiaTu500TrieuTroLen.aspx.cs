using System;
using System.Collections.Generic;
using WebDS;
using WebUS;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using IP.Core.IPBusinessService;
using IP.Core.IPData;
using IP.Core.IPUserService;
using WebDS.CDBNames;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_data();
            load_data_to_cbo_trang_thai();
        }

    }

    #region member
    DS_CM_DM_TU_DIEN m_ds_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    US_CM_DM_TU_DIEN m_us_dm_tu_dien = new US_CM_DM_TU_DIEN();

    DS_DM_DON_VI m_ds_dm_don_vi = new DS_DM_DON_VI();
    US_DM_DON_VI m_us_dm_don_vi = new US_DM_DON_VI();

    DS_DM_DAT m_ds_dm_dat = new DS_DM_DAT();
    US_DM_DAT m_us_dm_dat = new US_DM_DAT();

    DS_DM_NHA m_ds_dm_nha = new DS_DM_NHA();
    US_DM_NHA m_us_dm_nha = new US_DM_NHA();

    DS_DM_OTO m_ds_dm_oto = new DS_DM_OTO();
    US_DM_OTO m_us_dm_oto = new US_DM_OTO();




    #endregion

    #region private method

    private void load_data_to_grid()
    {

    }

    private void load_data_to_cbo_bo_tinh()
    {
        try
        {
            m_us_dm_don_vi.FillDataset(m_ds_dm_don_vi, "Where id_loai_don_vi=574");
            m_cbo_bo_tinh.DataSource = m_ds_dm_don_vi.DM_DON_VI;
            m_cbo_bo_tinh.DataValueField = CIPConvert.ToStr(DM_DON_VI.ID);
            m_cbo_bo_tinh.DataTextField = CIPConvert.ToStr(DM_DON_VI.TEN_DON_VI);
            m_cbo_bo_tinh.DataBind();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }

    private void load_data_to_cbo_don_vi_chu_quan()
    {
        string v_id_bo_tinh = m_cbo_bo_tinh.SelectedValue;
        m_us_dm_don_vi.FillDataset(m_ds_dm_don_vi, "where ID_LOAI_DON_VI = 575 and ID_DON_VI_CAP_TREN LIKE '%"
            + v_id_bo_tinh + "%'");
        m_cbo_don_vi_chu_quan.DataSource = m_ds_dm_don_vi.DM_DON_VI;
        m_cbo_don_vi_chu_quan.DataTextField = "TEN_DON_VI";
        m_cbo_don_vi_chu_quan.DataValueField = "ID";
        m_cbo_don_vi_chu_quan.DataBind();
        m_cbo_don_vi_chu_quan.Items.Insert(0, new ListItem("Tất cả đơn vị trực thuộc", ""));
    }
    private void load_data_to_cbo_don_vi_su_dung()
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        string v_id_don_vi_chu_quan = m_cbo_don_vi_chu_quan.SelectedValue;
        v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = 576 and ID_DON_VI_CAP_TREN LIKE '%" + v_id_don_vi_chu_quan
            + "%'");
        m_cbo_don_vi_su_dung_tai_san.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_cbo_don_vi_su_dung_tai_san.DataTextField = "TEN_DON_VI";
        m_cbo_don_vi_su_dung_tai_san.DataValueField = "ID";
        m_cbo_don_vi_su_dung_tai_san.DataBind();
    }


    private void load_data()
    {
        try
        {
            load_data_to_cbo_bo_tinh();
            //load_data_to_cbo_don_vi_chu_quan();
            //load_data_to_cbo_don_vi_su_dung();
            //load_data_to_grid_nha();
            //load_data_cbo_trang_thai();

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    private void load_data_to_grid_nha()
    {
        try
        {
            string v_id_don_vi_chu_quan = m_cbo_don_vi_chu_quan.SelectedValue;
            string v_id_don_vi_su_dung = m_cbo_don_vi_su_dung_tai_san.SelectedValue;
            string v_id_trang_thai = m_cbo_trang_thai.SelectedValue;
            //m_us_dm_nha.FillDataset(m_ds_dm_nha, "where id_don_vi_su_dung like '%" + v_id_don_vi_su_dung + "%' and id_don_vi_chu_quan like '%" + v_id_don_vi_chu_quan + "%' and id_trang_thai =" + v_id_trang_thai);
            string cmd = "select dm_nha.* from cm_dm_tu_dien join dm_nha on cm_dm_tu_dien.id=dm_nha.id_trang_thai where dm_nha.id_trang_thai in (select id from cm_dm_TU_DIEN where ma_tu_dien='" + m_cbo_trang_thai.SelectedValue + "')";
            System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(cmd);
            m_us_dm_nha.FillDatasetByCommand(m_ds_dm_nha, command);

            m_grv_nha.DataSource = m_ds_dm_nha.DM_NHA;
            m_grv_nha.DataBind();

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    private void load_data_to_grid_oto()
    {
        try
        {
            string v_id_don_vi_chu_quan = m_cbo_don_vi_chu_quan.SelectedValue;
            string v_id_don_vi_su_dung = m_cbo_don_vi_su_dung_tai_san.SelectedValue;
            string v_id_trang_thai = m_cbo_trang_thai.SelectedValue;

            //m_us_dm_oto.FillDataset(m_ds_dm_oto, "where id_don_vi_su_dung=" + v_id_don_vi_su_dung + " and id_don_vi_chu_quan=" + v_id_don_vi_chu_quan + " and id_trang_thai=" + v_id_trang_thai);
            string cmd = "select dm_oto.* from cm_dm_tu_dien join dm_oto on cm_dm_tu_dien.id=dm_oto.id_trang_thai where dm_oto.id_trang_thai in (select id from cm_dm_TU_DIEN where ma_tu_dien='" + m_cbo_trang_thai.SelectedValue + "')";
            System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(cmd);
            m_us_dm_oto.FillDatasetByCommand(m_ds_dm_oto, command);

            m_grv_oto.DataSource = m_ds_dm_oto.DM_OTO;
            m_grv_oto.DataBind();

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }

    private void load_data_to_cbo_trang_thai()
    {
        try
        {
            DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
            //string cmd = "select distinct ma_tu_dien from cm_dm_tu_dien where id_loai_tu_dien=6 or id_loai_tu_dien=7 or id_loai_tu_dien=8";
            //System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(cmd);  
            //"select * from DM_TAI_SAN_KHAC Where TEN_TAI_SAN like '%"+m_txt_tim_kiem.Text+
            //"%' or KY_HIEU like '%"+m_txt_tim_kiem.Text+
            //"%' or NUOC_SAN_XUAT like '%"+m_txt_tim_kiem.Text+
            //"%' or NAM_SAN_XUAT like '%"+m_txt_tim_kiem.Text+
            //"%' or NAM_SU_DUNG like '%"+m_txt_tim_kiem.Text+
            //"%'";
            v_us_cm_dm_tu_dien.FillDataset(v_ds_cm_dm_tu_dien, "where id_loai_tu_dien=6");

            m_cbo_trang_thai.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_trang_thai.DataValueField = CM_DM_TU_DIEN.MA_TU_DIEN;
            m_cbo_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN;
            m_cbo_trang_thai.DataBind();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }

    private void load_data_to_grid_tai_san_khac()
    {
        try
        {
            string v_id_don_vi_chu_quan = m_cbo_don_vi_chu_quan.SelectedValue;
            string v_id_don_vi_su_dung = m_cbo_don_vi_su_dung_tai_san.SelectedValue;
            string v_id_trang_thai = m_cbo_trang_thai.SelectedValue;
            DS_DM_TAI_SAN_KHAC v_ds_dm_tai_san_khac = new DS_DM_TAI_SAN_KHAC();
            US_DM_TAI_SAN_KHAC v_us_dm_tai_san_khac = new US_DM_TAI_SAN_KHAC();
            //v_us_dm_tai_san_khac.FillDataset(v_ds_dm_tai_san_khac, "where id_don_vi_su_dung=" + v_id_don_vi_su_dung + " and id_don_vi_chu_quan=" + v_id_don_vi_chu_quan + " and id_trang_thai=" + v_id_trang_thai);
            string cmd = "select dm_tai_san_khac.* from cm_dm_tu_dien join dm_tai_san_khac on cm_dm_tu_dien.id=dm_tai_san_khac.id_trang_thai where dm_tai_san_khac.id_trang_thai in (select id from cm_dm_TU_DIEN where ma_tu_dien='" + m_cbo_trang_thai.SelectedValue + "')";
            System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(cmd);
            v_us_dm_tai_san_khac.FillDatasetByCommand(v_ds_dm_tai_san_khac, command);
            m_grv_tai_san_khac.DataSource = v_ds_dm_tai_san_khac.DM_TAI_SAN_KHAC;
            m_grv_tai_san_khac.DataBind();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }

    #endregion


    protected void m_cbo_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            load_data_to_cbo_don_vi_chu_quan();

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    protected void m_cbo_don_vi_chu_quan_SelectedIndexChanged(object sender, EventArgs e)
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


    protected void m_cmd_loc_du_lieu_Click(object sender, EventArgs e)
    {
        try
        {
            load_data_to_grid_nha();
            load_data_to_grid_oto();
            load_data_to_grid_tai_san_khac();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }


    protected void m_grv_nha_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            load_data_to_grid_nha();
            m_grv_nha.PageIndex = e.NewPageIndex;
            m_grv_nha.DataBind();

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }


    protected void m_grv_oto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            load_data_to_grid_oto();
            m_grv_oto.PageIndex = e.NewPageIndex;
            m_grv_oto.DataBind();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    protected void m_grv_tai_san_khac_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            load_data_to_grid_tai_san_khac();
            m_grv_tai_san_khac.PageIndex = e.NewPageIndex;
            m_grv_tai_san_khac.DataBind();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
}
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
using QltsForm;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_data_to_cbo_bo_tinh();
            load_data_to_cbo_don_vi_chu_quan(m_cbo_bo_tinh.SelectedValue);
            load_data_to_cbo_don_vi_su_dung(m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
            load_data_to_cbo_trang_thai();

        }

    }

    #region member
    DS_CM_DM_TU_DIEN m_ds_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    US_CM_DM_TU_DIEN m_us_dm_tu_dien = new US_CM_DM_TU_DIEN();





    #endregion

    #region private method


    private void export_excel()
    {
        string v_str_bo_tinh = m_cbo_bo_tinh.SelectedItem.Text;
        string v_str_don_vi_chu_quan = m_cbo_don_vi_chu_quan.SelectedItem.Text;
        decimal v_dc_id_dv_su_dung = CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue);
        string v_str_output_file = "";
        f401_bao_cao_danh_muc_tai_san_khac v_f401_bc_dm_tai_san_khac = new f401_bao_cao_danh_muc_tai_san_khac();

        v_f401_bc_dm_tai_san_khac.expor_excel(f401_bao_cao_danh_muc_tai_san_khac.eFormMode.KE_KHAI_TAI_SAN_KHAC

                    , v_str_bo_tinh
                    , v_str_don_vi_chu_quan
                    , v_dc_id_dv_su_dung
                    , ref v_str_output_file);



        Response.Clear();
        v_str_output_file = "/QuanLyTaiSan/" + v_str_output_file;
        Response.Redirect(v_str_output_file, false);


    }

    private void load_data_to_cbo_bo_tinh()
    {

        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = " + ID_LOAI_DON_VI.BO_TINH);
        m_cbo_bo_tinh.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_cbo_bo_tinh.DataTextField = "TEN_DON_VI";
        m_cbo_bo_tinh.DataValueField = "ID";
        m_cbo_bo_tinh.DataBind();
        m_cbo_bo_tinh.Items.Insert(0, new ListItem("Tất cả", "-1"));

    }

    private void load_data_to_cbo_don_vi_chu_quan(string ip_str_id_bo_tinh)
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        if (ip_str_id_bo_tinh.Equals("-1"))
        {
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = " + ID_LOAI_DON_VI.DV_CHU_QUAN);
        }
        else
        {
            decimal v_dc_id_bo_tinh = CIPConvert.ToDecimal(ip_str_id_bo_tinh);
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = " + ID_LOAI_DON_VI.DV_CHU_QUAN
            + " AND ID_DON_VI_CAP_TREN = " + v_dc_id_bo_tinh);
        }

        m_cbo_don_vi_chu_quan.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_cbo_don_vi_chu_quan.DataTextField = "TEN_DON_VI";
        m_cbo_don_vi_chu_quan.DataValueField = "ID";
        m_cbo_don_vi_chu_quan.DataBind();
        m_cbo_don_vi_chu_quan.Items.Insert(0, new ListItem("Tất cả", "-1"));

    }
    private void load_data_to_cbo_don_vi_su_dung(string ip_str_id_don_vi_chu_quan, string ip_str_id_bo_tinh)
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        if (!ip_str_id_don_vi_chu_quan.Equals("-1"))
        {
            decimal v_dc_id_don_vi_chu_quan = CIPConvert.ToDecimal(ip_str_id_don_vi_chu_quan);
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_DON_VI_CAP_TREN = " + v_dc_id_don_vi_chu_quan + " or ID = " + v_dc_id_don_vi_chu_quan);
        }
        else if (!ip_str_id_bo_tinh.Equals("-1"))
        {
            decimal v_dc_id_bo_tinh = CIPConvert.ToDecimal(ip_str_id_bo_tinh);
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_DON_VI_CAP_TREN in (select ID from DM_DON_VI where ID_DON_VI_CAP_TREN = "
                + v_dc_id_bo_tinh + ") or ID_DON_VI_CAP_TREN = " + v_dc_id_bo_tinh);
        }
        else
        {
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "WHERE ID_LOAI_DON_VI IN (" + ID_LOAI_DON_VI.DV_SU_DUNG + "," + ID_LOAI_DON_VI.DV_CHU_QUAN + ")");
        }

        m_cbo_don_vi_su_dung_tai_san.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_cbo_don_vi_su_dung_tai_san.DataTextField = "TEN_DON_VI";
        m_cbo_don_vi_su_dung_tai_san.DataValueField = "ID";
        m_cbo_don_vi_su_dung_tai_san.DataBind();
        m_cbo_don_vi_su_dung_tai_san.Items.Insert(0, new ListItem("Tất cả", "-1"));
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

            v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC, CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);

            m_cbo_trang_thai.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_trang_thai.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN;
            m_cbo_trang_thai.SelectedValue = CIPConvert.ToStr(ID_TRANG_THAI_TAI_SAN_KHAC.DANG_SU_DUNG);
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
            if (v_id_don_vi_su_dung.Equals("-1"))
            {
                v_us_dm_tai_san_khac.FillDataset(v_ds_dm_tai_san_khac, "where id_trang_thai = " + v_id_trang_thai);



            }
            else if (!v_id_don_vi_su_dung.Equals("-1"))
            {
                if (v_id_don_vi_chu_quan.Equals("-1"))
                {
                    v_us_dm_tai_san_khac.FillDataset(v_ds_dm_tai_san_khac, "where id_trang_thai = " + v_id_trang_thai + " and id_don_vi_su_dung = " + v_id_don_vi_su_dung);
                }
                else
                {
                    v_us_dm_tai_san_khac.FillDataset(v_ds_dm_tai_san_khac, "where id_don_vi_chu_quan = " + v_id_don_vi_chu_quan + " and id_don_vi_su_dung = " + v_id_don_vi_su_dung + " and id_trang_thai = " + v_id_trang_thai);
                }

            }
            //// v_us_dm_tai_san_khac.FillDataset(v_ds_dm_tai_san_khac, "where id_don_vi_su_dung=" + v_id_don_vi_su_dung + " and id_don_vi_chu_quan=" + v_id_don_vi_chu_quan + " and id_trang_thai=" + v_id_trang_thai);
            ////string cmd = "select dm_tai_san_khac.* from cm_dm_tu_dien join dm_tai_san_khac on cm_dm_tu_dien.id=dm_tai_san_khac.id_trang_thai where ( dm_tai_san_khac.nguon_ns+dm_tai_san_khac.nguon_khac >=500000000) and dm_tai_san_khac.id_trang_thai in (select id from cm_dm_TU_DIEN where ma_tu_dien='" + m_cbo_trang_thai.SelectedValue + "')";
            //System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(cmd);
            //v_us_dm_tai_san_khac.FillDatasetByCommand(v_ds_dm_tai_san_khac, command);
            if (v_ds_dm_tai_san_khac.DM_TAI_SAN_KHAC.Count != 0)
            {
                m_grv_tai_san_khac.DataSource = v_ds_dm_tai_san_khac.DM_TAI_SAN_KHAC;
                m_grv_tai_san_khac.DataBind();
            }
            else
            {
                m_grv_tai_san_khac.Visible = false;
                m_lbl_thong_bao.Text = "Không có dữ liệu phù hợp";
            }
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
            m_lbl_mess.Text = "";
            m_lbl_thong_bao.Text = "";
            m_grv_tai_san_khac.Visible = false;

            load_data_to_cbo_don_vi_chu_quan(m_cbo_bo_tinh.SelectedValue);
            load_data_to_cbo_don_vi_su_dung(m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
            //load_data_to_cbo_dia_chi(m_cbo_don_vi_su_dung_tai_san.SelectedValue, m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
            //load_data_to_cbo_don_vi_su_dung(m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
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
            m_lbl_thong_bao.Text = "";
            m_lbl_mess.Text = "";
            m_grv_tai_san_khac.Visible = false;
            //load_data_to_cbo_don_vi_chu_quan(m_cbo_bo_tinh.SelectedValue);
            load_data_to_cbo_don_vi_su_dung(m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
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
            m_lbl_thong_bao.Text = "";
            m_grv_tai_san_khac.Visible = true;
            load_data_to_grid_tai_san_khac();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }

    //protected void m_grv_nha_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        load_data_to_grid_nha();
    //        m_grv_nha.PageIndex = e.NewPageIndex;
    //        m_grv_nha.DataBind();

    //    }
    //    catch (System.Exception ex)
    //    {
    //        CSystemLog_301.ExceptionHandle(ex);
    //    }
    //}


    //protected void m_grv_oto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        load_data_to_grid_oto();
    //        m_grv_oto.PageIndex = e.NewPageIndex;
    //        m_grv_oto.DataBind();
    //    }
    //    catch (System.Exception ex)
    //    {
    //        CSystemLog_301.ExceptionHandle(ex);
    //    }
    //}
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

    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        try
        {
            export_excel();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
}
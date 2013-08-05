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
    #region Member
    US_DM_TAI_SAN_KHAC m_us_tai_san_khac = new US_DM_TAI_SAN_KHAC();   
    DS_DM_TAI_SAN_KHAC m_ds_tai_san_khac = new DS_DM_TAI_SAN_KHAC();
    US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
    DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
    US_CM_DM_TU_DIEN m_us_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_tu_dien = new DS_CM_DM_TU_DIEN();
    #endregion
    #region Data Structures
    #endregion
    #region Private Methods
    private void load_data_2_grid()
    {
        try
        {
            m_us_tai_san_khac.FillDataset(m_ds_tai_san_khac);
            m_grv_tai_san_khac.DataSource = m_ds_tai_san_khac.DM_TAI_SAN_KHAC;
            m_grv_tai_san_khac.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_data_2_cbo_bo_tinh()
    {
        m_ds_don_vi.DM_DON_VI.Clear();
        m_us_don_vi.FillDataset(m_ds_don_vi, "Where ID_LOAI_DON_VI=574");
        m_cbo_bo_tinh.DataSource = m_ds_don_vi.DM_DON_VI;
        m_cbo_bo_tinh.DataTextField = DM_DON_VI.TEN_DON_VI;
        m_cbo_bo_tinh.DataValueField = DM_DON_VI.ID;
        m_cbo_bo_tinh.DataBind();
    }
    private void load_data_2_cbo_don_vi_chu_quan()
    {
        m_ds_don_vi.DM_DON_VI.Clear();
        m_us_don_vi.FillDataset(m_ds_don_vi, "Where ID_LOAI_DON_VI = 575");
        m_cbo_don_vi_chu_quan.DataSource = m_ds_don_vi.DM_DON_VI;
        m_cbo_don_vi_chu_quan.DataTextField = DM_DON_VI.TEN_DON_VI;
        m_cbo_don_vi_chu_quan.DataValueField = DM_DON_VI.ID;
        m_cbo_don_vi_chu_quan.DataBind();
    }
    private void load_data_2_cbo_don_vi_su_dung()
    {
        m_ds_don_vi.DM_DON_VI.Clear();
        m_us_don_vi.FillDataset(m_ds_don_vi, "Where ID_LOAI_DON_VI = 576");
        m_cbo_don_vi_su_dung.DataSource = m_ds_don_vi.DM_DON_VI;
        m_cbo_don_vi_su_dung.DataTextField = DM_DON_VI.TEN_DON_VI;
        m_cbo_don_vi_su_dung.DataValueField = DM_DON_VI.ID;
        m_cbo_don_vi_su_dung.DataBind();
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
    private void form_2_us_object()
    {
        m_us_tai_san_khac.dcID_DON_VI_CHU_QUAN = CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue);
        m_us_tai_san_khac.dcID_DON_VI_SU_DUNG = CIPConvert.ToDecimal(m_cbo_don_vi_su_dung.SelectedValue);
        m_us_tai_san_khac.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_cbo_trang_thai_tai_san.SelectedValue);
        m_us_tai_san_khac.dcID_LOAI_TAI_SAN = CIPConvert.ToDecimal("4");
        m_us_tai_san_khac.datNGAY_CAP_NHAT_CUOI = DateTime.Now.Date;
        m_us_tai_san_khac.strMA_TAI_SAN = m_txt_ma_tai_san.Text.Trim();
        m_us_tai_san_khac.strTEN_TAI_SAN = m_txt_ten_tai_san.Text.Trim();
        m_us_tai_san_khac.strKY_HIEU = m_txt_ky_hieu.Text.Trim();
        m_us_tai_san_khac.strNUOC_SAN_XUAT = m_txt_nuoc_sx.Text.Trim();
        m_us_tai_san_khac.dcNAM_SAN_XUAT = CIPConvert.ToDecimal(m_txt_nam_sx.Text.Trim());
        m_us_tai_san_khac.dcNAM_SU_DUNG = CIPConvert.ToDecimal(m_txt_ngay_su_dung.Text.Trim());
        m_us_tai_san_khac.dcNGUON_NS = CIPConvert.ToDecimal(m_txt_nguyen_gia_nguon_ns.Text.Trim());
        m_us_tai_san_khac.dcNGUON_KHAC = CIPConvert.ToDecimal(m_txt_nguyen_gia_nguon_khac.Text.Trim());
        m_us_tai_san_khac.dcGIA_TRI_CON_LAI = CIPConvert.ToDecimal(m_txt_gia_tri_con_lai.Text.Trim());
        m_us_tai_san_khac.dcQLNN = CIPConvert.ToDecimal(m_txt_quan_ly_nha_nuoc.Text.Trim());
        m_us_tai_san_khac.dcKINH_DOANH = CIPConvert.ToDecimal(m_txt_kinh_doanh.Text.Trim());
        m_us_tai_san_khac.dcKHONG_KINH_DOANH = CIPConvert.ToDecimal(m_txt_khong_kinh_doanh.Text.Trim());
        m_us_tai_san_khac.dcHD_KHAC = CIPConvert.ToDecimal(m_txt_khac.Text.Trim());
    }
    private void us_object_2_form(US_DM_TAI_SAN_KHAC ip_us_m_dm_tai_san_khac)
    {
        hdf_id.Value = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcID);
        m_txt_ten_tai_san.Text = ip_us_m_dm_tai_san_khac.strTEN_TAI_SAN;
        m_cbo_don_vi_chu_quan.SelectedValue = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcID_DON_VI_CHU_QUAN);
        m_cbo_don_vi_su_dung.SelectedValue = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcID_DON_VI_SU_DUNG);
        m_cbo_trang_thai_tai_san.SelectedValue = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcID_TRANG_THAI);
        m_txt_ma_tai_san.Text = ip_us_m_dm_tai_san_khac.strMA_TAI_SAN;
        m_txt_ky_hieu.Text = ip_us_m_dm_tai_san_khac.strKY_HIEU;
        m_txt_nuoc_sx.Text = ip_us_m_dm_tai_san_khac.strNUOC_SAN_XUAT;
        m_txt_nam_sx.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcNAM_SAN_XUAT);
        m_txt_ngay_su_dung.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcNAM_SU_DUNG);
        m_txt_nguyen_gia_nguon_ns.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcNGUON_NS, "#,##0.00");
        m_txt_nguyen_gia_nguon_khac.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcNGUON_KHAC, "#,##0.00");
        m_txt_gia_tri_con_lai.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcGIA_TRI_CON_LAI, "#,##0.00");
        m_txt_quan_ly_nha_nuoc.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcQLNN);
        m_txt_kinh_doanh.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcKINH_DOANH);
        m_txt_khong_kinh_doanh.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcKHONG_KINH_DOANH);
        m_txt_khac.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcHD_KHAC);
    }
    private void load_data_2_us_update(int ip_i_stt_row)
    {
        decimal dc_id_tai_san_khac = CIPConvert.ToDecimal(m_grv_tai_san_khac.DataKeys[ip_i_stt_row].Value);
        hdf_id.Value = CIPConvert.ToStr(dc_id_tai_san_khac);
        m_us_tai_san_khac = new US_DM_TAI_SAN_KHAC(dc_id_tai_san_khac);
    }
    private void load_data_trang_thai()
    {
        DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();

        v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds("TRANG_THAI_NHA", CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);
        m_cbo_trang_thai_tai_san.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
        m_cbo_trang_thai_tai_san.DataTextField = "TEN";
        m_cbo_trang_thai_tai_san.DataValueField = "ID";
        m_cbo_trang_thai_tai_san.DataBind();
    }
    private void reset_control()
    {
        m_txt_ma_tai_san.Text = "";
        m_txt_ky_hieu.Text = "";
        m_txt_nuoc_sx.Text = "";
        m_txt_nam_sx.Text = "";
        m_txt_ngay_su_dung.Text = "";
        m_txt_nguyen_gia_nguon_ns.Text = "";
        m_txt_nguyen_gia_nguon_khac.Text = "";
        m_txt_gia_tri_con_lai.Text = "";
        m_txt_quan_ly_nha_nuoc.Text = "";
        m_txt_kinh_doanh.Text = "";
        m_txt_khong_kinh_doanh.Text = "";
        m_txt_khac.Text = "";
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                load_data_2_grid();
                load_data_2_cbo_bo_tinh();
                load_data_2_cbo_trang_thai_tai_san();
            }
            load_data_2_cbo_don_vi_chu_quan();
            load_data_2_cbo_don_vi_su_dung();
        }
        catch (Exception v_e)
        {
            this.Response.Write(v_e.ToString());
        }
    }
   
    protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
    {
        try
        {
            if (hdf_id.Value.Trim().Equals(""))
            {
                m_lbl_mess.Visible = true;
                m_lbl_mess.Text = "Chua chon dong de cap nhat";
                return;
            }
            form_2_us_object(); 
            m_us_tai_san_khac.dcID = CIPConvert.ToDecimal(hdf_id.Value);
            m_us_tai_san_khac.Update();
            load_data_2_grid();
            hdf_id.Value = "";
            reset_control();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    protected void m_grv_tai_san_khac_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            load_data_2_us_update(e.RowIndex);
            us_object_2_form(m_us_tai_san_khac);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            form_2_us_object();
            m_us_tai_san_khac.Insert();
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    protected void m_cbo_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        m_ds_don_vi.DM_DON_VI.Clear();
        m_us_don_vi.FillDataset(m_ds_don_vi, "Where ID_DON_VI_CAP_TREN = "+m_cbo_bo_tinh.SelectedValue+"");
        m_cbo_don_vi_chu_quan.DataSource = m_ds_don_vi.DM_DON_VI;
        m_cbo_don_vi_chu_quan.DataTextField = DM_DON_VI.TEN_DON_VI;
        m_cbo_don_vi_chu_quan.DataValueField = DM_DON_VI.ID;
        m_cbo_don_vi_chu_quan.DataBind();
    }
    protected void m_cbo_don_vi_chu_quan_SelectedIndexChanged(object sender, EventArgs e)
    {
        m_ds_don_vi.DM_DON_VI.Clear();
        m_us_don_vi.FillDataset(m_ds_don_vi, "Where ID_DON_VI_CAP_TREN = " + m_cbo_don_vi_chu_quan.SelectedValue + "");
        m_cbo_don_vi_su_dung.DataSource = m_ds_don_vi.DM_DON_VI;
        m_cbo_don_vi_su_dung.DataTextField = DM_DON_VI.TEN_DON_VI;
        m_cbo_don_vi_su_dung.DataValueField = DM_DON_VI.ID;
        m_cbo_don_vi_su_dung.DataBind();
    }
    protected void m_grv_tai_san_khac_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            decimal dc_id_tai_san_khac = CIPConvert.ToDecimal(m_grv_tai_san_khac.DataKeys[e.RowIndex].Value);
            m_us_tai_san_khac.DeleteByID(dc_id_tai_san_khac);
            load_data_2_grid();
            m_lbl_mess.Text = "Xoa thanh cong";
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        m_us_tai_san_khac.search(m_txt_tim_kiem.Text, m_ds_tai_san_khac);
        m_grv_tai_san_khac.DataSource = m_ds_tai_san_khac.DM_TAI_SAN_KHAC;
        m_grv_tai_san_khac.DataBind();
    }
    protected void m_grv_tai_san_khac_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        m_grv_tai_san_khac.PageIndex = e.NewPageIndex;
        load_data_2_grid();
    }
}
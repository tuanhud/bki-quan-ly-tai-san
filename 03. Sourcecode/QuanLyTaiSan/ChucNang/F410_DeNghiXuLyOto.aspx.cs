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


public partial class ChucNang_F410_DeNghiXuLyOto : System.Web.UI.Page
{
    #region Members
    private US_DM_OTO m_us_dm_oto = new US_DM_OTO();
    private string m_str_id_checked = "";

    
    #endregion

    #region Public Interfaces
    #endregion

    #region Private Methods
    private void load_data_bo_tinh()
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = " + ID_LOAI_DON_VI.BO_TINH);
        m_ddl_bo_tinh.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_ddl_bo_tinh.DataTextField = "TEN_DON_VI";
        m_ddl_bo_tinh.DataValueField = "ID";
        m_ddl_bo_tinh.DataBind();
        m_ddl_bo_tinh.Items.Insert(0, new ListItem("Tất cả", "-1"));
    }
    private void load_data_don_vi_chu_quan(string ip_str_id_bo_tinh)
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

        m_ddl_dv_chu_quan.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_ddl_dv_chu_quan.DataTextField = "TEN_DON_VI";
        m_ddl_dv_chu_quan.DataValueField = "ID";
        m_ddl_dv_chu_quan.DataBind();
        m_ddl_dv_chu_quan.Items.Insert(0, new ListItem("Tất cả", "-1"));
    }

    private void load_data_don_vi_su_dung(string ip_str_id_don_vi_chu_quan, string ip_str_id_bo_tinh)
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        if (ip_str_id_bo_tinh.Equals("-1"))
        {
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "WHERE ID_LOAI_DON_VI IN (" + ID_LOAI_DON_VI.DV_SU_DUNG + "," + ID_LOAI_DON_VI.DV_CHU_QUAN + ")");
        }
        else if (ip_str_id_don_vi_chu_quan.Equals("-1"))
        {
            decimal v_dc_id_bo_tinh = CIPConvert.ToDecimal(ip_str_id_bo_tinh);
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_DON_VI_CAP_TREN in (select ID from DM_DON_VI where ID_DON_VI_CAP_TREN = "
                + v_dc_id_bo_tinh + ") or ID_DON_VI_CAP_TREN = " + v_dc_id_bo_tinh);
        }
        else
        {
            decimal v_dc_id_don_vi_chu_quan = CIPConvert.ToDecimal(ip_str_id_don_vi_chu_quan);
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_DON_VI_CAP_TREN = " + v_dc_id_don_vi_chu_quan + " or ID = " + v_dc_id_don_vi_chu_quan);
        }

        m_ddl_dv_sd_ts.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_ddl_dv_sd_ts.DataTextField = "TEN_DON_VI";
        m_ddl_dv_sd_ts.DataValueField = "ID";
        m_ddl_dv_sd_ts.DataBind();
        m_ddl_dv_sd_ts.Items.Insert(0, new ListItem("Tất cả", "-1"));
    }
    private void load_data_trang_thai()
    {
        DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();

        v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_OTO, CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);
        m_ddl_trang_thai_oto.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
        m_ddl_trang_thai_oto.DataTextField = "TEN";
        m_ddl_trang_thai_oto.DataValueField = "ID";
        m_ddl_trang_thai_oto.DataBind();
        m_ddl_trang_thai_oto.SelectedValue = ID_TRANG_THAI_OTO.DANG_SU_DUNG.ToString();
    }
    private void load_data_to_grid(string ip_str_tu_khoa)
    {
        try
        {
            DS_DM_OTO v_ds_dm_oto = new DS_DM_OTO();

            string query = "(TEN_TAI_SAN LIKE N'%" + ip_str_tu_khoa + "%' OR MA_TAI_SAN LIKE N'%" + ip_str_tu_khoa 
                + "%' OR ID LIKE N'%" + ip_str_tu_khoa
                + "%' OR NHAN_HIEU LIKE N'%" + ip_str_tu_khoa
                + "%' OR NUOC_SAN_XUAT LIKE N'%" + ip_str_tu_khoa
                + "%' OR BIEN_KIEM_SOAT LIKE N'%" + ip_str_tu_khoa
                + "%' OR NGUON_GOC_XE LIKE N'%" + ip_str_tu_khoa
                + "%' OR NUOC_SAN_XUAT LIKE N'%" + ip_str_tu_khoa
                + "%' OR CONG_SUAT_XE LIKE N'%" + ip_str_tu_khoa
                + "%' OR SO_CHO_NGOI LIKE N'%" + ip_str_tu_khoa
                + "%') AND "+ DM_OTO.ID_TRANG_THAI + " = " + m_ddl_trang_thai_oto.SelectedValue;

            if (!m_ddl_dv_sd_ts.SelectedValue.Equals("-1"))
            {
                m_us_dm_oto.FillDataset(v_ds_dm_oto, "where " + DM_OTO.ID_DON_VI_SU_DUNG + " = " + m_ddl_dv_sd_ts.SelectedValue
                    + " and " + query);
            }
            else if (!m_ddl_dv_chu_quan.SelectedValue.Equals("-1"))
            {
                m_us_dm_oto.FillDataset(v_ds_dm_oto, "where " + DM_OTO.ID_DON_VI_CHU_QUAN + " = " + m_ddl_dv_chu_quan.SelectedValue
                    + " and " + query);
            }
            else if (!m_ddl_bo_tinh.SelectedValue.Equals("-1"))
            {
                m_us_dm_oto.FillDataset(v_ds_dm_oto, "where " + DM_OTO.ID_DON_VI_CHU_QUAN
                    + " in (select ID from DM_DON_VI where " + DM_DON_VI.ID_DON_VI_CAP_TREN + " = " + m_ddl_bo_tinh.SelectedValue + ")"
                    + " and " + query);
            }
            else
            {
                m_us_dm_oto.FillDataset(v_ds_dm_oto, "where " + query);
            }
            m_grv_dm_oto.DataSource = v_ds_dm_oto.DM_OTO;
            m_grv_dm_oto.DataBind();
            set_trang_thai_cmd();
        }
        catch (Exception v_e)
        {
            //nhớ using Ip.Common
            CSystemLog_301.ExceptionHandle(this, v_e);
        }

    }

    private void set_trang_thai_cmd()
    {
        string v_trang_thai = m_ddl_trang_thai_oto.SelectedValue;
        switch (v_trang_thai)
        {
            case "584":
                m_cmd_de_nghi_xu_ly.Visible = true;
                m_cmd_de_nghi_xu_ly.Enabled = true;
                m_cmd_huy_de_nghi_xu_ly.Visible = false;
                break;
            case "581":
                m_cmd_de_nghi_xu_ly.Visible = false;
                m_cmd_huy_de_nghi_xu_ly.Visible = true;
                m_cmd_huy_de_nghi_xu_ly.Enabled = true;
                break;
            default:
                m_cmd_de_nghi_xu_ly.Visible = false;
                m_cmd_huy_de_nghi_xu_ly.Visible = false;
                break;
        }
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        m_lbl_mess.Text = "";
        if (!IsPostBack)
        {
            load_data_bo_tinh();
            load_data_don_vi_chu_quan(m_ddl_bo_tinh.SelectedValue);
            load_data_don_vi_su_dung(m_ddl_dv_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
            load_data_trang_thai();
            load_data_to_grid("");
            set_trang_thai_cmd();
        }
    }

    protected void m_grv_dm_oto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_dm_oto.PageIndex = e.NewPageIndex;
            load_data_to_grid(m_txt_tim_kiem.Text.Trim());
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
            string v_str_tu_khoa_tim_kiem = m_txt_tim_kiem.Text.Trim();
            load_data_to_grid(m_txt_tim_kiem.Text.Trim());
            set_trang_thai_cmd();
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
            load_data_to_grid("");
            set_trang_thai_cmd();
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
            load_data_to_grid("");
            set_trang_thai_cmd();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    #endregion
    
}
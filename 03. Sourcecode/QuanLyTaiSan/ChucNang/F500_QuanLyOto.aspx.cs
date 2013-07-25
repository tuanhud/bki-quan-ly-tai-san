using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;

using WebUS;
using WebDS;
using WebDS.CDBNames;
using System.Data;

public partial class ChucNang_F500_QuanLyOto : System.Web.UI.Page
{


    #region Members
    US_DM_OTO m_us_dm_oto = new US_DM_OTO();
    DS_DM_OTO m_ds_dm_oto = new DS_DM_OTO();

    US_CM_DM_TU_DIEN m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    DataEntryFormMode m_init_mode = DataEntryFormMode.ViewDataState;
    //private void load_2_cbo_dv_chu_quan()
    //{
    //    try
    //    {
    //        DS_CM_DM_TU_DIEN v_ds_cm_tu_dien = new DS_CM_DM_TU_DIEN();
    //        US_CM_DM_TU_DIEN v_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
    //        // DataRow v_dr_all = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.NewCM_DM_TU_DIENRow();
    //        // Đổ dữ liệu vào DS 
    //        v_us_cm_tu_dien.FillDataset(v_ds_cm_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.TRANG_THAI_GIANG_VIEN); // Đây là lấy theo điều kiện

    //        m_cbo_trang_thai_g_vien.Items.Add(new ListItem("Tất cả", "0"));
    //        for (int i = 0; i < v_ds_cm_tu_dien.CM_DM_TU_DIEN.Rows.Count; i++)
    //        {
    //            m_cbo_trang_thai_g_vien.Items.Add(new ListItem(v_ds_cm_tu_dien.CM_DM_TU_DIEN[i][CM_DM_TU_DIEN.TEN].ToString(), v_ds_cm_tu_dien.CM_DM_TU_DIEN[i][CM_DM_TU_DIEN.ID].ToString()));
    //        }
    //    }

    //    catch (Exception v_e)
    //    {
    //        throw v_e;
    //    }
    //}
    private void load_2_cbo_loaits()
    {
        try
        {
            DS_DM_LOAI_TAI_SAN v_ds_dm_loaits = new DS_DM_LOAI_TAI_SAN();
            US_DM_LOAI_TAI_SAN v_us_dm_loaits = new US_DM_LOAI_TAI_SAN();
            // DataRow v_dr_all = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.NewCM_DM_TU_DIENRow();
            // Đổ dữ liệu vào DS 
            v_us_dm_loaits.FillDataset(v_ds_dm_loaits); // Đây là lấy theo điều kiện

            m_ddl_loai_xe.Items.Add(new ListItem("Tất cả", "0"));
            for (int i = 0; i < v_ds_dm_loaits.DM_LOAI_TAI_SAN.Rows.Count; i++)
            {
                m_ddl_loai_xe.Items.Add(new ListItem(v_ds_dm_loaits.DM_LOAI_TAI_SAN[i][DM_LOAI_TAI_SAN.TEN_LOAI_TAI_SAN].ToString(), v_ds_dm_loaits.DM_LOAI_TAI_SAN[i][DM_LOAI_TAI_SAN.ID].ToString()));
            }
        }

        catch (Exception v_e)
        {
            throw v_e;
        }
    }
   
    private void load_2_cbo_dv_chu_quan()
    {
        try
        {
            DS_DM_DON_VI v_ds_dm_donvi = new DS_DM_DON_VI();
            US_DM_DON_VI v_us_dm_donvi = new US_DM_DON_VI();
            // DataRow v_dr_all = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.NewCM_DM_TU_DIENRow();
            // Đổ dữ liệu vào DS 
            v_us_dm_donvi.FillDataset(v_ds_dm_donvi); // Đây là lấy theo điều kiện

            m_ddl_dv_chu_quan.Items.Add(new ListItem("Tất cả", "0"));
            for (int i = 0; i < v_ds_dm_donvi.DM_DON_VI.Rows.Count; i++)
            {
                m_ddl_dv_chu_quan.Items.Add(new ListItem(v_ds_dm_donvi.DM_DON_VI[i][DM_DON_VI.TEN_DON_VI].ToString(), v_ds_dm_donvi.DM_DON_VI[i][DM_DON_VI.MA_DON_VI].ToString()));
            }
        }

        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_2_cbo_dv_sdts()
    {
        try
        {
            DS_DM_DON_VI v_ds_dm_donvi = new DS_DM_DON_VI();
            US_DM_DON_VI v_us_dm_donvi = new US_DM_DON_VI();
            // DataRow v_dr_all = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.NewCM_DM_TU_DIENRow();
            // Đổ dữ liệu vào DS 
            v_us_dm_donvi.FillDataset(v_ds_dm_donvi, " WHERE ID_DON_VI_CAP_TREN = " + Convert.ToInt32(m_ddl_dv_chu_quan.SelectedValue)); // Đây là lấy theo điều kiện

            m_ddl_dv_sd_ts.Items.Add(new ListItem("Tất cả", "0"));
            for (int i = 0; i < v_ds_dm_donvi.DM_DON_VI.Rows.Count; i++)
            {
                m_ddl_dv_sd_ts.Items.Add(new ListItem(v_ds_dm_donvi.DM_DON_VI[i][DM_DON_VI.TEN_DON_VI].ToString(), v_ds_dm_donvi.DM_DON_VI[i][DM_DON_VI.MA_DON_VI].ToString()));
            }
        }

        catch (Exception v_e)
        {
            throw v_e;
        }
    } 
    protected void Page_Load(object sender, EventArgs e)
    {
        m_lbl_mess.Text = "";
        if (m_init_mode == DataEntryFormMode.UpdateDataState)
        {
            m_cmd_tao_moi.Enabled = false;
        }
        else
        {
            m_cmd_tao_moi.Enabled = true;
        }
        if (!IsPostBack)
        {
            load_data_to_grid();
            load_2_cbo_dv_chu_quan();
            load_2_cbo_dv_sdts();
            load_2_cbo_loaits();
        }
    }
    private void reset_control()
    {
        m_txt_bien_kiem_soat.Text = "";
        m_txt_chuc_danh_sd_xe.Text = "";
        m_txt_cong_suat_xe.Text = "";
        m_txt_gia_tri_con_lai.Text = "";
        m_txt_hd_khac.Text = "";
        m_txt_kinh_doanh.Text = ""; 
        m_txt_khong_kinh_doanh.Text = "";
        m_txt_nam_san_xuat.Text = "";
        m_txt_nguon_goc_xe.Text = "";
        m_txt_nguon_khac.Text = "";
        m_txt_nguon_ns.Text = "";
        m_txt_nuoc_san_xuat.Text = "";
        m_txt_qlnn.Text = "";
        m_txt_tai_trong.Text="";
        m_txt_ten_nhan_hieu.Text="";
        m_txt_tim_kiem.Text = "";
    }
    private void form_2_us_object(US_DM_OTO ip_us_oto)
    {
        ip_us_oto.dcTAI_TRONG = CIPConvert.ToDecimal(m_txt_tai_trong.Text);
        ip_us_oto.datNGAY_CAP_NHAT_CUOI = DateTime.Now;
        ip_us_oto.datNAM_SU_DUNG= m_dt_ngay_su_dung.SelectedDate;
        ip_us_oto.datNAM_SAN_XUAT=CIPConvert.ToDatetime(m_txt_nam_san_xuat.Text);
        ip_us_oto.dcGIA_TRI_CON_LAI = CIPConvert.ToDecimal(m_txt_gia_tri_con_lai.Text);
        ip_us_oto.dcHD_KHAC = CIPConvert.ToDecimal(m_txt_hd_khac.Text);
        ip_us_oto.dcKHONG_KINH_DOANH = CIPConvert.ToDecimal(m_txt_khong_kinh_doanh.Text);
        ip_us_oto.dcKINH_DOANH = CIPConvert.ToDecimal(m_txt_kinh_doanh.Text);
        ip_us_oto.dcNGUON_KHAC = CIPConvert.ToDecimal(m_txt_nguon_khac.Text);
        ip_us_oto.dcNGUON_NS = CIPConvert.ToDecimal(m_txt_nguon_ns.Text);
        ip_us_oto.dcQLNN = CIPConvert.ToDecimal(m_txt_qlnn.Text);
        ip_us_oto.dcID_LOAI_TAI_SAN =CIPConvert.ToDecimal( m_ddl_loai_xe.SelectedItem);
        ip_us_oto.dcID_DON_VI_SU_DUNG = CIPConvert.ToDecimal(m_ddl_dv_sd_ts.SelectedItem);
        ip_us_oto.dcID_DON_VI_CHU_QUAN = CIPConvert.ToDecimal(m_ddl_dv_chu_quan.SelectedItem);
    }

    /// <summary>
    /// Load dữ liệu từ US đổ vào form
    /// </summary>
    /// <param name="ip_dm_noi_dung_thanh_toan"></param>
    private void us_obj_2_form(US_DM_OTO ip_us_oto)
    {
        m_txt_tai_trong.Text=ip_us_oto.dcTAI_TRONG.ToString();
        m_dt_ngay_su_dung.SelectedDate=ip_us_oto.datNAM_SU_DUNG;
        m_txt_nam_san_xuat.Text=ip_us_oto.datNAM_SAN_XUAT.ToString();
        m_txt_gia_tri_con_lai.Text=ip_us_oto.dcGIA_TRI_CON_LAI.ToString();
        m_txt_hd_khac.Text = ip_us_oto.dcHD_KHAC.ToString();
        m_txt_khong_kinh_doanh.Text = ip_us_oto.dcKHONG_KINH_DOANH.ToString();
        m_txt_kinh_doanh.Text=ip_us_oto.dcKINH_DOANH.ToString();
        m_txt_nguon_khac.Text = ip_us_oto.dcNGUON_KHAC.ToString();
        m_txt_nguon_ns.Text=ip_us_oto.dcNGUON_NS.ToString();
        m_txt_qlnn.Text=ip_us_oto.dcQLNN.ToString();
        m_ddl_loai_xe.SelectedValue=ip_us_oto.dcID_LOAI_TAI_SAN.ToString();
        m_ddl_dv_sd_ts.SelectedValue=ip_us_oto.dcID_DON_VI_SU_DUNG.ToString();
        m_ddl_dv_chu_quan.SelectedValue = ip_us_oto.dcID_DON_VI_CHU_QUAN.ToString();
    }

    private void load_data_to_grid()
    {
        try
        {
            // Đổ dữ liệu từ US vào DS
            m_us_dm_oto.FillDataset(m_ds_dm_oto);
            
            // Treo dữ liệu lên lưới
            m_grv_dm_oto.DataSource = m_ds_dm_oto.DM_OTO;
            m_grv_dm_oto.DataBind();

        }
        catch (Exception v_e)
        {
            //nhớ using Ip.Common
            CSystemLog_301.ExceptionHandle(this, v_e);

        }

    }
    #endregion
    private void delete_dm_oto(int ip_i_row_del)
    {
        decimal v_dc_id_oto = CIPConvert.ToDecimal(m_grv_dm_oto.DataKeys[ip_i_row_del].Value);
        m_us_dm_oto.dcID = v_dc_id_oto;
        m_us_dm_oto.DeleteByID(v_dc_id_oto);
        m_lbl_mess.Text = "Xóa bản ghi thành công";
        load_data_to_grid();
    }
    private void load_data_2_us_by_id(int ip_i_id)
    {
        decimal v_dc_id_dm_oto = CIPConvert.ToDecimal(m_grv_dm_oto.DataKeys[ip_i_id].Value);
        hdf_id.Value = v_dc_id_dm_oto.ToString(); 
        US_DM_OTO v_us_dm_oto = new US_DM_OTO(v_dc_id_dm_oto);
        hdf_id.Value = v_us_dm_oto.dcID.ToString();
        // Đẩy us lên form
        us_obj_2_form(v_us_dm_oto);
    }
    private void search_oto(string ip_str_tu_khoa)
    {
        //m_us_dm_oto(ip_str_tu_khoa, m_ds_oto);
        //m_grv_dm_oto.DataSource = m_ds_oto.DM_oto;
        //m_grv_dm_oto.DataBind();
        //if (m_ds_oto.DM_oto.Rows.Count == 0) m_lbl_thong_bao.Text = "Không có môn nào thỏa mãn!";
    }


    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            if (m_init_mode == DataEntryFormMode.UpdateDataState) return;
            form_2_us_object(m_us_dm_oto);
            m_us_dm_oto.Insert();
            m_lbl_mess.Text = "Thêm bản ghi thành công";
            reset_control();
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
    {
        try
        {
            if (hdf_id.Value == "")
            {
                m_lbl_mess.Text = "Bạn phải chọn nội dung cần Cập nhật";
                return;
            }
            form_2_us_object(m_us_dm_oto);
            m_us_dm_oto.dcID = CIPConvert.ToDecimal(hdf_id.Value);
            m_us_dm_oto.Update();
            reset_control();
            m_lbl_mess.Text = "Cập nhật dữ liệu thành công";
            m_grv_dm_oto.EditIndex = -1;
            m_init_mode = DataEntryFormMode.ViewDataState;
            load_data_to_grid();
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            reset_control();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.Equals(this, v_e);
        }
    }

    protected void m_grv_dm_oto_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            delete_dm_oto(e.RowIndex);
        }
        catch (Exception v_e)
        {
            // de su dung CsystemLog_301 bat buoc Site phai dat trong thu muc cap 1. Vi du: DanhMuc/Dictionary.aspx
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_oto_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            m_init_mode = DataEntryFormMode.UpdateDataState;
            m_cmd_tao_moi.Enabled = false;
            m_lbl_mess.Text = "";
            load_data_2_us_by_id(e.NewSelectedIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_oto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_dm_oto.PageIndex = e.NewPageIndex;
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this,v_e);
        }
    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {  
            // Thu thập dữ liệu search
            string v_str_tu_khoa_tim_kiem = m_txt_tim_kiem.Text.Trim();            
            // Search Môn học
            search_oto(v_str_tu_khoa_tim_kiem);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
}
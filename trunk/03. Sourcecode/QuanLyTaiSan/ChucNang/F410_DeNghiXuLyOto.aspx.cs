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
    US_DM_OTO m_us_dm_oto = new US_DM_OTO();
    DS_DM_OTO m_ds_dm_oto = new DS_DM_OTO();

    IP.Core.IPUserService.US_CM_DM_TU_DIEN m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    IP.Core.IPData.DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    DataEntryFormMode m_init_mode = DataEntryFormMode.ViewDataState;

    private void load_2_cbo_bo_tinh()
    {
        try
        {
            US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = 574");
            m_ddl_bo_tinh.DataSource = v_ds_dm_don_vi.DM_DON_VI;
            m_ddl_bo_tinh.DataTextField = "TEN_DON_VI";
            m_ddl_bo_tinh.DataValueField = "ID";
            m_ddl_bo_tinh.DataBind();
        }

        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_2_cbo_dv_chu_quan(string ip_str_id_don_vi_bo_tinh)
    {
        try
        {
            if (ip_str_id_don_vi_bo_tinh == "") return;
            US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = 575 and ID_DON_VI_CAP_TREN LIKE '%"
                + ip_str_id_don_vi_bo_tinh + "%'");
            m_ddl_dv_chu_quan.DataSource = v_ds_dm_don_vi.DM_DON_VI;
            m_ddl_dv_chu_quan.DataTextField = "TEN_DON_VI";
            m_ddl_dv_chu_quan.DataValueField = "ID";
            m_ddl_dv_chu_quan.DataBind();
        }

        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_2_cbo_dv_sdts(string ip_str_id_don_vi_chu_quan)
    {
        try
        {
            if (ip_str_id_don_vi_chu_quan == "") return;
            US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

            string v_id_don_vi_chu_quan = m_ddl_dv_chu_quan.SelectedValue;
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = 576 and ID_DON_VI_CAP_TREN LIKE '%" + ip_str_id_don_vi_chu_quan
                + "%'");
            m_ddl_dv_sd_ts.DataSource = v_ds_dm_don_vi.DM_DON_VI;
            m_ddl_dv_sd_ts.DataTextField = "TEN_DON_VI";
            m_ddl_dv_sd_ts.DataValueField = "ID";
            m_ddl_dv_sd_ts.DataBind();
        }

        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    // Load dữ liệu vào combo trạng thái
    private void load_data_trang_thai()
    {
        try
        {
            DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();

            v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds("TRANG_THAI_OTO", v_ds_cm_dm_tu_dien);
            m_ddl_trang_thai_oto.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_ddl_trang_thai_oto.DataTextField = "TEN";
            m_ddl_trang_thai_oto.DataValueField = "ID";
            m_ddl_trang_thai_oto.DataBind();
        }

        catch (Exception v_e)
        {
            throw v_e;
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        m_lbl_mess.Text = "";
        if (!IsPostBack)
        {
            load_data_to_grid();
            load_2_cbo_bo_tinh();
            load_2_cbo_dv_chu_quan("");
            load_2_cbo_dv_sdts("");
            load_data_trang_thai();
        }
    }
    private void reset_control()
    {
        m_txt_tim_kiem.Text = "";
    }
    private void form_2_us_object(US_DM_OTO ip_us_oto)
    {
        if (!m_hdf_id.Value.Equals(String.Empty))
        {
            ip_us_oto.dcID = CIPConvert.ToDecimal(m_hdf_id.Value);
        }
        ip_us_oto.datNGAY_CAP_NHAT_CUOI = DateTime.Now;
        
        ip_us_oto.datNGAY_CAP_NHAT_CUOI = DateTime.Now;
        ip_us_oto.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_ddl_trang_thai_oto.SelectedValue);
        ip_us_oto.dcID_DON_VI_SU_DUNG = CIPConvert.ToDecimal(m_ddl_dv_sd_ts.SelectedValue);
        ip_us_oto.dcID_DON_VI_CHU_QUAN = CIPConvert.ToDecimal(m_ddl_dv_chu_quan.SelectedValue);
    }

    /// <summary>
    /// Load dữ liệu từ US đổ vào form
    /// </summary>
    /// <param name="ip_dm_noi_dung_thanh_toan"></param>
    private void us_obj_2_form(US_DM_OTO ip_us_oto)
    {

        m_hdf_id.Value = ip_us_oto.dcID.ToString();
        m_ddl_dv_sd_ts.SelectedValue=ip_us_oto.dcID_DON_VI_SU_DUNG.ToString();
        m_ddl_dv_chu_quan.SelectedValue = ip_us_oto.dcID_DON_VI_CHU_QUAN.ToString();
        m_ddl_trang_thai_oto.SelectedValue = ip_us_oto.dcID_TRANG_THAI.ToString();
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
        m_hdf_id.Value = v_dc_id_dm_oto.ToString(); 
        US_DM_OTO v_us_dm_oto = new US_DM_OTO(v_dc_id_dm_oto);
        m_hdf_id.Value = v_us_dm_oto.dcID.ToString();
        // Đẩy us lên form
        us_obj_2_form(v_us_dm_oto);
    }
    private void duyet_oto(string ip_str_tu_khoa)
    {
        
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
            if (m_hdf_id.Value == "")
            {
                m_lbl_mess.Text = "Bạn phải chọn nội dung cần Cập nhật";
                return;
            }
            form_2_us_object(m_us_dm_oto);
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
            duyet_oto(v_str_tu_khoa_tim_kiem);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_ddl_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_2_cbo_dv_chu_quan(m_ddl_bo_tinh.SelectedValue);
        load_2_cbo_dv_sdts(m_ddl_dv_chu_quan.SelectedValue);
    }
    protected void m_ddl_dv_chu_quan_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_2_cbo_dv_sdts(m_ddl_dv_chu_quan.SelectedValue);

    }
    protected void m_ddl_dv_sd_ts_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void m_ddl_loai_xe_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void m_grv_danh_sach_nha_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (!e.CommandName.Equals(String.Empty))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                decimal v_ud_dm_oto_id = CIPConvert.ToDecimal(m_grv_dm_oto.DataKeys[rowIndex].Value);

                switch (e.CommandName)
                {
                    case "EditComp":
                        m_init_mode = DataEntryFormMode.UpdateDataState;
                        load_data_2_us_by_id(rowIndex);
                        load_data_to_grid();
                        break;
                    case "DeleteComp":
                        m_us_dm_oto.DeleteByID(v_ud_dm_oto_id);
                        load_data_to_grid();
                        break;
                }
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }

    }

    protected void m_cmd_de_nghi_xu_ly_Click(object sender, EventArgs e)
    {

    }
}
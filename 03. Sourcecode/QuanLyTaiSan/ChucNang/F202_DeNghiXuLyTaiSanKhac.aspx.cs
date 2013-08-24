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
using QltsForm;
using IP.Core.WinFormControls;
using System.Threading;


public partial class Default2 : System.Web.UI.Page
{
    #region Member
    US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
    DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
    US_DM_TAI_SAN_KHAC m_us_tai_san_khac = new US_DM_TAI_SAN_KHAC();
    DS_DM_TAI_SAN_KHAC m_ds_tai_san_khac = new DS_DM_TAI_SAN_KHAC();
    US_CM_DM_TU_DIEN m_us_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_tu_dien = new DS_CM_DM_TU_DIEN();
    private string m_str_id_checked = "";
    #endregion
    #region Private methods
    private void load_form_data()
    {
        //load_data_bo_tinh();
        //load_data_don_vi_chu_quan(m_cbo_bo_tinh.SelectedValue);
        //load_data_don_vi_su_dung(m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
        //load_data_trang_thai();
        WinFormControls.load_data_to_cbo_loai_hinh_don_vi(
                    WinFormControls.eLOAI_TU_DIEN.LOAI_HINH_DON_VI
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_loai_hinh_don_vi
                    );
        WinFormControls.load_data_to_cbo_bo_tinh(
                    WinFormControls.eTAT_CA.YES
                    , m_cbo_bo_tinh);
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(
            m_cbo_bo_tinh.SelectedValue
            , WinFormControls.eTAT_CA.YES
            , m_cbo_don_vi_chu_quan);
        WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
            m_cbo_loai_hinh_don_vi.SelectedValue
            , m_cbo_don_vi_chu_quan.SelectedValue
            , m_cbo_bo_tinh.SelectedValue
            , WinFormControls.eTAT_CA.YES
            , m_cbo_don_vi_su_dung_tai_san);
        WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC, WinFormControls.eTAT_CA.YES, m_cbo_trang_thai);
        m_cbo_trang_thai.SelectedValue = CIPConvert.ToStr(ID_TRANG_THAI_TAI_SAN_KHAC.DE_NGHI_XU_LY);
        load_data_to_grid();
        set_trang_thai_cmd();
    }

    // Load dữ liệu vào grid
    /*private void load_data_to_grid()
    {
        try
        {
            US_V_DM_TAI_SAN_KHAC m_us_v_tai_san_khac = new US_V_DM_TAI_SAN_KHAC();
            DS_V_DM_TAI_SAN_KHAC m_ds_v_tai_san_khac = new DS_V_DM_TAI_SAN_KHAC();
            US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
            m_us_v_tai_san_khac.FillDataSetLoadDataToGridTaiSanKhacLoaiHinh(CIPConvert.ToStr(m_cbo_loai_hinh_don_vi.SelectedValue),
                        Person.get_user_name()
                        , CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                        , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                        , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                        , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                        , m_ds_v_tai_san_khac);
            m_grv_danh_sach_tai_san_khac.DataSource = m_ds_tai_san_khac;
            m_grv_danh_sach_tai_san_khac.DataBind();

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    */
    private void load_data_to_grid()
    {
        US_V_DM_TAI_SAN_KHAC m_us_v_tai_san_khac = new US_V_DM_TAI_SAN_KHAC();
        DS_V_DM_TAI_SAN_KHAC m_ds_v_tai_san_khac = new DS_V_DM_TAI_SAN_KHAC();
        US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
        m_us_v_tai_san_khac.FillDatasetLoadDataToGridTaiSanKhac_by_tu_khoa(m_txt_tim_kiem.Text.Trim()
                    , CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                    , CIPConvert.ToStr(m_cbo_loai_hinh_don_vi.SelectedValue)
                    , Person.get_user_name()
                    , m_ds_v_tai_san_khac);
        m_grv_danh_sach_tai_san_khac.DataSource = m_ds_v_tai_san_khac.V_DM_TAI_SAN_KHAC;
        m_grv_danh_sach_tai_san_khac.DataBind();
    }

    // Load dữ liệu vào combo bộ tỉnh
    /*private void load_data_bo_tinh()
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

    // Load dữ liệu vào combo đơn vị chủ quản
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

        m_cbo_don_vi_chu_quan.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_cbo_don_vi_chu_quan.DataTextField = "TEN_DON_VI";
        m_cbo_don_vi_chu_quan.DataValueField = "ID";
        m_cbo_don_vi_chu_quan.DataBind();
        m_cbo_don_vi_chu_quan.Items.Insert(0, new ListItem("Tất cả", "-1"));
    }

    // Load dữ liệu vào combo đơn vị sử dụng
    private void load_data_don_vi_su_dung(string ip_str_id_don_vi_chu_quan, string ip_str_id_bo_tinh)
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

    // Load dữ liệu vào đất

    // Load dữ liệu vào combo trạng thái
    private void load_data_trang_thai()
    {
        DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();

        v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC, CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);
        m_cbo_trang_thai.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
        m_cbo_trang_thai.DataTextField = "TEN";
        m_cbo_trang_thai.DataValueField = "ID";
        m_cbo_trang_thai.DataBind();
        m_cbo_trang_thai.SelectedValue = ID_TRANG_THAI_TAI_SAN_KHAC.DANG_SU_DUNG.ToString();
    }
    */
    private void set_trang_thai_cmd()
    {
        string v_trang_thai = m_cbo_trang_thai.SelectedValue;
        switch (v_trang_thai)
        {
            case "588":
                m_cmd_de_nghi_xu_ly.Visible = true;
                m_cmd_de_nghi_xu_ly.Enabled = true;
                m_cmd_huy_de_nghi_xu_ly.Visible = false;
                break;
            case "585":
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
        try
        {
            if (!IsPostBack)
            {
                load_form_data();
            }
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
            Thread.Sleep(2000);
            load_data_to_grid();
            set_trang_thai_cmd();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_danh_sach_tai_san_khac_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_danh_sach_tai_san_khac.PageIndex = e.NewPageIndex;
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_cbo_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            /*load_data_to_cbo_don_vi_chu_quan();
            m_grv_danh_sach_tai_san_khac.Visible = false;*/
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES, m_cbo_don_vi_chu_quan);
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_tai_san);
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
            /*load_data_to_cbo_don_vi_su_dung();
            m_grv_danh_sach_tai_san_khac.Visible = false;*/
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_tai_san);
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }

    protected void m_cbo_don_vi_su_dung_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //load_data_to_grid();  
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_cbo_trang_thai_tai_san_khac_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //load_data_to_grid(); 
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_de_nghi_xu_ly_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in m_grv_danh_sach_tai_san_khac.Rows)
            {
                CheckBox v_checkbox = (CheckBox)row.FindControl("chkItem");
                if (v_checkbox != null)
                {
                    // Nếu checkbox của dòng này được checked thì ta thực hiện 1 số công việc sau
                    if (v_checkbox.Checked)
                    {
                        // Chỗ này là công việc cần thực hiện khi checkbox đc checkded
                        decimal v_id = CIPConvert.ToDecimal(m_grv_danh_sach_tai_san_khac.DataKeys[row.RowIndex].Value);
                        m_us_tai_san_khac = new US_DM_TAI_SAN_KHAC(v_id);
                        m_us_tai_san_khac.dcID_TRANG_THAI = ID_TRANG_THAI_TAI_SAN_KHAC.DE_NGHI_XU_LY;
                        m_us_tai_san_khac.Update();
                    }
                }
            }
            // Hiển thị các ID được checked ra màn hình
            Response.Write(m_str_id_checked);
            Thread.Sleep(2000);
            load_data_to_grid();
            set_trang_thai_cmd();
            m_lbl_mess.Text = "Đã cập nhập thành công";
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
            foreach (GridViewRow row in m_grv_danh_sach_tai_san_khac.Rows)
            {
                CheckBox v_checkbox = (CheckBox)row.FindControl("chkItem");
                if (v_checkbox != null)
                {
                    // Nếu checkbox của dòng này được checked thì ta thực hiện 1 số công việc sau
                    if (v_checkbox.Checked)
                    {
                        // Chỗ này là công việc cần thực hiện khi checkbox đc checkded
                        decimal v_id = CIPConvert.ToDecimal(m_grv_danh_sach_tai_san_khac.DataKeys[row.RowIndex].Value);
                        m_us_tai_san_khac = new US_DM_TAI_SAN_KHAC(v_id);
                        m_us_tai_san_khac.dcID_TRANG_THAI = ID_TRANG_THAI_TAI_SAN_KHAC.DANG_SU_DUNG;
                        m_us_tai_san_khac.Update();
                    }
                }
            }
            // Hiển thị các ID được checked ra màn hình
            Response.Write(m_str_id_checked);
            Thread.Sleep(2000);
            load_data_to_grid();
            set_trang_thai_cmd();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }

    protected void m_cbo_loai_hinh_don_vi_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
    m_cbo_loai_hinh_don_vi.SelectedValue
    , m_cbo_don_vi_chu_quan.SelectedValue.ToString()
    , m_cbo_bo_tinh.SelectedValue.ToString()
    , WinFormControls.eTAT_CA.YES
    , m_cbo_don_vi_su_dung_tai_san
    );
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    #endregion
}
    
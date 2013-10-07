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
        m_lbl_tieu_de.Text = "DANH SÁCH TÀI SẢN KHÁC";
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
        string v_str_thong_tin = " (Có " + m_ds_v_tai_san_khac.V_DM_TAI_SAN_KHAC.Rows.Count + " bản ghi)";
        m_lbl_tieu_de.Text = "DANH SÁCH TÀI SẢN KHÁC";
        m_lbl_tieu_de.Text += v_str_thong_tin;
        m_grv_danh_sach_tai_san_khac.DataBind();
    }

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

    private void clear_message()
    {
        m_lbl_mess.Text = "";
    }
    #endregion
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
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
            clear_message();
            m_lbl_tieu_de.Text = "DANH MỤC TÀI SẢN KHÁC";
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
            clear_message();
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
            clear_message();
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
            clear_message();
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
    protected void m_cmd_de_nghi_xu_ly_Click(object sender, EventArgs e)
    {
        clear_message();
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
        clear_message();
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
            m_lbl_mess.Text = "Đã cập nhập thành công";
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
            clear_message();
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
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            // vì có phân trang, nên nếu muốn xuất all dữ liệu trên lưới (tất cả các trang) thì thê 2 dòng sau:
            m_grv_danh_sach_tai_san_khac.AllowPaging = false;
            load_data_to_grid();  // đây là hàm load lại dữ liệu lên lưới
            // còn nếu chỉ muốn xuất dữ liệu ở Page hiện tại thì không cần 2 dòng trên
            WinformReport.export_gridview_2_excel(
                        m_grv_danh_sach_tai_san_khac
                        , "DS tsk de nghi xu ly.xls"
                        , 0); // 0 và 1 là số thứ tự 2 cột: Sửa, Xóa
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.") {
                CSystemLog_301.ExceptionHandle(ex);
            }
        }

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void m_cbo_don_vi_su_dung_tai_san_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_trang_thai_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion

    
}

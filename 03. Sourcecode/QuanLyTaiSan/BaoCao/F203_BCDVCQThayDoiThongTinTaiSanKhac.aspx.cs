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

public partial class BaoCao_F203_BCDVCQThayDoiThongTinTaiSanKhac : System.Web.UI.Page
{
    #region Member
    US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
    DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
    US_V_DM_TAI_SAN_KHAC_HISTORY m_us_tai_san_khac = new US_V_DM_TAI_SAN_KHAC_HISTORY();
    DS_V_DM_TAI_SAN_KHAC_HISTORY m_ds_tai_san_khac = new DS_V_DM_TAI_SAN_KHAC_HISTORY();
    US_CM_DM_TU_DIEN m_us_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_tu_dien = new DS_CM_DM_TU_DIEN();
    #endregion
    #region Private Methods
    private bool check_validate_data_is_ok()
    {
        if (m_dat_den_ngay.SelectedDate.CompareTo(m_dat_den_ngay.SelectedDate) < 0)
        {
            return false;
        }
        return true;
    }
    private void load_data_to_grid()
    {
        if (!check_validate_data_is_ok()) return;
        string v_id_trang_thai = m_cbo_trang_thai.SelectedValue;
        DS_V_DM_TAI_SAN_KHAC_HISTORY v_ds_v_dm_tai_san_khac_history = new DS_V_DM_TAI_SAN_KHAC_HISTORY();
        US_V_DM_TAI_SAN_KHAC_HISTORY v_us_v_dm_tai_san_khac_history = new US_V_DM_TAI_SAN_KHAC_HISTORY();
        v_us_v_dm_tai_san_khac_history.FillDataset(
            CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
            , CIPConvert.ToStr(m_cbo_loai_hinh_don_vi.SelectedValue)
            , m_dat_tu_ngay.SelectedDate
            , m_dat_den_ngay.SelectedDate
            , Person.get_user_name()
            , m_txt_tim_kiem.Text
            , v_ds_v_dm_tai_san_khac_history);
        m_grv_tai_san_khac_history.DataSource = v_ds_v_dm_tai_san_khac_history;
        m_lbl_title.Text = "THÔNG TIN THAY ĐỔI";
        string v_str_thong_tin = " (Có " + v_ds_v_dm_tai_san_khac_history.V_DM_TAI_SAN_KHAC_HISTORY.Rows.Count + " bản ghi)";
        m_lbl_title.Text += v_str_thong_tin;
        m_grv_tai_san_khac_history.DataBind();
    }
    private void set_inital_value_of_combox()
    {
        string v_str_id_don_vi_su_dung = "";
        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.ID_DVSD] != null)
        {
            v_str_id_don_vi_su_dung = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.ID_DVSD];
            m_cbo_don_vi_su_dung_tai_san.SelectedValue = v_str_id_don_vi_su_dung;
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
                //load_data_to_cbo_trang_thai();
                WinFormControls.load_data_to_cbo_tu_dien(
                    WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_trang_thai);
                set_inital_value_of_combox();
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    protected void m_grv_tai_san_khac_history_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_tai_san_khac_history.PageIndex = e.NewPageIndex;
            load_data_to_grid();
        }
        catch (Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void m_cbo_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES, m_cbo_don_vi_chu_quan);
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_tai_san);
            m_grv_tai_san_khac_history.Visible = false;
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
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_tai_san);
            m_grv_tai_san_khac_history.Visible = false;
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {
            if (m_cbo_don_vi_chu_quan.SelectedValue == "")
            {
                m_lbl_mess.Text = "Bạn chưa chọn Đơn vị chủ quản";
                return;
            }
            if (m_cbo_don_vi_su_dung_tai_san.SelectedValue == "")
            {
                m_lbl_mess.Text = "Bạn chưa chọn Đơn vị sử dụng";
                return;
            }
            else
            {
                m_lbl_title.Text = "THÔNG TIN THAY ĐỔI";
                m_grv_tai_san_khac_history.Visible = true;
                Thread.Sleep(2000);
                load_data_to_grid();
            }
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
            Thread.Sleep(2000);
            // vì có phân trang, nên nếu muốn xuất all dữ liệu trên lưới (tất cả các trang) thì thê 2 dòng sau:
            m_grv_tai_san_khac_history.AllowPaging = false;
            load_data_to_grid();  // đây là hàm load lại dữ liệu lên lưới
            // còn nếu chỉ muốn xuất dữ liệu ở Page hiện tại thì không cần 2 dòng trên
            WinformReport.export_gridview_2_excel(
                        m_grv_tai_san_khac_history
                        , "DS tai san khac thay doi thong tin.xls"
                        , 0
                        , 1); // 0 và 1 là số thứ tự 2 cột: Sửa, Xóa
        }
        catch (Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
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
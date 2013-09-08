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

public partial class BaoCao_F312_BCDVCQ_Thay_doi_thong_tin_Oto : System.Web.UI.Page
{
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
                WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_OTO, WinFormControls.eTAT_CA.YES, m_cbo_trang_thai);
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }

    #region Member
    US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
    DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
    US_V_DM_OTO_HISTORY m_us_oto = new US_V_DM_OTO_HISTORY();
    DS_V_DM_OTO_HISTORY m_ds_oto = new DS_V_DM_OTO_HISTORY();
    US_CM_DM_TU_DIEN m_us_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_tu_dien = new DS_CM_DM_TU_DIEN();
    #endregion
    #region Private Methods
    private bool check_validate_data_is_ok()
    {
        if (m_txt_tu_ngay.Text.Trim().Length == 0)
        {
            m_txt_tu_ngay.Text = CIPConvert.ToStr("01/01/1900");
        }

        if (m_txt_den_ngay.Text.Trim().Length == 0)
        {
            m_txt_den_ngay.Text = CIPConvert.ToStr("01/01/3000");
        }
        DateTime m_tu_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text);
        DateTime m_den_ngay = CIPConvert.ToDatetime(m_txt_den_ngay.Text);
        if (m_den_ngay.CompareTo(m_tu_ngay) < 0)
        {
            return false;
        }
        return true;
    }
    private void load_data_to_grid()
    {
        if (!check_validate_data_is_ok()) return;
        string v_id_trang_thai = m_cbo_trang_thai.SelectedValue;
        DateTime v_tsk_tu_ngay;
        DateTime v_tsk_den_ngay;
        if (m_txt_tu_ngay.Text.Trim().Length > 0)
        {
            v_tsk_tu_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text);
        }
        else
        {
            v_tsk_tu_ngay = CIPConvert.ToDatetime("01/01/1900");
        }
        if (m_txt_den_ngay.Text.Trim().Length > 0)
        {
            v_tsk_den_ngay = CIPConvert.ToDatetime(m_txt_den_ngay.Text);
        }
        else
        {
            v_tsk_den_ngay = CIPConvert.ToDatetime("01/01/3000");
        }
        DS_V_DM_OTO_HISTORY v_ds_v_dm_oto_history = new DS_V_DM_OTO_HISTORY();
        US_V_DM_OTO_HISTORY v_us_v_dm_oto_history = new US_V_DM_OTO_HISTORY();
        v_us_v_dm_oto_history.FillDataset(
            CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
            , CIPConvert.ToStr(m_cbo_loai_hinh_don_vi.SelectedValue)
            , v_tsk_tu_ngay
            , v_tsk_den_ngay
            , Person.get_user_name()
            , m_txt_tim_kiem.Text
            , v_ds_v_dm_oto_history);
        m_grv_oto_history.DataSource = v_ds_v_dm_oto_history;
        m_lbl_title.Text = "THÔNG TIN THAY ĐỔI";
        string v_str_thong_tin = " (Có " + v_ds_v_dm_oto_history.V_DM_OTO_HISTORY.Rows.Count + " bản ghi)";
        m_lbl_title.Text += v_str_thong_tin;
        m_grv_oto_history.DataBind();
    }
    #endregion
    #region Events
    protected void m_grv_oto_history_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_oto_history.PageIndex = e.NewPageIndex;
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
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
            m_grv_oto_history.Visible = false;
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
            m_grv_oto_history.Visible = false;
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
                m_grv_oto_history.Visible = true;
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
            m_grv_oto_history.AllowPaging = false;
            load_data_to_grid();  // đây là hàm load lại dữ liệu lên lưới
            // còn nếu chỉ muốn xuất dữ liệu ở Page hiện tại thì không cần 2 dòng trên
            WinformReport.export_gridview_2_excel(
                        m_grv_oto_history
                        , "DS oto thay doi thong tin.xls"
                        , 0
                        , 1); // 0 và 1 là số thứ tự 2 cột: Sửa, Xóa
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
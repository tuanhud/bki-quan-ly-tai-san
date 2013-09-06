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


public partial class BaoCao_F311_BCDVCQ_Thay_doi_thong_tin_Nha : System.Web.UI.Page
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
                WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_NHA, WinFormControls.eTAT_CA.YES, m_cbo_trang_thai);
                WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                     CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                   , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                   , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                   , CONST_QLDB.ID_TAT_CA
                   , m_cbo_loai_hinh_don_vi.SelectedValue
                   , WinFormControls.eTAT_CA.YES
                   , m_cbo_dia_chi);
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
    US_V_DM_NHA_HISTORY m_us_nha = new US_V_DM_NHA_HISTORY();
    DS_V_DM_NHA_HISTORY m_ds_nha = new DS_V_DM_NHA_HISTORY();
    US_CM_DM_TU_DIEN m_us_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_tu_dien = new DS_CM_DM_TU_DIEN();
    #endregion
    #region Private Methods

    private void export_excel()
    {
        string v_str_bo_tinh = m_cbo_bo_tinh.SelectedItem.Text;
        string v_str_don_vi_chu_quan = m_cbo_don_vi_chu_quan.SelectedItem.Text;
        decimal v_dc_id_dv_su_dung = CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue);
        string v_str_output_file = "";
        f401_bao_cao_danh_muc_tai_san_khac v_f401_bc_dm_tai_san_khac = new f401_bao_cao_danh_muc_tai_san_khac();  
    }

    private bool check_validate_data_is_ok()
    {

        //if (!CValidateTextBox.IsValid(m_txt_tu_ngay, DataType.DateType, allowNull.YES)) return false;
        //if (!CValidateTextBox.IsValid(m_txt_tu_ngay, DataType.DateType, allowNull.YES)) return false;
        //Sử lý sau
        try
        {
            DateTime m_tu_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text);
            DateTime m_den_ngay = CIPConvert.ToDatetime(m_txt_den_ngay.Text);
            if (m_den_ngay.CompareTo(m_tu_ngay) < 0)
            {
                return false;
            }

        }
        catch (Exception)
        {

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


        DS_V_DM_NHA_HISTORY v_ds_v_dm_nha_history = new DS_V_DM_NHA_HISTORY();
        US_V_DM_NHA_HISTORY v_us_v_dm_nha_history = new US_V_DM_NHA_HISTORY();
        v_us_v_dm_nha_history.FillDataset(
            CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
            , CIPConvert.ToStr(m_cbo_loai_hinh_don_vi.SelectedValue)
            , v_tsk_tu_ngay
            , v_tsk_den_ngay
            , Person.get_user_name()
            , m_txt_tim_kiem.Text
            , v_ds_v_dm_nha_history);
        m_grv_nha_history.DataSource = v_ds_v_dm_nha_history;
        m_lbl_title.Text = "THÔNG TIN THAY ĐỔI";
        string v_str_thong_tin = " (Có " + v_ds_v_dm_nha_history.V_DM_NHA_HISTORY.Rows.Count + " bản ghi)";
        m_lbl_title.Text += v_str_thong_tin;
        m_grv_nha_history.DataBind();
    }
    private void load_data_to_thong_tin_nha_dat()
    {

        decimal v_dc_id_dat = CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue);
        if (v_dc_id_dat == -1)
        {
            m_pnl_thong_tin_nha_dat.Visible = false;
            return;
        }
        m_pnl_thong_tin_nha_dat.Visible = true;
        US_DM_DAT v_us_dm_dat = new US_DM_DAT(v_dc_id_dat);
        m_lbl_dia_chi.Text = v_us_dm_dat.strDIA_CHI;
        m_lbl_dien_tich_khuon_vien_dat.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_KHUON_VIEN, "#,##0.00");
        m_lbl_lam_tru_so_lam_viec.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_TRU_SO_LAM_VIEC, "#,##0.00");
        m_lbl_lam_tru_so_lam_viec.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_TRU_SO_LAM_VIEC, "#,##0.00");
        m_lbl_lam_co_so_hd_du_nghiep.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_CO_SO_HOAT_DONG_SU_NGHIEP, "#,##0.00");
        m_lbl_lam_nha_o.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_LAM_NHA_O, "#,##0.00");
        m_lbl_cho_thue.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_CHO_THUE, "#,##0.00");
        m_lbl_bo_trong.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_BO_TRONG, "#,##0.00");
        m_lbl_bi_lan_chiem.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_BI_LAN_CHIEM, "#,##0.00");
        m_lbl_su_dung_vao_muc_dich_khac.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_SU_DUNG_MUC_DICH_KHAC, "#,##0.00");
        m_lbl_gia_tri_theo_so_ke_toan.Text = CIPConvert.ToStr(v_us_dm_dat.dcGT_THEO_SO_KE_TOAN, "#,##0.00");

    }
    #endregion
    #region Events
    protected void m_grv_nha_history_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_nha_history.PageIndex = e.NewPageIndex;
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
            m_grv_nha_history.Visible = false;
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
            m_grv_nha_history.Visible = false;
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    protected void m_cbo_don_vi_su_dung_tai_san_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                     CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                   , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                   , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                   , ID_TRANG_THAI_DAT.DANG_SU_DUNG
                   , m_cbo_loai_hinh_don_vi.SelectedValue
                   , WinFormControls.eTAT_CA.YES
                   , m_cbo_dia_chi);
            m_grv_nha_history.Visible = false;
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
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
                m_grv_nha_history.Visible = true;
                Thread.Sleep(2000);
                load_data_to_grid();
                load_data_to_thong_tin_nha_dat();
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
                m_grv_nha_history.AllowPaging = false;
                load_data_to_grid();  // đây là hàm load lại dữ liệu lên lưới
                // còn nếu chỉ muốn xuất dữ liệu ở Page hiện tại thì không cần 2 dòng trên
                WinformReport.export_gridview_2_excel(
                            m_grv_nha_history
                            , "DS nha thay doi thong tin.xls"
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
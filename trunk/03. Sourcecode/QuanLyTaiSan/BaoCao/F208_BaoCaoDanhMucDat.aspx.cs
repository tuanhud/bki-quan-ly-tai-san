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
using IP.Core.QltsFormControls;

public partial class BaoCao_F208_BaoCaoDanhMucDat : System.Web.UI.Page
{
    #region Member
    US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
    DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
    US_DM_DAT m_us_dat = new US_DM_DAT();
    DS_DM_DAT m_ds_dat = new DS_DM_DAT();
    US_CM_DM_TU_DIEN m_us_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_tu_dien = new DS_CM_DM_TU_DIEN();
    WinFormControls.eTAT_CA ip_e_tat_ca;
    #endregion
    #region Private Methods
    private void form_2_objExcelAssetParameters(CObjExcelAssetParameters op_obj_parameter)
    {
        op_obj_parameter.dcID_BO_TINH = CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue);
        op_obj_parameter.strTEN_BO_TINH = m_cbo_bo_tinh.SelectedItem.Text;
        op_obj_parameter.dcID_DON_VI_CHU_QUAN = CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue);
        op_obj_parameter.strTEN_DON_VI_CHU_QUAN = m_cbo_don_vi_chu_quan.SelectedItem.Text;
        op_obj_parameter.dcID_DON_VI_SU_DUNG = CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue);
        op_obj_parameter.strTEN_DON_VI_SU_DUNG = m_cbo_don_vi_su_dung_tai_san.SelectedItem.Text;
        op_obj_parameter.dcID_TRANG_THAI_TAI_SAN = CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue);
        op_obj_parameter.strTEN_TRANG_THAI_TAI_SAN = m_cbo_trang_thai.SelectedItem.Text;
        op_obj_parameter.strKEY_SEARCH = String.Empty;
        op_obj_parameter.strTEN_LOAI_TAI_SAN = CONST_QLDB.TAT_CA;
        op_obj_parameter.strLOAI_HINH_DON_VI = m_cbo_loai_hinh_don_vi.SelectedItem.Text;
        op_obj_parameter.strMA_LOAI_HINH_DON_VI = m_cbo_loai_hinh_don_vi.SelectedValue;
        op_obj_parameter.strUSER_NAME = Person.get_user_name();
    }
    private void export_excel()
    {
        string v_str_loai_bao_cao = "";
        CObjExcelAssetParameters v_obj_parameter = new CObjExcelAssetParameters();
        form_2_objExcelAssetParameters(v_obj_parameter);
        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO] != null)
        {
            v_str_loai_bao_cao = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO];
        }
        switch (v_str_loai_bao_cao)
        {
            case CONST_QLDB.LOAI_BAO_CAO.DVCQ:
                m_grv_danh_sach_dat.AllowPaging = false;
                load_data_to_grid();  // đây là hàm load lại dữ liệu lên lưới
                // còn nếu chỉ muốn xuất dữ liệu ở Page hiện tại thì không cần 2 dòng trên
                WinformReport.export_gridview_2_excel(
                            m_grv_danh_sach_dat
                            , "DS đất.xls"
                            ); // 0 và 1 là số thứ tự 2 cột: Sửa, Xóa
                break;
            case CONST_QLDB.LOAI_BAO_CAO.BLD:
                m_grv_danh_sach_dat.AllowPaging = false;
                load_data_to_grid();  // đây là hàm load lại dữ liệu lên lưới
                // còn nếu chỉ muốn xuất dữ liệu ở Page hiện tại thì không cần 2 dòng trên
                WinformReport.export_gridview_2_excel(
                            m_grv_danh_sach_dat
                            , "DS đất.xls"
                            ); // 0 và 1 là số thứ tự 2 cột: Sửa, Xóa
                break;
            case CONST_QLDB.LOAI_BAO_CAO.DVSD:
                m_grv_danh_sach_dat.AllowPaging = false;
                load_data_to_grid();  // đây là hàm load lại dữ liệu lên lưới
                // còn nếu chỉ muốn xuất dữ liệu ở Page hiện tại thì không cần 2 dòng trên
                WinformReport.export_gridview_2_excel(
                            m_grv_danh_sach_dat
                            , "DS đất.xls"
                            ); // 0 và 1 là số thứ tự 2 cột: Sửa, Xóa
                break;
        }
    }
    private void set_inital_value_of_combox()
    {
        string v_str_id_trang_thai = "";
        string v_str_id_don_vi_su_dung = "";
        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.ID_DVSD] != null)
        {
            v_str_id_don_vi_su_dung = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.ID_DVSD];
            m_cbo_don_vi_su_dung_tai_san.SelectedValue = v_str_id_don_vi_su_dung;
        }
        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.TRANG_THAI] != null)
        {
            v_str_id_trang_thai = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.TRANG_THAI];
            m_cbo_trang_thai.SelectedValue = v_str_id_trang_thai;
        }
    }
    private void set_form_title_and_cbo()
    {
        string v_str_kieu_bc = "";
        string v_str_id_trang_thai = "";
        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.TRANG_THAI] != null)
        {
            v_str_id_trang_thai = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.TRANG_THAI];
        }
        switch (v_str_id_trang_thai)
        {
            case "597":
                v_str_kieu_bc = "KÊ KHAI ĐẤT";
                break;
            case "594":
                v_str_kieu_bc = "ĐỀ NGHỊ XỬ LÝ ĐẤT";
                break;
        }
        string v_str_loai_bao_cao = "";
        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO] != null)
        {
            v_str_loai_bao_cao = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO];
        }
        switch (v_str_loai_bao_cao)
        {
            case CONST_QLDB.LOAI_BAO_CAO.DVSD:
                // KÊ KHAI ĐƠN VỊ SỬ DỤNG
                m_lbl_tieu_de.Text = "BÁO CÁO " + v_str_kieu_bc;
                m_cbo_trang_thai.Enabled = false;
                ip_e_tat_ca = WinFormControls.eTAT_CA.NO;
                m_txt_tim_kiem.Visible = false;
                m_lbl_tim_kiem.Visible = false;
                break;
            case CONST_QLDB.LOAI_BAO_CAO.DVCQ:
                m_lbl_tieu_de.Text = "THỐNG KÊ ĐẤT";
                m_cbo_trang_thai.Enabled = true;
                m_cbo_trang_thai.Enabled = true;
                ip_e_tat_ca = WinFormControls.eTAT_CA.YES;
                m_txt_tim_kiem.Visible = true;
                m_lbl_tim_kiem.Visible = true;
                break;
            case CONST_QLDB.LOAI_BAO_CAO.BLD:
                m_lbl_tieu_de.Text = "THỐNG KÊ ĐẤT";
                m_cbo_trang_thai.Enabled = true;
                m_cbo_trang_thai.Enabled = true;
                ip_e_tat_ca = WinFormControls.eTAT_CA.YES;
                m_txt_tim_kiem.Visible = true;
                m_lbl_tim_kiem.Visible = true;
                break;
            default:
                throw new Exception("Chưa cấu hình loại báo cáo có mã:" + v_str_loai_bao_cao);
        }
    }
    private void load_data_to_grid()
    {
        m_grv_danh_sach_dat.Visible = true;
        US_V_DM_DAT m_us_v_dat = new US_V_DM_DAT();
        DS_V_DM_DAT m_ds_v_dat = new DS_V_DM_DAT();
        US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
        m_us_v_dat.FillDataSetByKeyWord(CIPConvert.ToStr(m_cbo_bo_tinh.SelectedValue)
                    , CIPConvert.ToStr(m_cbo_don_vi_chu_quan.SelectedValue)
                    , CIPConvert.ToStr(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                    , CIPConvert.ToStr(m_cbo_trang_thai.SelectedValue)
                    , Person.get_user_name()
                    , CIPConvert.ToStr(m_cbo_loai_hinh_don_vi.SelectedValue)
                    , CIPConvert.ToStr(m_txt_tim_kiem.Text)
                    , m_ds_v_dat);
        m_lbl_title.Text = "DANH MỤC ĐẤT";
        string v_str_thong_tin = " (Có " + m_ds_v_dat.V_DM_DAT.Rows.Count + " bản ghi)";
        m_lbl_title.Text += v_str_thong_tin;
        m_grv_danh_sach_dat.DataSource = m_ds_v_dat.V_DM_DAT;
        m_grv_danh_sach_dat.DataBind();
    }
    private bool check_validate_is_ok()
    {
        if (m_cbo_don_vi_chu_quan.SelectedValue == "")
        {
            m_lbl_mess.Text = "Bạn chưa chọn Đơn vị chủ quản";
            return false;
        }
        if (m_cbo_don_vi_su_dung_tai_san.SelectedValue == "")
        {
            m_lbl_mess.Text = "Bạn chưa chọn Đơn vị sử dụng";
            return false;
        }
        return true;
    }
    private void search_dat()
    {
        if (!check_validate_is_ok())
            return;
        Thread.Sleep(2000);
        load_data_to_grid();
    }
    #endregion
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                set_form_title_and_cbo();
                WinFormControls.load_data_to_cbo_loai_hinh_don_vi(
                    WinFormControls.eLOAI_TU_DIEN.LOAI_HINH_DON_VI
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_loai_hinh_don_vi
                    );
                WinFormControls.load_data_to_cbo_bo_tinh(
                    ip_e_tat_ca
                    , m_cbo_bo_tinh);
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh.SelectedValue
                    , ip_e_tat_ca
                    , m_cbo_don_vi_chu_quan);
                WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                    m_cbo_loai_hinh_don_vi.SelectedValue
                    , m_cbo_don_vi_chu_quan.SelectedValue
                    , m_cbo_bo_tinh.SelectedValue
                    , ip_e_tat_ca
                    , m_cbo_don_vi_su_dung_tai_san);
                WinFormControls.load_data_to_cbo_tu_dien(
                    WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_DAT
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_trang_thai);
                set_inital_value_of_combox();
                search_dat();
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    protected void m_cbo_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                m_cbo_bo_tinh.SelectedValue
                , ip_e_tat_ca
                , m_cbo_don_vi_chu_quan);
            WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                    m_cbo_loai_hinh_don_vi.SelectedValue
                    , m_cbo_don_vi_chu_quan.SelectedValue
                    , m_cbo_bo_tinh.SelectedValue
                    , ip_e_tat_ca
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
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                    m_cbo_loai_hinh_don_vi.SelectedValue
                    , m_cbo_don_vi_chu_quan.SelectedValue
                    , m_cbo_bo_tinh.SelectedValue
                    , ip_e_tat_ca
                    , m_cbo_don_vi_su_dung_tai_san);
        }
        catch (System.Exception ex)
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
    , ip_e_tat_ca
    , m_cbo_don_vi_su_dung_tai_san
    );
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {
            search_dat();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }
    protected void m_grv_danh_sach_dat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        m_grv_danh_sach_dat.PageIndex = e.NewPageIndex;
        load_data_to_grid();
    }
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        Thread.Sleep(2000);
        export_excel();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    #endregion
}
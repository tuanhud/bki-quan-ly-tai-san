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


public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            set_form_title_and_cbo();
            if (!IsPostBack)
            {
                
                WinFormControls.load_data_to_cbo_loai_hinh_don_vi(
                    WinFormControls.eLOAI_TU_DIEN.LOAI_HINH_DON_VI
                    , ip_e_tat_ca
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
                load_data_to_cbo_trang_thai();
                load_data_to_cbo_loai_tai_san();
                set_inital_value_of_combox();
                search_tai_san_khac();
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
    US_DM_TAI_SAN_KHAC m_us_tai_san_khac = new US_DM_TAI_SAN_KHAC();
    DS_DM_TAI_SAN_KHAC m_ds_tai_san_khac = new DS_DM_TAI_SAN_KHAC();
    US_CM_DM_TU_DIEN m_us_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_tu_dien = new DS_CM_DM_TU_DIEN();
    WinFormControls.eTAT_CA ip_e_tat_ca;
    f401_bao_cao_danh_muc_tai_san_khac.eFormMode ip_e_formmode;
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
        op_obj_parameter.dcID_LOAI_TAI_SAN = CIPConvert.ToDecimal(m_cbo_loai_tai_san.SelectedValue);
        op_obj_parameter.strTEN_LOAI_TAI_SAN = CONST_QLDB.TAT_CA;
        op_obj_parameter.strLOAI_HINH_DON_VI = m_cbo_loai_hinh_don_vi.SelectedItem.Text;
        op_obj_parameter.strMA_LOAI_HINH_DON_VI = m_cbo_loai_hinh_don_vi.SelectedValue;
        op_obj_parameter.strUSER_NAME = Person.get_user_name();
    }

    private void export_excel()
    {
        string v_str_output_file = "";
        string v_str_loai_bao_cao = "";
        string v_str_id_trang_thai = "";
        f401_bao_cao_danh_muc_tai_san_khac v_f401_bc_dm_tai_san_khac = new f401_bao_cao_danh_muc_tai_san_khac();
        CObjExcelAssetParameters v_obj_parameter = new CObjExcelAssetParameters();
        form_2_objExcelAssetParameters(v_obj_parameter);
        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO] != null) {
            v_str_loai_bao_cao = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO];
        }
        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.TRANG_THAI] != null) {
            v_str_id_trang_thai = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.TRANG_THAI];
        }
        switch (v_str_id_trang_thai) {
            case CONST_QLDB.TRANG_THAI.KE_KHAI:
                break;
            case CONST_QLDB.TRANG_THAI.DE_NGHI_XU_LY:
                break;
        }
        switch (v_str_loai_bao_cao)
            {
            case CONST_QLDB.LOAI_BAO_CAO.DVSD:
                    v_f401_bc_dm_tai_san_khac.export_excel(f401_bao_cao_danh_muc_tai_san_khac.eFormMode.KE_KHAI_TAI_SAN_KHAC
                        , ref v_obj_parameter);
                    Response.Clear();
                    v_str_output_file = "/QuanLyTaiSan/" + v_obj_parameter.strFILE_NAME_RESULT;
                    Response.Redirect(v_str_output_file, false);
                    break;
            case CONST_QLDB.LOAI_BAO_CAO.DVCQ:
                    v_f401_bc_dm_tai_san_khac.export_excel(f401_bao_cao_danh_muc_tai_san_khac.eFormMode.KE_KHAI_TAI_SAN_KHAC
                        , ref v_obj_parameter);
                    Response.Clear();
                    v_str_output_file = "/QuanLyTaiSan/" + v_obj_parameter.strFILE_NAME_RESULT;
                    Response.Redirect(v_str_output_file, false);
                    break;
            case CONST_QLDB.LOAI_BAO_CAO.BLD:
                    v_f401_bc_dm_tai_san_khac.export_excel(f401_bao_cao_danh_muc_tai_san_khac.eFormMode.TAI_SAN_KHAC_DE_NGHI_XU_LY
                        , ref v_obj_parameter);
                    Response.Clear();
                    v_str_output_file = "/QuanLyTaiSan/" + v_obj_parameter.strFILE_NAME_RESULT;
                    Response.Redirect(v_str_output_file, false);
                    break;
                case "4":
                    m_grv_danh_sach_tai_san_khac.AllowPaging = false;
                    load_data_to_grid();  // đây là hàm load lại dữ liệu lên lưới
                    // còn nếu chỉ muốn xuất dữ liệu ở Page hiện tại thì không cần 2 dòng trên
                    WinformReport.export_gridview_2_excel(
                                m_grv_danh_sach_tai_san_khac
                                , "DS tai san khac nguyen gia lon hon 500tr.xls"
                                ); // 0 và 1 là số thứ tự 2 cột: Sửa, Xóa
                    break;
                case "5":
                    m_grv_danh_sach_tai_san_khac.AllowPaging = false;
                    load_data_to_grid();  // đây là hàm load lại dữ liệu lên lưới
                    // còn nếu chỉ muốn xuất dữ liệu ở Page hiện tại thì không cần 2 dòng trên
                    WinformReport.export_gridview_2_excel(
                                m_grv_danh_sach_tai_san_khac
                                , "DS tai san khac nguyen gia nhỏ hon 500tr.xls"
                                ); // 0 và 1 là số thứ tự 2 cột: Sửa, Xóa
                    break;
            }
    }
    private void set_inital_value_of_combox() {
        string v_str_id_trang_thai = "";
        string v_str_id_don_vi_su_dung = "";
        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.ID_DVSD] != null) {
            v_str_id_don_vi_su_dung = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.ID_DVSD];
            m_cbo_don_vi_su_dung_tai_san.SelectedValue = v_str_id_don_vi_su_dung;
        }
        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.TRANG_THAI] != null) {
            v_str_id_trang_thai = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.TRANG_THAI];
            m_cbo_trang_thai.SelectedValue = v_str_id_trang_thai;           
        }
    }

    private void set_form_title_and_cbo() {
       
        string v_str_loai_bao_cao = "";
        string v_str_loai_tai_san_khac = "";
        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO] != null) {
            v_str_loai_bao_cao = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO];
        }
       
        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_TAI_SAN_KHAC] != null) {
            v_str_loai_tai_san_khac = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_TAI_SAN_KHAC];
        }
        switch (v_str_loai_bao_cao) {
            case CONST_QLDB.LOAI_BAO_CAO.DVSD:
                // KÊ KHAI ĐƠN VỊ SỬ DỤNG
                m_lbl_tieu_de.Text = "BÁO CÁO";
                m_cbo_trang_thai.Enabled = false;                
                m_cbo_loai_tai_san.Enabled = false;
                ip_e_tat_ca = WinFormControls.eTAT_CA.NO;
                break;
            case CONST_QLDB.LOAI_BAO_CAO.DVCQ:
                m_lbl_tieu_de.Text = "THỐNG KÊ ";
                m_cbo_trang_thai.Enabled = true;
                m_cbo_trang_thai.Enabled = true;
                ip_e_tat_ca = WinFormControls.eTAT_CA.YES;
                break;
            case CONST_QLDB.LOAI_BAO_CAO.BLD:
                m_lbl_tieu_de.Text = "THỐNG KÊ ";
                m_cbo_trang_thai.Enabled = true;
                m_cbo_trang_thai.Enabled = true;
                ip_e_tat_ca = WinFormControls.eTAT_CA.YES;
                break;
            default:
                throw new Exception("Chưa cấu hình loại báo cáo có mã:" + v_str_loai_bao_cao);
        }
        switch (v_str_loai_tai_san_khac) {
            case CONST_QLDB.LOAI_TAI_SAN.TREN_500:
                m_lbl_tieu_de.Text += "TÀI SẢN KHÁC TRÊN 500 TRIỆU ĐỒNG";
                m_cbo_loai_tai_san.SelectedValue = CIPConvert.ToStr(ID_LOAI_TAI_SAN.TAI_SAN_KHAC_LON_HON_500);
                break;
            case CONST_QLDB.LOAI_TAI_SAN.DUOI_500:
                m_lbl_tieu_de.Text += "TÀI SẢN KHÁC DƯỚI 500 TRIỆU ĐỒNG";
                m_cbo_loai_tai_san.SelectedValue = CIPConvert.ToStr(ID_LOAI_TAI_SAN.TAI_SAN_KHAC_NHO_HON_500);
                break;

        }
    }

    private void load_data_to_grid()
    {
        m_lbl_title.Text = "DANH MỤC TÀI SẢN KHÁC (TRỪ TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNG SỰ NGHIỆP VÀ XE Ô TÔ)";
        m_grv_danh_sach_tai_san_khac.Visible = true;
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
                    , CIPConvert.ToDecimal(m_cbo_loai_tai_san.SelectedValue)
                    , m_ds_v_tai_san_khac);
        m_grv_danh_sach_tai_san_khac.DataSource = m_ds_v_tai_san_khac.V_DM_TAI_SAN_KHAC;
        string v_str_thong_tin = " (Có " + m_ds_v_tai_san_khac.V_DM_TAI_SAN_KHAC.Rows.Count + " bản ghi)";
        m_lbl_title.Text += v_str_thong_tin;
        m_grv_danh_sach_tai_san_khac.DataBind();
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
    private void load_data_to_cbo_trang_thai()
    {
        WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC, WinFormControls.eTAT_CA.YES, m_cbo_trang_thai);         

      
    }
    private void load_data_to_cbo_loai_tai_san()
    {
        US_DM_LOAI_TAI_SAN v_us_dm_loai_tai_san = new US_DM_LOAI_TAI_SAN();
        DS_DM_LOAI_TAI_SAN v_ds_dm_loai_tai_san = new DS_DM_LOAI_TAI_SAN();
        v_us_dm_loai_tai_san.FillDataset(v_ds_dm_loai_tai_san, "WHERE ID_LOAI_TAI_SAN_PARENT =" + ID_LOAI_TAI_SAN.TAI_SAN_KHAC);
        m_cbo_loai_tai_san.DataSource = v_ds_dm_loai_tai_san.DM_LOAI_TAI_SAN;
        m_cbo_loai_tai_san.DataTextField = DM_LOAI_TAI_SAN.TEN_LOAI_TAI_SAN;
        m_cbo_loai_tai_san.DataValueField = DM_LOAI_TAI_SAN.ID;
        m_cbo_loai_tai_san.DataBind();
    }
    private void search_tai_san_khac()
    {
        if (!check_validate_is_ok())
            return;


        Thread.Sleep(2000);
        load_data_to_grid();
    }
    #endregion
    #region Events
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

            search_tai_san_khac();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }
    protected void m_grv_danh_sach_tai_san_khac_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        m_grv_danh_sach_tai_san_khac.PageIndex = e.NewPageIndex;
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
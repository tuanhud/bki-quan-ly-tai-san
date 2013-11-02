using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.WinFormControls;
using IP.Core.IPCommon;
using IP.Core.IPBusinessService;
using IP.Core.IPData;
using IP.Core.IPUserService;
using WebDS.CDBNames;
using QltsForm;
using WebUS;
using WebDS;
using System.Threading;
using IP.Core.IPExcelWebReport;
using IP.Core.QltsFormControls;

public partial class BaoCao_F206_TH_HTSD_oto_Tong_hop_chung : System.Web.UI.Page
{
    #region Members

    #endregion

    #region Data Structure
    public enum e_cols_name_grid
    {
        TAI_SAN=0,
        SO_LUONG=1,
        GIA_TRI_THEO_SO_KE_TOAN=2,
        HIEN_TRANG_SU_DUNG=3,
        TEN_DON_VI_BO_TINH=4,
        TEN_DON_VI_CHU_QUAN=5,
        MA_DON_VI_CHU_QUAN=6
    }
    #endregion

    #region private methods
    private void format_grid(bool ip_bl_hide)
    {
        m_grv_oto.Columns[(int)e_cols_name_grid.TEN_DON_VI_BO_TINH].Visible = ip_bl_hide;
        m_grv_oto.Columns[(int)e_cols_name_grid.TEN_DON_VI_CHU_QUAN].Visible = ip_bl_hide;
        m_grv_oto.Columns[(int)e_cols_name_grid.MA_DON_VI_CHU_QUAN].Visible = ip_bl_hide;
    }
    public string get_ma_don_vi_chu_quan()
    {
        string v_str_ma_don_vi = "";
        if (m_cbo_don_vi_chu_quan.SelectedValue == null) return v_str_ma_don_vi;
        if (m_cbo_don_vi_chu_quan.SelectedValue.Equals(CONST_QLDB.MA_TAT_CA)) return v_str_ma_don_vi;
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI(CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue));
        return v_us_dm_don_vi.strMA_DON_VI;
    }

    public string get_ten_bo_tinh()
    {
        string v_str_ten_bo_tinh = "";
        if (m_cbo_bo_tinh.SelectedValue == null) return v_str_ten_bo_tinh;
        if (m_cbo_bo_tinh.SelectedValue.Equals(CONST_QLDB.MA_TAT_CA)) return CONST_QLDB.TAT_CA;
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI(CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue));
        return v_us_dm_don_vi.strTEN_DON_VI;
    }

    public string get_ten_don_vi_chu_quan()
    {
        string v_str_ten_don_vi_chu_quan = "";
        if (m_cbo_don_vi_chu_quan.SelectedValue == null) return v_str_ten_don_vi_chu_quan;
        if (m_cbo_don_vi_chu_quan.SelectedValue.Equals(CONST_QLDB.MA_TAT_CA)) return CONST_QLDB.TAT_CA;
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI(CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue));
        return v_us_dm_don_vi.strTEN_DON_VI;
    }
    private void load_data_to_grid()
    {
        DS_RPT_TONG_HOP_HIEN_TRANG_OTO v_ds_v_tong_hop_hien_trang_oto = new DS_RPT_TONG_HOP_HIEN_TRANG_OTO();
        US_RPT_TONG_HOP_HIEN_TRANG_OTO v_us_v_tong_hop_hien_trang_oto = new US_RPT_TONG_HOP_HIEN_TRANG_OTO();
        v_us_v_tong_hop_hien_trang_oto.FillDataset_tong_hop_chung(
            CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
            , Person.get_user_name()
            , v_ds_v_tong_hop_hien_trang_oto);
        m_grv_oto.DataSource = v_ds_v_tong_hop_hien_trang_oto;
        m_grv_oto.DataBind();
    }
    private void form_2_objExcelAssetParameters(CObjExcelAssetParameters op_obj_parameter)
    {
        op_obj_parameter.dcID_BO_TINH = CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue);
        op_obj_parameter.strTEN_BO_TINH = m_cbo_bo_tinh.SelectedItem.Text;
        op_obj_parameter.dcID_DON_VI_CHU_QUAN = CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue);
        op_obj_parameter.strTEN_DON_VI_CHU_QUAN = m_cbo_don_vi_chu_quan.SelectedItem.Text;
        op_obj_parameter.dcID_DON_VI_SU_DUNG = CONST_QLDB.ID_TAT_CA;
        op_obj_parameter.strTEN_DON_VI_SU_DUNG = CONST_QLDB.TAT_CA;
        op_obj_parameter.dcID_TRANG_THAI_TAI_SAN = CONST_QLDB.ID_TAT_CA;
        op_obj_parameter.strTEN_TRANG_THAI_TAI_SAN = CONST_QLDB.TAT_CA;
        op_obj_parameter.strKEY_SEARCH = String.Empty;
        op_obj_parameter.dcID_LOAI_TAI_SAN = CONST_QLDB.ID_TAT_CA;
        op_obj_parameter.strTEN_LOAI_TAI_SAN = CONST_QLDB.TAT_CA;
        op_obj_parameter.strLOAI_HINH_DON_VI = CONST_QLDB.TAT_CA;
        op_obj_parameter.strMA_LOAI_HINH_DON_VI = CONST_QLDB.TAT_CA;
        op_obj_parameter.strUSER_NAME = Person.get_user_name();
    }
    private void export_excel()
    {
        //string v_str_output_file = "";
        //f210_RPT_TONG_HOP_HIEN_TRANG_OTO v_f210_tong_hop_chung = new f210_RPT_TONG_HOP_HIEN_TRANG_OTO();
        //CObjExcelAssetParameters v_obj_parameter = new CObjExcelAssetParameters();
        //form_2_objExcelAssetParameters(v_obj_parameter);
        //v_f210_tong_hop_chung.export_excel_TH_THSD(
        //   f210_RPT_TONG_HOP_HIEN_TRANG_OTO.TINH_HINH_SU_DUNG.TONG_HOP_CHUNG
        //                         , ref v_obj_parameter
        //                       );
        //Response.Clear();
        //v_str_output_file = "/QuanLyTaiSan/" + v_obj_parameter.strFILE_NAME_RESULT;
        //Response.Redirect(v_str_output_file, false);
        m_grv_oto.AllowPaging = false;
        load_data_to_grid();
        WinformReport.export_gridview_2_excel(
                       m_grv_oto
                        , "Báo cáo HTSD ô tô - tổng hợp chung.xls"
                        );
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //1. load data to combobox bộ, tỉnh 
                WinFormControls.load_data_to_cbo_bo_tinh(
                         WinFormControls.eTAT_CA.YES
                         , m_cbo_bo_tinh);

                //2. load data to combobox đơn vị chủ quản
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan);
                format_grid(false);
                load_data_to_grid();
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    protected void m_cbo_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES, m_cbo_don_vi_chu_quan);
            m_grv_oto.Visible = false;
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void m_cmd_loc_du_lieu_Click(object sender, EventArgs e)
    {
        try
        {
            Thread.Sleep(2000);
            m_grv_oto.Visible = true;
            format_grid(false);
            load_data_to_grid();
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
            /*m_grv_tai_san_nha_dat.AllowPaging = false;
            load_data_to_grid();  // đây là hàm load lại dữ liệu lên lưới
            // còn nếu chỉ muốn xuất dữ liệu ở Page hiện tại thì không cần 2 dòng trên
            WinformReport.export_gridview_2_excel(
                       m_grv_tai_san_nha_dat
                        , "DS tong hop chung nha dat.xls"
                        ); // 0 và 1 là số thứ tự 2 cột: Sửa, Xóa
             */
            format_grid(false);
            export_excel();
            format_grid(true);
        }
        catch (Exception ex)
        {
            //CSystemLog_301.ExceptionHandle(ex);
        }
    }
    #endregion
}
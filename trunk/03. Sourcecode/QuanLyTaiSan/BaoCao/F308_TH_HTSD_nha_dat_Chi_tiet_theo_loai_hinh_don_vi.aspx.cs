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
public partial class BaoCao_F308_TH_HTSD_nha_dat_Chi_tiet_theo_loai_hinh_don_vi : System.Web.UI.Page
{
    #region Data Structure
    public enum e_cols_name_grid
    {
        TAI_SAN = 0,
        SO_LUONG = 1,
        DIEN_TICH = 2,
        HIEN_TRANG_SU_DUNG = 3,
        TEN_BO_TINH = 4,
        TEN_DON_VI_CHU_QUAN = 5,
        MA_DON_VI_CHU_QUAN = 6
    }
    #endregion

    #region private methods
    private void format_grid(bool ip_bl_hide)
    {
        m_grv_tai_san_nha_dat.Columns[(int)e_cols_name_grid.TEN_BO_TINH].Visible = ip_bl_hide;
        m_grv_tai_san_nha_dat.Columns[(int)e_cols_name_grid.TEN_DON_VI_CHU_QUAN].Visible = ip_bl_hide;
        m_grv_tai_san_nha_dat.Columns[(int)e_cols_name_grid.MA_DON_VI_CHU_QUAN].Visible = ip_bl_hide;
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
    private void load_data_to_grid(string ip_str_id_bo_tinh, string ip_str_id_don_vi_chu_quan)
    {
        DS_RPT_TONG_HOP_HIEN_TRANG v_ds_rpt_tong_hop_hien_trang = new DS_RPT_TONG_HOP_HIEN_TRANG();
        US_RPT_TONG_HOP_HIEN_TRANG v_us_rpt_tong_hop_hien_trang = new US_RPT_TONG_HOP_HIEN_TRANG();
        string v_str_user_name = Person.get_user_name();
        if (v_str_user_name.Equals(null)) return;

        v_us_rpt_tong_hop_hien_trang.FillDataset_tong_hop_chi_tiet_theo_loai_hinh_don_vi(
            CIPConvert.ToDecimal(ip_str_id_bo_tinh)
            , CIPConvert.ToDecimal(ip_str_id_don_vi_chu_quan)
            , v_str_user_name
            , v_ds_rpt_tong_hop_hien_trang
            );
        m_grv_tai_san_nha_dat.DataSource = v_ds_rpt_tong_hop_hien_trang.RPT_TONG_HOP_HIEN_TRANG;
        Thread.Sleep(1000);
        m_grv_tai_san_nha_dat.DataBind();
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
        //f320_RPT_TONG_HOP_HIEN_TRANG v_f320_tong_hop_thsn_theo_loai_hinh_don_vi = new f320_RPT_TONG_HOP_HIEN_TRANG();
        //CObjExcelAssetParameters v_obj_parameter = new CObjExcelAssetParameters();
        //form_2_objExcelAssetParameters(v_obj_parameter);
        //v_f320_tong_hop_thsn_theo_loai_hinh_don_vi.export_excel_TH_THSD(
        //   f320_RPT_TONG_HOP_HIEN_TRANG.TINH_HINH_SU_DUNG.LOAI_HINH_DON_VI
        //                         , ref v_obj_parameter
        //                       );
        //Response.Clear();
        //v_str_output_file = "/QuanLyTaiSan/" + v_obj_parameter.strFILE_NAME_RESULT;
        //Response.Redirect(v_str_output_file, false);
        m_grv_tai_san_nha_dat.AllowPaging = false;
        load_data_to_grid(m_cbo_bo_tinh.SelectedValue, m_cbo_don_vi_chu_quan.SelectedValue);
        WinformReport.export_gridview_2_excel(
                       m_grv_tai_san_nha_dat
                        , "Báo cáo THSD nhà đất - chi tiết theo loại hình đơn vị.xls"
                        );
    }
    #endregion

    #region Events
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                WinFormControls.load_data_to_cbo_bo_tinh(
                    WinFormControls.eTAT_CA.YES
                    , m_cbo_bo_tinh
                    );
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan
                    );
                format_grid(false);
                load_data_to_grid(m_cbo_bo_tinh.SelectedValue, m_cbo_don_vi_chu_quan.SelectedValue);
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
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_loc_du_lieu_Click(object sender, EventArgs e)
    {
        try
        {
            format_grid(false);
            load_data_to_grid(
                m_cbo_bo_tinh.SelectedValue
                , m_cbo_don_vi_chu_quan.SelectedValue
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
            Thread.Sleep(1000);
            format_grid(true);
            export_excel();
            format_grid(false);
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    #endregion
}
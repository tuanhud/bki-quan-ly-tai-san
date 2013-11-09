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
using IP.Core.QltsFormControls;
using System.Threading;

public partial class BaoCao_F304_TH_tang_giam_tai_san_Tong_hop_chung : System.Web.UI.Page
{
    #region Members

    #endregion

    #region Data Structure
    public enum e_cols_name_grid
    {
        TAI_SAN = 0,
        SO_DAU_KY = 1,
        SO_TANG_TRONG_KY = 2,
        SO_GIAM_TRONG_KY = 3,
        SO_CUOI_KY = 4,
        TEN_BO_TINH = 5,
        TEN_DON_VI_CHU_QUAN = 6,
        MA_DON_VI_CHU_QUAN = 7,
        TU_NGAY = 8,
        DEN_NGAY = 9

    }
    #endregion

    #region private methods
    private void format_grid(bool ip_bl_hide)
    {
        m_grv_tai_san.Columns[(int)e_cols_name_grid.TEN_BO_TINH].Visible = ip_bl_hide;
        m_grv_tai_san.Columns[(int)e_cols_name_grid.TEN_DON_VI_CHU_QUAN].Visible = ip_bl_hide;
        m_grv_tai_san.Columns[(int)e_cols_name_grid.MA_DON_VI_CHU_QUAN].Visible = ip_bl_hide;
        m_grv_tai_san.Columns[(int)e_cols_name_grid.TU_NGAY].Visible = ip_bl_hide;
        m_grv_tai_san.Columns[(int)e_cols_name_grid.DEN_NGAY].Visible = ip_bl_hide;
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

    public string get_date_tu_ngay()
    {
        return m_dat_tu_ngay.Text;
    }

    public string get_date_den_ngay()
    {
        return m_dat_den_ngay.Text;
    }
    public string get_ten_don_vi_chu_quan()
    {
        string v_str_ten_don_vi_chu_quan = "";
        if (m_cbo_don_vi_chu_quan.SelectedValue == null) return v_str_ten_don_vi_chu_quan;
        if (m_cbo_don_vi_chu_quan.SelectedValue.Equals(CONST_QLDB.MA_TAT_CA)) return CONST_QLDB.TAT_CA;
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI(CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue));
        return v_us_dm_don_vi.strTEN_DON_VI;
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
        op_obj_parameter.datDEN_NGAY = m_dat_den_ngay.SelectedDate;
        op_obj_parameter.datTU_NGAY = m_dat_tu_ngay.SelectedDate;
    }
    private void export_excel()
    {
        //if (!check_validate_data_is_ok()) return;
        //string v_str_output_file = "";
        //F330_RPT_TANG_GIAM_TAI_SAN v_f330_tang_giam_tai_san = new F330_RPT_TANG_GIAM_TAI_SAN();
        //CObjExcelAssetParameters v_obj_parameter = new CObjExcelAssetParameters();
        //form_2_objExcelAssetParameters(v_obj_parameter);
        //v_f330_tang_giam_tai_san.export_excel(
        //   F330_RPT_TANG_GIAM_TAI_SAN.TANG_GIAM_TAI_SAN.TONG_HOP_CHUNG
        //                         , ref v_obj_parameter
        //                       );
        //Response.Clear();
        //v_str_output_file = "/QuanLyTaiSan/" + v_obj_parameter.strFILE_NAME_RESULT;
        //Response.Redirect(v_str_output_file, false);
        m_grv_tai_san.AllowPaging = false;
        load_data_to_grid_tai_san();
        WinformReport.export_gridview_2_excel(
                       m_grv_tai_san
                        , "Báo cáo tăng giảm tài sản - tổng hợp chung.xls"
                        );
    }
    private void thongbao(string ip_str_thong_bao)
    {
        m_lbl_mess.Text = ip_str_thong_bao;
    }
    private void reset_thong_bao()
    {
        m_lbl_mess.Text = "";
    }
    private bool check_validate_data_is_ok()
    {
        if (m_dat_den_ngay.SelectedDate.CompareTo(m_dat_tu_ngay.SelectedDate) < 0)
        {
            thongbao("Thời gian từ ngày phải trước thời gian đến ngày!");
            return false;
        }

        return true;
    }
    private void load_data_to_grid_tai_san()
    {
        string v_str_user_name = Person.get_user_name();
        if (v_str_user_name.Equals("")) return;
        if (!check_validate_data_is_ok()) return;
        DS_RPT_TANG_GIAM_TAI_SAN v_ds_rpt_tang_giam_tai_san = new DS_RPT_TANG_GIAM_TAI_SAN();
        US_RPT_TANG_GIAM_TAI_SAN v_us_rpt_tang_giam_tai_san = new US_RPT_TANG_GIAM_TAI_SAN();
        v_us_rpt_tang_giam_tai_san.FillDataSet_tong_hop_chung(
            v_str_user_name
            , CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
            , m_dat_tu_ngay.SelectedDate
            , m_dat_den_ngay.SelectedDate
            , v_ds_rpt_tang_giam_tai_san
            );
        m_grv_tai_san.DataSource = v_ds_rpt_tang_giam_tai_san.RPT_TANG_GIAM_TAI_SAN;
        m_grv_tai_san.DataBind();
    }
    #endregion

    #region Events
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                WinFormControls.load_data_to_cbo_bo_tinh(
                    WinFormControls.eTAT_CA.NO
                    , m_cbo_bo_tinh
                    );
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.NO
                    , m_cbo_don_vi_chu_quan
                    );
                format_grid(false);
                load_data_to_grid_tai_san();
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
            reset_thong_bao();
            WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_chu_quan
                );
            m_grv_tai_san.Visible = false;
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }

    }
    protected void m_cmd_loc_du_lieu_Click(object sender, EventArgs e)
    {
        try
        {
            format_grid(false);
            load_data_to_grid_tai_san();
            m_grv_tai_san.Visible = true;
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
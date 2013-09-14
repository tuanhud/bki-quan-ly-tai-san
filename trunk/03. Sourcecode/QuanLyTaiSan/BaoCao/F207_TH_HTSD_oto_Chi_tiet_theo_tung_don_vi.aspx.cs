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
using IP.Core.QltsFormControls;
using WebUS;
using WebDS;
using System.Threading;

public partial class BaoCao_F207_TH_HTSD_oto_Chi_tiet_theo_tung_don_vi : System.Web.UI.Page
{
    #region Members

    #endregion

    #region private methods
    private void load_data_to_grid(string ip_str_id_bo_tinh, string ip_str_id_don_vi_chu_quan)
    {
        DS_RPT_TONG_HOP_HIEN_TRANG_OTO v_DS_RPT_TONG_HOP_HIEN_TRANG_OTO = new DS_RPT_TONG_HOP_HIEN_TRANG_OTO();
        US_RPT_TONG_HOP_HIEN_TRANG_OTO v_US_RPT_TONG_HOP_HIEN_TRANG_OTO = new US_RPT_TONG_HOP_HIEN_TRANG_OTO();
        string v_str_user_name = Person.get_user_name();
        if (v_str_user_name.Equals(null)) return;

        v_US_RPT_TONG_HOP_HIEN_TRANG_OTO.FillDataset_tong_hop_chi_tiet_theo_don_vi(
            CIPConvert.ToDecimal(ip_str_id_bo_tinh)
            , CIPConvert.ToDecimal(ip_str_id_don_vi_chu_quan)
            , v_str_user_name
            , v_DS_RPT_TONG_HOP_HIEN_TRANG_OTO
            );
        m_grv_tai_san_khac.DataSource = v_DS_RPT_TONG_HOP_HIEN_TRANG_OTO.RPT_TONG_HOP_HIEN_TRANG_OTO;
        Thread.Sleep(1000);
        m_grv_tai_san_khac.DataBind();
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
        string v_str_output_file = "";
        f210_RPT_TONG_HOP_HIEN_TRANG_OTO v_f210_tong_hop_chung = new f210_RPT_TONG_HOP_HIEN_TRANG_OTO();
        CObjExcelAssetParameters v_obj_parameter = new CObjExcelAssetParameters();
        form_2_objExcelAssetParameters(v_obj_parameter);
        v_f210_tong_hop_chung.export_excel_TH_THSD(
           f210_RPT_TONG_HOP_HIEN_TRANG_OTO.TINH_HINH_SU_DUNG.DON_VI_SU_DUNG
                                 , ref v_obj_parameter
                               );
        Response.Clear();
        v_str_output_file = "/QuanLyTaiSan/" + v_obj_parameter.strFILE_NAME_RESULT;
        Response.Redirect(v_str_output_file, false);
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
                load_data_to_grid(
                m_cbo_bo_tinh.SelectedValue
                , m_cbo_don_vi_chu_quan.SelectedValue
                );
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
            export_excel();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    protected void m_grv_tai_san_khac_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_tai_san_khac.PageIndex = e.NewPageIndex;
            load_data_to_grid(
                m_cbo_bo_tinh.SelectedValue
                , m_cbo_don_vi_chu_quan.SelectedValue);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
}
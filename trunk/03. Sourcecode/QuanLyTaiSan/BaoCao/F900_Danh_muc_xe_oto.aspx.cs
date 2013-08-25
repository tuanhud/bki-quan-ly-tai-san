using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using IP.Core;
using IP.Core.IPData;
using IP.Core.IPUserService;
using WebDS.CDBNames;
using IP.Core.IPCommon;
using QltsForm;
using IP.Core.QltsFormControls;
using IP.Core.WinFormControls;


public partial class BaoCao_F900_Danh_muc_xe_oto_de_nghi_xu_ly : System.Web.UI.Page
{
    #region Public Methods
    public string getTenLoaiTaiSan(decimal ip_dc_id_loai_tai_san)
    {
        US_DM_LOAI_TAI_SAN v_us_dm_loai_tai_san = new US_DM_LOAI_TAI_SAN(ip_dc_id_loai_tai_san);
        return v_us_dm_loai_tai_san.strTEN_LOAI_TAI_SAN;
    }
    #endregion
    #region Member
    #endregion

    #region Private Methods
    private void form_2_objExcelAssetParameters(CObjExcelAssetParameters op_obj_parameter)
    {
        op_obj_parameter.dcID_BO_TINH = CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue);
        op_obj_parameter.strTEN_BO_TINH = m_cbo_bo_tinh.SelectedItem.Text;
        op_obj_parameter.dcID_DON_VI_CHU_QUAN = CIPConvert.ToDecimal(m_cbo_don_vi_quan_ly.SelectedValue);
        op_obj_parameter.strTEN_DON_VI_CHU_QUAN = m_cbo_don_vi_quan_ly.SelectedItem.Text;
        op_obj_parameter.dcID_DON_VI_SU_DUNG = CIPConvert.ToDecimal(m_cbo_don_vi_su_dung.SelectedValue);
        op_obj_parameter.strTEN_DON_VI_SU_DUNG = m_cbo_don_vi_su_dung.SelectedItem.Text;
        op_obj_parameter.dcID_TRANG_THAI_TAI_SAN = CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue);
        op_obj_parameter.strTEN_TRANG_THAI_TAI_SAN = m_cbo_trang_thai.SelectedItem.Text;
        op_obj_parameter.strKEY_SEARCH = m_txt_tu_khoa.Text;
        op_obj_parameter.dcID_LOAI_TAI_SAN = CONST_QLDB.ID_TAT_CA;
        op_obj_parameter.strTEN_LOAI_TAI_SAN = CONST_QLDB.TAT_CA;
        op_obj_parameter.strLOAI_HINH_DON_VI = m_cbo_loai_hinh_don_vi.SelectedItem.Text;
        op_obj_parameter.strMA_LOAI_HINH_DON_VI = m_cbo_bo_tinh.SelectedValue;
        op_obj_parameter.strUSER_NAME = Person.get_user_name();
    }

    private void load_data_to_cbo_loai_xe()
    {
        US_DM_LOAI_TAI_SAN v_us_dm_loai_tai_san=new US_DM_LOAI_TAI_SAN();
        DS_DM_LOAI_TAI_SAN v_ds_dm_loai_tai_san=new DS_DM_LOAI_TAI_SAN();
        v_us_dm_loai_tai_san.FillDataset(v_ds_dm_loai_tai_san,"where id_loai_tai_san_parent = 3");
        m_cbo_loai_xe.DataSource=v_ds_dm_loai_tai_san.DM_LOAI_TAI_SAN;
        m_cbo_loai_xe.DataValueField = DM_LOAI_TAI_SAN.ID;
        m_cbo_loai_xe.DataTextField = DM_LOAI_TAI_SAN.TEN_LOAI_TAI_SAN;
        m_cbo_loai_xe.DataBind();
        m_cbo_loai_xe.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
    }
    
    private void export_excel()
    {

        f400_bao_cao_danh_muc_o_to v_f400_bc_dm_oto = new f400_bao_cao_danh_muc_o_to();
        CObjExcelAssetParameters v_obj_parameter = new CObjExcelAssetParameters();
        form_2_objExcelAssetParameters(v_obj_parameter);


        if (v_obj_parameter.dcID_TRANG_THAI_TAI_SAN == ID_TRANG_THAI_OTO.DANG_SU_DUNG)
        {

            v_f400_bc_dm_oto.export_excel(
                f400_bao_cao_danh_muc_o_to.eFormMode.KE_KHAI_O_TO
                , ref v_obj_parameter);
        }
        else if (v_obj_parameter.dcID_TRANG_THAI_TAI_SAN == ID_TRANG_THAI_OTO.DE_NGHI_XU_LY)
        {

            v_f400_bc_dm_oto.export_excel(
                f400_bao_cao_danh_muc_o_to.eFormMode.O_TO_DE_NGHI_XU_LY
                , ref v_obj_parameter);

        }
        Response.Clear();
        v_obj_parameter.strFILE_NAME_RESULT = "/QuanLyTaiSan/" + v_obj_parameter.strFILE_NAME_RESULT;
        Response.Redirect(v_obj_parameter.strFILE_NAME_RESULT, false);
    }
    private bool check_validate_data_is_ok()
    {
        return true;
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                WinFormControls.load_data_to_cbo_tu_dien(
                    WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_OTO
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_trang_thai
                    );
                WinFormControls.load_data_to_cbo_loai_hinh_don_vi(
                    WinFormControls.eLOAI_TU_DIEN.LOAI_HINH_DON_VI
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_loai_hinh_don_vi
                    );
                WinFormControls.load_data_to_cbo_bo_tinh(
                    WinFormControls.eTAT_CA.YES
                    , m_cbo_bo_tinh
                    );
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_quan_ly
                    );
                WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                    m_cbo_loai_hinh_don_vi.SelectedValue
                    , m_cbo_don_vi_quan_ly.SelectedValue
                    , m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung
                    );
                load_data_to_cbo_loai_xe();
            }
        }
        catch (Exception v_e)
        {
            this.Response.Write(v_e.ToString());
        }
    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {
            System.Threading.Thread.Sleep(1000);
            string v_str_user_name = Person.get_user_name();
            if (v_str_user_name.Equals(null)) return;
            US_V_DM_OTO v_us_v_dm_oto = new US_V_DM_OTO();
            DS_V_DM_OTO v_ds_v_dm_oto = new DS_V_DM_OTO();
            v_us_v_dm_oto.FillDatasetLoadDataToGridOto_by_tu_khoa(
                   m_txt_tu_khoa.Text.Trim()
                   , CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                   , CIPConvert.ToDecimal(m_cbo_don_vi_quan_ly.SelectedValue)
                   , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung.SelectedValue)
                   , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                   , CIPConvert.ToDecimal(m_cbo_loai_xe.SelectedValue)
                   , m_cbo_loai_hinh_don_vi.SelectedValue
                   , v_str_user_name
                   , v_ds_v_dm_oto
                );
            m_grv_bao_cao_oto.DataSource = v_ds_v_dm_oto.V_DM_OTO;
            m_grv_bao_cao_oto.DataBind();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    protected void m_cbo_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                  m_cbo_bo_tinh.SelectedValue
                  , WinFormControls.eTAT_CA.YES
                  , m_cbo_don_vi_quan_ly
                  );
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    protected void m_cbo_don_vi_quan_ly_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                    m_cbo_loai_hinh_don_vi.SelectedValue
                    , m_cbo_don_vi_quan_ly.SelectedValue
                    , m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung
                    );
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
            export_excel();
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
                   , m_cbo_don_vi_quan_ly.SelectedValue
                   , m_cbo_bo_tinh.SelectedValue
                   , WinFormControls.eTAT_CA.YES
                   , m_cbo_don_vi_su_dung
                   );
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_grv_bao_cao_oto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_bao_cao_oto.PageIndex = e.NewPageIndex;
            System.Threading.Thread.Sleep(1000);
            string v_str_user_name = Person.get_user_name();
            if (v_str_user_name.Equals(null)) return;
            US_V_DM_OTO v_us_v_dm_oto = new US_V_DM_OTO();
            DS_V_DM_OTO v_ds_v_dm_oto = new DS_V_DM_OTO();
            v_us_v_dm_oto.FillDatasetLoadDataToGridOto_by_tu_khoa(
                   m_txt_tu_khoa.Text.Trim()
                   , CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                   , CIPConvert.ToDecimal(m_cbo_don_vi_quan_ly.SelectedValue)
                   , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung.SelectedValue)
                   , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                   , CIPConvert.ToDecimal(m_cbo_loai_xe.SelectedValue)
                   , m_cbo_loai_hinh_don_vi.SelectedValue
                   , v_str_user_name
                   , v_ds_v_dm_oto
                );
            m_grv_bao_cao_oto.DataSource = v_ds_v_dm_oto.V_DM_OTO;
            m_grv_bao_cao_oto.DataBind();

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    #endregion
   
}


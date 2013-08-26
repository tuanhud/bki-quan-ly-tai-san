using System;
using System.Collections.Generic;
using WebDS;
using WebUS;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using IP.Core.IPBusinessService;
using IP.Core.IPData;
using IP.Core.IPUserService;
using WebDS.CDBNames;
using QltsForm;
using IP.Core.WinFormControls;
using System.Threading;
using IP.Core.QltsFormControls;

public partial class BaoCao_F300_TaiSanCoNguyenGiaTu500TrieuTroLen : System.Web.UI.Page
{
    #region member
    DS_CM_DM_TU_DIEN m_ds_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    US_CM_DM_TU_DIEN m_us_dm_tu_dien = new US_CM_DM_TU_DIEN();
    #endregion

    #region private method
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
        op_obj_parameter.dcID_LOAI_TAI_SAN = ID_LOAI_TAI_SAN.NHA;
        op_obj_parameter.strTEN_LOAI_TAI_SAN = CONST_QLDB.TAT_CA;
        op_obj_parameter.strLOAI_HINH_DON_VI = m_cbo_loai_hinh_don_vi.SelectedItem.Text;
        op_obj_parameter.strMA_LOAI_HINH_DON_VI = m_cbo_loai_hinh_don_vi.SelectedValue;
        op_obj_parameter.strUSER_NAME = Person.get_user_name();
    }

    private void export_excel()
    {
        string v_str_output_file = "";
        f401_bao_cao_danh_muc_tai_san_khac v_f401_bc_dm_tai_san_khac = new f401_bao_cao_danh_muc_tai_san_khac();
        CObjExcelAssetParameters v_obj_parameter = new CObjExcelAssetParameters();
        form_2_objExcelAssetParameters(v_obj_parameter);
        if (Request.QueryString["ID"] != null)
        {
            string v_id = Request.QueryString["ID"];
            switch (v_id)
            {
                case "1":
                    v_f401_bc_dm_tai_san_khac.export_excel(f401_bao_cao_danh_muc_tai_san_khac.eFormMode.KE_KHAI_TAI_SAN_KHAC
                        , ref v_obj_parameter);

                    break;
                case "2":
                    v_f401_bc_dm_tai_san_khac.export_excel(f401_bao_cao_danh_muc_tai_san_khac.eFormMode.TAI_SAN_KHAC_DE_NGHI_XU_LY
                        , ref v_obj_parameter);
                    break;
            }
            Response.Clear();
            v_str_output_file = "/QuanLyTaiSan/" + v_obj_parameter.strFILE_NAME_RESULT;
            Response.Redirect(v_str_output_file, false);
        }
    }

    private bool check_validate_data_id_ok()
    {
        return true;
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
                //load data to trang thai 
                WinFormControls.load_data_to_cbo_tu_dien(
                    WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC
                    , WinFormControls.eTAT_CA.NO
                    , m_cbo_trang_thai
                    );
                m_cbo_trang_thai.SelectedValue = CIPConvert.ToStr(ID_TRANG_THAI_TAI_SAN_KHAC.DANG_SU_DUNG);
                m_cbo_trang_thai.Enabled = false;
                //load data to combobox bo tinh
                WinFormControls.load_data_to_cbo_bo_tinh(
                         WinFormControls.eTAT_CA.YES
                         , m_cbo_bo_tinh);
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan);
                WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                   m_cbo_loai_hinh_don_vi.SelectedValue
                   , m_cbo_don_vi_chu_quan.SelectedValue.ToString()
                   , m_cbo_bo_tinh.SelectedValue.ToString()
                   , WinFormControls.eTAT_CA.YES
                   , m_cbo_don_vi_su_dung_tai_san
                   );
            }
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            m_lbl_thong_bao.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan);
            WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                   m_cbo_loai_hinh_don_vi.SelectedValue
                   , m_cbo_don_vi_chu_quan.SelectedValue.ToString()
                   , m_cbo_bo_tinh.SelectedValue.ToString()
                   , WinFormControls.eTAT_CA.YES
                   , m_cbo_don_vi_su_dung_tai_san
                   );
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_chu_quan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_lbl_thong_bao.Text = "";
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                   m_cbo_loai_hinh_don_vi.SelectedValue
                   , m_cbo_don_vi_chu_quan.SelectedValue.ToString()
                   , m_cbo_bo_tinh.SelectedValue.ToString()
                   , WinFormControls.eTAT_CA.YES
                   , m_cbo_don_vi_su_dung_tai_san
                   );
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
            m_lbl_thong_bao.Text = "";
            US_V_DM_TAI_SAN_KHAC v_us_v_dm_tai_san_khac = new US_V_DM_TAI_SAN_KHAC();
            DS_V_DM_TAI_SAN_KHAC v_ds_v_dm_tai_san_khac = new DS_V_DM_TAI_SAN_KHAC();
            v_us_v_dm_tai_san_khac.FillDataSetLoadDataToGridTaiSanKhacLoaiHinh(
                          CIPConvert.ToStr(m_cbo_loai_hinh_don_vi.SelectedValue)
                        , Person.get_user_name()
                        , CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                        , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                        , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                        , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                        , v_ds_v_dm_tai_san_khac
            );
            m_grv_tai_san_khac.DataSource = v_ds_v_dm_tai_san_khac.V_DM_TAI_SAN_KHAC;
            Thread.Sleep(1000);
            m_grv_tai_san_khac.DataBind();
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_tai_san_khac_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_tai_san_khac.PageIndex = e.NewPageIndex;

            m_lbl_thong_bao.Text = "";
            US_V_DM_TAI_SAN_KHAC v_us_v_dm_tai_san_khac = new US_V_DM_TAI_SAN_KHAC();
            DS_V_DM_TAI_SAN_KHAC v_ds_v_dm_tai_san_khac = new DS_V_DM_TAI_SAN_KHAC();
            v_us_v_dm_tai_san_khac.FillDataSetLoadDataToGridTaiSanKhacLoaiHinh(
                          CIPConvert.ToStr(m_cbo_loai_hinh_don_vi.SelectedValue)
                        , Person.get_user_name()
                        , CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                        , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                        , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                        , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                        , v_ds_v_dm_tai_san_khac
            );
            m_grv_tai_san_khac.DataSource = v_ds_v_dm_tai_san_khac.V_DM_TAI_SAN_KHAC;
            Thread.Sleep(1000);
            m_grv_tai_san_khac.DataBind();
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        try
        {
            export_excel();
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
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
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
}
    #endregion

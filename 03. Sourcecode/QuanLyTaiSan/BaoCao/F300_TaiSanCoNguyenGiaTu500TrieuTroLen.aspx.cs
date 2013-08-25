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
public partial class BaoCao_F300_TaiSanCoNguyenGiaTu500TrieuTroLen : System.Web.UI.Page
{
    #region member
    DS_CM_DM_TU_DIEN m_ds_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    US_CM_DM_TU_DIEN m_us_dm_tu_dien = new US_CM_DM_TU_DIEN();
    #endregion

    #region private method
    private void export_excel()
    {
        try
        {
            string v_str_bo_tinh = m_cbo_bo_tinh.SelectedItem.Text;
            string v_str_don_vi_chu_quan = m_cbo_don_vi_chu_quan.SelectedItem.Text;
            decimal v_dc_id_dv_su_dung = CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue);
            string v_str_output_file = "";
            f401_bao_cao_danh_muc_tai_san_khac v_f401_bc_dm_tai_san_khac = new f401_bao_cao_danh_muc_tai_san_khac();

            v_f401_bc_dm_tai_san_khac.expor_excel(f401_bao_cao_danh_muc_tai_san_khac.eFormMode.KE_KHAI_TAI_SAN_KHAC

                        , v_str_bo_tinh
                        , v_str_don_vi_chu_quan
                        , v_dc_id_dv_su_dung
                        , ref v_str_output_file);
            Response.Clear();
            v_str_output_file = "/QuanLyTaiSan/" + v_str_output_file;
            Response.Redirect(v_str_output_file, false);
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
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

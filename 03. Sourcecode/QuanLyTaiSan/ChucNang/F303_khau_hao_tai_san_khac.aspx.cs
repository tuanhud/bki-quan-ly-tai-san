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

public partial class ChucNang_F303_khau_hao_tai_san_khac : System.Web.UI.Page
{
    #region Members
    private US_GD_KHAU_HAO m_us_gd_khau_hao = new US_GD_KHAU_HAO();
    #endregion

    #region Private methods
    private void load_data_to_cbo_trang_thai_up()
    {

        WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC
            , WinFormControls.eTAT_CA.NO
            , m_cbo_trang_thai_tai_san_up);
    }

    private void load_data_to_cbo_trang_thai_down()
    {
        WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC
            , WinFormControls.eTAT_CA.NO
            , m_cbo_trang_thai_tai_san_down);
    }

    private void load_data_to_bo_tinh_up()
    {
        WinFormControls.load_data_to_cbo_bo_tinh(
                     WinFormControls.eTAT_CA.YES
                     , m_cbo_bo_tinh_up);
    }

    private void load_data_to_bo_tinh_down()
    {
        WinFormControls.load_data_to_cbo_bo_tinh(
                     WinFormControls.eTAT_CA.YES
                     , m_cbo_bo_tinh_down);
    }

    private void load_data_to_dv_chu_quan_up()
    {
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh_up.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan_up);
    }

    private void load_data_to_dv_chu_quan_down()
    {
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh_down.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan_down);
    }

    private void load_data_to_dv_su_dung_up()
    {
        WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan_up.SelectedValue
                    , m_cbo_bo_tinh_up.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung_tai_san_up);
    }

    private void load_data_to_dv_su_dung_down()
    {
        WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan_down.SelectedValue
                    , m_cbo_bo_tinh_down.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung_tai_san_down);
    }

    private void load_from_data()
    {
        load_data_to_bo_tinh_up();
        load_data_to_bo_tinh_down();
        load_data_to_dv_chu_quan_up();
        load_data_to_dv_chu_quan_down();
        load_data_to_dv_su_dung_up();
        load_data_to_dv_su_dung_down();
        load_data_to_grid();
    }

    private void load_data_to_grid()
    {

    }

    private void load_data_from_us()
    {

    }

    private void them_moi_khau_hao(decimal ip_dc_id)
    {

    }

    private void clear_form_data()
    {
        m_lbl_ma_tai_san.Text = "";
        m_lbl_ky_hieu.Text = "";
        m_lbl_nam_san_xuat.Text = "";
        m_lbl_ngay_thang_nam_su_dung.Text = "";
        m_lbl_nguyen_gia_nguon_ns.Text = "";
        m_lbl_nguyen_gia_nguon_khac.Text = "";
        m_lbl_nuoc_san_xuat.Text = "";
        m_lbl_gia_tri_con_lai.Text = "";
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                load_from_data();
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    protected void m_txt_ten_tai_san_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    protected void hdf_id_ValueChanged(object sender, EventArgs e)
    {

    }
    protected void m_cmd_xoa_trang_Click(object sender, EventArgs e)
    {

    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {

    }
    #endregion



}
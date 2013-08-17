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

public partial class ChucNang_F103_KhauHaoOto : System.Web.UI.Page
{

    #region Members

    #endregion

    #region private methods
    private void load_data_to_cbo_trang_thai_up()
    {
        try
        {
            DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
            v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC, CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);
            m_cbo_trang_thai_o_to_up.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_trang_thai_o_to_up.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_trang_thai_o_to_up.DataTextField = CM_DM_TU_DIEN.TEN;
            //m_cbo_trang_thai_o_to_up.SelectedValue = CIPConvert.ToStr(ID_TRANG_THAI_TAI_SAN_KHAC.DANG_SU_DUNG);
            m_cbo_trang_thai_o_to_up.DataBind();
            m_cbo_trang_thai_o_to_up.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }

    private void load_data_to_cbo_trang_thai_down()
    {
        try
        {
            DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
            v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC, CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);
            m_cbo_trang_thai_o_to_down.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_trang_thai_o_to_down.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_trang_thai_o_to_down.DataTextField = CM_DM_TU_DIEN.TEN;
            //m_cbo_trang_thai_o_to_up.SelectedValue = CIPConvert.ToStr(ID_TRANG_THAI_TAI_SAN_KHAC.DANG_SU_DUNG);
            m_cbo_trang_thai_o_to_down.DataBind();
            m_cbo_trang_thai_o_to_down.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //1. load data to combobox bộ, tỉnh - up
                WinFormControls.load_data_to_cbo_bo_tinh(
                         WinFormControls.eTAT_CA.YES
                         , m_cbo_bo_tinh_up);
                //2. load data to combobox đơn vị chủ quản - up
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh_up.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan_up);
                //3. load data to cobobox đơn vị sử dụng - up
                WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan_up.SelectedValue
                    , m_cbo_bo_tinh_up.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung_tai_san_up);
                //4. load data to combobox trạng thái - up
                load_data_to_cbo_trang_thai_up();
                //a. load data to combobox bộ, tỉnh - down
                WinFormControls.load_data_to_cbo_bo_tinh(
                    WinFormControls.eTAT_CA.YES,
                    m_cbo_bo_tinh_down
                    );
                //b. load data to combobox đơn vị chủ quản - down
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(m_cbo_bo_tinh_down.SelectedValue,
                    WinFormControls.eTAT_CA.YES, m_cbo_don_vi_chu_quan_down);
                //c. load data to combobox đơn vi sử dụng - down
                WinFormControls.load_data_to_cbo_don_vi_su_dung(m_cbo_don_vi_chu_quan_down.SelectedValue,
                    m_cbo_bo_tinh_down.SelectedValue, WinFormControls.eTAT_CA.YES, m_cbo_don_vi_su_dung_tai_san_down);
                //d. load data to combobox trạng thái - down
                load_data_to_cbo_trang_thai_down();
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    protected void m_cbo_bo_tinh_up_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    protected void m_cbo_don_vi_chu_quan_up_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    protected void m_cbo_don_vi_su_dung_tai_san_up_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    protected void m_cbo_trang_thai_o_to_up_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    protected void m_cbo_loai_o_to_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    protected void m_cbo_bo_tinh_down_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    protected void m_cbo_don_vi_chu_quan_down_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    protected void m_cbo_don_vi_su_dung_tai_san_down_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    protected void m_cbo_trang_thai_o_to_down_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    #endregion

    
}
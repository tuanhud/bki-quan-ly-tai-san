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

public partial class BaoCao_F308_TH_HTSD_nha_dat_Chi_tiet_theo_loai_hinh_don_vi : System.Web.UI.Page
{
    #region Members

    #endregion

    #region private methods
    private void load_data_to_cbo_trang_thai()
    {
        try
        {
            DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
            v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC, CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);
            m_cbo_trang_thai.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_trang_thai.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN;
            //m_cbo_trang_thai_o_to_up.SelectedValue = CIPConvert.ToStr(ID_TRANG_THAI_TAI_SAN_KHAC.DANG_SU_DUNG);
            m_cbo_trang_thai.DataBind();
            m_cbo_trang_thai.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));

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
                //1. load data to combobox bộ, tỉnh 
                WinFormControls.load_data_to_cbo_bo_tinh(
                         WinFormControls.eTAT_CA.YES
                         , m_cbo_bo_tinh);
                //2. load data to combobox đơn vị chủ quản
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan);
                //3. load data to cobobox đơn vị sử dụng
                WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan.SelectedValue
                    , m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung_tai_san);
                //4. load data to combobox trạng thái
                load_data_to_cbo_trang_thai();
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }




    #endregion
}
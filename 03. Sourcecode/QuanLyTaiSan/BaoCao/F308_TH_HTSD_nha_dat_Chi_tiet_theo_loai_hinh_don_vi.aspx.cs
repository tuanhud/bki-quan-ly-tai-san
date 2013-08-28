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
    #region private methods
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
        m_grv_tai_san_nha_dat.DataBind();
    }
    #endregion

    #region Events
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
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }




    #endregion
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
                ,m_cbo_don_vi_chu_quan.SelectedValue
                );
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
}
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

public partial class BaoCao_F305_TH_tang_giam_tai_san_Chi_tiet_theo_loai_hinh_don_vi : System.Web.UI.Page
{
    #region Members

    #endregion

    #region private methods
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
        if (m_txt_tu_ngay.Text.Equals(""))
        {
            m_txt_tu_ngay.Text = CIPConvert.ToStr("01/01/1900");
        }
        if (m_txt_den_ngay.Text.Equals(""))
        {
            m_txt_den_ngay.Text = CIPConvert.ToStr("01/01/3000");
        }
        if (!CValidateTextBox.IsValid(m_txt_tu_ngay, DataType.DateType, allowNull.YES))
        {
            thongbao("Bạn chưa nhập đúng Từ Ngày!");
            return false;
        }
        if (!CValidateTextBox.IsValid(m_txt_den_ngay, DataType.DateType, allowNull.YES))
        {
            thongbao("Bạn chưa nhập đúng Đến Ngày!");
            return false;
        }
        DateTime v_dat_tu_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text);
        DateTime v_dat_den_ngay = CIPConvert.ToDatetime(m_txt_den_ngay.Text);
        if (v_dat_den_ngay.CompareTo(v_dat_tu_ngay) < 0)
        {
            thongbao("Bạn nhập chưa đúng Từ Ngày, Đến Ngày!");
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
        v_us_rpt_tang_giam_tai_san.FillDataSet_chi_tiet_theo_loai_hinh(
            v_str_user_name
            , CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
            , CIPConvert.ToDatetime(m_txt_tu_ngay.Text)
            , CIPConvert.ToDatetime(m_txt_den_ngay.Text)
            , v_ds_rpt_tang_giam_tai_san
            );
        m_grv_tai_san.DataSource = v_ds_rpt_tang_giam_tai_san.RPT_TANG_GIAM_TAI_SAN;
        m_grv_tai_san.DataBind();
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
            load_data_to_grid_tai_san();
            m_grv_tai_san.Visible = true;
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }

    #endregion
}
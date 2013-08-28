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
using System.Threading;

public partial class BaoCao_F307_TH_HTSD_nha_dat_Tong_hop_chung : System.Web.UI.Page
{
    #region Members

    #endregion

    #region private methods

    private void load_data_to_grid()
    {
        


        DS_RPT_TONG_HOP_HIEN_TRANG v_ds_v_tong_hop_hien_trang = new DS_RPT_TONG_HOP_HIEN_TRANG();
        US_RPT_TONG_HOP_HIEN_TRANG v_us_v_tong_hop_hien_trang = new US_RPT_TONG_HOP_HIEN_TRANG();
        v_us_v_tong_hop_hien_trang.FillDataset_tong_hop_chung(
            CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
            ,CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
            , Person.get_user_name()
            , v_ds_v_tong_hop_hien_trang);
        m_grv_tai_san_nha_dat.DataSource = v_ds_v_tong_hop_hien_trang;
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
                //1. load data to combobox bộ, tỉnh 
                WinFormControls.load_data_to_cbo_bo_tinh(
                         WinFormControls.eTAT_CA.YES
                         , m_cbo_bo_tinh);
                
                //2. load data to combobox đơn vị chủ quản
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan);
                load_data_to_grid();
                //3. load data to cobobox đơn vị sử dụng
                /*WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan.SelectedValue
                    , m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung_tai_san);*/
                //4. load data to combobox trạng thái
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
            /*load_data_to_cbo_don_vi_chu_quan();
            m_grv_danh_sach_tai_san_khac.Visible = false;*/
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES, m_cbo_don_vi_chu_quan);
            m_grv_tai_san_nha_dat.Visible = false;
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    /*protected void m_cbo_don_vi_chu_quan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_tai_san);
            m_grv_tai_san_nha_dat.Visible = false;
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    */
    protected void m_cmd_loc_du_lieu_Click(object sender, EventArgs e)
    {
        try
        {
            Thread.Sleep(2000);
                m_grv_tai_san_nha_dat.Visible = true;
                load_data_to_grid();
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
            Thread.Sleep(2000);
            // vì có phân trang, nên nếu muốn xuất all dữ liệu trên lưới (tất cả các trang) thì thê 2 dòng sau:
            m_grv_tai_san_nha_dat.AllowPaging = false;
            load_data_to_grid();  // đây là hàm load lại dữ liệu lên lưới
            // còn nếu chỉ muốn xuất dữ liệu ở Page hiện tại thì không cần 2 dòng trên
            WinformReport.export_gridview_2_excel(
                       m_grv_tai_san_nha_dat
                        , "DS tong hop chung nha dat.xls"
                        ); // 0 và 1 là số thứ tự 2 cột: Sửa, Xóa
        }
        catch (Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
}
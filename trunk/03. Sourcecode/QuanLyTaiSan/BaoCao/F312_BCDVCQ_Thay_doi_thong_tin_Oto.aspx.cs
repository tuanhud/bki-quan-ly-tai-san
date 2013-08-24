using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPData;
using IP.Core.IPUserService;
using WebDS.CDBNames;
using WebDS;
using IP.Core.IPCommon;
using WebUS;
using QltsForm;
using IP.Core.WinFormControls;
using System.Threading;

public partial class BaoCao_F312_BCDVCQ_Thay_doi_thong_tin_Oto : System.Web.UI.Page
{
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
                WinFormControls.load_data_to_cbo_bo_tinh(
                    WinFormControls.eTAT_CA.YES
                    , m_cbo_bo_tinh);
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan);
                WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                    m_cbo_loai_hinh_don_vi.SelectedValue
                    , m_cbo_don_vi_chu_quan.SelectedValue
                    , m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung_tai_san);
                //load_data_to_cbo_trang_thai();
                WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_OTO, WinFormControls.eTAT_CA.YES, m_cbo_trang_thai);
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }

    #region Member
    US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
    DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
    US_V_DM_OTO_HISTORY m_us_oto = new US_V_DM_OTO_HISTORY();
    DS_V_DM_OTO_HISTORY m_ds_oto = new DS_V_DM_OTO_HISTORY();
    US_CM_DM_TU_DIEN m_us_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_tu_dien = new DS_CM_DM_TU_DIEN();
    #endregion
    #region Private Methods

    /*private void export_excel()
    {
        string v_str_bo_tinh = m_cbo_bo_tinh.SelectedItem.Text;
        string v_str_don_vi_chu_quan = m_cbo_don_vi_chu_quan.SelectedItem.Text;
        decimal v_dc_id_dv_su_dung = CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue);
        string v_str_output_file = "";
        f401_bao_cao_danh_muc_tai_san_khac v_f401_bc_dm_tai_san_khac = new f401_bao_cao_danh_muc_tai_san_khac();
        if (Request.QueryString["ID"] != null)
        {
            string v_id = Request.QueryString["ID"];
            switch (v_id)
            {
                case "1":
                    v_f401_bc_dm_tai_san_khac.expor_excel(f401_bao_cao_danh_muc_tai_san_khac.eFormMode.KE_KHAI_TAI_SAN_KHAC

                                , v_str_bo_tinh
                                , v_str_don_vi_chu_quan
                                , v_dc_id_dv_su_dung
                                , ref v_str_output_file);

                    break;
                case "2":
                    v_f401_bc_dm_tai_san_khac.expor_excel(f401_bao_cao_danh_muc_tai_san_khac.eFormMode.TAI_SAN_KHAC_DE_NGHI_XU_LY

                                , v_str_bo_tinh
                                , v_str_don_vi_chu_quan
                                , v_dc_id_dv_su_dung
                                , ref v_str_output_file);
                    break;
            }
            Response.Clear();
            v_str_output_file = "/QuanLyTaiSan/" + v_str_output_file;
            Response.Redirect(v_str_output_file, false);
        }

    }
    */
    private bool check_validate_data_is_ok()
    {

        //if (!CValidateTextBox.IsValid(m_txt_tu_ngay, DataType.DateType, allowNull.YES)) return false;
        //if (!CValidateTextBox.IsValid(m_txt_tu_ngay, DataType.DateType, allowNull.YES)) return false;
        try
        {
            DateTime m_tu_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text);
            DateTime m_den_ngay = CIPConvert.ToDatetime(m_txt_den_ngay.Text);
            if (m_den_ngay.CompareTo(m_tu_ngay) < 0)
            {
                return false;
            }

        }
        catch (Exception)
        {

        }
        return true;
    }

    private void load_data_to_grid()
    {
            /*US_V_DM_TAI_SAN_KHAC_HISTORY m_us_tai_san_khac = new US_V_DM_TAI_SAN_KHAC_HISTORY();
            DS_V_DM_TAI_SAN_KHAC_HISTORY m_ds_tai_san_khac = new DS_V_DM_TAI_SAN_KHAC_HISTORY();
            US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
            m_us_tai_san_khac.FillDataset(m_ds_tai_san_khac, " where ID_TRANG_THAI = " + m_cbo_trang_thai.SelectedValue.ToString() + "and ID_DON_VI_CHU_QUAN =" + m_cbo_don_vi_chu_quan.SelectedValue.ToString() + "and ID_DON_VI_SU_DUNG =" + m_cbo_don_vi_su_dung_tai_san.SelectedValue.ToString());
            m_grv_tai_san_khac_history.DataSource = m_ds_tai_san_khac;
            m_grv_tai_san_khac_history.DataBind();
            */
            if (!check_validate_data_is_ok()) return;
            string v_id_trang_thai = m_cbo_trang_thai.SelectedValue;
            DateTime v_tsk_tu_ngay;
            DateTime v_tsk_den_ngay;
            if (m_txt_tu_ngay.Text.Trim().Length > 0)
            {
                v_tsk_tu_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text);
            }
            else
            {
                v_tsk_tu_ngay = CIPConvert.ToDatetime("01/01/1900");
            }
            if (m_txt_den_ngay.Text.Trim().Length > 0)
            {
                v_tsk_den_ngay = CIPConvert.ToDatetime(m_txt_den_ngay.Text);
            }
            else
            {
                v_tsk_den_ngay = CIPConvert.ToDatetime("01/01/3000");
            }


            DS_V_DM_OTO_HISTORY v_ds_v_dm_oto_history = new DS_V_DM_OTO_HISTORY();
            US_V_DM_OTO_HISTORY v_us_v_dm_oto_history = new US_V_DM_OTO_HISTORY();
            v_us_v_dm_oto_history.FillDataset(
                CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                ,CIPConvert.ToStr(m_cbo_loai_hinh_don_vi.SelectedValue)
                , v_tsk_tu_ngay
                , v_tsk_den_ngay
                , m_txt_tim_kiem.Text
                , v_ds_v_dm_oto_history);
            m_grv_oto_history.DataSource = v_ds_v_dm_oto_history;
            m_grv_oto_history.DataBind();
        }

    /*private void load_data_to_cbo_bo_tinh()
    {
        try
        {
            US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
            m_us_don_vi.FillDataset(m_ds_don_vi, "Where id_loai_don_vi = " + ID_LOAI_DON_VI.BO_TINH);
            m_cbo_bo_tinh.DataSource = m_ds_don_vi.DM_DON_VI;
            m_cbo_bo_tinh.DataValueField = CIPConvert.ToStr(DM_DON_VI.ID);
            m_cbo_bo_tinh.DataTextField = CIPConvert.ToStr(DM_DON_VI.TEN_DON_VI);
            m_cbo_bo_tinh.DataBind();
            load_data_to_cbo_don_vi_chu_quan();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }*/
    /*private void load_data_to_cbo_don_vi_chu_quan()
    {
        US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
        string v_id_bo_tinh = m_cbo_bo_tinh.SelectedValue;
        m_us_don_vi.FillDataset(m_ds_don_vi, "where ID_LOAI_DON_VI = 575 and ID_DON_VI_CAP_TREN LIKE '%"
            + v_id_bo_tinh + "%'");
        if (m_ds_don_vi.DM_DON_VI.Count != 0)
        {
            m_cbo_don_vi_chu_quan.DataSource = m_ds_don_vi.DM_DON_VI;
            m_cbo_don_vi_chu_quan.DataTextField = "TEN_DON_VI";
            m_cbo_don_vi_chu_quan.DataValueField = "ID";
            m_cbo_don_vi_chu_quan.DataBind();
            //m_cbo_don_vi_chu_quan.Items.Insert(0, new ListItem("Tất cả đơn vị trực thuộc", ""));
            load_data_to_cbo_don_vi_su_dung();
        }
        else//ta
        {
            m_cbo_don_vi_chu_quan.Items.Clear();
            m_cbo_don_vi_su_dung_tai_san.Items.Clear();
        }
    }*/
    /*private void load_data_to_cbo_don_vi_su_dung()
    {
        if (m_cbo_bo_tinh.SelectedValue == null || m_cbo_don_vi_chu_quan.SelectedValue == null)
        {
            return;
        }
        else
        {
            US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();

            string v_id_don_vi_chu_quan = m_cbo_don_vi_chu_quan.SelectedValue;
            m_us_don_vi.FillDataset(m_ds_don_vi, "where ID_LOAI_DON_VI = " + ID_LOAI_DON_VI.DV_SU_DUNG + " and ID_DON_VI_CAP_TREN LIKE '%" + v_id_don_vi_chu_quan
                + "%'");
            if (m_ds_don_vi.DM_DON_VI.Count != 0)
            {
                m_cbo_don_vi_su_dung_tai_san.DataSource = m_ds_don_vi.DM_DON_VI;
                m_cbo_don_vi_su_dung_tai_san.DataTextField = "TEN_DON_VI";
                m_cbo_don_vi_su_dung_tai_san.DataValueField = "ID";
                m_cbo_don_vi_su_dung_tai_san.DataBind();
            }
            else
            {
                //m_cbo_don_vi_chu_quan.Items.Clear();
                m_cbo_don_vi_su_dung_tai_san.Items.Clear();
            }
        }
    }
    private void load_data_to_cbo_trang_thai()
    {
        try
        {
            DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
            //string cmd = "select distinct ma_tu_dien from cm_dm_tu_dien where id_loai_tu_dien=6 or id_loai_tu_dien=7 or id_loai_tu_dien=8";
            //System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(cmd);  
            //"select * from DM_TAI_SAN_KHAC Where TEN_TAI_SAN like '%"+m_txt_tim_kiem.Text+
            //"%' or KY_HIEU like '%"+m_txt_tim_kiem.Text+
            //"%' or NUOC_SAN_XUAT like '%"+m_txt_tim_kiem.Text+
            //"%' or NAM_SAN_XUAT like '%"+m_txt_tim_kiem.Text+
            //"%' or NAM_SU_DUNG like '%"+m_txt_tim_kiem.Text+
            //"%'";

            v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC, CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);

            m_cbo_trang_thai.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_trang_thai.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN;
            m_cbo_trang_thai.DataBind();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }*/
    #endregion

    protected void m_grv_oto_history_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_oto_history.PageIndex = e.NewPageIndex;
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle( v_e);
        }
        
    }

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
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_tai_san);
            m_grv_oto_history.Visible = false;
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }
    protected void m_cbo_don_vi_chu_quan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            /*load_data_to_cbo_don_vi_su_dung();
            m_grv_danh_sach_tai_san_khac.Visible = false;*/
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_tai_san);
            m_grv_oto_history.Visible = false;
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {
            if (m_cbo_don_vi_chu_quan.SelectedValue == "")
            {
                m_lbl_mess.Text = "Bạn chưa chọn Đơn vị chủ quản";
                return;
            }
            if (m_cbo_don_vi_su_dung_tai_san.SelectedValue == "")
            {
                m_lbl_mess.Text = "Bạn chưa chọn Đơn vị sử dụng";
                return;
            }
            else
            {
                m_grv_oto_history.Visible = true;
                Thread.Sleep(2000);
                load_data_to_grid();
            }
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
            //export_excel();
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
    , m_cbo_don_vi_chu_quan.SelectedValue.ToString()
    , m_cbo_bo_tinh.SelectedValue.ToString()
    , WinFormControls.eTAT_CA.YES
    , m_cbo_don_vi_su_dung_tai_san
    );
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
}
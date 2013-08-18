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
            m_cbo_trang_thai.SelectedValue = CIPConvert.ToStr(ID_TRANG_THAI_TAI_SAN_KHAC.DANG_SU_DUNG);
            m_cbo_trang_thai.DataBind();

        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    private void load_data_to_grid_tai_san_khac()
    {
        try
        {
            string v_id_don_vi_chu_quan = m_cbo_don_vi_chu_quan.SelectedValue;
            string v_id_don_vi_su_dung = m_cbo_don_vi_su_dung_tai_san.SelectedValue;
            string v_id_trang_thai = m_cbo_trang_thai.SelectedValue;
            DS_DM_TAI_SAN_KHAC v_ds_dm_tai_san_khac = new DS_DM_TAI_SAN_KHAC();
            US_DM_TAI_SAN_KHAC v_us_dm_tai_san_khac = new US_DM_TAI_SAN_KHAC();
            if (v_id_don_vi_su_dung.Equals(CONST_QLDB.ID_TAT_CA.ToString()))
            {
                v_us_dm_tai_san_khac.FillDataset(v_ds_dm_tai_san_khac, "where id_trang_thai = " + v_id_trang_thai);
            }
            else if (!v_id_don_vi_su_dung.Equals(CONST_QLDB.ID_TAT_CA.ToString()))
            {
                if (v_id_don_vi_chu_quan.Equals(CONST_QLDB.ID_TAT_CA.ToString()))
                {
                    v_us_dm_tai_san_khac.FillDataset(v_ds_dm_tai_san_khac, "where id_trang_thai = " + v_id_trang_thai + " and id_don_vi_su_dung = " + v_id_don_vi_su_dung);
                }
                else
                {
                    v_us_dm_tai_san_khac.FillDataset(v_ds_dm_tai_san_khac, "where id_don_vi_chu_quan = " + v_id_don_vi_chu_quan + " and id_don_vi_su_dung = " + v_id_don_vi_su_dung + " and id_trang_thai = " + v_id_trang_thai);
                }

            }
            //// v_us_dm_tai_san_khac.FillDataset(v_ds_dm_tai_san_khac, "where id_don_vi_su_dung=" + v_id_don_vi_su_dung + " and id_don_vi_chu_quan=" + v_id_don_vi_chu_quan + " and id_trang_thai=" + v_id_trang_thai);
            ////string cmd = "select dm_tai_san_khac.* from cm_dm_tu_dien join dm_tai_san_khac on cm_dm_tu_dien.id=dm_tai_san_khac.id_trang_thai where ( dm_tai_san_khac.nguon_ns+dm_tai_san_khac.nguon_khac >=500000000) and dm_tai_san_khac.id_trang_thai in (select id from cm_dm_TU_DIEN where ma_tu_dien='" + m_cbo_trang_thai.SelectedValue + "')";
            //System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(cmd);
            //v_us_dm_tai_san_khac.FillDatasetByCommand(v_ds_dm_tai_san_khac, command);
            if (v_ds_dm_tai_san_khac.DM_TAI_SAN_KHAC.Count != 0)
            {
                m_grv_tai_san_khac.DataSource = v_ds_dm_tai_san_khac.DM_TAI_SAN_KHAC;
                m_grv_tai_san_khac.DataBind();
            }
            else
            {
                m_grv_tai_san_khac.Visible = false;
                m_lbl_thong_bao.Text = "Không có dữ liệu phù hợp";
            }
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
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
                WinFormControls.load_data_to_cbo_bo_tinh(
                         WinFormControls.eTAT_CA.YES
                         , m_cbo_bo_tinh);
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan);
                WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan.SelectedValue
                    , m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung_tai_san);
                load_data_to_cbo_trang_thai();

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
            m_grv_tai_san_khac.Visible = false;

            WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan);
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_tai_san);
            //load_data_to_cbo_dia_chi(m_cbo_don_vi_su_dung_tai_san.SelectedValue, m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
            //load_data_to_cbo_don_vi_su_dung(m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
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
            m_grv_tai_san_khac.Visible = false;
            //load_data_to_cbo_don_vi_chu_quan(m_cbo_bo_tinh.SelectedValue);
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                     m_cbo_don_vi_chu_quan.SelectedValue
                     , m_cbo_bo_tinh.SelectedValue
                     , WinFormControls.eTAT_CA.YES
                     , m_cbo_don_vi_su_dung_tai_san);
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
            m_grv_tai_san_khac.Visible = true;
            load_data_to_grid_tai_san_khac();
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
            load_data_to_grid_tai_san_khac();
            m_grv_tai_san_khac.PageIndex = e.NewPageIndex;
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
    #endregion
}
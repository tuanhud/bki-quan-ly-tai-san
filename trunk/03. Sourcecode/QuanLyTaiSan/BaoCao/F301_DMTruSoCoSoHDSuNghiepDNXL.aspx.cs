using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using IP.Core.IPData;
using WebDS;
using WebUS;
using WebUS;
using WebDS.CDBNames;
using QltsForm;


public partial class ChucNang_F301_DanhMucTruSoLamViecCoSoHoatDongSuNghiepDeNghiXuLy : System.Web.UI.Page
{


    #region Members
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    US_CM_DM_TU_DIEN m_us_dm_dm_tu_dien = new US_CM_DM_TU_DIEN();

    #endregion

    #region private methods
    private void export_excel()
    {
        US_DM_DON_VI v_us_dm_don_vi;
        US_DM_DAT v_us_dm_dat;
        decimal v_dc_id_dat = CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue);
        v_us_dm_dat = new US_DM_DAT(v_dc_id_dat);
        decimal v_dc_id_dv_su_dung = v_us_dm_dat.dcID_DON_VI_SU_DUNG;
        v_us_dm_don_vi = new US_DM_DON_VI(v_us_dm_dat.dcID_DON_VI_CHU_QUAN);
        string v_str_don_vi_chu_quan = v_us_dm_don_vi.strTEN_DON_VI;
        v_us_dm_don_vi = new US_DM_DON_VI(v_us_dm_don_vi.dcID_DON_VI_CAP_TREN);
        string v_str_bo_tinh = v_us_dm_don_vi.strTEN_DON_VI;

        string v_str_output_file = "";

        if (Request.QueryString["id_loai_bao_cao"] != null)
        {
            string v_id = Request.QueryString["id_loai_bao_cao"];
            f402_bao_cao_danh_muc_tru_so_lam_viec v_f402_bc_dm_nha = new f402_bao_cao_danh_muc_tru_so_lam_viec();
            switch (v_id)
            {
                case "1":
                    v_f402_bc_dm_nha.export_excel(f402_bao_cao_danh_muc_tru_so_lam_viec.eFormMode.DANH_MUC_TRU_SO_LAM_VIEC
                                            , v_str_bo_tinh
                                            , v_str_don_vi_chu_quan
                                            , v_dc_id_dv_su_dung
                                            , v_dc_id_dat
                                            , ref v_str_output_file);
                    break;
                case "2":
                    v_f402_bc_dm_nha.export_excel(f402_bao_cao_danh_muc_tru_so_lam_viec.eFormMode.DE_NGHI_XU_LY
                                            , v_str_bo_tinh
                                            , v_str_don_vi_chu_quan
                                            , v_dc_id_dv_su_dung
                                            , v_dc_id_dat
                                            , ref v_str_output_file);
                    break;
                case "3":
                    break;
            }
        }
        Response.Clear();
        v_str_output_file = "/QuanLyTaiSan/" + v_str_output_file;
        Response.Redirect(v_str_output_file, false);
    }

    private void load_data_to_cbo_bo_tinh()
    {

        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = " + ID_LOAI_DON_VI.BO_TINH);
        m_cbo_bo_tinh.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_cbo_bo_tinh.DataTextField = "TEN_DON_VI";
        m_cbo_bo_tinh.DataValueField = "ID";
        m_cbo_bo_tinh.DataBind();
        m_cbo_bo_tinh.Items.Insert(0, new ListItem("Tất cả", "-1"));

    }

    private void load_data_to_cbo_don_vi_chu_quan(string ip_str_id_bo_tinh)
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        if (ip_str_id_bo_tinh.Equals("-1"))
        {
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = " + ID_LOAI_DON_VI.DV_CHU_QUAN);
        }
        else
        {
            decimal v_dc_id_bo_tinh = CIPConvert.ToDecimal(ip_str_id_bo_tinh);
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = " + ID_LOAI_DON_VI.DV_CHU_QUAN
            + " AND ID_DON_VI_CAP_TREN = " + v_dc_id_bo_tinh);
        }

        m_cbo_don_vi_chu_quan.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_cbo_don_vi_chu_quan.DataTextField = "TEN_DON_VI";
        m_cbo_don_vi_chu_quan.DataValueField = "ID";
        m_cbo_don_vi_chu_quan.DataBind();
        m_cbo_don_vi_chu_quan.Items.Insert(0, new ListItem("Tất cả", "-1"));

    }
    private void load_data_to_cbo_don_vi_su_dung(string ip_str_id_don_vi_chu_quan, string ip_str_id_bo_tinh)
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        if (!ip_str_id_don_vi_chu_quan.Equals("-1"))
        {
            decimal v_dc_id_don_vi_chu_quan = CIPConvert.ToDecimal(ip_str_id_don_vi_chu_quan);
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_DON_VI_CAP_TREN = " + v_dc_id_don_vi_chu_quan + " or ID = " + v_dc_id_don_vi_chu_quan);
        }
        else if (!ip_str_id_bo_tinh.Equals("-1"))
        {
            decimal v_dc_id_bo_tinh = CIPConvert.ToDecimal(ip_str_id_bo_tinh);
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_DON_VI_CAP_TREN in (select ID from DM_DON_VI where ID_DON_VI_CAP_TREN = "
                + v_dc_id_bo_tinh + ") or ID_DON_VI_CAP_TREN = " + v_dc_id_bo_tinh);
        }
        else
        {
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "WHERE ID_LOAI_DON_VI IN (" + ID_LOAI_DON_VI.DV_SU_DUNG + "," + ID_LOAI_DON_VI.DV_CHU_QUAN + ")");
        }

        m_cbo_don_vi_su_dung_tai_san.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_cbo_don_vi_su_dung_tai_san.DataTextField = "TEN_DON_VI";
        m_cbo_don_vi_su_dung_tai_san.DataValueField = "ID";
        m_cbo_don_vi_su_dung_tai_san.DataBind();
        m_cbo_don_vi_su_dung_tai_san.Items.Insert(0, new ListItem("Tất cả", "-1"));
    }

    private void load_data_to_cbo_dia_chi(string ip_str_id_don_vi_su_dung, string ip_str_id_don_vi_chu_quan, string ip_string_bo_tinh)
    {
        DS_DM_DAT v_ds_dm_dat = new DS_DM_DAT();
        US_DM_DAT v_us_dm_dat = new US_DM_DAT();

        if (!ip_str_id_don_vi_su_dung.Equals("-1"))
        {
            v_us_dm_dat.FillDataset(v_ds_dm_dat, "where " + DM_DAT.ID_DON_VI_SU_DUNG + " = " + ip_str_id_don_vi_su_dung);
        }
        else if (!ip_str_id_don_vi_su_dung.Equals("-1"))
        {
            v_us_dm_dat.FillDataset(v_ds_dm_dat, "where " + DM_DAT.ID_DON_VI_CHU_QUAN + " = " + ip_str_id_don_vi_chu_quan);
        }
        else if (!ip_string_bo_tinh.Equals("-1"))
        {
            v_us_dm_dat.FillDataset(v_ds_dm_dat, "where " + DM_DAT.ID_DON_VI_CHU_QUAN
                + " in (select ID from DM_DON_VI where " + DM_DON_VI.ID_DON_VI_CAP_TREN + " = " + ip_string_bo_tinh + ")");
        }
        else
        {
            v_us_dm_dat.FillDataset(v_ds_dm_dat);
        }

        m_cbo_dia_chi.DataSource = v_ds_dm_dat.DM_DAT;
        m_cbo_dia_chi.DataTextField = "DIA_CHI";
        m_cbo_dia_chi.DataValueField = "ID";
        m_cbo_dia_chi.DataBind();
    }

    private void load_data_to_thong_tin_nha_dat()
    {
        try
        {
            string v_id_dat = m_cbo_dia_chi.SelectedValue;
            DS_DM_DAT v_ds_dm_dat = new DS_DM_DAT();
            US_DM_DAT v_us_dm_dat = new US_DM_DAT(CIPConvert.ToDecimal(v_id_dat));
            m_lbl_dia_chi.Text = v_us_dm_dat.strDIA_CHI;
            m_lbl_dien_tich_khuon_vien_dat.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_KHUON_VIEN, "#,##0.00") + "   ";
            m_lbl_lam_tru_so_lam_viec.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_TRU_SO_LAM_VIEC, "#,##0.00");
            m_lbl_lam_tru_so_lam_viec.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_TRU_SO_LAM_VIEC, "#,##0.00");
            m_lbl_lam_co_so_hd_du_nghiep.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_CO_SO_HOAT_DONG_SU_NGHIEP, "#,##0.00");
            m_lbl_lam_nha_o.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_LAM_NHA_O, "#,##0.00");
            m_lbl_cho_thue.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_CHO_THUE, "#,##0.00");
            m_lbl_bo_trong.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_BO_TRONG, "#,##0.00");
            m_lbl_bi_lan_chiem.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_BI_LAN_CHIEM, "#,##0.00");
            m_lbl_su_dung_vao_muc_dich_khac.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_SU_DUNG_MUC_DICH_KHAC, "#,##0.00");
            m_lbl_gia_tri_theo_so_ke_toan.Text = CIPConvert.ToStr(v_us_dm_dat.dcGT_THEO_SO_KE_TOAN, "#,##0.00");
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    private void load_data_to_grid_nha()
    {
        try
        {
            DS_DM_NHA v_ds_dm_nha = new DS_DM_NHA();
            US_DM_NHA v_us_dm_nha = new US_DM_NHA();
            string v_id_dat = m_cbo_dia_chi.SelectedValue;
            string id_loai_bao_cao = "";
            if (Request.QueryString["id_loai_bao_cao"] != null)
            {
                id_loai_bao_cao = Request.QueryString["id_loai_bao_cao"];
            }

            switch (id_loai_bao_cao)
            {
                case "1":
                    // m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNNG SỰ NGHIỆP";
                    v_us_dm_nha.FillDataset(v_ds_dm_nha, "where id_dat = " + v_id_dat);
                    break;
                case "2":
                    // m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNNG SỰ NGHIỆP ĐỀ NGHỊ XỬ LÝ";
                    v_us_dm_nha.FillDataset(v_ds_dm_nha, "where id_dat = " + v_id_dat + " and id_trang_thai = " + ID_TRANG_THAI_NHA.DE_NGHI_XU_LY);
                    break;
                //case "3":
                //    m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, TRỤ SỞ HOẠT ĐỘNG GIAO CHO ĐƠN VỊ SỰ NGHIỆP TỰ CHỦ TÀI CHÍNH";
                //    m_us_dm_nha.FillDataset(m_ds_dm_nha,"where id_dat = "+ v_id_dat+" and id_loai_don_vi")
            }


            m_grv_nha.DataSource = v_ds_dm_nha.DM_NHA;
            m_grv_nha.DataBind();

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }

    private void form_title()
    {
        try
        {
            string v_id_dat = m_cbo_dia_chi.SelectedValue;
            string id_loai_bao_cao = "";
            if (Request.QueryString["id_loai_bao_cao"] != null)
            {
                id_loai_bao_cao = Request.QueryString["id_loai_bao_cao"];
            }

            switch (id_loai_bao_cao)
            {

                case "1":
                    m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNNG SỰ NGHIỆP";

                    break;
                case "2":
                    m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNNG SỰ NGHIỆP ĐỀ NGHỊ XỬ LÝ";

                    break;
                //case "3":
                //    m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, TRỤ SỞ HOẠT ĐỘNG GIAO CHO ĐƠN VỊ SỰ NGHIỆP TỰ CHỦ TÀI CHÍNH";
                //    m_us_dm_nha.FillDataset(m_ds_dm_nha,"where id_dat = "+ v_id_dat+" and id_loai_don_vi")
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }

    private void format_label_disable()
    {
        try
        {
            m_pnl_thong_tin_nha_dat.Visible = false;
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }

    private void format_label_able()
    {
        try
        {
            m_pnl_thong_tin_nha_dat.Visible = true;
            m_grv_nha.Visible = true;
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    #endregion

    #region events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                form_title();
                format_label_disable();
                load_data_to_cbo_bo_tinh();
                load_data_to_cbo_don_vi_chu_quan(m_cbo_bo_tinh.SelectedValue);
                load_data_to_cbo_don_vi_su_dung(m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
                load_data_to_cbo_dia_chi(m_cbo_don_vi_su_dung_tai_san.SelectedValue, m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }

    protected void m_grv_danh_sach_nha_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_nha.PageIndex = e.NewPageIndex;
            load_data_to_grid_nha();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    protected void m_cbo_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            load_data_to_cbo_don_vi_chu_quan(m_cbo_bo_tinh.SelectedValue);
            load_data_to_cbo_don_vi_su_dung(m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
            load_data_to_cbo_dia_chi(m_cbo_don_vi_su_dung_tai_san.SelectedValue, m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
            m_pnl_thong_tin_nha_dat.Visible = false;
            m_grv_nha.Visible = false;
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
            m_lbl_mess.Text = "";
            load_data_to_cbo_don_vi_su_dung(m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
            load_data_to_cbo_dia_chi(m_cbo_don_vi_su_dung_tai_san.SelectedValue, m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
            m_pnl_thong_tin_nha_dat.Visible = false;
            m_grv_nha.Visible = false;

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }
    protected void m_cbo_don_vi_su_dung_tai_san_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            load_data_to_cbo_dia_chi(m_cbo_don_vi_su_dung_tai_san.SelectedValue, m_cbo_don_vi_chu_quan.SelectedValue, m_cbo_bo_tinh.SelectedValue);
            m_pnl_thong_tin_nha_dat.Visible = false;
            m_grv_nha.Visible = false;
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }
    protected void m_cmd_loc_du_lieu_Click(object sender, EventArgs e)
    {
        try
        {

            format_label_able();
            load_data_to_thong_tin_nha_dat();
            load_data_to_grid_nha();


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

            export_excel();
        }

        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
}
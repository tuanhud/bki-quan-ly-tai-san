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
using IP.Core.WinFormControls;
using System.Threading;
using IP.Core.QltsFormControls;
using IP.Core;

public partial class BaoCao_F301_DMTruSoCoSoHDSuNghiepDNXL : System.Web.UI.Page
{
    #region Members
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    US_CM_DM_TU_DIEN m_us_dm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    #endregion

    #region private methods
    private void form_2_objExcelAssetParameters(CObjExcelAssetParameters op_obj_parameter)
    {
        op_obj_parameter.dcID_BO_TINH = CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue);
        op_obj_parameter.strTEN_BO_TINH = m_cbo_bo_tinh.SelectedItem.Text;
        op_obj_parameter.dcID_DON_VI_CHU_QUAN = CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue);
        op_obj_parameter.strTEN_DON_VI_CHU_QUAN = m_cbo_don_vi_chu_quan.SelectedItem.Text;
        op_obj_parameter.dcID_DON_VI_SU_DUNG = CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue);
        op_obj_parameter.strTEN_DON_VI_SU_DUNG = m_cbo_don_vi_su_dung_tai_san.SelectedItem.Text;
        op_obj_parameter.dcID_TRANG_THAI_TAI_SAN = CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue);
        op_obj_parameter.strTEN_TRANG_THAI_TAI_SAN = m_cbo_trang_thai.SelectedItem.Text;
        op_obj_parameter.strKEY_SEARCH = String.Empty;
        op_obj_parameter.dcID_LOAI_TAI_SAN = ID_LOAI_TAI_SAN.NHA;
        op_obj_parameter.strTEN_LOAI_TAI_SAN = CONST_QLDB.TAT_CA;
        op_obj_parameter.strLOAI_HINH_DON_VI = m_cbo_loai_hinh_don_vi.SelectedItem.Text;
        op_obj_parameter.strMA_LOAI_HINH_DON_VI = m_cbo_loai_hinh_don_vi.SelectedValue;
        op_obj_parameter.strUSER_NAME = Person.get_user_name();
    }
    private void export_excel()
    {
        string v_str_output_file = "";
        if (Request.QueryString["id_loai_bao_cao"] != null)
        {
            string v_id = Request.QueryString["id_loai_bao_cao"];
            f402_bao_cao_danh_muc_tru_so_lam_viec v_f402_bc_dm_nha = new f402_bao_cao_danh_muc_tru_so_lam_viec();
            CObjExcelAssetParameters v_obj_parameter = new CObjExcelAssetParameters();
            form_2_objExcelAssetParameters(v_obj_parameter);
            switch (v_id)
            {
                case "1":
                    v_f402_bc_dm_nha.export_excel(f402_bao_cao_danh_muc_tru_so_lam_viec.eFormMode.DANH_MUC_TRU_SO_LAM_VIEC
                                            , CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue)
                                            , ref v_obj_parameter);
                    break;
                case "2":
                    v_f402_bc_dm_nha.export_excel(f402_bao_cao_danh_muc_tru_so_lam_viec.eFormMode.DE_NGHI_XU_LY
                                            , CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue)
                                            , ref v_obj_parameter);
                    break;
                case "3":
                    v_f402_bc_dm_nha.export_excel(f402_bao_cao_danh_muc_tru_so_lam_viec.eFormMode.TRU_SO_GIAO_CHO_DON_VI_SU_NGHIEP
                                            , CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue)
                                            , ref v_obj_parameter);
                    break;
            }
            Response.Clear();
            v_str_output_file = "/QuanLyTaiSan/" + v_obj_parameter.strFILE_NAME_RESULT;
            Response.Redirect(v_str_output_file, false);
        }

    }
    private void load_data_to_thong_tin_nha_dat()
    {

        decimal v_dc_id_dat = CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue);
        if (v_dc_id_dat == -1)
        {
            m_pnl_thong_tin_nha_dat.Visible = false;
            return;
        }
        m_pnl_thong_tin_nha_dat.Visible = true;
        US_DM_DAT v_us_dm_dat = new US_DM_DAT(v_dc_id_dat);
        m_lbl_dia_chi.Text = v_us_dm_dat.strDIA_CHI;
        m_lbl_dien_tich_khuon_vien_dat.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_KHUON_VIEN, "#,##0.00");
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
    private bool check_validate_data_is_ok()
    {
        m_lbl_mess.Text = "";
        if (m_cbo_bo_tinh.SelectedValue.Equals(""))
        {
            m_lbl_mess.Text = "Không có Bộ, tỉnh!";
            return false;
        }
        if (m_cbo_don_vi_chu_quan.SelectedValue.Equals(""))
        {
            m_lbl_mess.Text = "Không có Đơn vị chủ quản!";
            return false;
        }
        if (m_cbo_don_vi_su_dung_tai_san.SelectedValue.Equals(""))
        {
            m_lbl_mess.Text = "Không có Đơn vị sử dụng!";
            return false;
        }
        if (m_cbo_dia_chi.SelectedValue.Equals(""))
        {
            m_lbl_mess.Text = "Không có Địa Chỉ Đất!";
            return false;
        }

        return true;
    }
    private void load_data_to_grid_nha()
    {
        DS_V_DM_NHA v_ds_v_dm_nha = new DS_V_DM_NHA();
        US_V_DM_NHA v_us_v_dm_nha = new US_V_DM_NHA();
        string v_id_dat = m_cbo_dia_chi.SelectedValue;
        string id_loai_bao_cao = "";
        string v_str_user_name = Person.get_user_name();
        if (v_str_user_name.Equals(null)) return;

        if (Request.QueryString["id_loai_bao_cao"] != null)
        {
            id_loai_bao_cao = Request.QueryString["id_loai_bao_cao"];
        }
        switch (id_loai_bao_cao)
        {
            case "1":
                v_us_v_dm_nha.FillDatasetLoadDataToGridNha_loai_hinh(
                    CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                    , m_cbo_loai_hinh_don_vi.SelectedValue
                    , v_str_user_name
                    , v_ds_v_dm_nha
                    );
                break;
            case "2":
                v_us_v_dm_nha.FillDatasetLoadDataToGridNha_loai_hinh(
                    CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                    , m_cbo_loai_hinh_don_vi.SelectedValue
                    , v_str_user_name
                    , v_ds_v_dm_nha
                    );
                break;
            //case "3":
            // m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, TRỤ SỞ HOẠT ĐỘNG GIAO CHO ĐƠN VỊ SỰ NGHIỆP TỰ CHỦ TÀI CHÍNH";
            // m_us_dm_nha.FillDataset(m_ds_dm_nha,"where id_dat = "+ v_id_dat+" and id_loai_don_vi")
        }
        m_grv_nha.DataSource = v_ds_v_dm_nha.V_DM_NHA;
        Thread.Sleep(1000);
        m_grv_nha.DataBind();

    }
    private void form_title()
    {
        string id_loai_bao_cao = "";
        if (Request.QueryString["id_loai_bao_cao"] != null)
        {
            id_loai_bao_cao = Request.QueryString["id_loai_bao_cao"];
        }

        switch (id_loai_bao_cao)
        {

            case "1":
                m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNG SỰ NGHIỆP";

                break;
            case "2":
                m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNG SỰ NGHIỆP ĐỀ NGHỊ XỬ LÝ";

                break;
            //case "3":
            //    m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, TRỤ SỞ HOẠT ĐỘNG GIAO CHO ĐƠN VỊ SỰ NGHIỆP TỰ CHỦ TÀI CHÍNH";
            //    m_us_dm_nha.FillDataset(m_ds_dm_nha,"where id_dat = "+ v_id_dat+" and id_loai_don_vi")
        }

    }
    private void format_label_disable()
    {

        m_pnl_thong_tin_nha_dat.Visible = false;

    }
    private void format_label_able()
    {

        m_pnl_thong_tin_nha_dat.Visible = true;
        m_grv_nha.Visible = true;

    }
    #endregion

    #region events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                m_lbl_mess.Text = "";
                form_title();
                format_label_disable();
                if (Request.QueryString["id_loai_bao_cao"].Equals(null)) return;
                string v_str_id_loai_bao_cao = Request.QueryString["id_loai_bao_cao"];
                WinFormControls.load_data_to_cbo_bo_tinh(
                   WinFormControls.eTAT_CA.NO
                   , m_cbo_bo_tinh);
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.NO
                    , m_cbo_don_vi_chu_quan);
                WinFormControls.load_data_to_cbo_loai_hinh_don_vi(
                    WinFormControls.eLOAI_TU_DIEN.LOAI_HINH_DON_VI
                    , WinFormControls.eTAT_CA.NO
                    , m_cbo_loai_hinh_don_vi
                    );
                switch (v_str_id_loai_bao_cao)
                {
                    case "1":
                        //load data to combobox trang thai nha
                        WinFormControls.load_data_to_cbo_tu_dien(
                            WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_NHA
                            , WinFormControls.eTAT_CA.NO
                            , m_cbo_trang_thai
                            );
                        m_cbo_trang_thai.SelectedValue = ID_TRANG_THAI_NHA.DANG_SU_DUNG.ToString();
                        m_cbo_trang_thai.Enabled = false;
                        WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                            m_cbo_loai_hinh_don_vi.SelectedValue
                            , m_cbo_don_vi_chu_quan.SelectedValue
                            , m_cbo_bo_tinh.SelectedValue
                            , WinFormControls.eTAT_CA.NO
                            , m_cbo_don_vi_su_dung_tai_san
                            );
                        if (m_cbo_don_vi_su_dung_tai_san.SelectedValue.Equals(""))
                        {
                            m_cbo_dia_chi.DataSource = null;
                            m_cbo_dia_chi.DataBind();
                            return;
                        }
                        WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                            CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                            , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                            , m_cbo_loai_hinh_don_vi.SelectedValue
                            , WinFormControls.eTAT_CA.NO
                            , m_cbo_dia_chi
                            );
                        break;
                    case "2":
                        //load data to combobox trang thai nha
                        WinFormControls.load_data_to_cbo_tu_dien(
                            WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_NHA
                            , WinFormControls.eTAT_CA.NO
                            , m_cbo_trang_thai
                            );
                        m_cbo_trang_thai.SelectedValue = ID_TRANG_THAI_NHA.DE_NGHI_XU_LY.ToString();
                        m_cbo_trang_thai.Enabled = false;
                        WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                            m_cbo_loai_hinh_don_vi.SelectedValue
                            , m_cbo_don_vi_chu_quan.SelectedValue
                            , m_cbo_bo_tinh.SelectedValue
                            , WinFormControls.eTAT_CA.NO
                            , m_cbo_don_vi_su_dung_tai_san
                            );
                        if (m_cbo_don_vi_su_dung_tai_san.SelectedValue.Equals(""))
                        {
                            m_cbo_dia_chi.DataSource = null;
                            m_cbo_dia_chi.DataBind();
                            return;
                        }
                        WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                            CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                            , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                            , m_cbo_loai_hinh_don_vi.SelectedValue
                            , WinFormControls.eTAT_CA.NO
                            , m_cbo_dia_chi
                            );
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                }
            }
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_danh_sach_nha_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            m_grv_nha.PageIndex = e.NewPageIndex;
            load_data_to_grid_nha();
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
            if (Request.QueryString["id_loai_bao_cao"].Equals(null)) return;
            string v_str_id_loai_bao_cao = Request.QueryString["id_loai_bao_cao"];
            m_lbl_mess.Text = "";
            switch (v_str_id_loai_bao_cao)
            {
                case "1":
                    WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                            m_cbo_bo_tinh.SelectedValue
                            , WinFormControls.eTAT_CA.NO, m_cbo_don_vi_chu_quan);
                    WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                            m_cbo_loai_hinh_don_vi.SelectedValue
                            , m_cbo_don_vi_chu_quan.SelectedValue
                            , m_cbo_bo_tinh.SelectedValue
                            , WinFormControls.eTAT_CA.NO
                            , m_cbo_don_vi_su_dung_tai_san);
                    WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                             CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                           , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                           , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                           , ID_TRANG_THAI_DAT.DANG_SU_DUNG
                           , m_cbo_loai_hinh_don_vi.SelectedValue
                           , WinFormControls.eTAT_CA.NO
                           , m_cbo_dia_chi);
                    break;
                case "2":
                    WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                            m_cbo_bo_tinh.SelectedValue
                            , WinFormControls.eTAT_CA.NO, m_cbo_don_vi_chu_quan);
                    WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                            m_cbo_loai_hinh_don_vi.SelectedValue
                            , m_cbo_don_vi_chu_quan.SelectedValue
                            , m_cbo_bo_tinh.SelectedValue
                            , WinFormControls.eTAT_CA.NO
                            , m_cbo_don_vi_su_dung_tai_san);
                    WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                             CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                           , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                           , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                           , ID_TRANG_THAI_DAT.DANG_SU_DUNG
                           , m_cbo_loai_hinh_don_vi.SelectedValue
                           , WinFormControls.eTAT_CA.NO
                           , m_cbo_dia_chi);
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
            }

            m_pnl_thong_tin_nha_dat.Visible = false;
            m_grv_nha.Visible = false;
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
            m_lbl_mess.Text = "";
            if (Request.QueryString["id_loai_bao_cao"].Equals(null)) return;
            string v_str_id_loai_bao_cao = Request.QueryString["id_loai_bao_cao"];
            switch (v_str_id_loai_bao_cao)
            {
                case "1":
                    WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                            m_cbo_loai_hinh_don_vi.SelectedValue
                            , m_cbo_don_vi_chu_quan.SelectedValue
                            , m_cbo_bo_tinh.SelectedValue
                            , WinFormControls.eTAT_CA.NO
                            , m_cbo_don_vi_su_dung_tai_san);
                    WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                             CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                           , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                           , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                           , ID_TRANG_THAI_DAT.DANG_SU_DUNG
                           , m_cbo_loai_hinh_don_vi.SelectedValue
                           , WinFormControls.eTAT_CA.NO
                           , m_cbo_dia_chi);
                    break;
                case "2":
                    WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                            m_cbo_loai_hinh_don_vi.SelectedValue
                            , m_cbo_don_vi_chu_quan.SelectedValue
                            , m_cbo_bo_tinh.SelectedValue
                            , WinFormControls.eTAT_CA.NO
                            , m_cbo_don_vi_su_dung_tai_san);
                    WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                             CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                           , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                           , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                           , ID_TRANG_THAI_DAT.DANG_SU_DUNG
                           , m_cbo_loai_hinh_don_vi.SelectedValue
                           , WinFormControls.eTAT_CA.NO
                           , m_cbo_dia_chi);
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
            }
            m_pnl_thong_tin_nha_dat.Visible = false;
            m_grv_nha.Visible = false;
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_su_dung_tai_san_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            if (Request.QueryString["id_loai_bao_cao"].Equals(null)) return;
            string v_str_id_loai_bao_cao = Request.QueryString["id_loai_bao_cao"];
            switch (v_str_id_loai_bao_cao)
            {
                case "1":
                    WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                             CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                           , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                           , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                           , ID_TRANG_THAI_DAT.DANG_SU_DUNG
                           , m_cbo_loai_hinh_don_vi.SelectedValue
                           , WinFormControls.eTAT_CA.NO
                           , m_cbo_dia_chi);
                    break;
                case "2":
                      WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                             CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                           , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                           , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                           , ID_TRANG_THAI_DAT.DANG_SU_DUNG
                           , m_cbo_loai_hinh_don_vi.SelectedValue
                           , WinFormControls.eTAT_CA.NO
                           , m_cbo_dia_chi);
                    break;
                case "3":
                    break;
                case "4":
                    break;
            }

            US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI(CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue));
            m_cbo_loai_hinh_don_vi.SelectedValue = v_us_dm_don_vi.strLOAI_HINH_DON_VI;
            m_pnl_thong_tin_nha_dat.Visible = false;
            m_grv_nha.Visible = false;
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
            m_lbl_mess.Text = "";
            if (!check_validate_data_is_ok()) return;
            format_label_able();
            load_data_to_thong_tin_nha_dat();
            load_data_to_grid_nha();

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
            if (!check_validate_data_is_ok()) return;
            export_excel();
        }

        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_loai_hinh_don_vi_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
                if (Request.QueryString["id_loai_bao_cao"].Equals(null)) return;
            string v_str_id_loai_bao_cao = Request.QueryString["id_loai_bao_cao"];
            switch (v_str_id_loai_bao_cao)
            {
                case "1":
                    WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                            m_cbo_loai_hinh_don_vi.SelectedValue
                            , m_cbo_don_vi_chu_quan.SelectedValue
                            , m_cbo_bo_tinh.SelectedValue
                            , WinFormControls.eTAT_CA.NO
                            , m_cbo_don_vi_su_dung_tai_san
                    );
                    if (m_cbo_don_vi_su_dung_tai_san.SelectedValue.Equals(""))
                    {
                        m_lbl_mess.Text = "Không có Đơn vị sử dụng!";
                        return;
                    }
                    WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                             CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                           , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                           , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                           , ID_TRANG_THAI_DAT.DANG_SU_DUNG
                           , m_cbo_loai_hinh_don_vi.SelectedValue
                           , WinFormControls.eTAT_CA.NO
                           , m_cbo_dia_chi);
                    break;
                case "2":
                    WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                            m_cbo_loai_hinh_don_vi.SelectedValue
                            , m_cbo_don_vi_chu_quan.SelectedValue
                            , m_cbo_bo_tinh.SelectedValue
                            , WinFormControls.eTAT_CA.NO
                            , m_cbo_don_vi_su_dung_tai_san
                    );
                    if (m_cbo_don_vi_su_dung_tai_san.SelectedValue.Equals(""))
                    {
                        m_lbl_mess.Text = "Không có Đơn vị sử dụng!";
                        return;
                    }
                    WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                             CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                           , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                           , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                           , ID_TRANG_THAI_DAT.DANG_SU_DUNG
                           , m_cbo_loai_hinh_don_vi.SelectedValue
                           , WinFormControls.eTAT_CA.NO
                           , m_cbo_dia_chi);
                    break;
                case "3":
                    break;
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    #endregion
}
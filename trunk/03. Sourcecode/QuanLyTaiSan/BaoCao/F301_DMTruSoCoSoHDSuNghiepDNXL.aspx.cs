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
using WebDS.CDBNames;
using QltsForm;
using IP.Core.WinFormControls;
using System.Threading;
using IP.Core.QltsFormControls;
using IP.Core;

public partial class BaoCao_F301_DMTruSoCoSoHDSuNghiepDNXL : System.Web.UI.Page
{
    #region Public Interface
    #endregion

    #region Members
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    US_CM_DM_TU_DIEN m_us_dm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    #endregion

    #region DataStructure
    public class LOAI_BAO_CAO_THAM_SO
    {
        public const string C_STR_LOAI_KE_KHAI = "1";
        public const string C_STR_LOAI_DE_NGHI_XU_LY = "2";
        public const string C_STR_LOAI_THONG_KE = "3";
    }

    #endregion

    #region Private Methods
    private void thong_bao(string ip_str_thong_bao)
    {
        m_lbl_mess.Text = ip_str_thong_bao;
    }
    private void reset_thong_bao()
    {
        m_lbl_mess.Text = "";
    }
    private void truyen_tham_so_tu_form_vao_obj_de_xuat_excel(CObjExcelAssetParameters op_obj_parameter)
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
    private void xuat_excel()
    {
        if (!check_data_validate_is_ok()) return;
        string v_str_output_file = "";
        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO] != null)
        {
            string v_id = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO];
            f402_bao_cao_danh_muc_tru_so_lam_viec v_f402_bc_dm_nha = new f402_bao_cao_danh_muc_tru_so_lam_viec();
            CObjExcelAssetParameters v_obj_parameter = new CObjExcelAssetParameters();
            truyen_tham_so_tu_form_vao_obj_de_xuat_excel(v_obj_parameter);
            switch (v_id)
            {
                case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_KE_KHAI:
                    v_f402_bc_dm_nha.export_excel(f402_bao_cao_danh_muc_tru_so_lam_viec.eFormMode.KE_KHAI
                                            , CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue)
                                            , ref v_obj_parameter);
                    break;
                case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_DE_NGHI_XU_LY:
                    v_f402_bc_dm_nha.export_excel(f402_bao_cao_danh_muc_tru_so_lam_viec.eFormMode.DE_NGHI_XU_LY
                                            , CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue)
                                            , ref v_obj_parameter);
                    break;
                case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_THONG_KE:
                    v_f402_bc_dm_nha.export_excel(f402_bao_cao_danh_muc_tru_so_lam_viec.eFormMode.THONG_KE
                                            , CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue)
                                            , ref v_obj_parameter);
                    break;
            }
            Response.Clear();
            v_str_output_file = "/QuanLyTaiSan/" + v_obj_parameter.strFILE_NAME_RESULT;
            Response.Redirect(v_str_output_file, false);
        }

    }
    private void truyen_thong_tin_ve_khu_dat()
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
    private bool check_data_validate_is_ok()
    {
        reset_thong_bao();
        if (m_cbo_bo_tinh.SelectedValue.Equals(""))
        {
            thong_bao("Không có Bộ, tỉnh!");
            return false;
        }
        if (m_cbo_don_vi_chu_quan.SelectedValue.Equals(""))
        {
            thong_bao("Không có Đơn vị chủ quản!");
            return false;
        }
        if (m_cbo_don_vi_su_dung_tai_san.SelectedValue.Equals(""))
        {
            thong_bao("Không có Đơn vị sử dụng!");
            return false;
        }
        if (m_cbo_dia_chi.SelectedValue.Equals(""))
        {
            thong_bao("Không có Địa Chỉ Đất!");
            return false;
        }

        return true;
    }
    private void load_data_to_grid_nha()
    {
        if (!check_data_validate_is_ok()) return;
        DS_V_DM_NHA v_ds_v_dm_nha = new DS_V_DM_NHA();
        US_V_DM_NHA v_us_v_dm_nha = new US_V_DM_NHA();
        string v_id_dat = m_cbo_dia_chi.SelectedValue;
        string id_loai_bao_cao = "";
        string v_str_user_name = Person.get_user_name();
        if (v_str_user_name.Equals(null)) return;

        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO] != null)
        {
            id_loai_bao_cao = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO];
        }
        v_us_v_dm_nha.FillDatasetLoadDataToGridNha_by_tu_khoa(
            ""
            , CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
            , m_cbo_loai_hinh_don_vi.SelectedValue
            , v_str_user_name
            , v_ds_v_dm_nha
            );
             
        m_grv_nha.DataSource = v_ds_v_dm_nha.V_DM_NHA;
        if (v_ds_v_dm_nha.V_DM_NHA.Count == 0) thong_bao("Không có kết quả tìm kiếm phù hợp!");
        Thread.Sleep(1000);
        string v_str_thong_tin = " (Có " + v_ds_v_dm_nha.V_DM_NHA.Rows.Count + " bản ghi)";
        m_lbl_title.Text += v_str_thong_tin;
        m_grv_nha.DataBind();

    }
    private void truyen_tieu_de()
    {
        string id_loai_bao_cao = "";
        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO] != null)
        {
            id_loai_bao_cao = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO];
        }

        switch (id_loai_bao_cao)
        {

            case "1":
                m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNG SỰ NGHIỆP";
                break;
            case "2":
                m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNG SỰ NGHIỆP ĐỀ NGHỊ XỬ LÝ";
                break;
            case "3":
                m_lbl_tieu_de.Text = "BÁO CÁO THỐNG KÊ TRỤ SỞ LÀM VIỆC, TRỤ SỞ HOẠT ĐỘNG";
                break;
        }

    }
    private void an_hien_gird_nha(bool ip_bool_visible)
    {
        m_grv_nha.Visible = ip_bool_visible;
    }
    private void an_hien_thong_tin_ve_khu_dat(bool ip_bool_visible)
    {
        m_pnl_thong_tin_nha_dat.Visible = ip_bool_visible;
    }
    private string get_querryString()
    {
        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO].Equals(null)) return "";
        else
            return Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO];
    }
    //Select các cbo theo id dơn vị sử dụng khi có id_don_vi_su_dung trên url
    private void load_data_to_combobox_theo_id_don_vi_su_dung(decimal ip_id_dvsd)
    {
        US_DM_DON_VI v_us_don_vi_su_dung = new US_DM_DON_VI(ip_id_dvsd);
        US_DM_DON_VI v_us_don_vi_chu_quan = new US_DM_DON_VI(v_us_don_vi_su_dung.dcID_DON_VI_CAP_TREN);
        m_cbo_bo_tinh.SelectedValue = v_us_don_vi_chu_quan.dcID_DON_VI_CAP_TREN.ToString();
        m_cbo_don_vi_chu_quan.SelectedValue = v_us_don_vi_chu_quan.dcID.ToString();
        m_cbo_loai_hinh_don_vi.SelectedValue = v_us_don_vi_su_dung.strLOAI_HINH_DON_VI;
        m_cbo_don_vi_su_dung_tai_san.SelectedValue = ip_id_dvsd.ToString();
        reset_thong_bao();
        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO].Equals(null)) return;
        string v_str_id_loai_bao_cao = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO];
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
                WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                         CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                       , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                       , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                       , ID_TRANG_THAI_DAT.DANG_SU_DUNG
                       , m_cbo_loai_hinh_don_vi.SelectedValue
                       , WinFormControls.eTAT_CA.YES
                       , m_cbo_dia_chi);
                break;

        }
        m_cmd_loc_du_lieu_Click(m_cmd_loc_du_lieu, EventArgs.Empty);
    }
    private void truyen_thong_tin_vao_trang_web()
    {
        //lấy Querry String của url
        string v_str_id_loai_bao_cao = "";
        if (get_querryString().Equals("")) return;
        else v_str_id_loai_bao_cao = get_querryString();
        WinFormControls.eTAT_CA v_e_tat_ca = WinFormControls.eTAT_CA.NO;
        switch (v_str_id_loai_bao_cao)
        {
            case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_KE_KHAI:
                v_e_tat_ca = WinFormControls.eTAT_CA.NO;
                break;
            case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_DE_NGHI_XU_LY:
                v_e_tat_ca = WinFormControls.eTAT_CA.NO;
                break;
            case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_THONG_KE:
                v_e_tat_ca = WinFormControls.eTAT_CA.YES;
                break;
        }
        reset_thong_bao();
        truyen_tieu_de();
        an_hien_thong_tin_ve_khu_dat(true);
        an_hien_gird_nha(true);
        load_data_to_combobox_loai_hinh_don_vi(
            m_cbo_loai_hinh_don_vi
            , WinFormControls.eTAT_CA.YES
            );
        load_data_to_combobox_trang_thai_nha(
            m_cbo_trang_thai
            , v_e_tat_ca
            , v_str_id_loai_bao_cao
            );
        load_data_to_combobox_bo_tinh(
            m_cbo_bo_tinh
            , v_e_tat_ca
            );
        load_data_to_combobox_don_vi_chu_quan(
            m_cbo_don_vi_chu_quan
            ,v_e_tat_ca
            ,v_str_id_loai_bao_cao
            );
        load_data_to_combobox_don_vi_su_dung_theo_loai_hinh_don_vi(
            m_cbo_don_vi_su_dung_tai_san
            , v_e_tat_ca
            , m_cbo_bo_tinh.SelectedValue
            , m_cbo_don_vi_chu_quan.SelectedValue
            , m_cbo_loai_hinh_don_vi.SelectedValue
            );
        load_data_to_combobox_dia_chi(
            m_cbo_dia_chi
            , v_e_tat_ca
            , m_cbo_bo_tinh.SelectedValue
            , m_cbo_don_vi_chu_quan.SelectedValue
            , m_cbo_don_vi_su_dung_tai_san.SelectedValue
            , m_cbo_loai_hinh_don_vi.SelectedValue
            );
        //Select các cbo theo id dơn vị sử dụng khi có id_don_vi_su_dung trên url
        if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.ID_DVSD] != null)
        {
            decimal v_id_don_vi_su_dung = CIPConvert.ToDecimal(Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.ID_DVSD]);
            load_data_to_combobox_theo_id_don_vi_su_dung(v_id_don_vi_su_dung);
        }
        //------------------------------------------------------------------------
        //load data to combobox dia chi

        m_cmd_loc_du_lieu_Click(m_cmd_loc_du_lieu, EventArgs.Empty);
    }
    private void load_data_to_combobox_bo_tinh(
        DropDownList ip_cbo_bo_tinh
        , WinFormControls.eTAT_CA ip_e_tat_ca
        )
    {
        WinFormControls.load_data_to_cbo_bo_tinh(
                 ip_e_tat_ca
                , ip_cbo_bo_tinh);
    }
    private void load_data_to_combobox_don_vi_chu_quan(
        DropDownList ip_cbo_don_vi_chu_quan
        , WinFormControls.eTAT_CA ip_e_tat_ca
        , string ip_str_id_bo_tinh
        )
    {
        //Nếu không có id_bo_tinh thì không hiện dữ liệu lên cbo_don_vi_chu_quan
        if (ip_str_id_bo_tinh.Equals(""))
        {
            m_cbo_don_vi_chu_quan.DataSource = null;
            m_cbo_don_vi_chu_quan.DataBind();
            return;
        }
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(
            ip_str_id_bo_tinh
            , ip_e_tat_ca
            , ip_cbo_don_vi_chu_quan);
    }
    private void load_data_to_combobox_don_vi_su_dung_theo_loai_hinh_don_vi(
        DropDownList ip_cbo_don_vi_su_dung
        , WinFormControls.eTAT_CA ip_e_tat_ca
        , string ip_str_id_bo_tinh
        , string ip_str_id_don_vi_chu_quan
        , string ip_str_loai_hinh_don_vi
        )
    {
        if (ip_cbo_don_vi_su_dung.Equals("") || ip_str_id_don_vi_chu_quan.Equals("") || ip_str_loai_hinh_don_vi.Equals(""))
        {
            m_cbo_don_vi_su_dung_tai_san.DataSource = null;
            m_cbo_don_vi_su_dung_tai_san.DataBind();
            return;
        }
        WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
            ip_str_loai_hinh_don_vi
            , ip_str_id_don_vi_chu_quan
            , ip_str_id_bo_tinh
            , ip_e_tat_ca
            , ip_cbo_don_vi_su_dung
            );
    }
    private void load_data_to_combobox_loai_hinh_don_vi(
         DropDownList ip_cbo_loai_hinh_don_vi
        , WinFormControls.eTAT_CA ip_e_tat_ca
        )
    {
        WinFormControls.load_data_to_cbo_loai_hinh_don_vi(
                   WinFormControls.eLOAI_TU_DIEN.LOAI_HINH_DON_VI
                   , ip_e_tat_ca
                   , ip_cbo_loai_hinh_don_vi
                   );
    }
    private void load_data_to_combobox_trang_thai_nha(
        DropDownList ip_cbo_trang_thai
        , WinFormControls.eTAT_CA ip_e_tat_ca
        , string ip_loai_bao_cao_tham_so
        )
    {
        WinFormControls.load_data_to_cbo_tu_dien(
           WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_NHA
           , ip_e_tat_ca
           , ip_cbo_trang_thai
           );
        switch (ip_loai_bao_cao_tham_so)
        {
            case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_KE_KHAI:
                ip_cbo_trang_thai.SelectedValue = CIPConvert.ToStr(ID_TRANG_THAI_NHA.DANG_SU_DUNG);
                ip_cbo_trang_thai.Enabled = false;
                ip_cbo_trang_thai.DataBind();
                break;
            case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_DE_NGHI_XU_LY:
                ip_cbo_trang_thai.SelectedValue = CIPConvert.ToStr(ID_TRANG_THAI_NHA.DE_NGHI_XU_LY);
                ip_cbo_trang_thai.Enabled = false;
                ip_cbo_trang_thai.DataBind();
                break;
            case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_THONG_KE:
                ip_cbo_trang_thai.Enabled = true;
                ip_cbo_trang_thai.DataBind();
                break;
        }
    }
    private void load_data_to_combobox_dia_chi(
        DropDownList ip_cbo_dia_chi
        , WinFormControls.eTAT_CA ip_e_tat_ca
        , string ip_str_id_bo_tinh
        , string ip_str_id_don_vi_chu_quan
        , string ip_str_id_don_vi_su_dung
        , string ip_str_loai_hinh_don_vi
        )
    {
        if(ip_str_id_bo_tinh.Equals("")
            ||ip_str_id_don_vi_chu_quan.Equals("")
            ||ip_str_id_don_vi_su_dung.Equals("")
            )
        {
            m_cbo_dia_chi.DataSource = null;
            m_cbo_dia_chi.DataBind();
        }
        WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
           CIPConvert.ToDecimal(ip_str_id_bo_tinh)
          ,CIPConvert.ToDecimal(ip_str_id_don_vi_chu_quan)
          , CIPConvert.ToDecimal(ip_str_id_don_vi_su_dung)
          , CONST_QLDB.ID_TAT_CA
          , ip_str_loai_hinh_don_vi
          , ip_e_tat_ca
          , ip_cbo_dia_chi
          );
    }
    #endregion

    #region events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                truyen_thong_tin_vao_trang_web();
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
            reset_thong_bao();
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
            if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO].Equals(null)) return;
            string v_str_id_loai_bao_cao = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO];
            reset_thong_bao();
            WinFormControls.eTAT_CA v_e_tat_ca = WinFormControls.eTAT_CA.NO;
            switch (v_str_id_loai_bao_cao)
            {
                case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_KE_KHAI:
                    v_e_tat_ca = WinFormControls.eTAT_CA.NO;
                    break;
                case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_DE_NGHI_XU_LY:
                    v_e_tat_ca = WinFormControls.eTAT_CA.NO;

                    break;
                case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_THONG_KE:
                    v_e_tat_ca = WinFormControls.eTAT_CA.YES;
                    break;

            }
            load_data_to_combobox_don_vi_chu_quan(
                m_cbo_don_vi_chu_quan
                ,v_e_tat_ca
                ,v_str_id_loai_bao_cao
                );
            load_data_to_combobox_don_vi_su_dung_theo_loai_hinh_don_vi(
                m_cbo_don_vi_su_dung_tai_san
                ,v_e_tat_ca
                ,m_cbo_bo_tinh.SelectedValue
                ,m_cbo_don_vi_chu_quan.SelectedValue
                ,m_cbo_loai_hinh_don_vi.SelectedValue
                );
            load_data_to_combobox_dia_chi(
                m_cbo_dia_chi
                ,v_e_tat_ca
                ,m_cbo_bo_tinh.SelectedValue
                ,m_cbo_don_vi_chu_quan.SelectedValue
                ,m_cbo_don_vi_su_dung_tai_san.SelectedValue
                ,m_cbo_loai_hinh_don_vi.SelectedValue
                );
            an_hien_thong_tin_ve_khu_dat(true);
            an_hien_gird_nha(false);
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
            reset_thong_bao();
            if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO].Equals(null)) return;
            string v_str_id_loai_bao_cao = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO];
            WinFormControls.eTAT_CA v_e_tat_ca = WinFormControls.eTAT_CA.NO;
            switch (v_str_id_loai_bao_cao)
            {
                case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_KE_KHAI:
                    v_e_tat_ca = WinFormControls.eTAT_CA.NO;
                    break;
                case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_DE_NGHI_XU_LY:
                    v_e_tat_ca = WinFormControls.eTAT_CA.NO;
                    break;
                case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_THONG_KE:
                    v_e_tat_ca = WinFormControls.eTAT_CA.YES;
                    break;
            }
            load_data_to_combobox_don_vi_su_dung_theo_loai_hinh_don_vi(
                m_cbo_don_vi_su_dung_tai_san
                , v_e_tat_ca
                , m_cbo_bo_tinh.SelectedValue
                , m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_loai_hinh_don_vi.SelectedValue
            );
            load_data_to_combobox_dia_chi(
                m_cbo_dia_chi
                ,v_e_tat_ca
                ,m_cbo_bo_tinh.SelectedValue
                ,m_cbo_don_vi_chu_quan.SelectedValue
                ,m_cbo_don_vi_su_dung_tai_san.SelectedValue
                ,m_cbo_loai_hinh_don_vi.SelectedValue
                );
            an_hien_gird_nha(false);
            an_hien_thong_tin_ve_khu_dat(false);
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
            reset_thong_bao();
            if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO].Equals(null)) return;
            string v_str_id_loai_bao_cao = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO];
            WinFormControls.eTAT_CA v_e_tat_ca = WinFormControls.eTAT_CA.NO;
            switch (v_str_id_loai_bao_cao)
            {
                case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_KE_KHAI:
                    v_e_tat_ca = WinFormControls.eTAT_CA.NO;
                    break;
                case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_DE_NGHI_XU_LY:
                    v_e_tat_ca = WinFormControls.eTAT_CA.NO;
                    break;
                case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_THONG_KE:
                    v_e_tat_ca = WinFormControls.eTAT_CA.YES;
                    break;

            }
            load_data_to_combobox_dia_chi(
                 m_cbo_dia_chi
                 , v_e_tat_ca
                 , m_cbo_bo_tinh.SelectedValue
                 , m_cbo_don_vi_chu_quan.SelectedValue
                 , m_cbo_don_vi_su_dung_tai_san.SelectedValue
                 , m_cbo_loai_hinh_don_vi.SelectedValue
                 );
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
            m_lbl_title.Text = "THÔNG TIN NHÀ ĐẤT";
            reset_thong_bao();
            if (!check_data_validate_is_ok()) return;
            an_hien_thong_tin_ve_khu_dat(true);
            an_hien_gird_nha(true);
            truyen_thong_tin_ve_khu_dat();
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
            xuat_excel();
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
            reset_thong_bao();
            if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO].Equals(null)) return;
            string v_str_id_loai_bao_cao = Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.LOAI_BAO_CAO];
            WinFormControls.eTAT_CA v_e_tat_ca = WinFormControls.eTAT_CA.NO;
            switch (v_str_id_loai_bao_cao)
            {
                case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_KE_KHAI:
                    v_e_tat_ca = WinFormControls.eTAT_CA.NO;
                    break;
                case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_DE_NGHI_XU_LY:
                    v_e_tat_ca = WinFormControls.eTAT_CA.NO;
                    break;
                case LOAI_BAO_CAO_THAM_SO.C_STR_LOAI_THONG_KE:
                    v_e_tat_ca = WinFormControls.eTAT_CA.YES;
                    break;
            }
            WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                            m_cbo_loai_hinh_don_vi.SelectedValue
                            , m_cbo_don_vi_chu_quan.SelectedValue
                            , m_cbo_bo_tinh.SelectedValue
                            , v_e_tat_ca
                            , m_cbo_don_vi_su_dung_tai_san
                    );
            if (m_cbo_don_vi_su_dung_tai_san.SelectedValue.Equals(""))
            {
                thong_bao("Không có Đơn vị sử dụng!");
                return;
            }
            WinFormControls.load_data_to_cbo_dia_chi_theo_loai_hinh(
                     CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                   , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                   , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                   , ID_TRANG_THAI_DAT.DANG_SU_DUNG
                   , m_cbo_loai_hinh_don_vi.SelectedValue
                   , v_e_tat_ca
                   , m_cbo_dia_chi);
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    #endregion
}
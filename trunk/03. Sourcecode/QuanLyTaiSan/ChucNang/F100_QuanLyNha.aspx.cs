using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using IP.Core.IPBusinessService;
using IP.Core.IPException;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;
using IP.Core.IPException;
using WebDS.CDBNames;
using System.Threading;
using IP.Core.WinFormControls;

public partial class ChucNang_F100_QuanLyNha : System.Web.UI.Page
{
    #region Members
    private US_DM_NHA m_us_dm_nha = new US_DM_NHA();
    private DataEntryFormMode m_e_form_mode = DataEntryFormMode.InsertDataState;
    #endregion

    #region Private Methods

    private void set_form_mode()
    {
        switch (m_e_form_mode)
        {
            case DataEntryFormMode.InsertDataState:
                m_cmd_tao_moi.Visible = true;
                m_cmd_cap_nhat.Visible = false;
                break;
            case DataEntryFormMode.SelectDataState:
                break;
            case DataEntryFormMode.UpdateDataState:
                m_cmd_tao_moi.Visible = false;
                m_cmd_cap_nhat.Visible = true;
                break;
            case DataEntryFormMode.ViewDataState:
                break;
            default:
                break;
        }
    }

    // Load dữ liệu vào form
    private void load_form_data()
    {
        load_data_bo_tinh();
        load_data_don_vi_chu_quan(m_ddl_bo_tinh.SelectedValue);
        load_data_don_vi_su_dung(m_ddl_don_vi_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
        load_data_dat(
            m_ddl_bo_tinh.SelectedValue
            , m_ddl_don_vi_chu_quan.SelectedValue
            , m_ddl_don_vi_su_dung.SelectedValue);
        load_data_trang_thai();
        load_data_don_vi_dau_tu();
        load_data_to_grid(m_txt_tu_khoa.Text);
        set_form_mode();
        m_txt_ten_tai_san.Focus();
    }

    // Load dữ liệu vào grid
    private void load_data_to_grid(string ip_str_tu_khoa)
    {
        DS_DM_NHA v_ds_dm_nha = new DS_DM_NHA();

        if (ip_str_tu_khoa.Equals(String.Empty))
        {
            m_us_dm_nha.FillDataset(v_ds_dm_nha);
        }
        else
        {
            CStoredProc v_cstore = new CStoredProc("pr_DM_NHA_Search");
            v_cstore.addNVarcharInputParam("@TU_KHOA", m_txt_tu_khoa.Text);
            v_cstore.fillDataSetByCommand(m_us_dm_nha, v_ds_dm_nha);
        }
        m_grv_danh_sach_nha.DataSource = v_ds_dm_nha.DM_NHA;
        m_grv_danh_sach_nha.DataBind();
    }

    // Load dữ liệu vào combo bộ tỉnh
    private void load_data_bo_tinh()
    {
        WinFormControls.load_data_to_cbo_bo_tinh(WinFormControls.eTAT_CA.NO, m_ddl_bo_tinh);

        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        if (m_us_dm_nha.dcID_DON_VI_CHU_QUAN != 0)
        {
            v_us_dm_don_vi = new US_DM_DON_VI(m_us_dm_nha.dcID_DON_VI_CHU_QUAN);
            m_ddl_bo_tinh.SelectedValue = v_us_dm_don_vi.dcID_DON_VI_CAP_TREN.ToString();
        }
    }

    // Load dữ liệu vào combo đơn vị chủ quản
    private void load_data_don_vi_chu_quan(string ip_str_id_bo_tinh)
    {
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(ip_str_id_bo_tinh
            , WinFormControls.eTAT_CA.NO
            , m_ddl_don_vi_chu_quan);

        if (m_us_dm_nha.dcID_DON_VI_CHU_QUAN != 0)
        {
            m_ddl_don_vi_chu_quan.SelectedValue = m_us_dm_nha.dcID_DON_VI_CHU_QUAN.ToString();
        }
    }

    // Load dữ liệu vào combo đơn vị sử dụng
    private void load_data_don_vi_su_dung(string ip_str_id_don_vi_chu_quan, string ip_str_id_bo_tinh)
    {
        WinFormControls.load_data_to_cbo_don_vi_su_dung(ip_str_id_don_vi_chu_quan
            , ip_str_id_bo_tinh
            , WinFormControls.eTAT_CA.NO
            , m_ddl_don_vi_su_dung);

        if (m_us_dm_nha.dcID_DON_VI_SU_DUNG != 0)
        {
            m_ddl_don_vi_su_dung.SelectedValue = m_us_dm_nha.dcID_DON_VI_SU_DUNG.ToString();
        }
    }

    // Load dữ liệu vào combo đơn vị đầu tư
    private void load_data_don_vi_dau_tu()
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi);
        m_ddl_don_vi_dau_tu.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_ddl_don_vi_dau_tu.DataTextField = DM_DON_VI.TEN_DON_VI;
        m_ddl_don_vi_dau_tu.DataValueField = DM_DON_VI.ID;
        m_ddl_don_vi_dau_tu.DataBind();
    }

    // Load dữ liệu vào đất
    private void load_data_dat(string ip_str_id_bo_tinh
        , string ip_str_id_don_vi_chu_quan
        , string ip_str_id_don_vi_su_dung)
    {
        WinFormControls.load_data_to_cbo_dia_chi(
            CIPConvert.ToDecimal(ip_str_id_bo_tinh)
            , CIPConvert.ToDecimal(ip_str_id_don_vi_chu_quan)
            , CIPConvert.ToDecimal(ip_str_id_don_vi_su_dung)
            , CONST_QLDB.ID_TAT_CA
            , WinFormControls.eTAT_CA.NO,
            m_ddl_thuoc_khu_dat);
    }

    private bool check_validate_data_is_ok()
    {
        if (m_ddl_thuoc_khu_dat.SelectedValue == "")
        {
            m_lbl_mess.Text = "Bạn chưa chọn khu đất!";
            return false;
        }
        return true;
    }

    // Load dữ liệu vào combo trạng thái
    private void load_data_trang_thai()
    {
        WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_NHA
            , WinFormControls.eTAT_CA.NO
            , m_ddl_trang_thai_nha);
    }

    private void load_data_from_us()
    {
        m_hdf_id.Value = m_us_dm_nha.dcID.ToString();
        m_ddl_don_vi_chu_quan.SelectedValue = m_us_dm_nha.dcID_DON_VI_CHU_QUAN.ToString();
        m_ddl_don_vi_su_dung.SelectedValue = m_us_dm_nha.dcID_DON_VI_SU_DUNG.ToString();
        m_ddl_don_vi_dau_tu.SelectedValue = m_us_dm_nha.dcID_DON_VI_DAU_TU.ToString();
        m_ddl_thuoc_khu_dat.SelectedValue = m_us_dm_nha.dcID_DAT.ToString();
        m_txt_ten_tai_san.Text = m_us_dm_nha.strTEN_TAI_SAN;
        m_txt_ma_tai_san.Text = m_us_dm_nha.strMA_TAI_SAN;
        m_txt_cap_hang.Text = m_us_dm_nha.dcCAP_HANG.ToString();
        m_txt_nam_xd.Text = m_us_dm_nha.dcNAM_XAY_DUNG.ToString();
        m_txt_ngay_su_dung.Text = m_us_dm_nha.dcNGAY_THANG_NAM_SU_DUNG.ToString();
        m_txt_nguyen_gia.Text = m_us_dm_nha.dcNGUON_NS.ToString("#,##0.00");
        m_txt_nguyen_gia_nguon_khac.Text = m_us_dm_nha.dcNGUON_KHAC.ToString("#,##0.00");
        m_txt_gia_tri_con_lai.Text = m_us_dm_nha.dcGIA_TRI_CON_LAI.ToString("#,##0.00");
        m_txt_so_tang.Text = m_us_dm_nha.dcSO_TANG.ToString();
        m_txt_dien_tich_xay_dung.Text = m_us_dm_nha.dcDT_XAY_DUNG.ToString("#,##0.00");
        m_txt_tong_dien_tich_xay_dung.Text = m_us_dm_nha.dcTONG_DT_SAN_XD.ToString("#,##0.00");
        m_txt_tru_so_lam_viec.Text = m_us_dm_nha.dcTRU_SO_LAM_VIEC.ToString("#,##0.00");
        m_txt_co_so_hdsn.Text = m_us_dm_nha.dcCO_SO_HDSN.ToString("#,##0.00");
        m_txt_lam_nha_o.Text = m_us_dm_nha.dcLAM_NHA_O.ToString("#,##0.00");
        m_txt_cho_thue.Text = m_us_dm_nha.dcCHO_THUE.ToString("#,##0.00");
        m_txt_bo_trong.Text = m_us_dm_nha.dcBO_TRONG.ToString("#,##0.00");
        m_txt_bi_lan_chiem.Text = m_us_dm_nha.dcBI_LAN_CHIEM.ToString("#,##0.00");
        m_txt_khac.Text = m_us_dm_nha.dcKHAC.ToString("#,##0.00");
        m_ddl_trang_thai_nha.SelectedValue = m_us_dm_nha.dcID_TRANG_THAI.ToString();
    }

    private void fill_form_data_to_us()
    {
        if (!m_hdf_id.Value.Equals("-1"))
        {
            m_us_dm_nha.dcID = CIPConvert.ToDecimal(m_hdf_id.Value);
        }
        m_us_dm_nha.strTEN_TAI_SAN = m_txt_ten_tai_san.Text;
        m_us_dm_nha.strMA_TAI_SAN = m_txt_ma_tai_san.Text;
        m_us_dm_nha.dcID_LOAI_TAI_SAN = ID_LOAI_TAI_SAN.NHA;
        m_us_dm_nha.dcCAP_HANG = CIPConvert.ToDecimal(m_txt_cap_hang.Text);
        m_us_dm_nha.dcNAM_XAY_DUNG = CIPConvert.ToDecimal(m_txt_nam_xd.Text);
        m_us_dm_nha.dcNGAY_THANG_NAM_SU_DUNG = CIPConvert.ToDecimal(m_txt_ngay_su_dung.Text);
        m_us_dm_nha.dcNGUON_NS = CIPConvert.ToDecimal(m_txt_nguyen_gia.Text);
        m_us_dm_nha.dcNGUON_KHAC = CIPConvert.ToDecimal(m_txt_nguyen_gia_nguon_khac.Text);
        m_us_dm_nha.dcGIA_TRI_CON_LAI = CIPConvert.ToDecimal(m_txt_gia_tri_con_lai.Text);
        m_us_dm_nha.dcSO_TANG = CIPConvert.ToDecimal(m_txt_so_tang.Text);
        m_us_dm_nha.dcDT_XAY_DUNG = CIPConvert.ToDecimal(m_txt_dien_tich_xay_dung.Text);
        m_us_dm_nha.dcTONG_DT_SAN_XD = CIPConvert.ToDecimal(m_txt_tong_dien_tich_xay_dung.Text);
        m_us_dm_nha.dcTRU_SO_LAM_VIEC = CIPConvert.ToDecimal(m_txt_tru_so_lam_viec.Text);
        m_us_dm_nha.dcCO_SO_HDSN = CIPConvert.ToDecimal(m_txt_co_so_hdsn.Text);
        m_us_dm_nha.dcLAM_NHA_O = CIPConvert.ToDecimal(m_txt_lam_nha_o.Text);
        m_us_dm_nha.dcCHO_THUE = CIPConvert.ToDecimal(m_txt_cho_thue.Text);
        m_us_dm_nha.dcBO_TRONG = CIPConvert.ToDecimal(m_txt_bo_trong.Text);
        m_us_dm_nha.dcBI_LAN_CHIEM = CIPConvert.ToDecimal(m_txt_bi_lan_chiem.Text);
        m_us_dm_nha.dcKHAC = CIPConvert.ToDecimal(m_txt_khac.Text);
        m_us_dm_nha.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_ddl_trang_thai_nha.SelectedValue);
        m_us_dm_nha.dcID_DAT = CIPConvert.ToDecimal(m_ddl_thuoc_khu_dat.SelectedValue);

        US_DM_DAT v_us_dm_dat = new US_DM_DAT(m_us_dm_nha.dcID_DAT);
        m_us_dm_nha.dcID_DON_VI_SU_DUNG = v_us_dm_dat.dcID_DON_VI_SU_DUNG;
        m_us_dm_nha.dcID_DON_VI_CHU_QUAN = v_us_dm_dat.dcID_DON_VI_CHU_QUAN;
        m_us_dm_nha.dcID_DON_VI_DAU_TU = CIPConvert.ToDecimal(m_ddl_don_vi_dau_tu.SelectedValue);
        m_us_dm_nha.datNGAY_CAP_NHAT_CUOI = DateTime.Now;

        m_us_dm_nha.dcID_NGUOI_DUYET = Person.get_user_id();
        m_us_dm_nha.dcID_NGUOI_LAP = Person.get_user_id();
    }

    private void clear_form_data()
    {
        m_hdf_id.Value = "-1";
        m_txt_ten_tai_san.Text = "";
        m_txt_cap_hang.Text = "";
        m_txt_nam_xd.Text = "";
        m_txt_ngay_su_dung.Text = "";
        m_txt_nguyen_gia.Text = "0";
        m_txt_nguyen_gia_nguon_khac.Text = "0";
        m_txt_gia_tri_con_lai.Text = "0";
        m_txt_so_tang.Text = "0";
        m_txt_dien_tich_xay_dung.Text = "0";
        m_txt_tong_dien_tich_xay_dung.Text = "0";
        m_txt_tru_so_lam_viec.Text = "0";
        m_txt_co_so_hdsn.Text = "0";
        m_txt_lam_nha_o.Text = "0";
        m_txt_cho_thue.Text = "0";
        m_txt_bo_trong.Text = "0";
        m_txt_bi_lan_chiem.Text = "0";
        m_txt_khac.Text = "0";
        m_txt_ma_tai_san.Text = "";
        m_lbl_mess.Text = "";
        m_lbl_thong_bao.Text = "";
        m_e_form_mode = DataEntryFormMode.InsertDataState;
        set_form_mode();
    }

    private decimal get_id_bo_tinh(decimal ip_dc_id_don_vi_chu_quan)
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI(ip_dc_id_don_vi_chu_quan);
        return v_us_dm_don_vi.dcID_DON_VI_CAP_TREN;
    }
    #endregion

    #region Public Interfaces
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                load_form_data();
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            if (!check_validate_data_is_ok()) return;
            if (m_hdf_id.Value == "-1")
            {
                Thread.Sleep(2000);
                fill_form_data_to_us();
                m_us_dm_nha.Insert();
                clear_form_data();
                load_form_data();
                m_lbl_mess.Text = "Đã thêm mới dữ liệu thành công!";
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
    {
        try
        {
            if (!check_validate_data_is_ok()) return;
            if (m_hdf_id.Value != "-1")
            {
                Thread.Sleep(2000);
                fill_form_data_to_us();
                m_us_dm_nha.Update();
                clear_form_data();
                load_form_data();
                m_lbl_mess.Text = "Đã cập nhật dữ liệu thành công!";
            }
            else
            {
                m_lbl_mess.Text = "Bạn chưa chọn dữ liệu để cập nhật";
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_cmd_xoa_trang_Click(object sender, EventArgs e)
    {
        try
        {
            Thread.Sleep(1000);
            clear_form_data();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {
            Thread.Sleep(2000);
            load_data_to_grid(m_txt_tu_khoa.Text);
            m_txt_tu_khoa.Focus();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        // TODO
    }

    protected void m_grv_danh_sach_nha_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (!e.CommandName.Equals("-1"))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                decimal v_dc_id_nha = CIPConvert.ToDecimal(m_grv_danh_sach_nha.DataKeys[rowIndex].Value);

                switch (e.CommandName)
                {
                    case "EditComp":
                        Thread.Sleep(2000);
                        m_us_dm_nha = new US_DM_NHA(v_dc_id_nha);
                        m_e_form_mode = DataEntryFormMode.UpdateDataState;
                        load_form_data();
                        load_data_from_us();
                        break;
                    case "DeleteComp":
                        Thread.Sleep(2000);
                        m_us_dm_nha.DeleteByID(v_dc_id_nha);
                        load_form_data();
                        break;
                }
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }

    }

    protected void m_grv_danh_sach_nha_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            Thread.Sleep(1000);
            m_grv_danh_sach_nha.PageIndex = e.NewPageIndex;
            load_data_to_grid(m_txt_tu_khoa.Text);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_ddl_don_vi_chu_quan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_don_vi_su_dung(m_ddl_don_vi_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
            load_data_dat(
                m_ddl_bo_tinh.SelectedValue
                , m_ddl_don_vi_chu_quan.SelectedValue
                , m_ddl_don_vi_su_dung.SelectedValue);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_ddl_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_don_vi_chu_quan(m_ddl_bo_tinh.SelectedValue);
            load_data_don_vi_su_dung(m_ddl_don_vi_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
            load_data_dat(
                m_ddl_bo_tinh.SelectedValue
                , m_ddl_don_vi_chu_quan.SelectedValue
                , m_ddl_don_vi_su_dung.SelectedValue);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_ddl_don_vi_su_dung_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_dat(
                m_ddl_bo_tinh.SelectedValue
                , m_ddl_don_vi_chu_quan.SelectedValue
                , m_ddl_don_vi_su_dung.SelectedValue);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
}
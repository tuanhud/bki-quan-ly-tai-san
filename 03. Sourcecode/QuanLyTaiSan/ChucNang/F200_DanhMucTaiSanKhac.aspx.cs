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
using IP.Core.WinFormControls;
using System.Threading;

public partial class Default2 : System.Web.UI.Page
{
    #region Member
    US_DM_TAI_SAN_KHAC m_us_tai_san_khac = new US_DM_TAI_SAN_KHAC();
    DS_DM_TAI_SAN_KHAC m_ds_tai_san_khac = new DS_DM_TAI_SAN_KHAC();
    DataEntryFormMode m_e_form_mode = DataEntryFormMode.InsertDataState;


    #endregion
    #region Data Structures
    #endregion
    #region Private Methods
    private void load_data_2_grid()
    {
        /*try {
            m_ds_tai_san_khac.DM_TAI_SAN_KHAC.Clear();
            m_us_tai_san_khac.search(m_txt_tim_kiem.Text.Trim(), m_ds_tai_san_khac);
            m_grv_tai_san_khac.DataSource = m_ds_tai_san_khac.DM_TAI_SAN_KHAC;
            m_grv_tai_san_khac.DataBind();
        }
        catch (Exception v_e) {
            throw v_e;
        }
         */
        US_V_DM_TAI_SAN_KHAC m_us_v_tai_san_khac = new US_V_DM_TAI_SAN_KHAC();
        DS_V_DM_TAI_SAN_KHAC m_ds_v_tai_san_khac = new DS_V_DM_TAI_SAN_KHAC();
        m_ds_v_tai_san_khac.V_DM_TAI_SAN_KHAC.Clear();
        m_us_v_tai_san_khac.FillDatasetLoadDataToGridTaiSanKhac_by_tu_khoa(m_txt_tim_kiem.Text.Trim()
            , CONST_QLDB.ID_TAT_CA
            , CONST_QLDB.ID_TAT_CA
            , CONST_QLDB.ID_TAT_CA
            , CONST_QLDB.ID_TAT_CA
            , CONST_QLDB.ID_TAT_CA.ToString()
            , Person.get_user_name()
            , m_ds_v_tai_san_khac);
        m_grv_tai_san_khac.DataSource = m_ds_v_tai_san_khac.V_DM_TAI_SAN_KHAC;
        m_grv_tai_san_khac.DataBind();
    }

    private bool check_validate_data_is_ok()
    {
        if (!CValidateTextBox.IsValid(m_txt_ma_tai_san, DataType.StringType, allowNull.NO)) return false;
        if (!CValidateTextBox.IsValid(m_txt_ten_tai_san, DataType.StringType, allowNull.NO)) return false;
        if (!CValidateTextBox.IsValid(m_txt_nguyen_gia_nguon_ns, DataType.NumberType, allowNull.NO)) return false;
        if (!CValidateTextBox.IsValid(m_txt_nguyen_gia_nguon_khac, DataType.NumberType, allowNull.NO)) return false;
        if (!CValidateTextBox.IsValid(m_txt_ngay_su_dung, DataType.NumberType, allowNull.YES)) return false;
        if (!CValidateTextBox.IsValid(m_txt_nam_sx, DataType.NumberType, allowNull.YES)) return false;
        if (!CValidateTextBox.IsValid(m_txt_gia_tri_con_lai, DataType.NumberType, allowNull.NO)) return false;
        if (!CValidateTextBox.IsValid(m_txt_quan_ly_nha_nuoc, DataType.NumberType, allowNull.YES)) return false;
        if (!CValidateTextBox.IsValid(m_txt_kinh_doanh, DataType.NumberType, allowNull.YES)) return false;
        if (!CValidateTextBox.IsValid(m_txt_khong_kinh_doanh, DataType.NumberType, allowNull.YES)) return false;
        if ((m_txt_ngay_su_dung.Text.Trim().Length > 0) & (m_txt_nam_sx.Text.Trim().Length > 0))
        {
            if (CIPConvert.ToDecimal(m_txt_ngay_su_dung.Text) < CIPConvert.ToDecimal(m_txt_nam_sx.Text))
            {
                m_lbl_mess.Text = "Năm sử dụng phải lớn hơn hoặc bằng năm sản xuất!";
                return false;
            }
        }
        if ((m_txt_nguyen_gia_nguon_ns.Text.Trim().Length > 0) & (m_txt_nguyen_gia_nguon_khac.Text.Trim().Length > 0) & (m_txt_gia_tri_con_lai.Text.Trim().Length > 0))
        {
            if (CIPConvert.ToDecimal(m_txt_nguyen_gia_nguon_ns.Text) + CIPConvert.ToDecimal(m_txt_nguyen_gia_nguon_khac.Text) < CIPConvert.ToDecimal(m_txt_gia_tri_con_lai.Text))
            {
                m_lbl_mess.Text = "Nguyên giá (nguồn ngân sách + nguồn khác) phải lớn hơn giá trị còn lại!";
                return false;
            }
        }
        if (m_e_form_mode == DataEntryFormMode.UpdateDataState)
        {
            m_us_tai_san_khac = new US_DM_TAI_SAN_KHAC(CIPConvert.ToDecimal(hdf_id.Value));
            if (m_us_tai_san_khac.strMA_TAI_SAN != m_txt_ma_tai_san.Text)
            {
                if (!m_us_tai_san_khac.check_ma_valid(m_txt_ma_tai_san.Text))
                {
                    m_lbl_mess.Text = "Không thể cập nhật. Lỗi: Mã tài sản này đã tồn tại";
                    return false;
                }
            }
        }
        if(m_e_form_mode==DataEntryFormMode.InsertDataState)
        {
            if (!m_us_tai_san_khac.check_ma_valid(m_txt_ma_tai_san.Text.Trim()))
                {
                    m_lbl_mess.Text = "Mã tài sản này đã tồn tại";
                    return false;
                };
        }
        /*switch (m_e_form_mode)
        {
            case DataEntryFormMode.InsertDataState:
                if (!m_us_tai_san_khac.check_ma_valid(m_txt_ma_tai_san.Text.Trim()))
                {
                    m_lbl_mess.Text = "Mã tài sản này đã tồn tại";
                    return false;
                };
                break;
            case DataEntryFormMode.UpdateDataState:
                break;
            default:
                break;
        }
         */
        return true;
    }
    /*private void load_data_2_cbo_trang_thai_tai_san() {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();
        
        v_us_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC, CM_DM_TU_DIEN.GHI_CHU, v_ds_tu_dien);
        m_cbo_trang_thai_tai_san.DataSource = v_ds_tu_dien.CM_DM_TU_DIEN;
        m_cbo_trang_thai_tai_san.DataTextField = CM_DM_TU_DIEN.TEN;
        m_cbo_trang_thai_tai_san.DataValueField = CM_DM_TU_DIEN.ID;
        m_cbo_trang_thai_tai_san.DataBind();
    }*/
    private void form_2_us_object()
    {

        m_us_tai_san_khac.dcID_DON_VI_CHU_QUAN = CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue);
        m_us_tai_san_khac.dcID_DON_VI_SU_DUNG = CIPConvert.ToDecimal(m_cbo_don_vi_su_dung.SelectedValue);
        m_us_tai_san_khac.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_cbo_trang_thai_tai_san.SelectedValue);
        m_us_tai_san_khac.dcID_LOAI_TAI_SAN = CIPConvert.ToDecimal("4");
        m_us_tai_san_khac.datNGAY_CAP_NHAT_CUOI = DateTime.Now.Date;
        m_us_tai_san_khac.strMA_TAI_SAN = m_txt_ma_tai_san.Text.Trim();
        m_us_tai_san_khac.strTEN_TAI_SAN = m_txt_ten_tai_san.Text.Trim();
        m_us_tai_san_khac.strKY_HIEU = m_txt_ky_hieu.Text.Trim();
        m_us_tai_san_khac.strNUOC_SAN_XUAT = m_txt_nuoc_sx.Text.Trim();
        m_us_tai_san_khac.dcNAM_SAN_XUAT = CIPConvert.ToDecimal(m_txt_nam_sx.Text.Trim());
        m_us_tai_san_khac.dcNAM_SU_DUNG = CIPConvert.ToDecimal(m_txt_ngay_su_dung.Text.Trim());
        m_us_tai_san_khac.dcNGUON_NS = CIPConvert.ToDecimal(m_txt_nguyen_gia_nguon_ns.Text.Trim());
        m_us_tai_san_khac.dcNGUON_KHAC = CIPConvert.ToDecimal(m_txt_nguyen_gia_nguon_khac.Text.Trim());
        m_us_tai_san_khac.dcGIA_TRI_CON_LAI = CIPConvert.ToDecimal(m_txt_gia_tri_con_lai.Text.Trim());
        m_us_tai_san_khac.dcQLNN = CIPConvert.ToDecimal(m_txt_quan_ly_nha_nuoc.Text.Trim());
        m_us_tai_san_khac.dcKINH_DOANH = CIPConvert.ToDecimal(m_txt_kinh_doanh.Text.Trim());
        m_us_tai_san_khac.dcKHONG_KINH_DOANH = CIPConvert.ToDecimal(m_txt_khong_kinh_doanh.Text.Trim());
        m_us_tai_san_khac.dcHD_KHAC = CIPConvert.ToDecimal(m_txt_khac.Text.Trim());
        if (hdf_id.Value.Equals(String.Empty))
        {
            m_us_tai_san_khac.dcID_TINH_TRANG = ID_TINH_TRANG.TOT;
        }
    }
    private void us_object_2_form(US_DM_TAI_SAN_KHAC ip_us_m_dm_tai_san_khac)
    {
        hdf_id.Value = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcID);
        m_txt_ten_tai_san.Text = ip_us_m_dm_tai_san_khac.strTEN_TAI_SAN;

        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI(ip_us_m_dm_tai_san_khac.dcID_DON_VI_CHU_QUAN);
        m_cbo_bo_tinh.SelectedValue = CIPConvert.ToStr(v_us_dm_don_vi.dcID_DON_VI_CAP_TREN);
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                   m_cbo_bo_tinh.SelectedValue
                   , WinFormControls.eTAT_CA.NO
                   , m_cbo_don_vi_chu_quan);

        m_cbo_don_vi_chu_quan.SelectedValue = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcID_DON_VI_CHU_QUAN);
        WinFormControls.load_data_to_cbo_don_vi_su_dung(
    m_cbo_don_vi_chu_quan.SelectedValue
    , m_cbo_bo_tinh.SelectedValue
    , WinFormControls.eTAT_CA.NO
    , m_cbo_don_vi_su_dung);
        m_cbo_don_vi_su_dung.SelectedValue = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcID_DON_VI_SU_DUNG);
        m_cbo_trang_thai_tai_san.SelectedValue = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcID_TRANG_THAI);
        m_txt_ma_tai_san.Text = ip_us_m_dm_tai_san_khac.strMA_TAI_SAN;
        m_txt_ky_hieu.Text = ip_us_m_dm_tai_san_khac.strKY_HIEU;
        m_txt_nuoc_sx.Text = ip_us_m_dm_tai_san_khac.strNUOC_SAN_XUAT;
        m_txt_nam_sx.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcNAM_SAN_XUAT);
        m_txt_ngay_su_dung.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcNAM_SU_DUNG);
        m_txt_nguyen_gia_nguon_ns.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcNGUON_NS, "#,##0.00");
        m_txt_nguyen_gia_nguon_khac.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcNGUON_KHAC, "#,##0.00");
        m_txt_gia_tri_con_lai.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcGIA_TRI_CON_LAI, "#,##0.00");
        m_txt_quan_ly_nha_nuoc.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcQLNN);
        m_txt_kinh_doanh.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcKINH_DOANH);
        m_txt_khong_kinh_doanh.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcKHONG_KINH_DOANH);
        m_txt_khac.Text = CIPConvert.ToStr(ip_us_m_dm_tai_san_khac.dcHD_KHAC);
    }
    private void load_data_2_us_update(int ip_i_stt_row)
    {
        decimal dc_id_tai_san_khac = CIPConvert.ToDecimal(m_grv_tai_san_khac.DataKeys[ip_i_stt_row].Value);
        hdf_id.Value = CIPConvert.ToStr(dc_id_tai_san_khac);
        m_us_tai_san_khac = new US_DM_TAI_SAN_KHAC(dc_id_tai_san_khac);
    }
    /*private void load_data_trang_thai() {
        DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();

        v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds("TRANG_THAI_NHA", CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);
        m_cbo_trang_thai_tai_san.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
        m_cbo_trang_thai_tai_san.DataTextField = "TEN";
        m_cbo_trang_thai_tai_san.DataValueField = "ID";
        m_cbo_trang_thai_tai_san.DataBind();
    }*/
    private void reset_control()
    {
        m_lbl_mess.Text = "";
        m_txt_ten_tai_san.Text = "";
        m_txt_ma_tai_san.Text = "";
        m_txt_ky_hieu.Text = "";
        m_txt_nuoc_sx.Text = "";
        m_txt_nam_sx.Text = "";
        m_txt_ngay_su_dung.Text = "";
        m_txt_nguyen_gia_nguon_ns.Text = "";
        m_txt_nguyen_gia_nguon_khac.Text = "";
        m_txt_gia_tri_con_lai.Text = "";
        m_txt_quan_ly_nha_nuoc.Text = "";
        m_txt_kinh_doanh.Text = "";
        m_txt_khong_kinh_doanh.Text = "";
        m_txt_khac.Text = "";
        m_e_form_mode = DataEntryFormMode.InsertDataState;
    }

    private void update_data()
    {
        if (hdf_id.Value.Trim().Equals(""))
        {
            m_lbl_mess.Visible = true;
            m_lbl_mess.Text = "Bạn chưa chọn tài sản để cập nhật!";
            return;
        }
        if (!check_validate_data_is_ok()) return;
        m_us_tai_san_khac = new US_DM_TAI_SAN_KHAC(CIPConvert.ToDecimal(hdf_id.Value));

        form_2_us_object();

        m_us_tai_san_khac.Update();
        load_data_2_grid();
        hdf_id.Value = "";
        reset_control();
        set_form_mode();
        m_lbl_mess.Text = "Cập nhật thành công!";
    }
    private void insert_data()
    {
        if (!check_validate_data_is_ok()) return;

        form_2_us_object();
        m_us_tai_san_khac.Insert();
        load_data_2_grid();
        m_lbl_mess.Text = "Tạo mới thành công!";
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {


            if (!this.IsPostBack)
            {
                /*load_data_2_grid();
                load_data_2_cbo_bo_tinh();
                load_data_2_cbo_trang_thai_tai_san();*/
                set_form_mode();

                WinFormControls.load_data_to_cbo_bo_tinh(
                    WinFormControls.eTAT_CA.NO
                    , m_cbo_bo_tinh);
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.NO
                    , m_cbo_don_vi_chu_quan);
                WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan.SelectedValue
                    , m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.NO
                    , m_cbo_don_vi_su_dung);
                //load_data_2_cbo_trang_thai_tai_san();
                WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC, WinFormControls.eTAT_CA.NO, m_cbo_trang_thai_tai_san);
                load_data_2_grid();
            }

            /*load_data_2_cbo_don_vi_chu_quan();
            load_data_2_cbo_don_vi_su_dung();*/
        }
        catch (Exception v_e)
        {
            this.Response.Write(v_e.ToString());
        }
    }

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
    protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
    {
        try
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            Thread.Sleep(2000);
            update_data();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    protected void m_grv_tai_san_khac_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            load_data_2_us_update(e.RowIndex);
            //m_cbo_don_vi_chu_quan.Items.Clear();
            //WinFormControls.load_data_to_cbo_don_vi_chu_quan(
            //         m_cbo_bo_tinh.SelectedValue
            //         , WinFormControls.eTAT_CA.NO
            //         , m_cbo_don_vi_chu_quan);
            //m_cbo_don_vi_su_dung.Items.Clear();
            //WinFormControls.load_data_to_cbo_don_vi_su_dung(
            //         m_cbo_don_vi_chu_quan.SelectedValue
            //         , m_cbo_bo_tinh.SelectedValue
            //         , WinFormControls.eTAT_CA.NO
            //         , m_cbo_don_vi_su_dung);
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            set_form_mode();
            us_object_2_form(m_us_tai_san_khac);
            
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            Thread.Sleep(2000);
            insert_data();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    protected void m_cbo_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*m_ds_don_vi.DM_DON_VI.Clear();
        m_us_don_vi.FillDataset(m_ds_don_vi, "Where ID_DON_VI_CAP_TREN = "+m_cbo_bo_tinh.SelectedValue+"");
        m_cbo_don_vi_chu_quan.DataSource = m_ds_don_vi.DM_DON_VI;
        m_cbo_don_vi_chu_quan.DataTextField = DM_DON_VI.TEN_DON_VI;
        m_cbo_don_vi_chu_quan.DataValueField = DM_DON_VI.ID;
        m_cbo_don_vi_chu_quan.DataBind();*/
        try
        {
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.NO, m_cbo_don_vi_chu_quan);
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.NO
                , m_cbo_don_vi_su_dung);

        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(v_e);
        }

    }
    protected void m_cbo_don_vi_chu_quan_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*m_ds_don_vi.DM_DON_VI.Clear();
        m_us_don_vi.FillDataset(m_ds_don_vi, "Where ID_DON_VI_CAP_TREN = " + m_cbo_don_vi_chu_quan.SelectedValue + "");
        m_cbo_don_vi_su_dung.DataSource = m_ds_don_vi.DM_DON_VI;
        m_cbo_don_vi_su_dung.DataTextField = DM_DON_VI.TEN_DON_VI;
        m_cbo_don_vi_su_dung.DataValueField = DM_DON_VI.ID;
        m_cbo_don_vi_su_dung.DataBind();*/
        try
        {
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.NO
                , m_cbo_don_vi_su_dung);

        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(v_e);
        }

    }
    protected void m_grv_tai_san_khac_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            decimal dc_id_tai_san_khac = CIPConvert.ToDecimal(m_grv_tai_san_khac.DataKeys[e.RowIndex].Value);
            m_us_tai_san_khac.DeleteByID(dc_id_tai_san_khac);
            load_data_2_grid();
            m_lbl_mess.Text = "Xóa thành công!";
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }

    protected void m_cmd_search_Click(object sender, EventArgs e)
    {
        try
        {
            Thread.Sleep(2000);
            load_data_2_grid();
            m_txt_tim_kiem.Focus();
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(v_e);
        }

    }
    protected void m_grv_tai_san_khac_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_tai_san_khac.PageIndex = e.NewPageIndex;
            load_data_2_grid();
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(v_e);
        }

    }
    protected void m_cmd_xoa_trang_Click(object sender, EventArgs e)
    {
        try
        {
            Thread.Sleep(2000);
            reset_control();
            set_form_mode();
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(v_e);
        }

    }
    protected void m_txt_khong_kinh_doanh_TextChanged(object sender, EventArgs e)
    {

    }
}
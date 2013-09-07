using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using IP.Core.IPBusinessService;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPException;
using IP.Core.IPUserService;
using WebDS.CDBNames;
using IP.Core.WinFormControls;
using System.Threading;

public partial class ChucNang_F302_khau_hao_nha : System.Web.UI.Page {

    #region Public Interfaces

    #endregion

    #region Members
    private US_GD_KHAU_HAO m_us_gd_khau_hao = new US_GD_KHAU_HAO();
    #endregion

    #region Private Methods
    private void load_form_data()
    {
        clear_form_data();
        load_data_trang_thai();
        load_data_to_bo_tinh_up();
        load_data_to_bo_tinh_down();
        load_data_to_dv_chu_quan_up();
        load_data_to_dv_chu_quan_down();
        load_data_to_dv_su_dung_up();
        load_data_to_dv_su_dung_down();
        load_data_to_khu_dat_down();
        load_data_to_khu_dat_up();
        load_data_to_ten_tai_san();
        load_data_to_grid();
        load_data_from_us();
    }

    private void load_data_from_us()
    {
        if (m_cbo_ten_tai_san.Items.Count == 0) return;
        decimal v_dc_id_nha = CIPConvert.ToDecimal(m_cbo_ten_tai_san.SelectedValue);
        if (v_dc_id_nha < 1) return;
        US_DM_NHA v_us_dm_nha = new US_DM_NHA(v_dc_id_nha);
        m_lbl_ten_tai_san.Text = v_us_dm_nha.strTEN_TAI_SAN;
        m_lbl_ma_tai_san.Text = v_us_dm_nha.strMA_TAI_SAN;
        m_lbl_cap_hang.Text = v_us_dm_nha.dcCAP_HANG.ToString();
        m_lbl_nam_xay_dung.Text = v_us_dm_nha.dcNAM_XAY_DUNG.ToString();
        m_lbl_ngay_thang_nam_du_dung.Text = v_us_dm_nha.dcNGAY_THANG_NAM_SU_DUNG.ToString();
        m_lbl_nguyen_gia_nguon_ns.Text = v_us_dm_nha.dcNGUON_NS.ToString("#,##0.00");
        m_lbl_nguyen_gia_nguon_khac.Text = v_us_dm_nha.dcNGUON_KHAC.ToString("#,##0.00");
        m_lbl_gia_tri_con_lai.Text = v_us_dm_nha.dcGIA_TRI_CON_LAI.ToString("#,##0.00");
    }

    private void load_data_trang_thai()
    {
        DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();

        v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_NHA, CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);
        m_cbo_trang_thai_nha_up.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
        m_cbo_trang_thai_nha_up.DataTextField = CM_DM_TU_DIEN.TEN;
        m_cbo_trang_thai_nha_up.DataValueField = CM_DM_TU_DIEN.ID;
        m_cbo_trang_thai_nha_up.DataBind();
        m_cbo_trang_thai_nha_up.SelectedValue = ID_TRANG_THAI_NHA.DANG_SU_DUNG.ToString();
    }

    private void load_data_to_grid()
    {
        US_V_GD_KHAU_HAO_DM_NHA v_us_v_gd_kh_dm_nha = new US_V_GD_KHAU_HAO_DM_NHA();
        DS_V_GD_KHAU_HAO_DM_NHA v_ds_v_gd_kh_dm_nha = new DS_V_GD_KHAU_HAO_DM_NHA();

        v_us_v_gd_kh_dm_nha.FillDatasetLoadDataToGridNha_by_tu_khoa(
            m_txt_tu_khoa.Text
            , CIPConvert.ToDecimal(m_cbo_bo_tinh_down.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan_down.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_down.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_trang_thai_nha_up.SelectedValue)
            , CONST_QLDB.ID_TAT_CA.ToString()
            , Person.get_user_name()
            , v_ds_v_gd_kh_dm_nha);
        m_grv_danh_sach_nha.DataSource = v_ds_v_gd_kh_dm_nha.V_GD_KHAU_HAO_DM_NHA;
        m_grv_danh_sach_nha.DataBind();
    }

    private void load_data_to_bo_tinh_up()
    {
        WinFormControls.load_data_to_cbo_bo_tinh(
                     WinFormControls.eTAT_CA.NO
                     , m_cbo_bo_tinh_up);
    }

    private void load_data_to_bo_tinh_down()
    {
        WinFormControls.load_data_to_cbo_bo_tinh(
                     WinFormControls.eTAT_CA.YES
                     , m_cbo_bo_tinh_down);
    }

    private void load_data_to_dv_chu_quan_up()
    {
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh_up.SelectedValue
                    , WinFormControls.eTAT_CA.NO
                    , m_cbo_don_vi_chu_quan_up);
    }

    private void load_data_to_dv_chu_quan_down()
    {
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh_down.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan_down);
    }

    private void load_data_to_dv_su_dung_up()
    {
        WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan_up.SelectedValue
                    , m_cbo_bo_tinh_up.SelectedValue
                    , WinFormControls.eTAT_CA.NO
                    , m_cbo_don_vi_su_dung_up);
    }

    private void load_data_to_dv_su_dung_down()
    {
        WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan_down.SelectedValue
                    , m_cbo_bo_tinh_down.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung_down);
    }

    private void load_data_to_khu_dat_up()
    {
        WinFormControls.load_data_to_cbo_dia_chi(
               CIPConvert.ToDecimal(m_cbo_bo_tinh_up.SelectedValue)
             , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan_up.SelectedValue)
             , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_up.SelectedValue)
             , ID_TRANG_THAI_DAT.DANG_SU_DUNG
             , WinFormControls.eTAT_CA.NO
             , m_cbo_thuoc_khu_dat);
    }

    private void load_data_to_khu_dat_down()
    {
        WinFormControls.load_data_to_cbo_dia_chi(
                   CIPConvert.ToDecimal(m_cbo_bo_tinh_down.SelectedValue)
                 , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan_down.SelectedValue)
                 , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_down.SelectedValue)
                 , ID_TRANG_THAI_DAT.DANG_SU_DUNG
                 , WinFormControls.eTAT_CA.NO
                 , m_cbo_dia_chi);
    }

    private void load_data_to_ten_tai_san()
    {
        US_V_DM_NHA v_us_v_dm_nha = new US_V_DM_NHA();
        DS_V_DM_NHA v_ds_v_dm_nha = new DS_V_DM_NHA();

        v_us_v_dm_nha.FillDatasetLoadDataToGridNha(
            CIPConvert.ToDecimal(m_cbo_bo_tinh_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_thuoc_khu_dat.SelectedValue)
            , Person.get_user_name()
            , CIPConvert.ToDecimal(m_cbo_trang_thai_nha_up.SelectedValue)
            , v_ds_v_dm_nha);

        m_cbo_ten_tai_san.DataSource = v_ds_v_dm_nha.V_DM_NHA;
        m_cbo_ten_tai_san.DataTextField = V_DM_NHA.TEN_TAI_SAN;
        m_cbo_ten_tai_san.DataValueField = V_DM_NHA.ID;
        m_cbo_ten_tai_san.DataBind();
    }

    private void them_moi_khau_hao()
    {
        decimal v_dc_id_nha = CIPConvert.ToDecimal(m_cbo_ten_tai_san.SelectedValue);
        decimal v_dc_gia_tri_khau_hao = CIPConvert.ToDecimal(m_txt_gia_tri_khau_hao.Text);
        US_DM_NHA v_us_dm_nha = new US_DM_NHA();
        US_GD_KHAU_HAO v_us_gd_khau_hao = new US_GD_KHAU_HAO();

        // Lấy thông tin mới cho giao dịch khấu hao
        v_us_gd_khau_hao.dcID_TAI_SAN = v_dc_id_nha;
        v_us_gd_khau_hao.dcID_LOAI_TAI_SAN = v_us_dm_nha.dcID_LOAI_TAI_SAN;
        v_us_gd_khau_hao.dcID_DON_VI = v_us_dm_nha.dcID_DON_VI_SU_DUNG;
        v_us_gd_khau_hao.dcGIA_TRI_KHAU_HAO = v_dc_gia_tri_khau_hao;
        v_us_gd_khau_hao.strMA_PHIEU = m_txt_ma_phieu.Text;
        v_us_gd_khau_hao.datNGAY_DUYET = CIPConvert.ToDatetime(m_txt_ngay_duyet.Text);
        v_us_gd_khau_hao.datNGAY_LAP = CIPConvert.ToDatetime(m_txt_ngay_lap.Text);
        v_us_gd_khau_hao.dcID_NGUOI_LAP = Person.get_user_id();
        v_us_gd_khau_hao.dcID_NGUOI_DUYET = Person.get_user_id();

        // Cập nhật cho nhà
        v_us_dm_nha.dcGIA_TRI_CON_LAI = v_us_dm_nha.dcGIA_TRI_CON_LAI - v_dc_gia_tri_khau_hao;

        // Thực hiện cập nhật
        v_us_gd_khau_hao.Insert();
        v_us_dm_nha.Update();
    }

    private void xoa_khau_hao(decimal ip_dc_id_kh, decimal ip_dc_id_nha, decimal ip_dc_gia_tri_kh)
    {
        US_DM_NHA v_us_dm_nha = new US_DM_NHA(ip_dc_id_nha);
        m_us_gd_khau_hao.DeleteByID(ip_dc_id_kh);
        v_us_dm_nha.dcGIA_TRI_CON_LAI += ip_dc_gia_tri_kh;
        v_us_dm_nha.Update();
        load_data_to_grid();
    }

    private void clear_form_data()
    {
        m_hdf_id.Value = "";
        m_lbl_nguyen_gia_nguon_khac.Text = "";
        m_lbl_nguyen_gia_nguon_ns.Text = "";
        m_lbl_gia_tri_con_lai.Text = "";
        m_lbl_ten_tai_san.Text = "";
        m_lbl_ma_tai_san.Text = "";
        m_lbl_cap_hang.Text = "";
        m_lbl_nam_xay_dung.Text = "";
        m_lbl_ngay_thang_nam_du_dung.Text = "";
        m_txt_ma_phieu.Text = "";
        m_txt_ngay_duyet.Text = "";
        m_txt_ngay_lap.Text = "";
        m_txt_gia_tri_khau_hao.Text = "";
    }

    private bool check_validate_data_is_valid()
    {
        if (CIPConvert.ToDecimal(m_txt_gia_tri_khau_hao.Text) > CIPConvert.ToDecimal(m_lbl_gia_tri_con_lai.Text))
        {
            m_lbl_mess.Text = "Không thể cập nhật. Lỗi: Giá trị khấu hao lớn hơn giá trị còn lại";
            return false;
        }
        string v_str_id_nha = m_cbo_ten_tai_san.SelectedValue;
        if (v_str_id_nha.Equals(String.Empty) || v_str_id_nha.Equals("-1"))
        {
            m_lbl_mess.Text = "Bạn chưa chọn tài sản";
            return false;
        }
        decimal v_dc_gia_tri_kh = CIPConvert.ToDecimal(m_txt_gia_tri_khau_hao.Text);
        if (v_dc_gia_tri_kh <= 0)
        {
            m_lbl_mess.Text = "Giá trị khấu hao phải lớn hơn 0";
            return false;
        }
        return true;
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e) {
        try {
            if (!IsPostBack) {
                load_form_data();
            }
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }

    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e) {
        try {
            Thread.Sleep(1000);
            load_data_to_grid();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_hdf_id_ValueChanged(object sender, EventArgs e) {
        try {
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_danh_sach_nha_PageIndexChanging(object sender, GridViewPageEventArgs e) {
        try {
            m_grv_danh_sach_nha.PageIndex = e.NewPageIndex;
            load_data_to_grid();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e) {
        try {
            if (!check_validate_data_is_valid()) return;
            them_moi_khau_hao();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }

    }
    protected void m_cmd_xoa_trang_Click(object sender, EventArgs e) {
        try {
            clear_form_data();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e) {
        try {
            m_grv_danh_sach_nha.AllowPaging = false;
            load_data_to_grid();
            WinformReport.export_gridview_2_excel(m_grv_danh_sach_nha
                , "DS khau hao nha.xls"
                , 0);
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_bo_tinh_up_SelectedIndexChanged(object sender, EventArgs e) {
        try {
            load_data_to_dv_chu_quan_up();
            load_data_to_dv_su_dung_up();
            load_data_to_khu_dat_up();
            load_data_to_ten_tai_san();
            load_data_from_us();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_chu_quan_up_SelectedIndexChanged(object sender, EventArgs e) {
        try {
            load_data_to_dv_su_dung_up();
            load_data_to_khu_dat_up();
            load_data_to_ten_tai_san();
            load_data_from_us();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_su_dung_up_SelectedIndexChanged(object sender, EventArgs e) {
        try {
            load_data_to_khu_dat_up();
            load_data_to_ten_tai_san();
            load_data_from_us();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_thuoc_khu_dat_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_to_ten_tai_san();
            load_data_from_us();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_ten_tai_san_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_from_us();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_bo_tinh_down_SelectedIndexChanged(object sender, EventArgs e) {
        try {
            load_data_to_dv_chu_quan_down();
            load_data_to_dv_su_dung_down();
            load_data_to_khu_dat_down();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_chu_quan_down_SelectedIndexChanged(object sender, EventArgs e) {
        try {
            load_data_to_dv_su_dung_down();
            load_data_to_khu_dat_down();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_su_dung_down_SelectedIndexChanged(object sender, EventArgs e) {
        try {
            load_data_to_khu_dat_down();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_danh_sach_nha_RowCommand(object sender, GridViewCommandEventArgs e) {
        try {
            if (!e.CommandName.Equals(String.Empty)) 
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                decimal v_dc_id_kh = CIPConvert.ToDecimal(m_grv_danh_sach_nha.DataKeys[rowIndex].Value);
                m_us_gd_khau_hao = new US_GD_KHAU_HAO(v_dc_id_kh);
                decimal v_dc_id_nha = m_us_gd_khau_hao.dcID_TAI_SAN;
                decimal v_dc_gia_tri_kh = m_us_gd_khau_hao.dcGIA_TRI_KHAU_HAO;

                switch (e.CommandName) 
                {
                    case "DeleteComp":
                        xoa_khau_hao(v_dc_id_kh, v_dc_id_nha, v_dc_gia_tri_kh);
                        break;
                }
            }
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    public override void VerifyRenderingInServerForm(Control control) {
        //base.VerifyRenderingInServerForm(control);
    }
    #endregion 
}
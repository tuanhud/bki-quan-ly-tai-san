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

public partial class ChucNang_F103_KhauHaoOto : System.Web.UI.Page
{

    #region Members

    #endregion

    #region private methods
    private void load_data_to_cbo_trang_thai_up()
    {
        DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
        v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_OTO, CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);
        m_cbo_trang_thai_o_to_up.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
        m_cbo_trang_thai_o_to_up.DataValueField = CM_DM_TU_DIEN.ID;
        m_cbo_trang_thai_o_to_up.DataTextField = CM_DM_TU_DIEN.TEN;
        m_cbo_trang_thai_o_to_up.DataBind();
        m_cbo_trang_thai_o_to_up.SelectedValue = ID_TRANG_THAI_OTO.DANG_SU_DUNG.ToString();
    }

    private void load_data_to_cbo_trang_thai_down()
    {
        DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
        v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_OTO, CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);
        m_cbo_trang_thai_o_to_down.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
        m_cbo_trang_thai_o_to_down.DataValueField = CM_DM_TU_DIEN.ID;
        m_cbo_trang_thai_o_to_down.DataTextField = CM_DM_TU_DIEN.TEN;
        m_cbo_trang_thai_o_to_down.DataBind();
    }

    private void load_data_from_us(decimal ip_dc_id_oto)
    {
        US_DM_OTO v_us_dm_oto = new US_DM_OTO(ip_dc_id_oto);
        m_lbl_ma_tai_san.Text = v_us_dm_oto.strMA_TAI_SAN;
        m_lbl_nhan_hieu.Text = v_us_dm_oto.strNHAN_HIEU;
        m_lbl_bien_kiem_soat.Text = v_us_dm_oto.strBIEN_KIEM_SOAT;
        m_lbl_nuoc_san_xuat.Text = v_us_dm_oto.strNUOC_SAN_XUAT;
        m_lbl_nam_san_xuat.Text = v_us_dm_oto.dcNAM_SAN_XUAT.ToString();
        m_lbl_nam_su_dung.Text = v_us_dm_oto.dcNAM_SU_DUNG.ToString();
        m_lbl_chuc_dang_su_dung.Text = v_us_dm_oto.strCHUC_DANH_SU_DUNG;
        m_lbl_nguyen_gia_nguon_ns.Text = v_us_dm_oto.dcNGUON_NS.ToString("#,##0.00");
        m_lbl_nguyen_gia_nguon_khac.Text = v_us_dm_oto.dcNGUON_KHAC.ToString("#,##0.00");
        m_lbl_gia_tri_con_lai.Text = v_us_dm_oto.dcGIA_TRI_CON_LAI.ToString("#,##0.00");
    }

    private void them_moi_khau_hao(decimal ip_dc_id)
    {
        US_GD_KHAU_HAO v_us_gd_khau_hao = new US_GD_KHAU_HAO();
        US_DM_OTO v_us_dm_oto = new US_DM_OTO(ip_dc_id);

        decimal v_dc_gia_tri_khau_hao = CIPConvert.ToDecimal(m_txt_gia_tri_khau_hao.Text);
        decimal v_dc_user_id = CIPConvert.ToDecimal(HttpContext.Current.Session[SESSION.UserID].ToString());

        // Lấy thông tin mới cho giao dịch khấu hao
        v_us_gd_khau_hao.dcID_TAI_SAN = ip_dc_id;
        v_us_gd_khau_hao.dcID_LOAI_TAI_SAN = ID_LOAI_TAI_SAN.NHA;
        v_us_gd_khau_hao.dcID_DON_VI = v_us_dm_oto.dcID_DON_VI_SU_DUNG;
        v_us_gd_khau_hao.dcGIA_TRI_KHAU_HAO = v_dc_gia_tri_khau_hao;
        v_us_gd_khau_hao.strMA_PHIEU = m_txt_ma_phieu.Text;
        v_us_gd_khau_hao.datNGAY_DUYET = CIPConvert.ToDatetime(m_txt_ngay_duyet.Text);
        v_us_gd_khau_hao.datNGAY_LAP = CIPConvert.ToDatetime(m_txt_ngay_lap.Text);
        v_us_gd_khau_hao.dcID_NGUOI_LAP = v_dc_user_id;
        v_us_gd_khau_hao.dcID_NGUOI_DUYET = v_dc_user_id;

        // Cập nhật cho nhà
        v_us_dm_oto.dcGIA_TRI_CON_LAI = v_us_dm_oto.dcGIA_TRI_CON_LAI - v_dc_gia_tri_khau_hao;

        // Thực hiện cập nhật
        v_us_gd_khau_hao.Insert();
        v_us_dm_oto.Update();
    }

    private void load_cbo_loai_xe()
    {
        try
        {
            DS_DM_LOAI_TAI_SAN v_ds_dm_loaits = new DS_DM_LOAI_TAI_SAN();
            US_DM_LOAI_TAI_SAN v_us_dm_loaits = new US_DM_LOAI_TAI_SAN();
            // DataRow v_dr_all = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.NewCM_DM_TU_DIENRow();
            // Đổ dữ liệu vào DS 
            v_us_dm_loaits.FillDataset(v_ds_dm_loaits, "where  = " + DM_LOAI_TAI_SAN.ID_LOAI_TAI_SAN_PARENT + " = "+ ID_LOAI_TAI_SAN.OTO); // Đây là lấy theo điều kiện
            m_cbo_loai_o_to_up.DataSource = v_ds_dm_loaits.DM_LOAI_TAI_SAN;
            m_cbo_loai_o_to_up.DataTextField = "TEN_LOAI_TAI_SAN";
            m_cbo_loai_o_to_up.DataValueField = "ID";
            m_cbo_loai_o_to_up.DataBind();
        }

        catch (Exception v_e)
        {
            throw v_e;
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
                //1. load data to combobox bộ, tỉnh - up
                WinFormControls.load_data_to_cbo_bo_tinh(
                         WinFormControls.eTAT_CA.YES
                         , m_cbo_bo_tinh_up);
                //2. load data to combobox đơn vị chủ quản - up
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh_up.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan_up);
                //3. load data to cobobox đơn vị sử dụng - up
                WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan_up.SelectedValue
                    , m_cbo_bo_tinh_up.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung_tai_san_up);
                //4. load data to combobox trạng thái - up
                load_data_to_cbo_trang_thai_up();
                //a. load data to combobox bộ, tỉnh - down
                WinFormControls.load_data_to_cbo_bo_tinh(
                    WinFormControls.eTAT_CA.YES,
                    m_cbo_bo_tinh_down
                    );
                //b. load data to combobox đơn vị chủ quản - down
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(m_cbo_bo_tinh_down.SelectedValue,
                    WinFormControls.eTAT_CA.YES, m_cbo_don_vi_chu_quan_down);
                //c. load data to combobox đơn vi sử dụng - down
                WinFormControls.load_data_to_cbo_don_vi_su_dung(m_cbo_don_vi_chu_quan_down.SelectedValue,
                    m_cbo_bo_tinh_down.SelectedValue, WinFormControls.eTAT_CA.YES, m_cbo_don_vi_su_dung_tai_san_down);
                //d. load data to combobox trạng thái - down
                load_data_to_cbo_trang_thai_down();
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    protected void m_cbo_bo_tinh_up_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                m_cbo_bo_tinh_up.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_chu_quan_up);
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan_up.SelectedValue
                , m_cbo_bo_tinh_up.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_tai_san_up);
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    protected void m_cbo_don_vi_chu_quan_up_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan_up.SelectedValue
                , m_cbo_bo_tinh_up.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_tai_san_up);
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }

    protected void m_cbo_bo_tinh_down_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            WinFormControls.load_data_to_cbo_don_vi_chu_quan(m_cbo_bo_tinh_down.SelectedValue,
                WinFormControls.eTAT_CA.YES, m_cbo_don_vi_chu_quan_down);
            WinFormControls.load_data_to_cbo_don_vi_su_dung(m_cbo_don_vi_chu_quan_down.SelectedValue,
                m_cbo_bo_tinh_down.SelectedValue, WinFormControls.eTAT_CA.YES, m_cbo_don_vi_su_dung_tai_san_down);
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }

    protected void m_cbo_don_vi_chu_quan_down_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            WinFormControls.load_data_to_cbo_don_vi_su_dung(m_cbo_don_vi_chu_quan_down.SelectedValue,
                m_cbo_bo_tinh_down.SelectedValue, WinFormControls.eTAT_CA.YES, m_cbo_don_vi_su_dung_tai_san_down);
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }

    protected void m_txt_ten_tai_san_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (!m_hdf_id.Value.Equals(String.Empty))
            {
                decimal v_dc_id = CIPConvert.ToDecimal(m_hdf_id.Value);
                load_data_from_us(v_dc_id);
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
            if (!m_hdf_id.Value.Equals(String.Empty))
            {
                them_moi_khau_hao(CIPConvert.ToDecimal(m_hdf_id.Value));
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
            m_lbl_ma_tai_san.Text = "";
            m_lbl_nhan_hieu.Text = "";
            m_lbl_bien_kiem_soat.Text = "";
            m_lbl_nuoc_san_xuat.Text = "";
            m_lbl_nam_san_xuat.Text = "";
            m_lbl_nam_su_dung.Text = "";
            m_lbl_chuc_dang_su_dung.Text = "";
            m_lbl_nguyen_gia_nguon_ns.Text = "";
            m_lbl_nguyen_gia_nguon_khac.Text = "";
            m_lbl_gia_tri_con_lai.Text = "";
            m_txt_ma_phieu.Text = "";
            m_txt_gia_tri_khau_hao.Text = "";
            m_txt_ngay_lap.Text = "";
            m_txt_ngay_duyet.Text = "";
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_hdf_id_ValueChanged(object sender, EventArgs e)
    {
        try
        {
            if (!m_hdf_id.Value.Equals(String.Empty))
            {
                decimal v_dc_id = CIPConvert.ToDecimal(m_hdf_id.Value);
                load_data_from_us(v_dc_id);
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_grv_dm_oto_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {

    }
    #endregion
}
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using WebDS.CDBNames;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;
using IP.Core.IPException;
using IP.Core.IPUserService;
using IP.Core.WinFormControls;
using IP.Core.QltsFormControls;

public partial class ChucNang_F105_KhauHaoDat : System.Web.UI.Page
{
    #region Members
    #endregion

    #region Private Methods
    private void load_form_data()
    {
        load_data_trang_thai();
        load_data_to_bo_tinh_up();
        load_data_to_bo_tinh_down();
        load_data_to_dv_chu_quan_up();
        load_data_to_dv_chu_quan_down();
        load_data_to_dv_su_dung_up();
        load_data_to_dv_su_dung_down();
        load_data_to_grid();
    }

    private void load_data_trang_thai()
    {
        DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();

        v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_DAT, CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);
        m_cbo_trang_thai_dat_up.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
        m_cbo_trang_thai_dat_up.DataTextField = CM_DM_TU_DIEN.TEN;
        m_cbo_trang_thai_dat_up.DataValueField = CM_DM_TU_DIEN.ID;
        m_cbo_trang_thai_dat_up.DataBind();
        m_cbo_trang_thai_dat_up.SelectedValue = ID_TRANG_THAI_NHA.DANG_SU_DUNG.ToString();
    }

    private void load_data_to_grid()
    {
        US_V_GD_KHAU_HAO_DM_DAT v_us_v_gd_khau_hao_dm_dat = new US_V_GD_KHAU_HAO_DM_DAT();
        DS_V_GD_KHAU_HAO_DM_DAT v_ds_v_gd_khau_hao_dm_dat = new DS_V_GD_KHAU_HAO_DM_DAT();

        v_us_v_gd_khau_hao_dm_dat.FillDataSetByKeyWord(
            m_cbo_bo_tinh_down.SelectedValue,
            m_cbo_don_vi_chu_quan_down.SelectedValue,
            m_cbo_don_vi_su_dung_down.SelectedValue,
            CONST_QLDB.ID_TAT_CA.ToString(),
            Person.get_user_name(),
            CONST_QLDB.ID_TAT_CA.ToString(),
            m_txt_tu_khoa.Text.Trim(),
            v_ds_v_gd_khau_hao_dm_dat);
        m_grv_danh_sach_dat.DataSource = v_ds_v_gd_khau_hao_dm_dat.V_GD_KHAU_HAO_DM_DAT;
        m_grv_danh_sach_dat.DataBind();
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

    private void load_data_from_us()
    {
        US_DM_DAT v_us_dm_dat = new US_DM_DAT(CIPConvert.ToDecimal(m_hdf_id.Value));
        m_lbl_ma_tai_san.Text = v_us_dm_dat.strMA_TAI_SAN;
        m_lbl_dt_khuon_vien.Text = v_us_dm_dat.dcDT_KHUON_VIEN.ToString("#,##0.00");
        m_lbl_so_nam_su_dung.Text = v_us_dm_dat.dcSO_NAM_DA_SU_DUNG.ToString();
        m_lbl_gt_theo_so_ke_toan.Text = v_us_dm_dat.dcGT_THEO_SO_KE_TOAN.ToString("#,##0.00");
    }

    private void them_moi_khau_hao()
    {
        US_GD_KHAU_HAO v_us_gd_khau_hao = new US_GD_KHAU_HAO();
        US_DM_DAT v_us_dm_dat = new US_DM_DAT(CIPConvert.ToDecimal(m_hdf_id.Value));

        decimal v_dc_gia_tri_khau_hao = CIPConvert.ToDecimal(m_txt_gia_tri_khau_hao.Text);

        // Lấy thông tin mới cho giao dịch khấu hao
        v_us_gd_khau_hao.dcID_TAI_SAN = CIPConvert.ToDecimal(m_hdf_id.Value);
        v_us_gd_khau_hao.dcID_LOAI_TAI_SAN = v_us_dm_dat.dcID_LOAI_TAI_SAN;
        v_us_gd_khau_hao.dcID_DON_VI = v_us_dm_dat.dcID_DON_VI_SU_DUNG;
        v_us_gd_khau_hao.dcGIA_TRI_KHAU_HAO = v_dc_gia_tri_khau_hao;
        v_us_gd_khau_hao.strMA_PHIEU = m_txt_ma_phieu.Text;
        v_us_gd_khau_hao.datNGAY_DUYET = CIPConvert.ToDatetime(m_txt_ngay_duyet.Text);
        v_us_gd_khau_hao.datNGAY_LAP = CIPConvert.ToDatetime(m_txt_ngay_lap.Text);
        v_us_gd_khau_hao.dcID_NGUOI_LAP = Person.get_user_id();
        v_us_gd_khau_hao.dcID_NGUOI_DUYET = Person.get_user_id();

        // Cập nhật cho nhà
        v_us_dm_dat.dcGT_THEO_SO_KE_TOAN = v_us_dm_dat.dcGT_THEO_SO_KE_TOAN - v_dc_gia_tri_khau_hao;

        // Thực hiện cập nhật
        v_us_gd_khau_hao.Insert();
        v_us_dm_dat.Update();
    }

    private void clear_form_data()
    {
        m_lbl_ma_tai_san.Text = "";
        m_lbl_dt_khuon_vien.Text = "";
        m_lbl_gt_theo_so_ke_toan.Text = "";
        m_lbl_so_nam_su_dung.Text = "";
        m_txt_ma_phieu.Text = "";
        m_txt_ngay_duyet.Text = "";
        m_txt_ngay_lap.Text = "";
        m_txt_gia_tri_khau_hao.Text = "";
        m_hdf_id.Value = "";
    }

    private bool check_validate_data_is_valid()
    {
        if (CIPConvert.ToDecimal(m_txt_gia_tri_khau_hao.Text) > CIPConvert.ToDecimal(m_lbl_gt_theo_so_ke_toan.Text))
        {
            m_lbl_mess.Text = "Không thể cập nhật. Lỗi: Giá trị khấu hao lớn hơn giá trị còn lại";
            return false;
        }
        if (m_hdf_id.Value.Equals(String.Empty))
        {
            m_lbl_mess.Text = "Bạn chưa chọn tài sản";
            return false;
        }
        return true;
    }
    #endregion

    #region Events
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
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
    protected void m_cbo_bo_tinh_up_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_to_dv_chu_quan_up();
            load_data_to_dv_su_dung_up();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_chu_quan_up_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_to_dv_su_dung_up();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
        load_data_to_dv_su_dung_up();
    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_bo_tinh_down_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_to_dv_chu_quan_down();
            load_data_to_dv_su_dung_down();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_chu_quan_down_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_to_dv_su_dung_down();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_txt_dia_chi_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (!m_hdf_id.Value.Equals(String.Empty))
            {
                load_data_from_us();
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
            if (!check_validate_data_is_valid()) return;
            them_moi_khau_hao();
            m_lbl_mess.Text = "Cập nhật thành công";
            clear_form_data();
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
            clear_form_data();
            m_lbl_mess.Text = "";
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_danh_sach_dat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_danh_sach_dat.PageIndex = e.NewPageIndex;
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_danh_sach_dat_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (!e.CommandName.Equals(String.Empty))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                decimal v_dc_id_kh = CIPConvert.ToDecimal(m_grv_danh_sach_dat.DataKeys[rowIndex].Value);

                switch (e.CommandName)
                {
                    case "DeleteComp":
                        US_GD_KHAU_HAO v_us_gd_khau_hao = new US_GD_KHAU_HAO();
                        v_us_gd_khau_hao.DeleteByID(v_dc_id_kh);
                        load_data_to_grid();
                        break;
                }
            }
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
                load_data_from_us();
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
}
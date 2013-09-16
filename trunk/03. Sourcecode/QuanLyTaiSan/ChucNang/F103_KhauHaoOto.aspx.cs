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
using System.Threading;

public partial class ChucNang_F103_KhauHaoOto : System.Web.UI.Page
{
    #region Members
    private US_GD_KHAU_HAO m_us_gd_kh = new US_GD_KHAU_HAO();
    #endregion

    #region Private methods
    private bool check_validate_data_is_valid()
    {
        if (CIPConvert.ToDecimal(m_txt_gia_tri_khau_hao.Text) > CIPConvert.ToDecimal(m_lbl_gia_tri_con_lai.Text))
        {
            m_lbl_message.Text = "Không thể cập nhật. Lỗi: Giá trị khấu hao lớn hơn giá trị còn lại";
            return false;
        }
        
        string v_str_id_oto = m_cbo_ten_tai_san.SelectedValue;
        if (v_str_id_oto.Equals(String.Empty) || v_str_id_oto.Equals(CONST_QLDB.MA_TAT_CA))
        {
            m_lbl_message.Text = "Bạn chưa chọn tài sản";
            return false;
        }

        decimal v_dc_gia_tri_kh = CIPConvert.ToDecimal(m_txt_gia_tri_khau_hao.Text);
        if (v_dc_gia_tri_kh <= 0)
        {
            m_lbl_message.Text = "Giá trị khấu hao phải lớn hơn 0";
            return false;
        }

        if (!m_us_gd_kh.check_ma_khau_hao_is_valid(m_txt_ma_phieu.Text.Trim()))
        {
            m_lbl_message.Text = "Mã phiếu này đã tồn tại";
            return false;
        }
        
        return true;
    }

    private void load_data_to_cbo_trang_thai_up()
    {
        WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_OTO
            , WinFormControls.eTAT_CA.NO
            , m_cbo_trang_thai_o_to_up);
        m_cbo_trang_thai_o_to_up.SelectedValue = ID_TRANG_THAI_OTO.DANG_SU_DUNG.ToString();
    }

    private void load_data_to_cbo_trang_thai_down()
    {
        WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_OTO
            , WinFormControls.eTAT_CA.NO
            , m_cbo_trang_thai_o_to_down);
    }

    private void load_data_from_us()
    {
        clear_form_data();
        if (m_cbo_ten_tai_san.Items.Count == 0) return;
        decimal v_dc_id_oto = CIPConvert.ToDecimal(m_cbo_ten_tai_san.SelectedValue);
        if (v_dc_id_oto < 1) return;
        US_DM_OTO v_us_dm_oto = new US_DM_OTO(v_dc_id_oto);
        m_lbl_ma_tai_san.Text = v_us_dm_oto.strMA_TAI_SAN;
        m_lbl_nhan_hieu.Text = v_us_dm_oto.strNHAN_HIEU;
        m_lbl_bien_kiem_soat.Text = v_us_dm_oto.strBIEN_KIEM_SOAT;
        m_lbl_nuoc_san_xuat.Text = v_us_dm_oto.strNUOC_SAN_XUAT;
        m_lbl_nam_san_xuat.Text = v_us_dm_oto.dcNAM_SAN_XUAT.ToString();
        m_lbl_nam_su_dung.Text = v_us_dm_oto.dcNAM_SU_DUNG.ToString();
        m_lbl_chuc_dang_su_dung.Text = v_us_dm_oto.strCHUC_DANH_SU_DUNG;
        m_lbl_nguyen_gia_nguon_ns.Text = v_us_dm_oto.dcNGUON_NS.ToString("#,##0");
        m_lbl_nguyen_gia_nguon_khac.Text = v_us_dm_oto.dcNGUON_KHAC.ToString("#,##0");
        m_lbl_gia_tri_con_lai.Text = v_us_dm_oto.dcGIA_TRI_CON_LAI.ToString("#,##0");
    }

    private void them_moi_khau_hao()
    {
        decimal v_dc_id_tai_san = CIPConvert.ToDecimal(m_cbo_ten_tai_san.SelectedValue);
        US_GD_KHAU_HAO v_us_gd_khau_hao = new US_GD_KHAU_HAO();
        US_DM_OTO v_us_dm_oto = new US_DM_OTO(v_dc_id_tai_san);
        decimal v_dc_gia_tri_khau_hao = CIPConvert.ToDecimal(m_txt_gia_tri_khau_hao.Text);
        // Lấy thông tin mới cho giao dịch khấu hao
        v_us_gd_khau_hao.dcID_TAI_SAN = v_dc_id_tai_san;
        v_us_gd_khau_hao.dcID_LOAI_TAI_SAN = v_us_dm_oto.dcID_LOAI_TAI_SAN;
        v_us_gd_khau_hao.dcID_DON_VI = v_us_dm_oto.dcID_DON_VI_SU_DUNG;
        v_us_gd_khau_hao.dcGIA_TRI_KHAU_HAO = v_dc_gia_tri_khau_hao;
        v_us_gd_khau_hao.strMA_PHIEU = m_txt_ma_phieu.Text;
        v_us_gd_khau_hao.datNGAY_DUYET = CIPConvert.ToDatetime(m_txt_ngay_duyet.Text);
        v_us_gd_khau_hao.datNGAY_LAP = CIPConvert.ToDatetime(m_txt_ngay_lap.Text);
        v_us_gd_khau_hao.dcID_NGUOI_LAP = Person.get_user_id();
        v_us_gd_khau_hao.dcID_NGUOI_DUYET = Person.get_user_id();
        // Cập nhật cho nhà
        v_us_dm_oto.dcGIA_TRI_CON_LAI = v_us_dm_oto.dcGIA_TRI_CON_LAI - v_dc_gia_tri_khau_hao;
        // Thực hiện cập nhật
        v_us_gd_khau_hao.Insert();
        v_us_dm_oto.Update();
        m_lbl_message.Text = "Cập nhật thành công";
    }

    private void load_cbo_loai_xe()
    {
        try
        {
            DS_DM_LOAI_TAI_SAN v_ds_dm_loaits = new DS_DM_LOAI_TAI_SAN();
            US_DM_LOAI_TAI_SAN v_us_dm_loaits = new US_DM_LOAI_TAI_SAN();
            // DataRow v_dr_all = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.NewCM_DM_TU_DIENRow();
            // Đổ dữ liệu vào DS 
            v_us_dm_loaits.FillDataset(v_ds_dm_loaits, "where " + DM_LOAI_TAI_SAN.ID_LOAI_TAI_SAN_PARENT + " = " + ID_LOAI_TAI_SAN.OTO); // Đây là lấy theo điều kiện
            m_cbo_loai_o_to_up.DataSource = v_ds_dm_loaits.DM_LOAI_TAI_SAN;
            m_cbo_loai_o_to_up.DataTextField = "TEN_LOAI_TAI_SAN";
            m_cbo_loai_o_to_up.DataValueField = "ID";
            m_cbo_loai_o_to_up.DataBind();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    private void load_form_data()
    {
        m_grv_dm_oto.Columns[0].Visible = Person.Allow2DeleteData();
        clear_form_data();
        load_data_to_bo_tinh_up();
        load_data_to_bo_tinh_down();
        load_data_to_cbo_trang_thai_up();
        load_data_to_cbo_trang_thai_down();
        load_data_to_dv_chu_quan_up();
        load_data_to_dv_chu_quan_down();
        load_data_to_dv_su_dung_up();
        load_data_to_dv_su_dung_down();
        load_cbo_loai_xe();
        load_data_to_ten_tai_san();
        load_data_to_grid();
        load_data_from_us();
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

    private void load_data_to_ten_tai_san()
    {
        DS_V_DM_OTO v_ds_v_dm_oto = new DS_V_DM_OTO();
        US_V_DM_OTO v_us_v_dm_oto = new US_V_DM_OTO();
        v_us_v_dm_oto.FillDatasetLoadDataToGridOto_by_tu_khoa(
            String.Empty
            , CIPConvert.ToDecimal(m_cbo_bo_tinh_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san_up.SelectedValue)
            , ID_TRANG_THAI_OTO.DANG_SU_DUNG
            , CIPConvert.ToDecimal(m_cbo_loai_o_to_up.SelectedValue)
            , CONST_QLDB.MA_TAT_CA
            , Person.get_user_name()
            , v_ds_v_dm_oto);
        m_cbo_ten_tai_san.DataSource = v_ds_v_dm_oto.V_DM_OTO;
        m_cbo_ten_tai_san.DataTextField = V_DM_OTO.TEN_TAI_SAN;
        m_cbo_ten_tai_san.DataValueField = V_DM_OTO.ID;
        m_cbo_ten_tai_san.DataBind();
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
             , m_cbo_don_vi_su_dung_tai_san_up);
    }

    private void load_data_to_dv_su_dung_down()
    {
        WinFormControls.load_data_to_cbo_don_vi_su_dung(
            m_cbo_don_vi_chu_quan_down.SelectedValue
            , m_cbo_bo_tinh_down.SelectedValue
            , WinFormControls.eTAT_CA.YES
            , m_cbo_don_vi_su_dung_tai_san_down);
    }

    private void clear_form_data()
    {
        m_txt_ma_phieu.Text = "";
        m_txt_gia_tri_khau_hao.Text = "";
        m_txt_ngay_lap.Text = "";
        m_txt_ngay_duyet.Text = "";
        m_hdf_id.Value = "";
    }

    private void load_data_to_grid()
    {
        m_lbl_thong_tin_khau_hao.Text = "DANH SÁCH CÁC LẦN KHẤU HAO";
        US_V_GD_KHAU_HAO_DM_OTO v_us_v_gd_khau_hao_oto = new US_V_GD_KHAU_HAO_DM_OTO();
        DS_V_GD_KHAU_HAO_DM_OTO v_ds_v_gd_khau_hao_oto = new DS_V_GD_KHAU_HAO_DM_OTO();

        v_us_v_gd_khau_hao_oto.FillDatasetLoadDataToGridOto_by_tu_khoa(
            m_txt_tu_khoa.Text
            , CIPConvert.ToDecimal(m_cbo_bo_tinh_down.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan_down.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san_down.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_trang_thai_o_to_down.SelectedValue)
            , CONST_QLDB.ID_TAT_CA
            , CONST_QLDB.MA_TAT_CA
            , Person.get_user_name()
            , v_ds_v_gd_khau_hao_oto);
        m_grv_dm_oto.DataSource = v_ds_v_gd_khau_hao_oto.V_GD_KHAU_HAO_DM_OTO;
        string v_str_thong_tin = " (Có " + v_ds_v_gd_khau_hao_oto.V_GD_KHAU_HAO_DM_OTO.Rows.Count + " bản ghi)";
        m_lbl_thong_tin_khau_hao.Text += v_str_thong_tin;
        m_grv_dm_oto.DataBind();
    }

    private void xoa_khau_hao(decimal ip_dc_id_kh, decimal ip_dc_id_oto, decimal ip_dc_gia_tri_kh)
    {
        US_DM_OTO v_us_dm_oto = new US_DM_OTO(ip_dc_id_oto);
        m_us_gd_kh.DeleteByID(ip_dc_id_kh);
        v_us_dm_oto.dcGIA_TRI_CON_LAI += ip_dc_gia_tri_kh;
        v_us_dm_oto.Update();
    }

    private void export_gridview_2_excel()
    {
        m_grv_dm_oto.AllowPaging = false;
        load_data_to_grid();
        WinformReport.export_gridview_2_excel(m_grv_dm_oto
            , "DM khau hao oto.xls"
            , 0);
    }
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
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void m_cbo_bo_tinh_up_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_to_dv_chu_quan_up();
            load_data_to_dv_su_dung_up();
            load_data_to_ten_tai_san();
            load_data_from_us();
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
            load_data_to_dv_su_dung_up();
            load_data_to_ten_tai_san();
            load_data_from_us();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    protected void m_cbo_don_vi_su_dung_tai_san_up_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void m_cbo_loai_o_to_up_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void m_cbo_bo_tinh_down_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_to_dv_chu_quan_down();
            load_data_to_dv_su_dung_down();
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
            load_data_to_dv_su_dung_down();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    protected void m_grv_dm_oto_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (!e.CommandName.Equals(String.Empty))
            {
                int v_dc_rowIndex = Convert.ToInt32(e.CommandArgument);
                decimal v_dc_id_kh = CIPConvert.ToDecimal(m_grv_dm_oto.DataKeys[v_dc_rowIndex].Value);
                m_us_gd_kh = new US_GD_KHAU_HAO(v_dc_id_kh);
                decimal v_dc_id_oto = m_us_gd_kh.dcID_TAI_SAN;
                decimal v_dc_gia_tri_kh = m_us_gd_kh.dcGIA_TRI_KHAU_HAO;

                switch (e.CommandName)
                {
                    case "DeleteComp":
                        xoa_khau_hao(v_dc_id_kh, v_dc_id_oto, v_dc_gia_tri_kh);
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
    protected void m_grv_dm_oto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_dm_oto.PageIndex = e.NewPageIndex;
            load_data_to_grid();
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
            export_gridview_2_excel();
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
            load_form_data();
            Thread.Sleep(1000);
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
            m_lbl_message.Text = "";
            clear_form_data();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
}
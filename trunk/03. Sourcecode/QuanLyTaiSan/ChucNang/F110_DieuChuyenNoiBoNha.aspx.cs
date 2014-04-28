using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using WebDS.CDBNames;
using IP.Core.IPBusinessService;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPException;
using IP.Core.IPUserService;
using IP.Core.WinFormControls;
using IP.Core.QltsFormControls;

public partial class ChucNang_F110_DieuChuyenNoiBoNha : System.Web.UI.Page
{
    #region Members
    private US_GD_TANG_GIAM_TAI_SAN m_us_gd_tang_giam_tai_san = new US_GD_TANG_GIAM_TAI_SAN();
    #endregion

    #region Private Methods
    private void load_data_2_form()
    {
        clear_form_data();
        clear_thong_tin_tai_san();
        load_data_to_bo_tinh_up();
        load_data_to_bo_tinh_down();
        load_data_to_dv_chu_quan_up();
        load_data_to_dv_chu_quan_down();
        load_data_to_dv_su_dung_up();
        load_data_to_dv_su_dung_down();
        load_data_to_khu_dat_up();
        load_data_to_khu_dat_down();
        load_data_trang_thai();
        load_data_to_dv_su_dung_moi();
        load_data_to_ten_tai_san();
        load_data_from_us();
        //load_data_to_ly_do();
        //select_loai_tang_giam();
        //set_caption_by_loai_tang_giam();
        load_data_to_grid();
    }

    private void load_data_from_us()
    {
        if (m_cbo_ten_tai_san.Items.Count == 0) return;
        decimal v_dc_id_nha = CIPConvert.ToDecimal(m_cbo_ten_tai_san.SelectedValue);
        if (v_dc_id_nha < 1) return;
        US_DM_NHA v_us_dm_nha = new US_DM_NHA(CIPConvert.ToDecimal(v_dc_id_nha));
        m_lbl_ten_tai_san.Text = v_us_dm_nha.strTEN_TAI_SAN;
        m_lbl_ma_tai_san.Text = v_us_dm_nha.strMA_TAI_SAN;
        m_lbl_cap_hang.Text = v_us_dm_nha.dcCAP_HANG.ToString();
        m_lbl_nam_xay_dung.Text = v_us_dm_nha.dcNAM_XAY_DUNG.ToString();
        m_lbl_ngay_thang_nam_du_dung.Text = v_us_dm_nha.dcNGAY_THANG_NAM_SU_DUNG.ToString();
        m_lbl_nguyen_gia_nguon_ns.Text = v_us_dm_nha.dcNGUON_NS.ToString("#,##0");
        m_lbl_nguyen_gia_nguon_khac.Text = v_us_dm_nha.dcNGUON_KHAC.ToString("#,##0");
        m_lbl_gia_tri_con_lai.Text = v_us_dm_nha.dcGIA_TRI_CON_LAI.ToString("#,##0");
    }

    //private void load_data_to_ly_do()
    //{
    //    WinFormControls.eLOAI_TANG_GIAM_TAI_SAN v_e_loai = WinFormControls.eLOAI_TANG_GIAM_TAI_SAN.GIAM_TAI_SAN;

    //    string v_str_trang_thai = m_cbo_trang_thai_nha_up.SelectedValue;

    //    switch (v_str_trang_thai)
    //    {
    //        case TRANG_THAI_NHA.DE_NGHI_XU_LY:
    //            v_e_loai = WinFormControls.eLOAI_TANG_GIAM_TAI_SAN.GIAM_TAI_SAN;
    //            break;
    //        case TRANG_THAI_NHA.DA_DIEU_CHUYEN:
    //            v_e_loai = WinFormControls.eLOAI_TANG_GIAM_TAI_SAN.TANG_TAI_SAN;
    //            break;
    //    }

    //    WinFormControls.load_data_to_cbo_ly_do_tang_giam(
    //        WinFormControls.eLOAI_TU_DIEN.LY_DO_TANG_GIAM_TS
    //        , v_e_loai
    //        , m_cbo_ly_do_thay_doi);
    //}

    private void load_data_trang_thai()
    {
        WinFormControls.load_data_to_cbo_trang_thai_tang_giam(
            WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_NHA
            , WinFormControls.eTAT_CA.NO
            , m_cbo_trang_thai_nha_up);
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
                    , m_cbo_don_vi_su_dung_tai_san_up);
    }

    private void load_data_to_dv_su_dung_down()
    {
        WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan_down.SelectedValue
                    , m_cbo_bo_tinh_down.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung_down);
    }

    private void load_data_to_dv_su_dung_moi()
    {
        WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_cbo_don_vi_chu_quan_up.SelectedValue
                    , m_cbo_bo_tinh_up.SelectedValue
                    , WinFormControls.eTAT_CA.NO
                    , m_cbo_don_vi_su_dung_moi);
    }

    private void load_data_to_khu_dat_up()
    {
        WinFormControls.load_data_to_cbo_dia_chi(
               CIPConvert.ToDecimal(m_cbo_bo_tinh_up.SelectedValue)
             , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan_up.SelectedValue)
             , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san_up.SelectedValue)
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
                 , WinFormControls.eTAT_CA.YES
                 , m_cbo_dia_chi);
    }

    private void load_data_to_ten_tai_san()
    {
        if (m_cbo_thuoc_khu_dat.Items.Count == 0)
        {
            return;
        }

        US_V_DM_NHA v_us_v_dm_nha = new US_V_DM_NHA();
        DS_V_DM_NHA v_ds_v_dm_nha = new DS_V_DM_NHA();

        v_us_v_dm_nha.FillDatasetLoadDataToGridNha(
            CIPConvert.ToDecimal(m_cbo_bo_tinh_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san_up.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_thuoc_khu_dat.SelectedValue)
            , Person.get_user_name()
            , CIPConvert.ToDecimal(m_cbo_trang_thai_nha_up.SelectedValue)
            , v_ds_v_dm_nha);

        m_cbo_ten_tai_san.DataSource = v_ds_v_dm_nha.V_DM_NHA;
        m_cbo_ten_tai_san.DataTextField = V_DM_NHA.TEN_TAI_SAN;
        m_cbo_ten_tai_san.DataValueField = V_DM_NHA.ID;
        m_cbo_ten_tai_san.DataBind();
    }

    private void load_data_to_grid()
    {
        m_lbl_thong_tin_nha.Text = "Danh sách duyệt ghi tăng giảm tài sản";

        US_V_GD_TANG_GIAM_TAI_SAN_NHA v_us_v_gd_tg_tsn = new US_V_GD_TANG_GIAM_TAI_SAN_NHA();
        DS_V_GD_TANG_GIAM_TAI_SAN_NHA v_ds_v_gd_tg_tsn = new DS_V_GD_TANG_GIAM_TAI_SAN_NHA();
        v_us_v_gd_tg_tsn.FillDatasetLoadDataToGridNha_by_tu_khoa(
            m_txt_tu_khoa.Text.Trim()
            , CIPConvert.ToDecimal(m_cbo_bo_tinh_down.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_down.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_down.SelectedValue)
            , CIPConvert.ToDecimal(m_cbo_dia_chi.SelectedValue)
            , CONST_QLDB.ID_TAT_CA
            , CONST_QLDB.MA_TAT_CA
            , Person.get_user_name()
            , v_ds_v_gd_tg_tsn);

        string v_str_thong_tin = " (Có " + v_ds_v_gd_tg_tsn.V_GD_TANG_GIAM_TAI_SAN_NHA.Rows.Count + " bản ghi)";
        m_lbl_thong_tin_nha.Text += v_str_thong_tin;
        m_grv_danh_sach_nha.DataSource = v_ds_v_gd_tg_tsn.V_GD_TANG_GIAM_TAI_SAN_NHA;
        m_grv_danh_sach_nha.DataBind();
    }

    private void clear_form_data()
    {
        m_txt_ma_phieu_tang.Text = "";
        m_txt_ma_phieu_giam.Text = "";
    }

    private bool check_validate_data_is_ok()
    {
        if (m_cbo_ten_tai_san.Items.Count == 0)
        {
            m_lbl_message.Text = "Bạn chưa lựa chọn tài sản";
            m_cbo_ten_tai_san.Focus();
            return false;
        }

        if (!m_us_gd_tang_giam_tai_san.check_valid_ma_phieu(m_txt_ma_phieu_giam.Text))
        {
            m_lbl_message.Text = "Lỗi: Mã phiểu giảm đã tồn tại";
            m_txt_ma_phieu_giam.Focus();
            return false;
        }
        if (!m_us_gd_tang_giam_tai_san.check_valid_ma_phieu(m_txt_ma_phieu_tang.Text))
        {
            m_lbl_message.Text = "Lỗi: Mã phiểu tăng này đã tồn tại";
            m_txt_ma_phieu_tang.Focus();
            return false;
        }


        if (m_cbo_don_vi_su_dung_moi.SelectedValue == m_cbo_don_vi_su_dung_tai_san_up.SelectedValue)
        {
            m_lbl_message.Text = "Đơn vị sử dụng của tài sản chưa được thay đổi. Hãy lựa chọn một đơn vị khác.";
            m_cbo_don_vi_su_dung_moi.Focus();
            return false;
        }
        return true;
    }

    private void them_moi_ghi_giam()
    {
        US_DM_NHA v_us_dm_nha = new US_DM_NHA(CIPConvert.ToDecimal(m_cbo_ten_tai_san.SelectedValue));
        v_us_dm_nha.strMA_TAI_SAN = v_us_dm_nha.strMA_TAI_SAN + "-Cũ";
        v_us_dm_nha.dcID_TRANG_THAI = ID_KHAC.DIEU_CHUYEN_NOI_BO;
        v_us_dm_nha.Insert();
        m_us_gd_tang_giam_tai_san = new US_GD_TANG_GIAM_TAI_SAN();
        m_us_gd_tang_giam_tai_san.datNGAY_DUYET = m_dat_ngay_duyet.SelectedDate;
        m_us_gd_tang_giam_tai_san.datNGAY_TANG_GIAM_TAI_SAN = m_dat_ngay_tang_giam.SelectedDate;
        m_us_gd_tang_giam_tai_san.dcID_LY_DO_TANG_GIAM = ID_LY_DO_TANG_GIAM_TAI_SAN.DIEU_CHUYEN;
        m_us_gd_tang_giam_tai_san.strTANG_GIA_TRI_TAI_SAN_YN = "N";

        m_us_gd_tang_giam_tai_san.dcID_TAI_SAN = v_us_dm_nha.dcID;
        m_us_gd_tang_giam_tai_san.dcID_LOAI_TAI_SAN = v_us_dm_nha.dcID_LOAI_TAI_SAN;
        m_us_gd_tang_giam_tai_san.strMA_PHIEU = m_txt_ma_phieu_giam.Text;
        m_us_gd_tang_giam_tai_san.dcDIEN_TICH = v_us_dm_nha.dcDT_XAY_DUNG;
        m_us_gd_tang_giam_tai_san.dcGIA_TRI_NGUYEN_GIA_TANG_GIAM = v_us_dm_nha.dcNGUON_NS + v_us_dm_nha.dcNGUON_KHAC;

        m_us_gd_tang_giam_tai_san.dcID_NGUOI_LAP = Person.get_user_id();
        m_us_gd_tang_giam_tai_san.dcID_NGUOI_DUYET = Person.get_user_id();

        m_us_gd_tang_giam_tai_san.Insert();

        m_lbl_message.Text = "Cập nhật thành công";
        m_txt_tu_khoa.Text = m_us_gd_tang_giam_tai_san.strMA_PHIEU;
    }

    private void them_moi_ghi_tang()
    {
        US_DM_NHA v_us_dm_nha = new US_DM_NHA(CIPConvert.ToDecimal(m_cbo_ten_tai_san.SelectedValue));
        m_us_gd_tang_giam_tai_san = new US_GD_TANG_GIAM_TAI_SAN();
        m_us_gd_tang_giam_tai_san.datNGAY_DUYET = m_dat_duyet_dieu_chuyen.SelectedDate;
        m_us_gd_tang_giam_tai_san.datNGAY_TANG_GIAM_TAI_SAN = m_dat_nhan_dieu_chuyen.SelectedDate;
        m_us_gd_tang_giam_tai_san.dcID_LY_DO_TANG_GIAM = ID_LY_DO_TANG_GIAM_TAI_SAN.TRANG_CAP_MUA_MOI;
        m_us_gd_tang_giam_tai_san.strTANG_GIA_TRI_TAI_SAN_YN = "Y";

        m_us_gd_tang_giam_tai_san.dcID_TAI_SAN = v_us_dm_nha.dcID;
        m_us_gd_tang_giam_tai_san.dcID_LOAI_TAI_SAN = v_us_dm_nha.dcID_LOAI_TAI_SAN;
        m_us_gd_tang_giam_tai_san.strMA_PHIEU = m_txt_ma_phieu_tang.Text;
        m_us_gd_tang_giam_tai_san.dcDIEN_TICH = v_us_dm_nha.dcDT_XAY_DUNG;
        m_us_gd_tang_giam_tai_san.dcGIA_TRI_NGUYEN_GIA_TANG_GIAM = v_us_dm_nha.dcNGUON_NS + v_us_dm_nha.dcNGUON_KHAC;

        m_us_gd_tang_giam_tai_san.dcID_NGUOI_LAP = Person.get_user_id();
        m_us_gd_tang_giam_tai_san.dcID_NGUOI_DUYET = Person.get_user_id();

        m_us_gd_tang_giam_tai_san.Insert();

        m_lbl_message.Text = "Cập nhật thành công";
    }

    private void cap_nhat_thong_tin_tai_san()
    {
        US_DM_NHA v_us_dm_nha = new US_DM_NHA(CIPConvert.ToDecimal(m_cbo_ten_tai_san.SelectedValue));
        v_us_dm_nha.dcID_TRANG_THAI = ID_TRANG_THAI_NHA.DANG_SU_DUNG;
        v_us_dm_nha.dcID_DON_VI_SU_DUNG = CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_moi.SelectedValue);
        v_us_dm_nha.Update();
        string v_str_dv_cu = m_cbo_don_vi_su_dung_tai_san_up.SelectedItem.Text;
        string v_str_dv_moi = m_cbo_don_vi_su_dung_moi.SelectedItem.Text;
        m_lbl_message.Text = "Đã điều chuyển tài sản " + v_us_dm_nha.strTEN_TAI_SAN
            + " từ đơn vị " + v_str_dv_cu + " đến đơn vị " + v_str_dv_moi;
    }

    //private void select_loai_tang_giam()
    //{
    //    decimal v_dc_loai_tang_giam = CIPConvert.ToDecimal(m_cbo_ly_do_thay_doi.SelectedValue);
    //    if (v_dc_loai_tang_giam == ID_LY_DO_TANG_GIAM_TAI_SAN.THANH_LY
    //        || v_dc_loai_tang_giam == ID_LY_DO_TANG_GIAM_TAI_SAN.DIEU_CHUYEN)
    //    {
    //        m_rbl_loai.SelectedValue = "N";
    //    }
    //    else
    //    {
    //        m_rbl_loai.SelectedValue = "Y";
    //    }
    //}

    //private void set_caption_by_loai_tang_giam()
    //{
    //    decimal v_dc_loai_tang_giam = CIPConvert.ToDecimal(m_cbo_ly_do_thay_doi.SelectedValue);
    //    if (v_dc_loai_tang_giam == ID_LY_DO_TANG_GIAM_TAI_SAN.THANH_LY)
    //    {
    //        m_lbl_caption.Text = "CHI TIẾT THANH LÝ TÀI SẢN NHÀ";
    //        return;
    //    }
    //    if (v_dc_loai_tang_giam == ID_LY_DO_TANG_GIAM_TAI_SAN.DIEU_CHUYEN)
    //    {
    //        m_lbl_caption.Text = "CHI TIẾT ĐIỀU CHUYỂN TÀI SẢN NHÀ";
    //        return;
    //    }
    //}

    private void export_gridview_to_excel()
    {
        m_grv_danh_sach_nha.AllowPaging = false;
        load_data_to_grid();
        WinformReport.export_gridview_2_excel(
                m_grv_danh_sach_nha
                , "De nghi tang giam nha.xls");
    }

    private void clear_message()
    {
        m_lbl_message.Text = "";
    }

    private void clear_thong_tin_tai_san()
    {
        m_lbl_ten_tai_san.Text = "";
        m_lbl_ma_tai_san.Text = "";
        m_lbl_cap_hang.Text = "";
        m_lbl_nam_xay_dung.Text = "";
        m_lbl_ngay_thang_nam_du_dung.Text = "";
        m_lbl_nguyen_gia_nguon_ns.Text = "";
        m_lbl_nguyen_gia_nguon_khac.Text = "";
        m_lbl_gia_tri_con_lai.Text = "";
    }

    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                load_data_2_form();
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
            clear_message();
            clear_thong_tin_tai_san();
            load_data_to_dv_chu_quan_up();
            load_data_to_dv_su_dung_up();
            load_data_to_khu_dat_up();
            load_data_to_ten_tai_san();
            load_data_from_us();
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
            clear_message();
            clear_thong_tin_tai_san();
            load_data_to_dv_su_dung_up();
            load_data_to_khu_dat_up();
            load_data_to_ten_tai_san();
            load_data_from_us();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_su_dung_tai_san_up_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            clear_thong_tin_tai_san();
            load_data_to_khu_dat_up();
            load_data_to_ten_tai_san();
            load_data_from_us();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_thuoc_khu_dat_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            clear_thong_tin_tai_san();
            load_data_to_ten_tai_san();
            load_data_from_us();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_trang_thai_nha_up_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            clear_thong_tin_tai_san();
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
            clear_message();
            clear_thong_tin_tai_san();
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
            clear_message();
            load_data_to_dv_chu_quan_down();
            load_data_to_dv_su_dung_down();
            load_data_to_khu_dat_down();
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
            clear_message();
            load_data_to_dv_su_dung_down();
            load_data_to_khu_dat_down();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_su_dung_down_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            load_data_to_khu_dat_down();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_ly_do_thay_doi_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            //select_loai_tang_giam();
            //set_caption_by_loai_tang_giam();
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
            clear_message();
            if (!check_validate_data_is_ok()) return;
            them_moi_ghi_giam();
            them_moi_ghi_tang();
            cap_nhat_thong_tin_tai_san();
            load_data_2_form();
            m_cbo_bo_tinh_up.Focus();
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
            clear_message();
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
            clear_message();
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
            clear_message();
            export_gridview_to_excel();
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
            clear_message();
            m_grv_danh_sach_nha.PageIndex = e.NewPageIndex;
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_danh_sach_nha_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_txt_tu_khoa_TextChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_dia_chi_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_su_dung_moi_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion        
}
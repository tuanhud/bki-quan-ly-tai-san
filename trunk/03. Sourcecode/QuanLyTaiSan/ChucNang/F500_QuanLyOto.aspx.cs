using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;
using WebDS;
using WebDS.CDBNames;
using System.Data;
using IP.Core.IPBusinessService;
using IP.Core.IPException;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;
using IP.Core.IPException;
using IP.Core.WinFormControls;
using System.Threading;


public partial class ChucNang_F500_QuanLyOto : System.Web.UI.Page
{
    #region Members
    US_DM_OTO m_us_dm_oto = new US_DM_OTO();
    DS_DM_OTO m_ds_dm_oto = new DS_DM_OTO();

    IP.Core.IPUserService.US_CM_DM_TU_DIEN m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    IP.Core.IPData.DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    DataEntryFormMode m_init_mode = DataEntryFormMode.InsertDataState;


    #endregion

    #region Private Methods
    private void export_to_excel()
    {
        Thread.Sleep(2000);
        // vì có phân trang, nên nếu muốn xuất all dữ liệu trên lưới (tất cả các trang) thì thê 2 dòng sau:
        m_grv_dm_oto.AllowPaging = false;
        search_oto(m_txt_tim_kiem.Text);  // đây là hàm load lại dữ liệu lên lưới
        // còn nếu chỉ muốn xuất dữ liệu ở Page hiện tại thì không cần 2 dòng trên
        WinformReport.export_gridview_2_excel(
                    m_grv_dm_oto
                    , "DS oto.xls"
                    , 0
                    , 1); // 0 và 1 là số thứ tự 2 cột: Sửa, Xóa
    }
    private void load_2_cbo_loaits()
    {
        try
        {
            DS_DM_LOAI_TAI_SAN v_ds_dm_loaits = new DS_DM_LOAI_TAI_SAN();
            US_DM_LOAI_TAI_SAN v_us_dm_loaits = new US_DM_LOAI_TAI_SAN();
            // DataRow v_dr_all = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.NewCM_DM_TU_DIENRow();
            // Đổ dữ liệu vào DS 
            v_us_dm_loaits.FillDataset(v_ds_dm_loaits, "where ID_LOAI_TAI_SAN_PARENT = 3"); // Đây là lấy theo điều kiện
            m_ddl_loai_xe.DataSource = v_ds_dm_loaits.DM_LOAI_TAI_SAN;
            m_ddl_loai_xe.DataTextField = "TEN_LOAI_TAI_SAN";
            m_ddl_loai_xe.DataValueField = "ID";
            m_ddl_loai_xe.DataBind();
        }

        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_data_trang_thai()
    {
        try
        {
            DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
            v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_OTO, CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);
            m_ddl_trang_thai_oto.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_ddl_trang_thai_oto.DataTextField = CM_DM_TU_DIEN.TEN;
            m_ddl_trang_thai_oto.DataValueField = CM_DM_TU_DIEN.ID;
            m_ddl_trang_thai_oto.DataBind();
            m_ddl_trang_thai_oto.SelectedValue = TRANG_THAI_OTO.DANG_SU_DUNG;
        }

        catch (Exception v_e)
        {
            throw v_e;
        }

    }
    private void set_form_mode()
    {
        switch (m_init_mode)
        {
            case DataEntryFormMode.InsertDataState:
                m_cmd_tao_moi.Visible = true;
                m_cmd_cap_nhat.Visible = false;
                m_lbl_caption.Text = "NHẬP MỚI TÀI SẢN Ô TÔ";
                break;
            case DataEntryFormMode.SelectDataState:
                break;
            case DataEntryFormMode.UpdateDataState:
                m_cmd_tao_moi.Visible = false;
                m_cmd_cap_nhat.Visible = true;
                m_lbl_caption.Text = "CẬP NHẬT THÔNG TIN TÀI SẢN Ô TÔ";
                break;
            case DataEntryFormMode.ViewDataState:
                break;
            default:
                break;
        }
    }
    private void reset_control()
    {
        m_txt_bien_kiem_soat.Text = "";
        m_txt_chuc_danh_sd_xe.Text = "";
        m_txt_cong_suat_xe.Text = "";
        m_txt_gia_tri_con_lai.Text = "";
        m_txt_nam_san_xuat.Text = "";
        m_txt_nguon_goc_xe.Text = "";
        m_txt_nguon_khac.Text = "";
        m_txt_nguon_ns.Text = "";
        m_txt_nuoc_san_xuat.Text = "";
        m_txt_tai_trong.Text = "";
        m_txt_ten_nhan_hieu.Text = "";
        m_txt_ten_ts.Text = "";
        m_txt_ma_ts.Text = "";
        m_txt_nam_su_dung.Text = "";
        m_txt_tim_kiem.Text = "";
        m_lbl_mess.Text = "";
        m_lbl_thong_bao.Text = "";
        m_txt_ten_ts.Focus();
    }
    private void form_2_us_object(US_DM_OTO ip_us_oto)
    {
        ip_us_oto.dcID_NGUOI_LAP = CIPConvert.ToDecimal(Person.get_user_id());
        if (!m_hdf_id.Value.Equals(String.Empty))
        {
            ip_us_oto.dcID = CIPConvert.ToDecimal(m_hdf_id.Value);
        }
        ip_us_oto.strNGUON_GOC_XE = m_txt_nguon_goc_xe.Text;
        ip_us_oto.dcSO_CHO_NGOI = CIPConvert.ToDecimal(m_txt_tai_trong.Text);
        ip_us_oto.dcCONG_SUAT_XE = CIPConvert.ToDecimal(m_txt_cong_suat_xe.Text);
        ip_us_oto.datNGAY_CAP_NHAT_CUOI = DateTime.Now;
        ip_us_oto.dcNAM_SU_DUNG = CIPConvert.ToDecimal(m_txt_nam_su_dung.Text);
        ip_us_oto.dcNAM_SAN_XUAT = CIPConvert.ToDecimal(m_txt_nam_san_xuat.Text);
        ip_us_oto.dcGIA_TRI_CON_LAI = CIPConvert.ToDecimal(m_txt_gia_tri_con_lai.Text);
        ip_us_oto.dcNGUON_KHAC = CIPConvert.ToDecimal(m_txt_nguon_khac.Text);
        ip_us_oto.dcNGUON_NS = CIPConvert.ToDecimal(m_txt_nguon_ns.Text);
        ip_us_oto.strBIEN_KIEM_SOAT = m_txt_bien_kiem_soat.Text;
        ip_us_oto.strCHUC_DANH_SU_DUNG = m_txt_chuc_danh_sd_xe.Text;
        ip_us_oto.strNGUON_GOC_XE = m_txt_nguon_goc_xe.Text;
        ip_us_oto.strNHAN_HIEU = m_txt_ten_nhan_hieu.Text;
        ip_us_oto.strNUOC_SAN_XUAT = m_txt_nuoc_san_xuat.Text;
        ip_us_oto.strMA_TAI_SAN = m_txt_ma_ts.Text;
        ip_us_oto.strTEN_TAI_SAN = m_txt_ten_ts.Text;
        ip_us_oto.datNGAY_CAP_NHAT_CUOI = DateTime.Now;
        ip_us_oto.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_ddl_trang_thai_oto.SelectedValue);
        ip_us_oto.dcID_LOAI_TAI_SAN = CIPConvert.ToDecimal(m_ddl_loai_xe.SelectedValue);
        ip_us_oto.dcID_DON_VI_SU_DUNG = CIPConvert.ToDecimal(m_ddl_dv_sd_ts.SelectedValue);
        ip_us_oto.dcID_DON_VI_CHU_QUAN = CIPConvert.ToDecimal(m_ddl_dv_chu_quan.SelectedValue);
        ip_us_oto.dcID_TINH_TRANG = CIPConvert.ToDecimal(m_ddl_tinh_trang_oto.SelectedValue);
        set_gia_tri_hien_trang(ip_us_oto);
    }
    private void us_obj_2_form(US_DM_OTO ip_us_oto)
    {
        m_hdf_id.Value = ip_us_oto.dcID.ToString();
        m_txt_tai_trong.Text = ip_us_oto.dcSO_CHO_NGOI.ToString();
        m_txt_ma_ts.Text = ip_us_oto.strMA_TAI_SAN;
        m_txt_nam_su_dung.Text = ip_us_oto.dcNAM_SU_DUNG.ToString();
        m_txt_nam_san_xuat.Text = ip_us_oto.dcNAM_SAN_XUAT.ToString();
        m_txt_gia_tri_con_lai.Text = ip_us_oto.dcGIA_TRI_CON_LAI.ToString("#,##0");
        m_txt_ten_nhan_hieu.Text = ip_us_oto.strNHAN_HIEU;
        m_txt_nuoc_san_xuat.Text = ip_us_oto.strNUOC_SAN_XUAT;
        m_txt_bien_kiem_soat.Text = ip_us_oto.strBIEN_KIEM_SOAT;
        m_txt_chuc_danh_sd_xe.Text = ip_us_oto.strCHUC_DANH_SU_DUNG;
        m_txt_nguon_goc_xe.Text = ip_us_oto.strNGUON_GOC_XE;
        m_txt_cong_suat_xe.Text = ip_us_oto.dcCONG_SUAT_XE.ToString();
        m_txt_nguon_khac.Text = ip_us_oto.dcNGUON_KHAC.ToString("#,##0");
        m_txt_nguon_ns.Text = ip_us_oto.dcNGUON_NS.ToString("#,##0");
        m_txt_ten_ts.Text = ip_us_oto.strTEN_TAI_SAN;
        m_ddl_loai_xe.SelectedValue = ip_us_oto.dcID_LOAI_TAI_SAN.ToString();
        m_ddl_tinh_trang_oto.SelectedValue = ip_us_oto.dcID_TINH_TRANG.ToString();

        load_gia_tri_hien_trang(ip_us_oto);

        US_DM_DON_VI v_us_don_vi = new US_DM_DON_VI(ip_us_oto.dcID_DON_VI_CHU_QUAN);
        m_ddl_bo_tinh.SelectedValue = v_us_don_vi.dcID_DON_VI_CAP_TREN.ToString();

        WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                   m_ddl_bo_tinh.SelectedValue
                   , WinFormControls.eTAT_CA.NO
                   , m_ddl_dv_chu_quan);

        m_ddl_dv_chu_quan.SelectedValue = ip_us_oto.dcID_DON_VI_CHU_QUAN.ToString();

        WinFormControls.load_data_to_cbo_don_vi_su_dung(
            m_ddl_dv_chu_quan.SelectedValue
            , m_ddl_bo_tinh.SelectedValue
            , WinFormControls.eTAT_CA.NO
            , m_ddl_dv_sd_ts);
        m_ddl_dv_sd_ts.SelectedValue = ip_us_oto.dcID_DON_VI_SU_DUNG.ToString();

        m_ddl_trang_thai_oto.SelectedValue = ip_us_oto.dcID_TRANG_THAI.ToString();
        m_txt_ten_ts.Focus();
    }
    private void load_data_to_grid()
    {
        try
        {
            m_lbl_ket_qua_loc_du_lieu.Text = "DANH SÁCH Ô TÔ";
            // Đổ dữ liệu từ US vào DS

            US_V_DM_OTO v_us_v_dm_oto = new US_V_DM_OTO();
            DS_V_DM_OTO v_ds_v_dm_oto = new DS_V_DM_OTO();

            v_us_v_dm_oto.FillDatasetLoadDataToGridOto_by_tu_khoa(
                m_txt_tim_kiem.Text.Trim()
                , CONST_QLDB.ID_TAT_CA
                , CONST_QLDB.ID_TAT_CA
                , CONST_QLDB.ID_TAT_CA
                , CONST_QLDB.ID_TAT_CA
                , CONST_QLDB.ID_TAT_CA
                , CONST_QLDB.MA_TAT_CA
                , Person.get_user_name()
                , v_ds_v_dm_oto);

            // Treo dữ liệu lên lưới
            string v_str_thong_tin = " (Có " + v_ds_v_dm_oto.V_DM_OTO.Rows.Count + " bản ghi)";
            m_lbl_ket_qua_loc_du_lieu.Text += v_str_thong_tin;
            m_grv_dm_oto.DataSource = v_ds_v_dm_oto.V_DM_OTO;
            m_grv_dm_oto.DataBind();

        }
        catch (Exception v_e)
        {
            //nhớ using Ip.Common
            CSystemLog_301.ExceptionHandle(this, v_e);

        }

    }
    private void delete_dm_oto(int ip_i_row_del)
    {
        decimal v_dc_id_oto = CIPConvert.ToDecimal(m_grv_dm_oto.DataKeys[ip_i_row_del].Value);
        m_us_dm_oto.dcID = v_dc_id_oto;
        m_us_dm_oto.DeleteByID(v_dc_id_oto);
        m_lbl_mess.Text = "Xóa bản ghi thành công!";
        load_data_to_grid();
    }
    private void load_data_2_us_by_id(int ip_i_id)
    {

        decimal v_dc_id_dm_oto = CIPConvert.ToDecimal(m_grv_dm_oto.DataKeys[ip_i_id].Value);
        m_hdf_id.Value = v_dc_id_dm_oto.ToString();
        US_DM_OTO v_us_dm_oto = new US_DM_OTO(v_dc_id_dm_oto);
        m_hdf_id.Value = v_us_dm_oto.dcID.ToString();
        // Đẩy us lên form
        us_obj_2_form(v_us_dm_oto);
    }
    private bool check_validate_data_is_ok()
    {
        if (!CValidateTextBox.IsValid(m_txt_nam_su_dung, DataType.NumberType, allowNull.YES))
        {
            m_lbl_mess.Text = "Chưa nhập đúng năm sử dụng";
            return false;
        }
        if (!CValidateTextBox.IsValid(m_txt_nam_san_xuat, DataType.NumberType, allowNull.YES))
        {
            m_lbl_mess.Text = "Chưa nhập đúng năm sản xuất";
            return false;
        }
        if ((m_txt_nam_su_dung.Text.Trim().Length > 0) && (m_txt_nam_san_xuat.Text.Trim().Length > 0))
        {
            if (CIPConvert.ToDecimal(m_txt_nam_su_dung.Text) < CIPConvert.ToDecimal(m_txt_nam_san_xuat.Text))
            {
                m_lbl_mess.Text = "Năm sử dụng phải lớn hơn hoặc bằng năm sản xuất!";
                m_txt_nam_su_dung.Focus();
                return false;
            }
        }
        if ((m_txt_nguon_ns.Text.Trim().Length > 0) & (m_txt_nguon_khac.Text.Trim().Length > 0) & (m_txt_gia_tri_con_lai.Text.Trim().Length > 0))
        {
            if (CIPConvert.ToDecimal(m_txt_nguon_ns.Text) + CIPConvert.ToDecimal(m_txt_nguon_khac.Text) < CIPConvert.ToDecimal(m_txt_gia_tri_con_lai.Text))
            {
                m_lbl_mess.Text = "Nguyên giá (nguồn ngân sách + nguồn khác) phải lớn hơn giá trị còn lại!";
                m_txt_gia_tri_con_lai.Focus();
                return false;
            }
        }

        if (m_init_mode == DataEntryFormMode.UpdateDataState)
        {
            m_us_dm_oto = new US_DM_OTO(CIPConvert.ToDecimal(m_hdf_id.Value));
            if (m_us_dm_oto.strMA_TAI_SAN != m_txt_ma_ts.Text)
            {
                if (!m_us_dm_oto.check_ma_valid(m_txt_ma_ts.Text))
                {
                    m_lbl_mess.Text = "Không thể cập nhật. Lỗi: Mã tài sản này đã tồn tại";
                    m_txt_ma_ts.Focus();
                    return false;
                }
            }
        }
        if (m_init_mode == DataEntryFormMode.InsertDataState)
        {
            if (!m_us_dm_oto.check_ma_valid(m_txt_ma_ts.Text.Trim()))
            {
                m_lbl_mess.Text = "Mã tài sản này đã tồn tại";
                m_txt_ma_ts.Focus();
                return false;
            };
        }
        return true;
    }
    private void insert_data()
    {
        if (m_init_mode == DataEntryFormMode.UpdateDataState) return;
        if (!check_validate_data_is_ok()) return;
        form_2_us_object(m_us_dm_oto);
        m_us_dm_oto.Insert();
        reset_control();
        m_txt_tim_kiem.Text = m_us_dm_oto.strMA_TAI_SAN;
        load_data_to_grid();
        m_hdf_id.Value = m_us_dm_oto.dcID.ToString();
        m_lbl_mess.Text = "Thêm bản ghi thành công!";
        display_panel_tang_giam();
        m_ddl_bo_tinh.Focus();
    }
    private void update_data()
    {
        if (m_hdf_id.Value == "")
        {
            m_lbl_mess.Text = "Bạn phải chọn nội dung cần Cập nhật!";

            return;
        }
        if (!check_validate_data_is_ok()) return;
        form_2_us_object(m_us_dm_oto);
        m_us_dm_oto.Update();
        reset_control();
        set_form_mode();
        m_lbl_mess.Text = "Cập nhật dữ liệu thành công!";
        m_grv_dm_oto.EditIndex = -1;
        load_data_to_grid();
    }
    private void search_oto(string ip_str_tu_khoa)
    {
        m_lbl_thong_bao.Text = "";
        m_lbl_ket_qua_loc_du_lieu.Text = "DANH SÁCH Ô TÔ";
        m_us_dm_oto.FillDatasetBySearch(
            m_ds_dm_oto
            , ip_str_tu_khoa
            , CONST_QLDB.ID_TAT_CA
            , CONST_QLDB.ID_TAT_CA
            , CONST_QLDB.ID_TAT_CA
            , CONST_QLDB.ID_TAT_CA);
        m_grv_dm_oto.DataSource = m_ds_dm_oto.DM_OTO;
        string v_str_thong_tin = " (Có " + m_ds_dm_oto.DM_OTO.Rows.Count + " bản ghi)";
        m_lbl_ket_qua_loc_du_lieu.Text += v_str_thong_tin;
        m_grv_dm_oto.DataSource = m_ds_dm_oto.DM_OTO;
        m_grv_dm_oto.DataBind();
        if (m_ds_dm_oto.DM_OTO.Rows.Count == 0) m_lbl_thong_bao.Text = "Không có ô tô nào thỏa mãn!";
    }
    private void load_data_to_ly_do()
    {
        WinFormControls.load_data_to_cbo_ly_do_tang_giam(
            WinFormControls.eLOAI_TU_DIEN.LY_DO_TANG_GIAM_TS
            , WinFormControls.eLOAI_TANG_GIAM_TAI_SAN.TANG_TAI_SAN
            , m_cbo_ly_do_thay_doi);
    }
    private void hidden_panel_tang_giam()
    {
        m_mtv_1.SetActiveView(m_view_confirm);
        m_pnl_confirm_tg.Visible = false;
    }
    private void display_panel_tang_giam()
    {
        if (m_hdf_id.Value == "") return;
        load_data_to_ly_do();
        m_pnl_confirm_tg.Visible = true;
        m_mtv_1.SetActiveView(m_view_confirm);
    }
    private void them_moi_tang_giam()
    {
        US_GD_TANG_GIAM_TAI_SAN v_us_gd_tang_giam_tai_san = new US_GD_TANG_GIAM_TAI_SAN();
        m_us_dm_oto = new US_DM_OTO(CIPConvert.ToDecimal(m_hdf_id.Value));
        v_us_gd_tang_giam_tai_san.datNGAY_DUYET = m_dat_ngay_duyet.SelectedDate;
        v_us_gd_tang_giam_tai_san.datNGAY_TANG_GIAM_TAI_SAN = m_dat_ngay_tang_giam.SelectedDate;
        v_us_gd_tang_giam_tai_san.dcID_LY_DO_TANG_GIAM = CIPConvert.ToDecimal(m_cbo_ly_do_thay_doi.SelectedValue);
        v_us_gd_tang_giam_tai_san.strTANG_GIA_TRI_TAI_SAN_YN = m_rbl_loai.SelectedValue;

        v_us_gd_tang_giam_tai_san.dcID_TAI_SAN = m_us_dm_oto.dcID;
        v_us_gd_tang_giam_tai_san.dcID_LOAI_TAI_SAN = m_us_dm_oto.dcID_LOAI_TAI_SAN;
        v_us_gd_tang_giam_tai_san.strMA_PHIEU = m_txt_ma_phieu.Text;
        v_us_gd_tang_giam_tai_san.dcDIEN_TICH = m_us_dm_oto.dcKINH_DOANH + m_us_dm_oto.dcKHONG_KINH_DOANH;
        v_us_gd_tang_giam_tai_san.dcGIA_TRI_NGUYEN_GIA_TANG_GIAM = m_us_dm_oto.dcNGUON_NS + m_us_dm_oto.dcNGUON_KHAC;

        v_us_gd_tang_giam_tai_san.dcID_NGUOI_LAP = Person.get_user_id();
        v_us_gd_tang_giam_tai_san.dcID_NGUOI_DUYET = Person.get_user_id();

        v_us_gd_tang_giam_tai_san.Insert();

        // Phần cập nhật thông tin cho DM
        set_form_mode();
        WinFormControls.load_data_to_cbo_bo_tinh(
             WinFormControls.eTAT_CA.NO
             , m_ddl_bo_tinh);
        WinFormControls.load_data_to_cbo_don_vi_chu_quan(
            m_ddl_bo_tinh.SelectedValue
            , WinFormControls.eTAT_CA.NO
            , m_ddl_dv_chu_quan);
        WinFormControls.load_data_to_cbo_don_vi_su_dung(
            m_ddl_dv_chu_quan.SelectedValue
            , m_ddl_bo_tinh.SelectedValue
            , WinFormControls.eTAT_CA.NO
            , m_ddl_dv_sd_ts);
        load_2_cbo_loaits();
        load_data_trang_thai();
        load_data_to_grid();
        m_txt_tim_kiem.Text = v_us_gd_tang_giam_tai_san.strMA_PHIEU;
    }
    private void clear_panel_data()
    {
        m_txt_ma_phieu.Text = "";
    }
    private void lua_chon_loai_tang_giam()
    {
        decimal v_dc_loai_tang_giam = CIPConvert.ToDecimal(m_cbo_ly_do_thay_doi.SelectedValue);
        if (v_dc_loai_tang_giam == ID_LY_DO_TANG_GIAM_TAI_SAN.THANH_LY
            || v_dc_loai_tang_giam == ID_LY_DO_TANG_GIAM_TAI_SAN.DIEU_CHUYEN)
        {
            m_rbl_loai.SelectedValue = "N";
        }
        else
        {
            m_rbl_loai.SelectedValue = "Y";
        }
    }
    private void clear_message()
    {
        m_lbl_mess.Text = "";
    }
    private void set_gia_tri_hien_trang(US_DM_OTO ip_us_dm_oto)
    {
        string v_str_hien_trang = m_rbl_muc_dich_su_dung.SelectedValue;
        ip_us_dm_oto.dcQLNN = 0;
        ip_us_dm_oto.dcKINH_DOANH = 0;
        ip_us_dm_oto.dcKHONG_KINH_DOANH = 0;
        ip_us_dm_oto.dcHD_KHAC = 0;

        switch (v_str_hien_trang)
        {
            case "QLNN":
                ip_us_dm_oto.dcQLNN = 1;
                break;
            case "KD":
                ip_us_dm_oto.dcKINH_DOANH = 1;
                break;
            case "KKD":
                ip_us_dm_oto.dcKHONG_KINH_DOANH = 1;
                break;
            case "MDK":
                ip_us_dm_oto.dcHD_KHAC = 1;
                break;
        }
    }
    private void load_gia_tri_hien_trang(US_DM_OTO ip_us_dm_oto)
    {
        if ( ip_us_dm_oto.dcQLNN == 1)
        {
            m_rbl_muc_dich_su_dung.SelectedValue = "QLNN";
            return;
        }
        if ( ip_us_dm_oto.dcKINH_DOANH == 1)
        {
            m_rbl_muc_dich_su_dung.SelectedValue = "KD";
            return;
        }
        if ( ip_us_dm_oto.dcKHONG_KINH_DOANH == 1)
        {
            m_rbl_muc_dich_su_dung.SelectedValue = "KKD";
            return;
        }
        if ( ip_us_dm_oto.dcHD_KHAC == 1)
        {
            m_rbl_muc_dich_su_dung.SelectedValue = "MDK";
            return;
        }
    }
    private void load_data_tinh_trang_oto()
    {
        WinFormControls.load_data_to_cbo_tu_dien(
            WinFormControls.eLOAI_TU_DIEN.TINH_TRANG_TAI_SAN
            , WinFormControls.eTAT_CA.NO
            , m_ddl_tinh_trang_oto);
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

            /*m_lbl_mess.Text = "";
            if (m_init_mode == DataEntryFormMode.UpdateDataState)
            {
                m_cmd_tao_moi.Enabled = false;
            }
            else
            {
                m_cmd_tao_moi.Enabled = true;
            }*/

            if (!IsPostBack)
            {
                set_form_mode();
                WinFormControls.load_data_to_cbo_bo_tinh(
                     WinFormControls.eTAT_CA.NO
                     , m_ddl_bo_tinh);
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_ddl_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.NO
                    , m_ddl_dv_chu_quan);
                WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_ddl_dv_chu_quan.SelectedValue
                    , m_ddl_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.NO
                    , m_ddl_dv_sd_ts);
                load_2_cbo_loaits();
                load_data_trang_thai();
                load_data_to_grid();
                hidden_panel_tang_giam();
                load_data_tinh_trang_oto();
                //Code này là chức năng liên quan đến from F1000
                if (Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.ID_OTO] != null)
                {
                    decimal v_dc_id_oto = CIPConvert.ToDecimal(Request.QueryString[CONST_QLDB.MA_THAM_SO_URL.ID_OTO]);
                    m_us_dm_oto = new US_DM_OTO(v_dc_id_oto);
                    us_obj_2_form(m_us_dm_oto);
                }
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
            clear_message();
            insert_data();
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
            clear_message();
            m_init_mode = DataEntryFormMode.UpdateDataState;
            update_data();
            m_ddl_bo_tinh.Focus();
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            reset_control();
            set_form_mode();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.Equals(this, v_e);
        }
    }
    protected void m_grv_dm_oto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            clear_message();
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
            clear_message();
            // Thu thập dữ liệu search
            string v_str_tu_khoa_tim_kiem = m_txt_tim_kiem.Text.Trim();
            // Search Môn học
            search_oto(v_str_tu_khoa_tim_kiem);
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
            clear_message();
            WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                   m_ddl_bo_tinh.SelectedValue
                   , WinFormControls.eTAT_CA.NO
                   , m_ddl_dv_chu_quan);
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_ddl_dv_chu_quan.SelectedValue
                , m_ddl_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.NO
                , m_ddl_dv_sd_ts);
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    protected void m_ddl_dv_chu_quan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                    m_ddl_dv_chu_quan.SelectedValue
                    , m_ddl_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.NO
                    , m_ddl_dv_sd_ts);
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(v_e);
        }


    }
    protected void m_grv_danh_sach_nha_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            clear_message();
            if (!e.CommandName.Equals(String.Empty))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                decimal v_ud_dm_oto_id = CIPConvert.ToDecimal(m_grv_dm_oto.DataKeys[rowIndex].Value);

                switch (e.CommandName)
                {
                    case "EditComp":
                        load_data_2_us_by_id(rowIndex);
                        m_init_mode = DataEntryFormMode.UpdateDataState;
                        set_form_mode();
                        load_data_to_grid();
                        break;
                    case "DeleteComp":
                        m_us_dm_oto.DeleteByID(v_ud_dm_oto_id);
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
    protected void m_cmd_export_excel_Click(object sender, EventArgs e)
    {
        try
        {
            clear_message();
            export_to_excel();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
    protected void m_cmd_tao_tang_giam_Click(object sender, EventArgs e)
    {
        try
        {
            them_moi_tang_giam();
            hidden_panel_tang_giam();
            m_ddl_bo_tinh.Focus();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_huy_bo_Click(object sender, EventArgs e)
    {
        try
        {
            clear_panel_data();
            hidden_panel_tang_giam();
            reset_control();
            m_ddl_bo_tinh.Focus();

        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_confirm_Click(object sender, EventArgs e)
    {
        try
        {
            m_mtv_1.SetActiveView(m_view_them_moi_tg);
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
            lua_chon_loai_tang_giam();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_txt_tim_kiem_TextChanged(object sender, EventArgs e)
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
    protected void m_ddl_trang_thai_oto_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void m_ddl_dv_sd_ts_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void m_ddl_loai_xe_SelectedIndexChanged(object sender, EventArgs e)
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
    #endregion
    
}
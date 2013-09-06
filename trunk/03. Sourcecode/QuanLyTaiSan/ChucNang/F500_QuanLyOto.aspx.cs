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

    // Load dữ liệu vào combo trạng thái
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
    private void reset_control()
    {
        m_txt_bien_kiem_soat.Text = "";
        m_txt_chuc_danh_sd_xe.Text = "";
        m_txt_cong_suat_xe.Text = "";
        m_txt_gia_tri_con_lai.Text = "";
        m_txt_hd_khac.Text = "";
        m_txt_kinh_doanh.Text = "";
        m_txt_khong_kinh_doanh.Text = "";
        m_txt_nam_san_xuat.Text = "";
        m_txt_nguon_goc_xe.Text = "";
        m_txt_nguon_khac.Text = "";
        m_txt_nguon_ns.Text = "";
        m_txt_nuoc_san_xuat.Text = "";
        m_txt_qlnn.Text = "";
        m_txt_tai_trong.Text = "";
        m_txt_ten_nhan_hieu.Text = "";
        m_txt_ten_ts.Text = "";
        m_txt_ma_ts.Text = "";
        m_txt_nam_su_dung.Text = "";
        m_txt_tim_kiem.Text = "";
        m_lbl_mess.Text = "";
        m_lbl_thong_bao.Text = "";
    }
    private void form_2_us_object(US_DM_OTO ip_us_oto)
    {
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
        ip_us_oto.dcHD_KHAC = CIPConvert.ToDecimal(m_txt_hd_khac.Text);
        ip_us_oto.dcKHONG_KINH_DOANH = CIPConvert.ToDecimal(m_txt_khong_kinh_doanh.Text);
        ip_us_oto.dcKINH_DOANH = CIPConvert.ToDecimal(m_txt_kinh_doanh.Text);
        ip_us_oto.dcNGUON_KHAC = CIPConvert.ToDecimal(m_txt_nguon_khac.Text);
        ip_us_oto.dcNGUON_NS = CIPConvert.ToDecimal(m_txt_nguon_ns.Text);
        ip_us_oto.dcQLNN = CIPConvert.ToDecimal(m_txt_qlnn.Text);
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
    }

    /// <summary>
    /// Load dữ liệu từ US đổ vào form
    /// </summary>
    /// <param name="ip_dm_noi_dung_thanh_toan"></param>
    private void us_obj_2_form(US_DM_OTO ip_us_oto)
    {
        m_hdf_id.Value = ip_us_oto.dcID.ToString();
        m_txt_tai_trong.Text = ip_us_oto.dcSO_CHO_NGOI.ToString();
        m_txt_ma_ts.Text = ip_us_oto.strMA_TAI_SAN;
        m_txt_nam_su_dung.Text = ip_us_oto.dcNAM_SU_DUNG.ToString();
        m_txt_nam_san_xuat.Text = ip_us_oto.dcNAM_SAN_XUAT.ToString();
        m_txt_gia_tri_con_lai.Text = ip_us_oto.dcGIA_TRI_CON_LAI.ToString("#,##0.##");
        m_txt_ten_nhan_hieu.Text = ip_us_oto.strNHAN_HIEU;
        m_txt_nuoc_san_xuat.Text = ip_us_oto.strNUOC_SAN_XUAT;
        m_txt_bien_kiem_soat.Text = ip_us_oto.strBIEN_KIEM_SOAT;
        m_txt_chuc_danh_sd_xe.Text = ip_us_oto.strCHUC_DANH_SU_DUNG;
        m_txt_nguon_goc_xe.Text = ip_us_oto.strNGUON_GOC_XE;
        m_txt_cong_suat_xe.Text = ip_us_oto.dcCONG_SUAT_XE.ToString();
        m_txt_hd_khac.Text = ip_us_oto.dcHD_KHAC.ToString();
        m_txt_khong_kinh_doanh.Text = ip_us_oto.dcKHONG_KINH_DOANH.ToString();
        m_txt_kinh_doanh.Text = ip_us_oto.dcKINH_DOANH.ToString();
        m_txt_nguon_khac.Text = ip_us_oto.dcNGUON_KHAC.ToString("#,##0.##");
        m_txt_nguon_ns.Text = ip_us_oto.dcNGUON_NS.ToString("#,##0.##");
        m_txt_qlnn.Text = ip_us_oto.dcQLNN.ToString();
        m_txt_ten_ts.Text = ip_us_oto.strTEN_TAI_SAN;
        m_ddl_loai_xe.SelectedValue = ip_us_oto.dcID_LOAI_TAI_SAN.ToString();

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
    }

    private void load_data_to_grid()
    {
        try
        {
            m_lbl_ket_qua_loc_du_lieu.Text = "DANH SÁCH Ô TÔ";
            // Đổ dữ liệu từ US vào DS
            m_us_dm_oto.FillDataset(m_ds_dm_oto);

            // Treo dữ liệu lên lưới
            string v_str_thong_tin = " (Có " + m_ds_dm_oto.DM_OTO.Rows.Count + " bản ghi)";
            m_lbl_ket_qua_loc_du_lieu.Text += v_str_thong_tin;
            m_grv_dm_oto.DataSource = m_ds_dm_oto.DM_OTO;
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
        if (!CValidateTextBox.IsValid(m_txt_ma_ts, DataType.StringType, allowNull.NO))
        {
            m_lbl_mess.Text = "Chưa nhập đúng mã tài sản";
            return false;
        }
        if (!CValidateTextBox.IsValid(m_txt_ten_ts, DataType.StringType, allowNull.NO))
        {
            m_lbl_mess.Text = "Chưa nhập đúng tên tài sản";
            return false;
        }
        if (!CValidateTextBox.IsValid(m_txt_nguon_ns, DataType.NumberType, allowNull.NO))
        {
            m_lbl_mess.Text = "Chưa nhập đúng nguồn ngân sách";
            return false;
        }
        if (!CValidateTextBox.IsValid(m_txt_nguon_khac, DataType.NumberType, allowNull.NO))
        {
            m_lbl_mess.Text = "Chưa nhập đúng nguồn khác";
            return false; 
        }
        if (!CValidateTextBox.IsValid(m_txt_nam_su_dung, DataType.DateType, allowNull.YES))
        {
            m_lbl_mess.Text = "Chưa nhập đúng năm sử dụng";
            return false;
        }
        if (!CValidateTextBox.IsValid(m_txt_nam_san_xuat, DataType.DateType, allowNull.YES))
        {
            m_lbl_mess.Text = "Chưa nhập đúng năm sản xuất";
            return false;
        }
        if (!CValidateTextBox.IsValid(m_txt_gia_tri_con_lai, DataType.NumberType, allowNull.NO))
        {
            m_lbl_mess.Text = "Chưa nhập đúng giá trị còn lại";
            return false;
        }
        if (!CValidateTextBox.IsValid(m_txt_qlnn, DataType.NumberType, allowNull.YES))
        {
            m_lbl_mess.Text = "Chưa nhập đúng quản lý nhà nước";
            return false;
        }
        if (!CValidateTextBox.IsValid(m_txt_kinh_doanh, DataType.NumberType, allowNull.YES))
        {
            m_lbl_mess.Text = "Chưa nhập đúng kinh doanh";
            return false;
        }
        if (!CValidateTextBox.IsValid(m_txt_khong_kinh_doanh, DataType.NumberType, allowNull.YES))
        {
            m_lbl_mess.Text = "Chưa nhập đúng không kinh doanh";
            return false;
        }
        if ((m_txt_nam_su_dung.Text.Trim().Length > 0) & (m_txt_nam_san_xuat.Text.Trim().Length > 0))
        {
            if (CIPConvert.ToDecimal(m_txt_nam_su_dung.Text) < CIPConvert.ToDecimal(m_txt_nam_san_xuat.Text))
            {
                m_lbl_mess.Text = "Năm sử dụng phải lớn hơn hoặc bằng năm sản xuất!";
                return false;
            }
        }
        if ((m_txt_nguon_ns.Text.Trim().Length > 0) & (m_txt_nguon_khac.Text.Trim().Length > 0) & (m_txt_gia_tri_con_lai.Text.Trim().Length > 0))
        {
            if (CIPConvert.ToDecimal(m_txt_nguon_ns.Text) + CIPConvert.ToDecimal(m_txt_nguon_khac.Text) < CIPConvert.ToDecimal(m_txt_gia_tri_con_lai.Text))
            {
                m_lbl_mess.Text = "Nguyên giá (nguồn ngân sách + nguồn khác) phải lớn hơn giá trị còn lại!";
                return false;
            }
        }

        /*if (m_init_mode == DataEntryFormMode.UpdateDataState)
        {
            m_us_dm_oto = new US_DM_OTO(CIPConvert.ToDecimal(m_hdf_id.Value));
            if (m_us_dm_oto.strMA_TAI_SAN != m_txt_ma_ts.Text)
            {
                if (!m_us_dm_oto.check_ma_valid(m_txt_ma_ts.Text))
                {
                    m_lbl_mess.Text = "Không thể cập nhật. Lỗi: Mã tài sản này đã tồn tại";
                    return false;
                }
            }
        }
        if (m_init_mode == DataEntryFormMode.InsertDataState)
        {
            if (!m_us_dm_oto.check_ma_valid(m_txt_ma_ts.Text.Trim()))
            {
                m_lbl_mess.Text = "Mã tài sản này đã tồn tại";
                return false;
            };
        }*/
        return true;
    }

    private void insert_data()
    {
        if (m_init_mode == DataEntryFormMode.UpdateDataState) return;
        if (!check_validate_data_is_ok()) return;
        form_2_us_object(m_us_dm_oto);
        m_us_dm_oto.Insert();
        
        reset_control();
        load_data_to_grid();
        m_lbl_mess.Text = "Thêm bản ghi thành công!";
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
            }
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
            m_init_mode = DataEntryFormMode.UpdateDataState;
            update_data();
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
            export_to_excel();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }


    #endregion
 
}
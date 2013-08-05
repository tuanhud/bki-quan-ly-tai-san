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

public partial class ChucNang_F100_QuanLyNha : System.Web.UI.Page
{
    #region Members
    private US_DM_NHA m_us_dm_nha = new US_DM_NHA();
    #endregion

    #region Private Methods
    // Load dữ liệu vào form
    private void load_form_data()
    {
        load_data_bo_tinh();
        load_data_don_vi_chu_quan("");
        load_data_don_vi_su_dung("", "");
        load_data_dat("");
        load_data_trang_thai();
        load_data_don_vi_dau_tu();
        load_data_to_grid(m_txt_tu_khoa.Text);
        m_txt_ten_tai_san.Focus();
    }

    // Load dữ liệu vào grid
    private void load_data_to_grid(string ip_tu_khoa)
    {
        DS_DM_NHA v_ds_dm_nha = new DS_DM_NHA();

        if (ip_tu_khoa.Equals(String.Empty))
        {
            m_us_dm_nha.FillDataset(v_ds_dm_nha);
        }
        else
        {
            string v_str_query = "where TEN_TAI_SAN LIKE %" + ip_tu_khoa + "% OR MA_TAI_SAN LIKE %" + ip_tu_khoa + "%";
            m_us_dm_nha.FillDataset(v_ds_dm_nha, v_str_query);
        }
        m_grv_danh_sach_nha.DataSource = v_ds_dm_nha.DM_NHA;
        m_grv_danh_sach_nha.DataBind();
    }

    // Load dữ liệu vào combo bộ tỉnh
    private void load_data_bo_tinh()
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = " + ID_LOAI_DON_VI.BO_TINH);
        m_ddl_bo_tinh.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_ddl_bo_tinh.DataTextField = "TEN_DON_VI";
        m_ddl_bo_tinh.DataValueField = "ID";
        m_ddl_bo_tinh.DataBind();
    }

    // Load dữ liệu vào combo đơn vị chủ quản
    private void load_data_don_vi_chu_quan(string ip_str_id_bo_tinh)
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        if (ip_str_id_bo_tinh.Equals(String.Empty))
        {
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = " + ID_LOAI_DON_VI.DV_CHU_QUAN);
        }
        else
        {
            decimal v_dc_id_bo_tinh = CIPConvert.ToDecimal(ip_str_id_bo_tinh);
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = " + ID_LOAI_DON_VI.DV_CHU_QUAN
            + " AND ID_DON_VI_CAP_TREN = " + v_dc_id_bo_tinh);
        }

        m_ddl_don_vi_chu_quan.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_ddl_don_vi_chu_quan.DataTextField = "TEN_DON_VI";
        m_ddl_don_vi_chu_quan.DataValueField = "ID";
        m_ddl_don_vi_chu_quan.DataBind();
        //m_ddl_don_vi_chu_quan.Items.Insert(0, new ListItem("Tất cả các đơn vị", ""));
    }

    // Load dữ liệu vào combo đơn vị sử dụng
    private void load_data_don_vi_su_dung(string ip_str_id_don_vi_chu_quan, string ip_str_id_bo_tinh)
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        if (ip_str_id_bo_tinh.Equals(String.Empty))
        {
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "WHERE ID_LOAI_DON_VI IN (" + ID_LOAI_DON_VI.DV_SU_DUNG + "," + ID_LOAI_DON_VI.DV_CHU_QUAN + ")");
        }
        else if (ip_str_id_don_vi_chu_quan.Equals(String.Empty))
        {
            decimal v_dc_id_bo_tinh = CIPConvert.ToDecimal(ip_str_id_bo_tinh);
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_DON_VI_CAP_TREN in (select ID from DM_DON_VI where ID_DON_VI_CAP_TREN = "
                + v_dc_id_bo_tinh + ") or ID_DON_VI_CAP_TREN = " + v_dc_id_bo_tinh);
        }
        else
        {
            decimal v_dc_id_don_vi_chu_quan = CIPConvert.ToDecimal(ip_str_id_don_vi_chu_quan);
            v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_DON_VI_CAP_TREN = " + v_dc_id_don_vi_chu_quan + " or ID = " + v_dc_id_don_vi_chu_quan);
        }

        m_ddl_don_vi_su_dung.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_ddl_don_vi_su_dung.DataTextField = "TEN_DON_VI";
        m_ddl_don_vi_su_dung.DataValueField = "ID";
        m_ddl_don_vi_su_dung.DataBind();
        //m_ddl_don_vi_su_dung.Items.Insert(0, new ListItem("Tất cả các đơn vị", ""));
    }

    // Load dữ liệu vào combo đơn vị đầu tư
    private void load_data_don_vi_dau_tu()
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi);
        m_ddl_don_vi_dau_tu.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_ddl_don_vi_dau_tu.DataTextField = "TEN_DON_VI";
        m_ddl_don_vi_dau_tu.DataValueField = "ID";
        m_ddl_don_vi_dau_tu.DataBind();
    }

    // Load dữ liệu vào đất
    private void load_data_dat(string ip_str_don_vi_su_dung)
    {
        DS_DM_DAT v_ds_dm_dat = new DS_DM_DAT();
        US_DM_DAT vs_us_dm_dat = new US_DM_DAT();

        vs_us_dm_dat.FillDataset(v_ds_dm_dat, "where ID_DON_VI_SU_DUNG LIKE '%" + ip_str_don_vi_su_dung + "%'");
        m_ddl_thuoc_khu_dat.DataSource = v_ds_dm_dat.DM_DAT;
        m_ddl_thuoc_khu_dat.DataTextField = "DIA_CHI";
        m_ddl_thuoc_khu_dat.DataValueField = "ID";
        m_ddl_thuoc_khu_dat.DataBind();
    }

    // Load dữ liệu vào combo trạng thái
    private void load_data_trang_thai()
    {
        DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();

        v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds("TRANG_THAI_NHA", v_ds_cm_dm_tu_dien);
        m_ddl_trang_thai_nha.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
        m_ddl_trang_thai_nha.DataTextField = "TEN";
        m_ddl_trang_thai_nha.DataValueField = "ID";
        m_ddl_trang_thai_nha.DataBind();
    }

    private void load_data_to_us_by_id(decimal ip_dc_id_nha)
    {
        m_us_dm_nha = new US_DM_NHA(ip_dc_id_nha);
        load_data_from_us();
    }

    private void load_data_from_us()
    {
        try
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
            m_txt_nguyen_gia.Text = m_us_dm_nha.dcNGUON_NS.ToString();
            m_txt_nguyen_gia_nguon_khac.Text = m_us_dm_nha.dcNGUON_KHAC.ToString();
            m_txt_gia_tri_con_lai.Text = m_us_dm_nha.dcGIA_TRI_CON_LAI.ToString();
            m_txt_so_tang.Text = m_us_dm_nha.dcSO_TANG.ToString();
            m_txt_dien_tich_xay_dung.Text = m_us_dm_nha.dcDT_XAY_DUNG.ToString();
            m_txt_tong_dien_tich_xay_dung.Text = m_us_dm_nha.dcTONG_DT_SAN_XD.ToString();
            m_txt_tru_so_lam_viec.Text = m_us_dm_nha.dcTRU_SO_LAM_VIEC.ToString();
            m_txt_co_so_hdsn.Text = m_us_dm_nha.dcCO_SO_HDSN.ToString();
            m_txt_lam_nha_o.Text = m_us_dm_nha.dcLAM_NHA_O.ToString();
            m_txt_cho_thue.Text = m_us_dm_nha.dcCHO_THUE.ToString();
            m_txt_bo_trong.Text = m_us_dm_nha.dcBO_TRONG.ToString();
            m_txt_bi_lan_chiem.Text = m_us_dm_nha.dcBI_LAN_CHIEM.ToString();
            m_txt_khac.Text = m_us_dm_nha.dcKHAC.ToString();
            m_ddl_trang_thai_nha.SelectedValue = m_us_dm_nha.dcID_TRANG_THAI.ToString();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    private void fill_form_data_to_us()
    {
        try
        {
            if (!m_hdf_id.Value.Equals(String.Empty))
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
            m_us_dm_nha.dcID_DON_VI_SU_DUNG = CIPConvert.ToDecimal(m_ddl_don_vi_su_dung.SelectedValue);
            US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI(m_us_dm_nha.dcID_DON_VI_SU_DUNG);
            m_us_dm_nha.dcID_DON_VI_CHU_QUAN = v_us_dm_don_vi.dcID_DON_VI_CAP_TREN;
            m_us_dm_nha.dcID_DON_VI_DAU_TU = CIPConvert.ToDecimal(m_ddl_don_vi_dau_tu.SelectedValue);
            m_us_dm_nha.datNGAY_CAP_NHAT_CUOI = DateTime.Now;
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    private void clear_form_data()
    {
        m_hdf_id.Value = "";
        m_txt_ten_tai_san.Text = "";
        m_txt_cap_hang.Text = "";
        m_txt_nam_xd.Text = "";
        m_txt_ngay_su_dung.Text = "";
        m_txt_nguyen_gia.Text = "";
        m_txt_nguyen_gia_nguon_khac.Text = "";
        m_txt_gia_tri_con_lai.Text = "";
        m_txt_so_tang.Text = "";
        m_txt_dien_tich_xay_dung.Text = "";
        m_txt_tong_dien_tich_xay_dung.Text = "";
        m_txt_tru_so_lam_viec.Text = "";
        m_txt_co_so_hdsn.Text = "";
        m_txt_lam_nha_o.Text = "";
        m_txt_cho_thue.Text = "";
        m_txt_bo_trong.Text = "";
        m_txt_bi_lan_chiem.Text = "";
        m_txt_khac.Text = "";
        m_txt_ma_tai_san.Text = "";
    }

    private void edit_grv_nha(decimal ip_us_dm_nha_id)
    {
        load_data_to_us_by_id(ip_us_dm_nha_id);
    }

    #endregion

    #region Public Interfaces
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_form_data();
        }
    }

    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        if (m_hdf_id.Value == "")
        {
            fill_form_data_to_us();
            m_us_dm_nha.Insert();
        }
        else
        {
        }

    }

    protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
    {
        if (m_hdf_id.Value != "")
        {
            fill_form_data_to_us();
            m_us_dm_nha.Update();
        }
        else
        {

        }
    }

    protected void m_cmd_xoa_trang_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ChucNang/F100_QuanLyNha.aspx");
    }

    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        load_form_data();
    }

    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        // TODO
    }

    protected void m_grv_danh_sach_nha_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (!e.CommandName.Equals(String.Empty))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                decimal v_ud_dm_nha_id = CIPConvert.ToDecimal(m_grv_danh_sach_nha.DataKeys[rowIndex].Value);

                switch (e.CommandName)
                {
                    case "EditComp":
                        load_data_to_us_by_id(v_ud_dm_nha_id);
                        load_form_data();
                        load_data_from_us();
                        break;
                    case "DeleteComp":
                        m_us_dm_nha.DeleteByID(v_ud_dm_nha_id);
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
        m_grv_danh_sach_nha.PageIndex = e.NewPageIndex;
    }

    protected void m_ddl_don_vi_chu_quan_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_data_don_vi_su_dung(m_ddl_don_vi_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
        load_data_dat(m_ddl_don_vi_su_dung.SelectedValue);
    }

    protected void m_ddl_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_data_don_vi_chu_quan(m_ddl_bo_tinh.SelectedValue);
        load_data_don_vi_su_dung(m_ddl_don_vi_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
    }

    protected void m_ddl_don_vi_su_dung_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_data_dat(m_ddl_don_vi_su_dung.SelectedValue);
    }
    #endregion
}
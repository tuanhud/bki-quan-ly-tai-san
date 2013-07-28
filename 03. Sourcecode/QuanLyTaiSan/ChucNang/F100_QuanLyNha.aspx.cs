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
        load_data_don_vi_chu_quan();
        load_data_don_vi_su_dung();
        load_data_to_grid(m_txt_tu_khoa.Text);
        
    }

    // Load dữ liệu vào grid
    private void load_data_to_grid(string ip_tu_khoa)
    {
        //if (!ip_tu_khoa.Equals(String.Empty))
        //{
        //    m_us_dm_nha.FillDataset(v_ds_dm_nha);
        //}

        DS_DM_NHA v_ds_dm_nha = new DS_DM_NHA();

        m_us_dm_nha.FillDataset(v_ds_dm_nha);
        m_grv_danh_sach_nha.DataSource = v_ds_dm_nha.DM_NHA;
        m_grv_danh_sach_nha.DataBind();
    }

    // Load dữ liệu danh sách bộ tỉnh
    private void load_data_bo_tinh()
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = 574");
        m_ddl_bo_tinh.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_ddl_bo_tinh.DataTextField = "TEN_DON_VI";
        m_ddl_bo_tinh.DataValueField = "ID";
        m_ddl_bo_tinh.DataBind();
    }

    private void load_data_don_vi_chu_quan()
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        string v_id_bo_tinh = m_ddl_bo_tinh.SelectedValue;
        v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = 575 and ID_DON_VI_CAP_TREN LIKE '%"
            + v_id_bo_tinh + "%'");
        m_ddl_don_vi_chu_quan.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_ddl_don_vi_chu_quan.DataTextField = "TEN_DON_VI";
        m_ddl_don_vi_chu_quan.DataValueField = "ID";
        m_ddl_don_vi_chu_quan.DataBind();
        m_ddl_don_vi_chu_quan.Items.Insert(0, new ListItem("Tất cả đơn vị trực thuộc", ""));
    }

    private void load_data_don_vi_su_dung()
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        string v_id_don_vi_chu_quan = m_ddl_don_vi_chu_quan.SelectedValue;
        v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = 576 and ID_DON_VI_CAP_TREN LIKE '%" + v_id_don_vi_chu_quan
            + "%'");
        m_ddl_don_vi_su_dung.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_ddl_don_vi_su_dung.DataTextField = "TEN_DON_VI";
        m_ddl_don_vi_su_dung.DataValueField = "ID";
        m_ddl_don_vi_su_dung.DataBind();
    }

    private void load_data_dat()
    {
        DS_DM_DAT v_ds_dm_dat = new DS_DM_DAT();
        US_DM_DAT vs_us_dm_dat = new US_DM_DAT();

        string v_id_don_vi_su_dung = m_ddl_don_vi_su_dung.SelectedValue;
        vs_us_dm_dat.FillDataset(v_ds_dm_dat, "where ID_DON_VI_SU_DUNG LIKE '%" + v_id_don_vi_su_dung + "%'");
        m_ddl_thuoc_khu_dat.DataSource = v_ds_dm_dat.DM_DAT;
        m_ddl_thuoc_khu_dat.DataTextField = "DIA_CHI";
        m_ddl_thuoc_khu_dat.DataValueField = "ID";
        m_ddl_thuoc_khu_dat.DataBind();
    }

    private void load_data_trang_thai()
    {

    }

    private void load_data_to_us_by_id(decimal ip_us_nha_id)
    {
        m_us_dm_nha = new US_DM_NHA(ip_us_nha_id);
        load_data_from_us();
    }

    private void load_data_from_us()
    {
        m_hdf_id.Value = m_us_dm_nha.dcID.ToString();
        m_txt_ten_tai_san.Text = m_us_dm_nha.strTEN_TAI_SAN;
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

    private void fill_form_data_to_us()
    {
        
    }

    private void clear_form_data()
    {

    }

    private void edit_grv_nha(decimal ip_us_dm_nha_id)
    {

    }

    private void delete_nha(decimal ip_us_dm_nha_id)
    {

    }

    #endregion

    #region Public Interfaces
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_form_data();
        }
    }

    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {

    }
    protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
    {

    }
    protected void m_cmd_xoa_trang_Click(object sender, EventArgs e)
    {

    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {

    }
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {

    }

    protected void m_grv_danh_sach_nha_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (!e.CommandName.Equals(String.Empty))
        {
            decimal v_ud_dm_nha_id = Convert.ToDecimal(e.CommandArgument.ToString());

            switch (e.CommandName)
            {
                case "Edit":
                    m_hdf_id.Value = v_ud_dm_nha_id.ToString();
                    break;
                case "Delete":
                    break;
            }
        }
    }

    protected void m_grv_danh_sach_nha_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        m_grv_danh_sach_nha.PageIndex = e.NewPageIndex;
    }

    protected void m_ddl_don_vi_chu_quan_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_data_don_vi_su_dung();
    }

    protected void m_ddl_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_data_don_vi_chu_quan();
    }
}
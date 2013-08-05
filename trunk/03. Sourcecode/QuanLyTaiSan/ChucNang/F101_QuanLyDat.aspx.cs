using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPUserService;
using WebDS;
using WebUS;
using IP.Core.IPData;
using WebDS.CDBNames;

public partial class ChucNang_F101_QuanLyDat : System.Web.UI.Page
{
    #region Members
    private US_DM_DAT m_us_dm_dat = new US_DM_DAT();
    #endregion

    #region Public Interfaces
    #endregion

    #region Private Methods
    private void load_form_data()
    {
        load_data_bo_tinh();
        load_data_don_vi_chu_quan(m_ddl_bo_tinh.SelectedValue);
        load_data_don_vi_su_dung(m_ddl_don_vi_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
        load_data_trang_thai();
        load_data_grid(m_txt_tu_khoa.Text);
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

        if (m_us_dm_dat.dcID_DON_VI_CHU_QUAN != 0)
        {
            v_us_dm_don_vi = new US_DM_DON_VI(m_us_dm_dat.dcID_DON_VI_CHU_QUAN);
            m_ddl_bo_tinh.SelectedValue = v_us_dm_don_vi.dcID_DON_VI_CAP_TREN.ToString();
        }
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
        if (m_us_dm_dat.dcID_DON_VI_CHU_QUAN != 0)
        {
            m_ddl_don_vi_chu_quan.SelectedValue = m_us_dm_dat.dcID_DON_VI_CHU_QUAN.ToString();
        }
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
        if (m_us_dm_dat.dcID_DON_VI_SU_DUNG != 0)
        {
            m_ddl_don_vi_su_dung.SelectedValue = m_us_dm_dat.dcID_DON_VI_SU_DUNG.ToString();
        }
    }

    // Load dữ liệu vào combo trạng thái
    private void load_data_trang_thai()
    {
        DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();

        v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_DAT,CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);
        m_ddl_trang_thai.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
        m_ddl_trang_thai.DataTextField = "TEN";
        m_ddl_trang_thai.DataValueField = "ID";
        m_ddl_trang_thai.DataBind();
    }

    private void load_data_grid(string ip_str_tu_khoa)
    {
        DS_DM_DAT v_ds_dm_dat = new DS_DM_DAT();

        if (ip_str_tu_khoa.Equals(String.Empty))
        {
            m_us_dm_dat.FillDataset(v_ds_dm_dat);
        }
        else
        {
            CStoredProc v_cstore = new CStoredProc("pr_DM_DAT_Search");
            v_cstore.addNVarcharInputParam("@TU_KHOA", m_txt_tu_khoa.Text);
            v_cstore.fillDataSetByCommand(m_us_dm_dat, v_ds_dm_dat);
        }
        m_grv_danh_sach_nha.DataSource = v_ds_dm_dat.DM_DAT;
        m_grv_danh_sach_nha.DataBind();
    }

    private void load_data_from_us()
    {
        try
        {
            m_hdf_id.Value = m_us_dm_dat.dcID.ToString();
            m_ddl_don_vi_chu_quan.SelectedValue = m_us_dm_dat.dcID_DON_VI_CHU_QUAN.ToString();
            m_ddl_don_vi_su_dung.SelectedValue = m_us_dm_dat.dcID_DON_VI_SU_DUNG.ToString();
            m_ddl_trang_thai.SelectedValue = m_us_dm_dat.dcID_TRANG_THAI.ToString();
            m_txt_dia_chi.Text = m_us_dm_dat.strDIA_CHI;
            m_txt_ma_tai_san.Text = m_us_dm_dat.strMA_TAI_SAN;
            m_txt_nam_xd.Text = m_us_dm_dat.dcSO_NAM_DA_SU_DUNG.ToString();
            m_txt_nguyen_gia.Text = m_us_dm_dat.dcGT_THEO_SO_KE_TOAN.ToString("#,##0.00");
            m_txt_dien_tich_khuon_vien.Text = m_us_dm_dat.dcDT_KHUON_VIEN.ToString("#,##0.00");
            m_txt_tru_so_lam_viec.Text = m_us_dm_dat.dcDT_TRU_SO_LAM_VIEC.ToString("#,##0.00");
            m_txt_lam_nha_o.Text = m_us_dm_dat.dcDT_LAM_NHA_O.ToString("#,##0.00");
            m_txt_co_so_hdsn.Text = m_us_dm_dat.dcDT_CO_SO_HOAT_DONG_SU_NGHIEP.ToString("#,##0.00");
            m_txt_cho_thue.Text = m_us_dm_dat.dcDT_CHO_THUE.ToString("#,##0.00");
            m_txt_bo_trong.Text = m_us_dm_dat.dcDT_BO_TRONG.ToString("#,##0.00");
            m_txt_bi_lan_chiem.Text = m_us_dm_dat.dcDT_BI_LAN_CHIEM.ToString("#,##0.00");
            m_txt_khac.Text = m_us_dm_dat.dcDT_SU_DUNG_MUC_DICH_KHAC.ToString("#,##0.00");
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    private void fill_form_data_to_us()
    {
        if (!m_hdf_id.Value.Equals(String.Empty))
        {
            m_us_dm_dat.dcID = CIPConvert.ToDecimal(m_hdf_id.Value);
        }
        m_us_dm_dat.dcID_DON_VI_CHU_QUAN = CIPConvert.ToDecimal(m_ddl_don_vi_chu_quan.SelectedValue);
        m_us_dm_dat.dcID_DON_VI_SU_DUNG = CIPConvert.ToDecimal(m_ddl_don_vi_su_dung.SelectedValue);
        m_us_dm_dat.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_ddl_trang_thai.SelectedValue);
        m_us_dm_dat.strDIA_CHI = m_txt_dia_chi.Text;
        m_us_dm_dat.strMA_TAI_SAN = m_txt_ma_tai_san.Text;
        m_us_dm_dat.dcSO_NAM_DA_SU_DUNG = CIPConvert.ToDecimal(m_txt_nam_xd.Text);
        m_us_dm_dat.dcGT_THEO_SO_KE_TOAN = CIPConvert.ToDecimal(m_txt_nguyen_gia.Text);
        m_us_dm_dat.dcDT_KHUON_VIEN = CIPConvert.ToDecimal(m_txt_dien_tich_khuon_vien.Text);
        m_us_dm_dat.dcDT_TRU_SO_LAM_VIEC = CIPConvert.ToDecimal(m_txt_tru_so_lam_viec.Text);
        m_us_dm_dat.dcDT_LAM_NHA_O = CIPConvert.ToDecimal(m_txt_lam_nha_o.Text);
        m_us_dm_dat.dcDT_CO_SO_HOAT_DONG_SU_NGHIEP = CIPConvert.ToDecimal(m_txt_co_so_hdsn.Text);
        m_us_dm_dat.dcDT_CHO_THUE = CIPConvert.ToDecimal(m_txt_cho_thue.Text);
        m_us_dm_dat.dcDT_BO_TRONG = CIPConvert.ToDecimal(m_txt_bo_trong.Text);
        m_us_dm_dat.dcDT_BI_LAN_CHIEM = CIPConvert.ToDecimal(m_txt_bi_lan_chiem.Text);
        m_us_dm_dat.dcDT_SU_DUNG_MUC_DICH_KHAC = CIPConvert.ToDecimal(m_txt_khac.Text);
    }

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
            m_us_dm_dat.Insert();
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
            m_us_dm_dat.Update();
        }
        else
        {

        }
    }
    protected void m_cmd_xoa_trang_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ChucNang/F101_QuanLyDat.aspx");
    }

    protected void m_ddl_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_data_don_vi_chu_quan(m_ddl_bo_tinh.SelectedValue);
        load_data_don_vi_su_dung(m_ddl_don_vi_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
    }
    protected void m_ddl_don_vi_chu_quan_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_data_don_vi_su_dung(m_ddl_don_vi_chu_quan.SelectedValue, m_ddl_bo_tinh.SelectedValue);
    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        load_form_data();
    }
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {

    }
    #endregion

    protected void m_grv_danh_sach_nha_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        m_grv_danh_sach_nha.PageIndex = e.NewPageIndex;
        load_form_data();
    }
    protected void m_grv_danh_sach_nha_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (!e.CommandName.Equals(String.Empty))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                decimal v_dc_id_dat = CIPConvert.ToDecimal(m_grv_danh_sach_nha.DataKeys[rowIndex].Value);

                switch (e.CommandName)
                {
                    case "EditComp":
                        m_us_dm_dat = new US_DM_DAT(v_dc_id_dat);
                        load_form_data();
                        load_data_from_us();
                        break;
                    case "DeleteComp":
                        m_us_dm_dat.DeleteByID(v_dc_id_dat);
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
}
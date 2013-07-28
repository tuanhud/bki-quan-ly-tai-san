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
    private DS_DM_NHA m_ds_dm_nha = new DS_DM_NHA();
    private DS_DM_DAT m_ds_dm_dat = new DS_DM_DAT();
    private DS_DM_DON_VI m_ds_dm_bo_tinh = new DS_DM_DON_VI();
    private DS_DM_DON_VI m_ds_dm_don_vi_chu_quan = new DS_DM_DON_VI();
    private DS_DM_DON_VI m_ds_dm_don_vi_su_dung = new DS_DM_DON_VI();
    private US_DM_DAT m_us_dm_dat = new US_DM_DAT();
    private US_DM_DON_VI m_us_dm_don_vi = new US_DM_DON_VI();
    private US_DM_NHA m_us_dm_nha = new US_DM_NHA();
    #endregion

    #region Private Methods
    private void load_form_data()
    {

    }
    private void load_data_to_grid()
    {
        m_us_dm_nha.FillDataset(m_ds_dm_nha, "where ID_DON_VI_SU_DUNG ");
    }

    private void load_data_bo_tinh()
    {
        m_us_dm_don_vi.FillDataset(m_ds_dm_bo_tinh, "where ID_LOAI_DON_VI = 574");
        m_ddl_bo_tinh.DataSource = m_ds_dm_bo_tinh.DM_DON_VI;
        m_ddl_bo_tinh.DataTextField = "TEN_DON_VI";
        m_ddl_bo_tinh.DataValueField = "ID";
        m_ddl_bo_tinh.Items.Insert(0, new ListItem("Tất cả đơn vị trực thuộc", ""));
        m_ddl_bo_tinh.DataBind();
    }

    private void load_data_don_vi_chu_quan()
    {
        string v_id_bo_tinh = m_ddl_bo_tinh.SelectedValue;

        m_us_dm_don_vi.FillDataset(m_ds_dm_don_vi_chu_quan, "where ID_LOAI_DON_VI = 575 and ID_DON_VI_CAP_TREN LIKE '%"
            + v_id_bo_tinh + "%'");
        m_ddl_don_vi_chu_quan.DataSource = m_ds_dm_don_vi_chu_quan.DM_DON_VI;
        m_ddl_don_vi_chu_quan.DataTextField = "TEN_DON_VI";
        m_ddl_don_vi_chu_quan.DataValueField = "ID";
        m_ddl_don_vi_chu_quan.Items.Insert(0, new ListItem("Tất cả đơn vị trực thuộc", ""));
        m_ddl_don_vi_chu_quan.DataBind();
    }

    private void load_data_don_vi_su_dung()
    {
        string v_id_don_vi_chu_quan = m_ddl_don_vi_chu_quan.SelectedValue;
        m_us_dm_don_vi.FillDataset(m_ds_dm_don_vi_su_dung, "where ID_LOAI_DON_VI = 575 ID_DON_VI_CAP_TREN LIKE '%" + v_id_don_vi_chu_quan
            + "%'");
        m_ddl_don_vi_su_dung.DataSource = m_ds_dm_don_vi_chu_quan.DM_DON_VI;
        m_ddl_don_vi_su_dung.DataTextField = "TEN_DON_VI";
        m_ddl_don_vi_su_dung.DataValueField = "ID";
        m_ddl_don_vi_su_dung.Items.Insert(0, new ListItem("Tất cả", ""));
        m_ddl_don_vi_su_dung.DataBind();
    }

    private void fill_data_to_us()
    {

    }
    #endregion

    #region Public Interfaces
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

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
}
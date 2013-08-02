using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using IP.Core.IPData;
using WebDS;
using WebUS;
using WebUS;
using WebDS.CDBNames;


public partial class ChucNang_F301_DanhMucTruSoLamViecCoSoHoatDongSuNghiepDeNghiXuLy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                load_data_to_cbo_bo_tinh();
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }

    #region Member
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    US_CM_DM_TU_DIEN m_us_dm_dm_tu_dien = new US_CM_DM_TU_DIEN();

    DS_DM_DON_VI m_ds_dm_don_vi = new DS_DM_DON_VI();
    US_DM_DON_VI m_us_dm_don_vi = new US_DM_DON_VI();

    DS_DM_NHA m_ds_dm_nha = new DS_DM_NHA();
    US_DM_NHA m_us_dm_nha = new US_DM_NHA();

    DS_DM_DAT m_ds_dm_dat = new DS_DM_DAT();
    US_DM_DAT m_us_dm_dat = new US_DM_DAT();



    #endregion

    #region private methods
    private void load_data_to_cbo_bo_tinh()
    {
        try
        {
            m_us_dm_don_vi.FillDataset(m_ds_dm_don_vi, "Where id_loai_don_vi=574");
            m_cbo_bo_tinh.DataSource = m_ds_dm_don_vi.DM_DON_VI;
            m_cbo_bo_tinh.DataValueField = CIPConvert.ToStr(DM_DON_VI.ID);
            m_cbo_bo_tinh.DataTextField = CIPConvert.ToStr(DM_DON_VI.TEN_DON_VI);
            m_cbo_bo_tinh.DataBind();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }

    private void load_data_to_cbo_don_vi_chu_quan()
    {
        string v_id_bo_tinh = m_cbo_bo_tinh.SelectedValue;
        m_us_dm_don_vi.FillDataset(m_ds_dm_don_vi, "where ID_LOAI_DON_VI = 575 and ID_DON_VI_CAP_TREN LIKE '%"
            + v_id_bo_tinh + "%'");
        m_cbo_don_vi_chu_quan.DataSource = m_ds_dm_don_vi.DM_DON_VI;
        m_cbo_don_vi_chu_quan.DataTextField = "TEN_DON_VI";
        m_cbo_don_vi_chu_quan.DataValueField = "ID";
        m_cbo_don_vi_chu_quan.DataBind();
        m_cbo_don_vi_chu_quan.Items.Insert(0, new ListItem("Tất cả đơn vị trực thuộc", ""));
    }
    private void load_data_to_cbo_don_vi_su_dung()
    {
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

        string v_id_don_vi_chu_quan = m_cbo_don_vi_chu_quan.SelectedValue;
        v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = 576 and ID_DON_VI_CAP_TREN LIKE '%" + v_id_don_vi_chu_quan
            + "%'");
        m_cbo_don_vi_su_dung_tai_san.DataSource = v_ds_dm_don_vi.DM_DON_VI;
        m_cbo_don_vi_su_dung_tai_san.DataTextField = "TEN_DON_VI";
        m_cbo_don_vi_su_dung_tai_san.DataValueField = "ID";
        m_cbo_don_vi_su_dung_tai_san.DataBind();
    }

    private void load_data_to_cbo_dia_chi()
    {
        try
        {
            string v_id_don_vi_chu_quan = m_cbo_don_vi_chu_quan.SelectedValue;
            string v_id_don_vi_su_dung = m_cbo_don_vi_su_dung_tai_san.SelectedValue;
            m_us_dm_dat.FillDataset(m_ds_dm_dat, "where ID_DON_VI_CHU_QUAN = " + v_id_don_vi_chu_quan
            + " and id_don_vi_su_dung = " + v_id_don_vi_su_dung);
            m_cbo_dia_chi.DataSource = m_ds_dm_dat.DM_DAT;
            m_cbo_dia_chi.DataValueField = DM_DAT.ID;
            m_cbo_dia_chi.DataTextField = DM_DAT.DIA_CHI;
            m_cbo_dia_chi.DataBind();
            //m_cbo_dia_chi.DataTextField=DM_NHA.d

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }

    private void load_data_to_thong_tin_nha_dat()
    {

        try
        {

            string v_id_dat = m_cbo_dia_chi.SelectedValue;
            DS_DM_DAT v_ds_dm_dat= new DS_DM_DAT();
            US_DM_DAT v_us_dm_dat = new US_DM_DAT(CIPConvert.ToDecimal(v_id_dat));
            m_lbl_dia_chi.Text = v_us_dm_dat.strDIA_CHI;
            if(v_us_dm_dat.dcDT_KHUON_VIEN!=0)
            {
                m_lbl_dien_tich_khuon_vien_dat.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_KHUON_VIEN) + "   ";
            }
            else 
            {
            m_lbl_dien_tich_khuon_vien_dat.Text ="0  ";
            }
            if(v_us_dm_dat.dcDT_TRU_SO_LAM_VIEC!=0)
            {
                m_lbl_lam_tru_so_lam_viec.Text=CIPConvert.ToStr(v_us_dm_dat.dcDT_TRU_SO_LAM_VIEC);
            }
            else
            {
                m_lbl_lam_tru_so_lam_viec.Text = "0  ";
            }

            if (v_us_dm_dat.dcDT_TRU_SO_LAM_VIEC != 0)
            {
                m_lbl_lam_tru_so_lam_viec.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_TRU_SO_LAM_VIEC);
            }
            else
            {
                m_lbl_lam_tru_so_lam_viec.Text = "0  ";
            }

            if (v_us_dm_dat.dcDT_CO_SO_HOAT_DONG_SU_NGHIEP != 0)
            {
                m_lbl_lam_co_so_hd_du_nghiep.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_CO_SO_HOAT_DONG_SU_NGHIEP);
            }
            else
            {
                m_lbl_lam_co_so_hd_du_nghiep.Text = "0  ";
            }

            if (v_us_dm_dat.dcDT_LAM_NHA_O != 0)
            {
                m_lbl_lam_nha_o.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_LAM_NHA_O);
            }
            else
            {
                m_lbl_lam_nha_o.Text = "0  ";
            }

            if (v_us_dm_dat.dcDT_CHO_THUE != 0)
            {
                m_lbl_cho_thue.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_CHO_THUE);
            }
            else
            {
                m_lbl_cho_thue.Text = "0  ";
            }

            if (v_us_dm_dat.dcDT_BO_TRONG!= 0)
            {
                m_lbl_bo_trong.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_BO_TRONG);
            }
            else
            {
                m_lbl_bo_trong.Text = "0  ";
            }

            if (v_us_dm_dat.dcDT_BI_LAN_CHIEM != 0)
            {
                m_lbl_bi_lan_chiem.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_BI_LAN_CHIEM);
            }
            else
            {
                m_lbl_bi_lan_chiem.Text = "0  ";
            }

            if (v_us_dm_dat.dcDT_SU_DUNG_MUC_DICH_KHAC != 0)
            {
                m_lbl_su_dung_vao_muc_dich_khac.Text = CIPConvert.ToStr(v_us_dm_dat.dcDT_SU_DUNG_MUC_DICH_KHAC);
            }
            else
            {
                m_lbl_su_dung_vao_muc_dich_khac.Text = "0  ";
            }

            if (v_us_dm_dat.dcGT_THEO_SO_KE_TOAN != 0)
            {
                m_lbl_gia_tri_theo_so_ke_toan.Text = CIPConvert.ToStr(v_us_dm_dat.dcGT_THEO_SO_KE_TOAN);
            }
            else
            {
                m_lbl_gia_tri_theo_so_ke_toan.Text = "0  ";
            }

            

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    private void load_data_to_grid_nha()
    {
        try
        {
            string v_id_dat =m_cbo_dia_chi.SelectedValue;
            string id_loai_bao_cao ="";
            if (Request.QueryString["id_loai_bao_cao"] != null)
            {
                id_loai_bao_cao = Request.QueryString["id_loai_bao_cao"];
            }

            switch (id_loai_bao_cao)
            {
                case "1":
                    m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỐNG SỰ NGHIỆP";
                    m_us_dm_nha.FillDataset(m_ds_dm_nha,"where id_dat = "+v_id_dat);
                    break;
                case "2":
                    m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỐNG SỰ NGHIỆP ĐỀ NGHỊ XỬ LÝ";
                    m_us_dm_nha.FillDataset(m_ds_dm_nha, "where id_dat = " + v_id_dat + " and id_trang_thai = " + ID_TRANG_THAI_NHA.DE_NGHI_XU_LY);
                    break;
                //case "3":
                //    m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, TRỤ SỞ HOẠT ĐỘNG GIAO CHO ĐƠN VỊ SỰ NGHIỆP TỰ CHỦ TÀI CHÍNH";
                //    m_us_dm_nha.FillDataset(m_ds_dm_nha,"where id_dat = "+ v_id_dat+" and id_loai_don_vi")
            }
           
            
            m_grv_nha.DataSource = m_ds_dm_nha;
            m_grv_nha.DataBind();

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    #endregion

    #region events

    #endregion
    protected void m_grv_danh_sach_nha_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    protected void m_cbo_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_to_cbo_don_vi_chu_quan();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }
    protected void m_cbo_don_vi_chu_quan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            
            load_data_to_cbo_don_vi_su_dung();
            load_data_to_cbo_dia_chi();

        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }
    protected void m_cbo_don_vi_su_dung_tai_san_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_to_cbo_dia_chi();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }
    protected void m_cmd_loc_du_lieu_Click(object sender, EventArgs e)
    {
        try
        {
            load_data_to_thong_tin_nha_dat();
            load_data_to_grid_nha();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
}
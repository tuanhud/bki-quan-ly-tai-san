﻿using System;
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

public partial class ChucNang_F303_khau_hao_tai_san_khac : System.Web.UI.Page
{
    #region Members
    private US_GD_KHAU_HAO m_us_gd_khau_hao = new US_GD_KHAU_HAO();
    #endregion

    #region Private methods
    private void load_data_to_cbo_trang_thai_up()
    {

        WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC
            , WinFormControls.eTAT_CA.NO
            , m_cbo_trang_thai_tai_san_up);
    }

    private void load_data_to_cbo_trang_thai_down()
    {
        WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC
            , WinFormControls.eTAT_CA.NO
            , m_cbo_trang_thai_tai_san_down);
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
                    , m_cbo_don_vi_su_dung_tai_san_down);
    }

    private void load_from_data()
    {
        load_data_to_bo_tinh_up();
        load_data_to_bo_tinh_down();
        load_data_to_dv_chu_quan_up();
        load_data_to_dv_chu_quan_down();
        load_data_to_dv_su_dung_up();
        load_data_to_dv_su_dung_down();
        load_data_to_cbo_trang_thai_up();
        load_data_to_cbo_trang_thai_down();
        load_data_to_grid();
    }

    private void load_data_to_grid()
    {

    }

    private void load_data_from_us(decimal ip_dc_id)
    {
        US_DM_TAI_SAN_KHAC v_us_dm_tai_san_khac = new US_DM_TAI_SAN_KHAC(ip_dc_id);
        m_lbl_ma_tai_san.Text = v_us_dm_tai_san_khac.strMA_TAI_SAN;
        m_lbl_ky_hieu.Text = v_us_dm_tai_san_khac.strKY_HIEU;
        m_lbl_nam_san_xuat.Text = v_us_dm_tai_san_khac.dcNAM_SAN_XUAT.ToString();
        m_lbl_ngay_thang_nam_su_dung.Text = v_us_dm_tai_san_khac.dcNAM_SU_DUNG.ToString();
        m_lbl_nguyen_gia_nguon_ns.Text = v_us_dm_tai_san_khac.dcNGUON_NS.ToString();
        m_lbl_nguyen_gia_nguon_khac.Text = v_us_dm_tai_san_khac.dcNGUON_KHAC.ToString();
        m_lbl_nuoc_san_xuat.Text = v_us_dm_tai_san_khac.strNUOC_SAN_XUAT;
        m_lbl_gia_tri_con_lai.Text = v_us_dm_tai_san_khac.dcGIA_TRI_CON_LAI.ToString();
    }

    private void them_moi_khau_hao(decimal ip_dc_id)
    {
        US_GD_KHAU_HAO v_us_gd_khau_hao = new US_GD_KHAU_HAO();
        US_DM_TAI_SAN_KHAC v_us_dm_tai_san_khac = new US_DM_TAI_SAN_KHAC(ip_dc_id);

        decimal v_dc_gia_tri_khau_hao = CIPConvert.ToDecimal(m_txt_gia_tri_khau_hao.Text);

        // Lấy thông tin mới cho giao dịch khấu hao
        v_us_gd_khau_hao.dcID_TAI_SAN = ip_dc_id;
        v_us_gd_khau_hao.dcID_LOAI_TAI_SAN = v_us_dm_tai_san_khac.dcID_LOAI_TAI_SAN;
        v_us_gd_khau_hao.dcID_DON_VI = v_us_dm_tai_san_khac.dcID_DON_VI_SU_DUNG;
        v_us_gd_khau_hao.dcGIA_TRI_KHAU_HAO = v_dc_gia_tri_khau_hao;
        v_us_gd_khau_hao.strMA_PHIEU = m_txt_ma_phieu.Text;
        v_us_gd_khau_hao.datNGAY_DUYET = CIPConvert.ToDatetime(m_txt_ngay_duyet.Text);
        v_us_gd_khau_hao.datNGAY_LAP = CIPConvert.ToDatetime(m_txt_ngay_lap.Text);
        v_us_gd_khau_hao.dcID_NGUOI_LAP = Person.get_user_id();
        v_us_gd_khau_hao.dcID_NGUOI_DUYET = Person.get_user_id();

        // Cập nhật cho nhà
        v_us_dm_tai_san_khac.dcGIA_TRI_CON_LAI = v_us_dm_tai_san_khac.dcGIA_TRI_CON_LAI - v_dc_gia_tri_khau_hao;

        // Thực hiện cập nhật
        v_us_gd_khau_hao.Insert();
        v_us_dm_tai_san_khac.Update();
    }

    private void clear_form_data()
    {
        m_lbl_ma_tai_san.Text = "";
        m_lbl_ky_hieu.Text = "";
        m_lbl_nam_san_xuat.Text = "";
        m_lbl_ngay_thang_nam_su_dung.Text = "";
        m_lbl_nguyen_gia_nguon_ns.Text = "";
        m_lbl_nguyen_gia_nguon_khac.Text = "";
        m_lbl_nuoc_san_xuat.Text = "";
        m_lbl_gia_tri_con_lai.Text = "";
        m_txt_gia_tri_khau_hao.Text = "";
        m_txt_ma_phieu.Text = "";
        m_txt_ngay_duyet.Text = "";
        m_txt_ngay_lap.Text = "";
    }

    private bool check_validate_data_is_valid()
    {
        if (CIPConvert.ToDecimal(m_txt_gia_tri_khau_hao.Text) > CIPConvert.ToDecimal(m_lbl_gia_tri_con_lai.Text))
        {
            m_lbl_mess.Text = "Không thể cập nhật. Lỗi: Giá trị khấu hao lớn hơn giá trị còn lại";
            return false;
        }
        return true;
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                load_from_data();
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    protected void m_txt_ten_tai_san_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (!m_hdf_id.Value.Equals(String.Empty))
            {
                clear_form_data();
                decimal v_dc_id = CIPConvert.ToDecimal(m_hdf_id.Value);
                load_data_from_us(v_dc_id);
            }

        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    protected void hdf_id_ValueChanged(object sender, EventArgs e)
    {
        try
        {
            if (!m_hdf_id.Value.Equals(String.Empty))
            {
                clear_form_data();
                decimal v_dc_id = CIPConvert.ToDecimal(m_hdf_id.Value);
                load_data_from_us(v_dc_id);
            }

        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    protected void m_cmd_xoa_trang_Click(object sender, EventArgs e)
    {
        try
        {
            load_data_from_us(CIPConvert.ToDecimal(m_hdf_id.Value));
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {
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
            if (!m_hdf_id.Value.Equals(String.Empty))
            {
                if (!check_validate_data_is_valid()) return;
                them_moi_khau_hao(CIPConvert.ToDecimal(m_hdf_id.Value));
                m_lbl_mess.Text = "Cập nhật thành công";
                clear_form_data();
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
            CSystemLog_301.ExceptionHandle(v_e);
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
            CSystemLog_301.ExceptionHandle(v_e);
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
            CSystemLog_301.ExceptionHandle(v_e);
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
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    protected void m_grv_tai_san_khac_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_tai_san_khac.PageIndex = e.NewPageIndex;
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_tai_san_khac_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (!e.CommandName.Equals(String.Empty))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                decimal v_dc_id_kh = CIPConvert.ToDecimal(m_grv_tai_san_khac.DataKeys[rowIndex].Value);

                switch (e.CommandName)
                {
                    case "DeleteComp":
                        m_us_gd_khau_hao.DeleteByID(v_dc_id_kh);

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
    #endregion  
}
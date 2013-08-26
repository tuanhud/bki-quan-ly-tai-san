using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPData;
using IP.Core.IPUserService;
using WebDS.CDBNames;
using WebDS;
using IP.Core.IPCommon;
using WebUS;
using QltsForm;
using IP.Core.WinFormControls;
using System.Threading;
using IP.Core.QltsFormControls;


public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                form_title();
                WinFormControls.load_data_to_cbo_loai_hinh_don_vi(
                    WinFormControls.eLOAI_TU_DIEN.LOAI_HINH_DON_VI
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_loai_hinh_don_vi
                    );
                WinFormControls.load_data_to_cbo_bo_tinh(
                    WinFormControls.eTAT_CA.YES
                    , m_cbo_bo_tinh);
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_chu_quan);
                WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
                    m_cbo_loai_hinh_don_vi.SelectedValue
                    , m_cbo_don_vi_chu_quan.SelectedValue
                    , m_cbo_bo_tinh.SelectedValue
                    , WinFormControls.eTAT_CA.YES
                    , m_cbo_don_vi_su_dung_tai_san);
                load_data_to_cbo_trang_thai();
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }
    #region Member
    US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
    DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
    US_DM_TAI_SAN_KHAC m_us_tai_san_khac = new US_DM_TAI_SAN_KHAC();
    DS_DM_TAI_SAN_KHAC m_ds_tai_san_khac = new DS_DM_TAI_SAN_KHAC();
    US_CM_DM_TU_DIEN m_us_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_tu_dien = new DS_CM_DM_TU_DIEN();
    #endregion
    #region Private Methods
    private void form_2_objExcelAssetParameters(CObjExcelAssetParameters op_obj_parameter)
    {
        op_obj_parameter.dcID_BO_TINH = CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue);
        op_obj_parameter.strTEN_BO_TINH = m_cbo_bo_tinh.SelectedItem.Text;
        op_obj_parameter.dcID_DON_VI_CHU_QUAN = CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue);
        op_obj_parameter.strTEN_DON_VI_CHU_QUAN = m_cbo_don_vi_chu_quan.SelectedItem.Text;
        op_obj_parameter.dcID_DON_VI_SU_DUNG = CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue);
        op_obj_parameter.strTEN_DON_VI_SU_DUNG = m_cbo_don_vi_su_dung_tai_san.SelectedItem.Text;
        op_obj_parameter.dcID_TRANG_THAI_TAI_SAN = CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue);
        op_obj_parameter.strTEN_TRANG_THAI_TAI_SAN = m_cbo_trang_thai.SelectedItem.Text;
        op_obj_parameter.strKEY_SEARCH = String.Empty;
        op_obj_parameter.dcID_LOAI_TAI_SAN = ID_LOAI_TAI_SAN.NHA;
        op_obj_parameter.strTEN_LOAI_TAI_SAN = CONST_QLDB.TAT_CA;
        op_obj_parameter.strLOAI_HINH_DON_VI = m_cbo_loai_hinh_don_vi.SelectedItem.Text;
        op_obj_parameter.strMA_LOAI_HINH_DON_VI = m_cbo_loai_hinh_don_vi.SelectedValue;
        op_obj_parameter.strUSER_NAME = Person.get_user_name();
    }

    private void export_excel()
    {
        string v_str_output_file = "";
        f401_bao_cao_danh_muc_tai_san_khac v_f401_bc_dm_tai_san_khac = new f401_bao_cao_danh_muc_tai_san_khac();
        CObjExcelAssetParameters v_obj_parameter = new CObjExcelAssetParameters();
        form_2_objExcelAssetParameters(v_obj_parameter);
        if (Request.QueryString["ID"] != null)
        {
            string v_id = Request.QueryString["ID"];
            switch (v_id)
            {
                case "1":
                    v_f401_bc_dm_tai_san_khac.export_excel(f401_bao_cao_danh_muc_tai_san_khac.eFormMode.KE_KHAI_TAI_SAN_KHAC
                        , ref v_obj_parameter);

                    break;
                case "2":
                    v_f401_bc_dm_tai_san_khac.export_excel(f401_bao_cao_danh_muc_tai_san_khac.eFormMode.TAI_SAN_KHAC_DE_NGHI_XU_LY
                        , ref v_obj_parameter);
                    break;
            }
            Response.Clear();
            v_str_output_file = "/QuanLyTaiSan/" + v_obj_parameter.strFILE_NAME_RESULT;
            Response.Redirect(v_str_output_file, false);
        }

    }

    private void form_title()
    {
        string id_loai_bao_cao = "";
        if (Request.QueryString["ID"] != null)
        {
            id_loai_bao_cao = Request.QueryString["ID"];
        }

        switch (id_loai_bao_cao)
        {

            case "1":
                m_lbl_tieu_de.Text = "BÁO CÁO KÊ KHAI DANH MUC TÀI SẢN KHÁC";

                break;
            case "2":
                m_lbl_tieu_de.Text = "DANH MỤC TÀI SẢN KHÁC (TRỪ TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNG SỰ NGHIỆP VÀ XE Ô TÔ) ĐỀ NGHỊ XỬ LÝ";

                break;
            //case "3":
            //    m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, TRỤ SỞ HOẠT ĐỘNG GIAO CHO ĐƠN VỊ SỰ NGHIỆP TỰ CHỦ TÀI CHÍNH";
            //    m_us_dm_nha.FillDataset(m_ds_dm_nha,"where id_dat = "+ v_id_dat+" and id_loai_don_vi")
        }
    }

    private void load_data_to_grid()
    {
        US_V_DM_TAI_SAN_KHAC m_us_v_tai_san_khac = new US_V_DM_TAI_SAN_KHAC();
        DS_V_DM_TAI_SAN_KHAC m_ds_v_tai_san_khac = new DS_V_DM_TAI_SAN_KHAC();
        US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
        string id_loai_bao_cao = "";
        if (Request.QueryString["ID"] != null)
        {
            id_loai_bao_cao = Request.QueryString["ID"];
        }

        switch (id_loai_bao_cao)
        {
            case "1":
                // m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNNG SỰ NGHIỆP";
                m_us_v_tai_san_khac.FillDataSetLoadDataToGridTaiSanKhacLoaiHinh(CIPConvert.ToStr(m_cbo_loai_hinh_don_vi.SelectedValue),
                    Person.get_user_name()
                    , CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                    , m_ds_v_tai_san_khac);
                break;
            case "2":
                // m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNNG SỰ NGHIỆP ĐỀ NGHỊ XỬ LÝ";
                m_us_v_tai_san_khac.FillDataSetLoadDataToGridTaiSanKhacLoaiHinh(CIPConvert.ToStr(m_cbo_loai_hinh_don_vi.SelectedValue),
                    Person.get_user_name()
                    , CIPConvert.ToDecimal(m_cbo_bo_tinh.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_don_vi_chu_quan.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_don_vi_su_dung_tai_san.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue)
                    , m_ds_v_tai_san_khac);
                break;
            //case "3":
            //    m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, TRỤ SỞ HOẠT ĐỘNG GIAO CHO ĐƠN VỊ SỰ NGHIỆP TỰ CHỦ TÀI CHÍNH";
            //    m_us_dm_nha.FillDataset(m_ds_dm_nha,"where id_dat = "+ v_id_dat+" and id_loai_don_vi")
        }


        m_grv_danh_sach_tai_san_khac.DataSource = m_ds_v_tai_san_khac.V_DM_TAI_SAN_KHAC;
        m_grv_danh_sach_tai_san_khac.DataBind();
    }

    /*private void load_data_to_cbo_bo_tinh()
    {
        try
        {
            US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
            m_us_don_vi.FillDataset(m_ds_don_vi, "Where id_loai_don_vi = " + ID_LOAI_DON_VI.BO_TINH);
            m_cbo_bo_tinh.DataSource = m_ds_don_vi.DM_DON_VI;
            m_cbo_bo_tinh.DataValueField = CIPConvert.ToStr(DM_DON_VI.ID);
            m_cbo_bo_tinh.DataTextField = CIPConvert.ToStr(DM_DON_VI.TEN_DON_VI);
            m_cbo_bo_tinh.DataBind();
            load_data_to_cbo_don_vi_chu_quan();
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }
    }*/
    /*private void load_data_to_cbo_don_vi_chu_quan()
    {
        US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
        DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
        string v_id_bo_tinh = m_cbo_bo_tinh.SelectedValue;
        m_us_don_vi.FillDataset(m_ds_don_vi, "where ID_LOAI_DON_VI = 575 and ID_DON_VI_CAP_TREN LIKE '%"
            + v_id_bo_tinh + "%'");
        if (m_ds_don_vi.DM_DON_VI.Count != 0)
        {
            m_cbo_don_vi_chu_quan.DataSource = m_ds_don_vi.DM_DON_VI;
            m_cbo_don_vi_chu_quan.DataTextField = "TEN_DON_VI";
            m_cbo_don_vi_chu_quan.DataValueField = "ID";
            m_cbo_don_vi_chu_quan.DataBind();
            //m_cbo_don_vi_chu_quan.Items.Insert(0, new ListItem("Tất cả đơn vị trực thuộc", ""));
            load_data_to_cbo_don_vi_su_dung();
        }
        else//ta
        {
            m_cbo_don_vi_chu_quan.Items.Clear();
            m_cbo_don_vi_su_dung_tai_san.Items.Clear();
        }
    }*/
    /*private void load_data_to_cbo_don_vi_su_dung()
    {
        if (m_cbo_bo_tinh.SelectedValue == null || m_cbo_don_vi_chu_quan.SelectedValue == null)
        {
            return;
        }
        else
        {
            US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();

            string v_id_don_vi_chu_quan = m_cbo_don_vi_chu_quan.SelectedValue;
            m_us_don_vi.FillDataset(m_ds_don_vi, "where ID_LOAI_DON_VI = " + ID_LOAI_DON_VI.DV_SU_DUNG + " and ID_DON_VI_CAP_TREN LIKE '%" + v_id_don_vi_chu_quan
                + "%'");
            if (m_ds_don_vi.DM_DON_VI.Count != 0)
            {
                m_cbo_don_vi_su_dung_tai_san.DataSource = m_ds_don_vi.DM_DON_VI;
                m_cbo_don_vi_su_dung_tai_san.DataTextField = "TEN_DON_VI";
                m_cbo_don_vi_su_dung_tai_san.DataValueField = "ID";
                m_cbo_don_vi_su_dung_tai_san.DataBind();
            }
            else
            {
                //m_cbo_don_vi_chu_quan.Items.Clear();
                m_cbo_don_vi_su_dung_tai_san.Items.Clear();
            }
        }
    }*/
    private void load_data_to_cbo_trang_thai()
    {
        //DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
        //US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
        //string cmd = "select distinct ma_tu_dien from cm_dm_tu_dien where id_loai_tu_dien=6 or id_loai_tu_dien=7 or id_loai_tu_dien=8";
        //System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(cmd);  
        //"select * from DM_TAI_SAN_KHAC Where TEN_TAI_SAN like '%"+m_txt_tim_kiem.Text+
        //"%' or KY_HIEU like '%"+m_txt_tim_kiem.Text+
        //"%' or NUOC_SAN_XUAT like '%"+m_txt_tim_kiem.Text+
        //"%' or NAM_SAN_XUAT like '%"+m_txt_tim_kiem.Text+
        //"%' or NAM_SU_DUNG like '%"+m_txt_tim_kiem.Text+
        //"%'";

        //v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(MA_LOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC, CM_DM_TU_DIEN.GHI_CHU, v_ds_cm_dm_tu_dien);

        //m_cbo_trang_thai.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
        //m_cbo_trang_thai.DataValueField = CM_DM_TU_DIEN.ID;
        //m_cbo_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN;
        string id_loai_bao_cao = "";
        if (Request.QueryString["ID"] != null)
        {
            id_loai_bao_cao = Request.QueryString["ID"];
        }

        switch (id_loai_bao_cao)
        {
            case "1":
                // m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNNG SỰ NGHIỆP";
                WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC, WinFormControls.eTAT_CA.YES, m_cbo_trang_thai);
                m_cbo_trang_thai.SelectedValue = CIPConvert.ToStr(ID_TRANG_THAI_TAI_SAN_KHAC.DANG_SU_DUNG);
                break;
            case "2":
                // m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNNG SỰ NGHIỆP ĐỀ NGHỊ XỬ LÝ";
                WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC, WinFormControls.eTAT_CA.YES, m_cbo_trang_thai);
                m_cbo_trang_thai.SelectedValue = CIPConvert.ToStr(ID_TRANG_THAI_TAI_SAN_KHAC.DE_NGHI_XU_LY);
                break;
            //case "3":
            //    m_lbl_tieu_de.Text = "BÁO CÁO DANH MỤC TRỤ SỞ LÀM VIỆC, TRỤ SỞ HOẠT ĐỘNG GIAO CHO ĐƠN VỊ SỰ NGHIỆP TỰ CHỦ TÀI CHÍNH";
            //    m_us_dm_nha.FillDataset(m_ds_dm_nha,"where id_dat = "+ v_id_dat+" and id_loai_don_vi")
        }

        //m_cbo_trang_thai.DataBind();
        //m_cbo_trang_thai.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
    }
    #endregion

    protected void m_cbo_bo_tinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            /*load_data_to_cbo_don_vi_chu_quan();
            m_grv_danh_sach_tai_san_khac.Visible = false;*/
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES, m_cbo_don_vi_chu_quan);
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_tai_san);
            m_grv_danh_sach_tai_san_khac.Visible = false;
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
            /*load_data_to_cbo_don_vi_su_dung();
            m_grv_danh_sach_tai_san_khac.Visible = false;*/
            m_lbl_mess.Text = "";
            WinFormControls.load_data_to_cbo_don_vi_su_dung(
                m_cbo_don_vi_chu_quan.SelectedValue
                , m_cbo_bo_tinh.SelectedValue
                , WinFormControls.eTAT_CA.YES
                , m_cbo_don_vi_su_dung_tai_san);
            m_grv_danh_sach_tai_san_khac.Visible = false;
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {
            if (m_cbo_don_vi_chu_quan.SelectedValue == "")
            {
                m_lbl_mess.Text = "Bạn chưa chọn Đơn vị chủ quản";
                return;
            }
            if (m_cbo_don_vi_su_dung_tai_san.SelectedValue == "")
            {
                m_lbl_mess.Text = "Bạn chưa chọn Đơn vị sử dụng";
                return;
            }
            else
            {
                m_grv_danh_sach_tai_san_khac.Visible = true;
                Thread.Sleep(2000);
                load_data_to_grid();
            }
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(ex);
        }

    }
    protected void m_grv_danh_sach_tai_san_khac_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        m_grv_danh_sach_tai_san_khac.PageIndex = e.NewPageIndex;
        load_data_to_grid();
    }
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        Thread.Sleep(2000);
        export_excel();
    }
    protected void m_cbo_loai_hinh_don_vi_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            WinFormControls.load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
    m_cbo_loai_hinh_don_vi.SelectedValue
    , m_cbo_don_vi_chu_quan.SelectedValue.ToString()
    , m_cbo_bo_tinh.SelectedValue.ToString()
    , WinFormControls.eTAT_CA.YES
    , m_cbo_don_vi_su_dung_tai_san
    );
        }
        catch (System.Exception ex)
        {
            CSystemLog_301.ExceptionHandle(this, ex);
        }
    }
}
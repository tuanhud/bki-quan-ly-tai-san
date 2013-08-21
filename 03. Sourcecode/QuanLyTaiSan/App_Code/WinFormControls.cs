﻿using System;
using System.Web.SessionState;
using System.Web;

using WebDS;
using WebUS;
using WebUS;
using WebDS.CDBNames;
using QltsForm;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using IP.Core.IPData;
using IP.Core.IPData.DBNames;

using System.Web.UI.WebControls;


namespace IP.Core.WinFormControls
{
    /// <summary>
    /// Summary description for ApplicationControls.
    /// </summary>
    public class WinFormControls
    {
        public WinFormControls()
        {
            //
            // TODO: Add constructor logic here
            //

        }

        #region Public Interfaces
        public enum eTAT_CA
        {
            YES,
            NO
        }

        public enum eLOAI_TU_DIEN
        {
            TRANG_THAI_DAT
                ,
            TRANG_THAI_NHA
                ,
            TRANG_THAI_OTO
                ,
            TRANG_THAI_TAI_SAN_KHAC
                ,
            LOAI_HINH_DON_VI
                , PHAN_LOAI_TAI_SAN
        }

        public static void load_data_to_cbo_dia_chi(
             decimal ip_dc_bo_tinh
            , decimal ip_dc_id_don_vi_chu_quan
            , decimal ip_dc_id_don_vi_su_dung
            , decimal ip_dc_id_trang_thai_dat
            , eTAT_CA ip_e_tat_ca
            , DropDownList op_obj_cbo_dia_chi_dat)
        {

            DS_DM_DAT v_ds_dm_dat = new DS_DM_DAT();
            US_DM_DAT v_us_dm_dat = new US_DM_DAT();
            string v_str_user_name = HttpContext.Current.Session[SESSION.UserName].ToString();
            v_us_dm_dat.FillDatasetByID_DonVi(
                ip_dc_bo_tinh
                , ip_dc_id_don_vi_chu_quan
                , ip_dc_id_don_vi_su_dung
                , ip_dc_id_trang_thai_dat
                , v_str_user_name
                , v_ds_dm_dat);
            op_obj_cbo_dia_chi_dat.DataSource = v_ds_dm_dat.DM_DAT;
            op_obj_cbo_dia_chi_dat.DataTextField = DM_DAT.DIA_CHI;
            op_obj_cbo_dia_chi_dat.DataValueField = DM_DAT.ID;
            op_obj_cbo_dia_chi_dat.DataBind();
            if (ip_e_tat_ca == eTAT_CA.YES)
            {
                op_obj_cbo_dia_chi_dat.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
            }
        }

        public static void load_data_to_cbo_dia_chi_theo_loai_hinh(
           decimal ip_dc_bo_tinh
          , decimal ip_dc_id_don_vi_chu_quan
          , decimal ip_dc_id_don_vi_su_dung
          , decimal ip_dc_id_trang_thai_dat
            , string ip_str_loai_hinh_don_vi
          , eTAT_CA ip_e_tat_ca
          , DropDownList op_obj_cbo_dia_chi_dat)
        {

            DS_DM_DAT v_ds_dm_dat = new DS_DM_DAT();
            US_DM_DAT v_us_dm_dat = new US_DM_DAT();
            string v_str_user_name = HttpContext.Current.Session[SESSION.UserName].ToString();
            v_us_dm_dat.FillDatasetByID_DonVi_Loai_hinh(
                ip_dc_bo_tinh
                , ip_dc_id_don_vi_chu_quan
                , ip_dc_id_don_vi_su_dung
                , ip_dc_id_trang_thai_dat
                , ip_str_loai_hinh_don_vi
                , v_str_user_name
                , v_ds_dm_dat);
            op_obj_cbo_dia_chi_dat.DataSource = v_ds_dm_dat.DM_DAT;
            op_obj_cbo_dia_chi_dat.DataTextField = DM_DAT.DIA_CHI;
            op_obj_cbo_dia_chi_dat.DataValueField = DM_DAT.ID;
            op_obj_cbo_dia_chi_dat.DataBind();
            if (ip_e_tat_ca == eTAT_CA.YES)
            {
                op_obj_cbo_dia_chi_dat.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
            }
        }
        public static void load_data_to_cbo_dia_chi(
             decimal ip_dc_bo_tinh
            , decimal ip_dc_id_don_vi_chu_quan
            , decimal ip_dc_id_don_vi_su_dung
            , string ip_str_loai_hinh_don_vi
            , decimal ip_dc_id_trang_thai_dat
            , eTAT_CA ip_e_tat_ca
            , DropDownList op_obj_cbo_dia_chi_dat)
        {

            DS_DM_DAT v_ds_dm_dat = new DS_DM_DAT();
            US_DM_DAT v_us_dm_dat = new US_DM_DAT();
            string v_str_user_name = HttpContext.Current.Session[SESSION.UserName].ToString();
            v_us_dm_dat.FillDatasetByID_DonVi(
                ip_dc_bo_tinh
                , ip_dc_id_don_vi_chu_quan
                , ip_dc_id_don_vi_su_dung
                , ip_dc_id_trang_thai_dat
                , v_str_user_name
                , v_ds_dm_dat);
            op_obj_cbo_dia_chi_dat.DataSource = v_ds_dm_dat.DM_DAT;
            op_obj_cbo_dia_chi_dat.DataTextField = DM_DAT.DIA_CHI;
            op_obj_cbo_dia_chi_dat.DataValueField = DM_DAT.ID;
            op_obj_cbo_dia_chi_dat.DataBind();
            if (ip_e_tat_ca == eTAT_CA.YES)
            {
                op_obj_cbo_dia_chi_dat.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
            }
        }
        public static void load_data_to_cbo_loai_hinh_don_vi(
            eLOAI_TU_DIEN ip_e_trang_thai_tai_san
           , eTAT_CA ip_e_tat_ca
           , DropDownList ip_obj_cbo_trang_thai)
        {

            US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN();
            DS_CM_DM_TU_DIEN v_ds_dm_tu_dien = new DS_CM_DM_TU_DIEN();
            string v_str_loai_trang_thai = "";
            v_str_loai_trang_thai = MA_LOAI_TU_DIEN.LOAI_HINH_DON_VI;
            v_us_dm_tu_dien.fill_tu_dien_cung_loai_ds(
                v_str_loai_trang_thai
                , CM_DM_TU_DIEN.GHI_CHU
                , v_ds_dm_tu_dien);
            ip_obj_cbo_trang_thai.DataSource = v_ds_dm_tu_dien.CM_DM_TU_DIEN;
            ip_obj_cbo_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN;
            ip_obj_cbo_trang_thai.DataValueField = CM_DM_TU_DIEN.MA_TU_DIEN;
            ip_obj_cbo_trang_thai.DataBind();
            if (ip_e_tat_ca == eTAT_CA.YES)
            {
                ip_obj_cbo_trang_thai.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
            }

        }
        public static void load_data_to_cbo_tu_dien(
             eLOAI_TU_DIEN ip_e_trang_thai_tai_san
            , eTAT_CA ip_e_tat_ca
            , DropDownList ip_obj_cbo_trang_thai)
        {

            US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN();
            DS_CM_DM_TU_DIEN v_ds_dm_tu_dien = new DS_CM_DM_TU_DIEN();
            string v_str_loai_trang_thai = "";
            switch (ip_e_trang_thai_tai_san)
            {
                case eLOAI_TU_DIEN.TRANG_THAI_DAT:
                    v_str_loai_trang_thai = MA_LOAI_TU_DIEN.TRANG_THAI_DAT;
                    break;
                case eLOAI_TU_DIEN.TRANG_THAI_NHA:
                    v_str_loai_trang_thai = MA_LOAI_TU_DIEN.TRANG_THAI_NHA;
                    break;
                case eLOAI_TU_DIEN.TRANG_THAI_OTO:
                    v_str_loai_trang_thai = MA_LOAI_TU_DIEN.TRANG_THAI_OTO;
                    break;
                case eLOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC:
                    v_str_loai_trang_thai = MA_LOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC;
                    break;
                case eLOAI_TU_DIEN.LOAI_HINH_DON_VI:
                    v_str_loai_trang_thai = MA_LOAI_TU_DIEN.LOAI_HINH_DON_VI;
                    break;
                case eLOAI_TU_DIEN.PHAN_LOAI_TAI_SAN:
                    v_str_loai_trang_thai = MA_LOAI_TU_DIEN.PHAN_LOAI_TAI_SAN;
                    break;
            }
            v_us_dm_tu_dien.fill_tu_dien_cung_loai_ds(
                v_str_loai_trang_thai
                , CM_DM_TU_DIEN.GHI_CHU
                , v_ds_dm_tu_dien);

            ip_obj_cbo_trang_thai.DataSource = v_ds_dm_tu_dien.CM_DM_TU_DIEN;
            ip_obj_cbo_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN;
            ip_obj_cbo_trang_thai.DataValueField = CM_DM_TU_DIEN.ID;
            ip_obj_cbo_trang_thai.DataBind();
            if (ip_e_tat_ca == eTAT_CA.YES)
            {
                ip_obj_cbo_trang_thai.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
            }

        }

        public static void load_data_to_cbo_don_vi_chu_quan(
            string ip_str_id_bo_tinh
            , eTAT_CA ip_e_tat_ca
            , DropDownList ip_obj_cbo_dv_chu_quan)
        {
            US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

            if (ip_str_id_bo_tinh.Length == 0)
            {
                ip_obj_cbo_dv_chu_quan.Items.Clear();
                return;
            }

            string v_str_user_name = HttpContext.Current.Session[SESSION.UserName].ToString();
            decimal v_dc_id_bo_tinh = CIPConvert.ToDecimal(ip_str_id_bo_tinh);
            v_us_dm_don_vi.FillDataset(
                v_ds_dm_don_vi
                , ID_LOAI_DON_VI.DV_CHU_QUAN
                , v_dc_id_bo_tinh
                , CONST_QLDB.ID_TAT_CA
                , v_str_user_name);

            ip_obj_cbo_dv_chu_quan.DataSource = v_ds_dm_don_vi.DM_DON_VI;
            ip_obj_cbo_dv_chu_quan.DataTextField = DM_DON_VI.TEN_DON_VI;
            ip_obj_cbo_dv_chu_quan.DataValueField = DM_DON_VI.ID;
            ip_obj_cbo_dv_chu_quan.DataBind();
            if (ip_e_tat_ca == eTAT_CA.YES)
            {
                ip_obj_cbo_dv_chu_quan.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
            }

        }

        public static void load_data_to_cbo_bo_tinh(
             eTAT_CA ip_e_tat_ca
            , DropDownList ip_obj_cbo_bo_tinh)
        {

            US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

            //v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = " + ID_LOAI_DON_VI.BO_TINH);
            string v_str_user_name = HttpContext.Current.Session[SESSION.UserName].ToString();
            v_us_dm_don_vi.FillDataset(
                v_ds_dm_don_vi
                , ID_LOAI_DON_VI.BO_TINH
                , CONST_QLDB.ID_TAT_CA
                , CONST_QLDB.ID_TAT_CA
                , v_str_user_name);

            ip_obj_cbo_bo_tinh.DataSource = v_ds_dm_don_vi.DM_DON_VI;
            ip_obj_cbo_bo_tinh.DataTextField = DM_DON_VI.TEN_DON_VI;
            ip_obj_cbo_bo_tinh.DataValueField = DM_DON_VI.ID;
            ip_obj_cbo_bo_tinh.DataBind();
            if (ip_e_tat_ca == eTAT_CA.YES)
            {
                ip_obj_cbo_bo_tinh.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
            }

        }

        public static void load_data_to_cbo_don_vi_su_dung(
            string ip_str_loai_hinh_don_vi
            , string ip_str_id_don_vi_chu_quan
            , string ip_str_id_bo_tinh
             , eTAT_CA ip_e_tat_ca
            , DropDownList ip_obj_cbo_dv_su_dung
            )
        {
            if (ip_str_id_bo_tinh.Length == 0)
            {
                ip_obj_cbo_dv_su_dung.Items.Clear();
                return;
            }
            if (ip_str_id_don_vi_chu_quan.Length == 0)
            {
                ip_obj_cbo_dv_su_dung.Items.Clear();
                return;
            }

            US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

            string v_str_user_name = HttpContext.Current.Session[SESSION.UserName].ToString();
            if (!Person.check_session_valid()) return;
            decimal v_dc_id_don_vi_chu_quan = CIPConvert.ToDecimal(ip_str_id_don_vi_chu_quan);
            decimal v_dc_id_bo_tinh = CIPConvert.ToDecimal(ip_str_id_bo_tinh);
            v_us_dm_don_vi.FillDataset(
                v_ds_dm_don_vi
                , ID_LOAI_DON_VI.DV_SU_DUNG
                , v_dc_id_don_vi_chu_quan
                , v_dc_id_bo_tinh
                , ip_str_loai_hinh_don_vi
                , v_str_user_name);
            ip_obj_cbo_dv_su_dung.DataSource = v_ds_dm_don_vi.DM_DON_VI;
            ip_obj_cbo_dv_su_dung.DataTextField = DM_DON_VI.TEN_DON_VI;
            ip_obj_cbo_dv_su_dung.DataValueField = DM_DON_VI.ID;
            ip_obj_cbo_dv_su_dung.DataBind();

            if (ip_e_tat_ca == eTAT_CA.YES)
            {
                ip_obj_cbo_dv_su_dung.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
            }
        }

        public static void load_data_to_cbo_don_vi_su_dung(
            string ip_str_id_don_vi_chu_quan
            , string ip_str_id_bo_tinh
             , eTAT_CA ip_e_tat_ca
            , DropDownList ip_obj_cbo_dv_su_dung)
        {

            if (ip_str_id_bo_tinh.Length == 0)
            {
                ip_obj_cbo_dv_su_dung.Items.Clear();
                return;
            }
            if (ip_str_id_don_vi_chu_quan.Length == 0)
            {
                ip_obj_cbo_dv_su_dung.Items.Clear();
                return;
            }

            US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

            string v_str_user_name = HttpContext.Current.Session[SESSION.UserName].ToString();
            decimal v_dc_id_don_vi_chu_quan = CIPConvert.ToDecimal(ip_str_id_don_vi_chu_quan);
            decimal v_dc_id_bo_tinh = CIPConvert.ToDecimal(ip_str_id_bo_tinh);
            v_us_dm_don_vi.FillDataset(
                v_ds_dm_don_vi
                , ID_LOAI_DON_VI.DV_SU_DUNG
                , v_dc_id_don_vi_chu_quan
                , v_dc_id_bo_tinh
                , v_str_user_name);

            ip_obj_cbo_dv_su_dung.DataSource = v_ds_dm_don_vi.DM_DON_VI;
            ip_obj_cbo_dv_su_dung.DataTextField = DM_DON_VI.TEN_DON_VI;
            ip_obj_cbo_dv_su_dung.DataValueField = DM_DON_VI.ID;
            ip_obj_cbo_dv_su_dung.DataBind();

            if (ip_e_tat_ca == eTAT_CA.YES)
            {
                ip_obj_cbo_dv_su_dung.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
            }
        }
        #endregion
    }
}

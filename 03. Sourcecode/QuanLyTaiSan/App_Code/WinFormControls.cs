using System;
using System.Web.SessionState;
using System.Web;

using WebDS;
using WebUS;
using WebUS;
using WebDS.CDBNames;
using QltsForm;
using IP.Core.IPCommon;
using System.Web.UI.WebControls;


namespace IP.Core.WinFormControls{
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
        public enum eTAT_CA {
            YES,
            NO
        }

        public static void load_data_to_cbo_don_vi_chu_quan(
            string ip_str_id_bo_tinh  
            , eTAT_CA ip_e_tat_ca 
            , DropDownList ip_obj_cbo_dv_chu_quan) {
            US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

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
            if (ip_e_tat_ca == eTAT_CA.YES) {
                ip_obj_cbo_dv_chu_quan.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
            }

        }

        public static void load_data_to_cbo_bo_tinh(
             eTAT_CA ip_e_tat_ca 
            , DropDownList ip_obj_cbo_bo_tinh) {

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
            if (ip_e_tat_ca == eTAT_CA.YES) {
                ip_obj_cbo_bo_tinh.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
            }

        }

        public static void load_data_to_cbo_don_vi_su_dung(
            string ip_str_id_don_vi_chu_quan
            , string ip_str_id_bo_tinh
             , eTAT_CA ip_e_tat_ca 
            , DropDownList ip_obj_cbo_dv_su_dung) {
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

            if (ip_e_tat_ca == eTAT_CA.YES) {
                ip_obj_cbo_dv_su_dung.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
            }
        }
        #endregion
    }
}

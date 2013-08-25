using System;
using System.Data;
using System.Web.SessionState;
using System.Web;
using System.Windows.Forms;

using WebDS;
using WebUS;
using WebUS;
using WebDS.CDBNames;
using QltsForm;
using IP.Core.IPCommon;
using System.Web.UI.WebControls;


namespace IP.Core.QltsFormControls{
    /// <summary>
    /// Summary description for ApplicationControls.
    /// </summary>
    public class QltsFormControls
    {
        public QltsFormControls()
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
        public static void load_data_to_cbo_bo_tinh(
          eTAT_CA ip_e_tat_ca
         , ComboBox ip_obj_cbo_bo_tinh) {

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
            if (ip_e_tat_ca == eTAT_CA.YES) {
                DataRow v_dr = v_ds_dm_don_vi.DM_DON_VI.NewDM_DON_VIRow();
                v_dr[DM_DON_VI.ID] = CONST_QLDB.ID_TAT_CA;
                v_dr[DM_DON_VI.TEN_DON_VI] = CONST_QLDB.TAT_CA;

                v_ds_dm_don_vi.DM_DON_VI.Rows.InsertAt(v_dr, 0);
            }
            ip_obj_cbo_bo_tinh.DataSource = v_ds_dm_don_vi.DM_DON_VI;
            ip_obj_cbo_bo_tinh.DisplayMember = DM_DON_VI.TEN_DON_VI;
            ip_obj_cbo_bo_tinh.ValueMember = DM_DON_VI.ID;


        }

        public static void load_data_to_cbo_don_vi_chu_quan(
            decimal ip_dc_id_bo_tinh  
            , eTAT_CA ip_e_tat_ca 
            , ComboBox ip_obj_cbo_dv_chu_quan) {
            US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

            if (ip_dc_id_bo_tinh ==0) {
                ip_obj_cbo_dv_chu_quan.Items.Clear();
                return;
            }

            string v_str_user_name = HttpContext.Current.Session[SESSION.UserName].ToString();
            
            v_us_dm_don_vi.FillDataset(
                v_ds_dm_don_vi
                , ID_LOAI_DON_VI.DV_CHU_QUAN
                , ip_dc_id_bo_tinh
                , CONST_QLDB.ID_TAT_CA
                , v_str_user_name);

            if (ip_e_tat_ca == eTAT_CA.YES) {
                DataRow v_dr = v_ds_dm_don_vi.DM_DON_VI.NewDM_DON_VIRow();
                v_dr[DM_DON_VI.ID] = CONST_QLDB.ID_TAT_CA;
                v_dr[DM_DON_VI.TEN_DON_VI] = CONST_QLDB.TAT_CA;

                v_ds_dm_don_vi.DM_DON_VI.Rows.InsertAt(v_dr,0);
            }

            ip_obj_cbo_dv_chu_quan.DataSource = v_ds_dm_don_vi.DM_DON_VI;
            ip_obj_cbo_dv_chu_quan.DisplayMember = DM_DON_VI.TEN_DON_VI;
            ip_obj_cbo_dv_chu_quan.ValueMember = DM_DON_VI.ID;
            
            

        }

     

        public static void load_data_to_cbo_don_vi_su_dung(
            decimal ip_dc_id_don_vi_chu_quan
            , decimal ip_dc_id_bo_tinh
             , eTAT_CA ip_e_tat_ca 
            , ComboBox ip_obj_cbo_dv_su_dung) {

                if (ip_dc_id_bo_tinh == 0) {
                    ip_obj_cbo_dv_su_dung.Items.Clear();
                    return;
                }
                if (ip_dc_id_don_vi_chu_quan == 0) {
                    ip_obj_cbo_dv_su_dung.Items.Clear();
                    return;
                }

            US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

            string v_str_user_name = HttpContext.Current.Session[SESSION.UserName].ToString();
      
            v_us_dm_don_vi.FillDataset(
                v_ds_dm_don_vi
                , ID_LOAI_DON_VI.DV_SU_DUNG
                , ip_dc_id_don_vi_chu_quan
                , ip_dc_id_bo_tinh
                , v_str_user_name);

            if (ip_e_tat_ca == eTAT_CA.YES) {
                DataRow v_dr = v_ds_dm_don_vi.DM_DON_VI.NewDM_DON_VIRow();
                v_dr[DM_DON_VI.ID] = CONST_QLDB.ID_TAT_CA;
                v_dr[DM_DON_VI.TEN_DON_VI] = CONST_QLDB.TAT_CA;

                v_ds_dm_don_vi.DM_DON_VI.Rows.InsertAt(v_dr, 0);
            }

            ip_obj_cbo_dv_su_dung.DataSource = v_ds_dm_don_vi.DM_DON_VI;
            ip_obj_cbo_dv_su_dung.DisplayMember = DM_DON_VI.TEN_DON_VI;
            ip_obj_cbo_dv_su_dung.ValueMember = DM_DON_VI.ID;
            

            
        }
        #endregion
    }

    public class CObjExcelAssetParameters {
        public decimal dcID_BO_TINH;
        public decimal dcID_DON_VI_CHU_QUAN;
        public decimal dcID_DON_VI_SU_DUNG;
        public decimal dcID_TRANG_THAI_TAI_SAN;
        public decimal dcID_LOAI_TAI_SAN;
        public decimal dcUSER_ID;
        public string strTEN_BO_TINH;
        public string strTEN_DON_VI_CHU_QUAN;
        public string strTEN_DON_VI_SU_DUNG;
        public string strTEN_TRANG_THAI_TAI_SAN;
        public string strTEN_LOAI_TAI_SAN;
        public string strLOAI_HINH_DON_VI;
        public string strMA_LOAI_HINH_DON_VI;
        public string strKEY_SEARCH;
        public string strUSER_NAME;
        public DateTime datTU_NGAY;
        public DateTime datDEN_NGAY;
        public string strFILE_NAME_RESULT;
    }
}

﻿using System.Collections.Generic;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;
using System.Data.SqlClient;
using WebDS;
using WebDS.CDBNames;
using WebUS;
using IP.Core.IPCommon;
using System;

[WebService(Namespace = "http://bkindex.com")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class PersonService : System.Web.Services.WebService
{
    #region Web Methods
    [WebMethod]
    public List<US_V_DM_OTO> GetOto(string name_prefix, decimal ip_dc_id_dv_su_dung)
    {
        return get_top_dm_oto_by_name(name_prefix, ip_dc_id_dv_su_dung);
    }

    [WebMethod]
    public List<US_DM_NHA> GetNha(string name_prefix, decimal ip_dc_id_dat)
    {
        return get_top_dm_nha_by_name(name_prefix, ip_dc_id_dat);
    }
    [WebMethod]
    public List<US_V_DM_TAI_SAN_KHAC> GetTaiSanKhac(string name_prefix, decimal ip_dc_id_dv_su_dung)
    {
        return null;
    }
    #endregion

    #region Private Methods
    private List<US_V_DM_OTO> get_top_dm_oto_by_name(string ip_str_oto_name, decimal ip_dc_id_dv_su_dung)
    {
        DS_V_DM_OTO v_ds_oto = new DS_V_DM_OTO();
        US_V_DM_OTO v_us = new US_V_DM_OTO();
        v_ds_oto.EnforceConstraints = false;
        v_us.load_oto_by_ten(v_ds_oto, ip_str_oto_name, ip_dc_id_dv_su_dung);
        if (v_ds_oto.V_DM_OTO.Rows.Count == 0) return null;
        List<US_V_DM_OTO> v_teachers = new List<US_V_DM_OTO>();
        if (v_ds_oto.V_DM_OTO.Rows.Count > 0)
            for (int i = 0; i < v_ds_oto.V_DM_OTO.Rows.Count; i++)
            {
                US_V_DM_OTO v_oto = new US_V_DM_OTO();
                v_oto.dcID = int.Parse(v_ds_oto.V_DM_OTO.Rows[i]["ID"].ToString());
                v_oto.strTEN_TAI_SAN = v_ds_oto.V_DM_OTO.Rows[i][V_DM_OTO.TEN_TAI_SAN].ToString().TrimEnd();
                v_teachers.Add(v_oto);
            }
        return v_teachers;
    }

    private List<US_DM_NHA> get_top_dm_nha_by_name(string ip_str_ten_nha, decimal ip_dc_id_dat)
    {
        DS_DM_NHA v_ds_dm_nha = new DS_DM_NHA();
        US_DM_NHA v_us_dm_nha = new US_DM_NHA();
        v_ds_dm_nha.EnforceConstraints = false;
        v_us_dm_nha.load_nha_by_ten(v_ds_dm_nha, ip_str_ten_nha, ip_dc_id_dat);
        if (v_ds_dm_nha.DM_NHA.Rows.Count == 0) return null;
        List<US_DM_NHA> v_list_nha = new List<US_DM_NHA>();
        for (int i = 0; i < v_ds_dm_nha.DM_NHA.Rows.Count; i++)
        {
            US_DM_NHA v_us_temp = new US_DM_NHA();
            v_us_temp.dcID = int.Parse(v_ds_dm_nha.DM_NHA.Rows[i]["ID"].ToString());
            v_us_temp.strTEN_TAI_SAN = v_ds_dm_nha.DM_NHA.Rows[i][DM_NHA.TEN_TAI_SAN].ToString().TrimEnd();
            v_list_nha.Add(v_us_temp);
        }

        return v_list_nha;
    }

    private List<US_V_DM_TAI_SAN_KHAC> get_top_dm_tai_san_khac(string ip_str_ten_ts, decimal ip_dc_id_ts)
    {
        DS_V_DM_TAI_SAN_KHAC v_ds_v_dm_ts_khac = new DS_V_DM_TAI_SAN_KHAC();
        US_V_DM_TAI_SAN_KHAC v_us_v_dm_ts_khac = new US_V_DM_TAI_SAN_KHAC();
        v_ds_v_dm_ts_khac.EnforceConstraints = false;
        v_us_v_dm_ts_khac.FillDatasetLoadDataToGridTaiSanKhac_by_tu_khoa(
            String.Empty
            , CONST_QLDB.ID_TAT_CA
            , CONST_QLDB.ID_TAT_CA
            , ip_dc_id_ts
            , ID_TRANG_THAI_TAI_SAN_KHAC.DANG_SU_DUNG
            , CONST_QLDB.ID_TAT_CA.ToString()
            , Person.get_user_name()
            , v_ds_v_dm_ts_khac);

        List<US_V_DM_TAI_SAN_KHAC> v_list = new List<US_V_DM_TAI_SAN_KHAC>();
        for (int i = 0; i < v_ds_v_dm_ts_khac.V_DM_TAI_SAN_KHAC.Rows.Count; i++)
        {
            US_V_DM_TAI_SAN_KHAC v_us_temp = new US_V_DM_TAI_SAN_KHAC();
            v_us_temp.dcID = int.Parse(v_ds_v_dm_ts_khac.V_DM_TAI_SAN_KHAC.Rows[i]["ID"].ToString());
            v_us_temp.strTEN_TAI_SAN = v_ds_v_dm_ts_khac.V_DM_TAI_SAN_KHAC.Rows[i][V_DM_TAI_SAN_KHAC.TEN_TAI_SAN].ToString().TrimEnd();
            v_list.Add(v_us_temp);
        }

        return v_list;
    }
    #endregion
}


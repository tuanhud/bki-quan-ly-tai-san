using System.Collections.Generic;
using System.Web.Services;
//using System.Web.Script.Services;

using System.Data;
using System.Data.SqlClient;

using WebDS;
using WebDS.CDBNames;
using WebUS;
using IP.Core.IPCommon;

[WebService(Namespace = "http://bkindex.com")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//[ScriptService]
public class PersonService : System.Web.Services.WebService
{
    #region Web Methods
    [WebMethod]
    public List<US_V_DM_OTO> GetOto(string name_prefix)
    {
        return get_top_dm_oto_by_name(name_prefix);
    }
    
    #endregion
    #region Private Methods

    private List<US_V_DM_OTO> get_top_dm_oto_by_name(string ip_str_oto_name)
    {
        DS_V_DM_OTO v_ds_oto = new DS_V_DM_OTO();
        US_V_DM_OTO v_us = new US_V_DM_OTO();
        v_ds_oto.EnforceConstraints = false;
        v_us.load_oto_by_ten(v_ds_oto, ip_str_oto_name);
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

    private SqlConnection getConnection()
    {
        string v_str_query_string = "Data Source=.\\SQLEXPRESS; Initial Catalog=TRM; User Id=sa; Password=123456;";
        return new SqlConnection(v_str_query_string);
    }
    #endregion
}


using System.Collections.Generic;
using System.Web;
using WebUS;
using IP.Core.IPCommon;

/// <summary>
/// Summary description for Employee
/// </summary>
public class Person
{
    public int ID;
    public string Name;

	public Person()
	{
	}

    public static decimal get_user_id()
    {
        object v_obj_id = HttpContext.Current.Session[SESSION.UserID];
        return CIPConvert.ToDecimal(v_obj_id);
    }

    public static string get_user_name()
    {
        object v_obj_username = HttpContext.Current.Session[SESSION.UserName];
        return v_obj_username.ToString();
    }

    public static bool check_session_valid()
    {
        return HttpContext.Current.Session[SESSION.UserID] != null;
    }
}

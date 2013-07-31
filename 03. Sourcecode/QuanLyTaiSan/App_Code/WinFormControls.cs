using System;
using IP.Core.FormWinReport;

namespace IP.Core.FormWinReport
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
        public static void f706_report_exel_tong_hop_cv_gv_chuyen_mon(System.Web.HttpResponse i_response
                , System.Web.HttpRequest i_request
                , string ip_str_thang
                , string ip_str_nam
                , string ip_str_trang_thai
                , string ip_str_tong_tien
                , decimal ip_dc_trang_thai)
        {
            try
            {
                string v_srt_output_file = "";
                f706_rpt_bao_cao_cv_gv_chuyen_mon v_frm = new f706_rpt_bao_cao_cv_gv_chuyen_mon();
                v_frm.load_data_2_grid(ip_str_thang
                                        , ip_str_nam
                                        , ip_dc_trang_thai);
                v_frm.excel_danh_sach_2_report(ref v_srt_output_file
                                               , ip_str_thang
                                               , ip_str_nam
                                               , ip_str_trang_thai
                                               , ip_str_tong_tien);
                i_response.Clear();
                v_srt_output_file = "/TRMProject/" + v_srt_output_file;
                i_response.Redirect(v_srt_output_file, false);
                //i_response.End();
            }
            catch (Exception v_e)
            {
                i_response.Write("Souce Error: <b>" + v_e.Source + v_e.Message + "<b>" + v_e.StackTrace);
            }
        }
        #endregion
    }
}

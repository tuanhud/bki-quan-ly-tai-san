using System;
using System.Drawing;
using System.Web.SessionState;
using System.Web;
using System.IO;    


using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI;






/// <summary>
/// Summary description for WinformReport
/// </summary>
public class WinformReport
{
    /*
* Chú ý khi xuất excel:
* thêm EnableEventValidation ="false" vào <%@ Page ở trang .aspx* Hàm load dữ liệu lên lưới để là: load_data_to_grid();
*/

    /// <summary>
    /// Hàm này dùng để xuất dữ liệu từ Gridview ra Excel
    /// </summary>
    /// <param name="ip_grv">Gridview muốn xuất dữ liệu ra</param>
    /// <param name="ip_str_filename">Tên file excel xuất ra</param>
    /// <param name="ip_b_export_all_yn">Xuất tất cả dữ liệu hay chỉ xuất ở trang hiện tại</param>
    /// <param name="ip_i_invisible_columns">Danh sách các cột muốn ẩn đi khi xuất (lấy theo số thứ tự, bắt đầu từ 0)</param>
    public static void export_gridview_2_excel(GridView ip_grv
                               , string ip_str_filename
                               , System.Web.UI.Page ip_page
                               , params int[] ip_i_invisible_columns
                                ) {
        ip_page.Response.Clear();
        ip_page.Response.Buffer = true;
        ip_page.Response.AddHeader("content-disposition", "attachment;filename=" + ip_str_filename);
        ip_page.Response.Charset = "UTF-8";
        ip_page.Response.ContentEncoding = System.Text.Encoding.UTF8;
        ip_page.Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter()) {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //if (ip_b_export_all_yn) {
            //    //To Export all pages
            //    ip_grv.AllowPaging = false;
            //    load_data_to_grid();
            //}

            // Ẩn các cột phân trang ở cả đầu và cuối
            ip_grv.TopPagerRow.Visible = false;
            ip_grv.BottomPagerRow.Visible = false;

            ip_grv.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in ip_grv.HeaderRow.Cells) {
                cell.BackColor = ip_grv.HeaderStyle.BackColor;
            }
            // Chỗ này để ẩn đi cột trên header
            if (ip_i_invisible_columns.Length > 0) {
                for (int v_i = 0; v_i < ip_i_invisible_columns.Length; v_i++) {
                    ip_grv.HeaderRow.Cells[v_i].Visible = false;
                }
            }

            foreach (GridViewRow row in ip_grv.Rows) {
                // Chỗ này để ẩn đi cột trên các dòng dữ liệu
                if (ip_i_invisible_columns.Length > 0) {
                    for (int v_i = 0; v_i < ip_i_invisible_columns.Length; v_i++) {
                        row.Cells[v_i].Visible = false;
                    }
                }

                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells) {
                    if (row.RowIndex % 2 == 0) {
                        cell.BackColor = ip_grv.AlternatingRowStyle.BackColor;
                    }
                    else {
                        cell.BackColor = ip_grv.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";

                    List<Control> controls = new List<Control>();

                    //Add controls to be removed to Generic List
                    foreach (Control control in cell.Controls) {
                        switch (control.GetType().Name) {
                            case "HyperLink":
                                cell.Controls.Remove(control);
                                break;
                            case "TextBox":
                                break;
                            case "LinkButton":
                                cell.Controls.Remove(control);
                                break;
                            case "CheckBox":
                                cell.Controls.Remove(control);
                                break;
                            case "RadioButton":
                                //cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });  // Chưa biết tại sao lỗi
                                cell.Controls.Remove(control);
                                break;
                        }
                    }
                }
            }

            ip_grv.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            ip_page.Response.Write(style);
            ip_page.Response.Output.Write(sw.ToString());
            ip_page.Response.Flush();
            ip_page.Response.End();
        }
    }

    /*
    * Ví dụ dùng hàm
  
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e) {
        try {
            export_gridview_2_excel(m_grv_dm_tai_san
                        , "DS tai san.xls"
                        , true
                        , 0, 1); // 0 và 1 là số thứ tự 2 cột: Sửa, Xóa
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
     *   */
}
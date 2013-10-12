using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IP.Core.IPException;
using IP.Core.IPCommon;
namespace QltsForm
{
    public partial class f101_menu_tao_bao_cao : Form
    {
        public f101_menu_tao_bao_cao()
        {
            InitializeComponent();
            load_data_to_form();
            set_inital_form();
        }
        #region Public Interface

        public void display()
        {
            this.ShowDialog();
        }
        #endregion

        #region Data Structure
        class eLOAI_BAO_CAO_INDEX
        {
            public const string KE_KHAI = "1";
            public const string DE_NGHI_XU_LY = "2";
        }
        class eLOAI_BAO_CAO_VALUE
        {
            public const string KE_KHAI = "Kê khai";
            public const string DE_NGHI_XU_LY = "Đề nghị xử lý";
        }
        class eLOAI_TAI_SAN_INDEX
        {
            public const string TRU_SO_LAM_VIEC = "1";
            public const string OTO = "2";
            public const string TAI_SAN_KHAC = "3";
        }
        class eLOAI_TAI_SAN_VALUE
        {
            public const string TRU_SO_LAM_VIEC = "Trụ sở làm việc";
            public const string OTO = "Ô tô";
            public const string TAI_SAN_KHAC = "Tải sản khác";
        }
        #endregion

        #region Private Methods
        private void open_report()
        {
            switch (CIPConvert.ToStr(m_cbo_loai_tai_san.SelectedValue))
            {
                case eLOAI_TAI_SAN_INDEX.TRU_SO_LAM_VIEC:
                    f402_tao_bao_cao_danh_muc_tru_so_lam_viec v_frm_tru_so_lam_viec = new f402_tao_bao_cao_danh_muc_tru_so_lam_viec();
                    
                    v_frm_tru_so_lam_viec.load_data_from_file_excel(m_txt_file_path.Text);
                    if (m_cbo_loai_bao_cao.SelectedValue.Equals(eLOAI_BAO_CAO_INDEX.KE_KHAI))
                        v_frm_tru_so_lam_viec.set_form_mode(f402_tao_bao_cao_danh_muc_tru_so_lam_viec.eFormMode.KE_KHAI);
                    if (m_cbo_loai_bao_cao.SelectedValue.Equals(eLOAI_BAO_CAO_INDEX.DE_NGHI_XU_LY))
                        v_frm_tru_so_lam_viec.set_form_mode(f402_tao_bao_cao_danh_muc_tru_so_lam_viec.eFormMode.DE_NGHI_XU_LY);
                    v_frm_tru_so_lam_viec.display();
                    break;
                case eLOAI_TAI_SAN_INDEX.OTO:
                    F403_tao_bao_cao_danh_muc_oto v_frm_oto = new F403_tao_bao_cao_danh_muc_oto();
                    v_frm_oto.load_data_from_file_excel(m_txt_file_path.Text);
                    if (m_cbo_loai_bao_cao.SelectedValue.Equals(eLOAI_BAO_CAO_INDEX.KE_KHAI))
                        v_frm_oto.set_form_mode(F403_tao_bao_cao_danh_muc_oto.eFormMode.KE_KHAI);
                    if (m_cbo_loai_bao_cao.SelectedValue.Equals(eLOAI_BAO_CAO_INDEX.DE_NGHI_XU_LY))
                        v_frm_oto.set_form_mode(F403_tao_bao_cao_danh_muc_oto.eFormMode.DE_NGHI_XU_LY);
                    v_frm_oto.display();
                    break;
                //case eLOAI_TAI_SAN_INDEX.TAI_SAN_KHAC:
                //    F403_tao_bao_cao_danh_muc_oto v_frm_oto = new F403_tao_bao_cao_danh_muc_oto();
                //    v_frm_oto.load_data_from_file_excel(m_txt_file_path.Text);
                //    v_frm_oto.display();
                //    break;
            }
        }
        private void load_data_to_form()
        {
            //load data to combobox m_cbo_loai_bao_cao
            Dictionary<string, string> v_ct_loai_bao_cao = new Dictionary<string, string>();
            v_ct_loai_bao_cao.Add(eLOAI_BAO_CAO_INDEX.KE_KHAI, eLOAI_BAO_CAO_VALUE.KE_KHAI);
            v_ct_loai_bao_cao.Add(eLOAI_BAO_CAO_INDEX.DE_NGHI_XU_LY, eLOAI_BAO_CAO_VALUE.DE_NGHI_XU_LY);
            m_cbo_loai_bao_cao.DataSource = new BindingSource(v_ct_loai_bao_cao, null);
            m_cbo_loai_bao_cao.DisplayMember = "Value";
            m_cbo_loai_bao_cao.ValueMember = "Key";
            ////load data to combobox loai tai san
            Dictionary<string, string> v_ct_loai_tai_san = new Dictionary<string, string>();
            v_ct_loai_tai_san.Add(eLOAI_TAI_SAN_INDEX.TRU_SO_LAM_VIEC, eLOAI_TAI_SAN_VALUE.TRU_SO_LAM_VIEC);
            v_ct_loai_tai_san.Add(eLOAI_TAI_SAN_INDEX.OTO, eLOAI_TAI_SAN_VALUE.OTO);
            v_ct_loai_tai_san.Add(eLOAI_TAI_SAN_INDEX.TAI_SAN_KHAC, eLOAI_TAI_SAN_VALUE.TAI_SAN_KHAC);
            m_cbo_loai_tai_san.DataSource = new BindingSource(v_ct_loai_tai_san, null);
            m_cbo_loai_tai_san.DisplayMember = "Value";
            m_cbo_loai_tai_san.ValueMember = "Key";
        }
        private void format_control()
        {
            set_define_event();
            this.KeyPreview = true;

        }
        private void set_inital_form()
        {
            format_control();
        }
        private void open_excel_file()
        {
            m_openDiaglog.Filter = "File Excel|*.xls";
            m_openDiaglog.Title = "Hãy chọn file excel";
            m_openDiaglog.FileName = "Chọn file excel";
            DialogResult result = m_openDiaglog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                m_txt_file_path.Text = m_openDiaglog.FileName;
            }
        }
        private void set_define_event()
        {
            this.Load += new EventHandler(f101_menu_tao_bao_cao_Load);
            m_cmd_open_file.Click += new EventHandler(m_cmd_open_file_Click);
        }

        #endregion

        #region Events
        private void f101_menu_tao_bao_cao_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_open_file_Click(object sender, EventArgs e)
        {
            try
            {
                open_excel_file();
                open_report();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

    }
        #endregion
}


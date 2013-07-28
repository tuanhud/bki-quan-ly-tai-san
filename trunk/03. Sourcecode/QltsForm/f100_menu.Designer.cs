namespace QltsForm {
    partial class f100_menu {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kêKhaiTrụSởLàmViệcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kêKhaiÔTôToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kêKhaiTàiSảnKhácToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đềNghịXửLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trụSởLàmViệcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ôTôToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiSảnKhácToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoToolStripMenuItem,
            this.đềNghịXửLýToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kêKhaiTrụSởLàmViệcToolStripMenuItem,
            this.kêKhaiÔTôToolStripMenuItem,
            this.kêKhaiTàiSảnKhácToolStripMenuItem});
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.báoCáoToolStripMenuItem.Text = "Kê khai";
            // 
            // kêKhaiTrụSởLàmViệcToolStripMenuItem
            // 
            this.kêKhaiTrụSởLàmViệcToolStripMenuItem.Name = "kêKhaiTrụSởLàmViệcToolStripMenuItem";
            this.kêKhaiTrụSởLàmViệcToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.kêKhaiTrụSởLàmViệcToolStripMenuItem.Text = "Trụ sở làm việc";
            // 
            // kêKhaiÔTôToolStripMenuItem
            // 
            this.kêKhaiÔTôToolStripMenuItem.Name = "kêKhaiÔTôToolStripMenuItem";
            this.kêKhaiÔTôToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.kêKhaiÔTôToolStripMenuItem.Text = "Ô tô";
            this.kêKhaiÔTôToolStripMenuItem.Click += new System.EventHandler(this.kêKhaiÔTôToolStripMenuItem_Click);
            // 
            // kêKhaiTàiSảnKhácToolStripMenuItem
            // 
            this.kêKhaiTàiSảnKhácToolStripMenuItem.Name = "kêKhaiTàiSảnKhácToolStripMenuItem";
            this.kêKhaiTàiSảnKhácToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.kêKhaiTàiSảnKhácToolStripMenuItem.Text = "Tài sản khác";
            // 
            // đềNghịXửLýToolStripMenuItem
            // 
            this.đềNghịXửLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trụSởLàmViệcToolStripMenuItem,
            this.ôTôToolStripMenuItem,
            this.tàiSảnKhácToolStripMenuItem});
            this.đềNghịXửLýToolStripMenuItem.Name = "đềNghịXửLýToolStripMenuItem";
            this.đềNghịXửLýToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.đềNghịXửLýToolStripMenuItem.Text = "Đề nghị xử lý";
            // 
            // trụSởLàmViệcToolStripMenuItem
            // 
            this.trụSởLàmViệcToolStripMenuItem.Name = "trụSởLàmViệcToolStripMenuItem";
            this.trụSởLàmViệcToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.trụSởLàmViệcToolStripMenuItem.Text = "Trụ sở làm việc";
            // 
            // ôTôToolStripMenuItem
            // 
            this.ôTôToolStripMenuItem.Name = "ôTôToolStripMenuItem";
            this.ôTôToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.ôTôToolStripMenuItem.Text = "Ô tô";
            // 
            // tàiSảnKhácToolStripMenuItem
            // 
            this.tàiSảnKhácToolStripMenuItem.Name = "tàiSảnKhácToolStripMenuItem";
            this.tàiSảnKhácToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.tàiSảnKhácToolStripMenuItem.Text = "Tài sản khác";
            // 
            // f100_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "f100_menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý tài sản";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kêKhaiTrụSởLàmViệcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kêKhaiÔTôToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kêKhaiTàiSảnKhácToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đềNghịXửLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trụSởLàmViệcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ôTôToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiSảnKhácToolStripMenuItem;
    }
}


namespace Arduino_Control
{
    partial class Monitor
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Settings = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SerialPort = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ControlPanel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuTileButton1 = new Bunifu.Framework.UI.BunifuTileButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ino2 = new Arduino_Control.ino();
            this.settings1 = new Arduino_Control.Settings();
            this.serialPortWindows1 = new Arduino_Control.SerialPortWindows();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panel1.Controls.Add(this.Settings);
            this.panel1.Controls.Add(this.SerialPort);
            this.panel1.Controls.Add(this.ControlPanel);
            this.panel1.Controls.Add(this.bunifuTileButton1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(157, 477);
            this.panel1.TabIndex = 0;
            // 
            // Settings
            // 
            this.Settings.Activecolor = System.Drawing.Color.DarkOliveGreen;
            this.Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(142)))), ((int)(((byte)(62)))));
            this.Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Settings.BorderRadius = 0;
            this.Settings.ButtonText = "設定";
            this.Settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Settings.DisabledColor = System.Drawing.Color.Gray;
            this.Settings.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Settings.Iconcolor = System.Drawing.Color.Transparent;
            this.Settings.Iconimage = ((System.Drawing.Image)(resources.GetObject("Settings.Iconimage")));
            this.Settings.Iconimage_right = null;
            this.Settings.Iconimage_right_Selected = null;
            this.Settings.Iconimage_Selected = null;
            this.Settings.IconMarginLeft = 0;
            this.Settings.IconMarginRight = 0;
            this.Settings.IconRightVisible = false;
            this.Settings.IconRightZoom = 0D;
            this.Settings.IconVisible = false;
            this.Settings.IconZoom = 0D;
            this.Settings.IsTab = false;
            this.Settings.Location = new System.Drawing.Point(0, 245);
            this.Settings.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Settings.Name = "Settings";
            this.Settings.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(142)))), ((int)(((byte)(62)))));
            this.Settings.OnHovercolor = System.Drawing.Color.DarkOliveGreen;
            this.Settings.OnHoverTextColor = System.Drawing.Color.White;
            this.Settings.selected = false;
            this.Settings.Size = new System.Drawing.Size(157, 48);
            this.Settings.TabIndex = 3;
            this.Settings.Text = "設定";
            this.Settings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Settings.Textcolor = System.Drawing.Color.White;
            this.Settings.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings.Click += new System.EventHandler(this.ChangePage);
            // 
            // SerialPort
            // 
            this.SerialPort.Activecolor = System.Drawing.Color.DarkOliveGreen;
            this.SerialPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SerialPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(142)))), ((int)(((byte)(62)))));
            this.SerialPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SerialPort.BorderRadius = 0;
            this.SerialPort.ButtonText = "串列埠視窗";
            this.SerialPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SerialPort.DisabledColor = System.Drawing.Color.Gray;
            this.SerialPort.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SerialPort.Iconcolor = System.Drawing.Color.Transparent;
            this.SerialPort.Iconimage = ((System.Drawing.Image)(resources.GetObject("SerialPort.Iconimage")));
            this.SerialPort.Iconimage_right = null;
            this.SerialPort.Iconimage_right_Selected = null;
            this.SerialPort.Iconimage_Selected = null;
            this.SerialPort.IconMarginLeft = 0;
            this.SerialPort.IconMarginRight = 0;
            this.SerialPort.IconRightVisible = false;
            this.SerialPort.IconRightZoom = 0D;
            this.SerialPort.IconVisible = false;
            this.SerialPort.IconZoom = 0D;
            this.SerialPort.IsTab = false;
            this.SerialPort.Location = new System.Drawing.Point(0, 198);
            this.SerialPort.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.SerialPort.Name = "SerialPort";
            this.SerialPort.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(142)))), ((int)(((byte)(62)))));
            this.SerialPort.OnHovercolor = System.Drawing.Color.DarkOliveGreen;
            this.SerialPort.OnHoverTextColor = System.Drawing.Color.White;
            this.SerialPort.selected = false;
            this.SerialPort.Size = new System.Drawing.Size(157, 48);
            this.SerialPort.TabIndex = 2;
            this.SerialPort.Text = "串列埠視窗";
            this.SerialPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SerialPort.Textcolor = System.Drawing.Color.White;
            this.SerialPort.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialPort.Click += new System.EventHandler(this.ChangePage);
            // 
            // ControlPanel
            // 
            this.ControlPanel.Activecolor = System.Drawing.Color.DarkOliveGreen;
            this.ControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(142)))), ((int)(((byte)(62)))));
            this.ControlPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ControlPanel.BorderRadius = 0;
            this.ControlPanel.ButtonText = "ino 修改/檢視";
            this.ControlPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ControlPanel.DisabledColor = System.Drawing.Color.Gray;
            this.ControlPanel.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ControlPanel.Iconcolor = System.Drawing.Color.Transparent;
            this.ControlPanel.Iconimage = ((System.Drawing.Image)(resources.GetObject("ControlPanel.Iconimage")));
            this.ControlPanel.Iconimage_right = null;
            this.ControlPanel.Iconimage_right_Selected = null;
            this.ControlPanel.Iconimage_Selected = null;
            this.ControlPanel.IconMarginLeft = 0;
            this.ControlPanel.IconMarginRight = 0;
            this.ControlPanel.IconRightVisible = false;
            this.ControlPanel.IconRightZoom = 0D;
            this.ControlPanel.IconVisible = false;
            this.ControlPanel.IconZoom = 0D;
            this.ControlPanel.IsTab = false;
            this.ControlPanel.Location = new System.Drawing.Point(0, 151);
            this.ControlPanel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(142)))), ((int)(((byte)(62)))));
            this.ControlPanel.OnHovercolor = System.Drawing.Color.DarkOliveGreen;
            this.ControlPanel.OnHoverTextColor = System.Drawing.Color.White;
            this.ControlPanel.selected = false;
            this.ControlPanel.Size = new System.Drawing.Size(157, 48);
            this.ControlPanel.TabIndex = 1;
            this.ControlPanel.Text = "ino 修改/檢視";
            this.ControlPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ControlPanel.Textcolor = System.Drawing.Color.White;
            this.ControlPanel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlPanel.Click += new System.EventHandler(this.ChangePage);
            // 
            // bunifuTileButton1
            // 
            this.bunifuTileButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuTileButton1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.bunifuTileButton1.color = System.Drawing.Color.DarkOliveGreen;
            this.bunifuTileButton1.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(142)))), ((int)(((byte)(62)))));
            this.bunifuTileButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTileButton1.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.bunifuTileButton1.ForeColor = System.Drawing.Color.White;
            this.bunifuTileButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuTileButton1.Image")));
            this.bunifuTileButton1.ImagePosition = 20;
            this.bunifuTileButton1.ImageZoom = 50;
            this.bunifuTileButton1.LabelPosition = 41;
            this.bunifuTileButton1.LabelText = "Monitor";
            this.bunifuTileButton1.Location = new System.Drawing.Point(0, 0);
            this.bunifuTileButton1.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuTileButton1.Name = "bunifuTileButton1";
            this.bunifuTileButton1.Size = new System.Drawing.Size(156, 141);
            this.bunifuTileButton1.TabIndex = 0;
            this.bunifuTileButton1.Click += new System.EventHandler(this.bunifuTileButton1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(783, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(750, -1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 33);
            this.button2.TabIndex = 2;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ino2
            // 
            this.ino2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ino2.Location = new System.Drawing.Point(158, 29);
            this.ino2.Name = "ino2";
            this.ino2.Size = new System.Drawing.Size(662, 445);
            this.ino2.TabIndex = 4;
            this.ino2.Load += new System.EventHandler(this.ino2_Load);
            // 
            // settings1
            // 
            this.settings1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.settings1.Location = new System.Drawing.Point(158, 29);
            this.settings1.Name = "settings1";
            this.settings1.Size = new System.Drawing.Size(662, 445);
            this.settings1.TabIndex = 3;
            this.settings1.Load += new System.EventHandler(this.settings1_Load);
            // 
            // serialPortWindows1
            // 
            this.serialPortWindows1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.serialPortWindows1.Location = new System.Drawing.Point(157, 32);
            this.serialPortWindows1.Name = "serialPortWindows1";
            this.serialPortWindows1.Size = new System.Drawing.Size(662, 445);
            this.serialPortWindows1.TabIndex = 5;
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(816, 476);
            this.Controls.Add(this.ino2);
            this.Controls.Add(this.settings1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.serialPortWindows1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Monitor";
            this.Text = "Monitor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this._headPanel_MouseDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuFlatButton ControlPanel;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton1;
        private Bunifu.Framework.UI.BunifuFlatButton Settings;
        private Bunifu.Framework.UI.BunifuFlatButton SerialPort;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Settings settings1;
        private ino ino2;
        private SerialPortWindows serialPortWindows1;
    }
}


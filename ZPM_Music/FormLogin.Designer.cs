namespace ZPM_Music
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxUser = new HZH_Controls.Controls.UCTextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ucTextBoxPwd = new HZH_Controls.Controls.UCTextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.ucBtnLogin = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtnExtReg = new HZH_Controls.Controls.UCBtnExt();
            this.ucCheckBoxPwd = new HZH_Controls.Controls.UCCheckBox();
            this.ucCheckBoxAutoLogin = new HZH_Controls.Controls.UCCheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelTop.Controls.Add(this.buttonClose);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(499, 37);
            this.panelTop.TabIndex = 0;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            this.panelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseUp);
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(469, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(30, 37);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "❌";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxUser
            // 
            this.textBoxUser.BackColor = System.Drawing.Color.Transparent;
            this.textBoxUser.ConerRadius = 5;
            this.textBoxUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxUser.DecLength = 2;
            this.textBoxUser.FillColor = System.Drawing.Color.Empty;
            this.textBoxUser.FocusBorderColor = System.Drawing.Color.LimeGreen;
            this.textBoxUser.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxUser.InputText = "";
            this.textBoxUser.InputType = HZH_Controls.TextInputType.NotControl;
            this.textBoxUser.IsFocusColor = true;
            this.textBoxUser.IsRadius = true;
            this.textBoxUser.IsShowClearBtn = true;
            this.textBoxUser.IsShowKeyboard = false;
            this.textBoxUser.IsShowRect = true;
            this.textBoxUser.IsShowSearchBtn = false;
            this.textBoxUser.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderAll_EN;
            this.textBoxUser.Location = new System.Drawing.Point(153, 163);
            this.textBoxUser.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxUser.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.textBoxUser.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Padding = new System.Windows.Forms.Padding(5);
            this.textBoxUser.PasswordChar = '\0';
            this.textBoxUser.PromptColor = System.Drawing.Color.Gray;
            this.textBoxUser.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxUser.PromptText = "输入账号";
            this.textBoxUser.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.textBoxUser.RectWidth = 1;
            this.textBoxUser.RegexPattern = "";
            this.textBoxUser.Size = new System.Drawing.Size(262, 47);
            this.textBoxUser.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(86, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "账号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(86, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 27);
            this.label2.TabIndex = 8;
            this.label2.Text = "密码:";
            // 
            // ucTextBoxPwd
            // 
            this.ucTextBoxPwd.BackColor = System.Drawing.Color.Transparent;
            this.ucTextBoxPwd.ConerRadius = 5;
            this.ucTextBoxPwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ucTextBoxPwd.DecLength = 2;
            this.ucTextBoxPwd.FillColor = System.Drawing.Color.Empty;
            this.ucTextBoxPwd.FocusBorderColor = System.Drawing.Color.LightGreen;
            this.ucTextBoxPwd.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucTextBoxPwd.InputText = "";
            this.ucTextBoxPwd.InputType = HZH_Controls.TextInputType.NotControl;
            this.ucTextBoxPwd.IsFocusColor = true;
            this.ucTextBoxPwd.IsRadius = true;
            this.ucTextBoxPwd.IsShowClearBtn = true;
            this.ucTextBoxPwd.IsShowKeyboard = false;
            this.ucTextBoxPwd.IsShowRect = true;
            this.ucTextBoxPwd.IsShowSearchBtn = false;
            this.ucTextBoxPwd.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderAll_EN;
            this.ucTextBoxPwd.Location = new System.Drawing.Point(153, 233);
            this.ucTextBoxPwd.Margin = new System.Windows.Forms.Padding(0);
            this.ucTextBoxPwd.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ucTextBoxPwd.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.ucTextBoxPwd.Name = "ucTextBoxPwd";
            this.ucTextBoxPwd.Padding = new System.Windows.Forms.Padding(5);
            this.ucTextBoxPwd.PasswordChar = '●';
            this.ucTextBoxPwd.PromptColor = System.Drawing.Color.Gray;
            this.ucTextBoxPwd.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucTextBoxPwd.PromptText = "输入密码";
            this.ucTextBoxPwd.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucTextBoxPwd.RectWidth = 1;
            this.ucTextBoxPwd.RegexPattern = "";
            this.ucTextBoxPwd.Size = new System.Drawing.Size(262, 47);
            this.ucTextBoxPwd.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(191, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 45);
            this.label3.TabIndex = 10;
            this.label3.Text = "ZPM MUSIC";
            // 
            // ucBtnLogin
            // 
            this.ucBtnLogin.BackColor = System.Drawing.Color.White;
            this.ucBtnLogin.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnLogin.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnLogin.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnLogin.BtnText = "登陆";
            this.ucBtnLogin.ConerRadius = 20;
            this.ucBtnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnLogin.EnabledMouseEffect = false;
            this.ucBtnLogin.FillColor = System.Drawing.Color.CornflowerBlue;
            this.ucBtnLogin.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnLogin.IsRadius = true;
            this.ucBtnLogin.IsShowRect = true;
            this.ucBtnLogin.IsShowTips = false;
            this.ucBtnLogin.Location = new System.Drawing.Point(273, 356);
            this.ucBtnLogin.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnLogin.Name = "ucBtnLogin";
            this.ucBtnLogin.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ucBtnLogin.RectWidth = 1;
            this.ucBtnLogin.Size = new System.Drawing.Size(107, 48);
            this.ucBtnLogin.TabIndex = 11;
            this.ucBtnLogin.TabStop = false;
            this.ucBtnLogin.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnLogin.TipsText = "";
            this.ucBtnLogin.BtnClick += new System.EventHandler(this.ucBtnLogin_BtnClick);
            // 
            // ucBtnExtReg
            // 
            this.ucBtnExtReg.BackColor = System.Drawing.Color.White;
            this.ucBtnExtReg.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnExtReg.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExtReg.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnExtReg.BtnText = "注册";
            this.ucBtnExtReg.ConerRadius = 20;
            this.ucBtnExtReg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExtReg.EnabledMouseEffect = false;
            this.ucBtnExtReg.FillColor = System.Drawing.Color.CornflowerBlue;
            this.ucBtnExtReg.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnExtReg.IsRadius = true;
            this.ucBtnExtReg.IsShowRect = true;
            this.ucBtnExtReg.IsShowTips = false;
            this.ucBtnExtReg.Location = new System.Drawing.Point(125, 356);
            this.ucBtnExtReg.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExtReg.Name = "ucBtnExtReg";
            this.ucBtnExtReg.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ucBtnExtReg.RectWidth = 1;
            this.ucBtnExtReg.Size = new System.Drawing.Size(107, 48);
            this.ucBtnExtReg.TabIndex = 12;
            this.ucBtnExtReg.TabStop = false;
            this.ucBtnExtReg.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExtReg.TipsText = "";
            this.ucBtnExtReg.BtnClick += new System.EventHandler(this.ucBtnExtReg_BtnClick);
            // 
            // ucCheckBoxPwd
            // 
            this.ucCheckBoxPwd.BackColor = System.Drawing.Color.Transparent;
            this.ucCheckBoxPwd.Checked = false;
            this.ucCheckBoxPwd.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.ucCheckBoxPwd.Location = new System.Drawing.Point(91, 297);
            this.ucCheckBoxPwd.Name = "ucCheckBoxPwd";
            this.ucCheckBoxPwd.Padding = new System.Windows.Forms.Padding(1);
            this.ucCheckBoxPwd.Size = new System.Drawing.Size(176, 30);
            this.ucCheckBoxPwd.TabIndex = 13;
            this.ucCheckBoxPwd.TextValue = "记住账号密码";
            this.ucCheckBoxPwd.CheckedChangeEvent += new System.EventHandler(this.ucCheckBoxPwd_CheckedChangeEvent);
            // 
            // ucCheckBoxAutoLogin
            // 
            this.ucCheckBoxAutoLogin.BackColor = System.Drawing.Color.Transparent;
            this.ucCheckBoxAutoLogin.Checked = false;
            this.ucCheckBoxAutoLogin.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.ucCheckBoxAutoLogin.Location = new System.Drawing.Point(273, 297);
            this.ucCheckBoxAutoLogin.Name = "ucCheckBoxAutoLogin";
            this.ucCheckBoxAutoLogin.Padding = new System.Windows.Forms.Padding(1);
            this.ucCheckBoxAutoLogin.Size = new System.Drawing.Size(130, 30);
            this.ucCheckBoxAutoLogin.TabIndex = 14;
            this.ucCheckBoxAutoLogin.TextValue = "自动登陆";
            this.ucCheckBoxAutoLogin.CheckedChangeEvent += new System.EventHandler(this.ucCheckBoxAutoLogin_CheckedChangeEvent);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ZPM_Music.Properties.Resources.音乐;
            this.pictureBox1.Location = new System.Drawing.Point(91, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(499, 519);
            this.Controls.Add(this.ucCheckBoxAutoLogin);
            this.Controls.Add(this.ucCheckBoxPwd);
            this.Controls.Add(this.ucBtnLogin);
            this.Controls.Add(this.ucBtnExtReg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucTextBoxPwd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLogin";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonClose;
        private HZH_Controls.Controls.UCTextBoxEx textBoxUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private HZH_Controls.Controls.UCTextBoxEx ucTextBoxPwd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private HZH_Controls.Controls.UCBtnExt ucBtnLogin;
        private HZH_Controls.Controls.UCBtnExt ucBtnExtReg;
        private HZH_Controls.Controls.UCCheckBox ucCheckBoxPwd;
        private HZH_Controls.Controls.UCCheckBox ucCheckBoxAutoLogin;
    }
}
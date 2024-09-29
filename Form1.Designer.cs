namespace Kaburra
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelLog = new System.Windows.Forms.Panel();
            this.pictureBoxLoading = new System.Windows.Forms.PictureBox();
            this.listViewLog = new System.Windows.Forms.ListView();
            this.Log = new System.Windows.Forms.ColumnHeader();
            this.panelForm = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageHome = new System.Windows.Forms.TabPage();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.textBoxAddMail = new System.Windows.Forms.TextBox();
            this.groupBoxPayload = new System.Windows.Forms.GroupBox();
            this.textBoxZipPasswd = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.radioButNoAtt = new System.Windows.Forms.RadioButton();
            this.textBoxAttName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonInsertClickTrack = new System.Windows.Forms.Button();
            this.radioAsDownLink = new System.Windows.Forms.RadioButton();
            this.radioAsAttachment = new System.Windows.Forms.RadioButton();
            this.comboBoxAttach = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonOpenBody = new System.Windows.Forms.Button();
            this.textBoxBodyPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonInBulk = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonRemoveMail = new System.Windows.Forms.Button();
            this.buttonAddMail = new System.Windows.Forms.Button();
            this.groupBoxMailSetting = new System.Windows.Forms.GroupBox();
            this.pictureBoxCheckComplete = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxDisplayNm = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxSMTPPort = new System.Windows.Forms.TextBox();
            this.textBoxSMTPSRV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMailPasswd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTrackingDmain = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.listViewMail = new System.Windows.Forms.ListView();
            this.Email = new System.Windows.Forms.ColumnHeader();
            this.tabPageSentItem = new System.Windows.Forms.TabPage();
            this.panelResultPage = new System.Windows.Forms.Panel();
            this.dataGridViewSent = new System.Windows.Forms.DataGridView();
            this.tabPageResult = new System.Windows.Forms.TabPage();
            this.dataGridViewOpen = new System.Windows.Forms.DataGridView();
            this.tabPageStatistic = new System.Windows.Forms.TabPage();
            this.labelmostAttType = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.labelmostAtt = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.labeltotalAttOpen = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.labeltotalAttSent = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.labelmostSubject = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.labeltotalOpen = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.labeltotalSent = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panelAttStat = new System.Windows.Forms.Panel();
            this.panelMailStat = new System.Windows.Forms.Panel();
            this.openMailFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panelLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).BeginInit();
            this.panelForm.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.groupBoxPayload.SuspendLayout();
            this.groupBoxMailSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCheckComplete)).BeginInit();
            this.tabPageSentItem.SuspendLayout();
            this.panelResultPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSent)).BeginInit();
            this.tabPageResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOpen)).BeginInit();
            this.tabPageStatistic.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLog
            // 
            this.panelLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLog.Controls.Add(this.pictureBoxLoading);
            this.panelLog.Controls.Add(this.listViewLog);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLog.Location = new System.Drawing.Point(0, 673);
            this.panelLog.Name = "panelLog";
            this.panelLog.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.panelLog.Size = new System.Drawing.Size(1857, 143);
            this.panelLog.TabIndex = 0;
            // 
            // pictureBoxLoading
            // 
            this.pictureBoxLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxLoading.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxLoading.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLoading.Image")));
            this.pictureBoxLoading.Location = new System.Drawing.Point(1778, 69);
            this.pictureBoxLoading.Name = "pictureBoxLoading";
            this.pictureBoxLoading.Size = new System.Drawing.Size(68, 60);
            this.pictureBoxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLoading.TabIndex = 14;
            this.pictureBoxLoading.TabStop = false;
            // 
            // listViewLog
            // 
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Log});
            this.listViewLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewLog.Location = new System.Drawing.Point(10, 5);
            this.listViewLog.Margin = new System.Windows.Forms.Padding(10);
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.Size = new System.Drawing.Size(1843, 129);
            this.listViewLog.TabIndex = 0;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.Details;
            // 
            // Log
            // 
            this.Log.Text = "Log";
            this.Log.Width = 800;
            // 
            // panelForm
            // 
            this.panelForm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelForm.Controls.Add(this.tabControl1);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(1857, 673);
            this.panelForm.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageHome);
            this.tabControl1.Controls.Add(this.tabPageSentItem);
            this.tabControl1.Controls.Add(this.tabPageResult);
            this.tabControl1.Controls.Add(this.tabPageStatistic);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1853, 669);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageHome
            // 
            this.tabPageHome.Controls.Add(this.webView21);
            this.tabPageHome.Controls.Add(this.textBoxAddMail);
            this.tabPageHome.Controls.Add(this.groupBoxPayload);
            this.tabPageHome.Controls.Add(this.buttonInBulk);
            this.tabPageHome.Controls.Add(this.buttonRemoveMail);
            this.tabPageHome.Controls.Add(this.buttonAddMail);
            this.tabPageHome.Controls.Add(this.groupBoxMailSetting);
            this.tabPageHome.Controls.Add(this.listViewMail);
            this.tabPageHome.ImageKey = "icons8-home-144.png";
            this.tabPageHome.Location = new System.Drawing.Point(4, 34);
            this.tabPageHome.Name = "tabPageHome";
            this.tabPageHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHome.Size = new System.Drawing.Size(1845, 631);
            this.tabPageHome.TabIndex = 0;
            this.tabPageHome.Text = "Home";
            this.tabPageHome.UseVisualStyleBackColor = true;
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Dock = System.Windows.Forms.DockStyle.Right;
            this.webView21.Location = new System.Drawing.Point(1062, 3);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(780, 625);
            this.webView21.TabIndex = 13;
            this.webView21.ZoomFactor = 1D;
            // 
            // textBoxAddMail
            // 
            this.textBoxAddMail.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxAddMail.Location = new System.Drawing.Point(3, 16);
            this.textBoxAddMail.Name = "textBoxAddMail";
            this.textBoxAddMail.Size = new System.Drawing.Size(355, 27);
            this.textBoxAddMail.TabIndex = 12;
            this.textBoxAddMail.Visible = false;
            this.textBoxAddMail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAddMail_KeyPress);
            // 
            // groupBoxPayload
            // 
            this.groupBoxPayload.Controls.Add(this.textBoxZipPasswd);
            this.groupBoxPayload.Controls.Add(this.label13);
            this.groupBoxPayload.Controls.Add(this.textBoxDelay);
            this.groupBoxPayload.Controls.Add(this.label11);
            this.groupBoxPayload.Controls.Add(this.radioButNoAtt);
            this.groupBoxPayload.Controls.Add(this.textBoxAttName);
            this.groupBoxPayload.Controls.Add(this.label9);
            this.groupBoxPayload.Controls.Add(this.buttonSend);
            this.groupBoxPayload.Controls.Add(this.buttonInsertClickTrack);
            this.groupBoxPayload.Controls.Add(this.radioAsDownLink);
            this.groupBoxPayload.Controls.Add(this.radioAsAttachment);
            this.groupBoxPayload.Controls.Add(this.comboBoxAttach);
            this.groupBoxPayload.Controls.Add(this.label7);
            this.groupBoxPayload.Controls.Add(this.buttonOpenBody);
            this.groupBoxPayload.Controls.Add(this.textBoxBodyPath);
            this.groupBoxPayload.Controls.Add(this.label6);
            this.groupBoxPayload.Controls.Add(this.textBoxSubject);
            this.groupBoxPayload.Controls.Add(this.label5);
            this.groupBoxPayload.Location = new System.Drawing.Point(390, 343);
            this.groupBoxPayload.Name = "groupBoxPayload";
            this.groupBoxPayload.Size = new System.Drawing.Size(666, 339);
            this.groupBoxPayload.TabIndex = 2;
            this.groupBoxPayload.TabStop = false;
            this.groupBoxPayload.Text = "Payload Setting";
            // 
            // textBoxZipPasswd
            // 
            this.textBoxZipPasswd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxZipPasswd.Location = new System.Drawing.Point(519, 163);
            this.textBoxZipPasswd.Name = "textBoxZipPasswd";
            this.textBoxZipPasswd.PlaceholderText = "In Second";
            this.textBoxZipPasswd.Size = new System.Drawing.Size(87, 27);
            this.textBoxZipPasswd.TabIndex = 26;
            this.textBoxZipPasswd.Text = "123456";
            this.textBoxZipPasswd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(520, 139);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 20);
            this.label13.TabIndex = 25;
            this.label13.Text = "Zip Passwd";
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxDelay.Location = new System.Drawing.Point(519, 47);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.PlaceholderText = "In Second";
            this.textBoxDelay.Size = new System.Drawing.Size(87, 27);
            this.textBoxDelay.TabIndex = 24;
            this.textBoxDelay.Text = "5";
            this.textBoxDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(520, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Delay Time";
            // 
            // radioButNoAtt
            // 
            this.radioButNoAtt.AutoSize = true;
            this.radioButNoAtt.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButNoAtt.Location = new System.Drawing.Point(138, 196);
            this.radioButNoAtt.Name = "radioButNoAtt";
            this.radioButNoAtt.Size = new System.Drawing.Size(116, 21);
            this.radioButNoAtt.TabIndex = 22;
            this.radioButNoAtt.Text = "No Attachment";
            this.radioButNoAtt.UseVisualStyleBackColor = true;
            this.radioButNoAtt.CheckedChanged += new System.EventHandler(this.radioButNoAtt_CheckedChanged);
            // 
            // textBoxAttName
            // 
            this.textBoxAttName.Location = new System.Drawing.Point(34, 243);
            this.textBoxAttName.Name = "textBoxAttName";
            this.textBoxAttName.PlaceholderText = "Example 01 | Report | Invoice | * without extension";
            this.textBoxAttName.Size = new System.Drawing.Size(459, 27);
            this.textBoxAttName.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(34, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Attachment Name";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(524, 293);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(126, 29);
            this.buttonSend.TabIndex = 19;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonInsertClickTrack
            // 
            this.buttonInsertClickTrack.Enabled = false;
            this.buttonInsertClickTrack.Location = new System.Drawing.Point(512, 241);
            this.buttonInsertClickTrack.Name = "buttonInsertClickTrack";
            this.buttonInsertClickTrack.Size = new System.Drawing.Size(94, 29);
            this.buttonInsertClickTrack.TabIndex = 12;
            this.buttonInsertClickTrack.Text = "Insert";
            this.buttonInsertClickTrack.UseVisualStyleBackColor = true;
            // 
            // radioAsDownLink
            // 
            this.radioAsDownLink.AutoSize = true;
            this.radioAsDownLink.Enabled = false;
            this.radioAsDownLink.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioAsDownLink.Location = new System.Drawing.Point(474, 196);
            this.radioAsDownLink.Name = "radioAsDownLink";
            this.radioAsDownLink.Size = new System.Drawing.Size(132, 21);
            this.radioAsDownLink.TabIndex = 17;
            this.radioAsDownLink.Text = "As Download Link";
            this.radioAsDownLink.UseVisualStyleBackColor = true;
            // 
            // radioAsAttachment
            // 
            this.radioAsAttachment.AutoSize = true;
            this.radioAsAttachment.Checked = true;
            this.radioAsAttachment.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioAsAttachment.Location = new System.Drawing.Point(316, 196);
            this.radioAsAttachment.Name = "radioAsAttachment";
            this.radioAsAttachment.Size = new System.Drawing.Size(141, 21);
            this.radioAsAttachment.TabIndex = 16;
            this.radioAsAttachment.TabStop = true;
            this.radioAsAttachment.Text = "As Mail Attachment";
            this.radioAsAttachment.UseVisualStyleBackColor = true;
            // 
            // comboBoxAttach
            // 
            this.comboBoxAttach.FormattingEnabled = true;
            this.comboBoxAttach.Items.AddRange(new object[] {
            "00: .doc file with VBA macros",
            "01: Shortcut - LNK file with PDF Icon (in Zip)",
            "02: MS-Word exe Icon Side-Loading (in Zip)",
            "03: Adobe-PDF exe Icon Side-Loading (in Zip)"});
            this.comboBoxAttach.Location = new System.Drawing.Point(34, 162);
            this.comboBoxAttach.Name = "comboBoxAttach";
            this.comboBoxAttach.Size = new System.Drawing.Size(459, 28);
            this.comboBoxAttach.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(34, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Attachment Type";
            // 
            // buttonOpenBody
            // 
            this.buttonOpenBody.Location = new System.Drawing.Point(548, 98);
            this.buttonOpenBody.Name = "buttonOpenBody";
            this.buttonOpenBody.Size = new System.Drawing.Size(59, 29);
            this.buttonOpenBody.TabIndex = 10;
            this.buttonOpenBody.Text = "...";
            this.buttonOpenBody.UseVisualStyleBackColor = true;
            this.buttonOpenBody.Click += new System.EventHandler(this.buttonOpenBody_Click);
            // 
            // textBoxBodyPath
            // 
            this.textBoxBodyPath.Location = new System.Drawing.Point(34, 100);
            this.textBoxBodyPath.Name = "textBoxBodyPath";
            this.textBoxBodyPath.PlaceholderText = "Body as HTML: Path to HTML file";
            this.textBoxBodyPath.Size = new System.Drawing.Size(508, 27);
            this.textBoxBodyPath.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(34, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Mail Body\r\n";
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Location = new System.Drawing.Point(34, 47);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(459, 27);
            this.textBoxSubject.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(34, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mail Subject";
            // 
            // buttonInBulk
            // 
            this.buttonInBulk.FlatAppearance.BorderSize = 0;
            this.buttonInBulk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInBulk.ImageKey = "icons8-stack-of-paper-96.png";
            this.buttonInBulk.ImageList = this.imageList1;
            this.buttonInBulk.Location = new System.Drawing.Point(367, 86);
            this.buttonInBulk.Name = "buttonInBulk";
            this.buttonInBulk.Size = new System.Drawing.Size(33, 29);
            this.buttonInBulk.TabIndex = 4;
            this.buttonInBulk.UseVisualStyleBackColor = true;
            this.buttonInBulk.Click += new System.EventHandler(this.buttonInBulk_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Statistic.png");
            this.imageList1.Images.SetKeyName(1, "icons8-home-144.png");
            this.imageList1.Images.SetKeyName(2, "icons8-delivered-box-96.png");
            this.imageList1.Images.SetKeyName(3, "Result-96.png");
            this.imageList1.Images.SetKeyName(4, "icons8-graph-96.png");
            this.imageList1.Images.SetKeyName(5, "icons8-minus-96.png");
            this.imageList1.Images.SetKeyName(6, "icons8-plus-96.png");
            this.imageList1.Images.SetKeyName(7, "icons8-stack-of-paper-96.png");
            // 
            // buttonRemoveMail
            // 
            this.buttonRemoveMail.FlatAppearance.BorderSize = 0;
            this.buttonRemoveMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveMail.ImageKey = "icons8-minus-96.png";
            this.buttonRemoveMail.ImageList = this.imageList1;
            this.buttonRemoveMail.Location = new System.Drawing.Point(367, 51);
            this.buttonRemoveMail.Name = "buttonRemoveMail";
            this.buttonRemoveMail.Size = new System.Drawing.Size(33, 29);
            this.buttonRemoveMail.TabIndex = 3;
            this.buttonRemoveMail.UseVisualStyleBackColor = true;
            this.buttonRemoveMail.Click += new System.EventHandler(this.buttonRemoveMail_Click);
            // 
            // buttonAddMail
            // 
            this.buttonAddMail.FlatAppearance.BorderSize = 0;
            this.buttonAddMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddMail.ImageKey = "icons8-plus-96.png";
            this.buttonAddMail.ImageList = this.imageList1;
            this.buttonAddMail.Location = new System.Drawing.Point(367, 16);
            this.buttonAddMail.Name = "buttonAddMail";
            this.buttonAddMail.Size = new System.Drawing.Size(33, 29);
            this.buttonAddMail.TabIndex = 2;
            this.buttonAddMail.UseVisualStyleBackColor = true;
            this.buttonAddMail.Click += new System.EventHandler(this.buttonAddMail_Click);
            // 
            // groupBoxMailSetting
            // 
            this.groupBoxMailSetting.Controls.Add(this.pictureBoxCheckComplete);
            this.groupBoxMailSetting.Controls.Add(this.label10);
            this.groupBoxMailSetting.Controls.Add(this.textBoxDisplayNm);
            this.groupBoxMailSetting.Controls.Add(this.label8);
            this.groupBoxMailSetting.Controls.Add(this.textBoxSMTPPort);
            this.groupBoxMailSetting.Controls.Add(this.textBoxSMTPSRV);
            this.groupBoxMailSetting.Controls.Add(this.label4);
            this.groupBoxMailSetting.Controls.Add(this.textBoxMailPasswd);
            this.groupBoxMailSetting.Controls.Add(this.label3);
            this.groupBoxMailSetting.Controls.Add(this.textBoxEmail);
            this.groupBoxMailSetting.Controls.Add(this.label2);
            this.groupBoxMailSetting.Controls.Add(this.textBoxTrackingDmain);
            this.groupBoxMailSetting.Controls.Add(this.label1);
            this.groupBoxMailSetting.Controls.Add(this.buttonCheck);
            this.groupBoxMailSetting.Location = new System.Drawing.Point(460, 16);
            this.groupBoxMailSetting.Name = "groupBoxMailSetting";
            this.groupBoxMailSetting.Size = new System.Drawing.Size(596, 311);
            this.groupBoxMailSetting.TabIndex = 1;
            this.groupBoxMailSetting.TabStop = false;
            this.groupBoxMailSetting.Text = "Sender Setting";
            // 
            // pictureBoxCheckComplete
            // 
            this.pictureBoxCheckComplete.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCheckComplete.Image")));
            this.pictureBoxCheckComplete.Location = new System.Drawing.Point(435, 259);
            this.pictureBoxCheckComplete.Name = "pictureBoxCheckComplete";
            this.pictureBoxCheckComplete.Size = new System.Drawing.Size(55, 46);
            this.pictureBoxCheckComplete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCheckComplete.TabIndex = 13;
            this.pictureBoxCheckComplete.TabStop = false;
            this.pictureBoxCheckComplete.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(454, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "Port";
            // 
            // textBoxDisplayNm
            // 
            this.textBoxDisplayNm.Location = new System.Drawing.Point(306, 102);
            this.textBoxDisplayNm.Name = "textBoxDisplayNm";
            this.textBoxDisplayNm.PlaceholderText = "User001 Account";
            this.textBoxDisplayNm.Size = new System.Drawing.Size(231, 27);
            this.textBoxDisplayNm.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(306, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Display Name";
            // 
            // textBoxSMTPPort
            // 
            this.textBoxSMTPPort.Location = new System.Drawing.Point(454, 226);
            this.textBoxSMTPPort.Name = "textBoxSMTPPort";
            this.textBoxSMTPPort.Size = new System.Drawing.Size(83, 27);
            this.textBoxSMTPPort.TabIndex = 9;
            this.textBoxSMTPPort.Text = "587";
            this.textBoxSMTPPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSMTPSRV
            // 
            this.textBoxSMTPSRV.Location = new System.Drawing.Point(32, 226);
            this.textBoxSMTPSRV.Name = "textBoxSMTPSRV";
            this.textBoxSMTPSRV.PlaceholderText = "SMTP Server";
            this.textBoxSMTPSRV.Size = new System.Drawing.Size(390, 27);
            this.textBoxSMTPSRV.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(32, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "SMTP SRV";
            // 
            // textBoxMailPasswd
            // 
            this.textBoxMailPasswd.Location = new System.Drawing.Point(32, 164);
            this.textBoxMailPasswd.Name = "textBoxMailPasswd";
            this.textBoxMailPasswd.Size = new System.Drawing.Size(505, 27);
            this.textBoxMailPasswd.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(32, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mail Password";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(32, 102);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.PlaceholderText = "U001@zerosalarium.loca";
            this.textBoxEmail.Size = new System.Drawing.Size(255, 27);
            this.textBoxEmail.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(32, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email";
            // 
            // textBoxTrackingDmain
            // 
            this.textBoxTrackingDmain.Location = new System.Drawing.Point(32, 48);
            this.textBoxTrackingDmain.Name = "textBoxTrackingDmain";
            this.textBoxTrackingDmain.PlaceholderText = "https::/zerosalarium.loca";
            this.textBoxTrackingDmain.Size = new System.Drawing.Size(505, 27);
            this.textBoxTrackingDmain.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(32, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tracking Domain";
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(496, 274);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(94, 29);
            this.buttonCheck.TabIndex = 0;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // listViewMail
            // 
            this.listViewMail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Email});
            this.listViewMail.Dock = System.Windows.Forms.DockStyle.Left;
            this.listViewMail.Location = new System.Drawing.Point(3, 3);
            this.listViewMail.Name = "listViewMail";
            this.listViewMail.Size = new System.Drawing.Size(358, 625);
            this.listViewMail.TabIndex = 0;
            this.listViewMail.UseCompatibleStateImageBehavior = false;
            this.listViewMail.View = System.Windows.Forms.View.Details;
            // 
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.Width = 600;
            // 
            // tabPageSentItem
            // 
            this.tabPageSentItem.Controls.Add(this.panelResultPage);
            this.tabPageSentItem.ImageKey = "icons8-delivered-box-96.png";
            this.tabPageSentItem.Location = new System.Drawing.Point(4, 34);
            this.tabPageSentItem.Name = "tabPageSentItem";
            this.tabPageSentItem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSentItem.Size = new System.Drawing.Size(1845, 631);
            this.tabPageSentItem.TabIndex = 1;
            this.tabPageSentItem.Text = "Sent Item";
            this.tabPageSentItem.UseVisualStyleBackColor = true;
            this.tabPageSentItem.Enter += new System.EventHandler(this.tabPageSentItem_Enter);
            // 
            // panelResultPage
            // 
            this.panelResultPage.Controls.Add(this.dataGridViewSent);
            this.panelResultPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResultPage.Location = new System.Drawing.Point(3, 3);
            this.panelResultPage.Name = "panelResultPage";
            this.panelResultPage.Size = new System.Drawing.Size(1839, 625);
            this.panelResultPage.TabIndex = 0;
            // 
            // dataGridViewSent
            // 
            this.dataGridViewSent.AllowUserToAddRows = false;
            this.dataGridViewSent.AllowUserToDeleteRows = false;
            this.dataGridViewSent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSent.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSent.Name = "dataGridViewSent";
            this.dataGridViewSent.RowHeadersWidth = 51;
            this.dataGridViewSent.RowTemplate.Height = 29;
            this.dataGridViewSent.Size = new System.Drawing.Size(1839, 625);
            this.dataGridViewSent.TabIndex = 0;
            // 
            // tabPageResult
            // 
            this.tabPageResult.Controls.Add(this.dataGridViewOpen);
            this.tabPageResult.ImageKey = "Result-96.png";
            this.tabPageResult.Location = new System.Drawing.Point(4, 34);
            this.tabPageResult.Name = "tabPageResult";
            this.tabPageResult.Size = new System.Drawing.Size(1845, 631);
            this.tabPageResult.TabIndex = 2;
            this.tabPageResult.Text = "Result";
            this.tabPageResult.UseVisualStyleBackColor = true;
            this.tabPageResult.Enter += new System.EventHandler(this.tabPageResult_Enter);
            // 
            // dataGridViewOpen
            // 
            this.dataGridViewOpen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOpen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOpen.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewOpen.Name = "dataGridViewOpen";
            this.dataGridViewOpen.RowHeadersWidth = 51;
            this.dataGridViewOpen.RowTemplate.Height = 29;
            this.dataGridViewOpen.Size = new System.Drawing.Size(1845, 631);
            this.dataGridViewOpen.TabIndex = 0;
            // 
            // tabPageStatistic
            // 
            this.tabPageStatistic.Controls.Add(this.labelmostAttType);
            this.tabPageStatistic.Controls.Add(this.label25);
            this.tabPageStatistic.Controls.Add(this.labelmostAtt);
            this.tabPageStatistic.Controls.Add(this.label23);
            this.tabPageStatistic.Controls.Add(this.labeltotalAttOpen);
            this.tabPageStatistic.Controls.Add(this.label21);
            this.tabPageStatistic.Controls.Add(this.labeltotalAttSent);
            this.tabPageStatistic.Controls.Add(this.label19);
            this.tabPageStatistic.Controls.Add(this.labelmostSubject);
            this.tabPageStatistic.Controls.Add(this.label17);
            this.tabPageStatistic.Controls.Add(this.labeltotalOpen);
            this.tabPageStatistic.Controls.Add(this.label15);
            this.tabPageStatistic.Controls.Add(this.labeltotalSent);
            this.tabPageStatistic.Controls.Add(this.label12);
            this.tabPageStatistic.Controls.Add(this.panelAttStat);
            this.tabPageStatistic.Controls.Add(this.panelMailStat);
            this.tabPageStatistic.ImageKey = "icons8-graph-96.png";
            this.tabPageStatistic.Location = new System.Drawing.Point(4, 34);
            this.tabPageStatistic.Name = "tabPageStatistic";
            this.tabPageStatistic.Size = new System.Drawing.Size(1845, 631);
            this.tabPageStatistic.TabIndex = 3;
            this.tabPageStatistic.Text = "Statistic";
            this.tabPageStatistic.UseVisualStyleBackColor = true;
            this.tabPageStatistic.Enter += new System.EventHandler(this.tabPageStatistic_Enter);
            // 
            // labelmostAttType
            // 
            this.labelmostAttType.AutoSize = true;
            this.labelmostAttType.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelmostAttType.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelmostAttType.Location = new System.Drawing.Point(758, 580);
            this.labelmostAttType.Name = "labelmostAttType";
            this.labelmostAttType.Size = new System.Drawing.Size(42, 25);
            this.labelmostAttType.TabIndex = 15;
            this.labelmostAttType.Text = "100";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label25.Location = new System.Drawing.Point(758, 538);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(335, 32);
            this.label25.TabIndex = 14;
            this.label25.Text = "Most Open Attachment Type:";
            // 
            // labelmostAtt
            // 
            this.labelmostAtt.AutoSize = true;
            this.labelmostAtt.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelmostAtt.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelmostAtt.Location = new System.Drawing.Point(758, 497);
            this.labelmostAtt.Name = "labelmostAtt";
            this.labelmostAtt.Size = new System.Drawing.Size(42, 25);
            this.labelmostAtt.TabIndex = 13;
            this.labelmostAtt.Text = "100";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label23.Location = new System.Drawing.Point(758, 456);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(277, 32);
            this.label23.TabIndex = 12;
            this.label23.Text = "Most Open Attachment:";
            // 
            // labeltotalAttOpen
            // 
            this.labeltotalAttOpen.AutoSize = true;
            this.labeltotalAttOpen.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labeltotalAttOpen.ForeColor = System.Drawing.Color.OrangeRed;
            this.labeltotalAttOpen.Location = new System.Drawing.Point(1040, 405);
            this.labeltotalAttOpen.Name = "labeltotalAttOpen";
            this.labeltotalAttOpen.Size = new System.Drawing.Size(50, 32);
            this.labeltotalAttOpen.TabIndex = 11;
            this.labeltotalAttOpen.Text = "100";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label21.Location = new System.Drawing.Point(758, 405);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(275, 32);
            this.label21.TabIndex = 10;
            this.label21.Text = "Total Attachment Open:";
            // 
            // labeltotalAttSent
            // 
            this.labeltotalAttSent.AutoSize = true;
            this.labeltotalAttSent.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labeltotalAttSent.Location = new System.Drawing.Point(1040, 355);
            this.labeltotalAttSent.Name = "labeltotalAttSent";
            this.labeltotalAttSent.Size = new System.Drawing.Size(50, 32);
            this.labeltotalAttSent.TabIndex = 9;
            this.labeltotalAttSent.Text = "100";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(758, 355);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(265, 32);
            this.label19.TabIndex = 8;
            this.label19.Text = "Total Attachment Sent:";
            // 
            // labelmostSubject
            // 
            this.labelmostSubject.AutoSize = true;
            this.labelmostSubject.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelmostSubject.ForeColor = System.Drawing.Color.Goldenrod;
            this.labelmostSubject.Location = new System.Drawing.Point(758, 222);
            this.labelmostSubject.Name = "labelmostSubject";
            this.labelmostSubject.Size = new System.Drawing.Size(42, 25);
            this.labelmostSubject.TabIndex = 7;
            this.labelmostSubject.Text = "100";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(758, 175);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(282, 32);
            this.label17.TabIndex = 6;
            this.label17.Text = "Most Open Mail Subject:";
            // 
            // labeltotalOpen
            // 
            this.labeltotalOpen.AutoSize = true;
            this.labeltotalOpen.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labeltotalOpen.ForeColor = System.Drawing.Color.Goldenrod;
            this.labeltotalOpen.Location = new System.Drawing.Point(998, 121);
            this.labeltotalOpen.Name = "labeltotalOpen";
            this.labeltotalOpen.Size = new System.Drawing.Size(50, 32);
            this.labeltotalOpen.TabIndex = 5;
            this.labeltotalOpen.Text = "100";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(758, 121);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(204, 32);
            this.label15.TabIndex = 4;
            this.label15.Text = "Total Email Open:";
            // 
            // labeltotalSent
            // 
            this.labeltotalSent.AutoSize = true;
            this.labeltotalSent.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labeltotalSent.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labeltotalSent.Location = new System.Drawing.Point(998, 62);
            this.labeltotalSent.Name = "labeltotalSent";
            this.labeltotalSent.Size = new System.Drawing.Size(50, 32);
            this.labeltotalSent.TabIndex = 3;
            this.labeltotalSent.Text = "100";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(758, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(194, 32);
            this.label12.TabIndex = 2;
            this.label12.Text = "Total Email Sent:";
            // 
            // panelAttStat
            // 
            this.panelAttStat.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelAttStat.Location = new System.Drawing.Point(1202, 0);
            this.panelAttStat.Name = "panelAttStat";
            this.panelAttStat.Size = new System.Drawing.Size(643, 631);
            this.panelAttStat.TabIndex = 1;
            // 
            // panelMailStat
            // 
            this.panelMailStat.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMailStat.Location = new System.Drawing.Point(0, 0);
            this.panelMailStat.Name = "panelMailStat";
            this.panelMailStat.Size = new System.Drawing.Size(643, 631);
            this.panelMailStat.TabIndex = 0;
            // 
            // openMailFileDialog
            // 
            this.openMailFileDialog.FileName = "openMailFileDialog";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1878, 750);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Kaburra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageHome.ResumeLayout(false);
            this.tabPageHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.groupBoxPayload.ResumeLayout(false);
            this.groupBoxPayload.PerformLayout();
            this.groupBoxMailSetting.ResumeLayout(false);
            this.groupBoxMailSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCheckComplete)).EndInit();
            this.tabPageSentItem.ResumeLayout(false);
            this.panelResultPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSent)).EndInit();
            this.tabPageResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOpen)).EndInit();
            this.tabPageStatistic.ResumeLayout(false);
            this.tabPageStatistic.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelLog;
        private ListView listViewLog;
        private Panel panelForm;
        private TabControl tabControl1;
        private TabPage tabPageHome;
        private TabPage tabPageSentItem;
        private ListView listViewMail;
        private Button buttonInBulk;
        private Button buttonRemoveMail;
        private Button buttonAddMail;
        private GroupBox groupBoxMailSetting;
        private GroupBox groupBoxPayload;
        private TextBox textBoxSMTPPort;
        private TextBox textBoxSMTPSRV;
        private Label label4;
        private TextBox textBoxMailPasswd;
        private Label label3;
        private TextBox textBoxEmail;
        private Label label2;
        private TextBox textBoxTrackingDmain;
        private Label label1;
        private Button buttonCheck;
        private TextBox textBoxSubject;
        private Label label5;
        private RadioButton radioAsDownLink;
        private RadioButton radioAsAttachment;
        private ComboBox comboBoxAttach;
        private Label label7;
        private Button buttonOpenBody;
        private TextBox textBoxBodyPath;
        private Label label6;
        private Button buttonSend;
        private Button buttonInsertClickTrack;
        private TextBox textBoxDisplayNm;
        private Label label8;
        //private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Panel panelResultPage;
        private TabPage tabPageResult;
        private TextBox textBoxAddMail;
        private ColumnHeader Log;
        private ColumnHeader Email;
        private OpenFileDialog openMailFileDialog;
        private TextBox textBoxAttName;
        private Label label9;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private RadioButton radioButNoAtt;
        private Label label10;
        private DataGridView dataGridViewSent;
        private DataGridView dataGridViewOpen;
        private TabPage tabPageStatistic;
        private Panel panelAttStat;
        private Panel panelMailStat;
        private TextBox textBoxDelay;
        private Label label11;
        private Label labeltotalSent;
        private Label label12;
        private Label labelmostAttType;
        private Label label25;
        private Label labelmostAtt;
        private Label label23;
        private Label labeltotalAttOpen;
        private Label label21;
        private Label labeltotalAttSent;
        private Label label19;
        private Label labelmostSubject;
        private Label label17;
        private Label labeltotalOpen;
        private Label label15;
        private ImageList imageList1;
        private PictureBox pictureBoxCheckComplete;
        private TextBox textBoxZipPasswd;
        private Label label13;
        private PictureBox pictureBoxLoading;
    }
}
using Microsoft.Web.WebView2.Core;
using System.Data;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace Kaburra
{
    public partial class Form1 : Form
    {
        private HomePage hPage = new();
        private WebUtils webUtils = new();
        private DatabaseIO dtaIO = new();
        //Sử dụng Singleton cho việc ghi log
        private static Form1 _instance;

        public static Form1 Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new Form1();
                }
                return _instance;
            }
        }

        public Form1()
        {
            _instance = this;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // Set the form to start maximized
            InitializeWebView();

            //init variable
            webUtils.InitClient();

        }

        private void SetSize()
        {
            panelForm.Height = ((this.Height - 50) / 4) * 3;
            panelLog.Height = (this.Height - 50) / 4;
            //panelLog.Height = panelLog.Height - 40;
            tabControl1.Height = panelForm.Height;
            listViewLog.Columns[0].Width = panelLog.Width - 50;
        }

        void SetTestInfo()
        {
            textBoxTrackingDmain.Text = @"https://cdn.zerosalarium.loca";
            textBoxEmail.Text = @"User001@zerosalarium.loca";
            textBoxMailPasswd.Text = @"nko890MLP";
            textBoxSMTPSRV.Text = @"w-exchange.zerosalarium.loca";
            textBoxDisplayNm.Text = "User001 USR";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Loading(true);
            SetSize();
            comboBoxAttach.SelectedIndex = 0;
            Logging("Warning:", "This is warning");
            Logging("Error:", "This is error");
            Logging("Result:", "This is result ok");
            //SetTestInfo();
            Attachment atm = new Attachment();
            atm.ClearTemp();
            //Reload old config if avaiable
            Config config = hPage.LoadConfig();
            if (config != null)
            {
                textBoxTrackingDmain.Text = config.TrackDomain;
                textBoxEmail.Text = config.SenderEmail;
                textBoxMailPasswd.Text = config.SenderPasswd;
                textBoxSMTPSRV.Text = config.SMTPServer;
                textBoxSMTPPort.Text = config.SMTPPort;
                textBoxDisplayNm.Text = config.SenderName;
                Logging("Result:", "Reload previous config OK. Click 'Check' to ensure everything runs smoothly");
            }
            if(dtaIO.CreateDataDirectory())
            {
                if(dtaIO.InitDatabaseConn())
                {
                    dtaIO.CreateDatabaseAndTable();
                    Logging("Result:", "Process database OK");
                }
            }
            Logging("Info:", "Working dir: " + Directory.GetCurrentDirectory());
            Loading(false);
        }

        private async void InitializeWebView()
        {
            await webView21.EnsureCoreWebView2Async(null);
            string htmlContent = @"
                <html>
                <body>
                    <h1>Kaburra Mail Preview</h1>
                </body>
                </html>";
            webView21.NavigateToString(htmlContent);         
        }
        public void Logging(string prefixLog, string suffixLog) //Prefix: Error:  Result:  Warning:  Suffix: Text Msg
        {
            ListViewItem logItem = new ListViewItem();
            logItem.Text = suffixLog;
            switch (prefixLog.ToLower())    //so sánh ở dạng chữ thường
            {
                case "error:":
                    {
                        logItem.ForeColor = Color.Red;
                        break;
                    }
                case "warning:":
                    {
                        logItem.ForeColor = Color.Orange;
                        break;
                    }
                case "result:":
                    {
                        logItem.ForeColor = Color.Green;
                        break;
                    }
                default:
                    {
                        //sử dụng màu default
                        break;
                    }
            }
            listViewLog.Items.Add(logItem);
            // Scroll to the last item
            if (listViewLog.Items.Count > 0)
            {
                listViewLog.EnsureVisible(listViewLog.Items.Count - 1);
            }

        }

        private void buttonAddMail_Click(object sender, EventArgs e)
        {
            textBoxAddMail.Visible = true;
            textBoxAddMail.Focus();
        }

        private void textBoxAddMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool canAdd = true;
            //Kiểm tra có phải là key Enter
            if(e.KeyChar == ((char)Keys.Enter))
            {
                if(!textBoxAddMail.Text.Contains('@'))
                {
                    Logging("Error:", "Invalid mail format");
                    canAdd = false;
                }
                if(hPage.ExistInListView(listViewMail, textBoxAddMail.Text))
                {
                    Logging("Error:", "Mail already added: " + textBoxAddMail.Text);
                    canAdd = false;
                }
                if(canAdd)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = textBoxAddMail.Text;
                    listViewMail.Items.Add(listViewItem);
                    textBoxAddMail.Text = "";
                    Logging("Info:", "Mail added: " + textBoxAddMail.Text);
                }
                //ẩn textbox add mail
                textBoxAddMail.Visible = false;
            }
        }

        private void buttonRemoveMail_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem listViewItem in listViewMail.SelectedItems)
            {
                listViewMail.Items.Remove(listViewItem);
            }
        }

        private void buttonInBulk_Click(object sender, EventArgs e)
        {
            Loading(true);
            DialogResult dialogResult = openMailFileDialog.ShowDialog();
            string[] readtext;
            if(dialogResult == DialogResult.OK)
            {
                string filePath = openMailFileDialog.FileName;
                try
                {
                    // Open the file to read from.
                    readtext = File.ReadAllLines(filePath);
                    Logging("Info:", "Open file: " + filePath);
                    int mailAdded = 0, mailNotAdded = 0;
                    foreach(string line in readtext)
                    {
                        if(hPage.IsValidMailFormat(line) && !hPage.ExistInListView(listViewMail, line))
                        {
                            hPage.AddToListView(listViewMail, line);
                            mailAdded++;
                        }
                        else
                        {
                            mailNotAdded++;
                        }
                    }
                    Logging("Info:", "Number of mail added: " + mailAdded + "/" + readtext.Length);
                    Logging("Warning:", "Number of mail NOT added: " + mailNotAdded);
                }
                catch(Exception ex)
                {
                    Logging("Error:", "Add mails in bulk error: " + ex.Message);
                }
            }
            Loading(false);
        }

        private async void buttonCheck_Click(object sender, EventArgs e)
        {
            Loading(true);
            Logging("Info:", "Start checking configuration info...");
            pictureBoxCheckComplete.Visible = false;
            webUtils.PrepareUsing(textBoxTrackingDmain.Text);
            string result = await webUtils.CheckServerAlive();
            if(string.IsNullOrEmpty(result))
            {
                Logging("Error:", "Cannot connect to tracking domain " + webUtils.DomainURL);
                Loading(false);
                return;
            }
            Logging("Result:", "Tracking server alive " + webUtils.DomainURL);
            MailHandle mMail = new MailHandle(textBoxSMTPSRV.Text, int.Parse(textBoxSMTPPort.Text), textBoxEmail.Text, textBoxDisplayNm.Text, textBoxMailPasswd.Text);
            if(!mMail.CheckConfig())
            {
                Logging("Error:", "SMTP config. Check Sender Setting fields");
                Loading(false);
                return;
            }
            Logging("Result:", "SMTP server connection successfull " + textBoxSMTPSRV.Text + ":" + textBoxSMTPPort.Text);
            pictureBoxCheckComplete.Visible = true;
            Loading(false);
        }

        string mailBody = String.Empty;
        private void buttonOpenBody_Click(object sender, EventArgs e)
        {
            Loading(true);
            DialogResult dialogResult = openMailFileDialog.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                textBoxBodyPath.Text = openMailFileDialog.FileName;
                Logging("Info:", "HTML mail body from file: " + openMailFileDialog.FileName);
            }
            try
            {
                //dử dụng iso-8859-1 để hiển thị các ký tự extra khi gửi qua SMTP, các encode khác sẽ hiển thị ????
                mailBody = File.ReadAllText(textBoxBodyPath.Text, System.Text.Encoding.GetEncoding("iso-8859-1"));
                webView21.NavigateToString(mailBody);
            }
            catch(Exception ex)
            {
                Logging("Error:", ex.Message);
                mailBody = String.Empty;
            }
            Loading(false);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if(listViewMail.SelectedItems.Count == 0)
            {
                Logging("Error:", "Select target mail: one or multi");
                return;
            }
            if(string.IsNullOrEmpty(mailBody))
            {
                Logging("Error:", "Mail body still null");
                return;
            }
            if(string.IsNullOrEmpty(textBoxSubject.Text))
            {
                Logging("Error:", "Check Subject");
                return;
            }
            Attachment atm = new();
            MailHandle mHdl = new(textBoxSMTPSRV.Text, int.Parse(textBoxSMTPPort.Text), textBoxEmail.Text, textBoxDisplayNm.Text, textBoxMailPasswd.Text);
            if (radioButNoAtt.Checked)
            {
                Loading(true);
                SendWithNoAtt(atm, mHdl);
                Loading(false);
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxAttName.Text))
                {
                    Logging("Error:", "Check Attachment name");
                    return;
                }
                Loading(true);
                SendWithAtt(atm, mHdl);
                Loading(false);
            }
        }

        private void SendWithNoAtt(Attachment atm, MailHandle mHdl)
        {
            string mHash = hPage.ComputeMD5Hash(textBoxSubject.Text);
            string eHash = string.Empty;
            string bodyWithTrack = string.Empty;
            string trackURL = string.Empty;
            //chuẩn bị SMTP connect để gửi email
            if(!mHdl.InitSMTPClient())
            {
                Logging("Error:", "Error at init SMTP connection");
                return;
            }
            int sent = 0;
            foreach (ListViewItem item in listViewMail.SelectedItems)
            {
                eHash = hPage.ComputeMD5Hash(item.Text.ToLower());
                trackURL = textBoxTrackingDmain.Text + Marker.trackingPrefix + "/e_" + eHash + "/m_" + mHash + "/img5x5.png";
                bodyWithTrack = atm.InsertTrackngImg(mailBody, trackURL);
                if(string.IsNullOrEmpty(bodyWithTrack))
                {
                    Logging("Error:", "Error in parse Mail Body, canceling");
                    mHdl.CloseSMTPClient();
                    return;
                }
                //gửi email
                if(mHdl.SendMail(textBoxSubject.Text, bodyWithTrack, item.Text, item.Text))//tên người nhận tạm cho giống với email
                {
                    //Logging("Result:", $"**** Send to {item.Text} successfully");
                    //process database
                    dtaIO.InsertTBTwoRecord("EmailAddress", "ID", "OriginalName", eHash, item.Text);
                    dtaIO.InsertTBTwoRecord("MailSubject", "ID", "OriginalName", mHash, textBoxSubject.Text);
                    dtaIO.InsertSentMail(mHdl.Sender, item.Text, textBoxSubject.Text, ""); //kho6ng có x_hash
                    sent++;
                }
                else
                {
                    Logging("Error:", $"**** Error when send to {item.Text}");
                }
                System.Threading.Thread.Sleep(int.Parse(textBoxDelay.Text.Trim() + "000"));
            }
            mHdl.CloseSMTPClient();
            Logging("Result", $"Number of email sent: {sent} / {listViewMail.SelectedItems.Count}");
        }
        private async void SendWithAtt(Attachment atm, MailHandle mHdl)
        {
            //set passwd cho Zip file nếu như có
            Marker.defaultZipPasswd = textBoxZipPasswd.Text;
            string xHash = hPage.ComputeMD5Hash(textBoxAttName.Text.ToLower() + atm.GetExt(comboBoxAttach.SelectedIndex) + ":" + atm.GetAttDescr(comboBoxAttach.SelectedIndex));
            string mHash = hPage.ComputeMD5Hash(textBoxSubject.Text.ToLower());
            string trackURLX = string.Empty;
            string trackURL = string.Empty;
            string eHash = string.Empty;
            string bodyWithTrack = string.Empty;
            string atmFile = string.Empty;
            if (!mHdl.InitSMTPClient())
            {
                Logging("Error:", "Error at init SMTP connection");
                return;
            }
            int sent = 0;
            foreach (ListViewItem item in listViewMail.SelectedItems)
            {
                eHash = hPage.ComputeMD5Hash(item.Text.ToLower());
                trackURLX = textBoxTrackingDmain.Text + Marker.trackingPrefix + "/e_" + eHash + "/m_" + mHash + "/x_" + xHash + "/img5x5.png";
                trackURL = textBoxTrackingDmain.Text + Marker.trackingPrefix + "/e_" + eHash + "/m_" + mHash + "/img5x5.png";
                bodyWithTrack = atm.InsertTrackngImg(mailBody, trackURL);
                if (string.IsNullOrEmpty(bodyWithTrack))
                {
                    Logging("Error:", "Error in parse Mail Body, canceling");
                    mHdl.CloseSMTPClient();
                    return;
                }
                atmFile = atm.ProcessAttachment(comboBoxAttach.SelectedIndex, textBoxAttName.Text, trackURLX);
                if(!string.IsNullOrEmpty(atmFile))
                {
                    if (mHdl.SendWithAttach(textBoxSubject.Text, bodyWithTrack, atmFile, item.Text, item.Text))//tên người nhận tạm cho giống với email
                    {
                        //Logging("Result:", $"**** Send to {item.Text} successfully");
                        sent++;
                        //process database
                        dtaIO.InsertTBTwoRecord("EmailAddress", "ID", "OriginalName", eHash, item.Text);
                        dtaIO.InsertTBTwoRecord("MailSubject", "ID", "OriginalName", mHash, textBoxSubject.Text);
                        dtaIO.InsertTBTwoRecord("Attachment", "ID", "OriginalName", xHash, textBoxAttName.Text + atm.GetExt(comboBoxAttach.SelectedIndex) + ":" + atm.GetAttDescr(comboBoxAttach.SelectedIndex));
                        dtaIO.InsertSentMail(mHdl.Sender, item.Text, textBoxSubject.Text, Path.GetFileName(atmFile) + ":" + atm.GetAttDescr(comboBoxAttach.SelectedIndex)); 
                    }
                    else
                    {
                        Logging("Error:", $"**** Error when send to {item.Text}");
                    }
                    //await Task.Delay(int.Parse(textBoxDelay.Text.Trim() + "000"));
                    //Sleep sẽ block luôn hiệu ưng của gif loading
                    System.Threading.Thread.Sleep(int.Parse(textBoxDelay.Text.Trim() + "000")); //Delay để không vượt qua số Mails được gửi trong khoảng thời gian nhất định. Tùy vào các Mail Server.
                }
                else
                {
                    Logging("Error:", $"**** Error when process attachment {textBoxAttName.Text}");
                }
            }
            Logging("result", $"Number of email sent: {sent} / {listViewMail.SelectedItems.Count}");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config config = new();
            config.TrackDomain = textBoxTrackingDmain.Text;
            config.SenderEmail = textBoxEmail.Text;
            config.SenderPasswd = textBoxMailPasswd.Text;
            config.SMTPServer = textBoxSMTPSRV.Text;
            config.SMTPPort = textBoxSMTPPort.Text;
            config.SenderName = textBoxDisplayNm.Text;
            hPage.SaveConfig(config);
            webView21.Dispose();
        }

        private void tabPageSentItem_Enter(object sender, EventArgs e)
        {
            Loading(true);
            DataTable sentData = dtaIO.QueryMail("MSent");
            //xóa cột ID Auto Inc 
            sentData.Columns.RemoveAt(0);           
            dataGridViewSent.DataSource = sentData;
            Loading(false);
        }

        private async void tabPageResult_Enter(object sender, EventArgs e)
        {
            Loading(true);
            Logging("Info:", "Pull log from server...");
            webUtils.PrepareUsing(textBoxTrackingDmain.Text);
            string logData = await webUtils.GetLogdata(Marker.getLogURI);
            List<Maildata> listLog = webUtils.ParseLog(logData, dtaIO);
            foreach (Maildata maildata in listLog)
            {
                dtaIO.InsertExecMail(maildata.Sender, maildata.Target, maildata.Subject, maildata.Exec, maildata.RequestIP, maildata.Time);
            }
            if(listLog.Count > 0)
            {
                string clearLog = await webUtils.ClearLogData(Marker.clearLogURI);
                Logging("Warning:", "Do clear log data on server: " + clearLog);
            }
            DataTable openData = dtaIO.QueryMail("MOpen");
            //xóa cột ID Auto Inc 
            openData.Columns.RemoveAt(0);
            dataGridViewOpen.DataSource = openData;
            Loading(false);
        }

        private void tabPageStatistic_Enter(object sender, EventArgs e)
        {
            Loading(true);
            // Count Mail Data, loại bỏ duplicate
            int totalEmailsSent = (int)dtaIO.CountSent(false);
            int emailsOpened = (int)dtaIO.CountOpen();
            int emailsExec = (int)dtaIO.CountExec();
            var model = new PlotModel { Title = "Email Statistics" };
            model.TitleFontWeight = FontWeights.Bold;
            var pieSeries = new PieSeries {StrokeThickness = 1, InsideLabelPosition = 0.5, AngleSpan = 360,StartAngle = 0};
            pieSeries.Slices.Add(new PieSlice("Emails Opened", emailsOpened) { Fill = OxyColor.FromArgb(255, 255, 255, 0), IsExploded = true });
            pieSeries.Slices.Add(new PieSlice("Emails With Exec", emailsExec) { Fill = OxyColor.FromArgb(255, 255, 0, 0), IsExploded = true});
            pieSeries.Slices.Add(new PieSlice("Emails Not Opened", totalEmailsSent - emailsOpened) { Fill = OxyColor.FromArgb(255, 0, 255, 0), IsExploded = false });
            model.Series.Add(pieSeries);
            var plotView = new PlotView { Dock = DockStyle.Fill, Model = model };
            panelMailStat.Controls.Add(plotView);

            //Count Attachment
            //int totalExec = (int)dtaIO.CountExecRecord("");
            string mostOpenType = "Doc Macros";
            int mostOpenCount = 0;
            int docExec = (int)dtaIO.CountExecRecord(Marker.docMacros, false);
            mostOpenCount = docExec;
            int lnkExec = (int)dtaIO.CountExecRecord(Marker.lnkPdf, false);
            if(lnkExec >= mostOpenCount)
            {
                mostOpenCount = lnkExec;
                mostOpenType = "LNK Shortcut";
            }
            int wordExec = (int)dtaIO.CountExecRecord(Marker.wordEXE, false);
            if (wordExec >= mostOpenCount)
            {
                mostOpenCount = wordExec;
                mostOpenType = "MSWord Exe";
            }
            int adobeExec = (int)dtaIO.CountExecRecord(Marker.AdobeEXE, false);
            if(adobeExec >= mostOpenCount)
            {
                mostOpenCount = adobeExec;
                mostOpenType = "Adobe Exe";
            }
            var modelAtt = new PlotModel { Title = "Attachment Execution" };
            model.TitleFontWeight = FontWeights.Bold;
            var pieSeriesAtt = new PieSeries { StrokeThickness = 1, InsideLabelPosition = 0.5, AngleSpan = 360, StartAngle = 0 };
            pieSeriesAtt.Slices.Add(new PieSlice("Doc Macros", docExec) { IsExploded = true });
            pieSeriesAtt.Slices.Add(new PieSlice("LNK Shortcut", lnkExec) { IsExploded = true });
            pieSeriesAtt.Slices.Add(new PieSlice("MSWord Exe", wordExec) { IsExploded = false });
            pieSeriesAtt.Slices.Add(new PieSlice("Adobe Exe", adobeExec) { IsExploded = false });
            //pieSeriesAtt.Slices.Add(new PieSlice("Un", adobeExec) { IsExploded = false });
            modelAtt.Series.Add(pieSeriesAtt);
            var plotViewAtt = new PlotView { Dock = DockStyle.Fill, Model = modelAtt };
            panelAttStat.Controls.Add(plotViewAtt);

            labeltotalSent.Text = dtaIO.CountSent(true).ToString();
            labeltotalOpen.Text = dtaIO.CountOpen(true).ToString();
            labelmostSubject.Text = dtaIO.GetMostOpenSubject();

            labeltotalAttSent.Text = dtaIO.GetTotalAttachment().ToString();
            labeltotalAttOpen.Text = dtaIO.CountExecRecord("",true).ToString();
            labelmostAtt.Text = dtaIO.GetMostOpenAtt().Split(':')[0];
            labelmostAttType.Text = mostOpenType;

            Loading(false);
        }

        private void radioButNoAtt_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButNoAtt.Checked)
            {
                comboBoxAttach.Enabled = false;
                textBoxAttName.Enabled = false;
                textBoxZipPasswd.Enabled = false;

            }
            else
            {
                comboBoxAttach.Enabled = true;
                textBoxAttName.Enabled = true;
                textBoxZipPasswd.Enabled=true;
            }
        }

        private void Loading(bool loading)
        {
            pictureBoxLoading.Visible = loading;
        }
    }
}
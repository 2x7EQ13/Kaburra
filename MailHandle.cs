using MimeKit;
using MailKit.Net.Smtp;
using System.Collections.Generic;

namespace Kaburra
{
    internal class MailHandle
    {
        public string Sender { get; set; }
        public string SenderPasswd { get; set; }
        public string SenderName { get; set; }
        public string SMTPServer { get; set; }
        public int SMTPPort { get; set; }

        private SmtpClient sendClient;
        public MailHandle(string smtpServer, int smtpPort, string sender, string senderName, string senderPasswd)
        {
            this.SMTPServer = smtpServer;
            this.SMTPPort = smtpPort;
            this.Sender = sender;
            this.SenderName = senderName;
            this.SenderPasswd = senderPasswd;
        }

        public bool CheckConfig()
        {
            SmtpClient smtpClient = new SmtpClient();
            try
            {
                smtpClient.Connect(this.SMTPServer, this.SMTPPort, false);
                smtpClient.Authenticate(this.Sender, this.SenderPasswd);
                Form1.Instance.Logging("Result:", "Connect to SMTP server OK");
                smtpClient.Disconnect(true);
                return true;
            }
            catch(Exception ex)
            {
                Form1.Instance.Logging("Error:", "Connect to SMTP server " + ex.Message);
                return false;
            }
        }
        public bool SendMail(string subject, string bodyMail, string receiverMail, string receiverName)
        {
            string mtp = "";
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(this.SenderName, this.Sender));
                message.To.Add(new MailboxAddress(receiverName, receiverMail));
                message.Subject = subject;
                BodyBuilder bodyBuilder = new BodyBuilder();
                // quick fix for extended ASCI chracter: single quote System.Text.Encoding.GetEncoding("iso-8859-1")
                //bodyBuilder.HtmlBody = File.ReadAllText(@"E:\RES_Work\CodeTest\Files\Sending Email.htm", System.Text.Encoding.GetEncoding("iso-8859-1"));
                //string tFile = File.ReadAllText(@"E:\RES_Work\CodeTest\Files\Sending Email.htm", System.Text.Encoding.GetEncoding("iso-8859-1"));
                //string tFileMod = InsertTrackngImg(tFile, @"https://w-exchange.zerosalarium.loca/owa/auth/5x5.png");
                //File.WriteAllText("TestFIle.html", tFileMod, System.Text.Encoding.GetEncoding("iso-8859-1"));

                bodyBuilder.HtmlBody = bodyMail;
                bodyBuilder.TextBody = "-";
                message.Body = bodyBuilder.ToMessageBody();
                //message.WriteTo("testfile.txt");

                //Send
                //sendClient = new SmtpClient();  //this client use current computername, carefull
                //smtpClient.Connect(this.SMTPServer, this.SMTPPort, false);
                //smtpClient.Authenticate(this.Sender, this.SenderPasswd);
                mtp = sendClient.Send(message);
                //smtpClient.Disconnect(true);
                //Form1.Instance.Logging("Result:", "Send mail completed");
                return true;
            }
            catch(Exception ex)
            {
                Form1.Instance.Logging("Error:", "Send mail error " + ex.Message + " " + mtp);
                return false;
            }
           //
        }
        public bool InitSMTPClient()
        {
            try
            {
                sendClient = new SmtpClient();
                sendClient.Connect(this.SMTPServer, this.SMTPPort, false);
                sendClient.Authenticate(this.Sender, this.SenderPasswd);
            }
            catch(Exception ex)
            {
                Form1.Instance.Logging("Error:", "Init SMTP Client error: " + ex.Message );
                return false;
            }
            return true;
        }
        public void CloseSMTPClient()
        {
            try
            {
                sendClient.Disconnect(true);
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Error:",ex.Message);
            }
        }

        public bool SendWithAttach(string subject, string bodyMail, string attachFilePath ,string receiverMail, string receiverName)
        {
            string mtp = string.Empty;
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(this.SenderName, this.Sender));
                message.To.Add(new MailboxAddress(receiverName, receiverMail));
                message.Subject = subject;
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = bodyMail;
                bodyBuilder.TextBody = "-";
                bodyBuilder.Attachments.Add(attachFilePath);
                message.Body = bodyBuilder.ToMessageBody();
                mtp = sendClient.Send(message);
            }
            catch(Exception ex)
            {
                Form1.Instance.Logging("Error:", receiverMail + ": " + ex.Message + " " + mtp);
                return false;
            }
            return true;
        }

        public void SendMailInBulk(string subject, string bodyMail, Dictionary<string, string> rvNameNPasswd) //Dic:  email:displayname
        {
            int mailSended = 0;
            string mtp = "";
            //Send
            SmtpClient smtpClient = new SmtpClient();  //this client use current computername, carefull
            try
            {               
                smtpClient.Connect(this.SMTPServer, this.SMTPPort, false);
                smtpClient.Authenticate(this.Sender, this.SenderPasswd);
                foreach (KeyValuePair<string, string> entry in rvNameNPasswd)
                {
                    MimeMessage message = new MimeMessage();
                    message.From.Add(new MailboxAddress(this.SenderName, this.Sender));
                    message.To.Add(new MailboxAddress(entry.Key, entry.Value));
                    message.Subject = subject;
                    BodyBuilder bodyBuilder = new BodyBuilder();
                    bodyBuilder.HtmlBody = bodyMail;
                    bodyBuilder.TextBody = "-";
                    message.Body = bodyBuilder.ToMessageBody();
                    mtp = smtpClient.Send(message);
                    mailSended++;
                }
            }catch(Exception ex)
            {
                Form1.Instance.Logging("Error:", ex.Message + " " + mtp);
            }
            smtpClient.Disconnect(true);
            Form1.Instance.Logging("Result:", "Send mail completed " + mailSended + "/" + rvNameNPasswd.Count);
        }
    }
}

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Kaburra
{
    internal class WebUtils
    {
        private HttpClientHandler handler = null;
        private HttpClient client = null;

        public string DomainURL { get; set; }
        public bool InitClient()
        {
            DomainURL = "";
            handler = new HttpClientHandler();
            // Ignore SSL certificate errors
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            try
            {
                client = new HttpClient(handler);
                return true;
            }catch(Exception ex)
            {
                //Console.WriteLine($"Error: {ex.Message}");
                Form1.Instance.Logging("Error:", ex.Message);
                return false;
            }
        }
        public void SetBaseDomain()
        {
            try
            {
                // Set the base address or any other configurations
                client.BaseAddress = new Uri(DomainURL);
            }catch(Exception ex)
            {
                Form1.Instance.Logging("Error:", ex.Message);
            }
        }
        public void ResetClient()
        {
            client.Dispose();
            handler.Dispose();
        }

        public void PrepareUsing(string strURL)
        {
            if (!DomainURL.ToLower().Equals(strURL.Trim().ToLower()))
            {
                ResetClient();
                InitClient();
                DomainURL = strURL.Trim().ToLower();
                SetBaseDomain();
            }
        }
        public async Task<string> GetLogdata(string strURI)
        {
            string strResult = string.Empty;
            try
            {             
                
                // Make a request
                var response = await client.GetAsync(strURI);
                if (response.IsSuccessStatusCode)
                {
                    strResult = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine(strResult);
                }
                else
                {
                    //Console.WriteLine($"Error: {response.StatusCode}");
                    Form1.Instance.Logging("Error:", response.StatusCode.ToString());
                }
            }catch(Exception ex)
            {
                //Console.WriteLine($"Error: {ex.Message}");
                Form1.Instance.Logging("Error:", ex.Message);
            }
            return strResult;
        }

        public async Task<string> CheckServerAlive()
        {
            string strResult = string.Empty;
            try
            {
                // Make a request
                var response = await client.GetAsync("/index");
                if (response.IsSuccessStatusCode)
                {
                    strResult = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    //Console.WriteLine($"Error: {response.StatusCode}");
                    Form1.Instance.Logging("Info:", "Status code - " + response.StatusCode.ToString());
                    strResult = response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error: {ex.Message}");
                Form1.Instance.Logging("Error:", ex.Message);
            }
            return strResult;
        }

        public async Task<string> ClearLogData(string strURI)
        {
            string strResult = string.Empty;
            try
            {
                // Make a request
                var response = await client.GetAsync(strURI);
                if (response.IsSuccessStatusCode)
                {
                    strResult = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine(strResult);
                }
                else
                {
                    //Console.WriteLine($"Error: {response.StatusCode}");
                    Form1.Instance.Logging("Error:", response.StatusCode.ToString());
                }
            } catch(Exception ex)
            {
                //Console.WriteLine($"Error: {ex.Message}");
                Form1.Instance.Logging("Error:", ex.Message);
            }
            return strResult;
        }

        public List<Maildata> ParseLog(string textLog, DatabaseIO dtaIO)
        {
            List<Maildata> mData = new List<Maildata>();
            try
            {
                string[] lines = textLog.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                //các dòng log có định dạng: IP Time URI  cách nhau bằng dấu Space
                foreach (string line in lines)
                {
                    string[] parts = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 3)
                    {
                        Maildata mailData = new Maildata();
                        mailData.RequestIP = parts[0];
                        mailData.Time = parts[1];
                        string uri = parts[2];
                        if (ParseURIToIDs(uri, ref mailData, dtaIO))
                        {
                            mailData.Sender = dtaIO.QuerySender(mailData.Target, mailData.Subject);
                            mData.Add(mailData);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Form1.Instance.Logging("Error: ", "ParseLog: " + ex.Message);
            }          
            return mData;
        }
        public bool ParseURIToIDs(string uriToParse, ref Maildata maildata, DatabaseIO dtaIO)
        {
            try
            {
                string[] tmpArray = uriToParse.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                string target, subject, att;
                if (tmpArray.Length > 0)
                {
                    foreach (string str in tmpArray)
                    {
                        if (str.StartsWith("e_"))       // e == Email
                        {
                            target = str.Substring(2);  // 2 == "e_".Length  <== remove e_ to get tracking hash
                            maildata.Target = dtaIO.QueryOrigName("EmailAddress", "ID", target);
                            continue;
                        }
                        if (str.StartsWith("m_"))   //m == Mailtext == Tracking Email trggered
                        {
                            subject = str.Substring(2);
                            maildata.Subject = dtaIO.QueryOrigName("MailSubject", "ID", subject);
                            continue;
                        }
                        if (str.StartsWith("x_"))   // x == Attachment Open and Exec code in file
                        {
                            att = str.Substring(2);
                            maildata.Exec = dtaIO.QueryOrigName("Attachment", "ID", att);
                            continue;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Form1.Instance.Logging("Error: ", "ParseURIToIDs: " + ex.Message);
            }
            
            if (string.IsNullOrEmpty(maildata.Target))
            {
                return false;
            }
            return true;
        }

    }
}

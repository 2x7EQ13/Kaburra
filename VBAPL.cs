using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaburra
{
    internal class VBAPL
    {
        public string PrepareNewPayload(string attachName)
        {
            string strRes = string.Empty;
            try
            {
                string attPath = @".\Temp\" + attachName;
                File.Copy(@".\Template\" + Marker.docxVBATemplate, attPath, overwrite: true);
                Directory.CreateDirectory(@".\Temp\word");
                string xmlDoc = ExtractSpecificFile(attPath, Marker.docxXmlFilePath, @".\Temp\word");
                if(string.IsNullOrEmpty(xmlDoc))
                {
                    Form1.Instance.Logging("Error:", $"Failed to extract template file: {attPath}");
                    return strRes;
                }
                strRes = xmlDoc;
            }
            catch(Exception ex)
            {
                Form1.Instance.Logging("Error:", ex.Message);
            }
            return strRes;
        }

        public bool UpdateTrackingURL(string[] fileContent, string trackingURL)
        {
            bool bres = false;
            try
            {
                //string[] tmpContent = new string[fileContent.Length];
                //Array.Copy(fileContent, tmpContent, fileContent.Length);
                for (int line = 0; line < fileContent.Length; line++)
                {
                    if(fileContent[line].Contains(Marker.docxRqURL))
                    {
                        fileContent[line] = fileContent[line].Replace(Marker.docxRqURL, trackingURL);
                    }
                }
                File.WriteAllLines(@".\Temp\" + Marker.docxXmlFor7Zip, fileContent);
                bres = true;
            }catch(Exception ex)
            {
                bres = false;
                Form1.Instance.Logging("Error:", ex.Message);
            }
            return bres;
        }
        public bool UpdateDocxFile(string attName)
        {
            string strFullAttPath = Directory.GetCurrentDirectory() + @"\Temp\" + attName; //phải lấy full path để chạy 7zip, do curr dir của 7zip được set trong .\Temp\
            return SevenZipAddFile(strFullAttPath, Marker.docxInputFolder7Z);
        }

        string ExtractSpecificFile(string zipFilePath, string fileToExtract, string extractPath)
        {
            string destinationPath = string.Empty;
            try
            {
                using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
                {

                    ZipArchiveEntry entry = archive.GetEntry(fileToExtract);
                    if (entry != null)
                    {
                        destinationPath = Path.Combine(extractPath, entry.Name);
                        entry.ExtractToFile(destinationPath, overwrite: true);
                    }
                    else
                    {
                        Form1.Instance.Logging("Error:", $"File '{fileToExtract}' not found in the ZIP archive.");
                    }
                }
            }
            catch(Exception ex)
            {
                Form1.Instance.Logging("Error:", $"Error in extract docx file: {ex.Message}");
            }
            return destinationPath;
        }

        bool SevenZipAddFile(string zipFilePath, string inputFolder)
        {
            //chạy tool 7z với current dir trong .\Temp
            Process process = new Process();
            process.StartInfo.FileName = @".\Tools\7za.exe";
            process.StartInfo.Arguments = $"a \"{zipFilePath}\" \"{inputFolder}\""; // Command line arguments
            process.StartInfo.UseShellExecute = false; 
            process.StartInfo.RedirectStandardOutput = true; // Redirect output
            process.StartInfo.RedirectStandardError = true; // Redirect error output
            process.StartInfo.CreateNoWindow = true; // chạy ẩn cửa sổ
            process.StartInfo.WorkingDirectory = @".\Temp\";
            bool bRes = false;
            try
            {
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();
                if (!string.IsNullOrEmpty(output))
                {
                    if (output.Contains("Everything is Ok"))
                    {
                        bRes = true;
                    }
                }
                if (!string.IsNullOrEmpty(error))
                {
                    foreach(string line in error.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        Form1.Instance.Logging("Error:", line);
                    }
                }
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Error:", $"An error occurred: {ex.Message}");
            }
            finally
            {
                // Clean up
                if (process != null && !process.HasExited)
                {
                    process.Kill();
                }
                process.Dispose();
            }
            return bRes;
        }

    }
}

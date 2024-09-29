using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaburra
{
    internal class Config
    {
        public string TrackDomain { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPasswd { get; set; }
        public string SenderName { get; set; }
        public string SMTPServer { get; set; }
        public string SMTPPort { get; set; }


    }
}

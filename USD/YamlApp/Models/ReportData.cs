using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Models
{
    public class ReportData
    {
        public ReportData()
        {
            USDData = new Dictionary<string, string>();
        }
        public Dictionary<string, string> USDData{ get; set; }
        public string FIO { get; set; }
        public string TypeOfReport { get; set; }
        public DateTime ReportDate { get; set; }
        public long GUID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Models
{
    public class RadioButtonGroupModel
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Orientation { get; set; }
        public List<string> OptionList { get; set; }
    }
}

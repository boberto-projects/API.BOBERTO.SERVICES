using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Message.Models.Integration.Ntfy.Models
{
    public class NtfyActionModel
    {
        public string Action { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
    }
}

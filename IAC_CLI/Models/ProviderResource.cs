using IAC_CLI.Models.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAC_CLI.Models
{
    public class ProviderResource
    {
        /** Provider to use */
        public string Provider { get; set; }

        /** Project of the provider */
        public string Project { get; set; }

        /** Target zone of the provider */
        public string Zone { get; set; }
    }
}

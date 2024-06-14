using System;
using System.Collections.Generic;
using System.Text;

namespace IAC_CLI.Models
{
    /**
     * Resource representing a VM or compute instance.
     */
    public class VMResource : AbstractResource
    {

        public VMResource() 
        {
            Type = ResourceType.VM;
        }
    }
}

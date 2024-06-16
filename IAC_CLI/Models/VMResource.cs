using IAC_CLI.Models.Command;
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

        /** Inherit docs */
        public override UpdateCommand CreateUpdateCommand(AbstractResource currentState)
        {
            return new UpdateCommand(this, currentState, new Dictionary<string, string>());
        }
    }
}

using IAC_CLI.Models.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace IAC_CLI.Models
{
    /**
     * Resource representing a network.
     */
    public class NetworkResource : AbstractResource
    {

        public string Name { get; set; }

        public NetworkResource() 
        {
            Type = ResourceType.Network;
        }

        /** Inherit docs */
        public override UpdateCommand CreateUpdateCommand(AbstractResource currentState)
        {
            return new UpdateCommand(this, currentState, new Dictionary<string, string>());
        }
    }
}

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
    }
}

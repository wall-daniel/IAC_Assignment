using System.Collections.Generic;

namespace IAC_CLI.Models
{
    /**
     * Class to hold either the current state or desired state of the infrastructure.
     */
    public class State
    {

        public ProviderResource Provider { get; set; }

        public List<VMResource> VMs = new List<VMResource>();

        public List<NetworkResource> Networks = new List<NetworkResource>();

        public List<DBResource> DBs = new List<DBResource>();
    }
}

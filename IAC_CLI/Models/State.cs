using Google.Cloud.Compute.V1;
using System.Collections.Generic;

namespace IAC_CLI.Models
{
    /**
     * Class to hold either the current state or desired state of the infrastructure.
     */
    public class State
    {

        public ProviderResource Provider { get; set; }

        public List<Instance> VMs = new List<Instance>();

        public List<NetworkResource> Networks = new List<NetworkResource>();

        public List<DBResource> DBs = new List<DBResource>();
    }
}

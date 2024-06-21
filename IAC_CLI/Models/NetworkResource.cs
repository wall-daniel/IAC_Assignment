using Google.Cloud.Compute.V1;

namespace IAC_CLI.Models
{
    /**
     * Resource representing a network.
     */
    public class NetworkResource : AbstractResource<Network>
    {

        public string Name { get; set; }

        public NetworkResource() 
        {
            Type = ResourceType.Network;
        }
    }
}

using Google.Cloud.Compute.V1;

namespace IAC_CLI.Models
{
    /**
     * Resource representing a VM or compute instance.
     */
    public class VMResource : AbstractResource<Instance>
    {

        public string Name { get; set; }

        public string MachineType { get; set; }

        public string OS {  get; set; }

        public VMResource() 
        {
            Type = ResourceType.VM;
        }
    }
}

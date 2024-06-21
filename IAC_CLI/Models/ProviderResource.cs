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

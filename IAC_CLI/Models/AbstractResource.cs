namespace IAC_CLI.Models
{
    /**
     * Abstract class that all resources implement.
     */
    public abstract class AbstractResource<T>
    {
        /** Unique ID of resource */
        public string ID { get; set; }

        /** The type of resource */
        public ResourceType Type { get; set; }
    }

    public enum ResourceType
    {
        Network,
        VM,
        DB
    }
}

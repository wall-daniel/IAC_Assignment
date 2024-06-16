using IAC_CLI.Models.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace IAC_CLI.Models
{
    /**
     * Abstract class that all resources implement.
     */
    public abstract class AbstractResource
    {
        /** Unique ID of resource */
        public string ID { get; set; }

        /** The type of resource */
        public ResourceType Type { get; set; }

        /**
         * Creates an update command to go from the current to the desired state.
         */
        public abstract UpdateCommand CreateUpdateCommand(AbstractResource currentState);
    }

    public enum ResourceType
    {
        Network,
        VM,
        DB
    }
}

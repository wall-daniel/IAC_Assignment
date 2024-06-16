using IAC_CLI.Models.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace IAC_CLI.Models
{
    /**
     * Resource representing a database
     */
    public class DBResource : AbstractResource
    {

        public DBResource()
        {
            Type = ResourceType.DB;
        }

        /** Inherit docs */
        public override UpdateCommand CreateUpdateCommand(AbstractResource currentState)
        {
            return new UpdateCommand(this, currentState, new Dictionary<string, string>());
        }
    }
}

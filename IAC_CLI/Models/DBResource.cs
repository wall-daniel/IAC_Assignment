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
    }
}

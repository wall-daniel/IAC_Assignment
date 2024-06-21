using Google.Apis.SQLAdmin.v1.Data;

namespace IAC_CLI.Models
{
    /**
     * Resource representing a database
     */
    public class DBResource : AbstractResource<Database>
    {

        public DBResource()
        {
            Type = ResourceType.DB;
        }
    }
}

using IAC_CLI.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAC_CLI.Models.Command
{
    /**
     * Command to create a new resource
     */
    public class CreateCommand : ICommand
    {
        public AbstractResource Resource;

        public CreateCommand(AbstractResource resource) 
        {
            Resource = resource;
        }

        public void Apply(IProvider provider)
        {
            switch (Resource.Type)
            {
                case ResourceType.Network:
                    provider.CreateNetwork();
                    break;
                case ResourceType.VM:
                    provider.CreateVM();
                    break;
                case ResourceType.DB:
                    provider.CreateDB();
                    break;
            }
        }
    }
}

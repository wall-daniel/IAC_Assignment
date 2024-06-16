using IAC_CLI.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAC_CLI.Models.Command
{
    public class UpdateCommand : ICommand
    {
        public AbstractResource DesiredState;
        public AbstractResource CurrentState;

        private IDictionary<string, string> _resourceUpdates;

        public UpdateCommand(AbstractResource desiredState, AbstractResource currentState, IDictionary<string, string> updates) 
        {
            DesiredState = desiredState;
            CurrentState = currentState;
            _resourceUpdates = updates;
        }

        public void Apply(IProvider provider)
        {
            switch (DesiredState.Type)
            {
                case ResourceType.Network:
                    provider.UpdateNetwork();
                    break;
                case ResourceType.VM:
                    provider.UpdateVM();
                    break;
                case ResourceType.DB:
                    provider.UpdateDB();
                    break;
            }
        }
    }
}

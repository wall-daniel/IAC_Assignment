using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAC_CLI.Models.Command
{
    public class CommandFactory
    {

        public CommandFactory() { }

        public ICommand CreateCommand(AbstractResource desiredState, AbstractResource currentState)
        {
            if (currentState == null)
                return new CreateCommand(desiredState);

            var updateCommand = desiredState.CreateUpdateCommand(currentState);
            if (updateCommand != null)
            {
                return updateCommand;
            }

            return null;
        }
    }
}

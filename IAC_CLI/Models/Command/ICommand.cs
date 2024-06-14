using IAC_CLI.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAC_CLI.Models.Command
{
    /**
     * Command interface
     */
    public interface ICommand
    {
        /** Apply the command using the provider */
        public void Apply(IProvider provider);
    }
}

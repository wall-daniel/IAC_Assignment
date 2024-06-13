using CommandLine;
using System.Collections.Generic;

namespace IAC_CLI.Parser
{
    [Verb("apply", HelpText = "Apply file contents.")]
    public class ApplyOptions
    {
        [Option('i', "input", Required = true, HelpText = "Input files to be processed.")]
        public string InputFiles { get; set; }
    }
}

using CommandLine;
using IAC_CLI.Parser;
using IAC_CLI.Provider;
using System;

namespace IAC_CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<ApplyOptions>(args)
                .MapResult(
                    (ApplyOptions opts) => new ApplyOrchestrator(opts).Run(),
                    errs => 1);
        }
    }
}

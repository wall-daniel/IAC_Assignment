using IAC_CLI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace IAC_CLI
{
    public class ApplyOrchestrator
    {
        private string _inputFolder;

        public ApplyOrchestrator(Parser.ApplyOptions opts)
        {
            this._inputFolder = opts.InputFiles;
        }

        public int Run()
        {
            // Get all the resources in the folder and load them all
            var resourcesFiles = Directory.GetFiles(_inputFolder);

            var vms = new List<VMResource>();
            var networks = new List<NetworkResource>();
            var dbs = new List<DBResource>();

            foreach (var file in resourcesFiles)
            {
                var resource = JsonConvert.DeserializeObject(File.ReadAllText(file)) as JObject;

                var resourceTypeStr = resource.Value<string>("resource");
                switch (resourceTypeStr)
                {
                    case "vm":
                        vms.Add(resource["description"].ToObject<VMResource>());
                        break;
                    case "network":
                        networks.Add(resource["description"].ToObject<NetworkResource>());
                        break;
                    case "db":
                        dbs.Add(resource["description"].ToObject<DBResource>());
                        break;
                    default:
                        Console.WriteLine("Unknown resource: {0} in file: {1}", resourceTypeStr, file);
                        break;
                }
            }

            return 1;
        }
    }
}

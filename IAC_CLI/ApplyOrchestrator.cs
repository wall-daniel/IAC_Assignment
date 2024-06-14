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

        private State desiredState = new State();

        private State currentState = new State();

        public ApplyOrchestrator(Parser.ApplyOptions opts)
        {
            this._inputFolder = opts.InputFiles;
        }

        /**
         * Run the apply command which applies the desired state to the current state
         * of the system.
         */
        public int Run()
        {
            // Load all of the configuration files into memory
            LoadFiles();

            // Get the current state from the provider
            GetCurrentState();

            // Reconcile the current state with the configuration
            ReconcileCurrentState();

            // Update current state to match provided state
            ApplyState();

            return 1;
        }

        /**
         * Load all the files 
         */
        private void LoadFiles()
        {
            // Get all the resources in the folder and load them all
            var resourcesFiles = Directory.GetFiles(_inputFolder);

            foreach (var file in resourcesFiles)
            {
                var resource = JsonConvert.DeserializeObject(File.ReadAllText(file)) as JObject;

                var resourceTypeStr = resource.Value<string>("resource");
                switch (resourceTypeStr)
                {
                    case "provider":
                        desiredState.Provider = resource["description"].ToObject<ProviderResource>();
                        break;
                    case "vm":
                        desiredState.VMs.Add(resource["description"].ToObject<VMResource>());
                        break;
                    case "network":
                        desiredState.Networks.Add(resource["description"].ToObject<NetworkResource>());
                        break;
                    case "db":
                        desiredState.DBs.Add(resource["description"].ToObject<DBResource>());
                        break;
                    default:
                        Console.WriteLine("Unknown resource: {0} in file: {1}", resourceTypeStr, file);
                        break;
                }
            }

            // Ensure a provider was given, otherwise we cannot continue
            if (desiredState.Provider == null)
            {
                throw new FileNotFoundException("No file found for a provider resource. Cannot continue.");
            }
        }

        private void GetCurrentState()
        {
            // TODO: implement based on provider
        }

        private void ReconcileCurrentState()
        {
            // TODO: implement based on provider and current state
        }

        private void ApplyState()
        {
            // TODO: implement 
        }
    }
}

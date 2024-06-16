using IAC_CLI.Models;
using IAC_CLI.Provider;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using IAC_CLI.Models.Command;
using System.Net;

namespace IAC_CLI
{
    public class ApplyOrchestrator
    {
        private string _inputFolder;

        private State _desiredState = new State();

        private State _currentState = new State();

        private IProvider _provider;

        private IList<ICommand> _commands = new List<ICommand>();

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

            // Get current provider
            _provider = new ProviderFactory(_desiredState.Provider.Provider).CreateProvider();

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
                        _desiredState.Provider = resource["description"].ToObject<ProviderResource>();
                        break;
                    case "vm":
                        _desiredState.VMs.Add(resource["description"].ToObject<VMResource>());
                        break;
                    case "network":
                        _desiredState.Networks.Add(resource["description"].ToObject<NetworkResource>());
                        break;
                    case "db":
                        _desiredState.DBs.Add(resource["description"].ToObject<DBResource>());
                        break;
                    default:
                        Console.WriteLine("Unknown resource: {0} in file: {1}", resourceTypeStr, file);
                        break;
                }
            }

            // Ensure a provider was given, otherwise we cannot continue
            if (_desiredState.Provider == null)
            {
                throw new FileNotFoundException("No file found for a provider resource. Cannot continue.");
            }
        }

        private void GetCurrentState()
        {
            _currentState = _provider.GetCurrentState();
        }

        /**
         * Determine what changes need to happen to get to the desired state
         */
        private void ReconcileCurrentState()
        {
            var commandFactory = new CommandFactory();

            // Second iteration find the resource in the current state
            foreach (var network in _desiredState.Networks)
            {
                var currentStateNetwork = _currentState.Networks.Find(n => n.ID == network.ID);
                var command = commandFactory.CreateCommand(network, currentStateNetwork);
                if (command != null)
                    _commands.Add(command);
                
                // Otherwise do nothing and continue on
            }

            foreach (var vm in _desiredState.VMs)
            {
                var currentVM = _currentState.VMs.Find(v => v.ID == vm.ID);
                var command = commandFactory.CreateCommand(vm, currentVM);
                if (command != null)
                    _commands.Add(command);

                // Otherwise do nothing and continue on
            }

            foreach (var db in _desiredState.DBs)
            {
                var currentDB = _currentState.DBs.Find(d => d.ID == db.ID);
                var command = commandFactory.CreateCommand(db, currentDB);
                if (command != null)
                    _commands.Add(command);

                // Otherwise do nothing and continue on
            }
        }

        private void ApplyState()
        {
            foreach (var command in _commands)
            {
                command.Apply(_provider);
            }
        }
    }
}

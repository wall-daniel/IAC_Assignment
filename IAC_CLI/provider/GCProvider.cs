using Google.Api.Gax.Grpc;
using Google.Cloud.Compute.V1;
using Grpc.Core;
using IAC_CLI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAC_CLI.Provider
{
    public class GCProvider : IProvider
    {
        private InstancesClient _instancesClient;
        private NetworksClient _networksClient;

        private ProviderResource _providerResource;

        public GCProvider(ProviderResource configuration)
        {
            this._providerResource = configuration;

            var jsonCredentialFile = File.ReadAllText("C:\\Users\\Danny Wall\\Downloads\\credentials.json");

            _instancesClient = new InstancesClientBuilder() { JsonCredentials = jsonCredentialFile }.Build();
            _networksClient = new NetworksClientBuilder() { JsonCredentials = jsonCredentialFile }.Build();
        }

        public State GetCurrentState()
        {
            // Get all the VM states
            var vms = _instancesClient.List(new ListInstancesRequest()
            {
                Project = _providerResource.Project,
                Zone = _providerResource.Zone,
            });


            // TODO: other stuff

            return new State()
            {
                VMs = vms.ToList(),
            };
        }

        public bool CreateDB()
        {
            // TODO:
            return true;
        }

        public bool CreateNetwork()
        {
            // TODO:
            return true;
        }

        public bool CreateVM(VMResource vm)
        {
            var instance = new Instance()
            {
                Name = vm.Name,
                MachineType = vm.MachineType,
            };

            instance.Disks.Add(new AttachedDisk()
            {
                Boot = true,
                InitializeParams = new AttachedDiskInitializeParams()
                {
                    SourceImage = vm.OS,
                }
            });

            instance.NetworkInterfaces.Add(new NetworkInterface()
            {

            });

            var operation = _instancesClient.Insert(new InsertInstanceRequest()
            {
                Zone = _providerResource.Zone,
                Project = _providerResource.Project,
                InstanceResource = instance
            });

            operation.PollUntilCompleted();
            return true;
        }

        public bool UpdateDB()
        {
            throw new NotImplementedException();
        }

        public bool UpdateNetwork()
        {
            throw new NotImplementedException();
        }

        public bool UpdateVM(VMResource desiredState, Instance instance)
        {
            bool needsUpdate = false;

            // Check ending as GC adds URL at start
            if (!instance.MachineType.EndsWith(desiredState.MachineType, StringComparison.InvariantCultureIgnoreCase))
            {
                instance.MachineType = desiredState.MachineType;
                needsUpdate = true;
            }

            //var bootDIsk = instance.Disks.FirstOrDefault(d => d.Boot);
            //Console.WriteLine(bootDIsk.Source.Contains("project"));
            //if (bootDIsk.Source != desiredState.OS)
            //{
            //    bootDIsk.Source = desiredState.OS;
            //    needsUpdate = true;
            //}


            if (!needsUpdate)
            {
                return true;
            }

            var operation = _instancesClient.Update(new UpdateInstanceRequest()
            {
                Zone = _providerResource.Zone,
                Project = _providerResource.Project,
                InstanceResource = instance,
                Instance = instance.Name,
                MinimalAction = "RESTART",
                MostDisruptiveAllowedAction = "RESTART"
            });

            try
            {
                operation.PollUntilCompleted();
                return true;
            }
            catch (Exception ex)
            {
                // TODO: logging...
            }

            return false;
        }
    }
}

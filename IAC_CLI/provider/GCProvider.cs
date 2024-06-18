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

        private ProviderResource _providerResource;

        public GCProvider(ProviderResource configuration) 
        {
            this._providerResource = configuration;

            _instancesClient = new InstancesClientBuilder()
            {
                JsonCredentials = File.ReadAllText("C:\\Users\\Danny Wall\\Downloads\\credentials.json")
            }.Build();
        }

        public State GetCurrentState()
        {
            // Get all the VM states
            var list = _instancesClient.List(new ListInstancesRequest()
            {
                Project = _providerResource.Project,
                Zone = _providerResource.Zone,
            });
            var vms = new List<VMResource>();
            foreach (var vm in list)
            {
                vms.Add(new VMResource() { ID = vm.Id.ToString(), Name = vm.Name });
            }

            // TODO: other stuff

            return new State()
            {
                VMs = vms
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
                    SourceImage = "projects/centos-cloud/global/images/family/centos-stream-9"
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

        public bool UpdateVM()
        {
            throw new NotImplementedException();
        }
    }
}

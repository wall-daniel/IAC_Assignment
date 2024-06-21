

using Google.Cloud.Compute.V1;
using IAC_CLI.Models;
using System;


namespace IAC_CLI.Provider;
/**
 * Interface for each cloud provider
 */
public interface IProvider 
{
    /** Get the current state of the system. Not affected by desired state. */
    State GetCurrentState();
    
    bool CreateVM(VMResource vm);
    bool UpdateVM(VMResource desiredState, Instance currentState);

    bool CreateNetwork();
    bool UpdateNetwork();

    bool CreateDB();
    bool UpdateDB();

}

public class ProviderFactory
{

    public IProvider CreateProvider(ProviderResource resource)
    {
        switch (resource.Provider)
        {
            case "mock":
                return new MockProvider();
            case "gcp":
                return new GCProvider(resource);
            default:
                throw new ArgumentException("Provider does not exist.");
        }
    }
}
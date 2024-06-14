

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
    
    object GetVMState();
    bool CreateVM();
    bool UpdateVM();

    object GetNetworkState();
    bool CreateNetwork();
    bool UpdateNetwork();

    object GetDBState();
    bool CreateDB();
    bool UpdateDB();

}

public class ProviderFactory
{

    private string _provider;

    public ProviderFactory(string provider)
    {
        _provider = provider;
    }

    public IProvider CreateProvider()
    {
        switch (_provider)
        {
            case "mock":
                return new MockProvider();
            default:
                throw new ArgumentException("Provider does not exist.");
        }
    }
}
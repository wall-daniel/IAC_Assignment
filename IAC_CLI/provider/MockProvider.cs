

using IAC_CLI.Models;
using System;
using System.Collections.Generic;

namespace IAC_CLI.Provider;

public class MockProvider : IProvider
{

    /** Get mock current state which is hard coded */
    public State GetCurrentState()
    {
        // Currently create empty state.
        return new State()
        {
            Networks = new List<NetworkResource>(),
            VMs = new List<VMResource>(),
            DBs = new List<DBResource>()
        };
    }

    public bool CreateDB()
    {
        Console.WriteLine("Creating DB...");
        return true;
    }

    public bool CreateNetwork()
    {
        Console.WriteLine("Creating Network...");
        return true;
    }

    public bool CreateVM()
    {
        Console.WriteLine("Creating VM...");
        return true;
    }

    public object GetDBState()
    {
        throw new System.NotImplementedException();
    }

    public object GetNetworkState()
    {
        throw new System.NotImplementedException();
    }

    public object GetVMState()
    {
        throw new System.NotImplementedException();
    }

    public bool UpdateDB()
    {
        throw new System.NotImplementedException();
    }

    public bool UpdateNetwork()
    {
        throw new System.NotImplementedException();
    }

    public bool UpdateVM()
    {
        throw new System.NotImplementedException();
    }
}
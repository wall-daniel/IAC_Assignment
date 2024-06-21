

using Google.Cloud.Compute.V1;
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
            VMs = new List<Instance>() { new Instance() { Name = "123" } },
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

    public bool CreateVM(VMResource vm)
    {
        Console.WriteLine("Creating VM...");
        return true;
    }

    public bool UpdateDB()
    {
        Console.WriteLine("Updating DB...");
        return true;
    }

    public bool UpdateNetwork()
    {
        Console.WriteLine("Updating Network...");
        return true;
    }

    public bool UpdateVM(VMResource desiredState, Instance currentState)
    {
        Console.WriteLine("Updating VM...");
        return true;
    }
}
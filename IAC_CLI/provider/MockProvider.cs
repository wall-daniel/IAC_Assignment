

public class MockProvider : IProvider
{
    public bool CreateDB()
    {
        throw new System.NotImplementedException();
    }

    public bool CreateNetwork()
    {
        throw new System.NotImplementedException();
    }

    public bool CreateVM()
    {
        throw new System.NotImplementedException();
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
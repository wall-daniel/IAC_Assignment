
/**
 * Interface for each cloud provider
 */
interface IProvider 
{
    
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
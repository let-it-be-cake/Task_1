using ORM.FabricMethodBasicMethod.Realisations;

namespace ORM.FabricMethodBasicMethod.Concerns
{
    public abstract class FabricMethodBasicMethods<T> where T : class, new()
    {
        abstract public AbstractBasicMethods<T> Create();
    }
}
using ORM.FabricMethodBasicMethod.Realisations;

namespace ORM.FabricMethodBasicMethod.Concerns
{
    internal class BasicMethod<T> : FabricMethodBasicMethods<T> where T : class, new()
    {
        public override AbstractBasicMethods<T> Create()
        {
            return new BasicMethods<T>();
        }
    }
}
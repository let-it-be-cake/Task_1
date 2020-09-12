using Orm.FabricMethodBasicMethod.Realisations;

namespace Orm.FabricMethodBasicMethod.Concerns
{
    /// <summary>
    /// Concern to create basicMethod
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class BasicMethod<T> : FabricMethodBasicMethods<T> where T : class, new()
    {
        /// <summary>
        /// Create realisation
        /// </summary>
        /// <returns></returns>
        public override AbstractBasicMethods<T> Create()
        {
            return new BasicMethods<T>();
        }
    }
}
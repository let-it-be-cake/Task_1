using ORM.FabricMethodBasicMethod.Realisations;

namespace ORM.FabricMethodBasicMethod.Concerns
{
    /// <summary>
    /// Concern to create basicMethod
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FabricMethodBasicMethods<T> where T : class, new()
    {
        /// <summary>
        /// Create realisaion
        /// </summary>
        /// <returns></returns>
        abstract public AbstractBasicMethods<T> Create();
    }
}
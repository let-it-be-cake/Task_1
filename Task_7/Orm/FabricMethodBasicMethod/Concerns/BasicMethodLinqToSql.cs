using Orm.FabricMethodBasicMethod.Realisations;

namespace Orm.FabricMethodBasicMethod.Concerns
{
    /// <summary>
    /// Concern to create basicMethod
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class BasicMethodLinqToSql<T> : FabricMethodBasicMethods<T> where T : class, new()
    {
        /// <summary>
        /// Create realisation
        /// </summary>
        public override Realisations.AbstractBasicMethods<T> Create()
        {
            return new BasicMethodsLinqToSql<T>();
        }
    }
}
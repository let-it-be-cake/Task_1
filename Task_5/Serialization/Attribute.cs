namespace Serialization.Attribute
{
    /// <summary>
    /// Class version attribute
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
    public class ClassVersion : System.Attribute
    {
        public double version;

        public ClassVersion()
        {
            version = 0.1;
        }
    }
}
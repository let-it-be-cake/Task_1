namespace Shapes.Interfaces
{
    /// <summary>
    /// Interface for all shapes
    /// </summary>
    public interface Shape
    {
        /// <summary>
        /// Method to calculate shape area
        /// </summary>
        /// <returns>Shape area</returns>
        public double Area();

        /// <summary>
        /// Method to calculate shape perimeter
        /// </summary>
        /// <returns>Shape perimeter</returns>
        public double Perimeter();
    }
}
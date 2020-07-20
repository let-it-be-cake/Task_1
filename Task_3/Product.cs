using System;

namespace Task_3.Products
{
    /// <summary>
    /// Main abstract product class
    /// </summary>
    abstract public class Product
    {
        public Product(double cost, string name, string type)
        {
            Cost = cost;
            Name = name;
            Type = type;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public double Cost { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Product product
                && product.Cost == Cost
                && product.Name == Name
                && product.Type == Type)

                return true;
            else
                return false;
        }

        public override int GetHashCode() => HashCode.Combine(this);

        /// <summary>
        /// Conversion of one type of child class to another child class
        /// </summary>
        /// <typeparam name="T">Class to convert</typeparam>
        /// <typeparam name="K">Convertible class</typeparam>
        /// <param name="product">Convertible parametr</param>
        /// <returns>New converted parametr</returns>
        public static T Convert<T, K>(K product)
            where T : Product, new()
            where K : Product, new()
        {
            return new T()
            {
                Cost = product.Cost,
                Name = product.Name,
            };
        }

        /// <summary>
        /// Summing of two child classes
        /// </summary>
        /// <typeparam name="T">Type of class</typeparam>
        /// <param name="a">First parameter of the class T</param>
        /// <param name="b">Second parameter of the class T</param>
        /// <returns>Amount of two class T parameters</returns>
        public static T Summing<T>(T a, T b)
            where T : Product, new()
        {
            var averageCost = (a.Cost + b.Cost) / 2;
            return new T()
            {
                Cost = averageCost,
                Name = a.Name + "-" + b.Name,
                Type = a.Type,
            };
        }

        /// <summary>
        /// Get current cost in integer
        /// </summary>
        /// <param name="product">Parameter from which the price is extracted</param>
        public static implicit operator int(Product product) => (int)product.Cost;

        /// <summary>
        /// Get current cost in double
        /// </summary>
        /// <param name="product">Parameter from which the price is extracted</param>
        public static implicit operator double(Product product) => (double)product.Cost;
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Products
{
    /// <summary>
    /// Specific product - bread, inherited from the class Product
    /// </summary>
    public class Bread : Product
    {
        public int Weight { get; set; } = 900;
        public Bread(double cost = 0, string name = "Bread") : base(cost, name, "Bread") { }
        public Bread() : base(0, "Bread", "Bread") { }


        /// <summary>
        /// Summing two parameters of class Bread
        /// </summary>
        /// <param name="a">Summing parameter a</param>
        /// <param name="b">Summing parameter b</param>
        /// <returns>New bread class</returns>
        public static Bread operator +(Bread a, Bread b) => Summing(a, b);

        //I have no idea what do with this//
        /// <summary>
        /// Conversion of the class bread to class notepad
        /// </summary>
        /// <param name="bread">Converted parameter</param>
        public static explicit operator Notepad(Bread bread) => Convert<Notepad, Bread>(bread);
        public static explicit operator Lamp(Bread bread) => Convert<Lamp, Bread>(bread);
    }
}

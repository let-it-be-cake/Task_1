using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Products
{
    public class Lamp : Product
    {
        public int Power { get; set; } = 90;
        public Lamp(double cost = 0, string name = "Lamp") : base(cost, name, "Lamp") { }
        public Lamp() : base(0, "Lamp", "Lamp") { }

        /// <summary>
        /// Summing two parameters of class Lamp
        /// </summary>
        /// <param name="a">Summing parameter a</param>
        /// <param name="b">Summing parameter b</param>
        /// <returns>New lamp class</returns>
        public static Lamp operator +(Lamp a, Lamp b) => Summing(a, b);

        //I have no idea what do with this//
        /// <summary>
        /// Conversion of the class bread to class Notepad
        /// </summary>
        /// <param name="sausages">Converted parameter</param>
        public static explicit operator Notepad(Lamp sausages) => Convert<Notepad, Lamp>(sausages);
        public static explicit operator Bread(Lamp sausages) => Convert<Bread, Lamp>(sausages);
    }
}

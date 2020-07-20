using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Products
{
    public class Notepad : Product
    {
        public int Lists { get; set; } = 96;
        public Notepad(double cost = 0, string name = "Notepad") : base(cost, name, "Notepad") { }
        public Notepad() : base(0, "Notepad", "Notepad") { }

        /// <summary>
        /// Summing two parameters of class Notepad
        /// </summary>
        /// <param name="a">Summing parameter a</param>
        /// <param name="b">Summing parameter b</param>
        /// <returns>New notepad class</returns>
        public static Notepad operator +(Notepad a, Notepad b) => Summing(a, b);

        //I have no idea what do with this//
        /// <summary>
        /// Conversion of the class bread to class Bread
        /// </summary>
        /// <param name="notepad">Converted parameter</param>
        public static explicit operator Bread(Notepad notepad) => Convert<Bread, Notepad>(notepad);
        public static explicit operator Lamp(Notepad notepad) => Convert<Lamp, Notepad>(notepad);

    }
}

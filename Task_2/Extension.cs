using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_2.Figures;

namespace Task_2.Extentions
{
    public static class Extension
    {
        //Array method for searching some shapes
        public static IEnumerable<Figure> Equal(this Array array, Figure figure)
        {
            foreach (Figure value in array)
            {
                if (value.GetSides().SequenceEqual(figure.GetSides()))
                    yield return value;
            }
        }
    }
}

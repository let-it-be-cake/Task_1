namespace Task_1
{
    public class Vector
    {
        public (double x, double y, double z) Point { get; set; }

        public Vector(double x, double y, double z)
        {
            Point = (x, y, z);
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.Point.x + b.Point.x,
                              a.Point.y + b.Point.y,
                              a.Point.z + b.Point.z);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.Point.x - b.Point.x,
                              a.Point.y - b.Point.y,
                              a.Point.z - b.Point.z);
        }

        public static Vector operator *(Vector a, double b) =>
            new Vector(a.Point.x * b, a.Point.y * b, a.Point.z * b);

        public static Vector operator *(double b, Vector a) =>
            new Vector(a.Point.x * b, a.Point.y * b, a.Point.z * b);

        public static Vector operator /(Vector a, double b) =>
            new Vector(a.Point.x / b, a.Point.y / b, a.Point.z / b);

        public static Vector operator /(double b, Vector a) =>
            new Vector(a.Point.x / b, a.Point.y / b, a.Point.z / b);
    }
}
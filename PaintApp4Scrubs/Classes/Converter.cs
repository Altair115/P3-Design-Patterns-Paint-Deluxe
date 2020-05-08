using System.Windows;

namespace PaintApp4Scrubs.Classes
{
    public class Converter
    {
        public static Vector ToVector(Point point)
        {
            return new Vector(point.X, point.Y);
        }
        public static Point ToPoint(Vector vector)
        {
            return new Point(vector.X, vector.Y);
        }
    }
}
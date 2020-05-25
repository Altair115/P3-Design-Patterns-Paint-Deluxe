using System.Windows;

namespace PaintApp4Scrubs.Classes
{
    /// <summary>
    /// A Simple Vector 2 Point or Point to Vector Converter
    /// </summary>
    public class Converter
    {
        /// <summary>
        /// Converts a Point to a Vector
        /// </summary>
        /// <param name="point">the point to be converted</param>
        /// <returns>A Vector</returns>
        public static Vector ToVector(Point point)
        {
            return new Vector(point.X, point.Y);
        }
        /// <summary>
        /// Convert a Vector to a Point
        /// </summary>
        /// <param name="vector">the vector to be converted</param>
        /// <returns>A Point</returns>
        public static Point ToPoint(Vector vector)
        {
            return new Point(vector.X, vector.Y);
        }
    }
}
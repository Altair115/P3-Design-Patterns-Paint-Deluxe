namespace PaintApp4Scrubs.Classes
{
    /// <summary>
    /// A Simple Printer Singleton
    /// </summary>
    public class ThePrinter
    {
        public static ThePrinter InstancePrinter = new ThePrinter();

        private ThePrinter(){}

        public static ThePrinter GetInstance()
        {
            return InstancePrinter;
        }

        /// <summary>
        /// Print the String to File
        /// </summary>
        /// <param name="text">the String to be printed</param>
        public void PrintToFile(string text)
        {
            using System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"..\..\..\..\comptest.txt", true);
            file.WriteLine(text);
        }
        /// <summary>
        /// Clear the File
        /// </summary>
        public void ClearFile()
        {
            System.IO.File.WriteAllText(@"..\..\..\..\comptest.txt", "");
        }
    }
}
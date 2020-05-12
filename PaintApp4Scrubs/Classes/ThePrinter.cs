namespace PaintApp4Scrubs.Classes
{
    public class ThePrinter
    {
        public static ThePrinter InstancePrinter = new ThePrinter();

        private ThePrinter(){}

        public static ThePrinter GetInstance()
        {
            return InstancePrinter;
        }

        public void PrintToFile(string text)
        {
            using System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"..\..\..\..\comptest.txt", true);
            file.WriteLine(text);
        }
        public void ClearFile()
        {
            System.IO.File.WriteAllText(@"..\..\..\..\comptest.txt", "");
        }
    }
}
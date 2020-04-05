using static System.Console;

namespace CoreEscuela.Util
{
    public static class Printer // does not allow create instance but the class is going to be used as an object by itself
    {
        public static void DrawLine (int size = 10) {
            WriteLine("".PadLeft(size,'='));
        }
        public static void WriteTitle (string title) {
            DrawLine(title.Length);
            WriteLine(title);
            DrawLine(title.Length);
        }
    }
}
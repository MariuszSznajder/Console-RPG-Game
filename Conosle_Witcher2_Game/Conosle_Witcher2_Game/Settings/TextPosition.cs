namespace Conosle_Witcher2_Game.Settings
{
    internal class TextPosition
    {
        public static void SetWriteLineTextPosition(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
        }
        public static string SetReadLineTextPosition()
        {
            string text = Convert.ToString(Console.ReadLine());
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            return text;
        }
        public static void SetTextPosition(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.Write(text);
        }
    }
}

using System;

namespace Lab_10
{
    class Print
    {
        /// <summary>
        /// Выводит 64 символа ===
        /// </summary>
        public static void Border()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("================================================================");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Выводит 64 символа === и указанный текст посередине
        /// </summary>
        /// <param name="Name">Текст</param>
        public static void Border(string Name)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string print = "\n";
            long length = 64 - Name.Length;

            for (int i = 0; i < length / 2; i++) print += "=";

            print += Name;

            for (int i = 0; i < length / 2 + 1; i++) print += "=";

            Console.Write(print + '\n');
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Выводит в консоль жёлтое сообщение
        /// </summary>
        /// <param name="message">Сообщение</param>
        public static void Yellow(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Выводит в консоль тёмно-зелёное сообщение
        /// </summary>
        /// <param name="message">Сообщение</param>
        public static void DarkGreen(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

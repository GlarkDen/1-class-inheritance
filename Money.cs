using System;

namespace Lab_10
{
    public class Money : IInit
    {
        // Хранящиеся деньги
        private double dollars;
        private double rubles;
        private double euro;

        /// <summary>
        /// Сумма всех счетов
        /// </summary>
        public double Sum
        {
            get => rubles + euro * 90 + dollars * 80;
        }

        /// <summary>
        /// Вносит некоторое количество денег на счета
        /// </summary>
        public void Init()
        {
            dollars = Math.Round(new Random().NextDouble() * 100, 3);
            rubles = Math.Round(new Random().NextDouble() * 10000, 3);
            euro = Math.Round(new Random().NextDouble() * 80, 3);
        }

        /// <summary>
        /// Показывает информацию о счетах
        /// </summary>
        public void ShowInformation()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ваши валюты:");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"Счёт в Долларах: {dollars}");
            Console.WriteLine($"Счёт в Рублях: {rubles}");
            Console.WriteLine($"Счёт в Евро: {euro}");
            Console.WriteLine($"Сумма счёта в рублях: {Sum}");
        }

        public Money(double dollars = 0, double rubles = 0, double euro = 0)
        {
            this.dollars = dollars;
            this.rubles = rubles;
            this.euro = euro;
        }

    }
}

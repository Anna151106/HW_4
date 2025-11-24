using System;
using System.Text;

namespace CurrencyConverterApp
{
    class Converter
    {
        private decimal usdRate;
        private decimal eurRate;

        public Converter(decimal usd, decimal eur)
        {
            usdRate = usd;
            eurRate = eur;
        }

        public decimal ConvertToUsd(decimal uahAmount)
        {
            return uahAmount / usdRate;
        }

        public decimal ConvertToEur(decimal uahAmount)
        {
            return uahAmount / eurRate;
        }

        public decimal ConvertFromUsd(decimal usdAmount)
        {
            return usdAmount * usdRate;
        }

        public decimal ConvertFromEur(decimal eurAmount)
        {
            return eurAmount * eurRate;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("--- Обмін валют ---");

            decimal currentUsdRate = 41.5m;
            decimal currentEurRate = 44.2m;

            Converter converter = new Converter(currentUsdRate, currentEurRate);

            Console.WriteLine($"Встановлено курс: USD = {currentUsdRate}, EUR = {currentEurRate}");
            Console.WriteLine("\nВиберіть операцію:");
            Console.WriteLine("1 - Гривні в Долари");
            Console.WriteLine("2 - Гривні в Євро");
            Console.WriteLine("3 - Долари в Гривні");
            Console.WriteLine("4 - Євро в Гривні");

            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();

            Console.Write("Введіть суму: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            decimal result = 0;

            switch (choice)
            {
                case "1":
                    result = converter.ConvertToUsd(amount);
                    Console.WriteLine($"{amount} UAH = {result:F2} USD");
                    break;
                case "2":
                    result = converter.ConvertToEur(amount);
                    Console.WriteLine($"{amount} UAH = {result:F2} EUR");
                    break;
                case "3":
                    result = converter.ConvertFromUsd(amount);
                    Console.WriteLine($"{amount} USD = {result:F2} UAH");
                    break;
                case "4":
                    result = converter.ConvertFromEur(amount);
                    Console.WriteLine($"{amount} EUR = {result:F2} UAH");
                    break;
                default:
                    Console.WriteLine("Невірний вибір операції.");
                    break;
            }

            Console.ReadKey();
        }
    }
}

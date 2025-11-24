using System;
using System.Text;

namespace GeographyInterface
{
    interface IGeographicObject
    {
        double X { get; set; }
        double Y { get; set; }
        string Name { get; set; }
        string Description { get; set; }

        string GetInformation();
    }

    class River : IGeographicObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double FlowSpeed { get; set; }
        public double TotalLength { get; set; }

        public string GetInformation()
        {
            return $"Річка: {Name} ({X}, {Y}), Опис: {Description}, Швидкість: {FlowSpeed} см/с, Довжина: {TotalLength} км";
        }
    }

    class Mountain : IGeographicObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double HighestPoint { get; set; }

        public string GetInformation()
        {
            return $"Гора: {Name} ({X}, {Y}), Опис: {Description}, Найвища точка: {HighestPoint} м";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IGeographicObject dnipro = new River
            {
                X = 50.45,
                Y = 30.52,
                Name = "Дніпро",
                Description = "Головна артерія",
                FlowSpeed = 120,
                TotalLength = 2201
            };

            IGeographicObject hoverla = new Mountain
            {
                X = 48.16,
                Y = 24.50,
                Name = "Говерла",
                Description = "Карпати",
                HighestPoint = 2061
            };

            Console.WriteLine(dnipro.GetInformation());
            Console.WriteLine(hoverla.GetInformation());

            Console.ReadKey();
        }
    }
}

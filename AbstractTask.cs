using System;
using System.Text;

namespace GeographyAbstract
{
    abstract class GeographicObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual string GetInformation()
        {
            return $"Об'єкт: {Name}, Координати: {X}, {Y}, Опис: {Description}";
        }
    }

    class River : GeographicObject
    {
        public double FlowSpeed { get; set; }
        public double TotalLength { get; set; }

        public override string GetInformation()
        {
            return base.GetInformation() + $", Швидкість течії: {FlowSpeed} см/с, Довжина: {TotalLength} км";
        }
    }

    class Mountain : GeographicObject
    {
        public double HighestPoint { get; set; }

        public override string GetInformation()
        {
            return base.GetInformation() + $", Найвища точка: {HighestPoint} м";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            River dnipro = new River
            {
                X = 50.45,
                Y = 30.52,
                Name = "Дніпро",
                Description = "Найбільша річка України",
                FlowSpeed = 120,
                TotalLength = 2201
            };

            Mountain hoverla = new Mountain
            {
                X = 48.16,
                Y = 24.50,
                Name = "Говерла",
                Description = "Найвища гора України",
                HighestPoint = 2061
            };

            Console.WriteLine(dnipro.GetInformation());
            Console.WriteLine(hoverla.GetInformation());

            Console.ReadKey();
        }
    }
}

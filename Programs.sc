using System;
using System.Collections.Generic;

namespace OfficeSimulator
{
        public abstract class Worker
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string WorkDay { get; set; }

        public Worker(string name)
        {
            Name = name;
            WorkDay = ""; 
        }

        public void Call()
        {
            WorkDay += "Дзвонив; ";
        }

        public void WriteCode()
        {
            WorkDay += "Писав код; ";
        }

        public void Relax()
        {
            WorkDay += "Відпочивав; ";
        }

        public abstract void FillWorkDay();
    }

    public class Developer : Worker
    {
        public Developer(string name) : base(name)
        {
            Position = "Розробник";
        }

        public override void FillWorkDay()
        {
            WriteCode();
            Call();
            Relax();
            WriteCode();
        }
    }

    public class Manager : Worker
    {
        private Random _random;

        public Manager(string name) : base(name)
        {
            Position = "Менеджер";
            _random = new Random();
        }

        public override void FillWorkDay()
        {
            int firstCallCount = _random.Next(1, 11);
            for (int i = 0; i < firstCallCount; i++)
            {
                Call();
            }

            Relax();

            int secondCallCount = _random.Next(1, 6);
            for (int i = 0; i < secondCallCount; i++)
            {
                Call();
            }
        }
    }

    public class Team
    {
        public string TeamName { get; set; }
        private List<Worker> _workers; 

        public Team(string teamName)
        {
            TeamName = teamName;
            _workers = new List<Worker>();
        }

        public void AddWorker(Worker worker)
        {
            
            worker.FillWorkDay();
            _workers.Add(worker);
        }

        public void ShowTeamInfo()
        {
            Console.WriteLine($"\nКоманда: {TeamName}");
            Console.WriteLine("Співробітники:");
            foreach (var worker in _workers)
            {
                Console.WriteLine($"- {worker.Name}");
            }
        }

        public void ShowDetailedInfo()
        {
            Console.WriteLine($"\nДетальна інформація про команду: {TeamName}");
            foreach (var worker in _workers)
            {
                Console.WriteLine($"{worker.Name} - {worker.Position} - {worker.WorkDay}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Введіть назву нової команди:");
            string teamName = Console.ReadLine();
            Team myTeam = new Team(teamName);

            bool continueWorking = true;

            while (continueWorking)
            {
                Console.WriteLine("\n--- МЕНЮ ---");
                Console.WriteLine("1. Додати Розробника");
                Console.WriteLine("2. Додати Менеджера");
                Console.WriteLine("3. Показати список команди");
                Console.WriteLine("4. Показати детальну інформацію (хто що робив)");
                Console.WriteLine("5. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть ім'я розробника: ");
                        string devName = Console.ReadLine();
                        myTeam.AddWorker(new Developer(devName));
                        Console.WriteLine("Розробника додано!");
                        break;

                    case "2":
                        Console.Write("Введіть ім'я менеджера: ");
                        string managerName = Console.ReadLine();
                        myTeam.AddWorker(new Manager(managerName));
                        Console.WriteLine("Менеджера додано!");
                        break;

                    case "3":
                        myTeam.ShowTeamInfo();
                        break;

                    case "4":
                        myTeam.ShowDetailedInfo();
                        break;

                    case "5":
                        continueWorking = false;
                        break;

                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}

using System;

namespace Company
{
    public abstract class Worker
    {
        private string name;
        private string position;
        private string workDay;
        public string Name 
        {
            get { return name; }
            set {
                if (string.IsNullOrEmpty(value)) name="Безіменний челік ";
                else name = value;
                 } 
        }
        public string Position { get { return position; } 
            set
            {
                if (string.IsNullOrEmpty(value)) position = "Невідома позиція ";
                else position = value;
            } 
        }
        public string WorkDay
        {
            get { return workDay; }
            set
            {
                if (string.IsNullOrEmpty(value)) workDay += "Нічого. ";
                else workDay = value;
            }
        }

        public Worker(string name)
        {
            Name = name;
        }

        public void Call()
        {
            WorkDay += "Телефонний дзвінок. ";
        }

        public void WriteCode()
        {
            WorkDay += "Написання коду. ";
        }

        public void Relax()
        {
            WorkDay += "Відпочинок. ";
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
        private Random random = new Random();

        public Manager(string name) : base(name)
        {
            Position = "Менеджер";
        }

        public override void FillWorkDay()
        {
            int callsBeforeRelax = random.Next(1, 10); 
            for (int i = 1; i <= callsBeforeRelax; i++)
            {
                Call();
            }
            Relax();
            int callsAfterRelax = random.Next(1, 5);
            for (int i = 1; i <= callsAfterRelax; i++)
            {
                Call();
            }
        }
    }
    public class Team
    {
        public string TeamName { get; set; }
        private List<Worker> workers = new List<Worker>();

        public Team(string teamName)
        {
            TeamName = teamName;
        }

        public void AddWorker(Worker worker)
        {
            workers.Add(worker);
        }

        public void ShowTeamInfo()
        {
            Console.WriteLine($"Команда: {TeamName}");
            foreach (var worker in workers)
            {
                Console.WriteLine(worker.Name);
            }
        }

        public void ShowDetailedTeamInfo()
        {
            Console.WriteLine($"Команда: {TeamName}");
            foreach (var worker in workers)
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

            Team team = new Team("Code Devils");

            Developer dev1 = new Developer("Олександ Слобода");
            dev1.FillWorkDay();
            team.AddWorker(dev1);

            Manager mgr1 = new Manager("Петрик П'яточкін");
            mgr1.FillWorkDay();
            team.AddWorker(mgr1);

            Developer dev2 = new Developer("Тарас Байконурів");
            dev2.FillWorkDay();
            team.AddWorker(dev2);

            Developer dev3 = new Developer("Георгій Гедзьович");
            dev3.FillWorkDay();
            team.AddWorker(dev3);

            team.ShowTeamInfo();

            Console.WriteLine("\nДетальна інформація про команду:");
            team.ShowDetailedTeamInfo();

            Console.ReadKey();
        }
    }

}

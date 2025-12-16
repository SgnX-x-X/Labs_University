using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool run = false;
            while (!run)
            {
                Console.Clear();
                Console.WriteLine("==========МЕНЮ=========");
                Console.WriteLine("1.Отгадай ответ");
                Console.WriteLine("2.Об авторе");
                Console.WriteLine("3.Сортировка Массивов");
                Console.WriteLine("4.Тетрис");
                Console.WriteLine("5.Выход"); 
                Console.Write("Введите ваш выбор(1-5):");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 5)
                {
                    Console.Write("Ошибка ввода, введите ваш выбор(1-5): ");
                }
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        MathGame.Game();
                        break;
                    case 2:
                        Console.Clear();
                        AboutAuthor.DisplayInformation();
                        break;
                    case 3:
                        Console.Clear();
                        int? size = Inputs.InputNull("Введите размер массива(по умолчанию 10):");
                        if (size == null)
                        {
                            ArraySorter sort = new ArraySorter();
                            sort.Task();
                        }
                        else
                        {
                            ArraySorter sort = new ArraySorter((int)size);
                            sort.Task();
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Tetris tetris = new Tetris();
                        tetris.Game();
                        break;
                    case 5:
                        Console.Clear();
                        run = Quit();
                        break;
                }
            }
        }
        static bool Quit()
        {
            bool ex = false;
            Console.Write("Вы действительно хотите выйти? \nд/н: ");
            string? exit = Console.ReadLine();
            while (exit != "д" && exit != "н")
            {
                Console.Write("Ошибка ввода, введите д/н:");
                exit = Console.ReadLine();
            }
            if (exit == "д")
            {
                ex = true;
            }
            Console.Clear();
            return ex;
        }
    }
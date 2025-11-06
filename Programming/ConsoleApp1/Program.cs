using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        bool run = false;
        while (!run)
        {
            Console.Write("==========МЕНЮ========= \n1.Отгадай ответ \n2.Об авторе \n3.Сортировка Массивов \n4.Выход \nВведите ваш выбор(1-4):");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 4)
            {
                Console.Write("Ошибка ввода, введите ваш выбор(1-4): ");
            }
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    FirstTask();
                    break;
                case 2:
                    Console.Clear();
                    SecondTask();
                    break;
                case 3:
                    Console.Clear();
                    ThirdTask();
                    break;
                case 4:
                    Console.Clear();
                    run = Quit();
                    break;
                case 5:
                    Console.CursorVisible = false;
                    Game game = new Game();
                    game.Start();
                    break;
            }
        }
    }
    static int Input(string text)
    {
        int result;
        Console.Write(text);
        while (!int.TryParse(Console.ReadLine(), out result) || result <= 0)
        {
            Console.WriteLine("Ошибка ввода, введите целое число больше 0:");
        }
        return result;
    }

    static void FirstTask()
    {
        int a = Input("Введите число А: ");
        int b = Input("Введите число Б: ");
        Console.Clear();
        Console.WriteLine("Попробуйте угадать результат, с точнойстью до 2 знаков поселе запятой за 3 попытки");
        double result = Formula(a, b);
        Console.Write("Введите число: ");
        double att;
        for (int i = 3; i > 0; i--)
        {
            while (!double.TryParse(Console.ReadLine(), out att))
            {
                Console.Write("Ошибка ввода, введите число:");
            }
            if (result == att)
            {
                Console.Write("Поздравляю вы угадали");
                i = 0;
            }
            else if (i != 1)
            {
                Console.Clear();
                Console.Write("Вы не угадали попробуйте снова \nКоличество оставшихся попыток: {0} \nВведите число:", i-1);
            }
            else
            {
                Console.Clear();
                Console.Write("Неповезло, вы проиграли");
            }
        }
        Console.WriteLine("");
        Console.Write("Чтобы вернуться в главное меню нажмите на любую кнопку");
        Console.ReadKey();
        Console.Clear();

    }
    static double Formula(int a, int b)
    {
        double numerator = Math.Log(Math.Pow(b, 5));
        double denominator = Math.Sin(a) + 1;
        double result = Math.PI * (numerator / denominator);
        result = Math.Round(result, 2);
        return result;
    }
    static void SecondTask()
    {
        Console.WriteLine("Гильфанов Александр Александрович, группа: 6101-090301D");
        Console.WriteLine("Чтобы вернуться в главное меню нажмите на любую кнопку");
        Console.ReadKey();
        Console.Clear();
    }
    static void ThirdTask()
    // Сортировка пузырьком. Сортировка вставками.
    {
        int[] array0 = CreateArray();
        PrintArray(array0,"Оригинальный массив: ",true);
        int[] arrayBubbble = ArrayCopy(array0);
        int[] arrayInsertion = ArrayCopy(array0);
        double timeBubbleSort = BubbleSort(arrayBubbble);
        Console.WriteLine($"Время сортировки пузырком: {timeBubbleSort}");
        PrintArray(arrayBubbble,"Результат сортировки пузырьком: ");
        double timeInsertSort = InsertionSort(arrayInsertion);
        Console.WriteLine($"Время сортировки вставками: {timeInsertSort}");
        PrintArray(arrayInsertion,"Результат сортировки вставками: ");
        Console.WriteLine("Чтобы вернуться в главное меню нажмите на любую кнопку");
        Console.ReadKey();
        Console.Clear();
     }
    static int[] CreateArray()
    {
        int size = Input("Введите размер массива:");
        Random rnd = new Random();
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = rnd.Next(10000);
        }
        return array;
    }
    static int[] ArrayCopy(int[] arr)
    {
        int[] copy = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            copy[i] = arr[i];
        }
        return copy;
    }
    static double BubbleSort(int[] arr)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
        stopwatch.Stop();
        return ((double)stopwatch.ElapsedTicks) / ((double)Stopwatch.Frequency);
    }
    static double InsertionSort(int[] arr)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 1; i < arr.Length; i++)
        {
            int k = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > k)
            {
                arr[j + 1] = arr[j];
                arr[j] = k;
                j--;
            }
        }
        stopwatch.Stop();
        return ((double)stopwatch.ElapsedTicks)/((double)Stopwatch.Frequency);
    }
    static void PrintArray(int[] arr,string text,bool message = false)
    {
        if (arr.Length <= 10)
        {
            Console.WriteLine(text + "{" + string.Join(", ",arr) + "}");
        }
        else if(message)
        {
            Console.WriteLine("Массивы не могут быть выведены на экран, так как длина массива больше 10.");
        }
    }
    static bool Quit(bool ex = false)
    {
        Console.WriteLine("Вы действительно хотите выйти? \nд/н");
        string ?exit = Console.ReadLine();
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
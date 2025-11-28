using System.Diagnostics;
/// <summary>
/// класс для сортировки массивов
/// </summary>
class ArraySorter
{
    private readonly int[] array;
    /// <summary>
    /// Конструктор для создание массива с заданным размером
    /// </summary>
    public ArraySorter(int size)
    {
        array = new int[size];
        Random rnd = new Random();
        for (int i = 0; i < size; i++)
        {
            array[i] = rnd.Next(10000);
        }
    }
    /// <summary>
    /// Конструктор для создание массива размером 10
    /// </summary>
    public ArraySorter() : this(10)
    {
    }
    /// <summary>
    /// Выполнение сортировки
    /// </summary>
    public void Task()
    {
        PrintArray(array, "Оригинальный массив: ", true);
        int[] arrayBubbble = ArrayCopy(array);
        int[] arrayInsertion = ArrayCopy(array);
        double timeBubbleSort = BubbleSort(arrayBubbble);
        Console.WriteLine($"Время сортировки пузырком: {timeBubbleSort}");
        PrintArray(arrayBubbble, "Результат сортировки пузырьком: ");
        double timeInsertSort = InsertionSort(arrayInsertion);
        Console.WriteLine($"Время сортировки вставками: {timeInsertSort}");
        PrintArray(arrayInsertion, "Результат сортировки вставками: ");
        Console.WriteLine("Чтобы вернуться в главное меню нажмите на любую кнопку");
        Console.ReadKey();
        Console.Clear();
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
        return ((double)stopwatch.ElapsedTicks) / ((double)Stopwatch.Frequency);
    }
    static void PrintArray(int[] arr, string text, bool message = false)
    {
        if (arr.Length <= 10)
        {
            Console.WriteLine(text + "{" + string.Join(", ", arr) + "}");
        }
        else if (message)
        {
            Console.WriteLine("Массивы не могут быть выведены на экран, так как длина массивов больше 10.");
        }
    }
}
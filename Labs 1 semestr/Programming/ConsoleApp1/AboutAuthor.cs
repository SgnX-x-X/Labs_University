/// <summary>
/// статический класс для вывода информации об авторе
/// </summary>
static class AboutAuthor
{
    const string AuthorInformation = "Гильфанов Александр Александрович, группа: 6101-090301D";
    /// <summary>
    /// Выводит информацию об авторе
    /// </summary>
    public static void DisplayInformation()
    {
        Console.WriteLine(AuthorInformation);
        Console.WriteLine("Чтобы вернуться в главное меню нажмите на любую кнопку");
        Console.ReadKey();
        Console.Clear();
    }
}
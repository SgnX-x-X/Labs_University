public interface ITetris
{
    void Game();
}

public class Tetris : ITetris
{
    // Настройки Поля
    static int boardWidth = 10;
    static int boardHeight = 20;
    static int[,] board = new int[boardWidth, boardHeight];
    static readonly Point[][] tetrominoes = new Point[][]
    {
        new Point[] { new Point(0, 0), new Point(-1, 0), new Point(1, 0), new Point(2, 0) },
        new Point[] { new Point(0, 0), new Point(1, 0), new Point(0, 1), new Point(1, 1) },
        new Point[] { new Point(0, 0), new Point(-1, 0), new Point(1, 0), new Point(0, -1) },
        new Point[] { new Point(0, 0), new Point(1, 0), new Point(0, 1), new Point(-1, 1) },
        new Point[] { new Point(0, 0), new Point(-1, 0), new Point(0, 1), new Point(1, 1) },
        new Point[] { new Point(0, 0), new Point(-1, 0), new Point(1, 0), new Point(1, -1) },
        new Point[] { new Point(0, 0), new Point(-1, 0), new Point(1, 0), new Point(-1, -1) }
    };
    // Текущая фигура
    static Point[] currentPiece;
    static Point currentPosition;
    static Random random = new Random();

    static bool gameOver = false;
    static int score = 0;

    //Основной Игровой Цикл
    public void Game()
    {
        Console.CursorVisible = false;
        SpawnPiece();
        DrawBoard();

        int frame = 0;
        int gameSpeed = 40;

        while (!gameOver)
        {
            frame++;
            // Обработка ввода 
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                HandleInput(key);
            }
            // Падение фигуры
            if (frame % gameSpeed == 0)
            {
                if (CanMove(currentPiece, currentPosition, 0, 1))
                {
                    currentPosition.Y++;
                }
                else
                {
                    LockPiece();
                    ClearLines();
                    SpawnPiece();
                    if (!CanMove(currentPiece, currentPosition, 0, 0))
                    {
                        gameOver = true;
                    }
                }
            }

            // Отрисовка
            DrawBoard();
            DrawPiece();
            Thread.Sleep(10);
        }

        // Конец Игры
        Console.Clear();
        Console.WriteLine("GAME OVER");
        Console.WriteLine($"Ваш счёт: {score}");
        Console.ReadKey();
        Console.Clear();
    }
    static void SpawnPiece()
    {
        currentPiece = tetrominoes[random.Next(tetrominoes.Length)];
        currentPosition = new Point(boardWidth / 2, 1); 
    }    static bool CanMove(Point[] piece, Point pos, int dx, int dy)
    {
        foreach (Point p in piece)
        {
            int newX = pos.X + p.X + dx;
            int newY = pos.Y + p.Y + dy;
            if (newX < 0 || newX >= boardWidth || newY >= boardHeight)
            {
                return false;
            }
            if (newY >= 0 && board[newX, newY] == 1)
            {
                return false;
            }
        }
        return true;
    }
    static void LockPiece()
    {
        foreach (Point p in currentPiece)
        {
            int x = currentPosition.X + p.X;
            int y = currentPosition.Y + p.Y;
            if (y >= 0)
            {
                board[x, y] = 1;
            }
        }
    }

    static void ClearLines()
    {
        int linesCleared = 0;
        for (int y = boardHeight - 1; y >= 0; y--) 
        {
            bool isLineFull = true;
            for (int x = 0; x < boardWidth; x++)
            {
                if (board[x, y] == 0)
                {
                    isLineFull = false;
                    break;
                }
            }

            if (isLineFull)
            {
                linesCleared++;
                for (int yAbove = y; yAbove > 0; yAbove--)
                {
                    for (int x = 0; x < boardWidth; x++)
                    {
                        board[x, yAbove] = board[x, yAbove - 1];
                    }
                }
                for (int x = 0; x < boardWidth; x++)
                {
                    board[x, 0] = 0;
                }
                y++;
            }
        }
        score += linesCleared * 100 * linesCleared;
    }
    static void RotatePiece()
    {
        Point[] rotatedPiece = new Point[currentPiece.Length];
        for (int i = 0; i < currentPiece.Length; i++)
        {
            rotatedPiece[i] = new Point(
                currentPiece[i].Y,
                -currentPiece[i].X
            );
        }
        if (CanMove(rotatedPiece, currentPosition, 0, 0))
        {
            currentPiece = rotatedPiece;
        }
    }
    // Логика Отрисовки
    static void DrawBoard()
    {
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.White;

        // Верхняя граница
        Console.WriteLine("╔" + new string('═', boardWidth * 2) + "╗");
        for (int y = 0; y < boardHeight; y++)
        {
            Console.Write("║"); // Левая граница
            for (int x = 0; x < boardWidth; x++)
            {
                if (board[x, y] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("■ ");
                }
                else
                {
                    Console.Write("  ");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("║");
        }
        Console.WriteLine("╚" + new string('═', boardWidth * 2) + "╝");
        Console.SetCursorPosition(boardWidth * 2 + 5, 2);
        Console.Write($"Счёт: {score}");
    }

    static void DrawPiece()
    {
        Console.ForegroundColor = ConsoleColor.Cyan; // Цвет текущей фигуры
        foreach (Point p in currentPiece)
        {
            int x = currentPosition.X + p.X;
            int y = currentPosition.Y + p.Y;
            if (y >= 0)
            {
                Console.SetCursorPosition(x * 2 + 1, y + 1);
                Console.Write("■ ");
            }
        }
        Console.ResetColor();
    }

    static void HandleInput(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.LeftArrow:
                if (CanMove(currentPiece, currentPosition, -1, 0))
                    currentPosition.X--;
                break;
            case ConsoleKey.RightArrow:
                if (CanMove(currentPiece, currentPosition, 1, 0))
                    currentPosition.X++;
                break;
            case ConsoleKey.DownArrow:
                if (CanMove(currentPiece, currentPosition, 0, 1))
                    currentPosition.Y++;
                break;
            case ConsoleKey.UpArrow:
            case ConsoleKey.Spacebar:
                // Вращение
                RotatePiece();
                break;
        }
    }
}
public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
class Tetromino
{
    int[,] shape;

    private static List<int[,]> shapes = new List<int[,]>
        {
            new int[,] {{1,1,1,1}},
            new int[,] {{1,1},{1,1}},
            new int[,] {{0,1,0},{1,1,1}},
            new int[,] {{1,0,0},{1,1,1}},
            new int[,] {{0,0,1},{1,1,1}},
            new int[,] {{1,1,0},{0,1,1}},
            new int[,] {{0,1,1},{1,1,0}},
        };
public List<(int, int)> GetBlocks(int dx = 0, int dy = 0)
        {
            var blocks = new List<(int, int)>();
            for (int i = 0; i < shape.GetLength(0); i++)
                for (int j = 0; j < shape.GetLength(1); j++)
                    if (shape[i, j] == 1)
                        blocks.Add((x + j + dx, y + i + dy));
            return blocks;
        }
     public static Tetromino GetRandom(Random rnd)
        {
            return new Tetromino(shapes[rnd.Next(shapes.Count)]);
        }
}
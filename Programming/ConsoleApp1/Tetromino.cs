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
     public static Tetromino GetRandom(Random rnd)
        {
            return new Tetromino(shapes[rnd.Next(shapes.Count)]);
        }
}
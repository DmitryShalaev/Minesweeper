using Core;

namespace Test {
    internal class Program {
        static void Main() {
            int Height = 25;
            int Width = 25;

            for(int ii = 0; ii < 10; ii++) {
                Minesweeper minesweeper = new(Height, Width, 100);

                Result d = minesweeper.CheckCell(1, 1);

                for(int i = 0; i < Height; i++) {
                    for(int j = 0; j < Width; j++) {

                        Console.Write($"{(minesweeper.Bombs[i * Width + j] == true ? "1" : "0")} ");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}

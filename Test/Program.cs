using Core;

namespace Test {
    internal class Program {
        static void Main() {
            int Height = 30;
            int Width = 30;

            Minesweeper minesweeper = new(Height, Width, 150);

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

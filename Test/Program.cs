using Core;

namespace Test {
    internal class Program {
        static void Main() {
            int Height = 25;
            int Width = 25;
            var random = new Random();
            while(true) {
                for(int ii = 0; ii < 3; ii++) {
                    Minesweeper minesweeper = new(Height, Width, random.Next(10, Width * Height / 2));

                minesweeper.CheckCell(1, 1);

                for(int i = 0; i < Height; i++) {
                    for(int j = 0; j < Width; j++) {

                        Console.Write($"{(minesweeper.Bombs[i * Width + j] == true ? "*" : " ")} ");



                    }

                    Console.Write("\t");
                    for(int j = 0; j < Width; j++) {

                        Result b = minesweeper.CheckCell(j, i);
                        Console.Write($"{(b.IsBomb ? "*" : b.NumberOfBombs == 0 ? " " : b.NumberOfBombs)} ");

                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine();
                }


                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}

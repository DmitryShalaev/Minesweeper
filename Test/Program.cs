using Core;

namespace Test
{
    internal class Program
    {
        static void Set(ref Dictionary<int, int> array, Result b)
        {
            foreach (var item in b.results)
            {
                if (item is not null)
                {

                    array[item.Shift] = item.NumberOfBombs == 0 ? -1 : item.NumberOfBombs;
                    Set(ref array, item);
                }

            }
        }



        static void Main()
        {
            int Height = 25;
            int Width = 25;
            var random = new Random();
            while (true)
            {
                for (int ii = 0; ii < 1; ii++)
                {
                    Minesweeper minesweeper = new(Height, Width, random.Next(10, Width * Height / 2));

                    minesweeper.CheckCell(1, 1);

                    Dictionary<int, int> array = Enumerable.Range(0, Height * Width).ToDictionary(i => i, i => 0);

                    for (int i = 0; i < Height; i++)
                    {
                        for (int j = 0; j < Width; j++)
                        {
                            Console.Write($"{(minesweeper.Bombs[i * Width + j] == true ? "*" : " ")} ");
                        }

                        Console.Write("\t");
                        for (int j = 0; j < Width; j++)
                        {
                            Result b = minesweeper.CheckCell(j, i);
                            Console.Write($"{(b.IsBomb ? "*" : b.NumberOfBombs == 0 ? " " : b.NumberOfBombs)} ");

                            if (b.NumberOfBombs == 0)
                            {
                                Set(ref array, b);
                            }

                        }

                        Console.WriteLine();
                    }

                    for (int i = 0; i < Height; i++)
                    {
                        for (int j = 0; j < Width; j++)
                        {
                            Console.Write($"{(array[i * Width + j] == -1 ? "#" : array[i * Width + j] == 0 ? " " : array[i * Width + j])} ");
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

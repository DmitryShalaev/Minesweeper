using System.Text;

using Core;

namespace Test {
    internal class Program {
        static void Set(string[] array, Result b) {
            foreach(Result? item in b.results) {
                if(item is not null) {
                    int index = item.Shift;
                    array[index] = item.NumberOfBombs == 0 ? " " : item.NumberOfBombs.ToString();
                    Set(array, item);
                }
            }
        }

        private static readonly int Height = 80;
        private static readonly int Width = 80;
        private static readonly int Bombs = 666;

        private static readonly int maxRowCoordWidth = (Height - 1).ToString().Length;
        private static readonly int maxColCoordWidth = (Width - 1).ToString().Length;

        static void Main() {
            while(true) {
                Minesweeper minesweeper = new(Height, Width, Bombs);
                string[] array = Enumerable.Repeat("'", Height * Width).ToArray();

                PrintTableHeader();
                PrintTable(array);

                while(true) {
                    try {
                        Console.Write("\n> ");
                        string? str = Console.ReadLine();
                        if(string.IsNullOrWhiteSpace(str)) break;
                        Console.Clear();

                        var t = str!.Split().Select(int.Parse).ToList();
                        Result b = minesweeper.CheckCell(t[0], t[1]);

                        PrintTableHeader();

                        if(b.IsBomb) {
                            PrintTableWithBombs(array, minesweeper);
                            Console.ReadKey();
                            break;
                        }

                        if(b.NumberOfBombs == 0) {
                            Set(array, b);
                            array[b.Shift] = " ";
                        } else array[b.Shift] = b.NumberOfBombs.ToString();

                        PrintTable(array);
                    } catch(Exception ex) {
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.Clear();
            }
        }

        static void PrintTableHeader() {
            var header = new StringBuilder();
            header.Append(new string(' ', maxRowCoordWidth + 3));
            for(int col = 0; col < Width; col++) {
                header.Append($"{col.ToString().PadLeft(maxColCoordWidth)} ");
            }

            header.AppendLine();

            header.Append(new string(' ', maxRowCoordWidth + 2));
            for(int col = 0; col < Width; col++) {
                header.Append(new string('-', maxColCoordWidth + 1));
            }

            header.AppendLine();

            Console.Write(header.ToString());
        }

        static void PrintTable(string[] array) {
            var sb = new StringBuilder();

            for(int row = 0; row < Height; row++) {
                sb.Append($"{row.ToString().PadLeft(maxRowCoordWidth)} | ");
                for(int col = 0; col < Width; col++) {
                    sb.Append($"{array[row * Width + col].PadLeft(maxColCoordWidth)} ");
                }

                sb.AppendLine();
            }

            Console.Write(sb.ToString());
        }

        static void PrintTableWithBombs(string[] array, Minesweeper minesweeper) {
            var sb = new StringBuilder();

            for(int row = 0; row < Height; row++) {
                sb.Append($"{row.ToString().PadLeft(maxRowCoordWidth)} | ");
                for(int col = 0; col < Width; col++) {
                    int index = row * Width + col;
                    sb.Append($"{(minesweeper.Bombs[index] ? "#" : array[index]).PadLeft(maxColCoordWidth)} ");
                }

                sb.AppendLine();
            }

            Console.Write(sb.ToString());
        }
    }
}
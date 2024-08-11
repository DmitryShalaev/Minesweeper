using Core;

namespace Test {
    internal class Program {
        static void Set(ref Dictionary<int, string> array, Result b) {
            foreach(Result? item in b.results) {
                if(item is not null) {

                    array[item.Shift] = $"{(item.IsBomb ? "#" : $"{(item.NumberOfBombs == 0 ? " " : item.NumberOfBombs.ToString())}")}";
                    Set(ref array, item);
                }
            }
        }

        static void Main() {
            int Height = 80;
            int Width = 80;
            var random = new Random();

            // Найти максимальную ширину для координат
            int maxRowCoordWidth = (Height - 1).ToString().Length;
            int maxColCoordWidth = (Width - 1).ToString().Length;

            while(true) {

                Minesweeper minesweeper = new(Height, Width, 666/*random.Next(50, Width * Height / 2)*/);

                var array = Enumerable.Range(0, Height * Width).ToDictionary(i => i, i => "\'");

                while(true) {
                    try {
                        Console.WriteLine();
                        string? str = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine();
                        if(!string.IsNullOrEmpty(str) && str != "") {
                            var t = str!.Split().Select(i => int.Parse(i.Trim())).ToList();

                            Result b = minesweeper.CheckCell(t[0], t[1]);

                            // Вывод заголовка таблицы (координаты сверху)
                            Console.Write(new string(' ', maxRowCoordWidth + 3)); // Пробелы для выравнивания
                            for(int col = 0; col < Width; col++) {
                                Console.Write($"{col.ToString().PadLeft(maxColCoordWidth)} ");
                            }

                            Console.WriteLine();

                            // Вывод разделительной линии
                            Console.Write(new string(' ', maxRowCoordWidth + 2));
                            for(int col = 0; col < Width; col++) {
                                Console.Write(new string('-', maxColCoordWidth + 1));
                            }

                            Console.WriteLine();

                            if(b.IsBomb) {
                                // Вывод данных таблицы с координатами слева
                                for(int row = 0; row < Height; row++) {
                                    // Вывод координаты строки слева
                                    Console.Write($"{row.ToString().PadLeft(maxRowCoordWidth)} | ");

                                    for(int col = 0; col < Width; col++) {
                                        Console.Write($"{(minesweeper.Bombs[row * Width + col] ? "#" : array[row * Width + col]).ToString().PadLeft(maxColCoordWidth)} ");
                                    }

                                    Console.WriteLine();
                                }

                                Console.ReadKey();
                                break;
                            }

                            if(b.NumberOfBombs == 0) {
                                array[b.Shift] = $"{(b.IsBomb ? "#" : $"{(b.NumberOfBombs == 0 ? " " : b.NumberOfBombs.ToString())}")}";
                                Set(ref array, b);
                            } else {
                                array[b.Shift] = $"{b.NumberOfBombs}";
                            }

                            // Вывод данных таблицы с координатами слева
                            for(int row = 0; row < Height; row++) {
                                // Вывод координаты строки слева
                                Console.Write($"{row.ToString().PadLeft(maxRowCoordWidth)} | ");

                                for(int col = 0; col < Width; col++) {
                                    Console.Write($"{array[row * Width + col].ToString().PadLeft(maxColCoordWidth)} ");
                                }

                                Console.WriteLine();
                            }
                        } else {
                            break;
                        }
                    } catch(Exception ex) {
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.Clear();
            }
        }
    }
}
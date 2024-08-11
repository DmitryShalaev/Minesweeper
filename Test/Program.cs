using Core;

namespace Test {
    internal class Program {
        static void Set(ref Dictionary<int, string> array, Result b) {
            foreach(Result? item in b.results) {
                if(item is not null) {

                    array[item.Shift] = $"{(item.IsBomb ? "*" : $"{(item.NumberOfBombs == 0 ? "#" : item.NumberOfBombs.ToString())}")}";
                    Set(ref array, item);
                }
            }
        }

        static void Main() {
            int Height = 25;
            int Width = 25;
            var random = new Random();
            while(true) {

                Minesweeper minesweeper = new(Height, Width, random.Next(50, Width * Height / 2));

                var array = Enumerable.Range(0, Height * Width).ToDictionary(i => i, i => "\"");

                while(true) {
                    Console.WriteLine();
                    string? str = Console.ReadLine();
                    Console.WriteLine();
                    if(!string.IsNullOrEmpty(str) && str != "") {
                        var t = str!.Split().Select(i => int.Parse(i.Trim())).ToList();
                        int x = t[0];
                        int y = t[1];

                        Result b = minesweeper.CheckCell(x, y);

                        if(b.IsBomb) {
                            array[b.Shift] = "*";
                            Console.WriteLine();
                            Console.WriteLine("GG");
                            Console.WriteLine();
                        }

                        if(b.NumberOfBombs == 0) {
                            array[b.Shift] = $"{(b.IsBomb ? "*" : $"{(b.NumberOfBombs == 0 ? "#" : b.NumberOfBombs.ToString())}")}";
                            Set(ref array, b);
                        } else {
                            array[b.Shift] = $"{b.NumberOfBombs}";
                        }

                        for(int i = 0; i < Height; i++) {
                            for(int j = 0; j < Width; j++) {
                                Console.Write($"{array[i * Width + j]} ");
                            }

                            Console.WriteLine();
                        }
                    } else {
                        break;
                    }
                }

                Console.Clear();
            }
        }
    }
}
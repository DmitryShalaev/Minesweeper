namespace Core {

    public class Result(bool isBomb, uint numberOfBombs) {
        public Result[] results = new Result[8];

        public bool IsBomb { get; set; } = isBomb;
        public uint NumberOfBombs { get; set; } = numberOfBombs;
    }

    public class Minesweeper {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int NumberOfBombs { get; private set; }

        public ByteArray Bombs { get; private set; }

        private bool FirstMove { get; set; } = true;

        public Minesweeper(int height, int width, int numberOfBombs) {
            if(height * width - 1 < numberOfBombs)
                throw new ArgumentOutOfRangeException(nameof(numberOfBombs), "Некорректное количество бомб.");

            Height = height;
            Width = width;
            NumberOfBombs = numberOfBombs;
            Bombs = new(height * width);
        }

        public Result CheckCell(int x, int y) {
            if(x >= Width || x < 0)
                throw new ArgumentOutOfRangeException(nameof(x), "Индекс вне диапазона.");
            if(y >= Height || y < 0)
                throw new ArgumentOutOfRangeException(nameof(y), "Индекс вне диапазона.");

            if(FirstMove) {
                MineTheField(x, y);
                FirstMove = false;
            }

            return new(false, 4);
        }

        private void MineTheField(int x, int y) {
            var _tmp = Enumerable.Range(0, Height * Width).ToList();

            _tmp.RemoveAt(y * Width + x);

            var random = new Random();
            for(int i = 0; i < NumberOfBombs; i++) {
                int num = random.Next(0, _tmp.Count);

                Bombs[_tmp[num]] = true;

                _tmp.RemoveAt(num);
            }
        }
    }
}

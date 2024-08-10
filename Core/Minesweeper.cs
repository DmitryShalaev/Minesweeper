namespace Core {

    /// <summary>
    /// Класс `Result` представляет результат проверки ячейки на наличие мины и количество мин в соседних ячейках.
    /// </summary>
    /// <remarks>
    /// Инициализирует новый экземпляр класса `Result` с указанными значениями.
    /// </remarks>
    /// <param name="isBomb">Указывает, содержит ли ячейка мину.</param>
    /// <param name="numberOfBombs">Количество мин в соседних ячейках.</param>
    public class Result(bool isBomb, uint numberOfBombs) {
        // Массив результатов проверки соседних ячеек.
        public Result[] results = new Result[8];

        /// <summary>
        /// Указывает, содержит ли ячейка мину.
        /// </summary>
        public bool IsBomb { get; set; } = isBomb;

        /// <summary>
        /// Количество мин в соседних ячейках.
        /// </summary>
        public uint NumberOfBombs { get; set; } = numberOfBombs;
    }

    /// <summary>
    /// Класс `Minesweeper` представляет игру "Сапёр", включая логику для инициализации игрового поля и проверки ячеек.
    /// </summary>
    public class Minesweeper {
        /// <summary>
        /// Высота игрового поля.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Ширина игрового поля.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Количество мин на игровом поле.
        /// </summary>
        public int NumberOfBombs { get; private set; }

        /// <summary>
        /// Массив, содержащий информацию о расположении мин.
        /// </summary>
        public ByteArray Bombs { get; private set; }

        // Указывает, является ли текущий ход первым.
        private bool FirstMove { get; set; } = true;

        /// <summary>
        /// Инициализирует новый экземпляр класса `Minesweeper` с заданными параметрами.
        /// </summary>
        /// <param name="height">Высота игрового поля.</param>
        /// <param name="width">Ширина игрового поля.</param>
        /// <param name="numberOfBombs">Количество мин на игровом поле.</param>
        /// <exception cref="ArgumentOutOfRangeException">Выбрасывается, если количество мин превышает допустимое значение.</exception>
        public Minesweeper(int height, int width, int numberOfBombs) {
            if(height * width - 1 < numberOfBombs)
                throw new ArgumentOutOfRangeException(nameof(numberOfBombs), "Некорректное количество бомб.");

            Height = height;
            Width = width;
            NumberOfBombs = numberOfBombs;
            Bombs = new(height * width);
        }

        /// <summary>
        /// Проверяет ячейку и возвращает результат, содержащий информацию о наличии мин и их количестве вокруг.
        /// </summary>
        /// <param name="x">Координата X ячейки.</param>
        /// <param name="y">Координата Y ячейки.</param>
        /// <returns>Объект `Result`, содержащий информацию о проверенной ячейке.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Выбрасывается, если координаты находятся вне допустимого диапазона.</exception>
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

        /// <summary>
        /// Расставляет мины на игровом поле, исключая ячейку с первой проверкой.
        /// </summary>
        /// <param name="x">Координата X первой ячейки, которая не должна содержать мину.</param>
        /// <param name="y">Координата Y первой ячейки, которая не должна содержать мину.</param>
        private void MineTheField(int x, int y) {
            var availableCells = Enumerable.Range(0, Height * Width).ToList();

            // Исключаем первую ячейку из списка.
            availableCells.RemoveAt(y * Width + x);

            var random = new Random();
            for(int i = 0; i < NumberOfBombs; i++) {
                int index = random.Next(0, availableCells.Count);

                // Устанавливаем мину.
                Bombs[availableCells[index]] = true;

                // Удаляем ячейку из списка доступных.
                availableCells.RemoveAt(index);
            }
        }
    }
}

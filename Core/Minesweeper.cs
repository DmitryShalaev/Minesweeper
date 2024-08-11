namespace Core {

    /// <summary>
    /// Класс `Result` представляет результат проверки ячейки на наличие мины и количество мин в соседних ячейках.
    /// </summary>
    public class Result {

        /// <summary>
        /// Конструктор класса <see cref="Result"/>. Инициализирует объект с заданной шириной поля, флагом наличия мины и количеством мин вокруг ячейки.
        /// </summary>
        /// <param name="width">Ширина игрового поля в ячейках. Используется для вычисления координат ячейки.</param>
        /// <param name="isBomb">Флаг, указывающий, содержит ли ячейка мину.</param>
        /// <param name="numberOfBombs">Количество мин вокруг ячейки.</param>
        public Result(int width, bool isBomb, int numberOfBombs) {
            Width = width;
            IsBomb = isBomb;
            NumberOfBombs = numberOfBombs;
        }

        /// <summary>
        /// Конструктор класса <see cref="Result"/>. Инициализирует объект с заданной шириной поля и устанавливает начальные значения для флага наличия мины и количества мин.
        /// </summary>
        /// <param name="width">Ширина игрового поля в ячейках. Используется для вычисления координат ячейки.</param>
        public Result(int width) {
            Width = width;
            IsBomb = false;
            NumberOfBombs = 0;
        }

        /// <summary>
        /// Массив результатов проверки соседних ячеек.
        /// </summary>
        public Result[] results = new Result[8];

        /// <summary>
        /// Указывает, содержит ли ячейка мину.
        /// </summary>
        public bool IsBomb { get; set; }

        /// <summary>
        /// Количество мин в соседних ячейках.
        /// </summary>
        public int NumberOfBombs { get; set; }

        /// <summary>
        /// Ширина игрового поля в ячейках.
        /// </summary>
        private int Width { get; set; }

        /// <summary>
        /// Координата X ячейки на игровом поле.
        /// </summary>
        public int X => Shift / Width;

        /// <summary>
        /// Координата Y ячейки на игровом поле.
        /// </summary>
        public int Y => Shift % Width;

        /// <summary>
        /// Смещение ячейки на игровом поле, представляющее её позицию в линейной системе координат.
        /// </summary>
        public int Shift { get; set; }
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

        /// <summary>
        /// Указывает, является ли текущий ход первым.
        /// </summary>
        private bool FirstMove { get; set; } = true;

        /// <summary>
        /// Возвращает массив смещений всех соседних ячеек относительно текущей ячейки, включая угловые.
        /// </summary>
        /// <returns>Массив смещений для всех восьми соседних ячеек.</returns>
        private int[] GetAllNeighbors() => [
                 -Width - 1, -Width, -Width + 1,  // Верхний ряд
                        - 1,                + 1,  // Левый и правый соседи
                 +Width - 1, +Width, +Width + 1   // Нижний ряд
        ];

        /// <summary>
        /// Возвращает массив смещений только для соседних ячеек по горизонтали и вертикали относительно текущей ячейки.
        /// </summary>
        /// <returns>Массив смещений для соседних ячеек сверху, снизу, слева и справа.</returns>
        private int[] GetNeighbors() => [
                    -Width,       // Верхний ряд
                - 1,       + 1,   // Левый и правый соседи
                    +Width        // Нижний ряд
        ];

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

            int shift = y * Width + x;

            if(FirstMove) {
                MineTheField(shift);
                FirstMove = false;
            }

            if(Bombs[shift])
                return new(Width, true, 0) { Shift = shift };

            int NumberOfBombs = GetNumberOfBombs(shift);
            if(NumberOfBombs != 0)
                return new(Width, false, NumberOfBombs) { Shift = shift };

            HashSet<int> hash = [];
            Result result = new(Width);
            int[] neighbors = GetNeighbors();
            GetEmptyRegion(shift, ref result!, neighbors, hash);

            return result!;
        }

        /// <summary>
        /// Рекурсивно проверяет регион пустых ячеек и обновляет объект результата с информацией о проверенной области.
        /// </summary>
        /// <param name="shift">Смещение текущей ячейки в линейной системе координат.</param>
        /// <param name="result">Объект <see cref="Result"/> для сохранения информации о проверенной области. Может быть заменен на <c>null</c>, если ячейка уже проверена или содержит мину.</param>
        /// <param name="neighbors">Массив смещений для определения соседних ячеек.</param>
        /// <param name="hash">Множество <see cref="HashSet{T}"/>, содержащее смещения уже проверенных ячеек, чтобы избежать повторной проверки.</param>
        private void GetEmptyRegion(int shift, ref Result? result, int[] neighbors, HashSet<int> hash) {
            if(result is null || hash.Contains(shift)) {
                result = null;
                return;
            }

            // Добавляем текущее смещение в множество проверенных
            hash.Add(shift);

            // Обновляем смещение в объекте результата
            result.Shift = shift;

            // Получаем количество мин вокруг текущей ячейки
            int NumberOfBombs = GetNumberOfBombs(shift);
            if(NumberOfBombs != 0) {
                result.NumberOfBombs = NumberOfBombs;
                return;
            }

            // Рекурсивно проверяем соседние ячейки, если они валидны
            for(int i = 0; i < 4; i++) {
                if(IsNeighborCellValid(shift, neighbors[i])) {
                    result.results[i] = new Result(Width);
                    GetEmptyRegion(shift + neighbors[i], ref result.results[i]!, neighbors, hash);
                }
            }
        }

        /// <summary>
        /// Расставляет мины на игровом поле, исключая ячейку с первой проверкой.
        /// </summary>
        /// <param name="shift">Смещение, представляющее ячейку, которая не должна содержать мину.</param>
        private void MineTheField(int shift) {
            var availableCells = Enumerable.Range(0, Height * Width).ToList();

            // Исключаем первую ячейку из списка.
            availableCells.RemoveAt(shift);

            var random = new Random();
            for(int i = 0; i < NumberOfBombs; i++) {
                int index = random.Next(0, availableCells.Count);

                // Устанавливаем мину.
                Bombs[availableCells[index]] = true;

                // Удаляем ячейку из списка доступных.
                availableCells.RemoveAt(index);
            }
        }

        /// <summary>
        /// Вычисляет количество мин, находящихся в соседних клетках относительно заданного смещения.
        /// </summary>
        /// <param name="shift">Смещение, определяющее текущую клетку.</param>
        /// <returns>Количество мин в соседних клетках.</returns>
        private int GetNumberOfBombs(int shift) {
            int number = 0;

            foreach(int offset in GetAllNeighbors()) {
                // Увеличиваем счетчик, если соседняя клетка находится в пределах и содержит мину.
                if(IsNeighborCellValid(shift, offset))
                    number += Bombs[shift + offset] ? 1 : 0;
            }

            return number;
        }

        /// <summary>
        /// Проверяет, является ли соседняя клетка допустимой (находится в пределах игрового поля и не выходит за край).
        /// </summary>
        /// <param name="shift">Смещение текущей клетки.</param>
        /// <param name="offset">Смещение относительно текущей клетки для проверки соседней клетки.</param>
        /// <returns>Значение `true`, если соседняя клетка допустима; иначе `false`.</returns>
        private bool IsNeighborCellValid(int shift, int offset) {
            int neighborShift = shift + offset;

            // Проверка на границы
            bool isInBounds = neighborShift >= 0 && neighborShift < Width * Height;

            // Проверка на левый и правый край
            bool isNotOutOfLeftBound = shift % Width != 0 || offset != -Width - 1 && offset != -1 && offset != +Width - 1;
            bool isNotOutOfRightBound = shift % Width != Width - 1 || offset != -Width + 1 && offset != +1 && offset != +Width + 1;

            return isInBounds && isNotOutOfLeftBound && isNotOutOfRightBound;
        }
    }
}

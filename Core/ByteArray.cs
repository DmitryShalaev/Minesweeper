using System.Collections;

/// <summary>
/// Класс `ByteArray` представляет собой массив битов, который может быть индексирован как массив логических значений.
/// Поддерживает изменение размера и реализует интерфейс `IEnumerable<bool>`.
/// </summary>
namespace Core {
    public class ByteArray : IEnumerable<bool> {
        /// <summary>
        /// Внутренний массив байтов для хранения битов.
        /// </summary>
        private byte[]? data;

        /// <summary>
        /// Длина массива в битах.
        /// </summary>
        private uint length;

        /// <summary>
        /// Получает или задает длину массива в битах.
        /// При задании новой длины выполняется изменение размера массива при необходимости.
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если новая длина отрицательна.</exception>
        public uint Length {
            get => length;
            set {
                if(value > (data?.Length ?? 0) * 8) {
                    Resize(value);
                } else {
                    length = value;
                }
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса `ByteArray` с указанной длиной в битах.
        /// </summary>
        /// <param name="length">Длина массива в битах.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если длина отрицательна.</exception>
        public ByteArray(uint length) => Resize(length);

        /// <summary>
        /// Индексатор для доступа к биту по указанному индексу.
        /// </summary>
        /// <param name="index">Индекс бита.</param>
        /// <returns>Значение бита (true/false).</returns>
        /// <exception cref="ArgumentOutOfRangeException">Выбрасывается, если индекс вне допустимого диапазона.</exception>
        public bool this[int index] {
            get => index < 0 || index >= length
                    ? throw new ArgumentOutOfRangeException(nameof(index), "Индекс вне диапазона.")
                    : (data![index / 8] & (1 << (index % 8))) != 0;
            set {
                if(index < 0 || index >= length)
                    throw new ArgumentOutOfRangeException(nameof(index), "Индекс вне диапазона.");

                int byteIndex = index / 8;
                int bitIndex = index % 8;

                if(value) {
                    data![byteIndex] |= (byte)(1 << bitIndex);
                } else {
                    data![byteIndex] &= (byte)~(1 << bitIndex);
                }
            }
        }

        /// <summary>
        /// Изменяет размер массива, чтобы вместить указанное количество битов.
        /// </summary>
        /// <param name="newSize">Новая длина в битах.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если новая длина отрицательна.</exception>
        private void Resize(uint newSize) {
            uint newByteSize = (newSize + 7) / 8; // Округление вверх для количества байтов
            byte[] newByteArray = new byte[newByteSize];

            if(data != null)
                Array.Copy(data, newByteArray, Math.Min(data.Length, newByteArray.Length));

            data = newByteArray;
            length = newSize;
        }

        /// <summary>
        /// Возвращает перечислитель, выполняющий перебор всех битов в массиве.
        /// </summary>
        /// <returns>Перечислитель для перебора битов.</returns>
        public IEnumerator<bool> GetEnumerator() {
            for(int i = 0; i < length; i++) {
                yield return this[i];
            }
        }

        /// <summary>
        /// Возвращает перечислитель, выполняющий перебор всех битов в массиве (неявная реализация интерфейса `IEnumerable`).
        /// </summary>
        /// <returns>Перечислитель для перебора битов.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

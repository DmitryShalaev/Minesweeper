using Core;

namespace Test {
    internal class Program {
        static void Main(string[] args) {
            ByteArray bools = new(9);
            bools[1] = true;

            foreach(bool b in bools) {
                Console.Write($"{(b == true ? 1 : 0)} ");
            }
        }
    }
}

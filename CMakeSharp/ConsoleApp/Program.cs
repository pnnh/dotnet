 

using Molecule.Helpers;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var bizId = MIDHelper.NewIdendity();
            Console.WriteLine($"bizId: {bizId}");
        }
    }
}
